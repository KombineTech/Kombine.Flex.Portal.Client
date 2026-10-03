[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Kombine Flex Portal-klient til PHP

[API-kontraktens changelog](https://api.team.kombine.technology/docs#changelog) — brug `/docs#changelog` på samme tenant-API og miljø som klienten. Changelog er kun på engelsk.

Version **0.3.1**, klargjort lokalt; ikke deployet eller udgivet på Packagist. Indeholder 110 offentlige operationer fra den medfølgende OpenAPI-kontrakt. Kræver **64-bit PHP 8.2+**, `ext-curl`, `ext-json`, HTTPS og betroede CA-certifikater. Ingen ekstra PHP-biblioteker eller interne Kombine-DLL'er kræves. Transporten understøtter Windows, Linux og macOS; denne version er testet med Windows CLI. Brug en PHP-version, der fortsat understøttes.

Version 0.3.1 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer. Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances. Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser. Version 0.2.5 tilføjer GetUserReceipts og GetHostingMetrics til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov fra offset 0. Fortsæt med nextOffset og samme revision; ved HTTP 409 (receipts-changed) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se /docs#user-receipts og /docs#hosting for rettigheder og grænser.

Til denne beta-kandidat skal svarfelterne icon/bankIcon/unitIcon ændres til iconKid/bankIconKid/unitIconKid, og ikonruter skal have et eksplicit ikonsæt. Se API-changelog for de fjernede stier. Appdownloads returnerer DownloadResponse og skriver bytes til den angivne stream.

## Installation

Hent `kombine-flex-portal-client-php-0.3.1.zip` fra API-vejledningens PHP-afsnit. Med Composer lægges ZIP-filen i applikationens `packages/`-mappe:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-portal-client:0.3.1
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
