# Kombine Flex Portal Dart-klient

Version **0.2.0** dækker **178 operationer** fra den medfølgende OpenAPI-kontrakt. Pak ZIP-filen ud ved siden af dit projekt, tilføj nedenstående sti i `pubspec.yaml`, og kør `dart pub get` eller `flutter pub get`. Eksemplets legitimationsoplysninger leveres af din applikation.

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

Objekter er maps med API'ets præcise feltnavne, ikke klasser med typede felter. int64-værdier er altid `BigInt`, int32 er `int`, og datoer er ISO-strenge. Brug `encodeApiJson` og `decodeApiJson` ved egen JSON-behandling. Null og udeladte felter bevares særskilt. Se [operationsoversigten](OPERATIONS.md).

`login` gemmer bearer-tokenet. `clearSession()` fjerner det. Rå login- og fornyelsesmetoder gemmer ikke tokenet automatisk; anvend svaret bevidst. Sen login kan ikke genskabe en ryddet session. Serveren kontrollerer altid tenant, identitet og rettigheder.

Fang `ApiException`, og læs `status`, `code` og `headers`. HTTP 400 kræver rettet input, 401 nyt login, 403 rettigheder, 404 en gyldig ressource og 409 konflikthåndtering. Ved 429/503 følges serverens Retry-After efter behov. Gentag aldrig automatisk en mutation med ukendt resultat. Log ikke legitimationsoplysninger eller følsomme svar.

Standardfristen er 30 sekunder inklusive streaming; JSON-grænsen er 8 MiB. Begge kan konfigureres. Alle metoder accepterer `cancel: completer.future`. Afbrydelse giver `ApiCancelledException`, tidsudløb `TimeoutException` og ugyldige data `ApiProtocolException`. Afslut med `client.close()`; en indsprøjtet HTTP-klient ejes fortsat af kaldende kode.

Binære svar leveres som `ApiDownload`: læs `chunks` én gang, og luk i en finally-blok. Multipart bruger `ApiUploadFile` med en frisk stream-fabrik og korrekt længde. HTTPS kræves bortset fra lokal loopback. Der er ingen automatisk gentagelse eller redirect. Flutter Web kræver serverens CORS-tilladelse og buffer uploads i browsertransporten. Native uploads kan streames. Dart 3.6.2 og 3.13.6 samt JavaScript-talpræcision er testet; Flutter på enheder er ikke afprøvet.

Generering, test og pakning beskrives i [den engelske guide](README.md). ZIP-pakken indeholder kode, kontrakt, tests og alle tre sprog. Pakning offentliggør eller deployer ikke noget. HTTP 202 ved kameraoptagelse betyder accepteret. Kontrollér resultatet via ConfirmCameraCapture; klienten poller ikke automatisk.

[API-guide](https://api.team.kombine.technology/docs/da) · [Kontraktændringer, engelsk](https://api.team.kombine.technology/docs#changelog) · [English](README.md) · [Español](README.es.md)
