using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Kombine.Flex.Portal.Client.Tests;

public sealed class ConsolidatedReleaseTests
{
    [Fact]
    public async Task AccountWithoutDateFilterPreservesAnUnknownEndDate()
    {
        using var http = new HttpClient(new Handler(request =>
        {
            Assert.Equal("/api/v1/banks/Bank-KID/account", request.RequestUri!.AbsolutePath);
            Assert.Equal("", request.RequestUri.Query);
            return Task.FromResult(Json("{\"through\":null,\"entries\":[]}"));
        })) { BaseAddress = new Uri("https://fixture.invalid/") };
        using var client = new PortalApiClient(http);
        var result = await client.GetBankAccountAsync("Bank-KID");
        Assert.Null(result.Through);
    }

    [Fact]
    public async Task PageMovePreservesBothRevisionsAndReturnsBothUpdatedSettings()
    {
        using var http = new HttpClient(new Handler(async request =>
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/api/v1/session/me/wallboards/public/move-page", request.RequestUri!.AbsolutePath);
            using var body = JsonDocument.Parse(await request.Content!.ReadAsStringAsync());
            Assert.Equal("private-before", body.RootElement.GetProperty("revision").GetString());
            Assert.Equal("public-before", body.RootElement.GetProperty("publicRevision").GetString());
            Assert.Equal("Screen-Case", body.RootElement.GetProperty("sourceDisplayId").GetString());
            Assert.True(body.RootElement.GetProperty("toPublic").GetBoolean());
            return Json("{\"personal\":{\"revision\":\"private-after\"},\"public\":{\"revision\":\"public-after\"}}");
        })) { BaseAddress = new Uri("https://fixture.invalid/") };
        using var client = new PortalApiClient(http);
        var result = await client.MovePublicWallboardPageAsync(new MovePublicWallboardPageRequest
        {
            Revision = "private-before", PublicRevision = "public-before", SourceDisplayId = "Screen-Case",
            ToPublic = true, PageIndex = 0, TargetPageIndex = 1
        });
        Assert.Equal("private-after", result.Personal!.Revision);
        Assert.Equal("public-after", result.Public!.Revision);
    }

    private static HttpResponseMessage Json(string value) => new(HttpStatusCode.OK)
    { Content = new StringContent(value, Encoding.UTF8, "application/json") };

    private sealed class Handler(Func<HttpRequestMessage, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => send(request);
    }
}
