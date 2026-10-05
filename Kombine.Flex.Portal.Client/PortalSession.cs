namespace Kombine.Flex.Portal.Client;

/// <summary>Temporary login credentials. Never log or persist this object.</summary>
public sealed class PortalCredentials
{
    /// <summary>Creates credentials fetched by the application only when login is needed.</summary>
    public PortalCredentials(string email, string password) { Email = email; Password = password; }
    /// <summary>Account email.</summary>
    public string Email { get; }
    /// <summary>Secret password; not retained by PortalSession.</summary>
    public string Password { get; }
}

/// <summary>Immutable session snapshot. Contains a secret bearer token.</summary>
public sealed class PortalSessionToken
{
    internal PortalSessionToken(string token, DateTimeOffset expires, DateTimeOffset renew)
    { AccessToken = token; ExpiresUtc = expires; RenewAfterUtc = renew; }
    /// <summary>Opaque bearer token for the fixed endpoint. Never log it.</summary>
    public string AccessToken { get; }
    /// <summary>Conservative expiry measured from the start of authentication.</summary>
    public DateTimeOffset ExpiresUtc { get; }
    internal DateTimeOffset RenewAfterUtc { get; }
}

/// <summary>One account/login at one API endpoint. No timers or automatic write retries. Applications decide which activity may renew a session.</summary>
public sealed class PortalSession
{
    private readonly object _gate = new();
    private readonly Func<DateTimeOffset> _utcNow;
    private readonly SemaphoreSlim _authentication = new(1, 1);
    private readonly Func<CancellationToken, Task<PortalCredentials>>? _credentials;
    private readonly Func<PortalApiClient> _factory;
    private PortalSessionToken? _current;
    private int _version;
    private bool _loggedOut;

    /// <summary>Creates an interactive session, or a configured-account session with an optional credential provider. Factory clients are disposed after use.</summary>
    public PortalSession(Uri endpoint, Func<CancellationToken, Task<PortalCredentials>>? credentials = null,
        Func<PortalApiClient>? clientFactory = null, Func<DateTimeOffset>? utcNow = null)
    {
        using var validation = new PortalApiClient(endpoint);
        Endpoint = validation.Endpoint;
        _utcNow = utcNow ?? (() => DateTimeOffset.UtcNow);
        _credentials = credentials;
        _factory = clientFactory ?? (() => new PortalApiClient(Endpoint));
    }
    /// <summary>Fixed API endpoint. Never share this session across distinct user logins.</summary>
    public Uri Endpoint { get; }
    /// <summary>Current immutable snapshot, or null before login/after logout.</summary>
    public PortalSessionToken? Current { get { lock (_gate) return _current; } }
    /// <summary>Clears the token and disables automatic login. Pending authentication cannot restore it.</summary>
    public void ClearSession() { lock (_gate) { _version++; _current = null; _loggedOut = true; } }

