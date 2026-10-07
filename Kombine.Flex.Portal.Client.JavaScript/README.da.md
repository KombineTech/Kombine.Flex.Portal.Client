Version 0.4.4: GetLocations kræver nu fields=vismaCustNo,bankActivationCode,locationActivationCode for at bevare de tidligere valgfrie værdier; accepter null for fravalgte felter. Behold samme fields under sideskift, og start gamle cursors forfra. Nye forslag til beboernumre er skrivebeskyttede og reserverer ikke et nummer. Aktiveringssvar indeholder qrCodeDataV1 og qrCodeDataV2 (fem værdier med 30-bit støj/kontrolsum); behandl begge som legitimationsoplysninger. Se /docs#changelog for migrering og /docs for rettigheder og fejlhåndtering.

ersion 0.4.4 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — JavaScript/TypeScript-klient

`@kombine/flex-portal-client` er én ESM-pakke med almindelig JavaScript og TypeScript-typer til alle **110 offentlige API-operationer**. Den understøtter Node.js 22+ og moderne browsere med `fetch`, `BigInt`, Web Streams og ES2022. Ingen runtimeafhængigheder, .NET, NuGet eller andre Kombine-pakker. Rettigheder og forretningsregler håndhæves af API'et.

Pakken er **ikke publiceret på npm**. Installér den leverede tarball:

```sh
npm install ./kombine-flex-portal-client-0.4.4.tgz
```

Version 0.4.4 følger den aktuelle beta-kandidat (110 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

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
