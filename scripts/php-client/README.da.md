Version 0.20.1 indeholder 206 operationer, herunder GetUnitTimeline og GetUnitTimelineFields. Wallboard-svar identificerer den præcise godkendte skærm; skærmsessioner viser kun minimal identitet uden normale administratorrettigheder. Brug et normalt administratorlogin til Portal-operationer. Permanent enhedsgodkendelse og UserBalance er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.18.0 tilføjer FindWallboardPairings og GetWallboardDevice (206 operationer i alt) samt valgfri lokationsmetadata ved skærmgodkendelse. Den samlede Wallboard-opsætning bruger én QR-skanning; privat lokation er kun tilgængelig for den godkendende administrator via enheds-endpointet. Enhedsgodkendelsen udløber ikke automatisk og kontrollerer fortsat tilbagekaldelse, administratoroplysninger samt tenant og miljø. Eksisterende UserBalance-klienter er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.17.0 tilføjer syv operationer til Wallboard-godkendelse og enheder (198 i alt). En aktiv administrator godkender skærmen én gang; enhedens godkendelse udløber ikke automatisk. Behold den ikke-eksporterbare private ECDSA P-256-nøgle på skærmen, underskriv engangsudfordringer ved genforbindelse, og hold administratoroplysninger og bearer-tokens ude af URL’er og browserlager. Tilbagekaldelse og kontrol af administratorens konto og legitimationsoplysninger bevares. Sessionsvarigheden på ti dage begrænser ikke enhedsgodkendelsen. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.16.1 tilføjer afregningschecklisten med læseadgang, maskinfejlhistorik og kvittering, visning og genåbning af maskiner ude af drift samt autoriseret adgang til beboerens eVaskeri. Beboersøgning inkluderer bankKid. Alle operationer bevarer administrator-, tenant- og ressourcekontrol. eVaskeri-links er følsomme adgangsoplysninger: åbn straks uden opener/referrer, og gem eller log dem aldrig. Gentag aldrig ændringskald automatisk efter et usikkert svar. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.15.0 bruger GetPublicCycleWidget og GetCycleChartPresentation. Erstat de udgåede WashDoc-widget-/præsentationsruter med /api/v1/public/widgets/cycle og /api/v1/public/cycle-chart/presentation. Dokumenternes stiparametre og tabel-/graf-/widgetfelter bruger cycleKid; widgettens visningsfelt hedder cycleKidText. Eksisterende KID-værdier og dokumentoperationernes ID er bevaret. Genbyg klienterne, og opdater feltbindingerne. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.14.0 synkroniserer personlige valg af sprog, dato/tid, talformat og linjeafstand. WashDoc-widgets erstatter unitKidText med documentKidText; graphSvg kan være null uden målinger. Stop polling ved refreshAfterSeconds=0; igangværende dokumenter bruger 15 sekunder. Administratorsessioner varer ti dage: brug svarets expiresIn og forny kun efter aktivitet. UserBalance er fortsat kompatibel. Se [API-changelog](/docs#changelog).

Version 0.13.0 flytter ConvertToolTime og InspectToolKid til /api/v1/tenant/tools/time og /api/v1/tenant/tools/kid. Fjern bankKid-argumentet ved genbygning; sitet vælger tenant. Aktiv manager, More1, Bank Read og et ressourcegrant i sitets tenant kræves fortsat. JSON-input og -svar er uændrede. GetUnitDocumentNeighbors giver autoriseret dokumentnavigation for samme enhed. Se [API-changelog](/docs#changelog).

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Kombine Flex __API__-klient til PHP

[API-kontraktens changelog](__ORIGIN__/docs#changelog) — brug `/docs#changelog` på samme tenant-API og miljø som klienten. Changelog er kun på engelsk.

Version **0.1.0**, klargjort lokalt; ikke deployet eller udgivet på Packagist. Indeholder __COUNT__ offentlige operationer fra den medfølgende OpenAPI-kontrakt. Kræver **64-bit PHP 8.2+**, `ext-curl`, `ext-json`, HTTPS og betroede CA-certifikater. Ingen ekstra PHP-biblioteker eller interne Kombine-DLL'er kræves. Transporten understøtter Windows, Linux og macOS; denne version er testet med Windows CLI. Brug en PHP-version, der fortsat understøttes.

## Installation

Hent `__ZIP__` fra API-vejledningens PHP-afsnit. Med Composer lægges ZIP-filen i applikationens `packages/`-mappe:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-__LOWER__-client:0.1.0
```

Composers artifact-kilde kræver `ext-zip` under installationen. Uden Composer udpakkes ZIP-filen i `flex-__LOWER__-client/`; erstat autoload-linjen nedenfor med `require __DIR__ . '/flex-__LOWER__-client/autoload.php';`. Behold hele `src/`, inklusive `contract.json`. Begge pakker kan indlæses sammen.

## Login og første kald

__AUTH__ Hent variablerne nedenfor fra applikationens beskyttede konfiguration eller loginformular. Tenantens API-adresse skal slutte med `/`.

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
    // Håndter fejlen efter tabellen nedenfor; gentag ikke skrivninger blindt.
} catch (TransportException | ProtocolException $error) {
    // Timeout, netværksfejl, ugyldigt svar eller overskredet svargrænse.
    // En skrivning kan være gennemført: kontrollér tilstanden før gentagelse.
} finally {
    $api->close();
}
```

`login()` husker bearer-tokenen i hukommelsen; den rå operation `__RAWLOGIN__($body)` returnerer den kun. `setAccessToken($token)` og `getAccessToken()` gør det muligt at genbruge en session via beskyttet lagring på serveren. Del aldrig en klient mellem brugere eller tenants. `clearSession()` og `close()` sletter den lokale token; eksisterende kopier beholder deres udløbstid. Loginoplysninger gemmes ikke. Anonyme kald sender ingen token. HTTP 401 sletter den, også ved ugyldige eller for store fejlsvar. __SESSION__

## Metoder og værdier

[OPERATIONS.md](OPERATIONS.md) viser alle stabile operation-ID'er og PHP-metoder. [MODELS.md](MODELS.md) beskriver array-formaterne. Nøgler i `$options` bruger API'ets præcise navne og store/små bogstaver. Objekter er associative arrays; lister er indekserede arrays. Et tomt request-array bliver til et JSON-objekt, når kontrakten kræver et objekt. Datoer, KID'er, cursors og revisioner forbliver strenge; rekonstruér eller fortolk dem ikke. Heltal, inklusive MS2000 og beløb i mindste valutaenhed, er PHP `int` på 64-bit. Decimaltal, strenge og værdier uden for intervallet afvises i kendte heltalsfelter. Bevar forskellen mellem manglende værdier og `null`; ingen af delene betyder nul.

__DETAILS__

## Fejl, rettigheder og grænser

| Resultat | Håndtering |
| --- | --- |
| 400 | Ret requesten ud fra API'ets fejlkode. |
| 401 | Sessionen er slettet; log ind igen. |
| 403 | Kontrollér kontoens API-rettigheder; gentagelse giver ikke adgang. |
| 404 / 409 | Genindlæs objekt eller revision og håndter manglende data/konflikter. |
| 429 | Respektér `Retry-After`; undgå samtidige gentagelsesløkker. |
| 5xx | Vis midlertidig fejl, og brug kun kontrolleret ventetid og gentagelse, hvor det er forsvarligt. |

Klienten gentager, sideinddeler, fornyer og kvitterer ikke automatisk. __PERMISSIONS__ Tenantens URL kan ikke ændres efter oprettelse. Redirects og cookies er slået fra. TLS-certifikater kontrolleres altid; HTTP accepteres kun til eksplicitte lokale loopback-adresser. PHP-kald fra serveren kræver ikke browser-CORS.

Standardgrænser: 30 sekunder for hele kaldet, højst 10 sekunder til forbindelse, 16 MiB JSON pr. request/svar, 64 KiB headers og 1 GiB pr. download. Tilpas `timeout`, `maxJsonBytes` og `maxDownloadBytes` i konstruktøren. Downloads streames til en skrivbar resource, som applikationen ejer og lukker. Kassér delvise filer ved fejl. Genoptagelse af downloads og samtidig/delt brug af en klient understøttes ikke. Headernavne i svar og fejl er med små bogstaver. Log aldrig loginoplysninger, tokens, fulde payloads eller følsomme svarheaders. Beskyt PHP-applikationens sessionscookies og formularer, der ændrer data, med CSRF-beskyttelse.

## Bygning og kontrol

Til vedligeholdere: `scripts/Update-PhpClients.ps1` eksporterer metadata fra den aktuelle API-kode uden at starte API-jobs eller tilgå databaser og genererer derefter PHP. `scripts/Test-PhpClients.ps1` kontrollerer generering, tester alle operationer mod lokale HTTP-fixtures, bygger deterministiske ZIP-filer, tester de udpakkede pakker og kopierer kun PHP-downloads til begge API'er. De øvrige klienter beholder deres egne udgivelseskontrakter. Der udføres ingen publicering eller deployment.


GetTerminals bruger rapporteret ComputerName til navn, filtrering og sortering; manglende navne er tomme. Bed om fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight for terminaldata. Værdier er strenge, null ved fravalg og tomme ved manglende data. Behold fields under sideskift, og genstart gamle cursors. Lokationsnavne følger altid med. Se /docs#changelog for alle migreringskrav.
