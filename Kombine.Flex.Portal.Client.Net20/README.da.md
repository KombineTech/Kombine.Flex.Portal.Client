Version 0.3.2 opdaterer dokumentationen for GetBankUserBalances til den nye databasefrist på 20 sekunder. Felter i kald og svar er uændrede. Giv ekstra tid til transport og adgangskontrol; HTTP 503 returnerer fortsat ingen delvise saldoer.

Version 0.2.5 tilføjer de valgfrie felter latestPostingMs2000 og hasActiveSubscription til GetBankUserBalances. Posteringstidspunktet er et 64-bit antal UTC-millisekunder siden 2000-01-01; nul betyder ingen posteringer. Null eller et manglende felt betyder ukendt, og manglende eller skjulte beboere giver null. Abonnementsstatus bekræfter ikke en betaling. Bevar eksisterende saldohåndtering og rettigheder; se /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 tilføjer `GetUserReceipts` og `GetHostingMetrics` til API-releases, som tilbyder disse operationer. Indlæs kvitteringer efter behov: hent offset 0 og fortsæt med `nextOffset` og samme `revision`. Ved HTTP 409 (`receipts-changed`) skal tidligere sider kasseres, og indlæsningen genstartes ved offset 0. Hold valutaer adskilt og beløb som 64-bit heltal i mindste valutaenhed. Se [kvitteringer](/docs#user-receipts) og [driftsmålinger](/docs#hosting) for rettigheder og grænser.

<!-- api-contract-changelog -->
[Changelog for API-kontrakten (engelsk)](https://api.team.kombine.technology/docs#changelog)

Brug samme tenant og miljø som klienten: tilføj /docs#changelog til API’ets basis-URL. Linket ovenfor bruger Team som offentligt eksempel. Loggen omfatter ændringer i eksisterende endpoints’ request/response, der kan bryde kundekode, ikke interne funktionsrettelser.
<!-- /api-contract-changelog -->

# Flex Portal-klient til .NET Framework 2.0 / Visual Studio 2008

Åbn **`Kombine.Flex.Portal.Client.2008.sln`** i Visual Studio 2008. Biblioteket hedder **`Kombine.Flex.Portal.Client.Net20`** og indeholder typede, synkrone metoder til alle **110 offentlige integrationskald** i API-kontrakten.

Ingen NuGet, SDK-style-projekter, .NET Core eller Kombine-pakker kræves. Den færdige DLL refererer kun til **mscorlib 2.0** og **System 2.0**. Projektet bruger klassisk MSBuild 3.5, `TargetFrameworkVersion=v2.0` og C# 2.0-syntaks. Det er en separat solution; den moderne portal-solution og .NET 8/10-klient ændres ikke af denne variant.

Version 0.3.2 følger den aktuelle beta-kandidat (110 operationer). Skift svarfelterne `icon`, `bankIcon` og `unitIcon` til `iconKid`, `bankIconKid` og `unitIconKid`. Brug ikonruter med eksplicit ikonsæt som beskrevet i [API-changelog](/docs#changelog). Den genererede operation `RenewManagerSession` fornyer en administratorsession, som endnu ikke er udløbet; tildel det returnerede token til samme klient før næste kald. Der er ingen separat refresh-token eller automatisk fornyelse. Windows-appdownloads returnerer streams; klienterne henter hele filer uden range- eller conditional-headere.

Version 0.2.5 tilføjer GetLocationOpeningHours og GetLocationBookingRules. Begge kræver Location Read, Unit Read og adgang til lokationen. Reservationsregler indeholder ren tekst samt ordnede parts med text/isValue til valgfri fremhævning; vis aldrig strengene som HTML. Brug text som fallback for ældre svar. Se /docs#location-opening-hours og /docs#location-booking-rules for rettigheder, eksempler og grænser.

## Brug uden NuGet

1. Pak `Kombine.Flex.Portal.Client.Net20.0.3.2.zip` ud.
2. I kundens projekt: **Add Reference → Browse → Kombine.Flex.Portal.Client.Net20.dll**.
3. Lad XML-filen med samme navn ligge ved DLL'en, så Visual Studio viser IntelliSense.
4. Distribuer DLL'en med applikationen. Kildekode og 2008-solutionen ligger i ZIP'ens `Source`-mappe.

Biblioteket bruger kun HTTPS/JSON mod det eksisterende API. Det har ingen databaseadgang, KID-beregning eller forretningsregler. API'et kontrollerer stadig managerens konto, tabs, KID-afgrænsning og handlingsrettigheder. API'ets funktionalitet er uændret.

## Først tenantens API-URL, derefter login

API-adressen skal oplyses af administratoren. Det er API-domænet, ikke portalens webadresse. Eksempel på formen: `https://api.tenant.kombine.technology/`. Vælg den konkrete tenant, før der indtastes e-mail og adgangskode. URL'en skal slutte med `/`.

Placér using/Imports øverst i filen og resten af koden inde i en metode. Inputvariabler (tenantApiUrl, loginoplysninger og KIDs) kommer fra din applikation. Begge sprog bruger den samme DLL.

**C#**

```csharp
using System;
using Kombine.Flex.Portal.Client.Net20;

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
Imports Kombine.Flex.Portal.Client.Net20

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

`Login` kalder `LoginManager` og gemmer kun tokenet i klientens hukommelse. Den rå metode `LoginManager(request)` returnerer svaret uden automatisk at sætte tokenet. Brug `api.AccessToken = response.AccessToken`, hvis du vælger den rå metode. Adgangskoden gemmes ikke af klienten efter login-kaldet. Log aldrig adgangskoder eller tokens.

Opret en ny klient og et separat login ved tenant-skift. `ClearSession` og `Dispose` fjerner klientens token. API'et har ingen separat refresh-token eller server-side logout/revocation: en anden kopi af et allerede udstedt token beholder sit udløbstidspunkt og er stadig underlagt API'ets adgangskontrol. Et igangværende login kan ikke genoprette sessionen efter `ClearSession` eller `Dispose`.

## Filtre, saldi og downloads

Metoderne hedder som operationerne i API'et, **uden `Async`**. Valgfrie query/header-parametre ligger i en `OperationOptions`-klasse. `null` betyder, at API'ets standard bruges. En overload uden options findes også. Se [OPERATIONS.md](OPERATIONS.md).

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

KIDs, cursors og revisionsværdier er opaque strenge: send dem uændret og skeln mellem store/små bogstaver. Fortsæt paging, indtil cursor mangler, også efter en tom side. Saldi er `long?` i mindste valutaenhed; `null` er ikke nul, og forskellige valutaer må ikke lægges sammen. Batchgrænsen bestemmes af API'et, aktuelt 1–50 beboere fra samme bank.

Datoer og tidsstempler er **ISO 8601-strenge**, da .NET Framework 2.0 ikke har `DateTimeOffset`. Tidszoneoffset og brøkdele af sekunder bevares præcist. Send datofiltre som `yyyy-MM-dd`, eksempelvis `options.From = "2026-09-01"`. Numeriske enum-identiteter er nullable heltal; SDK'et kræver ingen enum-pakke. Ukendte ekstra felter i API-svar ignoreres.

Kør de følgende eksempler med den eksisterende api-instans, som er logget ind. Vælg selectedFormat fra GetBankSettlementPeriod, og angiv downloadPath.

**C#**

```csharp
DownloadBankSettlementOptions options = new DownloadBankSettlementOptions();
options.Format = selectedFormat;
using (PortalDownload download = api.DownloadBankSettlement(bankKid, period, options))
using (System.IO.FileStream file = System.IO.File.Create(downloadPath))
{
    byte[] buffer = new byte[8192];
    int count;
    while ((count = download.Stream.Read(buffer, 0, buffer.Length)) > 0)
        file.Write(buffer, 0, count);
}
```

**VB.NET**

```vbnet
Dim options As New DownloadBankSettlementOptions()
options.Format = selectedFormat
Using download As PortalDownload = api.DownloadBankSettlement(bankKid, period, options)
    Using file As System.IO.FileStream = System.IO.File.Create(downloadPath)
        Dim buffer(8191) As Byte
        Dim count As Integer = download.Stream.Read(buffer, 0, buffer.Length)
        While count > 0
            file.Write(buffer, 0, count)
            count = download.Stream.Read(buffer, 0, buffer.Length)
        End While
    End Using
End Using
```

Downloads streames og skal lukkes med `Dispose`/`using`. JSON bufferes med en standardgrænse på 16 MiB, der kan sættes via `MaxJsonResponseBytes`. Request- og stream-I/O-timeout er som standard 30 sekunder, konfigureret med `TimeoutMilliseconds`. Kald er **blokerende**; brug eksempelvis en `BackgroundWorker` fra en Windows Forms-app. Der er ingen `Task`, `async/await` eller indbygget annullering. `Dispose` stopper nye kald, men annullerer ikke et allerede afsendt kald.

## Fejl

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
```

**VB.NET**

```vbnet
Try
    Dim manager As ManagerProfileResponse = api.GetCurrentManager()
Catch apiError As PortalApiException
    Console.WriteLine("HTTP {0}: {1}", apiError.StatusCode, apiError.Code)
Catch networkError As System.Net.WebException
    Console.WriteLine(networkError.Status)
End Try
```

* 400: ret requesten. 401: log ind igen. 403: kontoen mangler adgang.
* 404: ressourcen er ikke tilgængelig under den aktuelle adgang.
* 409: genindlæs ressourcen/revisionen før en ny ændring.
* 429: respekter `Headers["Retry-After"]`, hvis den findes. 503: midlertidigt utilgængelig.
* `InvalidDataException`: mangelfuldt/ugyldigt svar eller overskredet størrelsesgrænse.

Der udføres **ingen automatiske retries**. Ved et mistet svar på en ændring kan udfaldet være ukendt. Fejlens `Message`/`ToString()` viser ikke svarets indhold; `Response` kan indeholde følsomme oplysninger og skal ikke logges ukritisk. Cookies og redirects er slået fra, og Windows-loginoplysninger sendes ikke automatisk til API'et. Lokal udviklerlogin med bruger-ID og operatørdiagnostik er ikke del af kundeklienten.

## HTTPS på en gammel .NET-installation

At DLL'en er .NET 2.0-kompatibel betyder ikke, at enhver oprindelig Windows/.NET 2.0-installation kan tale moderne HTTPS. Kunden skal have en Windows-/CLR 2.0-installation med TLS 1.2-understøttelse og de nødvendige opdateringer. På nyere Windows leveres den opdaterede CLR 2.0 via .NET Framework 3.5-komponenten. Certifikatkæden skal være betroet af Windows.

Biblioteket ændrer **ikke** registry, certifikatkontrol eller maskinens TLS-indstillinger. Hvis værtsapplikationen vil vælge TLS 1.2 eksplicit på en understøttet installation, kan den gøre det ved opstart:

**C#**

```csharp
PortalApiClient.EnableTls12();
```

**VB.NET**

```vbnet
PortalApiClient.EnableTls12()
```

Det ændrer `ServicePointManager.SecurityProtocol` for **hele processen**, ikke kun klienten, og kaster en fejl, hvis runtime ikke understøtter værdien. Brug OS'ets passende TLS-standarder, hvor de allerede er konfigureret. Der er ingen fallback til usikker HTTP uden for loopback eller til deaktiveret certifikatkontrol. Se [Microsofts TLS-vejledning](https://learn.microsoft.com/en-us/dotnet/framework/network-programming/tls) og [opdateringer til CLR 2.0/.NET 3.5](https://support.microsoft.com/en-us/topic/support-for-tls-system-default-versions-included-in-the-net-framework-3-5-on-windows-8-1-and-windows-server-2012-r2-499ff5ef-a88a-128b-c639-ed038b7d2d5f).

## Byg og test uden NuGet

Åbn solutionen i VS2008, eller kør fra solutionens mappe:

Pak gerne kildekoden ud til en kort sti, f.eks. `C:\Flex20`. De gamle byggeværktøjer har Windows' klassiske stigrænse på 260 tegn, også for genererede filer i `obj`.

```bat
"%WINDIR%\Microsoft.NET\Framework\v3.5\MSBuild.exe" Kombine.Flex.Portal.Client.2008.sln /p:Configuration=Release
tests\Kombine.Flex.Portal.Client.Net20.Tests\bin\Release\Kombine.Flex.Portal.Client.Net20.Tests.exe
```

Der følger en selvstændig .NET 2.0-testapplikation med, uden testframework-pakker. Den kontrollerer runtime/referenceversioner, alle API-ruter, JSON-typer, præcise heltal, Unicode, login/logout, fejl, query-parametre, streaming og redirect-afvisning. Testene bruger simulerede svar og en lokal HTTP-fixture. Den valgfrie `--status https://localhost:7241/` kontrollerer et offentligt statuskald med TLS 1.2; den bruger ingen loginoplysninger.

Udvikling i hovedrepoet: `scripts/Test-PortalClientNet20.ps1` bygger, tester og pakker ZIP-filen. `scripts/Generate-PortalClientNet20.py` regenererer modeller/metoder fra den moderne klients kontrollerede OpenAPI-snapshot. Python kræves **kun ved regenerering hos udvikleren**, aldrig for at bygge eller bruge kundeklienten. Genereret C# ligger i source og kræver ikke en kørende API-server.

Verificeret lokalt med de gamle MSBuild 3.5-værktøjer og kørsel på CLR 2.0.50727. Visual Studio 2008-IDE'en og kundens konkrete Windows-installation er ikke afprøvet her. API-login med en rigtig kundekonto er heller ikke en del af de syntetiske tests.

## Automatisk sessionshåndtering — 0.4.0 (ikke udgivet)

Behold én `PortalSession` pr. API-adresse og konto/login. Klienter oprettet fra den fornyer ved brug kort før udløb; samtidige login og fornyelser samles. Der kører ingen baggrundstimer. Dispose af en klient logger ikke den fælles session ud; brug `session.ClearSession()`. Et igangværende login kan ikke genoprette en ryddet session. Log aldrig tokens eller adgangskoder.

Interaktive programmer kalder `Login`/`LoginAsync` én gang. Udløb kræver nyt login. Webprogrammer kan bruge `Restore` med et betroet token og udløbstid fra deres beskyttede cookie, kalde `Renew`/`RenewAsync` efter verificeret brugeraktivitet og derefter opdatere cookien. Statuskontrol i baggrunden skal bruge en separat anonym klient. Fornyelse giver ingen ekstra API-rettigheder.

Programmer med en konfigureret konto kan give `PortalSession` en callback: `PortalCredentialsProvider` på ældre frameworks eller `Func<CancellationToken, Task<PortalCredentials>>` på moderne .NET. Den returnerer `PortalCredentials(email, password)` fra programmets aktuelle sikre konfiguration, når nyt login er nødvendigt. Biblioteket gemmer ikke den returnerede adgangskode. Browserbaserede brugerlogin behøver ingen sådan callback.

Brug kun `ExecuteRead`/`ExecuteReadAsync` til udtrykkeligt sikre læsninger: HTTP 401 rydder den berørte session og tillader ét nyt login og ét genforsøg, hvis en callback findes. HTTP 403, 409, 429, 503, netværksfejl og timeout gentages ikke. Almindelige klientmetoder gentager aldrig automatisk forretningskald, heller ikke skrivninger. Uden callback giver udløbet/ryddet session `InvalidOperationException`; afvisning fra API'et bevarer status og kode i `PortalApiException`. Bed da brugeren logge ind igen; lav ikke en uendelig løkke.

C# og VB.NET bruger samme DLL. De interaktive eksempler modtager loginoplysninger fra kalderen:

```csharp
using Kombine.Flex.Portal.Client.Net20;

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
Imports Kombine.Flex.Portal.Client.Net20

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
