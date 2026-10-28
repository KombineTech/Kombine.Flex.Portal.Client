Version 0.15.0 uses GetPublicCycleWidget and GetCycleChartPresentation. Replace the retired WashDoc widget/presentation routes with /api/v1/public/widgets/cycle and /api/v1/public/cycle-chart/presentation. Document path parameters and table/graph/widget fields use cycleKid; the widget display field is cycleKidText. Existing KID values and document operation IDs remain valid. Rebuild callers and update property bindings. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.14.0 synchronizes personal language, date/time, number and line-spacing preferences. WashDoc widgets replace unitKidText with documentKidText; graphSvg may be null when no measurements exist. Treat refreshAfterSeconds=0 as stop polling; running documents use 15 seconds. Manager sessions last ten days: use the returned expiresIn and renew only after activity. UserBalance remains compatible. See the [API changelog](/docs#changelog).

Version 0.13.0 moves ConvertToolTime and InspectToolKid to /api/v1/tenant/tools/time and /api/v1/tenant/tools/kid. Remove the bankKid argument when rebuilding callers; the site selects the tenant. Active manager, More1, Bank Read and a resource grant in the site tenant remain required. JSON bodies and responses are unchanged. GetUnitDocumentNeighbors adds authorized same-unit document navigation. See the [API changelog](/docs#changelog).

## Location reservation calendars · 0.13.0

`GetLocationBookingCalendars` returns dated calendars with opening hours applied by the API. Pass optional from=yyyy-MM-dd and days=1-31 (default 14); responses include timeZone, from, days and a date on each day. Render these dates directly; fetch another range when navigating instead of repeating weeks or merging opening hours in the client. Groups contain authorized units and Configured status; malformed stored calendars are omitted. Slot startMinute is 0-1439, durationMinutes is positive and their sum is at most 1440. Type 0 is reservation time, 1 chance, 2 closed and 3 unknown opening hours. Show unknown periods as unavailable, never bookable. Requires Bookings1, Location Read, Unit Read and matching scope. Show each machine separately. This is configuration, not occupancy or booking availability. Handle 400/401/403/404/503 explicitly. See [reservation calendars](/docs#location-booking-calendars) and the [changelog](/docs#changelog).

Version 0.13.0 covers 182 operations. SaveCameraCapture accepts optional background processing; HTTP 202 only acknowledges temporary staging. Retain the original bytes and upload token, then call ConfirmCameraCapture until confirmed is true. processingPercent is an estimate and may be null; errorCode can indicate failure. After a host restart, retry with the same original bytes and ticket when publication is unconfirmed. Rebuild callers against the updated SaveCameraCapture signatures and use named arguments where available. The default synchronous API behavior remains unchanged. See /docs#camera-captures and /docs#changelog.

Version 0.13.0 includes GetCameraNearestLocation for GPS-based location capture and GetRecentCameraPhotoMetadata for authenticated thumbnail information. Camera resources include proximity-check and nullable location coordinates. New capture filenames are opaque GUIDs; never parse region or original names from filenames. Location selection requires Camera1 and Location Read/Write; metadata requires resource Read. Handle unavailable GPS and 404/409 by choosing the location manually. See /docs#camera-captures and /docs#changelog.

## Recent camera photos · 0.13.0

Adds `GetPublicRecentCameraPhotos` and `GetPublicCameraThumbnail`. These public operations need no login and are bound to the site tenant. The list returns at most ten photos, with short-lived thumbnail URLs and portal workspace paths. Thumbnails are public; originals and metadata remain protected. Opening a workspace requires normal manager permissions. Handle 503 when the complete list is unavailable and 400/404 for invalid, expired or missing thumbnails. See [public widgets](/docs#public-widgets).

## Location weather · 0.13.0

Version 0.13.0 exposes all 182 operations, including `GetLocationWeather` for a canonical location KID. Reuse the manager session. The API requires the assigned Tab, Bank Read, Location Read, matching scope and visible location/parent bank. It resolves stored coordinates or the location address; clients never supply provider keys or coordinates. Check `status`: `Available` has `current`; `LocationUnknown` or `Unavailable` has no measurements. Unknown values are null, never zero. Temperature is Celsius, wind m/s, precipitation mm and humidity percent; times are UTC. Address-based positions may be approximate. Display attribution: Weather data by Open-Meteo, CC BY 4.0. Handle HTTP 400/401/403/404/503 normally and retry only deliberately; provider failure may also return HTTP 200 with `Unavailable`. See [location weather](/docs#location-weather).

```csharp
LocationWeatherResponse weather = api.GetLocationWeather(locationKid);
if (weather.Status == "Available" && weather.Current != null)
    Console.WriteLine(weather.Current.TemperatureCelsius);
```

```vbnet
Dim weather As LocationWeatherResponse = api.GetLocationWeather(locationKid)
If weather.Status = "Available" AndAlso weather.Current IsNot Nothing Then
    Console.WriteLine(weather.Current.TemperatureCelsius)
End If
```

## Camera1 · 0.8.0

Version 0.8.0 includes all 148 public operations, including Camera1. Call PrepareCameraCapture with the exact original SHA-256, length, UTC capture time, resource KID and sensor object, then upload the same bytes with its uploadToken. Live Photos also need the matching motion length/hash and original MOV companion. Keep the same token and bytes for a deliberate retry; no client retries automatically. Increase the request timeout for video processing. Camera1 and exact resource Read/Write permissions are enforced by the API. Listings can be degraded or contain empty pages with nextCursor; continue until the cursor is absent. Download content through the API; Range requests may return HTTP 206. See /docs#camera-captures for limits and errors.

```csharp
// uploadToken comes from PrepareCameraCapture; originalPath points to those exact bytes.
using (System.IO.FileStream original = System.IO.File.OpenRead(originalPath))
{
    PortalMultipart body = new PortalMultipart();
    body.AddField("uploadToken", uploadToken);
    body.AddFile("original", System.IO.Path.GetFileName(originalPath), original);
    CameraSaveResponse saved = api.SaveCameraCapture(body);
}
```

```vbnet
' uploadToken comes from PrepareCameraCapture; originalPath contains the same bytes.
Using original As System.IO.FileStream = System.IO.File.OpenRead(originalPath)
    Dim body As New PortalMultipart()
    body.AddField("uploadToken", uploadToken)
    body.AddFile("original", System.IO.Path.GetFileName(originalPath), original)
    Dim saved As CameraSaveResponse = api.SaveCameraCapture(body)
End Using
```

Streams remain caller-owned. Use seekable streams, rewind and create a new multipart body before retrying. For Live Photos, add a second file named `motion`. Maximum multipart body: 140 MiB; text fields: 512 KiB each.

All manager role changes require Read and Write on both Tabs and Kids. Handle missing-tabs-read, missing-tabs-write, missing-kids-read and missing-kids-write (HTTP 403).

GetTerminals uses the reported ComputerName for name, filtering and sorting; missing names are empty. Request fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight for terminal telemetry. Values are strings, null when not selected, and empty when missing. Keep fields unchanged during paging and restart old cursors. Location names remain part of every row. See /docs#changelog for all migration requirements.

Version 0.8.0 targets 148 API operations. GetUnits adds the authorized unit directory: keep filters and fields unchanged while paging and restart after invalid-cursor. Manager role requests require all nine expectedFlags categories, including Tabs and Kids; handle their independent read/write permissions and 403 responses. Service access assignments are removed; stop sending assignment requests and reading the access object. Logo part selectors are path segments before the color, not query parameters. UserBalance remains compatible. See /docs#changelog for migration and /docs#unit-directory for paging and examples.

Version 0.8.0: GetLocations now requires fields=vismaCustNo,bankActivationCode,locationActivationCode to retain the previous optional values; accept null for unselected fields. Keep fields unchanged while paging and restart old cursors. New resident-number suggestions are read-only and do not reserve a number. Activation responses include qrCodeDataV1 and qrCodeDataV2 (five values with 30-bit noise/checksum); treat both as credentials. See /docs#changelog for migration and /docs for permissions and error handling.

Version 0.8.0 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.

Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 adds `GetUserReceipts` and `GetHostingMetrics` for API releases that expose these operations. Load receipts on demand: request offset 0, then use `nextOffset` with the same `revision`. On HTTP 409 (`receipts-changed`), discard earlier pages and restart at offset 0. Keep currencies separate and amounts as signed 64-bit minor units. See [receipts](/docs#user-receipts) and [hosting metrics](/docs#hosting) for permissions and limits.

<!-- api-contract-changelog -->
[API contract changelog](https://api.team.kombine.technology/docs#changelog)

Use the same tenant and environment as your client: append /docs#changelog to its API base URL. The link above uses Team as the public example. This log covers potentially breaking request/response changes to existing endpoints, not internal functional fixes.
<!-- /api-contract-changelog -->

# Flex Portal client for .NET Framework 2.0

`Kombine.Flex.Portal.Client.Net20` provides typed, synchronous methods for all **181 public integration operations**. No NuGet, other Kombine libraries, database access, KID calculation or business rules are required. Authorization remains in the API. See [OPERATIONS.md](OPERATIONS.md).

Version 0.13.0 targets the current beta candidate (182 operations). Migrate response fields `icon`, `bankIcon` and `unitIcon` to `iconKid`, `bankIconKid` and `unitIconKid`. Use the explicit-set icon routes described in the [API changelog](/docs#changelog). The generated `RenewManagerSession` operation renews an unexpired manager session; assign its returned access token to the same client before further calls. There is no separate refresh token or automatic renewal. Windows application downloads return streams; these clients request complete files, without range or conditional headers.

Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits.

## Install without NuGet

1. Extract `Kombine.Flex.Portal.Client.Net20.0.13.0.zip`.
2. Choose **Add Reference → Browse → Kombine.Flex.Portal.Client.Net20.dll** in your application.
3. Keep the XML file beside the DLL for IntelliSense and distribute the DLL with your app.
4. Source code and `Kombine.Flex.Portal.Client.2008.sln` are in `Source`.

The DLL references only mscorlib and System 2.0. This is a separate classic project, not .NET Standard or an SDK-style project.

## Select the tenant API URL, then log in

Obtain the **API URL**, not the portal website, from your administrator. It must end in `/`, for example `https://api.team.kombine.technology/`. Select the tenant before entering credentials. Create a new client and log in again when changing tenant/environment; never reuse another tenant's token.

Place using/Imports directives at the top of the file and the remaining code inside a method. Input variables (tenantApiUrl, credentials and KIDs) come from your application. The examples use the same DLL in both languages.

**C#**

```csharp
using System;
using Kombine.Flex.Portal.Client.Net20;

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
Imports Kombine.Flex.Portal.Client.Net20

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

.NET 2.0 compatibility does not mean an original, unpatched Windows/.NET 2.0 installation supports modern HTTPS. An updated CLR 2.0 is supplied by the .NET Framework 3.5 Windows component on newer Windows. `EnableTls12()` throws if the runtime does not support its value. See the [CLR 2.0/.NET 3.5 TLS update](https://support.microsoft.com/en-us/topic/support-for-tls-system-default-versions-included-in-the-net-framework-3-5-on-windows-8-1-and-windows-server-2012-r2-499ff5ef-a88a-128b-c639-ed038b7d2d5f).

## Build and checks

Use Visual Studio 2008 or the original MSBuild 3.5 tools. The project uses C# 2.0 syntax and TargetFrameworkVersion=v2.0. Extract to a short path such as C:\Flex20 because the old tools have the classic Windows path-length limit. The standalone test EXE needs no test-framework packages and uses synthetic responses/local HTTP fixtures. Its optional `--status https://localhost:7241/` checks anonymous HTTPS status with TLS 1.2 and no login.

Verified with MSBuild 3.5 and CLR 2.0.50727. The VS2008 IDE and a customer's particular Windows installation were not tested. No real customer login is part of these tests.

In the development repository, `scripts/Test-PortalClientNet20.ps1` builds, tests and creates the ZIP. PowerShell 7 is a developer tool, not a customer/device requirement. `scripts/Generate-PortalClientNet20.py` regenerates checked-in contracts from the shared OpenAPI snapshot; customers do not need Python, a generator or a running API to build/use the DLL. Documentation is primarily English, with Danish and Spanish alternatives included in the package.

## Managed sessions — 0.13.0 (unreleased)

Keep one `PortalSession` per API endpoint and account/login. Clients created from it renew on use shortly before expiry; concurrent authentication is serialized. No background timer runs. Disposing a client does not log out the shared session; call `session.ClearSession()` to log out. Pending authentication cannot restore a cleared session. Do not log tokens or credentials.

Interactive applications call `Login`/`LoginAsync` once. Expired sessions require a new login. Web applications may `Restore` a trusted token and expiry from their protected cookie, call `Renew`/`RenewAsync` only after verified user activity, then update that cookie. Background status checks must use a separate anonymous client. Session renewal grants no additional API permissions.

Configured-account applications can pass a credential provider to `PortalSession`: `PortalCredentialsProvider` on legacy frameworks, or `Func<CancellationToken, Task<PortalCredentials>>` on modern .NET. It returns a new `PortalCredentials(email, password)` read from the application's current secure configuration only when login is needed. The library does not retain the returned password. No credentials provider is needed for interactive browser sessions.

Use `ExecuteRead`/`ExecuteReadAsync` only for explicitly side-effect-free callbacks: HTTP 401 invalidates the matching session and permits one new login and one retry when a provider exists. HTTP 403, 409, 429, 503, transport failures and timeouts are not retried. Ordinary client methods never automatically retry business operations, including writes. Without a provider, an expired/cleared session raises `InvalidOperationException`; an API rejection retains its `PortalApiException` status/code. Handle these by asking the user to log in again, never by looping indefinitely.

C# and VB.NET use the same DLL. The following interactive examples use caller-supplied credentials:

```csharp
using Kombine.Flex.Portal.Client.Net20;

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
Imports Kombine.Flex.Portal.Client.Net20

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
