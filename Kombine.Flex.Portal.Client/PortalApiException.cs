using System.Text.Json;

namespace Kombine.Flex.Portal.Client;

/// <summary>API error with status, headers and response details. Message and ToString do not expose the body.</summary>
public class PortalApiException : Exception
{
    /// <summary>Creates an error from an unsuccessful API response.</summary>
    public PortalApiException(string message, int statusCode, string? response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers, Exception? innerException)
        : base($"Portal API request failed (HTTP {statusCode}).", innerException)
    { StatusCode = statusCode; Response = response; Headers = headers; }

    /// <summary>HTTP status. In particular: 401 login required, 403 forbidden, 409 conflict, 429 throttled, 503 unavailable.</summary>
    public int StatusCode { get; }
    /// <summary>Raw body when captured; streamed typed errors instead expose Result. May contain sensitive information.</summary>
    public string? Response { get; }
    /// <summary>Response headers, including Retry-After when the server supplies it.</summary>
    public IReadOnlyDictionary<string, IEnumerable<string>> Headers { get; }
    /// <summary>The API's language-independent error code, when supplied.</summary>
    public virtual string? Code
    {
        get
        {
            try
            {
                using var document = JsonDocument.Parse(Response ?? "{}");
                return document.RootElement.ValueKind == JsonValueKind.Object && document.RootElement.TryGetProperty("code", out var code) && code.ValueKind == JsonValueKind.String ? code.GetString() : null;
            }
            catch (JsonException) { return null; }
        }
    }

    /// <summary>Returns a safe diagnostic that excludes server body and request credentials.</summary>
    public override string ToString() => $"{GetType().Name}: {Message}";
}

/// <summary>API error with its typed error response.</summary>
public sealed class PortalApiException<TResult> : PortalApiException
{
    /// <summary>Creates a typed API error.</summary>
    public PortalApiException(string message, int statusCode, string? response,
        IReadOnlyDictionary<string, IEnumerable<string>> headers, TResult result, Exception? innerException)
        : base(message, statusCode, response, headers, innerException) => Result = result;
    /// <summary>Typed server error data. Availability depends on the operation's documented response schema.</summary>
    public TResult Result { get; }

    /// <summary>The API error code, including typed errors read directly from the response stream.</summary>
    public override string? Code
    {
        get
        {
            if (base.Code is { } code) return code;
            var result = JsonSerializer.SerializeToElement(Result);
            return result.ValueKind == JsonValueKind.Object && result.TryGetProperty("code", out var value) && value.ValueKind == JsonValueKind.String ? value.GetString() : null;
        }
    }
}
