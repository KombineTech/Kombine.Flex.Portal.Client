Version 0.4.4: GetLocations kræver nu fields=vismaCustNo,bankActivationCode,locationActivationCode for at bevare de tidligere valgfrie værdier; accepter null for fravalgte felter. Behold samme fields under sideskift, og start gamle cursors forfra. Nye forslag til beboernumre er skrivebeskyttede og reserverer ikke et nummer. Aktiveringssvar indeholder qrCodeDataV1 og qrCodeDataV2 (fem værdier med 30-bit støj/kontrolsum); behandl begge som legitimationsoplysninger. Se /docs#changelog for migrering og /docs for rettigheder og fejlhåndtering.

ersion 0.4.4 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Flex Portal-klient til Windows CE / Windows Mobile

`Kombine.Flex.Portal.Client.Compact20.dll` er et selvstændigt bibliotek til **.NET Compact Framework 2.0**. Det indeholder alle 110 offentlige API-operationer med typede request-/response-klasser. Se [OPERATIONS.md](OPERATIONS.md).

Ingen NuGet-pakker, databaseforbindelser, Kombine-biblioteker eller reference til desktop-klienten. Kun Compact Frameworks egne `mscorlib` og `System`, version 2.0, kræves. Biblioteket indeholder kommunikation og serialisering; forretningsregler og adgangskontrol ligger fortsat i API'et.

