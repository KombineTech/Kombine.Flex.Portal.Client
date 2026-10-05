using System;

#if PORTAL_NET45
namespace Kombine.Flex.Portal.Client.Net45
#elif PORTAL_COMPACT20
namespace Kombine.Flex.Portal.Client.Compact20
#else
namespace Kombine.Flex.Portal.Client.Net20
#endif
{
    /// <summary>Obtains credentials only when a new login is necessary. Do not log the result.</summary>
    public delegate PortalCredentials PortalCredentialsProvider();
    /// <summary>Creates a caller-owned client for the fixed endpoint.</summary>
    public delegate PortalApiClient PortalClientFactory();
    /// <summary>A caller-declared side-effect-free operation, eligible for one retry after HTTP 401.</summary>
    public delegate T PortalRead<T>(PortalApiClient client);

    /// <summary>Login credentials, used temporarily and never retained by the session.</summary>
    public sealed class PortalCredentials
    {
        private readonly string _email, _password;
        /// <summary>Creates credentials. The provider should read current application configuration.</summary>
        public PortalCredentials(string email, string password) { _email = email; _password = password; }
        /// <summary>Account email.</summary>
        public string Email { get { return _email; } }
        /// <summary>Secret password. Never log or persist this object.</summary>
        public string Password { get { return _password; } }
    }

    /// <summary>Immutable session snapshot. Contains a secret token; never log or serialize it to a browser.</summary>
    public sealed class PortalSessionToken
    {
        private readonly string _token;
        private readonly DateTime _expires, _renew;
        internal PortalSessionToken(string token, DateTime expires, DateTime renew) { _token = token; _expires = expires; _renew = renew; }
        /// <summary>Opaque bearer token for the session's fixed endpoint.</summary>
        public string AccessToken { get { return _token; } }
        /// <summary>Conservative UTC expiry, measured from the start of authentication.</summary>
        public DateTime ExpiresUtc { get { return _expires; } }
        internal DateTime RenewAfterUtc { get { return _renew; } }
    }

    /// <summary>One account/login at one endpoint. Renews on use, never on a background timer. Dispose clients independently; ClearSession logs out this session.</summary>
    public sealed class PortalSession
    {
        private readonly object _gate = new object(), _authentication = new object();
        private readonly Uri _endpoint;
        private readonly PortalCredentialsProvider _credentials;
        private readonly PortalClientFactory _factory;
        private PortalSessionToken _current;
        private int _version;
        private bool _loggedOut;
        /// <summary>Interactive session; an expired token requires explicit Login.</summary>
        public PortalSession(Uri endpoint) : this(endpoint, null, null) { }
        /// <summary>Configured-account session. Credentials are fetched only for login.</summary>
        public PortalSession(Uri endpoint, PortalCredentialsProvider credentials) : this(endpoint, credentials, null) { }
        /// <summary>Uses a factory for transport settings. Each returned client is disposed after use and must target this endpoint.</summary>
        public PortalSession(Uri endpoint, PortalCredentialsProvider credentials, PortalClientFactory factory)
        {
            using (PortalApiClient validation = new PortalApiClient(endpoint)) { _endpoint = validation.Endpoint; }
            _credentials = credentials; _factory = factory;
        }
        /// <summary>Fixed API endpoint. Use a distinct session for another account or endpoint.</summary>
        public Uri Endpoint { get { return _endpoint; } }
        /// <summary>Current immutable snapshot, or null before login/after logout.</summary>
        public PortalSessionToken Current { get { lock (_gate) { return _current; } } }
        /// <summary>Clears the token and disables automatic login. In-flight authentication cannot restore it.</summary>
        public void ClearSession() { lock (_gate) { _version++; _current = null; _loggedOut = true; } }
        /// <summary>Explicit login, also usable after logout. The password is not retained.</summary>
        public PortalSessionToken Login(string email, string password)
        {
            int version;
            lock (_gate) { _version++; version = _version; _current = null; _loggedOut = false; }
            lock (_authentication)
            {
                CheckVersion(version);
                using (PortalApiClient api = NewClient())
                {
                    DateTime started = DateTime.UtcNow;
                    return Save(AuthenticationRequest(api, delegate { return api.Login(email, password); }, "LoginManager"), started, version);
                }
            }
        }
        /// <summary>Imports a trusted, unexpired persisted session without retaining credentials.</summary>
        public void Restore(string token, DateTime expiresUtc)
        {
            using (PortalApiClient api = NewClient()) { api.AccessToken = token; }
            if (String.IsNullOrEmpty(token) || expiresUtc.Kind != DateTimeKind.Utc || expiresUtc <= DateTime.UtcNow) throw new ArgumentException("An unexpired UTC session is required.");
            lock (_gate) { _version++; _loggedOut = false; _current = new PortalSessionToken(token, expiresUtc, expiresUtc.AddSeconds(-60)); }
        }
        /// <summary>Gets a valid token, renewing only when necessary. Call only for actual application/user activity.</summary>
        public PortalSessionToken GetToken() { return Authenticate(false); }
        /// <summary>Explicit activity-triggered renewal. Concurrent renewal callers share the new snapshot.</summary>
        public PortalSessionToken Renew() { return Authenticate(true); }
        /// <summary>Creates an independent client with a valid token. Caller must dispose it.</summary>
        public PortalApiClient CreateClient()
        {
            PortalSessionToken token = GetToken();
            PortalApiClient api = NewClient();
            api.AccessToken = token.AccessToken;
            api.AttachSession(this);
            return api;
        }
        /// <summary>Runs a side-effect-free callback, retrying once after 401. Never use for writes or return the client.</summary>
        public T ExecuteRead<T>(PortalRead<T> operation)
        {
            if (operation == null) throw new ArgumentNullException("operation");
            for (int attempt = 0; attempt < 2; attempt++)
            {
                PortalSessionToken token = GetToken();
                using (PortalApiClient api = NewClient())
                {
                    api.AccessToken = token.AccessToken;
                    try { return operation(api); }
                    catch (PortalApiException ex)
                    {
                        if (ex.StatusCode != 401) throw;
                        lock (_gate) { if (Object.ReferenceEquals(_current, token)) _current = null; }
                        if (attempt != 0 || _credentials == null) throw;
                    }
                }
            }
            throw new InvalidOperationException("The read could not be completed.");
        }
        private PortalSessionToken Authenticate(bool force)
        {
            PortalSessionToken observed; int version;
            lock (_gate) { if (_loggedOut) throw new InvalidOperationException("Login is required."); observed = _current; version = _version; }
            lock (_authentication)
            {
                CheckVersion(version);
                PortalSessionToken current = Current;
                DateTime started = DateTime.UtcNow;
                if (current != null && started < current.RenewAfterUtc && (!force || !Object.ReferenceEquals(current, observed))) return current;
                using (PortalApiClient api = NewClient())
                {
                    ManagerSessionResponse response = null;
                    if (current != null && started < current.ExpiresUtc)
                    {
                        api.AccessToken = current.AccessToken;
                        try { response = AuthenticationRequest(api, delegate { return api.RenewManagerSession(); }, "RenewManagerSession"); }
                        catch (PortalApiException ex)
                        {
                            if (ex.StatusCode != 401) throw;
                            lock (_gate) { if (Object.ReferenceEquals(_current, current)) _current = null; }
                            if (_credentials == null) throw;
                        }
                    }
                    if (response == null)
                    {
                        CheckVersion(version);
                        if (_credentials == null) throw new InvalidOperationException("Login is required.");
                        PortalCredentials credentials = _credentials();
                        if (credentials == null) throw new InvalidOperationException("Login credentials are unavailable.");
                        started = DateTime.UtcNow;
                        CheckVersion(version);
                        response = AuthenticationRequest(api, delegate { return api.Login(credentials.Email, credentials.Password); }, "LoginManager");
                    }
                    return Save(response, started, version);
                }
            }
        }
        private PortalSessionToken Save(ManagerSessionResponse response, DateTime started, int version)
        {
            if (response == null || !String.Equals(response.TokenType, "Bearer", StringComparison.OrdinalIgnoreCase)
                || !response.ExpiresIn.HasValue || response.ExpiresIn.Value <= 0) throw new InvalidOperationException("The API returned an incomplete session.");
            using (PortalApiClient api = NewClient()) { api.AccessToken = response.AccessToken; }
            if (String.IsNullOrEmpty(response.AccessToken)) throw new InvalidOperationException("The API returned an incomplete session.");
            DateTime expires = started.AddSeconds(response.ExpiresIn.Value);
            if (expires <= DateTime.UtcNow) throw new InvalidOperationException("The API session has already expired.");
            PortalSessionToken token = new PortalSessionToken(response.AccessToken, expires, expires.AddSeconds(-Math.Min(60.0, response.ExpiresIn.Value / 10.0)));
            lock (_gate) { CheckVersion(version); _current = token; return token; }
        }
        private void CheckVersion(int version)
        {
            lock (_gate) { if (_loggedOut || _version != version) throw new InvalidOperationException("The session changed during authentication."); }
        }
        private delegate ManagerSessionResponse AuthenticationOperation();
        private static ManagerSessionResponse AuthenticationRequest(PortalApiClient api, AuthenticationOperation operation, string stage)
        {
#if PORTAL_COMPACT20
            return operation(); // Compact Framework has no Exception.Data dictionary.
#else
            DateTime started = DateTime.UtcNow;
            try { return operation(); }
            catch (Exception ex)
            {
                ex.Data["PortalStage"] = stage;
                ex.Data["PortalApiUrl"] = api.Endpoint.AbsoluteUri;
                ex.Data["PortalClientTimeoutMs"] = api.TimeoutMilliseconds;
                ex.Data["PortalRequestElapsedMs"] = (long)(DateTime.UtcNow - started).TotalMilliseconds;
                throw;
            }
#endif
        }
        private PortalApiClient NewClient()
        {
            PortalApiClient api = _factory == null ? new PortalApiClient(_endpoint) : _factory();
            if (api == null) throw new InvalidOperationException("The client factory returned no client.");
            if (api.Endpoint != _endpoint) { api.Dispose(); throw new InvalidOperationException("The session endpoint cannot change."); }
            return api;
        }
    }
}
