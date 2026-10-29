Version 0.19.0 indeholder 202 operationer, herunder GetUnitTimeline og GetUnitTimelineFields. Wallboard-svar identificerer den præcise godkendte skærm; skærmsessioner viser kun minimal identitet uden normale administratorrettigheder. Brug et normalt administratorlogin til Portal-operationer. Permanent enhedsgodkendelse og UserBalance er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.18.0 tilføjer FindWallboardPairings og GetWallboardDevice (200 operationer i alt) samt valgfri lokationsmetadata ved skærmgodkendelse. Den samlede Wallboard-opsætning bruger én QR-skanning; privat lokation er kun tilgængelig for den godkendende administrator via enheds-endpointet. Enhedsgodkendelsen udløber ikke automatisk og kontrollerer fortsat tilbagekaldelse, administratoroplysninger samt tenant og miljø. Eksisterende UserBalance-klienter er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.17.0 tilføjer syv operationer til Wallboard-godkendelse og enheder (198 i alt). En aktiv administrator godkender skærmen én gang; enhedens godkendelse udløber ikke automatisk. Behold den ikke-eksporterbare private ECDSA P-256-nøgle på skærmen, underskriv engangsudfordringer ved genforbindelse, og hold administratoroplysninger og bearer-tokens ude af URL’er og browserlager. Tilbagekaldelse og kontrol af administratorens konto og legitimationsoplysninger bevares. Sessionsvarigheden på ti dage begrænser ikke enhedsgodkendelsen. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog) og [Wallboard-vejledningen](https://api.team.kombine.technology/docs#wallboard-pairing).

Version 0.16.0 tilføjer afregningschecklisten med læseadgang, maskinfejlhistorik og kvittering, visning og genåbning af maskiner ude af drift samt autoriseret adgang til beboerens eVaskeri. Beboersøgning inkluderer bankKid. Alle operationer bevarer administrator-, tenant- og ressourcekontrol. eVaskeri-links er følsomme adgangsoplysninger: åbn straks uden opener/referrer, og gem eller log dem aldrig. Gentag aldrig ændringskald automatisk efter et usikkert svar. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.15.0 bruger GetPublicCycleWidget og GetCycleChartPresentation. Erstat de udgåede WashDoc-widget-/præsentationsruter med /api/v1/public/widgets/cycle og /api/v1/public/cycle-chart/presentation. Dokumenternes stiparametre og tabel-/graf-/widgetfelter bruger cycleKid; widgettens visningsfelt hedder cycleKidText. Eksisterende KID-værdier og dokumentoperationernes ID er bevaret. Genbyg klienterne, og opdater feltbindingerne. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.14.0 synkroniserer personlige valg af sprog, dato/tid, talformat og linjeafstand. WashDoc-widgets erstatter unitKidText med documentKidText; graphSvg kan være null uden målinger. Stop polling ved refreshAfterSeconds=0; igangværende dokumenter bruger 15 sekunder. Administratorsessioner varer ti dage: brug svarets expiresIn og forny kun efter aktivitet. UserBalance er fortsat kompatibel. Se [API-changelog](/docs#changelog).

Version 0.13.0 flytter ConvertToolTime og InspectToolKid til /api/v1/tenant/tools/time og /api/v1/tenant/tools/kid. Fjern bankKid-argumentet ved genbygning; sitet vælger tenant. Aktiv manager, More1, Bank Read og et ressourcegrant i sitets tenant kræves fortsat. JSON-input og -svar er uændrede. GetUnitDocumentNeighbors giver autoriseret dokumentnavigation for samme enhed. Se [API-changelog](/docs#changelog).

## Lokationens reservationskalendere · 0.13.0

`GetLocationBookingCalendars` returnerer daterede kalendere med åbningstider anvendt af API’et. Angiv valgfrit from=yyyy-MM-dd og days=1-31 (standard 14); svaret indeholder timeZone, from, days og date for hver dag. Vis datoerne direkte og hent et nyt interval ved navigation uden at gentage uger eller kombinere åbningstider i klienten. Grupper har autoriserede enheder og status Configured; ugyldige gemte kalendere udelades. startMinute er 0-1439, durationMinutes er positiv, og summen er højst 1440. Type 0 er reservationstid, 1 chance, 2 lukket og 3 ukendt åbningstid. Ukendt må ikke vises som reserverbart. Kræver Bookings1, Lokation Læs, Enhed Læs og korrekt ressourceadgang. Vis hver maskine separat. Dette er opsætning, ikke aktuelle reservationer eller ledighed. Håndter 400/401/403/404/503 eksplicit. Se [reservationskalendere](/docs#location-booking-calendars) og [changelog](/docs#changelog).

Version 0.13.0 omfatter 182 operationer. SaveCameraCapture understøtter valgfri baggrundsbehandling; HTTP 202 bekræfter kun midlertidig lagring. Behold originalfiler og uploadtoken, og kald ConfirmCameraCapture, indtil confirmed er true. processingPercent er et skøn og kan være null; errorCode kan angive fejl. Efter genstart af værten gentages upload med de samme originalfiler og token, hvis publicering ikke er bekræftet. Genbyg kald mod de opdaterede SaveCameraCapture-signaturer, og brug navngivne argumenter, hvor det er muligt. API-standardens synkrone adfærd er uændret. Se /docs#camera-captures og /docs#changelog.

Version 0.13.0 indeholder GetCameraNearestLocation til GPS-baseret lokationsvalg og GetRecentCameraPhotoMetadata til beskyttet billedinformation. Kameraressourcer indeholder afstandskontrol og nullable lokationskoordinater. Nye filnavne er uigennemsigtige GUID’er; udled ikke region eller oprindeligt navn. Lokationsvalg kræver Camera1 og Location Læs/Skriv; metadata kræver ressourcens Læs. Ved manglende GPS og 404/409 vælges lokationen manuelt. Se /docs#camera-captures og /docs#changelog.

## Seneste kamerabilleder · 0.13.0

Tilføjer `GetPublicRecentCameraPhotos` og `GetPublicCameraThumbnail`. De offentlige operationer kræver ikke login og er bundet til sitets tenant. Listen returnerer højst ti billeder med kortlivede miniature-URL’er og arbejdsområdestier. Miniaturer er offentlige; originaler og metadata forbliver beskyttede. Åbning af arbejdsområdet kræver normale administratorrettigheder. Håndtér 503 ved utilgængelig liste og 400/404 ved ugyldige, udløbne eller manglende miniaturer. Se [offentlige widgets](/docs#public-widgets).

## Lokationens vejr · 0.13.0

Version 0.13.0 omfatter alle 182 operationer og indeholder `GetLocationWeather` til et kanonisk lokations-KID. Genbrug administratorsessionen. API’et kræver tildelt Tab, Bank Læs, Lokation Læs, matchende adgangsområde samt synlig lokation og bank. Den bruger gemte koordinater eller lokationens adresse; klienten sender aldrig udbydernøgler eller koordinater. Kontrollér `status`: `Available` har `current`; `LocationUnknown` og `Unavailable` har ingen målinger. Ukendte værdier er null, aldrig nul. Temperatur er Celsius, vind m/s, nedbør mm og fugtighed procent; tidspunkter er UTC. Adressebaseret position kan være omtrentlig. Vis kildeangivelsen: Weather data by Open-Meteo, CC BY 4.0. Håndter HTTP 400/401/403/404/503 normalt, og gentag kun bevidst; udbyderfejl kan også give HTTP 200 med `Unavailable`. Se [lokationens vejr](/docs#location-weather).

```javascript
const weather = await api.getLocationWeather(locationKid);
if (weather.status === "Available" && weather.current != null) {
  console.log(weather.current.temperatureCelsius);
}
```

## Camera1 · 0.8.0

Version 0.8.0 indeholder alle 148 offentlige operationer, inklusive Camera1. Kald PrepareCameraCapture med originalens præcise SHA-256, længde, UTC-optagelsestid, ressource-KID og sensorobjekt. Upload derefter de samme bytes med uploadToken. Live Photos kræver også matchende længde/hash og den oprindelige MOV-fil. Behold samme token og bytes ved et bevidst genforsøg; klienten gentager aldrig automatisk. Forøg tidsfristen ved videobehandling. API’et kontrollerer Camera1 og præcise Read/Write-rettigheder til ressourcen. Lister kan være ufuldstændige eller have tomme sider med nextCursor; fortsæt, indtil cursor mangler. Hent medier gennem API’et; Range-kald kan give HTTP 206. Se /docs#camera-captures for grænser og fejl.

```javascript
// uploadToken comes from prepareCameraCapture for the exact original Blob bytes.
const body = new FormData();
body.set("uploadToken", uploadToken);
body.set("original", originalBlob, "capture.jpg");
const saved = await api.saveCameraCapture(body, { signal });
```

Fetch creates the multipart Content-Type boundary. Add a `motion` Blob for Live Photos. File and text payloads together are limited to 139 MiB, reserving framing overhead under the API limit; text fields: 512 KiB each.

Alle administratorrolleskift kræver Læs og Skriv på både Tabs og Kids. Håndter missing-tabs-read, missing-tabs-write, missing-kids-read og missing-kids-write (HTTP 403).

GetTerminals bruger rapporteret ComputerName til navn, filtrering og sortering; manglende navne er tomme. Bed om fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight for terminaldata. Værdier er strenge, null ved fravalg og tomme ved manglende data. Behold fields under sideskift, og genstart gamle cursors. Lokationsnavne følger altid med. Se /docs#changelog for alle migreringskrav.

Version 0.8.0 omfatter 148 API-operationer. GetUnits tilføjer en autoriseret enhedsoversigt: behold filtre og fields under sideskift, og genstart ved invalid-cursor. Administratorroller kræver alle ni expectedFlags-kategorier, inklusive Tabs og Kids; håndter deres særskilte læse-/skriverettigheder og 403-svar. Serviceadgangstildelinger er fjernet; stop tildelingskald og læsning af access-objektet. Logodele angives i stien før farven, ikke som query-parametre. UserBalance er fortsat kompatibel. Se /docs#changelog for migrering og /docs#unit-directory for sideskift og eksempler.

Version 0.8.0: GetLocations kræver nu fields=vismaCustNo,bankActivationCode,locationActivationCode for at bevare de tidligere valgfrie værdier; accepter null for fravalgte felter. Behold samme fields under sideskift, og start gamle cursors forfra. Nye forslag til beboernumre er skrivebeskyttede og reserverer ikke et nummer. Aktiveringssvar indeholder qrCodeDataV1 og qrCodeDataV2 (fem værdier med 30-bit støj/kontrolsum); behandl begge som legitimationsoplysninger. Se /docs#changelog for migrering og /docs for rettigheder og fejlhåndtering.

Version 0.8.0 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — JavaScript/TypeScript-klient

`@kombine/flex-portal-client` er én ESM-pakke med almindelig JavaScript og TypeScript-typer til alle **181 offentlige API-operationer**. Den understøtter Node.js 22+ og moderne browsere med `fetch`, `BigInt`, Web Streams og ES2022. Ingen runtimeafhængigheder, .NET, NuGet eller andre Kombine-pakker. Rettigheder og forretningsregler håndhæves af API'et.

Pakken er **ikke publiceret på npm**. Installér den leverede tarball:

```sh
npm install ./kombine-flex-portal-client-0.13.0.tgz
```

Version 0.13.0 følger den aktuelle beta-kandidat (182 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.

## Tenant, login og tabs

Vælg først tenantens **API-adresse**, ikke portalens webadresse, fx `https://api.team.kombine.technology/`. Afslut adressen med `/`. Brug ét klientobjekt pr. bruger og tenant. Opret en ny klient og log ind igen ved tenantskift.

```js
import { PortalClient, PortalApiError } from '@kombine/flex-portal-client';

// Værdierne kommer fx fra din loginformular; læg ikke adgangskoder i kildekoden.
const api = new PortalClient(tenantApiUrl, { timeoutMs: 30_000 });
try {
  const session = await api.login(email, password);
  const manager = await api.getCurrentManager();
  console.log(manager.name);
  for (const tab of manager.tabDetails ?? []) console.log(tab.id, tab.name);
} catch (error) {
  if (error instanceof PortalApiError) console.error(error.status, error.code);
  else console.error('API-kaldet kunne ikke gennemføres.');
} finally {
  api.clearSession();
}
```

`login()` gemmer bearer-token i hukommelsen. `loginManager(body)` er det rå API-kald og gemmer ikke sessionen. Du kan også tildele et udstedt token til `api.accessToken`. Offentlige kald sender aldrig token. Der bruges ingen cookies eller localStorage. `clearSession()`/`close()` fjerner klientens token; API'et har ingen separat refresh-token eller token-revokering. HTTP 401 fjerner den berørte session. Adgangskoden gemmes ikke af klienten. Log ikke tokens eller hele payloads.

Metodenavne følger operation IDs i `camelCase`. [OPERATIONS.md](OPERATIONS.md) viser alle kald; request/response-interfaces eksporteres fra pakken. Cursors, revisioner og kanoniske KIDs sendes uændret. Klienten udfører URL-kodningen; query-options er camelCase, mens wire-navne bevares, fx `includeZero` → `IncludeZero`.

```ts
const page = await api.getBankUsers(bankKid, { pageSize: 25, sort: 'number', direction: 'asc' });
const balances = await api.getBankUserBalances(bankKid, { userKids });
const account = await api.getBankAccount(bankKid, { period: 0, includeZero: false, limit: 50 });
const units = await api.getLocationUnits(locationKid, { acceptLanguage: 'da-DK' });
```

Pagination hentes kun ved eksplicitte kald. Saldokaldets nuværende API-grænse er 50 beboere i én bank; brug mindre portioner ved timeout. Ingen automatiske retries eller ekstra rettigheder.

## int64 er bigint

Alle OpenAPI-felter markeret `int64` er JavaScript `bigint`, også små værdier og `expiresIn`. Det forhindrer tavs afrunding af store beløb. `int32` er `number`; datoer er ISO-strenge; null/manglende felter bevares. Ukendte JSON-heltal fra nyere API-felter bevares også som `bigint`.

```ts
const expiresInSeconds: bigint | undefined = session.expiresIn;
const text = balance.currentBalanceMinor?.toString();
// Ved eget JSON-output: vælg eksplicit strenge til BigInt, da JSON.stringify ellers fejler.
const diagnostic = JSON.stringify(balances, (_, v) => typeof v === 'bigint' ? v.toString() : v);
```

Lav ikke `Number(...)` på et beløb uden en range-kontrol. Klientens egen serializer sender `bigint` som rigtige JSON-tal; request-modeller med int64 kræver `bigint` frem for `number`. Saldoer fra forskellige valutaer må ikke lægges sammen. Formatér beløb ud fra både minor units og valuta; null er ikke nul.

## Downloads, fejl og afbrydelse

```js
const download = await api.exportBankUsers(bankKid);
try {
  for await (const chunk of download.chunks()) {
    await destination.write(chunk); // Dit programs fil- eller stream-destination.
  }
} finally {
  await download.close();
}

const abort = new AbortController();
const request = api.getCurrentManager({ signal: abort.signal });
// abort.abort() kan fx kaldes, når brugeren forlader siden.
```

Downloads læses uden at samle hele filen i hukommelsen. `chunks()` kan kun anvendes én gang; afslutning og `break` lukker automatisk streamen. Et download, som ikke forbruges, skal også lukkes. Deadline og ekstern AbortSignal gælder under læsning af hele svaret. `close()` på klienten stopper nye kald, men afbryder ikke eksisterende kald; brug deres AbortSignal.

`PortalApiError` indeholder `status`, `code`, `headers` (`Headers`) og `response`. Sidstnævnte kan indeholde persondata; fejlens tekst indeholder kun HTTP-status. 401: nyt login. 403: manglende konto/Tab/KID/operationsadgang. 409: genindlæs revision. 429/503: respekter `Retry-After` og prøv senere; gentag ikke mutationskald automatisk. Netværks-/CORS-fejl bruger fetch-fejl; afbrydelse/timeout giver normalt `AbortError`/`TimeoutError`. Ugyldig/for stor JSON giver `PortalProtocolError`.

HTTPS bruger værtsmiljøets normale certifikatkontrol; HTTP er kun tilladt på loopback til lokale tests. Redirects afvises. Default deadline er 30 sekunder; JSON-grænsen er 16 MiB (`maxJsonBytes`), nesting 64. Fil-downloads er ikke begrænset af JSON-grænsen.

## Browser og CORS

Brug din bundler, eller kopiér **hele** `dist`-mappen til din webserver og importér `./dist/index.js` fra et `<script type="module">`. Åbn ikke via `file://`. API'ets `Cors:AllowedOrigins` skal tillade sidens præcise origin. Browseren viser kun CORS-eksponerede response-headers, så fx `Retry-After`/`Content-Disposition` kan være utilgængelige; status/body er stadig tilgængelige. Node.js kræver ikke browser-CORS. Klienten ændrer ikke API'ets CORS-regler.

En Tab i profilen giver ikke automatisk adgang til alle funktioner; API'ets konto-, Tab-, KID- og operationskontrol gælder for hvert kald. Send ikke et login via den lokale numeriske ID-mekanisme; SDK'et bruger normal e-mail/adgangskode.

## Bygning og tests

```sh
pnpm install --frozen-lockfile
pnpm test
pnpm pack
```

TypeScript er kun en udviklingsafhængighed. Pakken indeholder kompileret JavaScript og `.d.ts`; kunden behøver ikke kompilere SDK'et. CommonJS er ikke en særskilt build; brug dynamisk `import()` fra CommonJS.

Begge SDK'er genereres af `scripts/Generate-PortalScriptClients.py` fra den fælles `Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json`. Brug `--check` for driftkontrol. `scripts/Test-PortalScriptClients.ps1` tester og pakker begge under `artifacts/packages`. Tests bruger kun lokale fixtures uden database. Copyright Kombine Technology ApS.
