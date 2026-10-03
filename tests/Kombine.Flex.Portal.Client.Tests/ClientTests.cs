using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Kombine.Flex.Portal.Client;

namespace Kombine.Flex.Portal.Client.Tests;

public sealed class ClientTests
{
    private const string Session = "{\"accessToken\":\"fixture-token\",\"tokenType\":\"Bearer\",\"expiresIn\":3600}";
    private static HttpResponseMessage Json(string json, HttpStatusCode code = HttpStatusCode.OK) => new(code) { Content = new StringContent(json, Encoding.UTF8, "application/json") };
    private static HttpClient Transport(HttpMessageHandler handler) => new(handler) { BaseAddress = new Uri("https://tenant.example/") };

    [Theory]
    [InlineData("", null, null)]
    [InlineData(",\"latestPostingMs2000\":null,\"hasActiveSubscription\":null", null, null)]
    [InlineData(",\"latestPostingMs2000\":0,\"hasActiveSubscription\":false", 0L, false)]
    [InlineData(",\"latestPostingMs2000\":844123456789,\"hasActiveSubscription\":true", 844123456789L, true)]
    public async Task BalanceMetadataPreservesUnknownAndExactPostingTime(string fields, long? posting, bool? active)
    {
        using var http = Transport(new Handler((_, _) => Task.FromResult(Json(
            "{\"items\":[{\"kid\":\"resident\",\"status\":\"ok\",\"currentBalanceMinor\":0" + fields + "}]}"))));
        using var client = new PortalApiClient(http);
        var page = await client.GetBankUserBalancesAsync("bank", new UserBalancesRequest { UserKids = new[] { "resident" } });
        var resident = Assert.Single(page.Items!);
        Assert.Equal(posting, resident.LatestPostingMs2000);
        Assert.Equal(active, resident.HasActiveSubscription);
    }

    [Fact]
    public async Task BookingRulesPreservePlainTextAndValueParts()
    {
        using var http = Transport(new Handler((request, _) =>
        {
            Assert.Equal("/api/v1/locations/CaseSensitive-KID/booking-rules", request.RequestUri!.AbsolutePath);
            Assert.Contains("da", request.Headers.GetValues("Accept-Language"));
            return Task.FromResult(Json("{\"locationKid\":\"CaseSensitive-KID\",\"calculatedAt\":\"2026-10-01T12:00:00Z\",\"groups\":[{\"name\":null,\"units\":[],\"rules\":[{\"code\":\"maximum\",\"text\":\"Højst 2 reservationer.\",\"warning\":false,\"parts\":[{\"text\":\"Højst \",\"isValue\":false},{\"text\":\"2\",\"isValue\":true},{\"text\":\" reservationer.\",\"isValue\":false}]}]}]}"));
        }));
        using var client = new PortalApiClient(http);
        var result = await client.GetLocationBookingRulesAsync("CaseSensitive-KID", "da");
        var rule = Assert.Single(Assert.Single(result.Groups!).Rules!);
        Assert.NotNull(rule.Parts);
        Assert.Equal(rule.Text, string.Concat(rule.Parts.Select(part => part.Text)));
        Assert.Equal("2", Assert.Single(rule.Parts, part => part.IsValue == true).Text);
    }

    [Theory]
    [InlineData("http://tenant.example/")]
    [InlineData("https://name:password@tenant.example/")]
    [InlineData("https://tenant.example/?tenant=999")]
    [InlineData("https://tenant.example/#token")]
    [InlineData("https://tenant.example/api")]
    public void RejectsUnsafeBaseUris(string uri) => Assert.Throws<ArgumentException>(() => new PortalApiClient(new Uri(uri)));