    /// <summary>Explicit login, also usable after logout. Does not retain the password.</summary>
    public async Task<PortalSessionToken> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        int version;
        lock (_gate) { version = ++_version; _current = null; _loggedOut = false; }
        await _authentication.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            CheckVersion(version);
            using var api = NewClient();
            var started = _utcNow();
            var response = await api.LoginAsync(email, password, cancellationToken).ConfigureAwait(false);
            cancellationToken.ThrowIfCancellationRequested();
            return Save(response, started, version);
        }
        finally { _authentication.Release(); }
    }
    /// <summary>Imports a trusted unexpired session, for example from an authenticated protected cookie.</summary>
    public void Restore(string token, DateTimeOffset expiresUtc)
    {
        using var api = NewClient();
        api.AccessToken = token;
        if (string.IsNullOrEmpty(token) || expiresUtc <= _utcNow()) throw new ArgumentException("An unexpired session is required.");
        lock (_gate) { _version++; _loggedOut = false; _current = new PortalSessionToken(token, expiresUtc, expiresUtc.AddSeconds(-60)); }
    }
    /// <summary>Gets a valid token for actual application/user activity, renewing only when necessary.</summary>
    public Task<PortalSessionToken> GetTokenAsync(CancellationToken cancellationToken = default) => AuthenticateAsync(false, cancellationToken);
    /// <summary>Explicit activity-triggered renewal. Concurrent renewals share the new snapshot.</summary>
    public Task<PortalSessionToken> RenewAsync(CancellationToken cancellationToken = default) => AuthenticateAsync(true, cancellationToken);
    /// <summary>Creates an independent client with a valid session token. Caller must dispose it.</summary>
    public async Task<PortalApiClient> CreateClientAsync(CancellationToken cancellationToken = default)
    {
        var token = await GetTokenAsync(cancellationToken).ConfigureAwait(false);
        var api = NewClient();
        api.AccessToken = token.AccessToken;
        api.AttachSession(this);
        return api;
    }
    /// <summary>Runs a side-effect-free callback with at most one retry after 401. Never use for writes or return the client.</summary>
    public async Task<T> ExecuteReadAsync<T>(Func<PortalApiClient, CancellationToken, Task<T>> operation, CancellationToken cancellationToken = default)
    {
        if (operation is null) throw new ArgumentNullException(nameof(operation));
        for (var attempt = 0; attempt < 2; attempt++)
        {
            var token = await GetTokenAsync(cancellationToken).ConfigureAwait(false);
            using var api = NewClient();
            api.AccessToken = token.AccessToken;
            try { return await operation(api, cancellationToken).ConfigureAwait(false); }
            catch (PortalApiException ex) when (ex.StatusCode == 401)
            {
                lock (_gate) { if (ReferenceEquals(_current, token)) _current = null; }
                if (attempt != 0 || _credentials is null) throw;
            }
        }
        throw new InvalidOperationException("The read could not be completed.");
    }
    private async Task<PortalSessionToken> AuthenticateAsync(bool force, CancellationToken ct)
    {
        PortalSessionToken? observed; int version;
        lock (_gate) { if (_loggedOut) throw new InvalidOperationException("Login is required."); observed = _current; version = _version; }
        await _authentication.WaitAsync(ct).ConfigureAwait(false);
        try
        {
            CheckVersion(version);
            var current = Current;
            var started = _utcNow();
            if (current is not null && started < current.RenewAfterUtc && (!force || !ReferenceEquals(current, observed))) return current;
            using var api = NewClient();
            ManagerSessionResponse? response = null;
            if (current is not null && started < current.ExpiresUtc)
            {
                api.AccessToken = current.AccessToken;
                try { response = await api.RenewManagerSessionAsync(ct).ConfigureAwait(false); }
                catch (PortalApiException ex) when (ex.StatusCode == 401)
                {
                    lock (_gate) { if (ReferenceEquals(_current, current)) _current = null; }
                    if (_credentials is null) throw;
                }
            }
            if (response is null)
            {
                CheckVersion(version);
                if (_credentials is null) throw new InvalidOperationException("Login is required.");
                var credentials = await _credentials(ct).ConfigureAwait(false)
                    ?? throw new InvalidOperationException("Login credentials are unavailable.");
                CheckVersion(version);
                started = _utcNow();
                response = await api.LoginAsync(credentials.Email, credentials.Password, ct).ConfigureAwait(false);
            }
            ct.ThrowIfCancellationRequested();
            return Save(response, started, version);
        }
        finally { _authentication.Release(); }
    }
    private PortalSessionToken Save(ManagerSessionResponse response, DateTimeOffset started, int version)
    {
        if (response is null || !string.Equals(response.TokenType, "Bearer", StringComparison.OrdinalIgnoreCase)
            || response.ExpiresIn is not > 0 || string.IsNullOrEmpty(response.AccessToken)) throw new InvalidDataException("The API returned an incomplete session.");
        using var api = NewClient();
        api.AccessToken = response.AccessToken;
        var expires = started.AddSeconds(response.ExpiresIn.Value);
        if (expires <= _utcNow()) throw new InvalidDataException("The API session has already expired.");
        var token = new PortalSessionToken(response.AccessToken!, expires, expires.AddSeconds(-Math.Min(60.0, response.ExpiresIn.Value / 10.0)));
        lock (_gate) { CheckVersion(version); _current = token; return token; }
    }
    private void CheckVersion(int version)
    {
        lock (_gate) { if (_loggedOut || _version != version) throw new OperationCanceledException("The session changed during authentication."); }
    }
    private PortalApiClient NewClient()
    {
        var api = _factory() ?? throw new InvalidOperationException("The client factory returned no client.");
        if (api.Endpoint != Endpoint) { api.Dispose(); throw new InvalidOperationException("The session endpoint cannot change."); }
        return api;
    }
}
