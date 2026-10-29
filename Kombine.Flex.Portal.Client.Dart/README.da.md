Version 0.8.0 tilføjer FindWallboardPairings og GetWallboardDevice (200 operationer i alt) samt valgfri lokationsmetadata ved skærmgodkendelse. Den samlede Wallboard-opsætning bruger én QR-skanning; privat lokation er kun tilgængelig for den godkendende administrator via enheds-endpointet. Enhedsgodkendelsen udløber ikke automatisk og kontrollerer fortsat tilbagekaldelse, administratoroplysninger samt tenant og miljø. Eksisterende UserBalance-klienter er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.7.0 tilføjer syv operationer til Wallboard-godkendelse og enheder (198 i alt). En aktiv administrator godkender skærmen én gang; enhedens godkendelse udløber ikke automatisk. Behold den ikke-eksporterbare private ECDSA P-256-nøgle på skærmen, underskriv engangsudfordringer ved genforbindelse, og hold administratoroplysninger og bearer-tokens ude af URL’er og browserlager. Tilbagekaldelse og kontrol af administratorens konto og legitimationsoplysninger bevares. Sessionsvarigheden på ti dage begrænser ikke enhedsgodkendelsen. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.6.0 tilføjer afregningschecklisten med læseadgang, maskinfejlhistorik og kvittering, visning og genåbning af maskiner ude af drift samt autoriseret adgang til beboerens eVaskeri. Beboersøgning inkluderer bankKid. Alle operationer bevarer administrator-, tenant- og ressourcekontrol. eVaskeri-links er følsomme adgangsoplysninger: åbn straks uden opener/referrer, og gem eller log dem aldrig. Gentag aldrig ændringskald automatisk efter et usikkert svar. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.5.0 bruger GetPublicCycleWidget og GetCycleChartPresentation. Erstat de udgåede WashDoc-widget-/præsentationsruter med /api/v1/public/widgets/cycle og /api/v1/public/cycle-chart/presentation. Dokumenternes stiparametre og tabel-/graf-/widgetfelter bruger cycleKid; widgettens visningsfelt hedder cycleKidText. Eksisterende KID-værdier og dokumentoperationernes ID er bevaret. Genbyg klienterne, og opdater feltbindingerne. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.4.0 synkroniserer personlige valg af sprog, dato/tid, talformat og linjeafstand. WashDoc-widgets erstatter unitKidText med documentKidText; graphSvg kan være null uden målinger. Stop polling ved refreshAfterSeconds=0; igangværende dokumenter bruger 15 sekunder. Administratorsessioner varer ti dage: brug svarets expiresIn og forny kun efter aktivitet. UserBalance er fortsat kompatibel. Se [API-changelog](/docs#changelog).

Version 0.3.0 flytter ConvertToolTime og InspectToolKid til /api/v1/tenant/tools/time og /api/v1/tenant/tools/kid. Fjern bankKid-argumentet ved genbygning; sitet vælger tenant. Aktiv manager, More1, Bank Read og et ressourcegrant i sitets tenant kræves fortsat. JSON-input og -svar er uændrede. GetUnitDocumentNeighbors giver autoriseret dokumentnavigation for samme enhed. Se [API-changelog](/docs#changelog).

# Kombine Flex Portal Dart-klient

Version **0.8.0** dÃ¦kker **182 operationer** fra den medfÃ¸lgende OpenAPI-kontrakt. Pak ZIP-filen ud ved siden af dit projekt, tilfÃ¸j nedenstÃ¥ende sti i `pubspec.yaml`, og kÃ¸r `dart pub get` eller `flutter pub get`. Eksemplets legitimationsoplysninger leveres af din applikation.

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

Objekter er maps med API'ets prÃ¦cise feltnavne, ikke klasser med typede felter. int64-vÃ¦rdier er altid `BigInt`, int32 er `int`, og datoer er ISO-strenge. Brug `encodeApiJson` og `decodeApiJson` ved egen JSON-behandling. Null og udeladte felter bevares sÃ¦rskilt. Se [operationsoversigten](OPERATIONS.md).

`login` gemmer bearer-tokenet. `clearSession()` fjerner det. RÃ¥ login- og fornyelsesmetoder gemmer ikke tokenet automatisk; anvend svaret bevidst. Sen login kan ikke genskabe en ryddet session. Serveren kontrollerer altid tenant, identitet og rettigheder.

Fang `ApiException`, og lÃ¦s `status`, `code` og `headers`. HTTP 400 krÃ¦ver rettet input, 401 nyt login, 403 rettigheder, 404 en gyldig ressource og 409 konflikthÃ¥ndtering. Ved 429/503 fÃ¸lges serverens Retry-After efter behov. Gentag aldrig automatisk en mutation med ukendt resultat. Log ikke legitimationsoplysninger eller fÃ¸lsomme svar.

Standardfristen er 30 sekunder inklusive streaming; JSON-grÃ¦nsen er 8 MiB. Begge kan konfigureres. Alle metoder accepterer `cancel: completer.future`. Afbrydelse giver `ApiCancelledException`, tidsudlÃ¸b `TimeoutException` og ugyldige data `ApiProtocolException`. Afslut med `client.close()`; en indsprÃ¸jtet HTTP-klient ejes fortsat af kaldende kode.

BinÃ¦re svar leveres som `ApiDownload`: lÃ¦s `chunks` Ã©n gang, og luk i en finally-blok. Multipart bruger `ApiUploadFile` med en frisk stream-fabrik og korrekt lÃ¦ngde. HTTPS krÃ¦ves bortset fra lokal loopback. Der er ingen automatisk gentagelse eller redirect. Flutter Web krÃ¦ver serverens CORS-tilladelse og buffer uploads i browsertransporten. Native uploads kan streames. Dart 3.6.2 og 3.13.6 samt JavaScript-talprÃ¦cision er testet; Flutter pÃ¥ enheder er ikke afprÃ¸vet.

Generering, test og pakning beskrives i [den engelske guide](README.md). ZIP-pakken indeholder kode, kontrakt, tests og alle tre sprog. Pakning offentliggÃ¸r eller deployer ikke noget. HTTP 202 ved kameraoptagelse betyder accepteret. KontrollÃ©r resultatet via ConfirmCameraCapture; klienten poller ikke automatisk.

[API-guide](https://api.team.kombine.technology/docs/da) Â· [KontraktÃ¦ndringer, engelsk](https://api.team.kombine.technology/docs#changelog) Â· [English](README.md) Â· [EspaÃ±ol](README.es.md)
