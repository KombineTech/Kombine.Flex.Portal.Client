using System.Net;
using System.Net.Http;
using System.Text;
using Kombine.Flex.Portal.Client;

namespace Kombine.Flex.Portal.Client.Tests;

public sealed class SessionTests
{
    private static HttpResponseMessage Json(string token, int seconds = 3600) => new(HttpStatusCode.OK)
    { Content = new StringContent("{\"accessToken\":\"" + token + "\",\"tokenType\":\"Bearer\",\"expiresIn\":" + seconds + "}", Encoding.UTF8, "application/json") };
    private sealed class Handler(Func<HttpRequestMessage, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct) => send(request);
    }
    private static HttpClient Http(Func<HttpRequestMessage, Task<HttpResponseMessage>> send) => new(new Handler(send)) { BaseAddress = new Uri("https://fixture.test/") };
    private static PortalSession Session(HttpClient http, Func<DateTimeOffset>? now = null, bool configured = true)
        => new(http.BaseAddress!, configured ? _ => Task.FromResult(new PortalCredentials("fixture@example.invalid", "fixture-password")) : null,
            () => new PortalApiClient(http), now);

    [Fact]
    public async Task ConcurrentLoginAndRenewalAreCoalescedAndTokensAreReused()
    {
        var now = DateTimeOffset.UtcNow;
        var calls = 0;
        var release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var http = Http(async request =>
        {
            Interlocked.Increment(ref calls);
            await release.Task;
            return Json(request.RequestUri!.AbsolutePath.EndsWith("login") ? "login-token" : "renewed-token");
        });
        var session = Session(http, () => now);
        var logins = Enumerable.Range(0, 12).Select(_ => session.GetTokenAsync()).ToArray();
        Assert.Equal(1, calls);
        release.SetResult(true);
        var tokens = await Task.WhenAll(logins);
        Assert.All(tokens, token => Assert.Same(tokens[0], token));
        now = now.AddSeconds(3550);
        release = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        var renewals = Enumerable.Range(0, 12).Select(_ => session.GetTokenAsync()).ToArray();
        Assert.Equal(2, calls);
        release.SetResult(true);
        var renewed = await Task.WhenAll(renewals);
        Assert.All(renewed, token => Assert.Same(renewed[0], token));
        Assert.Equal("renewed-token", renewed[0].AccessToken);
        Assert.Equal(now.AddSeconds(3600), renewed[0].ExpiresUtc);
    }

    [Fact]
    public async Task LongLivedClientRenewsBeforeLaterCallsWithoutCallerSessionCode()
    {
        var now = DateTimeOffset.UtcNow;
        var tokens = new List<string?>();
        using var http = Http(request =>
        {
            if (request.RequestUri!.AbsolutePath.EndsWith("/renew")) return Task.FromResult(Json("renewed"));
            tokens.Add(request.Headers.Authorization?.Parameter);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") });
        });
        var session = Session(http, () => now, false);
        session.Restore("initial", now.AddHours(1));
        using var client = await session.CreateClientAsync();
        await client.GetCurrentManagerAsync();
        now = now.AddMinutes(59.5);
        await client.GetCurrentManagerAsync();
        Assert.Equal(new[] { "initial", "renewed" }, tokens);
        client.Dispose();
        Assert.Equal("renewed", session.Current!.AccessToken);
    }

    [Fact]
    public async Task LogoutDuringRenewalCannotResurrectSessionOrAutomaticallyLogin()
    {
        var response = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var http = Http(_ => response.Task);
        var session = Session(http);
        session.Restore("old-token", DateTimeOffset.UtcNow.AddHours(1));
        var renewal = session.RenewAsync();
        session.ClearSession();
        response.SetResult(Json("new-token"));
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => renewal);
        Assert.Null(session.Current);
        await Assert.ThrowsAsync<InvalidOperationException>(() => session.GetTokenAsync());
    }

    [Fact]
    public async Task ExpiredInteractiveSessionRequiresLoginAndHasNoNetworkActivity()
    {
        var now = DateTimeOffset.UtcNow;
        var calls = 0;
        using var http = Http(_ => { calls++; return Task.FromResult(Json("unexpected")); });
        var session = Session(http, () => now, false);
        session.Restore("old-token", now.AddMinutes(1));
        now = now.AddMinutes(2);
        await Assert.ThrowsAsync<InvalidOperationException>(() => session.GetTokenAsync());
        Assert.Equal(0, calls);
    }

    [Theory]
    [InlineData(401, 2)] [InlineData(403, 1)] [InlineData(429, 1)] [InlineData(503, 1)]
    public async Task OnlyUnauthorizedReadsRetryOnce(int status, int expectedReads)
    {
        var logins = 0; var reads = 0;
        using var http = Http(request =>
        {
            if (request.RequestUri!.AbsolutePath.EndsWith("login")) return Task.FromResult(Json("login-" + ++logins));
            reads++;
            return Task.FromResult(new HttpResponseMessage((HttpStatusCode)status) { Content = new StringContent("{}") });
        });
        var session = Session(http);
        await Assert.ThrowsAnyAsync<PortalApiException>(() => session.ExecuteReadAsync((api, ct) => api.GetCurrentManagerAsync(ct)));
        Assert.Equal(expectedReads, reads);
        Assert.Equal(expectedReads, logins);
    }

    [Fact]
    public async Task RenewalUnavailableDoesNotFallBackToLoginOrLoseExistingSession()
    {
        var now = DateTimeOffset.UtcNow;
        using var http = Http(request =>
        {
            Assert.EndsWith("/renew", request.RequestUri!.AbsolutePath);
            return Task.FromResult(new HttpResponseMessage(HttpStatusCode.ServiceUnavailable) { Content = new StringContent("{}") });
        });
        var session = Session(http, () => now);
        session.Restore("old", now.AddSeconds(30));
        await Assert.ThrowsAnyAsync<PortalApiException>(() => session.GetTokenAsync());
        Assert.Equal("old", session.Current!.AccessToken);
    }

    [Fact]
    public async Task LateUnauthorizedResponseDoesNotDiscardNewerSession()
    {
        var now = DateTimeOffset.UtcNow;
        var oldRead = new TaskCompletionSource<HttpResponseMessage>(TaskCreationOptions.RunContinuationsAsynchronously);
        using var http = Http(request => request.RequestUri!.AbsolutePath.EndsWith("/renew")
            ? Task.FromResult(Json("new-token"))
            : request.Headers.Authorization?.Parameter == "old-token" ? oldRead.Task
            : Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") }));
        var session = Session(http, () => now);
        session.Restore("old-token", now.AddHours(1));
        var read = session.ExecuteReadAsync((api, ct) => api.GetCurrentManagerAsync(ct));
        await session.RenewAsync();
        oldRead.SetResult(new HttpResponseMessage(HttpStatusCode.Unauthorized) { Content = new StringContent("{}") });
        await read;
        Assert.Equal("new-token", session.Current!.AccessToken);
    }

    [Fact]
    public async Task SeparateSessionsSharingTransportNeverShareAuthorization()
    {
        var tokens = new List<string?>();
        using var http = Http(request => { tokens.Add(request.Headers.Authorization?.Parameter); return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("{}") }); });
        var first = Session(http); var second = Session(http);
        first.Restore("first", DateTimeOffset.UtcNow.AddHours(1)); second.Restore("second", DateTimeOffset.UtcNow.AddHours(1));
        using var one = await first.CreateClientAsync(); using var two = await second.CreateClientAsync();
        await one.GetCurrentManagerAsync(); await two.GetCurrentManagerAsync();
        Assert.Equal(new[] { "first", "second" }, tokens);
        Assert.Null(http.DefaultRequestHeaders.Authorization);
        first.ClearSession();
        Assert.Equal("second", second.Current!.AccessToken);
    }

    [Fact]
    public async Task TransportRejectsForeignUrlsAndKeepsCallerOwnedTransportAlive()
    {
        using var http = Http(_ => Task.FromResult(Json("unused")));
        using var api = new PortalApiClient(http);
        using var foreign = new HttpRequestMessage(HttpMethod.Get, "https://other.test/api/v1/status");
        await Assert.ThrowsAsync<InvalidOperationException>(() => api.SendRequestAsync(foreign));
        api.Dispose();
        using var request = new HttpRequestMessage(HttpMethod.Get, "api/v1/status");
        using var second = new PortalApiClient(http);
        using var response = await second.SendRequestAsync(request);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
