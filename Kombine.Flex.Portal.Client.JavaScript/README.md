Version 0.17.0 adds seven Wallboard pairing/device operations (198 operations total). An active manager approves a screen once; its device approval has no automatic expiry. Keep the non-exportable ECDSA P-256 private key on the screen, sign one-use challenges to reconnect, and keep manager credentials and bearer tokens out of URLs and browser storage. Explicit revocation and manager credential/account checks remain enforced. Ten-day bearer sessions do not limit device approval. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog) and [Wallboard guide](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.16.0 adds the read-only settlement checklist, machine error history and acknowledgement, out-of-service listing and restore, and authorized eVaskeri resident delegation. Resident search includes bankKid. All operations retain manager, tenant and resource authorization. eVaskeri links are sensitive bearer credentials: open immediately without opener/referrer and never log or persist them. Never replay mutation requests automatically after an uncertain response. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog).

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

```javascript
const weather = await api.getLocationWeather(locationKid);
if (weather.status === "Available" && weather.current != null) {
  console.log(weather.current.temperatureCelsius);
}
```

## Camera1 · 0.8.0

Version 0.8.0 includes all 148 public operations, including Camera1. Call PrepareCameraCapture with the exact original SHA-256, length, UTC capture time, resource KID and sensor object, then upload the same bytes with its uploadToken. Live Photos also need the matching motion length/hash and original MOV companion. Keep the same token and bytes for a deliberate retry; no client retries automatically. Increase the request timeout for video processing. Camera1 and exact resource Read/Write permissions are enforced by the API. Listings can be degraded or contain empty pages with nextCursor; continue until the cursor is absent. Download content through the API; Range requests may return HTTP 206. See /docs#camera-captures for limits and errors.

```javascript
// uploadToken comes from prepareCameraCapture for the exact original Blob bytes.
const body = new FormData();
body.set("uploadToken", uploadToken);
body.set("original", originalBlob, "capture.jpg");
const saved = await api.saveCameraCapture(body, { signal });
```

Fetch creates the multipart Content-Type boundary. Add a `motion` Blob for Live Photos. File and text payloads together are limited to 139 MiB, reserving framing overhead under the API limit; text fields: 512 KiB each.

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

# Kombine Flex Portal — JavaScript client

`@kombine/flex-portal-client` supports **Node.js 22+ / modern browsers** and all **181 public API operations**. No runtime packages, .NET, NuGet or other Kombine libraries are required. It is ESM with compiled JavaScript and TypeScript declarations, requiring fetch, BigInt, Web Streams and ES2022. Business rules and authorization remain in the API.

The package is **not yet published to npm**. Install the supplied local distribution:

```sh
npm install ./kombine-flex-portal-client-0.13.0.tgz
```

