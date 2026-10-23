using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Cache;

namespace Kombine.Flex.Portal.Client.Net45
{
    internal sealed class PortalRequest
    {
        internal Uri Uri;
        internal string Method;
        internal byte[] Body;
        internal PortalMultipart Multipart;
        internal Dictionary<string, string> Headers;
        internal int Timeout;
    }
    internal interface IPortalTransport { PortalResponse Send(PortalRequest request); }
    internal sealed class PortalResponse : IDisposable
    {
        internal int Status;
        internal Dictionary<string, string> Headers;
        internal Stream Stream;
        internal WebResponse Owner;
        public void Dispose() { try { if (Stream != null) Stream.Close(); } finally { if (Owner != null) Owner.Close(); } }
    }
    internal sealed class WebRequestTransport : IPortalTransport
    {
        private static void AddRange(HttpWebRequest request, string value)
        {
            if (value == null || !value.StartsWith("bytes=", StringComparison.Ordinal) || value.Length > 128) throw new ArgumentException("Use a single byte range.");
            string[] parts = value.Substring(6).Split(new char[] { '-' });
            if (parts.Length != 2 || parts[0].Length == 0 && parts[1].Length == 0) throw new ArgumentException("Use a single byte range.");
            int first = parts[0].Length == 0 ? 0 : Int32.Parse(parts[0], System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture);
            int last = parts[1].Length == 0 ? 0 : Int32.Parse(parts[1], System.Globalization.NumberStyles.None, System.Globalization.CultureInfo.InvariantCulture);
            if (parts[0].Length == 0) { if (last == 0) throw new ArgumentException("Invalid suffix range."); request.AddRange(-last); }
            else if (parts[1].Length == 0) request.AddRange(first);
            else { if (last < first) throw new ArgumentException("Invalid byte range."); request.AddRange(first, last); }
        }
        public PortalResponse Send(PortalRequest input)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(input.Uri);
            request.Method = input.Method;
            request.AllowAutoRedirect = false;
            request.AllowWriteStreamBuffering = false;
            request.Credentials = null;
            request.UseDefaultCredentials = false;
            request.PreAuthenticate = false;
            request.CookieContainer = null;
            request.Timeout = input.Timeout;
            request.ReadWriteTimeout = input.Timeout;
            request.CachePolicy = new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore);
            request.Accept = "application/json, application/zip, text/csv";
            foreach (KeyValuePair<string, string> pair in input.Headers)
            {
                if (String.Equals(pair.Key, "Range", StringComparison.OrdinalIgnoreCase)) AddRange(request, pair.Value);
                else request.Headers.Add(pair.Key, pair.Value);
            }
            HttpWebResponse response;
            try
            {
                if (input.Multipart != null)
                {
                    request.ContentType = input.Multipart.ContentType;
                    request.ContentLength = input.Multipart.Length;
                    using (Stream stream = request.GetRequestStream()) input.Multipart.WriteTo(stream);
                }
                else if (input.Body != null)
                {
                    request.ContentType = "application/json; charset=utf-8";
                    request.ContentLength = input.Body.Length;
                    using (Stream stream = request.GetRequestStream()) stream.Write(input.Body, 0, input.Body.Length);
                }
                else if (input.Method == "POST") request.ContentLength = 0;
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException error)
            {
                response = error.Response as HttpWebResponse;
                if (response == null) { request.Abort(); throw; }
            }
            catch { request.Abort(); throw; }
            PortalResponse result = new PortalResponse();
            result.Owner = response;
            result.Status = (int)response.StatusCode;
            result.Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            foreach (string key in response.Headers.AllKeys) result.Headers[key] = response.Headers[key];
            result.Stream = response.GetResponseStream();
            return result;
        }
    }

    /// <summary>Streaming export response. Dispose after copying Stream; this closes the underlying HTTP response.</summary>
    public sealed class PortalDownload : IDisposable
    {
        private readonly PortalResponse _response;
        internal PortalDownload(PortalResponse response) { _response = response; }
        /// <summary>The download stream; copy it in chunks instead of loading large files into memory.</summary>
        public Stream Stream { get { return _response.Stream; } }
        /// <summary>HTTP status of the successful download.</summary>
        public int StatusCode { get { return _response.Status; } }
        /// <summary>Response headers, including content type/disposition if supplied.</summary>
        public IDictionary<string, string> Headers { get { return new Dictionary<string, string>(_response.Headers, StringComparer.OrdinalIgnoreCase); } }
        /// <summary>Closes the stream and HTTP response.</summary>
        public void Dispose() { _response.Dispose(); }
    }
}
