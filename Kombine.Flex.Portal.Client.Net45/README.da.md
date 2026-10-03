Version 0.3.1 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Flex Portal-klient til .NET Framework 4.5

`Kombine.Flex.Portal.Client.Net45.dll` indeholder typede, synkrone metoder til alle **110 offentlige API-operationer**. Biblioteket kommunikerer kun via HTTPS/JSON og har ingen forretningslogik, databaseadgang eller afhængighed af andre Kombine-biblioteker.

Version 0.3.1 følger den aktuelle beta-kandidat (110 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.

## Visual Studio-version

**Visual Studio 2008 understøtter .NET Framework 2.0, 3.0 og 3.5. .NET Framework 4.5 hører til Visual Studio 2012.** Åbn derfor denne variants `Kombine.Flex.Portal.Client.2012.sln` i VS2012 med .NET Framework 4.5-targetingbiblioteker, eller brug et andet kompatibelt buildværktøj. Se [Microsofts versionsoversigt](https://learn.microsoft.com/en-us/dotnet/framework/install/versions-and-dependencies) og [Microsofts beskrivelse af VS2008-multitargeting](https://devblogs.microsoft.com/dotnet/multi-targeting-of-web-projects-using-visual-studio-2010-beta1/).

Kunder, som bliver på VS2008, kan bruge den eksisterende `Client.Net20`-DLL fra både .NET 2.0- og 3.5-projekter. Windows CE/Mobile bruger den separate `Client.Compact20`. Denne DLL målretter desktop **.NET Framework 4.5**, ikke Compact Framework eller .NET Standard.

## Brug uden NuGet

Pak ZIP-filen ud, og vælg **Add Reference → Browse → Kombine.Flex.Portal.Client.Net45.dll**. Lad XML-filen ligge ved DLL'en for IntelliSense. Kun frameworkets `mscorlib` og `System` kræves; kunden behøver ingen NuGet-pakker. Kildefiler, solution og en selvstændig testapplikation ligger i ZIP'ens `Source`-mappe.

Projektet er et klassisk MSBuild 4.0-projekt med `TargetFrameworkVersion=v4.5`. Det har ingen `PackageReference` eller projekt-reference til andre klienter. De 100 metoder fremgår af [OPERATIONS.md](OPERATIONS.md).

## Tenant-URL, login og tabs

Vælg først tenantens API-adresse, fx `https://api.team.kombine.technology/`. Brug API-adressen, ikke portalens webadresse. Adressen skal slutte med `/`. Ved tenantskift oprettes en ny klient og et separat login.

Placér using/Imports øverst i filen og resten af koden inde i en metode. Inputvariabler (tenantApiUrl, loginoplysninger og KIDs) kommer fra din applikation. Begge sprog bruger den samme DLL.

**C#**

```csharp
using System;
using Kombine.Flex.Portal.Client.Net45;

using (PortalApiClient api = new PortalApiClient(new Uri(tenantApiUrl)))
{
    ManagerSessionResponse session = api.Login(email, password);
    ManagerProfileResponse manager = api.GetCurrentManager();
    Console.WriteLine(manager.Name);
    if (manager.TabDetails != null)
    {
        foreach (ManagerTabResponse tab in manager.TabDetails)
            Console.WriteLine("{0}: {1}", tab.Id, tab.Name);
    }
    api.ClearSession();
}
```

**VB.NET**

```vbnet
Imports System
Imports Kombine.Flex.Portal.Client.Net45

Using api As New PortalApiClient(New Uri(tenantApiUrl))
    Dim session As ManagerSessionResponse = api.Login(email, password)
    Dim manager As ManagerProfileResponse = api.GetCurrentManager()
    Console.WriteLine(manager.Name)
    If manager.TabDetails IsNot Nothing Then
        For Each tab As ManagerTabResponse In manager.TabDetails
            Console.WriteLine("{0}: {1}", tab.Id, tab.Name)
        Next
    End If
    api.ClearSession()
End Using
```

`Login` gemmer sessionens token i klientens hukommelse. Den rå operation `LoginManager(request)` returnerer kun svaret; brug `api.AccessToken = response.AccessToken`, hvis du anvender den. Adgangskoden gemmes ikke efter login-kaldet. Del eller log ikke tokenet. Klienten sender ikke tokens til en anden tenant eller via redirects.

`ClearSession()` og `Dispose()` fjerner tokenet lokalt. API'et har ingen separat refresh-token eller server-side logout/revokering. En anden kopi af tokenet beholder sit udløbstidspunkt. Et igangværende login kan ikke genskabe en session, der er ryddet i mellemtiden. `Dispose()` stopper nye kald, men afbryder ikke et allerede afsendt kald.

Managerens kontostatus, tabs, KID-afgrænsning og operationsrettigheder kontrolleres fortsat af API'et. Lokal udviklerlogin med numerisk bruger-ID er ikke tilgængelig i klienten.

## Data, filtre og downloads

**C#**

```csharp
GetBankUsersOptions options = new GetBankUsersOptions();
options.PageSize = 25;
options.Sort = "number";
BankUsersResponse page = api.GetBankUsers(bankKid, options);

UserBalancesRequest request = new UserBalancesRequest();
request.UserKids = new string[] { residentKid1, residentKid2 };
UserBalancesResponse balances = api.GetBankUserBalances(bankKid, request);
```

**VB.NET**

```vbnet
Dim options As New GetBankUsersOptions()
options.PageSize = 25
options.Sort = "number"
Dim page As BankUsersResponse = api.GetBankUsers(bankKid, options)

Dim request As New UserBalancesRequest()
request.UserKids = New String() {residentKid1, residentKid2}
Dim balances As UserBalancesResponse = api.GetBankUserBalances(bankKid, request)
```

- Valgfrie filtre ligger i operationens `Options`-klasse. `null` bruger API'ets standard.
- KIDs, cursors og revisioner er opaque strenge og sendes uændret. Fortsæt paging, indtil cursor mangler, også efter en tom side.
- Saldi er nullable `Int64` i mindsteenheder. `null` er ikke nul; forskellige valutaer bevares separat.
- Datoer/tidsstempler er ISO 8601-strenge, så offset og præcision bevares ens i de ældre klientvarianter. Enum-identiteter er heltal; ingen enum-pakke kræves.
- Kald er synkrone og bør køres på en worker-tråd i en grafisk app. Denne variant har samme synkrone kaldemønster som 2.0-klienten.
- JSON har en standardgrænse på 16 MiB, justerbar med `MaxJsonResponseBytes`. `TimeoutMilliseconds` styrer request- og stream-I/O-timeout, som standard 30 sekunder.

Eksporter returnerer `PortalDownload`. Kopiér `download.Stream` i små blokke, og luk download med `using`/`Dispose`. Hele filen bufferes ikke af klienten. Ingen kald gentages automatisk.

## Fejl og HTTPS

`PortalApiException` har `StatusCode`, `Code`, `Headers` og det rå `Response`. `Message`/`ToString()` indeholder ikke response-body; log ikke det rå svar ukritisk.

- 400: ret input. 401: log ind igen. 403: manglende adgang.
- 404: ressourcen er ikke tilgængelig under den aktuelle adgang.
- 409: læs ny revision, før brugeren forsøger en ændring igen.
- 429: respekter `Retry-After`, hvis headeren findes. 503: midlertidig fejl.
- `WebException`/I/O-fejl: netværk, TLS, timeout eller fejl under læsning.
- `InvalidDataException`: mangelfuldt/ugyldigt svar eller overskredet JSON-grænse.

På ældre .NET 4.5-værter kan applikationen eksplicit vælge TLS 1.2 **før første HTTPS-kald**:

**C#**

```csharp
PortalApiClient.EnableTls12();
```

**VB.NET**

```vbnet
PortalApiClient.EnableTls12()
```

Det bruger .NET 4.5's `SecurityProtocolType.Tls12` og påvirker **hele værtsprocessens** `ServicePointManager`. Biblioteket ændrer ikke indstillingen automatisk, maskinens certifikater eller registry. Værts-Windows skal understøtte serverens TLS/cipher suites og stole på certifikatet. Der er ingen usikker fallback; HTTP er kun tilladt på loopback til tests. Se [Microsofts TLS-vejledning](https://learn.microsoft.com/en-us/dotnet/framework/network-programming/tls).

## Byg og test

Åbn `Source/Kombine.Flex.Portal.Client.2012.sln`, byg Release, og start test-EXE'en i `tests/Kombine.Flex.Portal.Client.Net45.Tests/bin/Release`. Testprogrammet bruger syntetiske data og lokale HTTP-fixtures uden produktionslogin eller databaseændringer.

I udviklingsrepoet kører `scripts/Test-PortalClientNet45.ps1` build, tests og ZIP-pakning. Scriptet kræver PowerShell 7 på udviklings-pc'en og anvender Microsofts referencebiblioteker 4.5. Hvis targetingpakken mangler, hentes Microsofts udviklingspakke `Microsoft.NETFramework.ReferenceAssemblies.net45` 1.0.3 til `artifacts`; den bliver ikke en kunde-/runtimeafhængighed og følger ikke med ZIP'en.

`scripts/Generate-PortalClientNet20.py --net45` opdaterer de indtjekkede kontraktklasser. Kunder behøver hverken generator, Python eller NuGet for at bruge DLL'en eller bygge med det normale VS2012-targetingkit.

**Verificeret:** build mod .NET 4.5-referencebiblioteker; kontroller af alle 100 kald, datatyper, login/sessioner, fejl, escaping, downloads og lokale HTTP-forløb. HTTPS-status mod det eksisterende lokale API bestod med TLS 1.2 og normal certifikatkontrol. Testene kørte på den installerede nyere CLR 4-runtime; en uopdateret .NET 4.5-maskine og VS2012-IDE'et er ikke afprøvet.
