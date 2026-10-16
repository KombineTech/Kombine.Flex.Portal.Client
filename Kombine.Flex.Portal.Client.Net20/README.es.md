## Fotos recientes de la cámara · 0.8.2

Añade `GetPublicRecentCameraPhotos` y `GetPublicCameraThumbnail`. Estas operaciones públicas no requieren inicio de sesión y están vinculadas al tenant del sitio. La lista devuelve hasta diez fotos con URL temporales de miniaturas y rutas del portal. Las miniaturas son públicas; los originales y metadatos siguen protegidos. Abrir el espacio requiere los permisos normales del administrador. Gestione 503 si la lista no está disponible y 400/404 para miniaturas no válidas, caducadas o ausentes. Consulte [widgets públicos](/docs#public-widgets).

## Tiempo de la ubicación · 0.8.2

La versión 0.8.2 incluye las 151 operaciones y añade `GetLocationWeather` para un KID canónico de ubicación. Reutilice la sesión del administrador. La API exige Tab asignado, Bank Read, Location Read, ámbito autorizado y ubicación/banco visibles. Resuelve coordenadas guardadas o la dirección de la ubicación; el cliente nunca envía claves del proveedor ni coordenadas. Compruebe `status`: `Available` contiene `current`; `LocationUnknown` y `Unavailable` no contienen mediciones. Los valores desconocidos son null, nunca cero. Temperatura en Celsius, viento en m/s, precipitación en mm, humedad en porcentaje y horas UTC. La posición obtenida de la dirección puede ser aproximada. Muestre: Weather data by Open-Meteo, CC BY 4.0. Gestione HTTP 400/401/403/404/503 normalmente y reintente de forma deliberada; un fallo del proveedor también puede devolver HTTP 200 con `Unavailable`. Consulte [tiempo de la ubicación](/docs#location-weather).

```csharp
LocationWeatherResponse weather = api.GetLocationWeather(locationKid);
if (weather.Status == "Available" && weather.Current != null)
    Console.WriteLine(weather.Current.TemperatureCelsius);
```

```vbnet
Dim weather As LocationWeatherResponse = api.GetLocationWeather(locationKid)
If weather.Status = "Available" AndAlso weather.Current IsNot Nothing Then
    Console.WriteLine(weather.Current.TemperatureCelsius)
End If
```

## Camera1 · 0.8.0

La versión 0.8.0 incluye las 148 operaciones públicas, incluida Camera1. Llame a PrepareCameraCapture con SHA-256 y longitud exactos del original, fecha UTC, KID del recurso y objeto de sensores; cargue los mismos bytes con uploadToken. Live Photos requiere además la longitud/hash y el MOV original asociado. Conserve el token y los bytes para un reintento deliberado; no hay reintentos automáticos. Aumente el plazo para procesar vídeo. La API exige Camera1 y permisos Read/Write del recurso exacto. Las listas pueden estar degradadas o devolver páginas vacías con nextCursor; continúe hasta que no haya cursor. Descargue por la API; Range puede devolver HTTP 206. Consulte /docs#camera-captures para límites y errores.

```csharp
// uploadToken comes from PrepareCameraCapture; originalPath points to those exact bytes.
using (System.IO.FileStream original = System.IO.File.OpenRead(originalPath))
{
    PortalMultipart body = new PortalMultipart();
    body.AddField("uploadToken", uploadToken);
    body.AddFile("original", System.IO.Path.GetFileName(originalPath), original);
    CameraSaveResponse saved = api.SaveCameraCapture(body);
}
```

```vbnet
' uploadToken comes from PrepareCameraCapture; originalPath contains the same bytes.
Using original As System.IO.FileStream = System.IO.File.OpenRead(originalPath)
    Dim body As New PortalMultipart()
    body.AddField("uploadToken", uploadToken)
    body.AddFile("original", System.IO.Path.GetFileName(originalPath), original)
    Dim saved As CameraSaveResponse = api.SaveCameraCapture(body)
End Using
```

Streams remain caller-owned. Use seekable streams, rewind and create a new multipart body before retrying. For Live Photos, add a second file named `motion`. Maximum multipart body: 140 MiB; text fields: 512 KiB each.

Todos los cambios de rol de administrador requieren Read y Write tanto de Tabs como de Kids. Gestione missing-tabs-read, missing-tabs-write, missing-kids-read y missing-kids-write (HTTP 403).

GetTerminals usa el ComputerName comunicado para el nombre, el filtro y la ordenación; los nombres ausentes están vacíos. Solicite fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight para los datos del terminal. Son cadenas, null si no se seleccionan y vacías si faltan. Mantenga fields al paginar y reinicie los cursores anteriores. Cada fila incluye el nombre de la ubicación. Consulte /docs#changelog para todos los requisitos de migración.

La versión 0.8.0 incluye 148 operaciones. GetUnits añade el directorio de unidades autorizado: mantenga filtros y fields al paginar y reinicie ante invalid-cursor. Los roles de administrador requieren las nueve categorías de expectedFlags, incluidas Tabs y Kids; gestione sus permisos independientes y las respuestas 403. Se eliminan las asignaciones de acceso de servicios: deje de enviar esas solicitudes y de leer el objeto access. Las partes del logotipo se indican en la ruta antes del color, no en parámetros de consulta. UserBalance sigue siendo compatible. Consulte /docs#changelog para la migración y /docs#unit-directory para paginación y ejemplos.

Versión 0.8.0: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.

La versión 0.8.0 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.

La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

La versión 0.2.5 añade `GetUserReceipts` y `GetHostingMetrics` para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda: solicite offset 0 y continúe con `nextOffset` y la misma `revision`. Ante HTTP 409 (`receipts-changed`), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte [recibos](/docs#user-receipts) y [métricas](/docs#hosting) para los permisos y límites.

<!-- api-contract-changelog -->
[Changelog del contrato de la API (inglés)](https://api.team.kombine.technology/docs#changelog)

Use el mismo tenant y entorno que su cliente: añada /docs#changelog a la URL base de la API. El enlace anterior usa Team como ejemplo público. Este registro cubre cambios de solicitud/respuesta de endpoints existentes que pueden romper el código del cliente, no correcciones internas de funciones.
<!-- /api-contract-changelog -->

# Cliente Flex Portal para .NET Framework 2.0

`Kombine.Flex.Portal.Client.Net20` ofrece métodos síncronos y tipados para las **151 operaciones públicas**. No requiere NuGet, bibliotecas Kombine, acceso a bases de datos ni cálculos de KID. Las reglas de negocio y los permisos se aplican en la API. Consulte [OPERATIONS.md](OPERATIONS.md).

La versión 0.8.2 corresponde al candidato beta actual (151 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.

## Instalación

Extraiga `Kombine.Flex.Portal.Client.Net20.0.8.2.zip` y seleccione **Add Reference → Browse → Kombine.Flex.Portal.Client.Net20.dll**. Conserve el XML junto a la DLL para IntelliSense y distribuya la DLL con su aplicación. `Source` contiene el código y `Kombine.Flex.Portal.Client.2008.sln`. La DLL solo referencia mscorlib y System 2.0; es un proyecto clásico independiente.

## Primero la URL de la API, después las credenciales

Solicite al administrador la URL HTTPS de la API del tenant, terminada en `/`; no use la dirección del portal. Por ejemplo, `https://api.team.kombine.technology/`. Seleccione el tenant antes de introducir correo y contraseña. Al cambiar de tenant o entorno, cree otro cliente e inicie sesión de nuevo.

Coloque using/Imports al principio del archivo y el resto del código dentro de un método. Las variables de entrada (tenantApiUrl, credenciales y KIDs) proceden de su aplicación. Ambos lenguajes usan la misma DLL.

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

`Login` conserva el token en memoria. `LoginManager(request)` solo devuelve la respuesta; con esa operación debe asignar `api.AccessToken = response.AccessToken`. No se conserva la contraseña. `ClearSession` y `Dispose` eliminan el token local e impiden que un inicio de sesión pendiente lo restablezca. No existe renovación ni cierre de sesión/revocación en el servidor: otras copias siguen sujetas a caducidad y controles de cuenta. Nunca registre credenciales. El inicio de sesión local por ID y los diagnósticos no forman parte del cliente.

## Datos y descargas

Los métodos conservan los identificadores de operación, sin Async. Los filtros opcionales se encuentran en la clase Options correspondiente; null usa el valor predeterminado de la API. `GetBankUsersOptions` permite PageSize, Sort y Cursor; `UserBalancesRequest.UserKids` contiene los KIDs para `GetBankUserBalances`.

- Conserve KIDs, cursores y revisiones exactamente, incluidas las mayúsculas. Continúe hasta que no haya cursor, incluso después de una página vacía.
- Los saldos son Int64 anulables en unidades monetarias menores. Null no es cero; mantenga separadas las monedas. Se admiten 1–50 residentes del mismo banco por lote.
- Las fechas son cadenas ISO 8601 con su zona y precisión. Los filtros de fecha usan yyyy-MM-dd; los enums son enteros. Los campos adicionales desconocidos se ignoran.
- Las llamadas son bloqueantes: use un hilo de trabajo en interfaces gráficas y actualice la pantalla en su hilo de interfaz. Dispose impide nuevas llamadas, pero no cancela las que ya están en curso.
- JSON está limitado a **16 MiB** por defecto, configurable con MaxJsonResponseBytes. El uso total de memoria puede ser mayor.
- PortalDownload proporciona Stream. Copie en bloques pequeños y use siempre Dispose; no se carga todo el archivo en memoria. `TimeoutMilliseconds` configura los tiempos de espera de la solicitud y de E/S del stream, normalmente 30 segundos; no es un plazo total para una descarga larga.

## Errores y permisos

PortalApiException expone StatusCode, Code, Headers y Response. Message/ToString no incluyen el cuerpo; Response puede contener datos personales. 400: corrija la entrada; 401: inicie sesión; 403: acceso denegado; 404: recurso no disponible para el alcance actual; 409: recargue la revisión; 429/503: respete Retry-After y espere. WebException y errores de E/S indican problemas de red, TLS, tiempo de espera o lectura. InvalidDataException indica JSON inválido o demasiado grande.

No hay reintentos automáticos. Si se pierde la respuesta de una modificación, su resultado puede ser desconocido. Cookies y redirecciones están desactivadas y no se envían credenciales de Windows automáticamente. La API sigue comprobando cuenta, pestañas, KIDs, retención y permisos de operación.

## Compatibilidad HTTPS

Windows y el runtime deben admitir TLS y los algoritmos del servidor, y confiar en su certificado. En una instalación compatible, la aplicación puede llamar a `PortalApiClient.EnableTls12()` antes de la primera solicitud HTTPS. Cambia `ServicePointManager.SecurityProtocol` para **todo el proceso**, nunca de forma automática. No modifica el registro ni los certificados. No hay alternativa insegura; HTTP solo se admite en loopback para pruebas. Consulte la [guía TLS de Microsoft](https://learn.microsoft.com/en-us/dotnet/framework/network-programming/tls).

Una instalación original de .NET 2.0 sin actualizaciones puede no admitir HTTPS moderno. En Windows reciente, el componente .NET Framework 3.5 proporciona un CLR 2.0 actualizado. `EnableTls12()` genera un error si el runtime no admite el valor.

## Compilación y pruebas

Use Visual Studio 2008 o MSBuild 3.5. El proyecto emplea sintaxis C# 2.0 y TargetFrameworkVersion=v2.0. Extraiga el código en una ruta corta, como C:\Flex20, por el límite clásico de longitud de rutas. El ejecutable de pruebas es independiente y usa respuestas sintéticas y HTTP local; no necesita un framework de pruebas. La opción `--status https://localhost:7241/` comprueba HTTPS anónimo con TLS 1.2.

Verificado con MSBuild 3.5 y CLR 2.0.50727. No se probaron el IDE de VS2008, cada instalación de Windows del cliente ni inicios de sesión reales.

En el repositorio de desarrollo, `scripts/Test-PortalClientNet20.ps1` compila, prueba y empaqueta el ZIP; PowerShell 7 no es necesario en el equipo cliente. `scripts/Generate-PortalClientNet20.py` regenera los contratos desde OpenAPI. Para usar o compilar la DLL, el cliente no necesita Python, generadores ni una API en ejecución. El idioma principal de la documentación es inglés; se incluyen alternativas en danés y español.

## Gestión automática de sesiones — 0.8.2 (sin publicar)

Mantenga una `PortalSession` por dirección API y cuenta/inicio de sesión. Los clientes creados a partir de ella renuevan al usarse poco antes de caducar; la autenticación simultánea se coordina. No hay temporizador en segundo plano. Dispose del cliente no cierra la sesión compartida; use `session.ClearSession()`. La autenticación pendiente no puede restaurar una sesión borrada. No registre tokens ni contraseñas.

Las aplicaciones interactivas llaman a `Login`/`LoginAsync` una vez. Una sesión caducada requiere otro inicio de sesión. Una aplicación web puede usar `Restore` con el token y vencimiento fiables de su cookie protegida, llamar a `Renew`/`RenewAsync` después de actividad verificada del usuario y actualizar la cookie. Las comprobaciones de estado en segundo plano deben usar otro cliente anónimo. La renovación no concede permisos adicionales.

Las aplicaciones con cuenta configurada pueden proporcionar una función: `PortalCredentialsProvider` para frameworks antiguos o `Func<CancellationToken, Task<PortalCredentials>>` para .NET moderno. Devuelve `PortalCredentials(email, password)` desde la configuración segura y actual de la aplicación solo cuando hace falta iniciar sesión. La biblioteca no conserva la contraseña devuelta. Las sesiones interactivas del navegador no necesitan esta función.

Use `ExecuteRead`/`ExecuteReadAsync` solo para lecturas explícitamente seguras: HTTP 401 invalida la sesión correspondiente y permite un nuevo inicio y un único reintento si existe un proveedor. No se reintentan HTTP 403, 409, 429, 503, fallos de red ni tiempos de espera. Los métodos normales nunca repiten automáticamente operaciones de negocio, incluidas escrituras. Sin proveedor, una sesión caducada o borrada produce `InvalidOperationException`; un rechazo de la API conserva estado y código en `PortalApiException`. Solicite otro inicio de sesión, sin bucles ilimitados.

C# y VB.NET usan la misma DLL. Los ejemplos interactivos reciben las credenciales del llamador:

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
