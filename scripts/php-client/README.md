[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Kombine Flex __API__ PHP client

[API contract changelog](__ORIGIN__/docs#changelog) — use `/docs#changelog` on the same tenant API and environment as your client. The changelog is English-only.

Version **0.1.0**, prepared locally; not deployed or published to Packagist. Covers __COUNT__ public operations from the included OpenAPI snapshot. Requires **64-bit PHP 8.2+**, `ext-curl`, `ext-json`, HTTPS support and trusted CA certificates. No external PHP library or internal Kombine assembly is required. Windows, Linux and macOS are supported by the transport; this version was tested on Windows CLI. Use a currently supported PHP release.

## Install

Download `__ZIP__` from the API guide's PHP section. For Composer, save the ZIP under your application's `packages/` directory, then run:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-__LOWER__-client:0.1.0
```

Composer's artifact repository requires `ext-zip` during installation. For installation without Composer, extract the ZIP into `flex-__LOWER__-client/` and replace the autoload line below with `require __DIR__ . '/flex-__LOWER__-client/autoload.php';`. Keep the entire `src/` directory, including `contract.json`. Both packages can be loaded together.

## Login and first request

__AUTH__ Provide the variables below from your application's protected configuration or login form. The tenant API URL must end with `/`.

```php
<?php
declare(strict_types=1);
require __DIR__ . '/vendor/autoload.php';

use Kombine\Flex\__API__\__API__Client;
use Kombine\Flex\__API__\ApiException;
use Kombine\Flex\__API__\ProtocolException;
use Kombine\Flex\__API__\TransportException;

$api = new __API__Client($tenantUrl, timeout: 30);
try {
    $session = $api->login(__LOGIN__);
    $result = $api->__FIRST__();
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

`login()` retains the bearer in memory; the raw `__RAWLOGIN__($body)` operation only returns it. `setAccessToken($token)` and `getAccessToken()` support reusing a session in protected server-side storage. Never share a client between users or tenants. `clearSession()` and `close()` discard the local token; existing copies keep their server expiry. Credentials are not retained. Anonymous operations omit the token. HTTP 401 clears it, including malformed/oversized error responses. __SESSION__

## Methods and values

See [OPERATIONS.md](OPERATIONS.md) for every stable operation ID and PHP method, and [MODELS.md](MODELS.md) for array shapes. Parameters in `$options` use the exact documented wire names and case. Request/response objects are associative arrays; lists are indexed arrays. An empty request array becomes a JSON object where the schema requires an object. Dates, KIDs, cursors and revisions remain strings; do not reconstruct or reinterpret them. Integers, including MS2000 and money in minor units, are native 64-bit PHP `int`. Floating-point, quoted or out-of-range values in known integer fields are rejected. Preserve absent and `null` values; neither means zero.

__DETAILS__

## Errors, permissions and limits

| Result | Handling |
| --- | --- |
| 400 | Correct the request using the API error code. |
| 401 | The session is cleared; sign in again. |
| 403 | Check the account's API permissions; retrying does not grant access. |
| 404 / 409 | Reload the object or revision and resolve missing data/conflicts. |
| 429 | Respect `Retry-After`; avoid synchronized retry loops. |
| 5xx | Surface temporary failure and apply deliberate backoff only where safe. |

The client does not retry, page, renew or acknowledge automatically. __PERMISSIONS__ The fixed tenant URL cannot be changed after construction. Redirects and cookies are disabled. TLS certificates are always verified; HTTP is accepted only for explicit loopback development URLs. Server-side PHP calls do not need browser CORS.

The default total request deadline is 30 seconds, connect timeout at most 10 seconds, JSON request/response limit 16 MiB, headers 64 KiB, and each download 1 GiB. Set `timeout`, `maxJsonBytes` and `maxDownloadBytes` in the constructor as needed. Downloads stream into a caller-owned writable resource; the client leaves it open. On error, discard partial files. No resumable downloads or concurrent/shared-client use is provided. Headers in results/exceptions use lowercase names. Do not log credentials, tokens, full payloads or sensitive response headers. Protect your PHP application's session cookies and state-changing forms with CSRF protection.

## Build and verification

Repository maintainers: `scripts/Update-PhpClients.ps1` exports current controller metadata without starting API workers or touching a database, then generates PHP. `scripts/Test-PhpClients.ps1` verifies generation, exercises all operations against loopback fixtures, creates deterministic ZIPs, tests the extracted packages and copies only the PHP downloads into both APIs. Existing clients retain their own release snapshots. There is no registry publication or deployment step.


GetTerminals uses the reported ComputerName for name, filtering and sorting; missing names are empty. Request fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight for terminal telemetry. Values are strings, null when not selected, and empty when missing. Keep fields unchanged during paging and restart old cursors. Location names remain part of every row. See /docs#changelog for all migration requirements.
