Version 0.5.0 uses GetPublicCycleWidget and GetCycleChartPresentation. Replace the retired WashDoc widget/presentation routes with /api/v1/public/widgets/cycle and /api/v1/public/cycle-chart/presentation. Document path parameters and table/graph/widget fields use cycleKid; the widget display field is cycleKidText. Existing KID values and document operation IDs remain valid. Rebuild callers and update property bindings. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.4.0 synchronizes personal language, date/time, number and line-spacing preferences. WashDoc widgets replace unitKidText with documentKidText; graphSvg may be null when no measurements exist. Treat refreshAfterSeconds=0 as stop polling; running documents use 15 seconds. Manager sessions last ten days: use the returned expiresIn and renew only after activity. UserBalance remains compatible. See the [API changelog](/docs#changelog).

Version 0.3.0 moves ConvertToolTime and InspectToolKid to /api/v1/tenant/tools/time and /api/v1/tenant/tools/kid. Remove the bankKid argument when rebuilding callers; the site selects the tenant. Active manager, More1, Bank Read and a resource grant in the site tenant remain required. JSON bodies and responses are unchanged. GetUnitDocumentNeighbors adds authorized same-unit document navigation. See the [API changelog](/docs#changelog).

# Kombine Flex Portal Dart client

Extract the supplied source ZIP next to your application, add the path dependency below and run `dart pub get` (or `flutter pub get`). Credential variables in the example come from your application.

```yaml
dependencies:
  kombine_flex_portal_client:
    path: ../Kombine.Flex.Portal.Client.Dart
```

```dart
import 'package:kombine_flex_portal_client/kombine_flex_portal_client.dart';

final client = PortalClient('https://api.team.kombine.technology/');
try {
  await client.login({'email': email, 'password': password});
  final result = await client.getBanks();
  print(result); // Synthetic examples only: do not log personal data.
} finally {
  client.close();
}
```
## Contract and runtime

Version **0.5.0** contains **182 named operations**. See [OPERATIONS.md](OPERATIONS.md) and the bundled `OpenApi` snapshot for the exact contract; this package does not discover new server operations at runtime. Object models are wire-map typedefs (`Map<String, Object?>`), not field-typed classes. Keep JSON field names and KIDs unchanged. Server authorization, tenant binding and resource permissions always apply.

Dart SDK >=3.6.0 <4.0.0 is required. Tests cover Dart 3.6.2 and 3.13.6, including JavaScript compilation and 64-bit precision; Flutter device execution has not been tested. Runtime dependencies are `http` and `http_parser`. No private Kombine runtime dependency is required.

All OpenAPI int64 fields use **BigInt**, including small values; int32 uses `int`. Dates remain ISO strings. Use exported `encodeApiJson` / `decodeApiJson` to round-trip wire JSON, including BigInt. Do not use `jsonEncode` on BigInt. Absent fields and explicit null stay distinct. Unknown response fields remain available. Declared fields are checked for wire types and integer bounds.

## Sessions, errors and cancellation

`login` clears the old session and retains the returned bearer token. `clearSession()` removes it. Late login responses cannot restore a cleared or replaced session. Raw generated login and renewal methods return responses without changing the stored token; apply a renewal deliberately with `client.accessToken = response['accessToken'] as String`. There is no automatic renewal. A current authenticated request's HTTP 401 clears its token; an old request cannot clear a replacement token.

Catch `ApiException` and inspect `status`, `code`, `headers` and, when safe, `responseBody`. Its `toString()` excludes response bodies. Handle HTTP 400 (invalid request), 401 (session), 403 (permission), 404 (missing resource), 409 (conflict), 429 (rate limit) and 503 (unavailable) according to the operation contract. Respect `Retry-After` manually. Never automatically repeat an uncertain mutation. Avoid logging credentials, bearer tokens or response bodies.

Clients default to a 30-second absolute deadline, including streamed response consumption, and an 8 MiB JSON limit. Configure `timeout` / `maxJsonBytes` in the constructor. Every generated method accepts `cancel: completer.future`; complete it to abort. Cancellation throws `ApiCancelledException`, deadlines throw `TimeoutException`, malformed wire data throws `ApiProtocolException`. `close()` aborts active calls and closes owned transports. An injected `httpClient` remains owned by the caller.

HTTPS is required except literal loopback HTTP for tests. Redirects and automatic retries are disabled. The client cannot bypass server CORS or permissions. On Flutter Web, package:http's [BrowserClient](https://pub.dev/documentation/http/latest/browser_client/BrowserClient-class.html) streams responses but buffers request uploads; native transports can stream uploads. Browser redirect rejection can surface as a transport error.

## Files

Where the API declares a binary response, consume `ApiDownload.chunks` once, or call `await download.close()` to release an unread response. Keep `close()` in a `finally` block around consumption. A deadline also applies while the stream is idle.

Where an operation declares multipart input, use `ApiUploadFile(() => source.openRead(), length, 'photo.jpg', contentType: 'image/jpeg')` as its file field. The factory must return fresh bytes of exactly the declared length; invalid metadata and unexpected fields are rejected. File access is supplied by the application, so the library does not import `dart:io`.

## Validation and packaging

Run from the public client repository root:

```powershell
python scripts/Generate-PortalDartClient.py --check
pwsh -NoProfile -File scripts/Test-PortalDartClient.ps1
python scripts/Build-PortalDartPackage.py
```

The source ZIP includes this guide, Danish/Spanish alternatives, contract, library, examples and synthetic tests. Build output is `artifacts/packages/Kombine.Flex.Portal.Client.Dart.0.3.0.zip` with a SHA-256 manifest. A changed archive requires a new package version; identical rebuilds are deterministic. These commands do not publish or deploy anything.

[API integration guide](https://api.team.kombine.technology/docs) Â· [API contract changelog](https://api.team.kombine.technology/docs#changelog) Â· [English](README.md) Â· [Dansk](README.da.md) Â· [EspaÃ±ol](README.es.md)

Camera capture HTTP 202 means accepted, not completed. Follow the returned capture identity and call ConfirmCameraCapture deliberately as documented; no polling or mutation retry is automatic. This initial Dart source package has not been published to pub.dev or installed on a server.
