using System.Net.Http.Headers;

namespace Kombine.Flex.Portal.Client;

public partial class PortalApiClient
{
    /// <summary>Sends an endpoint-bound HTTP request, including downloads/streams and newer API operations. Does not retry. Caller owns the request and response.</summary>
    /// <remarks>Preserves explicit per-request headers. An unmanaged client token must agree with an explicit Authorization header. Managed sessions supply the current bearer token on each use. Never mutates shared HttpClient headers.</remarks>
    public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request,
        HttpCompletionOption completionOption = HttpCompletionOption.ResponseContentRead, CancellationToken cancellationToken = default)
    {
        if (request is null) throw new ArgumentNullException(nameof(request));
        if (request.RequestUri is null) throw new ArgumentException("A request URI is required.", nameof(request));
        var uri = new Uri(Endpoint, request.RequestUri);
        if (_httpClient.BaseAddress != Endpoint || !Endpoint.IsBaseOf(uri) || uri.UserInfo.Length != 0 || uri.Fragment.Length != 0)
            throw new InvalidOperationException("The API endpoint cannot change.");
        if (_managedSession is null && AccessToken is { } token)
        {
            if (request.Headers.Authorization is { } header && (header.Scheme != "Bearer" || header.Parameter != token))
                throw new InvalidOperationException("The request belongs to another session.");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var managedSession = _managedSession;
        if (managedSession is not null)
        {
            var sessionToken = await managedSession.GetTokenAsync(cancellationToken).ConfigureAwait(false);
            if (!ReferenceEquals(managedSession, _managedSession)) throw new OperationCanceledException("The client session changed.");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", sessionToken.AccessToken);
            Volatile.Write(ref _accessToken, sessionToken.AccessToken);
        }
        request.Headers.CacheControl = new CacheControlHeaderValue { NoStore = true };
        return await _httpClient.SendAsync(request, completionOption, cancellationToken).ConfigureAwait(false);
    }
}
