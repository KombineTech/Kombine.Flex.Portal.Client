using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using Kombine.Flex.Portal.Client.Compact20;

internal static class Program
{
    private static int _assertions;
    private const string LoginJson = "{\"accessToken\":\"fixture-token\",\"tokenType\":\"Bearer\",\"expiresIn\":3600}";
    internal static string Run(string directory)
    {
        _assertions = 0; _directory = directory;
        RuntimeAndDependencies();
        Contracts(); JsonRoundTripAndTyping(); ReceiptPaging(); MalformedJson(); LoginAndSessionIsolation();
        LogoutDuringLogin(); InvalidSessions(); ErrorsAndBoundedResponses(); QueryAndHeaderEncoding();
        DownloadOwnership(); EndpointValidation();
#if DESKTOP_TEST_HOST
        LoopbackTransport(); LoopbackPost(false); LoopbackPost(true); StalledTransport(false); StalledTransport(true);
#endif
        return "PASS: " + _assertions + " checks, 110 API operations; runtime " + Environment.Version + ".";
    }
    private static string _directory;
    private static void Check(bool ok, string label) { _assertions++; if (!ok) throw new Exception(label); }
    private static void Equal(object expected, object actual, string label) { Check(Object.Equals(expected, actual), label + ": unexpected value"); }
    private delegate void TestAction();
    private static void Throws<T>(TestAction action, string label) where T : Exception
    {
        try { action(); } catch (T) { _assertions++; return; }
        throw new Exception(label + ": expected " + typeof(T).Name);
    }
    private static PortalApiClient Client(Fake transport) { return new PortalApiClient(new Uri("https://tenant.example/"), transport); }
    private static void RuntimeAndDependencies()
    {
#if DESKTOP_TEST_HOST
        Equal(2, Environment.Version.Major, "Desktop fixture host must use CLR 2");
        Assembly assembly = typeof(PortalApiClient).Assembly;
        foreach (AssemblyName dependency in assembly.GetReferencedAssemblies())
        {
            Check(dependency.Name == "mscorlib" || dependency.Name == "System", "Only CF runtime dependencies");
            Equal(2, dependency.Version.Major, "CF dependency version");
            Equal("969db8053d3322ac", BitConverter.ToString(dependency.GetPublicKeyToken()).Replace("-", "").ToLowerInvariant(), "Compact Framework identity, not desktop BCL");
        }
#else
        Equal(PlatformID.WinCE, Environment.OSVersion.Platform, "Device checks require Windows CE/Mobile");
#endif
    }
    private static string[] ReadRows(string path)
    {
        List<string> rows = new List<string>();
        using (StreamReader reader = new StreamReader(path))
        { string line; while ((line = reader.ReadLine()) != null) if (line.Length > 0) rows.Add(line); }
        return rows.ToArray();
    }
    private static void Contracts()
    {
        string[] rows = ReadRows(Path.Combine(_directory, "ContractCases.tsv"));
        Equal(110, rows.Length, "Published operation count");
        foreach (string row in rows)
        {
            string[] fields = row.Split(new char[] { '\t' });
            MethodInfo chosen = null;
            foreach (MethodInfo method in typeof(PortalApiClient).GetMethods())
                if (method.Name == fields[0] && (chosen == null || method.GetParameters().Length > chosen.GetParameters().Length)) chosen = method;
            Check(chosen != null, "Typed method exists: " + fields[0]);
            ParameterInfo[] parameters = chosen.GetParameters();
            object[] arguments = new object[parameters.Length];
            string expected = fields[2];
            for (int i = 0; i < parameters.Length; i++)
            {
                Type type = parameters[i].ParameterType;
                arguments[i] = type == typeof(string) ? (object)"opaque-KID" : type == typeof(int) ? (object)7 : Activator.CreateInstance(type);
                expected = expected.Replace("{" + parameters[i].Name + "}", Convert.ToString(arguments[i], CultureInfo.InvariantCulture));
            }
            Fake fake = new Fake(Int32.Parse(fields[3], CultureInfo.InvariantCulture), fields[4]);
            using (PortalApiClient client = Client(fake))
            {
                object result = chosen.Invoke(client, arguments);
                Equal(fields[1], fake.Last.Method, fields[0] + " HTTP method");
                Equal(expected, Uri.UnescapeDataString(fake.Last.Uri.AbsolutePath), fields[0] + " route");
                Equal("tenant.example", fake.Last.Uri.Host, fields[0] + " tenant");
                Equal(1, fake.Calls, fields[0] + " no retry");
                Check(result != null, fields[0] + " typed response");
                IDisposable disposable = result as IDisposable;
                if (disposable != null) disposable.Dispose();
                Check(!fake.LastStream.CanRead, fields[0] + " response disposed");
            }
        }
    }
    private static void JsonRoundTripAndTyping()
    {
        string text = "Jens æøå Ä漢字 \ud83c\udf0d \"\\\r\n\t";
        Equal(text, PortalJson.Parse(PortalJson.Serialize(text)), "Unicode and escaping round trip");
#if DESKTOP_TEST_HOST
        CultureInfo before = Thread.CurrentThread.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = new CultureInfo("da-DK");
        try { Equal("1.25", PortalJson.Serialize(1.25), "Invariant number serialization"); }
        finally { Thread.CurrentThread.CurrentCulture = before; }
#endif
        Fake fake = new Fake(200, "{\"items\":[{\"kid\":\"CaseSensitive-KID\",\"status\":\"ok\",\"balances\":[{\"currency\":\"DKK\",\"currentBalanceMinor\":-9007199254740993,\"previousBalanceMinor\":null},{\"currency\":\"EUR\",\"currentBalanceMinor\":-1000,\"previousBalanceMinor\":0}]}]}");
        using (PortalApiClient client = Client(fake))
        {
            UserBalancesRequest request = new UserBalancesRequest(); request.UserKids = new string[] { "CaseSensitive-KID" };
            UserBalanceItem resident = client.GetBankUserBalances("bank-KID", request).Items[0];
            Equal("CaseSensitive-KID", resident.Kid, "Opaque KID");
            Equal(-9007199254740993L, resident.Balances[0].CurrentBalanceMinor.Value, "Exact Int64 balance beyond double precision");
            Equal(null, resident.Balances[0].PreviousBalanceMinor, "Null is not zero");
            Equal("EUR", resident.Balances[1].Currency, "Currency separated");
            Equal(0L, resident.Balances[1].PreviousBalanceMinor.Value, "Real zero preserved");
            Check(Encoding.UTF8.GetString(fake.Last.Body, 0, fake.Last.Body.Length).IndexOf("CaseSensitive-KID", StringComparison.Ordinal) >= 0, "Typed request serialization");
        }
        BankUserResponse user = (BankUserResponse)PortalJson.Deserialize("{\"deletedAt\":\"2026-09-26T15:23:40.1234567+02:00\",\"futureField\":true}", typeof(BankUserResponse));
        Equal("2026-09-26T15:23:40.1234567+02:00", user.DeletedAt, "Timestamp text and offset preserved");
        ManagerThemeResponse theme = (ManagerThemeResponse)PortalJson.Deserialize("{\"themeMode\":2}", typeof(ManagerThemeResponse));
        Equal(2, theme.ThemeMode.Value, "Enum numeric identity preserved without enum package");
        ValidationProblemDetails errors = (ValidationProblemDetails)PortalJson.Deserialize("{\"errors\":{\"email\":[\"invalid\"]}}", typeof(ValidationProblemDetails));
        Equal("invalid", errors.Errors["email"][0], "Dictionary and array contract");
    }
    private static void ReceiptPaging()
    {
        Fake fake = new Fake(200, "{\"userKid\":\"CaseSensitive-KID\",\"revision\":\"opaque+revision\",\"nextOffset\":40,\"periodCount\":2,\"items\":[{\"key\":\"r1\",\"date\":\"2026-10-01\",\"currency\":\"DKK\",\"totalMinor\":-9007199254740993,\"vatMinor\":null,\"balanceAfterMinor\":0,\"lines\":[{\"kid\":null,\"occurredAt\":\"2026-10-01T12:30:00+02:00\",\"texts\":[\"Vask\"],\"amountMinor\":-9007199254740993,\"calculated\":true}]}]}");
        using (PortalApiClient client = Client(fake))
        {
            GetUserReceiptsOptions options = new GetUserReceiptsOptions();
            options.Offset = 20; options.Revision = "opaque+revision";
            UserReceiptsResponse page = client.GetUserReceipts("CaseSensitive-KID", options);
            Equal("?offset=20&revision=opaque%2Brevision", fake.Last.Uri.Query, "Receipt page parameters");
            Equal("opaque+revision", page.Revision, "Receipt revision preserved");
            Equal(40, page.NextOffset.Value, "Next offset preserved");
            Equal("2026-10-01", page.Items[0].Date, "Receipt calendar date preserved");
            Equal(-9007199254740993L, page.Items[0].TotalMinor.Value, "Exact Int64 receipt total");
            Equal(null, page.Items[0].VatMinor, "Unknown VAT stays null");
            Equal(null, page.Items[0].Lines[0].Kid, "Calculated line has no KID");
            Equal("2026-10-01T12:30:00+02:00", page.Items[0].Lines[0].OccurredAt, "Receipt time offset preserved");
            Equal(1, fake.Calls, "No automatic receipt paging");
        }
        Fake changed = new Fake(409, "{\"code\":\"receipts-changed\"}");
        using (PortalApiClient client = Client(changed))
        {
            Throws<PortalApiException>(delegate() { client.GetUserReceipts("CaseSensitive-KID"); }, "Receipt conflict is returned");
            Equal(1, changed.Calls, "No automatic receipt retry");
        }
    }
    private static void MalformedJson()
    {
        string[] invalid = new string[] { "", "{", "[] trailing", "{\"a\":1,}", "[1,]", "01", "1.", "1e", "1e9999", "NaN", "true false", "{\"a\":1,\"a\":2}", "\"\\q\"", "\"\\uD800\"", "\"\n\"" };
        foreach (string value in invalid)
        { string captured = value; Throws<FormatException>(delegate() { PortalJson.Parse(captured); }, "Malformed JSON"); }
        string nesting = new string('[', 70) + "0" + new string(']', 70);
        Throws<FormatException>(delegate() { PortalJson.Parse(nesting); }, "Nesting limit");
        Throws<FormatException>(delegate() { PortalJson.Deserialize("{\"expiresIn\":1.5}", typeof(ManagerSessionResponse)); }, "Do not round integer fields");
        Throws<FormatException>(delegate() { PortalJson.Deserialize("{\"expiresIn\":9223372036854775807.00000000000001}", typeof(ManagerSessionResponse)); }, "Do not round tiny fractions of large integers");
        Throws<FormatException>(delegate() { PortalJson.Deserialize("{\"expiresIn\":1e0}", typeof(ManagerSessionResponse)); }, "Integer wire token required");
        Throws<FormatException>(delegate() { PortalJson.Deserialize("{\"expiresIn\":9223372036854775808}", typeof(ManagerSessionResponse)); }, "Do not overflow integer fields");
        Throws<FormatException>(delegate() { PortalJson.Deserialize("{\"expiresIn\":\"3600\"}", typeof(ManagerSessionResponse)); }, "Wrong primitive type");
        Throws<FormatException>(delegate() { PortalJson.Serialize(Double.NaN); }, "Reject non-finite request values");
    }
    private static void LoginAndSessionIsolation()
    {
        Fake fake = new Fake(200, LoginJson);
        using (PortalApiClient first = Client(fake))
        using (PortalApiClient second = Client(fake))
        {
            first.Login("test@example.invalid", "fixture-password");
            Equal("fixture-token", first.AccessToken, "Login session retained");
            Check(!fake.Last.Headers.ContainsKey("Authorization"), "Login starts without old bearer");
            Check(fake.Last.Uri.ToString().IndexOf("fixture-password", StringComparison.Ordinal) < 0, "No credentials in URL");
            IDictionary<string, object> body = (IDictionary<string, object>)PortalJson.Parse(Encoding.UTF8.GetString(fake.Last.Body, 0, fake.Last.Body.Length));
            Equal("fixture-password", body["password"], "Password only in JSON body");
            fake.Json = "{\"name\":\"Fixture\"}";
            first.GetCurrentManager(); Equal("Bearer fixture-token", fake.Last.Headers["Authorization"], "Authorized request");
            second.GetCurrentManager(); Check(!fake.Last.Headers.ContainsKey("Authorization"), "Separate client isolation");
            first.ClearSession(); first.GetCurrentManager(); Check(!fake.Last.Headers.ContainsKey("Authorization"), "Logout clears bearer");
            first.Dispose(); first.Dispose();
            Throws<ObjectDisposedException>(delegate() { first.GetCurrentManager(); }, "Disposed client cannot make calls");
        }
    }
    private static void LogoutDuringLogin()
    {
        Fake fake = new Fake(200, LoginJson);
        using (ManualResetEvent entered = new ManualResetEvent(false))
        using (ManualResetEvent release = new ManualResetEvent(false))
        using (PortalApiClient client = Client(fake))
        {
            fake.BeforeSend = delegate() { entered.Set(); if (!release.WaitOne(5000, false)) throw new Exception("Test release timeout"); };
            Exception failure = null;
            Thread worker = new Thread(delegate() { try { client.Login("test@example.invalid", "fixture"); } catch (Exception error) { failure = error; } });
            worker.IsBackground = true; worker.Start();
            Check(entered.WaitOne(5000, false), "Login request started");
            client.ClearSession(); release.Set(); Check(worker.Join(5000), "Login returned");
            Check(failure is InvalidOperationException, "Late login rejected after logout");
            Equal(null, client.AccessToken, "Late login does not restore token");
        }
    }
    private static void InvalidSessions()
    {
        string[] invalid = new string[] { "{}", "{\"accessToken\":\"token\",\"tokenType\":\"Basic\",\"expiresIn\":3600}", "{\"accessToken\":\"bad token\",\"tokenType\":\"Bearer\",\"expiresIn\":3600}", "{\"accessToken\":\"token\",\"tokenType\":\"Bearer\",\"expiresIn\":0}" };
        foreach (string json in invalid)
        {
            using (PortalApiClient client = Client(new Fake(200, json)))
            {
                client.AccessToken = "old-token";
                Throws<PortalProtocolException>(delegate() { client.Login("email", "password"); }, "Incomplete session rejected");
                Equal(null, client.AccessToken, "Previous token not reused");
            }
        }
    }
    private static void ErrorsAndBoundedResponses()
    {
        foreach (int status in new int[] { 400, 401, 403, 404, 409, 429, 503 })
        {
            Fake fake = new Fake(status, "{\"code\":\"fixture-error\",\"private\":\"secret-body\"}");
            using (PortalApiClient client = Client(fake))
            {
                try { client.GetCurrentManager(); throw new Exception("Expected API error"); }
                catch (PortalApiException error)
                {
                    Equal(status, error.StatusCode, "HTTP error status"); Equal("fixture-error", error.Code, "API error code");
                    Equal("12", error.Headers["Retry-After"], "Retry-After available");
                    Check(error.ToString().IndexOf("secret-body", StringComparison.Ordinal) < 0, "Error safe to display");
                }
                Equal(1, fake.Calls, "No automatic retry"); Check(!fake.LastStream.CanRead, "Error response disposed");
            }
        }
        using (PortalApiClient client = Client(new Fake(200, new string(' ', 100))))
        { client.MaxJsonResponseBytes = 32; Throws<PortalProtocolException>(delegate() { client.GetCurrentManager(); }, "Bounded response"); }
        using (PortalApiClient client = Client(new Fake(200, "null")))
        { Throws<PortalProtocolException>(delegate() { client.GetCurrentManager(); }, "Null response is not successful data"); }
        using (PortalApiClient client = Client(new Fake(503, "<html>unavailable</html>")))
        {
            try { client.GetCurrentManager(); throw new Exception("Expected error"); }
            catch (PortalApiException error) { Equal(503, error.StatusCode, "HTML error status retained"); Equal(null, error.Code, "HTML is not a code"); }
        }
    }
    private static void QueryAndHeaderEncoding()
    {
        Fake fake = new Fake(200, "{}");
        using (PortalApiClient client = Client(fake))
        {
            GetBankAccountOptions options = new GetBankAccountOptions(); options.From = "2026-09-01"; options.Through = "2026-09-26"; options.IncludeZero = false;
            client.TimeoutMilliseconds = 1234; client.GetBankAccount("bank-KID", options);
            Check(fake.Last.Uri.Query.IndexOf("From=2026-09-01", StringComparison.Ordinal) >= 0, "Date only query");
            Check(fake.Last.Uri.Query.IndexOf("IncludeZero=false", StringComparison.Ordinal) >= 0, "Lowercase boolean query");
            Equal(1234, fake.Last.Timeout, "Explicit timeout propagated");
            SearchBanksOptions search = new SearchBanksOptions(); search.Q = "æ&plus+ #?="; client.SearchBanks(search);
            Equal("?q=%C3%A6%26plus%2B%20%23%3F%3D", fake.Last.Uri.Query, "Encoded search query");
            Throws<ArgumentException>(delegate() { client.AccessToken = "header\r\ninjection"; }, "Token rejects control characters");
        }
    }
    private static void DownloadOwnership()
    {
        Fake fake = new Fake(200, "binary-fixture");
        using (PortalApiClient client = Client(fake))
        {
            PortalDownload download = client.DownloadBankSettlement("bank-KID", 7);
            Check(fake.LastStream.CanRead, "Download remains streaming");
            Equal((int)'b', download.Stream.ReadByte(), "Stream readable");
            download.Dispose(); Check(!fake.LastStream.CanRead, "Download dispose closes stream");
        }
    }
    private static void EndpointValidation()
    {
        string[] invalid = new string[] { "http://tenant.example/", "https://user:pass@tenant.example/", "https://tenant.example/?tenant=999", "https://tenant.example/#token", "https://tenant.example/api" };
        foreach (string uri in invalid)
        { string captured = uri; Throws<ArgumentException>(delegate() { new PortalApiClient(new Uri(captured)); }, "Unsafe endpoint rejected"); }
        using (PortalApiClient client = new PortalApiClient(new Uri("http://127.0.0.1:12345/"))) { Check(client.Endpoint.IsLoopback, "HTTP loopback test endpoint allowed"); }
    }
#if DESKTOP_TEST_HOST
    private static void StalledTransport(bool sendHeaders)
    {
        TcpListener listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        ManualResetEvent release = new ManualResetEvent(false);
        Thread server = new Thread(delegate()
        {
            try
            {
                using (TcpClient socket = listener.AcceptTcpClient())
                using (NetworkStream stream = socket.GetStream())
                {
                    socket.ReceiveTimeout = 3000;
                    StreamReader reader = new StreamReader(stream); string line;
                    while ((line = reader.ReadLine()) != null && line.Length > 0) { }
                    if (sendHeaders)
                    {
                        byte[] headers = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Length: 1000\r\nContent-Type: application/json\r\n\r\n{");
                        stream.Write(headers, 0, headers.Length);
                    }
                    release.WaitOne(4000, false);
                }
            }
            catch (SocketException) { }
            catch (IOException) { }
        });
        server.IsBackground = true; server.Start();
        DateTime started = DateTime.UtcNow;
        try
        {
            using (PortalApiClient client = new PortalApiClient(new Uri("http://127.0.0.1:" + port + "/")))
            {
                client.TimeoutMilliseconds = 300;
                bool rejected = false;
                try { client.GetPortalStatus(); }
                catch (WebException) { rejected = true; }
                catch (IOException) { rejected = true; }
                Check(rejected, "Stalled response rejected");
                Check((DateTime.UtcNow - started).TotalMilliseconds < 2500, "Deadline covers " + (sendHeaders ? "response body" : "headers"));
            }
        }
        finally { release.Set(); listener.Stop(); server.Join(5000); release.Close(); }
    }
    private static void LoopbackTransport()
    {
        TcpListener listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        string requestText = null; Exception failure = null;
        Thread worker = new Thread(delegate()
        {
            try
            {
                using (TcpClient socket = listener.AcceptTcpClient())
                using (NetworkStream stream = socket.GetStream())
                {
                    socket.ReceiveTimeout = 5000;
                    StreamReader reader = new StreamReader(stream, Encoding.ASCII);
                    StringBuilder request = new StringBuilder(); string line;
                    while ((line = reader.ReadLine()) != null && line.Length > 0) request.AppendLine(line);
                    requestText = request.ToString();
                    string body = "{\"code\":\"redirect-fixture\"}";
                    byte[] response = Encoding.ASCII.GetBytes("HTTP/1.1 302 Found\r\nLocation: http://127.0.0.1:1/must-not-follow\r\nContent-Type: application/json\r\nContent-Length: " + body.Length + "\r\nConnection: close\r\n\r\n" + body);
                    stream.Write(response, 0, response.Length);
                }
            }
            catch (Exception error) { failure = error; }
        });
        worker.IsBackground = true; worker.Start();
        try
        {
            using (PortalApiClient api = new PortalApiClient(new Uri("http://127.0.0.1:" + port + "/")))
            {
                api.AccessToken = "fixture-only-token";
                try { api.GetPortalStatus(); throw new Exception("Expected redirect rejection"); }
                catch (PortalApiException error) { Equal(302, error.StatusCode, "Real transport does not follow redirect"); }
            }
            Check(worker.Join(5000), "Loopback fixture finished");
            if (failure != null) throw failure;
            Check(requestText.IndexOf("GET /api/v1/status HTTP/1.1", StringComparison.Ordinal) >= 0, "Real wire route");
            Check(requestText.IndexOf("Authorization: Bearer fixture-only-token", StringComparison.Ordinal) >= 0, "Real wire authorization");
        }
        finally { listener.Stop(); }
    }
    private static void LoopbackPost(bool rejectBeforeBody)
    {
        TcpListener listener = new TcpListener(IPAddress.Loopback, 0); listener.Start();
        int port = ((IPEndPoint)listener.LocalEndpoint).Port;
        string requestBody = null; Exception failure = null;
        Thread worker = new Thread(delegate()
        {
            try
            {
                using (TcpClient socket = listener.AcceptTcpClient())
                using (NetworkStream stream = socket.GetStream())
                {
                    socket.ReceiveTimeout = 5000;
                    StringBuilder header = new StringBuilder();
                    while (!header.ToString().EndsWith("\r\n\r\n", StringComparison.Ordinal))
                    { int next = stream.ReadByte(); if (next < 0 || header.Length > 8192) throw new Exception("Invalid fixture request"); header.Append((char)next); }
                    if (!rejectBeforeBody)
                    {
                        if (header.ToString().ToLowerInvariant().IndexOf("expect: 100-continue", StringComparison.Ordinal) >= 0)
                        { byte[] interim = Encoding.ASCII.GetBytes("HTTP/1.1 100 Continue\r\n\r\n"); stream.Write(interim, 0, interim.Length); }
                        int length = 0;
                        foreach (string line in header.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None))
                            if (line.StartsWith("Content-Length:", StringComparison.OrdinalIgnoreCase)) length = Int32.Parse(line.Substring(15).Trim(), CultureInfo.InvariantCulture);
                        byte[] body = new byte[length]; int total = 0;
                        while (total < length) { int count = stream.Read(body, total, length - total); if (count == 0) throw new Exception("Truncated request"); total += count; }
                        requestBody = new UTF8Encoding(false, true).GetString(body);
                    }
                    string json = rejectBeforeBody ? "{\"code\":\"early-denial\"}" : LoginJson;
                    string status = rejectBeforeBody ? "401 Unauthorized" : "200 OK";
                    byte[] response = Encoding.ASCII.GetBytes("HTTP/1.1 " + status + "\r\nContent-Type: application/json\r\nContent-Length: " + json.Length + "\r\nConnection: close\r\n\r\n" + json);
                    stream.Write(response, 0, response.Length);
                }
            }
            catch (Exception error) { failure = error; }
        });
        worker.IsBackground = true; worker.Start();
        try
        {
            using (PortalApiClient client = new PortalApiClient(new Uri("http://127.0.0.1:" + port + "/")))
            {
                client.TimeoutMilliseconds = 3000;
                if (rejectBeforeBody)
                {
                    try { client.Login("test@example.invalid", "fixture-only"); throw new Exception("Expected early denial"); }
                    catch (PortalApiException error) { Equal(401, error.StatusCode, "Early HTTP POST rejection"); Equal("early-denial", error.Code, "Early rejection code"); }
                    Equal(null, client.AccessToken, "Failed wire login has no session");
                }
                else
                {
                    client.Login("test@example.invalid", "æøå\"\\fixture-only");
                    Equal("fixture-token", client.AccessToken, "Real HTTP POST login");
                }
            }
            Check(worker.Join(5000), "POST fixture finished");
            if (failure != null) throw failure;
            if (!rejectBeforeBody)
            {
                IDictionary<string, object> data = (IDictionary<string, object>)PortalJson.Parse(requestBody);
                Equal("æøå\"\\fixture-only", data["password"], "Actual UTF-8 body and byte Content-Length");
            }
        }
        finally { listener.Stop(); }
    }
#endif
    private sealed class Fake : IPortalTransport
    {
        internal int Status;
        internal string Json;
        internal int Calls;
        internal PortalRequest Last;
        internal MemoryStream LastStream;
        internal TestAction BeforeSend;
        internal Fake(int status, string json) { Status = status; Json = json; }
        public PortalResponse Send(PortalRequest request)
        {
            Calls++; Last = request;
            if (BeforeSend != null) BeforeSend();
            PortalResponse response = new PortalResponse(); response.Status = Status;
            response.Headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase); response.Headers.Add("Retry-After", "12");
            LastStream = new MemoryStream(Encoding.UTF8.GetBytes(Json)); response.Stream = LastStream;
            return response;
        }
    }
}