Version 0.13.0 targets the current beta candidate (182 operations). Migrate response fields `icon`, `bankIcon` and `unitIcon` to `iconKid`, `bankIconKid` and `unitIconKid`. Use the explicit-set icon routes described in the [API changelog](/docs#changelog). The generated `RenewManagerSession` operation renews an unexpired manager session; assign its returned access token to the same client before further calls. There is no separate refresh token or automatic renewal. Windows application downloads return streams; these clients request complete files, without range or conditional headers.

Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits.

## Tenant, login and tabs

Select the tenant's HTTPS **API URL**, ending in `/`, before entering credentials. Obtain it from your administrator; for example https://api.team.kombine.technology/. Do not use the portal website. Use a separate client and login for each user, tenant and environment. Values in the following example come from your application input; never embed real passwords in source.

```js
import { PortalClient, PortalApiError } from '@kombine/flex-portal-client';

const api = new PortalClient(tenantApiUrl, { timeoutMs: 30_000 });
try {
  await api.login(email, password);
  const manager = await api.getCurrentManager();
  for (const tab of manager.tabDetails ?? []) console.log(tab.id, tab.name);
} catch (error) {
  if (error instanceof PortalApiError) console.error(error.status, error.code);
  else console.error('The API request could not be completed.');
} finally { api.clearSession(); }
```

`login()` stores the bearer in memory. Raw `loginManager(body)` does not retain a session; an existing token can be assigned to `accessToken`. Public operations never send it. No cookies or persistent token storage are used. `clearSession()`/`close()` remove the local token; HTTP 401 clears the affected session. The API has no separate refresh token or server-side token revocation. Passwords are not retained. Do not log tokens or complete payloads.

## Operations and data

Methods use operation IDs in camelCase; see [OPERATIONS.md](OPERATIONS.md). KIDs, cursors and revisions remain unchanged and case-sensitive. The client performs URL encoding and preserves wire query names such as Period and IncludeZero. Paging requires explicit calls; keep requesting until the cursor is absent. Balance batches accept up to 50 residents from one bank; use smaller batches on timeout. No automatic retries, hidden calls, extra privileges or automatic paging.

```ts
const page = await api.getBankUsers(bankKid, { pageSize: 25, sort: 'number', direction: 'asc' });
const balances = await api.getBankUserBalances(bankKid, { userKids });
const account = await api.getBankAccount(bankKid, { period: 0, includeZero: false, limit: 50 });
const units = await api.getLocationUnits(locationKid, { acceptLanguage: 'en-GB' });
const download = await api.exportBankUsers(bankKid);
try {
  for await (const chunk of download.chunks()) await destination.write(chunk);
} finally { await download.close(); }
```

Int64 fields are JavaScript bigint, including small values and expiresIn. Int32 is number; dates are ISO strings. Unknown JSON integer fields are also retained as bigint. Do not convert money to Number without checking its range. The client serializer sends bigint as JSON numbers; int64 request fields require bigint. For your own JSON output, explicitly choose a representation, for example `JSON.stringify(value, (_, v) => typeof v === 'bigint' ? v.toString() : v)`. Preserve null/missing values and keep currencies separate.

The default 30-second deadline covers the whole response, including downloads. Every operation accepts AbortSignal; use an AbortController to cancel. `close()` prevents new calls but does not cancel existing requests; use their signals. Downloads stream without buffering the entire file. `chunks()` is single-use; completion/break closes the stream. Close unused downloads too.

## Browsers and CORS

Use a bundler or copy the entire dist directory to your webserver and import ./dist/index.js from a script of type module. Do not open it through file://. The API Cors:AllowedOrigins must permit the page's exact origin. Browsers can only read CORS-exposed headers, so Retry-After/Content-Disposition may be inaccessible. Node.js does not require browser CORS. The client does not change the API's CORS configuration. CommonJS consumers can use dynamic import(); no separate CommonJS build is provided.

## Errors and transport

PortalApiError exposes status, code, headers (Headers) and raw response. Response may contain personal data; the exception text only contains HTTP status. 400: correct input. 401: sign in. 403: denied account/Tab/KID/operation access. 404: unavailable in current scope. 409: reload the revision before editing. 429/503: respect Retry-After and retry later; never automatically repeat mutations whose outcome may be unknown. Network/cancellation errors use fetch errors (network/CORS), AbortError/TimeoutError (cancellation/deadline). Invalid or oversized JSON raises PortalProtocolError.

HTTPS retains normal platform certificate validation. HTTP is allowed only on loopback for tests; redirects are refused. JSON defaults to 16 MiB (maxJsonBytes), nesting 64. Streaming downloads are not bounded by the JSON limit. Tabs do not grant unrestricted API access, and local numeric-ID developer login is excluded.

## Build and maintenance

```sh
pnpm install --frozen-lockfile
pnpm test
pnpm pack
```

Both script clients are generated from Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json with `python scripts/Generate-PortalScriptClients.py`; add `--check` to detect drift. The snapshot is a development input, not a runtime dependency. `scripts/Test-PortalScriptClients.ps1` tests both clients and builds wheel, sdist and npm tarball in artifacts/packages, using only local synthetic fixtures. TypeScript are development tools, not customer runtime dependencies. Nothing is published by these checks.

English is the primary documentation language; Danish and Spanish alternatives are included. Copyright Kombine Technology ApS.