    [Fact]
    public async Task LoginUsesJsonAndSessionIsPerClientAndCleared()
    {
        var requests = new List<(string Uri, string? Token, string Body)>();
        using var handler = new Handler(async (request, _) =>
        {
            var body = request.Content is null ? "" : await request.Content.ReadAsStringAsync();
            requests.Add((request.RequestUri!.ToString(), request.Headers.Authorization?.Parameter, body));
            return Json(request.RequestUri.AbsolutePath.EndsWith("/login") ? Session : "{\"name\":\"Test manager\"}");
        });
        using var http = Transport(handler);
        using var first = new PortalApiClient(http);
        using var second = new PortalApiClient(http);
        await first.LoginAsync("test@example.invalid", "secret&+\"");
        Assert.Equal("fixture-token", first.AccessToken);
        await first.GetCurrentManagerAsync();
        await second.GetCurrentManagerAsync();
        first.ClearSession();
        await first.GetCurrentManagerAsync();
        Assert.Null(requests[0].Token);
        Assert.Equal("secret&+\"", JsonDocument.Parse(requests[0].Body).RootElement.GetProperty("password").GetString());
        Assert.DoesNotContain("secret", requests[0].Uri);
        Assert.Equal("fixture-token", requests[1].Token);
        Assert.Null(requests[2].Token);
        Assert.Null(requests[3].Token);
        Assert.Null(http.DefaultRequestHeaders.Authorization);
        first.Dispose();
        await second.GetCurrentManagerAsync(); // An injected transport remains caller-owned.
    }

    [Fact]
    public async Task LogoutDuringLoginDoesNotRestoreSession()
    {
        var response = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var http = Transport(new Handler((_, _) => response.Task));
        using var client = new PortalApiClient(http);
        var login = client.LoginAsync("test@example.invalid", "test");
        client.ClearSession();
        response.SetResult(Json(Session));
        await Assert.ThrowsAsync<OperationCanceledException>(() => login);
        Assert.Null(client.AccessToken);
    }

