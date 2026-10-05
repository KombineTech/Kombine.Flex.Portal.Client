Version 0.3.3 bruger det [officielle Kombine-logo](https://static.kombine.services/kombinelogotext1/black.svg), bevaret som logo.svg og gengivet som icon.png til NuGet. API-kontrakter og klientens funktion er uændrede.

Version 0.3.2 tilføjer det officielle Kombine-logo, udgiveroplysninger og virksomhedens kontaktoplysninger. API-kontrakter og klientens funktion er uændrede.

Version 0.3.1 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — .NET-klient

Typet HTTPS/JSON-klient til alle 110 offentlige API-operationer. Ingen afhængigheder til andre Kombine-pakker, databaseadgang eller forretningslogik. Den primære, detaljerede reference er [den engelske vejledning](README.md); alle operationer fremgår af [OPERATIONS.md](OPERATIONS.md).

Version 0.3.2 følger den aktuelle API-kontrakt (110 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.

## Installation og platforme

Produktionsudgaver publiceres på [nuget.org](https://www.nuget.org/packages/Kombine.Flex.Portal.Client). Installér den publicerede version med kommandoen nedenfor og nuget.org som pakkekilde. Hvis en beta-version endnu ikke findes dér, lægges den kontrollerede Kombine.Flex.Portal.Client.0.4.0.nupkg fra API-dokumentationen i en lokal NuGet-kilde.

```powershell
dotnet nuget add source ./packages --name flex-local
dotnet add package Kombine.Flex.Portal.Client --version 0.4.0
```

.NET Framework 4.7.2/4.8/4.8.1 bruger netstandard2.0 med Microsoft System.Text.Json 10.0.12 og dets afhængigheder. .NET 8/9 bruger net8.0; .NET 10 bruger net10.0 uden ekstra pakker. Behold nuget.org eller en godkendt mirror til Microsoft-afhængigheder. Framework-programmer kan have brug for automatiske binding redirects og System.Net.Http-reference ved egen HttpClient. Framework-tests er bygget mod 4.7.2/4.8 og kørt på installeret 4.8.1; en oprindelig 4.7.2-installation er ikke afprøvet.

## Forbindelse og login

Vælg først tenantens HTTPS API-URL, afsluttet med /, derefter e-mail og adgangskode. Brug API-adressen, ikke portalens adresse. Opret ny klient og nyt login ved skift af tenant eller miljø.

```csharp
using Kombine.Flex.Portal.Client;
using (var api = new PortalApiClient(new Uri(tenantApiUrl)))
{
    await api.LoginAsync(email, password, cancellationToken);
    var manager = await api.GetCurrentManagerAsync(cancellationToken);
    if (manager.TabDetails != null)
        foreach (var tab in manager.TabDetails)
            Console.WriteLine($"{tab.Id}: {tab.Name}");
    api.ClearSession();
}
```

LoginAsync gemmer kun token i hukommelsen. LoginManagerAsync er det rå kald og gemmer ikke token automatisk. ClearSession/Dispose glemmer token; API'et har ingen separat refresh-token eller server-side logout/revokering. Andre kopier kan stadig virke indtil udløb eller afvisning ved kontokontrol. Gem eller log aldrig adgangskoder/tokens ukritisk.

## Kald, data og fejl

Metoderne hedder OperationIdAsync og modtager cancellationToken. KIDs, cursors og revisioner er uændrede opaque strenge. Fortsæt paging indtil cursor mangler, også efter en tom side. GetBankUserBalancesAsync accepterer 1–50 beboere fra samme bank; saldi er heltal i mindsteenheder, null er ikke nul, og valutaer skal holdes adskilt. API'et kontrollerer konto, tabs, Kids, retentionsregler og rettigheder. Lokal udviklerlogin og diagnoser er ikke med.

PortalApiException har StatusCode og Code. 400: ret input; 401: nyt login; 403: ingen adgang; 404: utilgængelig; 409: genindlæs revision; 429/503: respekter Retry-After. HttpRequestException betyder netværks-/TLS-fejl; OperationCanceledException betyder annullering/timeout. Der er ingen automatiske retries; en ændring kan være gennemført selv om svaret gik tabt. Ugyldigt JSON er en fejl, ikke tomme data. Typed fejl har Result; rå Response kan indeholde persondata og udelades fra Message/ToString.

Downloads er streams, der skal lukkes med using/Dispose. URI-konstruktøren ejer HttpClient, bruger 30 sekunders timeout og afviser cookies/redirects. HTTPS bruger normal certifikatkontrol; HTTP er kun tilladt på loopback til tests. Ved egen HttpClient skal BaseAddress være fast med afsluttende /, redirects/cookies slået fra og normal TLS-kontrol bevaret. Transporten ejes da af kalderen. Brug ikke delt Authorization-header.

## Vedligeholdelse

scripts/Update-PortalClient.ps1 opdaterer fra OpenAPI-snapshottet og den fastlåste NSwag-version. Genereret kode følger med; kunder behøver ingen generator eller privat feed. scripts/Test-PortalClients.ps1 bygger og tester klient/app-projekter samt NuGet-pakken i en separat forbruger med frisk pakkecache og syntetiske data. Se den engelske reference for detaljer.

## Udgiver og support

![Kombine](https://raw.githubusercontent.com/KombineTech/Kombine.Flex.Portal.Client/5c87078b8a0b2439a4e68a0b432537d458dd31f4/Kombine.Flex.Portal.Client/icon.png)

**Kombine Technology ApS**  
Finlandsvej 61 st. th.  
DK-7100 Vejle, Danmark  
CVR: 44637928  
+45 76 43 70 20  
[support@kombinetech.com](mailto:support@kombinetech.com)  
[kombinetech.com](https://kombinetech.com/)

## Automatisk sessionshåndtering — 0.4.0 (ikke udgivet)

`SendRequestAsync` understøtter også downloads, streaming og operationer tilføjet efter den medfølgende genererede kontrakt. Den kontrollerer, at kaldet holder sig til klientens faste API-adresse, bevarer applikationens headers og gentager aldrig kald. Den kaldende kode ejer request og response. Brug `HttpCompletionOption.ResponseHeadersRead` til streaming. Applikationen kan bruge egne svarmodeller med denne transport; API'et håndhæver fortsat rettighederne.

Behold én `PortalSession` pr. API-adresse og konto/login. Klienter oprettet fra den fornyer ved brug kort før udløb; samtidige login og fornyelser samles. Der kører ingen baggrundstimer. Dispose af en klient logger ikke den fælles session ud; brug `session.ClearSession()`. Et igangværende login kan ikke genoprette en ryddet session. Log aldrig tokens eller adgangskoder.

Interaktive programmer kalder `Login`/`LoginAsync` én gang. Udløb kræver nyt login. Webprogrammer kan bruge `Restore` med et betroet token og udløbstid fra deres beskyttede cookie, kalde `Renew`/`RenewAsync` efter verificeret brugeraktivitet og derefter opdatere cookien. Statuskontrol i baggrunden skal bruge en separat anonym klient. Fornyelse giver ingen ekstra API-rettigheder.

Programmer med en konfigureret konto kan give `PortalSession` en callback: `PortalCredentialsProvider` på ældre frameworks eller `Func<CancellationToken, Task<PortalCredentials>>` på moderne .NET. Den returnerer `PortalCredentials(email, password)` fra programmets aktuelle sikre konfiguration, når nyt login er nødvendigt. Biblioteket gemmer ikke den returnerede adgangskode. Browserbaserede brugerlogin behøver ingen sådan callback.

Brug kun `ExecuteRead`/`ExecuteReadAsync` til udtrykkeligt sikre læsninger: HTTP 401 rydder den berørte session og tillader ét nyt login og ét genforsøg, hvis en callback findes. HTTP 403, 409, 429, 503, netværksfejl og timeout gentages ikke. Almindelige klientmetoder gentager aldrig automatisk forretningskald, heller ikke skrivninger. Uden callback giver udløbet/ryddet session `InvalidOperationException`; afvisning fra API'et bevarer status og kode i `PortalApiException`. Bed da brugeren logge ind igen; lav ikke en uendelig løkke.

C# og VB.NET bruger samme DLL. De interaktive eksempler modtager loginoplysninger fra kalderen:

```csharp
using Kombine.Flex.Portal.Client;

async Task Example(Uri apiUrl, string email, string password)
{
    var session = new PortalSession(apiUrl);
    await session.LoginAsync(email, password);
    using (var api = await session.CreateClientAsync())
    {
        var profile = await api.GetCurrentManagerAsync();
        // Keep this client for later user actions; it renews on use.
    }
    session.ClearSession();
}
```

```vbnet
Imports Kombine.Flex.Portal.Client

Async Function Example(apiUrl As Uri, email As String, password As String) As Task
    Dim session = New PortalSession(apiUrl)
    Await session.LoginAsync(email, password)
    Using api = Await session.CreateClientAsync()
        Dim profile = Await api.GetCurrentManagerAsync()
        ' Keep this client for later user actions; it renews on use.
    End Using
    session.ClearSession()
End Function
```
