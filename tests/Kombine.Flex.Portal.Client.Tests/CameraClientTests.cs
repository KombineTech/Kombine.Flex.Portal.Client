using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using Kombine.Flex.Portal.Client;

namespace Kombine.Flex.Portal.Client.Tests;

public sealed class CameraClientTests
{
    [Fact]
    public async Task BackgroundUploadReturnsAcceptedIdentityAndConfirmationKeepsUnknownProgress()
    {
        using var original = new MemoryStream(new byte[] { 255, 216, 255, 217 });
        using var http = Transport(new Handler((request, _) =>
        {
            if (request.RequestUri!.AbsolutePath.EndsWith("/confirmation"))
                return Task.FromResult(Json("{\"confirmed\":false,\"errorCode\":null,\"processingPercent\":null}"));
            Assert.Contains("background=true", request.RequestUri.Query);
            return Task.FromResult(Json("{\"captureId\":\"pending\",\"resourceKid\":\"kid\"}", HttpStatusCode.Accepted));
        }));
        var client = new PortalApiClient(http);
        client.AccessToken = "fixture-token";
        var accepted = await client.SaveCameraCaptureAsync(background: true, uploadToken: "ticket", original: new FileParameter(original, "photo.jpg"));
        Assert.Equal("pending", accepted.CaptureId);
        var confirmation = await client.ConfirmCameraCaptureAsync(new CameraConfirmationRequest { UploadToken = "ticket" });
        Assert.False(confirmation.Confirmed);
        Assert.Null(confirmation.ProcessingPercent);
    }

    private static HttpResponseMessage Json(string value, HttpStatusCode status = HttpStatusCode.OK)
        => new(status) { Content = new StringContent(value, Encoding.UTF8, "application/json") };
    private static HttpClient Transport(HttpMessageHandler handler)
        => new(handler) { BaseAddress = new Uri("https://tenant.example/") };

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task CameraUploadPreservesBinaryPartsAndOptionalMotion(bool livePhoto)
    {
        byte[] photo = [255, 216, 0, 128, 13, 10, 255, 217];
        byte[] movie = [0, 0, 0, 24, 102, 116, 121, 112, 255];
        using var original = new MemoryStream(photo);
        using var motion = new MemoryStream(movie);
        using var http = Transport(new Handler(async (request, _) =>
        {
            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal("/api/v1/camera", request.RequestUri!.AbsolutePath);
            Assert.Equal("", request.RequestUri.Query);
            Assert.Equal("fixture-token", request.Headers.Authorization?.Parameter);
            Assert.True(request.Headers.CacheControl!.NoStore);
            var form = Assert.IsType<MultipartFormDataContent>(request.Content);
            var parts = form.ToDictionary(part => part.Headers.ContentDisposition!.Name!.Trim('"'));
            Assert.Equal(livePhoto ? 3 : 2, parts.Count);
            Assert.Equal("signed+ticket/==", await parts["uploadToken"].ReadAsStringAsync());
            Assert.Equal("image/jpeg", parts["original"].Headers.ContentType!.MediaType);
            Assert.Equal("IMG_001.JPG", parts["original"].Headers.ContentDisposition!.FileName!.Trim('"'));
            Assert.Equal(photo, await parts["original"].ReadAsByteArrayAsync());
            if (livePhoto)
            {
                Assert.Equal("video/quicktime", parts["motion"].Headers.ContentType!.MediaType);
                Assert.Equal("IMG_001.MOV", parts["motion"].Headers.ContentDisposition!.FileName!.Trim('"'));
                Assert.Equal(movie, await parts["motion"].ReadAsByteArrayAsync());
            }
            else Assert.False(parts.ContainsKey("motion"));
            return Json("{\"captureId\":\"capture-one\",\"resourceKid\":\"CaseSensitive-KID\"}");
        }));
        using var client = new PortalApiClient(http) { AccessToken = "fixture-token" };
        var result = await client.SaveCameraCaptureAsync(null, "signed+ticket/==",
            new FileParameter(original, "IMG_001.JPG", "image/jpeg"),
            livePhoto ? new FileParameter(motion, "IMG_001.MOV", "video/quicktime") : null);
        Assert.Equal("capture-one", result.CaptureId);
        Assert.Equal("CaseSensitive-KID", result.ResourceKid);
    }

    [Fact]
    public async Task PreparePreservesMetadataAndLargeIntegerWithoutAddingTenantOrOwner()
    {
        var date = new DateTimeOffset(2026, 10, 15, 12, 34, 56, TimeSpan.Zero);
        using var http = Transport(new Handler(async (request, _) =>
        {
            Assert.Equal("/api/v1/camera/prepare", request.RequestUri!.AbsolutePath);
            using var document = JsonDocument.Parse(await request.Content!.ReadAsStringAsync());
            var root = document.RootElement;
            Assert.Equal("CaseSensitive-KID", root.GetProperty("resourceKid").GetString());
            Assert.Equal(date, root.GetProperty("capturedAtUtc").GetDateTimeOffset());
            Assert.Equal(9007199254740993L, root.GetProperty("sensorData").GetProperty("sequence").GetInt64());
            Assert.Equal(55.67, root.GetProperty("sensorData").GetProperty("location").GetProperty("latitude").GetDouble());
            Assert.False(root.TryGetProperty("tenantId", out var tenantValue));
            Assert.False(root.TryGetProperty("ownerKid", out var ownerValue));
            return Json("{\"uploadToken\":\"opaque+ticket/==\"}");
        }));
        using var client = new PortalApiClient(http);
        var result = await client.PrepareCameraCaptureAsync(new CameraPrepareRequest
        {
            ResourceKid = "CaseSensitive-KID", Kind = "photo", OriginalFileName = "IMG_001.JPG",
            OriginalNameAvailable = true, CapturedAtUtc = date, MediaLength = 8, MediaSha256 = new string('A', 64),
            SensorData = new { sequence = 9007199254740993L, location = new { status = "available", latitude = 55.67, longitude = 12.56 } }
        });
        Assert.Equal("opaque+ticket/==", result.UploadToken);
    }

