using System;
using System.Collections.Generic;

namespace Kombine.Flex.Portal.Client.Net45
{
    /// <summary>An unsuccessful API response, with HTTP status, error code and response headers.</summary>
    public sealed class PortalApiException : Exception
    {
        private readonly int _statusCode;
        private readonly string _response;
        private readonly string _code;
        private readonly Dictionary<string, string> _headers;
        internal PortalApiException(int status, string response, Dictionary<string, string> headers)
            : base("Portal API request failed (HTTP " + status + ").")
        {
            _statusCode = status; _response = response; _headers = headers;
            try
            {
                IDictionary<string, object> body = PortalJson.Parse(response) as IDictionary<string, object>;
                object value;
                if (body != null && body.TryGetValue("code", out value)) _code = value as string;
            }
            catch (FormatException) { }
        }
        /// <summary>HTTP status; for example 401, 403, 409, 429 or 503.</summary>
        public int StatusCode { get { return _statusCode; } }
        /// <summary>The API error code, if supplied. Null for non-JSON errors.</summary>
        public string Code { get { return _code; } }
        /// <summary>Raw body; may contain sensitive information. Do not log indiscriminately.</summary>
        public string Response { get { return _response; } }
        /// <summary>Response headers, including Retry-After when supplied.</summary>
        public IDictionary<string, string> Headers { get { return new Dictionary<string, string>(_headers, StringComparer.OrdinalIgnoreCase); } }
        /// <summary>Safe diagnostic without the response body.</summary>
        public override string ToString() { return GetType().Name + ": " + Message; }
    }
}
