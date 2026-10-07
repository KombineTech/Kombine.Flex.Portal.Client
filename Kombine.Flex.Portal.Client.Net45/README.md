Version 0.4.4: GetLocations now requires fields=vismaCustNo,bankActivationCode,locationActivationCode to retain the previous optional values; accept null for unselected fields. Keep fields unchanged while paging and restart old cursors. New resident-number suggestions are read-only and do not reserve a number. Activation responses include qrCodeDataV1 and qrCodeDataV2 (five values with 30-bit noise/checksum); treat both as credentials. See /docs#changelog for migration and /docs for permissions and error handling.

ersion 0.4.4 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.

Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 adds `GetUserReceipts` and `GetHostingMetrics` for API releases that expose these operations. Load receipts on demand: request offset 0, then use `nextOffset` with the same `revision`. On HTTP 409 (`receipts-changed`), discard earlier pages and restart at offset 0. Keep currencies separate and amounts as signed 64-bit minor units. See [receipts](/docs#user-receipts) and [hosting metrics](/docs#hosting) for permissions and limits.

<!-- api-contract-changelog -->
[API contract changelog](https://api.team.kombine.technology/docs#changelog)

Use the same tenant and environment as your client: append /docs#changelog to its API base URL. The link above uses Team as the public example. This log covers potentially breaking request/response changes to existing endpoints, not internal functional fixes.
<!-- /api-contract-changelog -->

# Flex Portal client for .NET Framework 4.5

`Kombine.Flex.Portal.Client.Net45` provides typed, synchronous methods for all **110 public integration operations**. No NuGet, other Kombine libraries, database access, KID calculation or business rules are required. Authorization remains in the API. See [OPERATIONS.md](OPERATIONS.md).

Version 0.4.4 targets the current beta candidate (110 operations). Migrate response fields `icon`, `bankIcon` and `unitIcon` to `iconKid`, `bankIconKid` and `unitIconKid`. Use the explicit-set icon routes described in the [API changelog](/docs#changelog). The generated `RenewManagerSession` operation renews an unexpired manager session; assign its returned access token to the same client before further calls. There is no separate refresh token or automatic renewal. Windows application downloads return streams; these clients request complete files, without range or conditional headers.

Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits.

## Install without NuGet

1. Extract `Kombine.Flex.Portal.Client.Net45.0.4.4.zip`.
2. Choose **Add Reference → Browse → Kombine.Flex.Portal.Client.Net45.dll** in your application.
3. Keep the XML file beside the DLL for IntelliSense and distribute the DLL with your app.
4. Source code and `Kombine.Flex.Portal.Client.2012.sln` are in `Source`.

The DLL references only mscorlib and System 4.5. This is a separate classic project, not .NET Standard or an SDK-style project.

## Select the tenant API URL, then log in

Obtain the **API URL**, not the portal website, from your administrator. It must end in `/`, for example `https://api.team.kombine.technology/`. Select the tenant before entering credentials. Create a new client and log in again when changing tenant/environment; never reuse another tenant's token.

Place using/Imports directives at the top of the file and the remaining code inside a method. Input variables (tenantApiUrl, credentials and KIDs) come from your application. The examples use the same DLL in both languages.

**C#**

```csharp
using System;
using Kombine.Flex.Portal.Client.Net45;

using (PortalApiClient api = new PortalApiClient(new Uri(tenantApiUrl)))
{
    ManagerSessionResponse session = api.Login(email, password);
    ManagerProfileResponse manager = api.GetCurrentManager();
    Console.WriteLine(manager.Name);
    if (manager.TabDetails != null)
    {
        foreach (ManagerTabResponse tab in manager.TabDetails)
            Console.WriteLine("{0}: {1}", tab.Id, tab.Name);
    }
    api.ClearSession();
}
```

**VB.NET**

```vbnet
Imports System
Imports Kombine.Flex.Portal.Client.Net45

Using api As New PortalApiClient(New Uri(tenantApiUrl))
    Dim session As ManagerSessionResponse = api.Login(email, password)
    Dim manager As ManagerProfileResponse = api.GetCurrentManager()
    Console.WriteLine(manager.Name)
    If manager.TabDetails IsNot Nothing Then
        For Each tab As ManagerTabResponse In manager.TabDetails
            Console.WriteLine("{0}: {1}", tab.Id, tab.Name)
        Next
    End If
    api.ClearSession()
End Using
```

`Login` keeps the token in memory. Raw `LoginManager(request)` only returns a response: assign `api.AccessToken = response.AccessToken` yourself when using it. Passwords are not retained. `ClearSession`/`Dispose` remove the local token; an in-progress login cannot restore a cleared session. The API has no separate refresh token or server-side logout/revocation operation; other token copies remain subject to expiry/account checks. Never log passwords or tokens. Local-ID developer login and diagnostics are excluded.

## Data, paging and downloads

Method names match operation IDs without Async. Optional filters/headers are in each operation's Options class; null uses the API default. For example:

**C#**

```csharp
GetBankUsersOptions options = new GetBankUsersOptions();
options.PageSize = 25;
options.Sort = "number";
BankUsersResponse page = api.GetBankUsers(bankKid, options);

UserBalancesRequest request = new UserBalancesRequest();
request.UserKids = new string[] { residentKid1, residentKid2 };
UserBalancesResponse balances = api.GetBankUserBalances(bankKid, request);
```

**VB.NET**

```vbnet
Dim options As New GetBankUsersOptions()
options.PageSize = 25
options.Sort = "number"
Dim page As BankUsersResponse = api.GetBankUsers(bankKid, options)

Dim request As New UserBalancesRequest()
request.UserKids = New String() {residentKid1, residentKid2}
Dim balances As UserBalancesResponse = api.GetBankUserBalances(bankKid, request)
```

- Preserve case-sensitive KIDs, cursors and revisions unchanged. Continue paging until no cursor remains, including after an empty page.
- Balances are nullable Int64 minor units; null is not zero and currencies must stay separate. The API accepts 1–50 residents from one bank per balance batch.
- Dates/timestamps remain ISO 8601 strings with offsets and precision. Date filters use yyyy-MM-dd. Enum identities are integers; no enum package is needed. Unknown extra response fields are ignored.
- Calls block: use a worker thread in graphical apps and marshal UI updates to the UI thread. There is no Task/async cancellation; Dispose prevents new calls but does not cancel an existing call.
- JSON defaults to **16 MiB**, configurable through MaxJsonResponseBytes. This is not the total RAM requirement: bytes, text and objects consume additional memory.
- Exports return PortalDownload. Copy Stream in small blocks and always dispose the download; files are streamed rather than fully buffered. `TimeoutMilliseconds` controls request and stream I/O timeouts, normally 30 seconds; this is not an overall deadline for a long download.

## Errors

PortalApiException exposes StatusCode, Code, Headers and raw Response. Message/ToString exclude response content; raw responses may contain personal data. Handle 400 by correcting input, 401 by logging in, 403 as denied access, 404 as unavailable in the current scope, 409 by reloading the revision, and 429/503 by respecting Retry-After and waiting. WebException/I/O failures cover network, TLS, timeouts and stream failures. InvalidDataException reports invalid or oversized JSON. 

No automatic retries are performed. A lost mutation response can leave the outcome unknown. Cookies and redirects are disabled; the client does not automatically send Windows credentials. Account, Tab, KID, retention and operation rules remain enforced by the API.

## HTTPS compatibility

The host Windows/runtime must support the server's TLS/cipher suites and trust its certificate. On a supported installation the host application may call `PortalApiClient.EnableTls12()` before its first HTTPS request. This changes `ServicePointManager.SecurityProtocol` for the **entire process**; the library never changes it automatically. It does not change the registry or certificates. There is no insecure fallback; HTTP is allowed only on loopback for tests. See [Microsoft's TLS guidance](https://learn.microsoft.com/en-us/dotnet/framework/network-programming/tls).

## Build and checks

Use Visual Studio 2012 with the .NET 4.5 targeting kit. The classic MSBuild 4.0 project has no PackageReference or reference to another client. Run the standalone test EXE from tests/Kombine.Flex.Portal.Client.Net45.Tests/bin/Release.

The developer script obtains Microsoft's reference-assembly package 1.0.3 only if the targeting kit is missing; it is not shipped or required at runtime. Verified against .NET 4.5 reference assemblies, with 454 synthetic checks and an anonymous local HTTPS status request. Execution used the installed newer CLR 4 runtime; an original .NET 4.5 machine and the VS2012 IDE were not tested.

In the development repository, `scripts/Test-PortalClientNet45.ps1` builds, tests and creates the ZIP. PowerShell 7 is a developer tool, not a customer/device requirement. `scripts/Generate-PortalClientNet20.py --net45` regenerates checked-in contracts from the shared OpenAPI snapshot; customers do not need Python, a generator or a running API to build/use the DLL. Documentation is primarily English, with Danish and Spanish alternatives included in the package.

## Managed sessions — 0.4.4 (unreleased)

Keep one `PortalSession` per API endpoint and account/login. Clients created from it renew on use shortly before expiry; concurrent authentication is serialized. No background timer runs. Disposing a client does not log out the shared session; call `session.ClearSession()` to log out. Pending authentication cannot restore a cleared session. Do not log tokens or credentials.

Interactive applications call `Login`/`LoginAsync` once. Expired sessions require a new login. Web applications may `Restore` a trusted token and expiry from their protected cookie, call `Renew`/`RenewAsync` only after verified user activity, then update that cookie. Background status checks must use a separate anonymous client. Session renewal grants no additional API permissions.

Configured-account applications can pass a credential provider to `PortalSession`: `PortalCredentialsProvider` on legacy frameworks, or `Func<CancellationToken, Task<PortalCredentials>>` on modern .NET. It returns a new `PortalCredentials(email, password)` read from the application's current secure configuration only when login is needed. The library does not retain the returned password. No credentials provider is needed for interactive browser sessions.

Use `ExecuteRead`/`ExecuteReadAsync` only for explicitly side-effect-free callbacks: HTTP 401 invalidates the matching session and permits one new login and one retry when a provider exists. HTTP 403, 409, 429, 503, transport failures and timeouts are not retried. Ordinary client methods never automatically retry business operations, including writes. Without a provider, an expired/cleared session raises `InvalidOperationException`; an API rejection retains its `PortalApiException` status/code. Handle these by asking the user to log in again, never by looping indefinitely.

C# and VB.NET use the same DLL. The following interactive examples use caller-supplied credentials:

```csharp
using Kombine.Flex.Portal.Client.Net45;

void Example(Uri apiUrl, string email, string password)
{
    PortalSession session = new PortalSession(apiUrl);
    session.Login(email, password);
    using (PortalApiClient api = session.CreateClient())
    {
        ManagerProfileResponse profile = api.GetCurrentManager();
        // Keep this client for later user actions; it renews on use.
    }
    session.ClearSession();
}
```

```vbnet
Imports Kombine.Flex.Portal.Client.Net45

Sub Example(ByVal apiUrl As Uri, ByVal email As String, ByVal password As String)
    Dim session As New PortalSession(apiUrl)
    session.Login(email, password)
    Using api As PortalApiClient = session.CreateClient()
        Dim profile As ManagerProfileResponse = api.GetCurrentManager()
        ' Keep this client for later user actions; it renews on use.
    End Using
    session.ClearSession()
End Sub
```
