Alle administratorrolleskift kræver Læs og Skriv på både Tabs og Kids. Håndter missing-tabs-read, missing-tabs-write, missing-kids-read og missing-kids-write (HTTP 403).

Version 0.5.3 omfatter 120 API-operationer. GetUnits tilføjer en autoriseret enhedsoversigt: behold filtre og fields under sideskift, og genstart ved invalid-cursor. Administratorroller kræver alle ni expectedFlags-kategorier, inklusive Tabs og Kids; håndter deres særskilte læse-/skriverettigheder og 403-svar. Serviceadgangstildelinger er fjernet; stop tildelingskald og læsning af access-objektet. Logodele angives i stien før farven, ikke som query-parametre. UserBalance er fortsat kompatibel. Se /docs#changelog for migrering og /docs#unit-directory for sideskift og eksempler.

Version 0.5.3: GetLocations kræver nu fields=vismaCustNo,bankActivationCode,locationActivationCode for at bevare de tidligere valgfrie værdier; accepter null for fravalgte felter. Behold samme fields under sideskift, og start gamle cursors forfra. Nye forslag til beboernumre er skrivebeskyttede og reserverer ikke et nummer. Aktiveringssvar indeholder qrCodeDataV1 og qrCodeDataV2 (fem værdier med 30-bit støj/kontrolsum); behandl begge som legitimationsoplysninger. Se /docs#changelog for migrering og /docs for rettigheder og fejlhåndtering.

Version 0.5.3 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — Python-klient

`kombine-flex-portal-client` er en selvstændig Python 3.11+-pakke til alle **110 offentlige API-operationer**. Den bruger kun Pythons standardbibliotek. Ingen .NET, NuGet, databaseadgang eller andre Kombine-pakker er nødvendige. Rettigheder og forretningsregler håndhæves fortsat af API'et.

Pakken er **ikke publiceret på PyPI**. Installér den leverede wheel lokalt:

```sh
python -m pip install ./kombine_flex_portal_client-0.5.3-py3-none-any.whl
```

Version 0.5.3 følger den aktuelle beta-kandidat (120 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

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
