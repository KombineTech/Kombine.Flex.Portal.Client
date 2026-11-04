Version 0.27.0 indeholder beskyttede widgets til administratoraktivitet og driftsbelastning.

Version 0.20.0 tilføjer autoriserede Plex-operationer; Plex er ikke offentligt tilgængelig.

Version 0.19.0 opdaterer widgettypen med Plex (52); serveren bestemmer separat, hvilke typer der er tilgængelige.

Version 0.18.0 indeholder GetPublicReservedMachines og omfatter 221 operationer. Enum indeholder værdierne 47–51; serveren aktiverer kun implementerede widgettyper.

Version 0.15.0 bruger separate lyse og mørke c-paletter i Wallboard-layouts; konvertér flade c-arrays før gemning. Klienten omfatter 220 operationer. Se API-changelog.

Version 0.14.0 synkroniserer 217 API-operationer med Wallboards 60 gange 60-model: ordnede skærm-id’er og rektangel-arrays erstatter de tidligere enkelt-id’er og koordinatfelter. Personlige og offentlige Portal-wallboards gemmes separat med rettigheds- og revisionskontrol. Nye operationer giver adgang til offentlige layouts og de beskyttede lager-, belastnings-, kort- og reservationsvisninger. Bevar gemt geometri, og genindlæs efter konflikter før et nyt forsøg. UserBalance er fortsat kompatibel.

Version 0.14.0 indeholder 217 operationer, herunder GetUnitTimeline og GetUnitTimelineFields. Wallboard-svar identificerer den præcise godkendte skærm; skærmsessioner viser kun minimal identitet uden normale administratorrettigheder. Brug et normalt administratorlogin til Portal-operationer. Permanent enhedsgodkendelse og UserBalance er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.8.0 tilføjer FindWallboardPairings og GetWallboardDevice (200 operationer i alt) samt valgfri lokationsmetadata ved skærmgodkendelse. Den samlede Wallboard-opsætning bruger én QR-skanning; privat lokation er kun tilgængelig for den godkendende administrator via enheds-endpointet. Enhedsgodkendelsen udløber ikke automatisk og kontrollerer fortsat tilbagekaldelse, administratoroplysninger samt tenant og miljø. Eksisterende UserBalance-klienter er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.7.0 tilføjer syv operationer til Wallboard-godkendelse og enheder (198 i alt). En aktiv administrator godkender skærmen én gang; enhedens godkendelse udløber ikke automatisk. Behold den ikke-eksporterbare private ECDSA P-256-nøgle på skærmen, underskriv engangsudfordringer ved genforbindelse, og hold administratoroplysninger og bearer-tokens ude af URL’er og browserlager. Tilbagekaldelse og kontrol af administratorens konto og legitimationsoplysninger bevares. Sessionsvarigheden på ti dage begrænser ikke enhedsgodkendelsen. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.6.0 tilføjer afregningschecklisten med læseadgang, maskinfejlhistorik og kvittering, visning og genåbning af maskiner ude af drift samt autoriseret adgang til beboerens eVaskeri. Beboersøgning inkluderer bankKid. Alle operationer bevarer administrator-, tenant- og ressourcekontrol. eVaskeri-links er følsomme adgangsoplysninger: åbn straks uden opener/referrer, og gem eller log dem aldrig. Gentag aldrig ændringskald automatisk efter et usikkert svar. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.5.0 bruger GetPublicCycleWidget og GetCycleChartPresentation. Erstat de udgåede WashDoc-widget-/præsentationsruter med /api/v1/public/widgets/cycle og /api/v1/public/cycle-chart/presentation. Dokumenternes stiparametre og tabel-/graf-/widgetfelter bruger cycleKid; widgettens visningsfelt hedder cycleKidText. Eksisterende KID-værdier og dokumentoperationernes ID er bevaret. Genbyg klienterne, og opdater feltbindingerne. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.4.0 synkroniserer personlige valg af sprog, dato/tid, talformat og linjeafstand. WashDoc-widgets erstatter unitKidText med documentKidText; graphSvg kan være null uden målinger. Stop polling ved refreshAfterSeconds=0; igangværende dokumenter bruger 15 sekunder. Administratorsessioner varer ti dage: brug svarets expiresIn og forny kun efter aktivitet. UserBalance er fortsat kompatibel. Se [API-changelog](/docs#changelog).

Version 0.3.0 flytter ConvertToolTime og InspectToolKid til /api/v1/tenant/tools/time og /api/v1/tenant/tools/kid. Fjern bankKid-argumentet ved genbygning; sitet vælger tenant. Aktiv manager, More1, Bank Read og et ressourcegrant i sitets tenant kræves fortsat. JSON-input og -svar er uændrede. GetUnitDocumentNeighbors giver autoriseret dokumentnavigation for samme enhed. Se [API-changelog](/docs#changelog).

# Kombine Flex Portal Dart-klient

Version **0.27.0** dækker **233 operationer** fra den medfølgende OpenAPI-kontrakt. Pak ZIP-filen ud ved siden af dit projekt, tilføj nedenstående sti i `pubspec.yaml`, og kør `dart pub get` eller `flutter pub get`. Eksemplets legitimationsoplysninger leveres af din applikation.

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
