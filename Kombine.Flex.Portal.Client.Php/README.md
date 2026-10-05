Version 0.4.3: GetLocations now requires fields=vismaCustNo,bankActivationCode,locationActivationCode to retain the previous optional values; accept null for unselected fields. Keep fields unchanged while paging and restart old cursors. New resident-number suggestions are read-only and do not reserve a number. Activation responses include qrCodeDataV1 and qrCodeDataV2 (five values with 30-bit noise/checksum); treat both as credentials. See /docs#changelog for migration and /docs for permissions and error handling.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Kombine Flex Portal PHP client

[API contract changelog](https://api.team.kombine.technology/docs#changelog) — use `/docs#changelog` on the same tenant API and environment as your client. The changelog is English-only.

Version **0.4.3**, prepared locally; not deployed or published to Packagist. Covers 114 public operations from the included OpenAPI snapshot. Requires **64-bit PHP 8.2+**, `ext-curl`, `ext-json`, HTTPS support and trusted CA certificates. No external PHP library or internal Kombine assembly is required. Windows, Linux and macOS are supported by the transport; this version was tested on Windows CLI. Use a currently supported PHP release.

Version 0.3.1 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances. Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances. Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits. Version 0.2.5 adds GetUserReceipts and GetHostingMetrics for API releases that expose these operations. Load receipts on demand, starting at offset 0. Continue with nextOffset and the same revision; on HTTP 409 (receipts-changed), discard earlier pages and restart at offset 0. Keep currencies separate and minor-unit amounts as 64-bit integers. See /docs#user-receipts and /docs#hosting for permissions and limits.

For this beta candidate, migrate response fields icon/bankIcon/unitIcon to iconKid/bankIconKid/unitIconKid and use icon routes with an explicit set. See the API changelog for the removed paths. Application downloads return DownloadResponse and write bytes to the supplied stream.

## Install

Download `kombine-flex-portal-client-php-0.4.3.zip` from the API guide's PHP section. For Composer, save the ZIP under your application's `packages/` directory, then run:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-portal-client:0.4.3
```

Composer's artifact repository requires `ext-zip` during installation. For installation without Composer, extract the ZIP into `flex-portal-client/` and replace the autoload line below with `require __DIR__ . '/flex-portal-client/autoload.php';`. Keep the entire `src/` directory, including `contract.json`. Both packages can be loaded together.

## Login and first request

Use a manager email and password for the tenant Portal API. Provide the variables below from your application's protected configuration or login form. The tenant API URL must end with `/`.

```php
<?php
declare(strict_types=1);
require __DIR__ . '/vendor/autoload.php';

use Kombine\Flex\Portal\PortalClient;
use Kombine\Flex\Portal\ApiException;
use Kombine\Flex\Portal\ProtocolException;
use Kombine\Flex\Portal\TransportException;

$api = new PortalClient($tenantUrl, timeout: 30);
try {
    $session = $api->login($email, $password);
    $result = $api->getCurrentManager();
} catch (ApiException $error) {
    $status = $error->status;
    $code = $error->apiCode;
    $retryAfter = $error->headers['retry-after'] ?? null;
    // Handle according to the table below; do not blindly repeat writes.
} catch (TransportException | ProtocolException $error) {
    // Timeout, network failure, malformed data or response limit.
    // A write may already have completed: check state before repeating it.
} finally {
    $api->close();
}
```

`login()` retains the bearer in memory; the raw `loginManager($body)` operation only returns it. `setAccessToken($token)` and `getAccessToken()` support reusing a session in protected server-side storage. Never share a client between users or tenants. `clearSession()` and `close()` discard the local token; existing copies keep their server expiry. Credentials are not retained. Anonymous operations omit the token. HTTP 401 clears it, including malformed/oversized error responses. `renew()` explicitly calls RenewManagerSession and stores the replacement token. Raw `renewManagerSession()` only returns the response. Renew while the bearer is unexpired, based on user activity; after expiry or revocation, log in again. There is no separate refresh token.

## Methods and values

See [OPERATIONS.md](OPERATIONS.md) for every stable operation ID and PHP method, and [MODELS.md](MODELS.md) for array shapes. Parameters in `$options` use the exact documented wire names and case. Request/response objects are associative arrays; lists are indexed arrays. An empty request array becomes a JSON object where the schema requires an object. Dates, KIDs, cursors and revisions remain strings; do not reconstruct or reinterpret them. Integers, including MS2000 and money in minor units, are native 64-bit PHP `int`. Floating-point, quoted or out-of-range values in known integer fields are rejected. Preserve absent and `null` values; neither means zero.

Paging is explicit: keep the returned cursor and continue until it is absent, including after an empty page. Keep revision tokens for writes. Use a temporary file for downloads and rename it only after success.

```php
$page = $api->getBankUsers($bankKid, ['pageSize' => 25, 'sort' => 'number']);
$balances = $api->getBankUserBalances($bankKid, ['userKids' => $userKids]);
$receipts = $api->getUserReceipts($userKid, ['offset' => 0]);
// Request the next page only when needed, using nextOffset and the same revision.
$stream = fopen($temporaryPath, 'w+b');
try {
    $download = $api->exportBankUsers($bankKid, $stream);
} finally {
    fclose($stream);
}
rename($temporaryPath, $completedPath);
```

## Errors, permissions and limits

| Result | Handling |
| --- | --- |
| 400 | Correct the request using the API error code. |
| 401 | The session is cleared; sign in again. |
| 403 | Check the account's API permissions; retrying does not grant access. |
| 404 / 409 | Reload the object or revision and resolve missing data/conflicts. |
| 429 | Respect `Retry-After`; avoid synchronized retry loops. |
| 5xx | Surface temporary failure and apply deliberate backoff only where safe. |

The client does not retry, page, renew or acknowledge automatically. Every business call still requires the manager’s account state, permitted Tab, KID scope and operation permission. A KID itself grants no access. The fixed tenant URL cannot be changed after construction. Redirects and cookies are disabled. TLS certificates are always verified; HTTP is accepted only for explicit loopback development URLs. Server-side PHP calls do not need browser CORS.

The default total request deadline is 30 seconds, connect timeout at most 10 seconds, JSON request/response limit 16 MiB, headers 64 KiB, and each download 1 GiB. Set `timeout`, `maxJsonBytes` and `maxDownloadBytes` in the constructor as needed. Downloads stream into a caller-owned writable resource; the client leaves it open. On error, discard partial files. No resumable downloads or concurrent/shared-client use is provided. Headers in results/exceptions use lowercase names. Do not log credentials, tokens, full payloads or sensitive response headers. Protect your PHP application's session cookies and state-changing forms with CSRF protection.

## Build and verification

Repository maintainers: `scripts/Update-PhpClients.ps1` exports current controller metadata without starting API workers or touching a database, then generates PHP. `scripts/Test-PhpClients.ps1` verifies generation, exercises all operations against loopback fixtures, creates deterministic ZIPs, tests the extracted packages and copies only the PHP downloads into both APIs. Existing clients retain their own release snapshots. There is no registry publication or deployment step.