    [Theory]
    [InlineData(401)] [InlineData(403)] [InlineData(409)] [InlineData(429)] [InlineData(503)]
    public async Task ErrorsKeepStatusCodeAndRetryAfterWithoutLeakingBodyOrRetrying(int status)
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) =>
        {
            calls++;
            var response = Json("{\"code\":\"fixture-error\",\"private\":\"secret\"}", (HttpStatusCode)status);
            response.Headers.TryAddWithoutValidation("Retry-After", "12");
            return Task.FromResult(response);
        }));
        using var client = new PortalApiClient(http);
        var error = await Assert.ThrowsAnyAsync<PortalApiException>(() => client.GetCurrentManagerAsync());
        Assert.Equal(status, error.StatusCode);
        Assert.Equal("fixture-error", error.Code);
        Assert.Contains("12", error.Headers["Retry-After"]);
        Assert.DoesNotContain("secret", error.Message + error.ToString());
        Assert.Equal(1, calls);
    }

    [Theory]
    [InlineData("null")] [InlineData("[]")] [InlineData("<html>error</html>")]
    public void NonObjectErrorBodyHasNoCode(string body) => Assert.Null(new PortalApiException("", 503, body, new Dictionary<string, IEnumerable<string>>(), null).Code);

    [Fact]
    public async Task CancellationReachesTransport()
    {
        using var http = Transport(new Handler(async (_, cancellation) => { await Task.Delay(Timeout.Infinite, cancellation); return Json("{}"); }));
        using var client = new PortalApiClient(http);
        using var cancellation = new CancellationTokenSource();
        var pending = client.GetCurrentManagerAsync(cancellation.Token);
        cancellation.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => pending);
    }

    [Theory]
    [InlineData("{\"tokenType\":\"Bearer\",\"accessToken\":\"token\"}")]
    [InlineData("{\"tokenType\":\"Basic\",\"accessToken\":\"token\",\"expiresIn\":3600}")]
    [InlineData("{\"tokenType\":\"Bearer\",\"accessToken\":\"bad token\",\"expiresIn\":3600}")]
    public async Task InvalidSessionsAreNotAccepted(string response)
    {
        using var http = Transport(new Handler((_, _) => Task.FromResult(Json(response))));
        using var client = new PortalApiClient(http);
        await Assert.ThrowsAsync<InvalidDataException>(() => client.LoginAsync("test@example.invalid", "test"));
        Assert.Null(client.AccessToken);
    }

    [Theory]
    [InlineData(null, "fixture", "email", true)]
    [InlineData("test@example.invalid", null, "password", true)]
    [InlineData(" ", "fixture", "email", false)]
    [InlineData("test@example.invalid", " ", "password", false)]
    public async Task InvalidCredentialsFailBeforeTransport(string? email, string? password, string parameter, bool isNull)
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) => { calls++; return Task.FromResult(Json(Session)); }));
        using var client = new PortalApiClient(http);
        var error = await Assert.ThrowsAnyAsync<ArgumentException>(() => client.LoginAsync(email!, password!));
        Assert.Equal(parameter, error.ParamName);
        Assert.Equal(isNull, error is ArgumentNullException);
        Assert.Equal(0, calls);
    }

    [Fact]
    public async Task BinaryDownloadReturnsOwnedStream()
    {
        using var http = Transport(new Handler((_, _) => Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new ByteArrayContent([80, 75, 3, 4]) })));
        using var client = new PortalApiClient(http);
        var file = await client.DownloadBankSettlementAsync("opaque-KID", 7, "zip");
        using var bytes = new MemoryStream();
        await file.Stream.CopyToAsync(bytes);
        Assert.Equal(new byte[] { 80, 75, 3, 4 }, bytes.ToArray());
        file.Dispose();
        Assert.False(file.Stream.CanRead);
    }

    [Fact]
    public async Task EveryPublishedOperationHasTypedMethodAndCorrectHttpRoute()
    {
        using var contract = JsonDocument.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "portal.openapi.json")));
        var operations = contract.RootElement.GetProperty("paths").EnumerateObject()
            .SelectMany(path => path.Value.EnumerateObject().Where(op => op.Value.TryGetProperty("operationId", out _)).Select(op => (path.Name, Verb: op.Name, Operation: op.Value))).ToArray();
        Assert.Equal(operations.Length, typeof(IPortalApiClient).GetMethods().Length);
        foreach (var (path, verb, operation) in operations)
        {
            var method = typeof(IPortalApiClient).GetMethod(operation.GetProperty("operationId").GetString() + "Async");
            Assert.NotNull(method);
            var success = operation.GetProperty("responses").EnumerateObject().First(r => r.Name.StartsWith("2", StringComparison.Ordinal));
            var resultType = method.ReturnType.GenericTypeArguments.FirstOrDefault();
            var json = resultType is not null && typeof(System.Collections.IEnumerable).IsAssignableFrom(resultType) && resultType != typeof(string) ? "[]" : "{}";
            HttpRequestMessage? sent = null;
            using var http = Transport(new Handler((request, _) => { sent = request; return Task.FromResult(Json(json, (HttpStatusCode)int.Parse(success.Name))); }));
            using var client = new PortalApiClient(http);
            var expectedPath = path;
            var arguments = method.GetParameters().Select(parameter =>
            {
                var type = Nullable.GetUnderlyingType(parameter.ParameterType) ?? parameter.ParameterType;
                object? value = type == typeof(string) ? "opaque-KID" : type.IsValueType ? Activator.CreateInstance(type) : parameter.HasDefaultValue ? null : Activator.CreateInstance(type);
                if (expectedPath.Contains("{" + parameter.Name + "}")) expectedPath = expectedPath.Replace("{" + parameter.Name + "}", value?.ToString());
                return value;
            }).ToArray();
            if (method.Invoke(client, arguments) is Task task) await task;
            Assert.NotNull(sent);
            Assert.Equal(verb.ToUpperInvariant(), sent.Method.Method);
            Assert.Equal(expectedPath, Uri.UnescapeDataString(sent.RequestUri!.AbsolutePath));
            Assert.Equal("tenant.example", sent.RequestUri.Host);
        }
    }

    [Theory]
    [InlineData(200)]
    [InlineData(206)]
    public async Task WindowsPackageDownloadPreservesBinaryContent(int status)
    {
        byte[] expected = [80, 75, 0, 255, 1];
        using var http = Transport(new Handler((request, _) =>
        {
            Assert.Equal("/download/windows/x64/portal.msix", request.RequestUri!.AbsolutePath);
            return Task.FromResult(new HttpResponseMessage((HttpStatusCode)status) { Content = new ByteArrayContent(expected) });
        }));
        using var client = new PortalApiClient(http);
        using var download = await client.DownloadPortalWindowsPackageAsync("x64", "portal.msix");
        using var bytes = new MemoryStream();
        await download.Stream.CopyToAsync(bytes);
        Assert.Equal(expected, bytes.ToArray());
        Assert.Equal(status, download.StatusCode);
    }

    [Fact]
    public void AssemblyHasOnlyFrameworkAndMicrosoftJsonDependencies()
    {
        Assert.All(typeof(PortalApiClient).Assembly.GetReferencedAssemblies(), reference =>
            Assert.True(reference.Name is "System.Runtime" or "netstandard" || reference.Name!.StartsWith("System."), reference.FullName));
    }

    [Fact]
    public void ConsumerLoadsTheExpectedClientTarget()
    {
        var target = typeof(PortalApiClient).Assembly.GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
            .Cast<System.Runtime.Versioning.TargetFrameworkAttribute>().Single().FrameworkName;
#if NETFRAMEWORK
        Assert.Equal(".NETStandard,Version=v2.0", target);
#elif NET10_0_OR_GREATER
        Assert.Equal(".NETCoreApp,Version=v10.0", target);
#else
        Assert.Equal(".NETCoreApp,Version=v8.0", target);
#endif
    }

    [Fact]
    public async Task CurrencyBalancesPreserveMinorUnitsNullsAndOpaqueKids()
    {
        var kid = "CaseSensitive-KID";
        using var http = Transport(new Handler(async (request, cancellation) =>
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync());
            Assert.Equal(kid, body.RootElement.GetProperty("userKids")[0].GetString());
            return Json("{\"items\":[{\"kid\":\"CaseSensitive-KID\",\"status\":\"ok\",\"balances\":[{\"currency\":\"DKK\",\"currentBalanceMinor\":-9007199254740993,\"previousBalanceMinor\":null},{\"currency\":\"EUR\",\"currentBalanceMinor\":-1000,\"previousBalanceMinor\":0}]}]}");
        }));
        using var client = new PortalApiClient(http);
        var response = await client.GetBankUserBalancesAsync("bank-KID", new UserBalancesRequest { UserKids = [kid] });
        var resident = Assert.Single(response.Items!);
        Assert.Equal(kid, resident.Kid);
        Assert.Collection(resident.Balances!,
            dkk => { Assert.Equal("DKK", dkk.Currency); Assert.Equal(-9007199254740993L, dkk.CurrentBalanceMinor); Assert.Null(dkk.PreviousBalanceMinor); },
            eur => { Assert.Equal("EUR", eur.Currency); Assert.Equal(-1000L, eur.CurrentBalanceMinor); Assert.Equal(0L, eur.PreviousBalanceMinor); });
    }

    [Fact]
    public async Task ReceiptPagePreservesDateOffsetsMoneyAndRevision()
    {
        var calls = 0;
        using var http = Transport(new Handler((request, _) =>
        {
            calls++;
            Assert.Equal("/api/v1/users/CaseSensitive-KID/receipts", request.RequestUri!.AbsolutePath);
            Assert.Equal("?offset=20&revision=opaque%2Brevision", request.RequestUri.Query);
            Assert.Equal("fixture-token", request.Headers.Authorization?.Parameter);
            return Task.FromResult(Json("{\"userKid\":\"CaseSensitive-KID\",\"revision\":\"opaque+revision\",\"nextOffset\":40,\"periodCount\":2,\"items\":[{\"key\":\"r1\",\"date\":\"2026-10-01\",\"kind\":\"Purchase\",\"currency\":\"DKK\",\"totalMinor\":-9007199254740993,\"vatMinor\":null,\"balanceAfterMinor\":0,\"lines\":[{\"kid\":null,\"occurredAt\":\"2026-10-01T12:30:00+02:00\",\"texts\":[\"Vask\"],\"amountMinor\":-9007199254740993,\"calculated\":true}]}]}"));
        }));
        using var client = new PortalApiClient(http) { AccessToken = "fixture-token" };
        var page = await client.GetUserReceiptsAsync("CaseSensitive-KID", 20, "opaque+revision");
        Assert.Equal("opaque+revision", page.Revision);
        Assert.Equal(40, page.NextOffset);
        var receipt = Assert.Single(page.Items!);
        Assert.Equal(new DateTime(2026, 10, 1), receipt.Date!.Value.Date);
        Assert.Equal(-9007199254740993L, receipt.TotalMinor);
        Assert.Equal(0L, receipt.BalanceAfterMinor);
        Assert.Null(receipt.VatMinor);
        var line = Assert.Single(receipt.Lines!);
        Assert.Null(line.Kid);
        Assert.Equal(TimeSpan.FromHours(2), line.OccurredAt!.Value.Offset);
        Assert.Equal(-9007199254740993L, line.AmountMinor);
        Assert.Equal(1, calls); // Paging stays caller-controlled, including when another page exists.
    }

    [Fact]
    public async Task ReceiptRevisionConflictIsReturnedWithoutRetry()
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) =>
        {
            calls++;
            return Task.FromResult(Json("{\"code\":\"receipts-changed\"}", HttpStatusCode.Conflict));
        }));
        using var client = new PortalApiClient(http);
        var error = await Assert.ThrowsAnyAsync<PortalApiException>(() => client.GetUserReceiptsAsync("resident-KID", 20, "previous-revision"));
        Assert.Equal(409, error.StatusCode);
        Assert.Equal("receipts-changed", error.Code);
        Assert.Equal(1, calls);
    }

    [Fact]
    public async Task RejectsBaseAddressChangeBeforeSendingAToken()
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) => { calls++; return Task.FromResult(Json("{}")); }));
        using var client = new PortalApiClient(http) { AccessToken = "secret-token" };
        http.BaseAddress = new Uri("https://other.example/");
        await Assert.ThrowsAsync<InvalidOperationException>(() => client.GetCurrentManagerAsync());
        Assert.Equal(0, calls);
    }

    [Fact]
    public async Task DateFiltersUseDateOnlyWireFormat()
    {
        var urls = new List<string>();
        using var http = Transport(new Handler((request, _) => { urls.Add(request.RequestUri!.Query); return Task.FromResult(Json("{}")); }));
        using var client = new PortalApiClient(http);
        await client.GetBankAccountAsync("bank-KID", from: new DateTimeOffset(2026, 9, 1, 0, 0, 0, TimeSpan.FromHours(2)), through: new DateTimeOffset(2026, 9, 26, 0, 0, 0, TimeSpan.FromHours(2)));
        Assert.Contains("From=2026-09-01", urls[0]);
        Assert.Contains("Through=2026-09-26", urls[0]);
        Assert.DoesNotContain("00%3A", urls[0]);
    }

    [Fact]
    public async Task OwnedTransportReadsJsonOverRealLoopbackHttp()
    {
        var listener = new System.Net.Sockets.TcpListener(IPAddress.Loopback, 0);
        listener.Start();
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(10));
        using var stop = deadline.Token.Register(listener.Stop);
        try
        {
            var endpoint = new Uri("http://127.0.0.1:" + ((IPEndPoint)listener.LocalEndpoint).Port + "/");
            var serve = Task.Run(async () =>
            {
                using var socket = await listener.AcceptTcpClientAsync();
                using var stream = socket.GetStream();
                using var reader = new StreamReader(stream, Encoding.ASCII, false, 1024, true);
                var request = new List<string>();
                string? line;
                while (!string.IsNullOrEmpty(line = await reader.ReadLineAsync())) request.Add(line!);
                Assert.StartsWith("GET /api/v1/session/me ", request[0]);
                Assert.Contains(request, header => header.Equals("Authorization: Bearer fixture-token", StringComparison.OrdinalIgnoreCase));
                var body = Encoding.UTF8.GetBytes("{\"name\":\"Æøå fixture\"}");
                var headers = Encoding.ASCII.GetBytes("HTTP/1.1 200 OK\r\nContent-Type: application/json; charset=utf-8\r\nContent-Length: " + body.Length + "\r\nConnection: close\r\n\r\n");
                await stream.WriteAsync(headers, 0, headers.Length, deadline.Token);
                await stream.WriteAsync(body, 0, body.Length, deadline.Token);
            });
            using var client = new PortalApiClient(endpoint) { AccessToken = "fixture-token" };
            try
            {
                var manager = await client.GetCurrentManagerAsync(deadline.Token);
                Assert.Equal("Æøå fixture", manager.Name);
            }
            finally
            {
                listener.Stop();
                await serve;
            }
        }
        finally { listener.Stop(); }
    }

    private sealed class Handler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send) : HttpMessageHandler
    { protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) => send(request, cancellationToken); }
}
