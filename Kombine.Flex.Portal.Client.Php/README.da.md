## Lokationens reservationskalendere · 0.20.1

`GetLocationBookingCalendars` returnerer daterede kalendere med åbningstider anvendt af API’et. Angiv valgfrit from=yyyy-MM-dd og days=1-31 (standard 14); svaret indeholder timeZone, from, days og date for hver dag. Vis datoerne direkte og hent et nyt interval ved navigation uden at gentage uger eller kombinere åbningstider i klienten. Grupper har autoriserede enheder og status Configured; ugyldige gemte kalendere udelades. startMinute er 0-1439, durationMinutes er positiv, og summen er højst 1440. Type 0 er reservationstid, 1 chance, 2 lukket og 3 ukendt åbningstid. Ukendt må ikke vises som reserverbart. Kræver Bookings1, Lokation Læs, Enhed Læs og korrekt ressourceadgang. Vis hver maskine separat. Dette er opsætning, ikke aktuelle reservationer eller ledighed. Håndter 400/401/403/404/503 eksplicit. Se [reservationskalendere](/docs#location-booking-calendars) og [changelog](/docs#changelog).

## Lokationens vejr · 0.20.1

Version 0.20.1 omfatter alle 206 operationer og indeholder `GetLocationWeather` til et kanonisk lokations-KID. Genbrug administratorsessionen. API’et kræver tildelt Tab, Bank Læs, Lokation Læs, matchende adgangsområde samt synlig lokation og bank. Den bruger gemte koordinater eller lokationens adresse; klienten sender aldrig udbydernøgler eller koordinater. Kontrollér `status`: `Available` har `current`; `LocationUnknown` og `Unavailable` har ingen målinger. Ukendte værdier er null, aldrig nul. Temperatur er Celsius, vind m/s, nedbør mm og fugtighed procent; tidspunkter er UTC. Adressebaseret position kan være omtrentlig. Vis kildeangivelsen: Weather data by Open-Meteo, CC BY 4.0. Håndter HTTP 400/401/403/404/503 normalt, og gentag kun bevidst; udbyderfejl kan også give HTTP 200 med `Unavailable`. Se [lokationens vejr](/docs#location-weather).

```php
$weather = $api->getLocationWeather($locationKid);
if (($weather["status"] ?? null) === "Available" && ($weather["current"] ?? null) !== null) {
    echo $weather["current"]["temperatureCelsius"];
}
```

Version 0.4.3: GetLocations kræver nu fields=vismaCustNo,bankActivationCode,locationActivationCode for at bevare de tidligere valgfrie værdier; accepter null for fravalgte felter. Behold samme fields under sideskift, og start gamle cursors forfra. Nye forslag til beboernumre er skrivebeskyttede og reserverer ikke et nummer. Aktiveringssvar indeholder qrCodeDataV1 og qrCodeDataV2 (fem værdier med 30-bit støj/kontrolsum); behandl begge som legitimationsoplysninger. Se /docs#changelog for migrering og /docs for rettigheder og fejlhåndtering.

Version 0.8.0 indeholder alle 148 offentlige operationer, inklusive Camera1. Kald PrepareCameraCapture med originalens præcise SHA-256, længde, UTC-optagelsestid, ressource-KID og sensorobjekt. Upload derefter de samme bytes med uploadToken. Live Photos kræver også matchende længde/hash og den oprindelige MOV-fil. Behold samme token og bytes ved et bevidst genforsøg; klienten gentager aldrig automatisk. Forøg tidsfristen ved videobehandling. API’et kontrollerer Camera1 og præcise Read/Write-rettigheder til ressourcen. Lister kan være ufuldstændige eller have tomme sider med nextCursor; fortsæt, indtil cursor mangler. Hent medier gennem API’et; Range-kald kan give HTTP 206. Se /docs#camera-captures for grænser og fejl.

```php
// $uploadToken comes from prepareCameraCapture for these exact original bytes.
$saved = $api->saveCameraCapture([
    'uploadToken' => $uploadToken,
    'original' => new \CURLFile($originalPath, 'application/octet-stream', 'capture.jpg'),
]);
```

Add a `motion` CURLFile for Live Photos. Only readable local files are accepted; cURL streams them. Payloads together are limited to 139 MiB plus framing; text fields: 512 KiB each.


Version 0.20.1 indeholder GetCameraNearestLocation til GPS-baseret lokationsvalg og GetRecentCameraPhotoMetadata til beskyttet billedinformation. Kameraressourcer indeholder afstandskontrol og nullable lokationskoordinater. Nye filnavne er uigennemsigtige GUID’er; udled ikke region eller oprindeligt navn. Lokationsvalg kræver Camera1 og Location Læs/Skriv; metadata kræver ressourcens Læs. Ved manglende GPS og 404/409 vælges lokationen manuelt. Se /docs#camera-captures og /docs#changelog.

Version 0.20.1 omfatter 206 operationer. SaveCameraCapture understøtter valgfri baggrundsbehandling; HTTP 202 bekræfter kun midlertidig lagring. Behold originalfiler og uploadtoken, og kald ConfirmCameraCapture, indtil confirmed er true. processingPercent er et skøn og kan være null; errorCode kan angive fejl. Efter genstart af værten gentages upload med de samme originalfiler og token, hvis publicering ikke er bekræftet. Genbyg kald mod de opdaterede SaveCameraCapture-signaturer, og brug navngivne argumenter, hvor det er muligt. API-standardens synkrone adfærd er uændret. Se /docs#camera-captures og /docs#changelog.

Version 0.20.1 indeholder 206 operationer, herunder GetUnitTimeline og GetUnitTimelineFields. Wallboard-svar identificerer den præcise godkendte skærm; skærmsessioner viser kun minimal identitet uden normale administratorrettigheder. Brug et normalt administratorlogin til Portal-operationer. Permanent enhedsgodkendelse og UserBalance er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.18.0 tilføjer FindWallboardPairings og GetWallboardDevice (206 operationer i alt) samt valgfri lokationsmetadata ved skærmgodkendelse. Den samlede Wallboard-opsætning bruger én QR-skanning; privat lokation er kun tilgængelig for den godkendende administrator via enheds-endpointet. Enhedsgodkendelsen udløber ikke automatisk og kontrollerer fortsat tilbagekaldelse, administratoroplysninger samt tenant og miljø. Eksisterende UserBalance-klienter er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.17.0 tilføjer syv operationer til Wallboard-godkendelse og enheder (198 i alt). En aktiv administrator godkender skærmen én gang; enhedens godkendelse udløber ikke automatisk. Behold den ikke-eksporterbare private ECDSA P-256-nøgle på skærmen, underskriv engangsudfordringer ved genforbindelse, og hold administratoroplysninger og bearer-tokens ude af URL’er og browserlager. Tilbagekaldelse og kontrol af administratorens konto og legitimationsoplysninger bevares. Sessionsvarigheden på ti dage begrænser ikke enhedsgodkendelsen. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.16.1 tilføjer afregningschecklisten med læseadgang, maskinfejlhistorik og kvittering, visning og genåbning af maskiner ude af drift samt autoriseret adgang til beboerens eVaskeri. Beboersøgning inkluderer bankKid. Alle operationer bevarer administrator-, tenant- og ressourcekontrol. eVaskeri-links er følsomme adgangsoplysninger: åbn straks uden opener/referrer, og gem eller log dem aldrig. Gentag aldrig ændringskald automatisk efter et usikkert svar. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.15.0 bruger GetPublicCycleWidget og GetCycleChartPresentation. Erstat de udgåede WashDoc-widget-/præsentationsruter med /api/v1/public/widgets/cycle og /api/v1/public/cycle-chart/presentation. Dokumenternes stiparametre og tabel-/graf-/widgetfelter bruger cycleKid; widgettens visningsfelt hedder cycleKidText. Eksisterende KID-værdier og dokumentoperationernes ID er bevaret. Genbyg klienterne, og opdater feltbindingerne. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.14.0 synkroniserer personlige valg af sprog, dato/tid, talformat og linjeafstand. WashDoc-widgets erstatter unitKidText med documentKidText; graphSvg kan være null uden målinger. Stop polling ved refreshAfterSeconds=0; igangværende dokumenter bruger 15 sekunder. Administratorsessioner varer ti dage: brug svarets expiresIn og forny kun efter aktivitet. UserBalance er fortsat kompatibel. Se [API-changelog](/docs#changelog).

Version 0.13.0 flytter ConvertToolTime og InspectToolKid til /api/v1/tenant/tools/time og /api/v1/tenant/tools/kid. Fjern bankKid-argumentet ved genbygning; sitet vælger tenant. Aktiv manager, More1, Bank Read og et ressourcegrant i sitets tenant kræves fortsat. JSON-input og -svar er uændrede. GetUnitDocumentNeighbors giver autoriseret dokumentnavigation for samme enhed. Se [API-changelog](/docs#changelog).

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Kombine Flex Portal-klient til PHP

[API-kontraktens changelog](https://api.team.kombine.technology/docs#changelog) — brug `/docs#changelog` på samme tenant-API og miljø som klienten. Changelog er kun på engelsk.

Version **0.20.1**, klargjort lokalt; ikke deployet eller udgivet på Packagist. Indeholder 206 offentlige operationer fra den medfølgende OpenAPI-kontrakt. Kræver **64-bit PHP 8.2+**, `ext-curl`, `ext-json`, HTTPS og betroede CA-certifikater. Ingen ekstra PHP-biblioteker eller interne Kombine-DLL'er kræves. Transporten understøtter Windows, Linux og macOS; denne version er testet med Windows CLI. Brug en PHP-version, der fortsat understøttes.

Version 0.3.1 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer. Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances. Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser. Version 0.2.5 tilføjer GetUserReceipts og GetHostingMetrics til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov fra offset 0. Fortsæt med nextOffset og samme revision; ved HTTP 409 (receipts-changed) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se /docs#user-receipts og /docs#hosting for rettigheder og grænser.

Til denne beta-kandidat skal svarfelterne icon/bankIcon/unitIcon ændres til iconKid/bankIconKid/unitIconKid, og ikonruter skal have et eksplicit ikonsæt. Se API-changelog for de fjernede stier. Appdownloads returnerer DownloadResponse og skriver bytes til den angivne stream.

## Installation

Hent `kombine-flex-portal-client-php-0.20.1.zip` fra API-vejledningens PHP-afsnit. Med Composer lægges ZIP-filen i applikationens `packages/`-mappe:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-portal-client:0.20.1
```

Composers artifact-kilde kræver `ext-zip` under installationen. Uden Composer udpakkes ZIP-filen i `flex-portal-client/`; erstat autoload-linjen nedenfor med `require __DIR__ . '/flex-portal-client/autoload.php';`. Behold hele `src/`, inklusive `contract.json`. Begge pakker kan indlæses sammen.

## Login og første kald

Brug en administrators mail og adgangskode til tenantens Portal API. Hent variablerne nedenfor fra applikationens beskyttede konfiguration eller loginformular. Tenantens API-adresse skal slutte med `/`.

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
    // Håndter fejlen efter tabellen nedenfor; gentag ikke skrivninger blindt.
} catch (TransportException | ProtocolException $error) {
    // Timeout, netværksfejl, ugyldigt svar eller overskredet svargrænse.
    // En skrivning kan være gennemført: kontrollér tilstanden før gentagelse.
} finally {
    $api->close();
}
```

`login()` husker bearer-tokenen i hukommelsen; den rå operation `loginManager($body)` returnerer den kun. `setAccessToken($token)` og `getAccessToken()` gør det muligt at genbruge en session via beskyttet lagring på serveren. Del aldrig en klient mellem brugere eller tenants. `clearSession()` og `close()` sletter den lokale token; eksisterende kopier beholder deres udløbstid. Loginoplysninger gemmes ikke. Anonyme kald sender ingen token. HTTP 401 sletter den, også ved ugyldige eller for store fejlsvar. `renew()` kalder eksplicit RenewManagerSession og gemmer den nye token. Den rå `renewManagerSession()` returnerer kun svaret. Forny før udløb ud fra brugeraktivitet; efter udløb eller tilbagekaldelse kræves nyt login. Der er ingen særskilt refresh-token.

## Metoder og værdier

[OPERATIONS.md](OPERATIONS.md) viser alle stabile operation-ID'er og PHP-metoder. [MODELS.md](MODELS.md) beskriver array-formaterne. Nøgler i `$options` bruger API'ets præcise navne og store/små bogstaver. Objekter er associative arrays; lister er indekserede arrays. Et tomt request-array bliver til et JSON-objekt, når kontrakten kræver et objekt. Datoer, KID'er, cursors og revisioner forbliver strenge; rekonstruér eller fortolk dem ikke. Heltal, inklusive MS2000 og beløb i mindste valutaenhed, er PHP `int` på 64-bit. Decimaltal, strenge og værdier uden for intervallet afvises i kendte heltalsfelter. Bevar forskellen mellem manglende værdier og `null`; ingen af delene betyder nul.

Sideinddeling er eksplicit: genbrug den returnerede cursor, og fortsæt, til den mangler, også efter en tom side. Behold revisionstokens til skrivninger. Download til en midlertidig fil, og omdøb den først efter succes.

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

## Fejl, rettigheder og grænser

| Resultat | Håndtering |
| --- | --- |
| 400 | Ret requesten ud fra API'ets fejlkode. |
| 401 | Sessionen er slettet; log ind igen. |
| 403 | Kontrollér kontoens API-rettigheder; gentagelse giver ikke adgang. |
| 404 / 409 | Genindlæs objekt eller revision og håndter manglende data/konflikter. |
| 429 | Respektér `Retry-After`; undgå samtidige gentagelsesløkker. |
| 5xx | Vis midlertidig fejl, og brug kun kontrolleret ventetid og gentagelse, hvor det er forsvarligt. |

Klienten gentager, sideinddeler, fornyer og kvitterer ikke automatisk. Hvert forretningskald kontrollerer fortsat administratorens kontostatus, tilladte Tab, KID-område og operationsrettighed. Et KID giver ikke i sig selv adgang. Tenantens URL kan ikke ændres efter oprettelse. Redirects og cookies er slået fra. TLS-certifikater kontrolleres altid; HTTP accepteres kun til eksplicitte lokale loopback-adresser. PHP-kald fra serveren kræver ikke browser-CORS.

Standardgrænser: 30 sekunder for hele kaldet, højst 10 sekunder til forbindelse, 16 MiB JSON pr. request/svar, 64 KiB headers og 1 GiB pr. download. Tilpas `timeout`, `maxJsonBytes` og `maxDownloadBytes` i konstruktøren. Downloads streames til en skrivbar resource, som applikationen ejer og lukker. Kassér delvise filer ved fejl. Genoptagelse af downloads og samtidig/delt brug af en klient understøttes ikke. Headernavne i svar og fejl er med små bogstaver. Log aldrig loginoplysninger, tokens, fulde payloads eller følsomme svarheaders. Beskyt PHP-applikationens sessionscookies og formularer, der ændrer data, med CSRF-beskyttelse.

## Bygning og kontrol

Til vedligeholdere: `scripts/Update-PhpClients.ps1` eksporterer metadata fra den aktuelle API-kode uden at starte API-jobs eller tilgå databaser og genererer derefter PHP. `scripts/Test-PhpClients.ps1` kontrollerer generering, tester alle operationer mod lokale HTTP-fixtures, bygger deterministiske ZIP-filer, tester de udpakkede pakker og kopierer kun PHP-downloads til begge API'er. De øvrige klienter beholder deres egne udgivelseskontrakter. Der udføres ingen publicering eller deployment.


GetTerminals bruger rapporteret ComputerName til navn, filtrering og sortering; manglende navne er tomme. Bed om fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight for terminaldata. Værdier er strenge, null ved fravalg og tomme ved manglende data. Behold fields under sideskift, og genstart gamle cursors. Lokationsnavne følger altid med. Se /docs#changelog for alle migreringskrav.
