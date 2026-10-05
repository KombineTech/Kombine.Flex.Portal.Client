Version 0.4.2: GetLocations now requires fields=vismaCustNo,bankActivationCode,locationActivationCode to retain the previous optional values; accept null for unselected fields. Keep fields unchanged while paging and restart old cursors. New resident-number suggestions are read-only and do not reserve a number. Activation responses include qrCodeDataV1 and qrCodeDataV2 (five values with 30-bit noise/checksum); treat both as credentials. See /docs#changelog for migration and /docs for permissions and error handling.

ersion 0.4.2 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.

Version 0.3.3 uses the [official Kombine logo](https://static.kombine.services/kombinelogotext1/black.svg), preserved as logo.svg and rendered to icon.png for NuGet. API contracts and client behavior are unchanged.

Version 0.3.2 adds the official Kombine logo, publisher metadata and company contact information. API contracts and client behavior are unchanged.

Version 0.3.1 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.

Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 adds `GetUserReceipts` and `GetHostingMetrics` for API releases that expose these operations. Load receipts on demand: request offset 0, then use `nextOffset` with the same `revision`. On HTTP 409 (`receipts-changed`), discard earlier pages and restart at offset 0. Keep currencies separate and amounts as signed 64-bit minor units. See [receipts](/docs#user-receipts) and [hosting metrics](/docs#hosting) for permissions and limits.

<!-- api-contract-changelog -->
[API contract changelog](https://api.team.kombine.technology/docs#changelog)

Use the same tenant and environment as your client: append /docs#changelog to its API base URL. The link above uses Team as the public example. This log covers potentially breaking request/response changes to existing endpoints, not internal functional fixes.
<!-- /api-contract-changelog -->

# Kombine.Flex.Portal.Client

Typed .NET Standard 2.0 / .NET 8 / .NET 10 client for the Flex Portal public integration API. **No dependencies on other Kombine packages or projects**: no enums, KID, database, ORM, API-server or Web assemblies. Authentication, data access and business authorization run on the selected tenant's HTTPS API.

Version 0.4.2 targets the current API contract (110 operations). Migrate response fields `icon`, `bankIcon` and `unitIcon` to `iconKid`, `bankIconKid` and `unitIconKid`. Use the explicit-set icon routes described in the [API changelog](/docs#changelog). The generated `RenewManagerSession` operation renews an unexpired manager session; assign its returned access token to the same client before further calls. There is no separate refresh token or automatic renewal. Windows application downloads return streams; these clients request complete files, without range or conditional headers.

Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits.

## Compatibility and dependencies

One NuGet package contains all three targets; NuGet selects the appropriate DLL.

| Consumer | Selected client asset | Dependencies |
| --- | --- | --- |
| .NET Framework 4.7.2 / 4.8 / 4.8.1 | `netstandard2.0` | Microsoft `System.Text.Json` 10.0.12 and its Microsoft dependencies |
| .NET 8 / 9 | `net8.0` | No package dependencies |
| .NET 10 | `net10.0` | No package dependencies |

Framework 4.7.2 and 4.8 consumers are compiled against their respective reference assemblies and tested on the installed .NET Framework 4.8.1 runtime. .NET 8, 9 and 10 tests run on their corresponding runtimes. This does not claim testing on an original, unpatched 4.7.2 installation. Other .NET Standard-compatible runtimes, including older .NET Core/.NET versions, are not in the verified matrix. Microsoft's [compatibility guidance](https://learn.microsoft.com/en-us/dotnet/standard/net-standard) recommends Framework 4.7.2 or later for .NET Standard libraries.

NuGet must be able to restore Microsoft dependencies from nuget.org or your approved mirror. Framework applications using an injected `HttpClient` also need the framework `System.Net.Http` reference. Enable automatic binding redirects for Framework executables when required by their dependency graph. For customers without NuGet, or on Framework 2.0–4.5 or Windows CE/Mobile, use the existing separate Net20, Net45 or Compact20 DLL packages.

## First select the tenant API URL

Obtain the exact URL from your administrator: the API address, not the portal website. Production normally uses `https://api.{tenant}.kombine.technology/`; beta uses `https://beta.api.{tenant}.kombine.technology/`. Tenant and environment are fixed by the hostname. Never reuse a token on another endpoint.

```csharp
using Kombine.Flex.Portal.Client;

// Ask for the tenant API URL before credentials. The URL must end in '/'.
using (var api = new PortalApiClient(new Uri(tenantApiUrl)))
{
    var session = await api.LoginAsync(email, password, cancellationToken);
    var manager = await api.GetCurrentManagerAsync(cancellationToken);
    if (manager.TabDetails != null)
        foreach (var tab in manager.TabDetails)
            Console.WriteLine($"{tab.Id}: {tab.Name}");
    api.ClearSession();
}
```

`LoginAsync` wraps `LoginManagerAsync` and keeps the returned token in memory. Raw `LoginManagerAsync` only returns the response; assign its token to `api.AccessToken` yourself when using that method. `IPortalApiClient` exposes all generated operations. Every method accepts cancellation.

`ClearSession` and `Dispose` forget the token. The API has no separate refresh token or server-side logout/revocation operation. Removing a saved session does not invalidate another copy; expiry and API account checks still apply. Never log tokens, put them in URLs, decode them for authorization or persist them unencrypted. The client does not retain passwords.

## Operations and identifiers

The public and manager OpenAPI documents currently expose **110 operations**. Each has an `OperationIdAsync` method, typed requests/responses and XML IntelliSense documentation. See [OPERATIONS.md](OPERATIONS.md) for the complete list.

```csharp
var locations = await api.GetBankLocationsAsync(bankKid, cancellationToken);
var balances = await api.GetBankUserBalancesAsync(bankKid,
    body: new UserBalancesRequest { UserKids = residentKids },
    cancellationToken: cancellationToken);

using (var download = await api.DownloadBankSettlementAsync(bankKid, period,
    format: "zip", cancellationToken: cancellationToken))
using (var destination = File.Create("settlement.zip"))
    await download.Stream.CopyToAsync(destination, 81920, cancellationToken);
```

KIDs come from API responses: keep them opaque, unchanged and case-sensitive. Cursors and revisions are also opaque. Follow cursors until absent, even after an empty page. Balance batches accept 1–50 residents from one bank. Money is signed integer minor units; keep currencies separate. API permission, retention, paging, scope, revision and limit rules remain authoritative.

Public anonymous operations can run without login. Local-ID developer login and operator diagnostics are not public integrations and are excluded. This package grants no special privileges: manager account, tab, KID scope and operation permissions are checked by the API.

## Errors and transport

```csharp
try { var manager = await api.GetCurrentManagerAsync(cancellationToken); }
catch (PortalApiException error)
{
    Console.WriteLine($"HTTP {error.StatusCode}: {error.Code}");
}
```

* `400`: correct the input. `401`: sign in again. `403`: access denied.
* `404`: unavailable under the current scope. `409`: reload the resource/revision before editing.
* `429`: respect `Retry-After`. `503`: temporary unavailability; use bounded, user-controlled retries.
* `HttpRequestException`: connection/TLS failure. `OperationCanceledException`: cancellation or timeout.

There are **no automatic retries**, particularly for mutations: a lost response can leave their outcome unknown. Invalid success JSON is an error, not empty data. Typed errors expose `PortalApiException<T>.Result`; `Code` also reads streamed typed errors. `Response` contains raw text only when captured. Exception messages and `ToString()` exclude response content. Do not indiscriminately log response bodies, credentials or headers.

The URI constructor owns its transport, uses a 30-second timeout and disables cookies/redirects. It requires HTTPS with normal certificate validation. HTTP is allowed only on loopback for tests. Changing tenant requires a new client.

To configure timeouts/proxies, inject a dedicated `HttpClient` with a fixed `BaseAddress` ending in `/`. Configure its handler with redirects/cookies disabled and normal TLS validation. Do not set a shared default Authorization header. The injected transport remains caller-owned; the SDK sets authorization per request. Never forward a bearer to another tenant or an untrusted redirect.

## Build and regeneration

```powershell
dotnet pack Kombine.Flex.Portal.Client -c Release -o artifacts/packages
dotnet nuget add source <local-package-directory> --name flex-local
dotnet add package Kombine.Flex.Portal.Client --version 0.4.2
```

Production releases publish this package to [nuget.org](https://www.nuget.org/packages/Kombine.Flex.Portal.Client). After publication, install with `dotnet add package Kombine.Flex.Portal.Client --version 0.4.2 --source https://api.nuget.org/v3/index.json`. For a beta version not yet listed there, use the reviewed `.nupkg` from your API documentation in a local NuGet source as shown above. `OpenApi/portal.openapi.json` is the source snapshot. Run `pwsh -File scripts/Update-PortalClient.ps1` to regenerate; optionally add `-ApiBaseUrl https://localhost:7241/` to first refresh both public Swagger documents. Review the generated changes and run `scripts/Test-PortalClients.ps1` before packing. NSwag 14.7.1 is a pinned development tool, not a package dependency. Generated code is checked in: consumer builds need neither NSwag, a running API nor private feeds.

`scripts/Test-PortalClients.ps1` runs client and sample-app tests, builds the package and invokes `scripts/Test-PortalClientPackage.ps1`. The latter verifies all three package assets and dependency groups, then repeats the client contract/session/error tests in a separate NuGet-only consumer with a fresh package cache. No API/server projects or private package feeds are referenced; tests use synthetic data only.

## Publisher and support

![Kombine](https://raw.githubusercontent.com/KombineTech/Kombine.Flex.Portal.Client/5c87078b8a0b2439a4e68a0b432537d458dd31f4/Kombine.Flex.Portal.Client/icon.png)

**Kombine Technology ApS**  
Finlandsvej 61 st. th.  
DK-7100 Vejle, Denmark  
CVR: 44637928  
+45 76 43 70 20  
[support@kombinetech.com](mailto:support@kombinetech.com)  
[kombinetech.com](https://kombinetech.com/)

## Managed sessions — 0.4.2 (unreleased)

`SendRequestAsync` also supports downloads, streaming responses and operations added after the bundled generated contract. It checks that the request stays within the client's fixed API endpoint, preserves application headers and never retries. The caller owns the request and response. Pass `HttpCompletionOption.ResponseHeadersRead` for streaming. Application-specific response models may be used with this transport; permissions remain enforced by the API.

Keep one `PortalSession` per API endpoint and account/login. Clients created from it renew on use shortly before expiry; concurrent authentication is serialized. No background timer runs. Disposing a client does not log out the shared session; call `session.ClearSession()` to log out. Pending authentication cannot restore a cleared session. Do not log tokens or credentials.

Interactive applications call `Login`/`LoginAsync` once. Expired sessions require a new login. Web applications may `Restore` a trusted token and expiry from their protected cookie, call `Renew`/`RenewAsync` only after verified user activity, then update that cookie. Background status checks must use a separate anonymous client. Session renewal grants no additional API permissions.

Configured-account applications can pass a credential provider to `PortalSession`: `PortalCredentialsProvider` on legacy frameworks, or `Func<CancellationToken, Task<PortalCredentials>>` on modern .NET. It returns a new `PortalCredentials(email, password)` read from the application's current secure configuration only when login is needed. The library does not retain the returned password. No credentials provider is needed for interactive browser sessions.

Use `ExecuteRead`/`ExecuteReadAsync` only for explicitly side-effect-free callbacks: HTTP 401 invalidates the matching session and permits one new login and one retry when a provider exists. HTTP 403, 409, 429, 503, transport failures and timeouts are not retried. Ordinary client methods never automatically retry business operations, including writes. Without a provider, an expired/cleared session raises `InvalidOperationException`; an API rejection retains its `PortalApiException` status/code. Handle these by asking the user to log in again, never by looping indefinitely.

C# and VB.NET use the same DLL. The following interactive examples use caller-supplied credentials:

```csharp
using Kombine.Flex.Portal.Client;

async Task Example(Uri apiUrl, string email, string password)
{
    var session = new PortalSession(apiUrl);
    await session.LoginAsync(email, password);
    using (var api = await session.CreateClientAsync())
    {
        var profile = await api.GetCurrentManagerAsync();
        // Keep this client for later user actions; it renews on use.
    }
    session.ClearSession();
}
```

```vbnet
Imports Kombine.Flex.Portal.Client

Async Function Example(apiUrl As Uri, email As String, password As String) As Task
    Dim session = New PortalSession(apiUrl)
    Await session.LoginAsync(email, password)
    Using api = Await session.CreateClientAsync()
        Dim profile = Await api.GetCurrentManagerAsync()
        ' Keep this client for later user actions; it renews on use.
    End Using
    session.ClearSession()
End Function
```
