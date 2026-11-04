using System.Net;
using System.Net.Http;
using System.Text;
using Kombine.Flex.Portal.Client;

namespace Kombine.Flex.Portal.Client.Tests;

public sealed class LocationWeatherClientTests
{
    private static HttpResponseMessage Json(string value, HttpStatusCode status = HttpStatusCode.OK)
        => new(status) { Content = new StringContent(value, Encoding.UTF8, "application/json") };
    private static HttpClient Transport(HttpMessageHandler handler)
        => new(handler) { BaseAddress = new Uri("https://tenant.example/") };

    [Theory]
    [InlineData(0)]
    [InlineData(-5.25)]
    public async Task AvailableWeatherPreservesUnitsZeroValuesAndUtcTimes(double temperature)
    {
        using var http = Transport(new Handler((request, _) =>
        {
            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal("/api/v1/locations/CaseSensitive-KID/weather", request.RequestUri!.AbsolutePath);
            Assert.Equal("", request.RequestUri.Query);
            Assert.Equal("fixture-token", request.Headers.Authorization?.Parameter);
            Assert.True(request.Headers.CacheControl!.NoStore);
            return Task.FromResult(Json("{\"locationKid\":\"CaseSensitive-KID\",\"status\":\"Available\",\"address\":\"Testvej 1\",\"zip\":\"1234\",\"positionSource\":\"Coordinates\",\"current\":{\"observedAtUtc\":\"2026-10-15T22:00:00Z\",\"retrievedAtUtc\":\"2026-10-15T22:01:02.345Z\",\"temperatureCelsius\":" + temperature.ToString(System.Globalization.CultureInfo.InvariantCulture) + ",\"apparentTemperatureCelsius\":-6.5,\"windSpeedMetresPerSecond\":2.75,\"precipitationMillimetres\":0,\"relativeHumidityPercent\":85,\"weatherCode\":0,\"isDay\":false}}"));
        }));
        using var client = new PortalApiClient(http) { AccessToken = "fixture-token" };
        var result = await client.GetLocationWeatherAsync("CaseSensitive-KID");
        Assert.Equal("CaseSensitive-KID", result.LocationKid);
        Assert.Equal("Available", result.Status);
        Assert.Equal("Coordinates", result.PositionSource);
        Assert.Equal("Testvej 1", result.Address); Assert.Equal("1234", result.Zip);
        Assert.NotNull(result.Current);
        Assert.Equal(temperature, result.Current.TemperatureCelsius);
        Assert.Equal(-6.5, result.Current.ApparentTemperatureCelsius);
        Assert.Equal(2.75, result.Current.WindSpeedMetresPerSecond);
        Assert.Equal(0, result.Current.PrecipitationMillimetres);
        Assert.Equal(85, result.Current.RelativeHumidityPercent);
        Assert.Equal(0, result.Current.WeatherCode);
        Assert.False(result.Current.IsDay);
        Assert.Equal(new DateTimeOffset(2026, 10, 15, 22, 0, 0, TimeSpan.Zero), result.Current.ObservedAtUtc);
        Assert.Equal(new DateTimeOffset(2026, 10, 15, 22, 1, 2, 345, TimeSpan.Zero), result.Current.RetrievedAtUtc);
    }

    [Theory]
    [InlineData("")]
    [InlineData(",\"apparentTemperatureCelsius\":null,\"windSpeedMetresPerSecond\":null,\"precipitationMillimetres\":null,\"relativeHumidityPercent\":null,\"weatherCode\":null,\"isDay\":null")]
    public async Task MissingOptionalMeasurementsRemainUnknown(string optionalFields)
    {
        using var http = Transport(new Handler((_, _) => Task.FromResult(Json("{\"status\":\"Available\",\"positionSource\":\"Address\",\"current\":{\"observedAtUtc\":\"2026-10-15T22:00:00Z\",\"retrievedAtUtc\":\"2026-10-15T22:01:00Z\",\"temperatureCelsius\":12.5" + optionalFields + "}}"))));
        using var client = new PortalApiClient(http);
        var result = await client.GetLocationWeatherAsync("CaseSensitive-KID");
        Assert.Equal("Address", result.PositionSource);
        Assert.NotNull(result.Current);
        Assert.Equal(12.5, result.Current.TemperatureCelsius);
        Assert.Null(result.Current.ApparentTemperatureCelsius);
        Assert.Null(result.Current.WindSpeedMetresPerSecond);
        Assert.Null(result.Current.PrecipitationMillimetres);
        Assert.Null(result.Current.RelativeHumidityPercent);
        Assert.Null(result.Current.WeatherCode);
        Assert.Null(result.Current.IsDay);
    }

    [Theory]
    [InlineData("LocationUnknown")]
    [InlineData("Unavailable")]
    public async Task UnavailableWeatherRemainsExplicitInsteadOfZero(string status)
    {
        using var http = Transport(new Handler((_, _) => Task.FromResult(Json("{\"locationKid\":\"CaseSensitive-KID\",\"status\":\"" + status + "\",\"address\":\"\",\"zip\":\"\",\"positionSource\":null,\"current\":null}"))));
        using var client = new PortalApiClient(http);
        var result = await client.GetLocationWeatherAsync("CaseSensitive-KID");
        Assert.Equal(status, result.Status);
        Assert.Null(result.PositionSource);
        Assert.Null(result.Current);
    }

    [Fact]
    public async Task StorageFailurePreservesErrorCodeWithoutRetrying()
    {
        var calls = 0;
        using var http = Transport(new Handler((_, _) =>
        {
            calls++;
            return Task.FromResult(Json("{\"code\":\"location-weather-unavailable\",\"private\":\"private-secret\"}", HttpStatusCode.ServiceUnavailable));
        }));
        using var client = new PortalApiClient(http);
        var error = await Assert.ThrowsAnyAsync<PortalApiException>(() => client.GetLocationWeatherAsync("CaseSensitive-KID"));
        Assert.Equal(503, error.StatusCode);
        Assert.Equal("location-weather-unavailable", error.Code);
        Assert.Equal(1, calls);
        Assert.DoesNotContain("private-secret", error.ToString());
    }

    private sealed class Handler(Func<HttpRequestMessage, CancellationToken, Task<HttpResponseMessage>> send) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            => send(request, cancellationToken);
    }
}
