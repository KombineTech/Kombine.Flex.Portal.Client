using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;

namespace Kombine.Flex.Portal.Client.Compact20
{
    /// <summary>Tenant-bound synchronous HTTPS client for .NET Compact Framework 2.0. Contains no database or business logic.</summary>
    public sealed partial class PortalApiClient : IDisposable
    {
        private readonly Uri _endpoint;
        private readonly IPortalTransport _transport;
        private readonly object _sessionLock = new object();
        private string _accessToken;
        private int _sessionVersion;
        private bool _disposed;
        private int _timeout = 30000;
        private int _maxJsonResponseBytes = 2 * 1024 * 1024;

        /// <summary>Select the tenant API URL first. Requires HTTPS and a trailing slash; HTTP is allowed only on loopback for tests.</summary>
        public PortalApiClient(Uri apiBaseUri) : this(apiBaseUri, new WebRequestTransport()) { }
        internal PortalApiClient(Uri apiBaseUri, IPortalTransport transport)
        {
            if (apiBaseUri == null || !apiBaseUri.IsAbsoluteUri || apiBaseUri.UserInfo.Length != 0 || apiBaseUri.Query.Length != 0 || apiBaseUri.Fragment.Length != 0
                || (apiBaseUri.Scheme != "https" && !(apiBaseUri.Scheme == "http" && apiBaseUri.IsLoopback)) || !apiBaseUri.AbsolutePath.EndsWith("/", StringComparison.Ordinal))
                throw new ArgumentException("Use an absolute HTTPS API URL ending in '/'.", "apiBaseUri");
            if (transport == null) throw new ArgumentNullException("transport");
            _endpoint = apiBaseUri; _transport = transport;
        }
        /// <summary>Fixed tenant API URL. Construct a new client and log in separately when changing tenant.</summary>
        public Uri Endpoint { get { return _endpoint; } }
        /// <summary>HTTP operation deadline, including response reads, in milliseconds; default 30000. No automatic retries.</summary>
        public int TimeoutMilliseconds { get { return _timeout; } set { if (value <= 0) throw new ArgumentOutOfRangeException("value"); _timeout = value; } }
        /// <summary>Maximum buffered JSON body size, default 2 MiB. Downloads remain streamed.</summary>
        public int MaxJsonResponseBytes { get { return _maxJsonResponseBytes; } set { if (value <= 0) throw new ArgumentOutOfRangeException("value"); _maxJsonResponseBytes = value; } }
        /// <summary>Opaque bearer token for this endpoint. Never log it or send it to another tenant.</summary>
        public string AccessToken
        {
            get { lock (_sessionLock) { return _accessToken; } }
            set
            {
                if (value != null && !ValidToken(value)) throw new ArgumentException("Invalid bearer token.", "value");
                lock (_sessionLock) { CheckDisposed(); _sessionVersion++; _accessToken = value; }
            }
        }
        /// <summary>Calls LoginManager and retains the session in memory. Does not retain the password.</summary>
        public ManagerSessionResponse Login(string email, string password)
        {
            if (email == null || email.Trim().Length == 0) throw new ArgumentException("An e-mail address is required.", "email");
            if (password == null || password.Length == 0) throw new ArgumentException("A password is required.", "password");
            int version;
            lock (_sessionLock) { ClearSession(); version = _sessionVersion; }
            ManagerLoginRequest request = new ManagerLoginRequest(); request.Email = email; request.Password = password;
            ManagerSessionResponse response;
            try { response = LoginManager(request); } finally { request.Password = null; }
            if (response == null || !String.Equals(response.TokenType, "Bearer", StringComparison.OrdinalIgnoreCase)
                || !ValidToken(response.AccessToken) || !response.ExpiresIn.HasValue || response.ExpiresIn.Value <= 0)
                throw new PortalProtocolException("The API returned an incomplete session.");
            lock (_sessionLock)
            {
                if (_disposed || version != _sessionVersion) throw new InvalidOperationException("The session changed during login.");
                _accessToken = response.AccessToken;
            }
            return response;
        }
        /// <summary>Forgets this client's token. The API has no logout/revocation endpoint; other token copies retain server expiry.</summary>
        public void ClearSession() { lock (_sessionLock) { _sessionVersion++; _accessToken = null; } }
        /// <summary>Clears the token and prevents new requests. Already-started synchronous requests are not cancelled.</summary>
        public void Dispose() { lock (_sessionLock) { if (_disposed) return; ClearSession(); _disposed = true; } }