Version 0.4.4 følger den aktuelle beta-kandidat (110 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.

## Tilføj biblioteket

1. Opret/åbn et **Smart Device**-projekt i Visual Studio 2008, målrettet .NET Compact Framework 2.0.
2. Vælg **Add Reference → Browse**, og vælg `Kombine.Flex.Portal.Client.Compact20.dll` fra ZIP-pakkens rod.
3. Behold XML-filen ved siden af DLL'en for IntelliSense. Installer den korrekte CF 2.0-runtime til enhedens processor, hvis den ikke er i ROM.

Dette er ikke desktop .NET Framework 2.0 eller .NET Standard 2.0. Brug ikke `Client.Net20.dll` på CE/Mobile. Koden er ren managed AnyCPU og bruger ingen ARM-/x86-specifikke native biblioteker; enhedens egen runtime og netværksstack skal være til stede.

## Vælg tenant, forbind og log ind

Brug tenantens **API-adresse**, ikke portalens webadresse. Adressen er fast for klientens levetid. Ved skift af tenant oprettes en ny klient, og der logges ind igen.

Placér using/Imports øverst i filen og resten af koden inde i en metode. Inputvariabler (tenantApiUrl, loginoplysninger og KIDs) kommer fra din applikation. Begge sprog bruger den samme DLL.

**C#**

```csharp
using System;
using Kombine.Flex.Portal.Client.Compact20;

using (PortalApiClient api = new PortalApiClient(new Uri(tenantApiUrl)))
{
    api.TimeoutMilliseconds = 30000;
    ApiStatusResponse status = api.GetPortalStatus();
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
Imports Kombine.Flex.Portal.Client.Compact20

Using api As New PortalApiClient(New Uri(tenantApiUrl))
    api.TimeoutMilliseconds = 30000
    Dim status As ApiStatusResponse = api.GetPortalStatus()
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

Kald er synkrone. Kør dem på en worker-tråd i en grafisk applikation, og opdater brugerfladen på dens UI-tråd. Behold klienten mellem kald for at genbruge bearer-sessionen. `LoginManager(request)` er den rå operation; `Login(email, password)` gemmer desuden token i klientens hukommelse. Biblioteket gemmer ikke adgangskoden, og der er ingen automatisk lagring på enheden, token-refresh eller automatiske retries.

## HTTPS skal kontrolleres på enheden

**Et build mod CF 2.0 er ikke en garanti for forbindelse til det nuværende HTTPS-API.** HTTPS bruger enhedens `HttpWebRequest` og dens CE/Mobile-netværksstack. TLS-version, cipher suites, certifikatlager, korrekt ur og eventuel SNI-understøttelse afhænger af OS/OEM-image. Mange gamle enheder kan derfor kræve en opdatering fra producenten, før en direkte forbindelse er mulig.

Biblioteket tilføjer ikke TLS 1.2 til en gammel enhed. Desktop-klientens `EnableTls12()` findes ikke her. HTTPS- og certifikatkontrol bevares; forbindelsesfejl giver ingen fallback til usikker HTTP eller til at acceptere ugyldige certifikater. Kun loopback-HTTP er tilladt til syntetiske tests.

Kontroller først `GetPortalStatus()` på den konkrete enhed mod den ønskede tenant. Hvis TLS-forhandlingen fejler, skal OS-/OEM-understøttelsen afklares, før login afprøves. Der er ikke ændret noget i API'et eller dets TLS-konfiguration for at understøtte denne klient.

Microsofts [vejledning om deling af kode mellem desktop og Compact Framework](https://learn.microsoft.com/en-us/archive/msdn-magazine/2007/july/share-code-write-code-once-for-both-mobile-and-desktop-apps) forklarer behovet for et særskilt device-build. Microsofts [TLS-opdatering til Windows Embedded Compact 7](https://support.microsoft.com/en-gb/topic/update-to-add-support-for-tls-1-1-and-tls-1-2-in-windows-embedded-compact-7-608b4129-2081-ddde-d078-a94665853b9b) gælder netop Compact 7; den dokumenterer ikke TLS 1.2-understøttelse på vilkårlige CE 5/6- eller Windows Mobile-enheder.

## Datatyper og hukommelse

- KIDs er uændrede strenge. Klienten udleder ikke tenant eller rettigheder af dem.
- Enum-værdier sendes som heltal. Der er ingen afhængighed af en enum-NuGet-pakke.
- Datoer og tidsstempler er ISO 8601-strenge, så tidszone og præcision bevares.
- Saldi er nullable `Int64` i mindsteenheder; valutaer og manglende saldi bevares separat.
- Valgfrie query-parametre ligger i fx `GetBankUsersOptions`. Brug små sider på håndholdte enheder.
- JSON er som standard begrænset til **2 MiB** pr. request/response. `MaxJsonResponseBytes` kan justeres. Den grænse er ikke det samlede RAM-forbrug; bytes, tekst og objekter bruger ekstra hukommelse.
- Eksporter returnerer `PortalDownload`. Kopiér `Stream` i små blokke og kald altid `Dispose()`; hele filen indlæses ikke i hukommelsen.
- `TimeoutMilliseconds` er en samlet HTTP-deadline, også under læsning af body/download. Øg den eksplicit for lange eksporter. CF 2.0 mangler `ReadWriteTimeout`, så klienten afbryder requesten med en timer. Den konkrete enheds netværksdriver skal også kunne afbryde blokerende I/O.

## Fejl og rettigheder

**C#**

```csharp
try
{
    ManagerProfileResponse manager = api.GetCurrentManager();
}
catch (PortalApiException apiError)
{
    Console.WriteLine("HTTP {0}: {1}", apiError.StatusCode, apiError.Code);
}
catch (System.Net.WebException networkError)
{
    Console.WriteLine(networkError.Status);
}
catch (PortalProtocolException protocolError)
{
    Console.WriteLine(protocolError.Message);
}
```

**VB.NET**

```vbnet
Try
    Dim manager As ManagerProfileResponse = api.GetCurrentManager()
Catch apiError As PortalApiException
    Console.WriteLine("HTTP {0}: {1}", apiError.StatusCode, apiError.Code)
Catch networkError As System.Net.WebException
    Console.WriteLine(networkError.Status)
Catch protocolError As PortalProtocolException
    Console.WriteLine(protocolError.Message)
End Try
```

`PortalProtocolException` erstatter desktop-klientens `InvalidDataException`, som ikke findes i CF 2.0. Andre I/O-fejl kan opstå under læsning. Log ikke tokens, adgangskoder eller rå svar med persondata. Adgang kræver stadig en aktiv manager, tilladte tabs, KIDs og operationsrettigheder. Lokal numerisk udviklerlogin findes ikke i klienten.

## Byg og test

Pak kildekoden ud i en **kort sti**, fx `C:\FlexCF`, og åbn `Source\Kombine.Flex.Portal.Client.Compact2008.sln` i Visual Studio 2008 Professional med Smart Device-værktøjer og CF 2.0-SDK. Gamle buildværktøjer har en grænse for stilængder. Ingen restore eller generator kræves hos kunden.

Solutionen indeholder:

- `Kombine.Flex.Portal.Client.Compact20`: det egentlige CF 2.0-bibliotek.
- `Kombine.Flex.Portal.Client.Compact20.Tests`: et CF 2.0-testprogram til enheden. Kopiér filerne fra ZIP-mappen `DeviceTests` til samme mappe på enheden, og start EXE'en. Programmet bruger kun syntetiske data og viser resultatet på skærmen.
- `Compact20.DesktopHost`: samme kontrakt-/JSON-tests kørt på desktop CLR 2.0, plus lokale HTTP-fixtures. Dette er en testvært, ikke en erstatning for CE-runtimeprøven.

I udviklingsrepoet bygger/tester/pakker `scripts/Test-PortalClientCompact20.ps1`. Scriptet kræver PowerShell 7 på udviklings-pc'en; kunder og enheder behøver det ikke. `scripts/Generate-PortalClientNet20.py --compact` opdaterer de indtjekkede kontraktklasser fra det fælles OpenAPI-snapshot.

**Verificeret:** Release-build med de originale VS2008/MSBuild 3.5-værktøjer og CF 2.0-referencebiblioteker; alle 110 operationer og syntetiske kontroller på desktop-testværten. Tests kontrollerer også, at DLL'en refererer til Compact Frameworks assembly-identiteter. Device-testprogrammet er bygget mod CF 2.0. **Ikke verificeret:** kørsel eller HTTPS på en fysisk CE/Mobile-enhed eller emulator. Der er ikke udført rigtige login eller databaseændringer.

## Automatisk sessionshåndtering — 0.4.4 (ikke udgivet)

Behold én `PortalSession` pr. API-adresse og konto/login. Klienter oprettet fra den fornyer ved brug kort før udløb; samtidige login og fornyelser samles. Der kører ingen baggrundstimer. Dispose af en klient logger ikke den fælles session ud; brug `session.ClearSession()`. Et igangværende login kan ikke genoprette en ryddet session. Log aldrig tokens eller adgangskoder.

Interaktive programmer kalder `Login`/`LoginAsync` én gang. Udløb kræver nyt login. Webprogrammer kan bruge `Restore` med et betroet token og udløbstid fra deres beskyttede cookie, kalde `Renew`/`RenewAsync` efter verificeret brugeraktivitet og derefter opdatere cookien. Statuskontrol i baggrunden skal bruge en separat anonym klient. Fornyelse giver ingen ekstra API-rettigheder.

Programmer med en konfigureret konto kan give `PortalSession` en callback: `PortalCredentialsProvider` på ældre frameworks eller `Func<CancellationToken, Task<PortalCredentials>>` på moderne .NET. Den returnerer `PortalCredentials(email, password)` fra programmets aktuelle sikre konfiguration, når nyt login er nødvendigt. Biblioteket gemmer ikke den returnerede adgangskode. Browserbaserede brugerlogin behøver ingen sådan callback.

Brug kun `ExecuteRead`/`ExecuteReadAsync` til udtrykkeligt sikre læsninger: HTTP 401 rydder den berørte session og tillader ét nyt login og ét genforsøg, hvis en callback findes. HTTP 403, 409, 429, 503, netværksfejl og timeout gentages ikke. Almindelige klientmetoder gentager aldrig automatisk forretningskald, heller ikke skrivninger. Uden callback giver udløbet/ryddet session `InvalidOperationException`; afvisning fra API'et bevarer status og kode i `PortalApiException`. Bed da brugeren logge ind igen; lav ikke en uendelig løkke.

C# og VB.NET bruger samme DLL. De interaktive eksempler modtager loginoplysninger fra kalderen:

```csharp
using Kombine.Flex.Portal.Client.Compact20;

void Example(Uri apiUrl, string email, string password)
{
    PortalSession session = new PortalSession(apiUrl);
    session.Login(email, password);
    using (PortalApiClient api = session.CreateClient())
    {
        ManagerProfileResponse profile = api.GetCurrentManager();
        // Keep this client for later user actions; it renews on use.
    }
    session.ClearSession();
}
```

```vbnet
Imports Kombine.Flex.Portal.Client.Compact20

Sub Example(ByVal apiUrl As Uri, ByVal email As String, ByVal password As String)
    Dim session As New PortalSession(apiUrl)
    session.Login(email, password)
    Using api As PortalApiClient = session.CreateClient()
        Dim profile As ManagerProfileResponse = api.GetCurrentManager()
        ' Keep this client for later user actions; it renews on use.
    End Using
    session.ClearSession()
End Sub
```