    [Theory]
    [InlineData(200, null)]
    [InlineData(206, "bytes=2-4")]
    public async Task CameraDownloadPreservesStreamAndOptionalRange(int status, string? range)
    {
        byte[] expected = [0, 128, 255];
        using var http = Transport(new Handler((request, _) =>
        {
            Assert.Equal("/api/v1/camera/opaque%2Bcapture%2Ftoken/content", request.RequestUri!.AbsolutePath);
            Assert.Equal("?part=playback", request.RequestUri.Query);
            Assert.Equal(range, request.Headers.TryGetValues("Range", out var values) ? Assert.Single(values) : null);
            Assert.Equal("fixture-token", request.Headers.Authorization?.Parameter);
            return Task.FromResult(new HttpResponseMessage((HttpStatusCode)status) { Content = new ByteArrayContent(expected) });
        }));
        using var client = new PortalApiClient(http) { AccessToken = "fixture-token" };
        var result = await client.GetCameraCaptureContentAsync("opaque+capture/token", "playback", range);
        using var output = new MemoryStream();
        await result.Stream.CopyToAsync(output);
        Assert.Equal(expected, output.ToArray());
        Assert.Equal(status == 206, result.IsPartial);
        result.Dispose();
        Assert.False(result.Stream.CanRead);
    }

    [Fact]
    public async Task GalleryRetainsDegradationCursorAndPlaybackFlags()
    {
        using var http = Transport(new Handler((request, _) =>
        {
            Assert.Equal("?resourceKid=CaseSensitive-KID&cursor=opaque%2Bcursor%2F%3D%3D", request.RequestUri!.Query);
            return Task.FromResult(Json("{\"items\":[{\"id\":\"opaque-id\",\"captureId\":\"capture-one\",\"resourceKid\":\"CaseSensitive-KID\",\"ownerKid\":\"Owner-KID\",\"fileName\":\"IMG_001.MOV\",\"kind\":\"video\",\"capturedAtUtc\":\"2026-10-15T12:34:56Z\",\"hasPreview\":true,\"hasMotion\":false,\"hasPlayback\":true}],\"nextCursor\":\"next+cursor\",\"isDegraded\":true}"));
        }));
        using var client = new PortalApiClient(http);
        var result = await client.GetCameraCapturesAsync("CaseSensitive-KID", "opaque+cursor/==");
        Assert.True(result.IsDegraded);
        Assert.Equal("next+cursor", result.NextCursor);
        var item = Assert.Single(result.Items!);
        Assert.True(item.HasPreview); Assert.True(item.HasPlayback); Assert.False(item.HasMotion);
        Assert.Equal("Owner-KID", item.OwnerKid);
    }

    [Theory]
    [InlineData(302)]
    [InlineData(401)]
    [InlineData(413)]
    [InlineData(503)]
    public async Task UploadFailuresNeverRetryOrExposeToken(int status)
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) =>
        {
            calls++;
            return Task.FromResult(Json("{\"code\":\"camera-storage-unavailable\",\"private\":\"private-secret\"}", (HttpStatusCode)status));
        }));
        using var client = new PortalApiClient(http);
        using var original = new MemoryStream([1, 2, 3]);
        var failure = await Assert.ThrowsAnyAsync<PortalApiException>(() => client.SaveCameraCaptureAsync(null, "signed-ticket", new FileParameter(original, "photo.jpg", "image/jpeg")));
        Assert.Equal(status, failure.StatusCode);
        Assert.Equal(1, calls);
        Assert.DoesNotContain("private-secret", failure.ToString());
        Assert.DoesNotContain("signed-ticket", failure.ToString());
    }

    [Fact]
    public async Task UploadCancellationReachesTransportWithoutRetry()
    {
        var calls = 0;
        using var http = Transport(new Handler(async (_, cancellation) =>
        {
            calls++;
            await Task.Delay(Timeout.Infinite, cancellation);
            return Json("{}");
        }));
        using var client = new PortalApiClient(http);
        using var original = new MemoryStream([1]);
        using var cancellation = new CancellationTokenSource();
        var pending = client.SaveCameraCaptureAsync(null, "ticket", new FileParameter(original, "photo.jpg"), cancellationToken: cancellation.Token);
        cancellation.Cancel();
        await Assert.ThrowsAnyAsync<OperationCanceledException>(() => pending);
        Assert.Equal(1, calls);
    }

    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public async Task RequiredUploadPartsFailBeforeTransport(bool missingToken)
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) => { calls++; return Task.FromResult(Json("{}")); }));
        using var client = new PortalApiClient(http);
        using var original = new MemoryStream([1]);
        var error = await Assert.ThrowsAsync<ArgumentNullException>(() => client.SaveCameraCaptureAsync(null,
            missingToken ? null : "ticket", missingToken ? new FileParameter(original, "photo.jpg") : null!));
        Assert.Equal(missingToken ? "uploadToken" : "original", error.ParamName);
        Assert.Equal(0, calls);
    }

    private sealed class Handler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => send(request, cancellationToken);
    }
}
