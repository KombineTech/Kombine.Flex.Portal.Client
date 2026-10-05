using System.Net.Http.Headers;

namespace Kombine.Flex.Portal.Client;

/// <summary>Typed, tenant-endpoint-bound HTTP client. All business rules remain in the API.</summary>
public partial class PortalApiClient : IDisposable
{
    private Uri _endpoint = null!;
    private bool _ownsHttpClient;
    private string? _accessToken;
    private int _sessionVersion;
    private readonly object _sessionLock = new();
    private PortalSession? _managedSession;

    /// <summary>Creates a client with its own transport, with cookies and redirects disabled.</summary>
    public PortalApiClient(Uri apiBaseUri) : this(CreateTransport(apiBaseUri)) => _ownsHttpClient = true;

    /// <summary>Creates a client that obtains/renews its token on each use through a shared session. Disposing it does not log out that session.</summary>
    public PortalApiClient(PortalSession session) : this(session?.Endpoint ?? throw new ArgumentNullException(nameof(session))) => AttachSession(session);

    internal void AttachSession(PortalSession session)
    {
        if (session.Endpoint != Endpoint) throw new ArgumentException("The session endpoint cannot change.", nameof(session));
        _managedSession = session;
    }

    /// <summary>The fixed endpoint to which this instance sends requests.</summary>
    public Uri Endpoint => _endpoint;

    /// <summary>Optional client address forwarded by a trusted portal server for login diagnostics. Never used for authorization.</summary>
    public string? LoginClientAddress { get; set; }

    /// <summary>Opaque bearer token for this endpoint only. Never put it in URLs or logs.</summary>
    public string? AccessToken
    {
        get => Volatile.Read(ref _accessToken);
        set
        {
            if (value is not null && (string.IsNullOrWhiteSpace(value) || value.Any(char.IsWhiteSpace)))
                throw new ArgumentException("An access token must be a nonempty token without whitespace.", nameof(value));
            lock (_sessionLock)
            {
                _sessionVersion++;
                _managedSession = null;
                Volatile.Write(ref _accessToken, value);
            }
        }
    }

    /// <summary>Logs in through LoginManager and retains the returned token in memory. Does not store the password or retry.</summary>
    public async Task<ManagerSessionResponse> LoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        if (email is null) throw new ArgumentNullException(nameof(email));
        if (password is null) throw new ArgumentNullException(nameof(password));
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("An email address is required.", nameof(email));
        if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("A password is required.", nameof(password));
        int version;
        lock (_sessionLock)
        {
            ClearSession();
            version = _sessionVersion;
        }
        var session = await LoginManagerAsync(x_Portal_Login_Client_IP: LoginClientAddress, body: new ManagerLoginRequest { Email = email, Password = password }, cancellationToken: cancellationToken).ConfigureAwait(false);
        cancellationToken.ThrowIfCancellationRequested();
        if (!string.Equals(session.TokenType, "Bearer", StringComparison.OrdinalIgnoreCase)
            || string.IsNullOrWhiteSpace(session.AccessToken) || session.AccessToken.Any(char.IsWhiteSpace)
            || session.ExpiresIn is not > 0)
            throw new InvalidDataException("The API returned an incomplete manager session.");
        // Logging out while an HTTP login is pending must not restore the old session.
        lock (_sessionLock)
        {
            if (version != _sessionVersion) throw new OperationCanceledException("The session changed during login.");
            Volatile.Write(ref _accessToken, session.AccessToken);
        }
        return session;
    }

    /// <summary>Forgets this client's token. The API has no logout/revocation endpoint; the issued token retains its server-side expiry.</summary>
    public void ClearSession() => AccessToken = null;

    partial void Initialize()
    {
        if (_httpClient is null) throw new ArgumentNullException(nameof(_httpClient));
        _endpoint = ValidateEndpoint(_httpClient.BaseAddress);
    }

    partial void PrepareRequest(HttpClient client, HttpRequestMessage request, string url)
    {
        if (client.BaseAddress != _endpoint || new Uri(_endpoint, url).GetLeftPart(UriPartial.Authority) != _endpoint.GetLeftPart(UriPartial.Authority))
            throw new InvalidOperationException("Create a separate client for a different API endpoint.");
        // Do not mutate HttpClient.DefaultRequestHeaders: unrelated users can share a transport.
        if (AccessToken is { } token) request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Headers.CacheControl = new CacheControlHeaderValue { NoStore = true };
    }

    /// <summary>Disposes the owned transport and clears the token; injected HttpClient instances remain caller-owned.</summary>
    public void Dispose()
    {
        ClearSession();
        if (_ownsHttpClient) _httpClient.Dispose();
        GC.SuppressFinalize(this);
    }

    private static HttpClient CreateTransport(Uri endpoint) => new(new HttpClientHandler { AllowAutoRedirect = false, UseCookies = false })
    { BaseAddress = ValidateEndpoint(endpoint), Timeout = TimeSpan.FromSeconds(30) };

    private static Uri ValidateEndpoint(Uri? endpoint)
    {
        if (endpoint is null || !endpoint.IsAbsoluteUri || !string.IsNullOrEmpty(endpoint.UserInfo)
            || !string.IsNullOrEmpty(endpoint.Query) || !string.IsNullOrEmpty(endpoint.Fragment)
            || endpoint.Scheme != Uri.UriSchemeHttps && !(endpoint.Scheme == Uri.UriSchemeHttp && endpoint.IsLoopback)
            || !endpoint.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
            throw new ArgumentException("Use an absolute HTTPS API base URL ending in '/'. HTTP is allowed only on loopback for local tests.", nameof(endpoint));
        return endpoint;
    }
}