        private static bool ValidToken(string token)
        {
            if (String.IsNullOrEmpty(token)) return false;
            foreach (char c in token) if (Char.IsWhiteSpace(c) || Char.IsControl(c)) return false;
            return true;
        }
        private void CheckDisposed() { if (_disposed) throw new ObjectDisposedException("PortalApiClient"); }
        private static string PathValue(object value)
        {
            if (value == null || Convert.ToString(value, CultureInfo.InvariantCulture).Length == 0) throw new ArgumentException("A route identifier is required.", "value");
            string text = Convert.ToString(value, CultureInfo.InvariantCulture);
            if (text == "." || text == "..") throw new ArgumentException("Invalid route identifier.", "value");
            return Uri.EscapeDataString(text);
        }
        private static string AddQuery(string path, string name, object value)
        {
            if (value == null) return path;
            string text = value is bool ? ((bool)value ? "true" : "false") : Convert.ToString(value, CultureInfo.InvariantCulture);
            return path + (path.IndexOf('?') < 0 ? "?" : "&") + Uri.EscapeDataString(name) + "=" + Uri.EscapeDataString(text);
        }
        private PortalResponse Send(string method, string path, object body, Dictionary<string, string> headers)
        {
            PortalRequest request = new PortalRequest();
            request.Uri = new Uri(_endpoint, path);
            if (request.Uri.GetLeftPart(UriPartial.Authority) != _endpoint.GetLeftPart(UriPartial.Authority)) throw new InvalidOperationException("The API endpoint cannot change.");
            request.Method = method; request.Headers = headers; request.Timeout = _timeout;
            lock (_sessionLock)
            {
                CheckDisposed();
                if (_accessToken != null) request.Headers.Add("Authorization", "Bearer " + _accessToken);
            }
            if (body != null)
            {
                request.Body = new UTF8Encoding(false, true).GetBytes(PortalJson.Serialize(body));
                if (request.Body.Length > _maxJsonResponseBytes) throw new PortalProtocolException("JSON request exceeds the configured limit.");
            }
            return _transport.Send(request);
        }
        private object SendJson(string method, string path, object body, Dictionary<string, string> headers, int expectedStatus, Type type)
        {
            using (PortalResponse response = Send(method, path, body, headers))
            {
                string json = ReadJson(response);
                if (response.Status != expectedStatus) throw new PortalApiException(response.Status, json, response.Headers);
                try
                {
                    object result = PortalJson.Deserialize(json, type);
                    if (result == null) throw new FormatException();
                    return result;
                }
                catch (FormatException) { throw new PortalProtocolException("The API returned invalid JSON or an unexpected response shape."); }
            }
        }
        private PortalDownload SendDownload(string method, string path, object body, Dictionary<string, string> headers, int expectedStatus)
        {
            PortalResponse response = Send(method, path, body, headers);
            if (response.Status == expectedStatus) return new PortalDownload(response);
            using (response) { throw new PortalApiException(response.Status, ReadJson(response), response.Headers); }
        }
        private string ReadJson(PortalResponse response)
        {
            using (MemoryStream output = new MemoryStream())
            {
                byte[] buffer = new byte[8192]; int count;
                while ((count = response.Stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (output.Length + count > _maxJsonResponseBytes) throw new PortalProtocolException("JSON response exceeds the configured limit.");
                    output.Write(buffer, 0, count);
                }
                byte[] bytes = output.ToArray();
                return new UTF8Encoding(false, true).GetString(bytes, 0, bytes.Length);
            }
        }
    }
}
