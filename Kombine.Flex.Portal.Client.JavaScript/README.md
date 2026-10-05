Version 0.4.3: GetLocations now requires fields=vismaCustNo,bankActivationCode,locationActivationCode to retain the previous optional values; accept null for unselected fields. Keep fields unchanged while paging and restart old cursors. New resident-number suggestions are read-only and do not reserve a number. Activation responses include qrCodeDataV1 and qrCodeDataV2 (five values with 30-bit noise/checksum); treat both as credentials. See /docs#changelog for migration and /docs for permissions and error handling.

ersion 0.4.3 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.

Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 adds `GetUserReceipts` and `GetHostingMetrics` for API releases that expose these operations. Load receipts on demand: request offset 0, then use `nextOffset` with the same `revision`. On HTTP 409 (`receipts-changed`), discard earlier pages and restart at offset 0. Keep currencies separate and amounts as signed 64-bit minor units. See [receipts](/docs#user-receipts) and [hosting metrics](/docs#hosting) for permissions and limits.

<!-- api-contract-changelog -->
[API contract changelog](https://api.team.kombine.technology/docs#changelog)

Use the same tenant and environment as your client: append /docs#changelog to its API base URL. The link above uses Team as the public example. This log covers potentially breaking request/response changes to existing endpoints, not internal functional fixes.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — JavaScript client

`@kombine/flex-portal-client` supports **Node.js 22+ / modern browsers** and all **110 public API operations**. No runtime packages, .NET, NuGet or other Kombine libraries are required. It is ESM with compiled JavaScript and TypeScript declarations, requiring fetch, BigInt, Web Streams and ES2022. Business rules and authorization remain in the API.

The package is **not yet published to npm**. Install the supplied local distribution:

```sh
npm install ./kombine-flex-portal-client-0.4.3.tgz
```

Version 0.4.3 targets the current beta candidate (110 operations). Migrate response fields `icon`, `bankIcon` and `unitIcon` to `iconKid`, `bankIconKid` and `unitIconKid`. Use the explicit-set icon routes described in the [API changelog](/docs#changelog). The generated `RenewManagerSession` operation renews an unexpired manager session; assign its returned access token to the same client before further calls. There is no separate refresh token or automatic renewal. Windows application downloads return streams; these clients request complete files, without range or conditional headers.

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
