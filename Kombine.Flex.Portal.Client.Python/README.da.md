Version 0.23.0 tilføjer personlige Wallboard-layouts, registrering af skannede skærme og revisionsbaseret læsning af skærmlayout. Gem kun allerede skannede skærm-id’er med den nyeste revision. Bevar kladder ved konflikter, og gentag aldrig usikre skrivninger automatisk. Skærmsessioner kan kun læse deres godkendte skærm. UserBalance er fortsat kompatibel. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

Version 0.23.0 indeholder 206 operationer, herunder GetUnitTimeline og GetUnitTimelineFields. Wallboard-svar identificerer den præcise godkendte skærm; skærmsessioner viser kun minimal identitet uden normale administratorrettigheder. Brug et normalt administratorlogin til Portal-operationer. Permanent enhedsgodkendelse og UserBalance er fortsat kompatible. Se [API-changelog](https://api.team.kombine.technology/docs#changelog).

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

```python
weather = api.get_location_weather(location_kid)
if weather.get("status") == "Available" and weather.get("current") is not None:
    print(weather["current"]["temperatureCelsius"])
```

## Camera1 · 0.8.0

Version 0.8.0 indeholder alle 148 offentlige operationer, inklusive Camera1. Kald PrepareCameraCapture med originalens præcise SHA-256, længde, UTC-optagelsestid, ressource-KID og sensorobjekt. Upload derefter de samme bytes med uploadToken. Live Photos kræver også matchende længde/hash og den oprindelige MOV-fil. Behold samme token og bytes ved et bevidst genforsøg; klienten gentager aldrig automatisk. Forøg tidsfristen ved videobehandling. API’et kontrollerer Camera1 og præcise Read/Write-rettigheder til ressourcen. Lister kan være ufuldstændige eller have tomme sider med nextCursor; fortsæt, indtil cursor mangler. Hent medier gennem API’et; Range-kald kan give HTTP 206. Se /docs#camera-captures for grænser og fejl.

```python
from kombine_flex_portal import PortalUploadFile

# upload_token comes from prepare_camera_capture for these exact bytes.
with open(original_path, "rb") as original:
    saved = api.save_camera_capture({
        "uploadToken": upload_token,
        "original": PortalUploadFile(original, "capture.jpg"),
    })
```

Streams remain caller-owned and must be seekable. Rewind before a deliberate retry. Add `motion: PortalUploadFile(...)` for Live Photos. Maximum multipart body: 140 MiB; text fields: 512 KiB each.

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

# Kombine Flex Portal — Python-klient

`kombine-flex-portal-client` er en selvstændig Python 3.11+-pakke til alle **181 offentlige API-operationer**. Den bruger kun Pythons standardbibliotek. Ingen .NET, NuGet, databaseadgang eller andre Kombine-pakker er nødvendige. Rettigheder og forretningsregler håndhæves fortsat af API'et.

Pakken er **ikke publiceret på PyPI**. Installér den leverede wheel lokalt:

```sh
python -m pip install ./kombine_flex_portal_client-0.13.0-py3-none-any.whl
```

Version 0.13.0 følger den aktuelle beta-kandidat (182 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.

## Tenant, login og tabs

Vælg tenantens **API-adresse**, ikke portalens webadresse. Adressen skal slutte med `/`. Brug fx `https://api.team.kombine.technology/` eller den tilsvarende beta-adresse. Ét klientobjekt pr. bruger og tenant; opret en ny klient og log ind igen ved tenantskift.

```python
from getpass import getpass
from urllib.error import URLError
from kombine_flex_portal import PortalClient, PortalApiError

tenant_url = input("Tenantens API-URL (slut med /): ").strip()
email = input("E-mail: ").strip()

try:
    with PortalClient(tenant_url, timeout=30) as api:
        session = api.login(email, getpass("Adgangskode: "))
        manager = api.get_current_manager()
        print("Logget ind:", manager.get("name"))
        for tab in manager.get("tabDetails") or []:
            print(tab.get("id"), tab.get("name"))
        api.clear_session()
except PortalApiError as error:
    print("API-fejl:", error.status, error.code)
except (URLError, TimeoutError):
    print("API'et kunne ikke kontaktes.")
```

`login()` gemmer kun bearer-token i klientens hukommelse. `login_manager(body)` er det rå API-kald og gemmer ikke svaret som session. Et allerede udstedt token kan tildeles `api.access_token`. Offentlige kald sender aldrig token. `clear_session()`/`close()` sletter klientens token; serveren har ingen separat refresh-token eller token-revokeringsoperation. HTTP 401 sletter den berørte session. Adgangskoden bliver ikke gemt af klienten. Log ikke tokens eller hele request/response-payloads.

## Metoder, modeller og pagination

Metodenavne er operation IDs i `snake_case`. [OPERATIONS.md](OPERATIONS.md) viser hele listen. Request- og response-modeller er `TypedDict` i `kombine_flex_portal.models`; JSON-feltnavne bevares som fx `userKids` og `currentBalanceMinor`. Ukendte svarfelter bevares. Manglende felter og `None` er ikke det samme som nul. ISO-datoer er strenge; alle heltal, også int64-saldoer, er eksakte Python `int`.

```python
page = api.get_bank_users(bank_kid, page_size=25, sort="number", direction="asc")
# Brug det cursorfelt, som API-svaret returnerer; beregn eller afkod det ikke selv.
balances = api.get_bank_user_balances(bank_kid, {"userKids": user_kids})
account = api.get_bank_account(bank_kid, period=0, include_zero=False, limit=50)
units = api.get_location_units(location_kid, accept_language="da-DK")
```

Send kanoniske KIDs og cursors uændret. Klienten foretager URL-kodningen og bevarer API'ets query-navne, også `Period`, `IncludeZero` osv. Ingen skjulte ekstra kald, automatisk pagination, retries eller ændring af brugerens scope. Saldokaldets nuværende API-grænse er 50 beboere i én bank pr. request; vælg mindre portioner ved timeout.

## Downloads og fejl

Downloads er streams. Luk dem altid med `with`; filnavnet vælges af dit program:

```python
with api.export_bank_users(bank_kid) as download:
    with open("beboere.csv", "wb") as target:
        for chunk in download.iter_bytes():
            target.write(chunk)
```

`PortalApiError` indeholder `status`, `code`, `headers` (lowercase nøgler) og `response`. Sidstnævnte kan indeholde persondata; exceptionens egen tekst indeholder kun HTTP-status. 401: log ind igen. 403: manglende konto/Tab/KID/operationsadgang. 409: genindlæs revision før nyt forsøg. 429/503: respekter `Retry-After` og prøv senere; gentag ikke mutationskald automatisk. Netværksfejl bruger standardbibliotekets `URLError`/`OSError`/`TimeoutError`. Ugyldig eller for stor JSON giver `PortalProtocolError`.

HTTPS bruger operativsystemets normale certifikatkontrol. HTTP tillades kun på loopback til lokale tests. Redirects følges ikke. JSON har som standard en grænse på 16 MiB (`max_json_bytes`), og nesting er begrænset til 64. `timeout` er socket-I/O-timeout i sekunder, **ikke** en samlet deadline for hele et langt stream. Klienten er synkron; flyt kald til en arbejdstråd, hvis du bruger den i en async- eller GUI-applikation. `close()` standser nye kald, men afbryder ikke et allerede startet kald/download.

## Vedligeholdelse

I repository-roden:

```sh
python scripts/Generate-PortalScriptClients.py
python scripts/Generate-PortalScriptClients.py --check
```

Begge SDK'er genereres fra `Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json`; det er en build-input, ikke en runtimeafhængighed. Efter opdatering af API-kontrakten skal alle klienter regenereres og testes. Tests her bruger kun lokale fixtures uden database:

```sh
python -m pip install -e . --no-deps
python -m unittest discover -s tests -v
```

`scripts/Test-PortalScriptClients.ps1` i repository-roden kører begge klienters tests og bygger wheel, sdist og npm-tarball under `artifacts/packages`. Bygning kræver setuptools/wheel; de er ikke dependencies i kundepakken. Copyright Kombine Technology ApS.
