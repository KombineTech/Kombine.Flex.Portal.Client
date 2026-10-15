Todos los cambios de rol de administrador requieren Read y Write tanto de Tabs como de Kids. Gestione missing-tabs-read, missing-tabs-write, missing-kids-read y missing-kids-write (HTTP 403).

GetTerminals usa el ComputerName comunicado para el nombre, el filtro y la ordenación; los nombres ausentes están vacíos. Solicite fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight para los datos del terminal. Son cadenas, null si no se seleccionan y vacías si faltan. Mantenga fields al paginar y reinicie los cursores anteriores. Cada fila incluye el nombre de la ubicación. Consulte /docs#changelog para todos los requisitos de migración.

La versión 0.8.1 incluye 149 operaciones. GetUnits añade el directorio de unidades autorizado: mantenga filtros y fields al paginar y reinicie ante invalid-cursor. Los roles de administrador requieren las nueve categorías de expectedFlags, incluidas Tabs y Kids; gestione sus permisos independientes y las respuestas 403. Se eliminan las asignaciones de acceso de servicios: deje de enviar esas solicitudes y de leer el objeto access. Las partes del logotipo se indican en la ruta antes del color, no en parámetros de consulta. UserBalance sigue siendo compatible. Consulte /docs#changelog para la migración y /docs#unit-directory para paginación y ejemplos.

Versión 0.8.0: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.

La versión 0.8.0 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.

La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

La versión 0.2.5 añade `GetUserReceipts` y `GetHostingMetrics` para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda: solicite offset 0 y continúe con `nextOffset` y la misma `revision`. Ante HTTP 409 (`receipts-changed`), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte [recibos](/docs#user-receipts) y [métricas](/docs#hosting) para los permisos y límites.

<!-- api-contract-changelog -->
[Changelog del contrato de la API (inglés)](https://api.team.kombine.technology/docs#changelog)

Use el mismo tenant y entorno que su cliente: añada /docs#changelog a la URL base de la API. El enlace anterior usa Team como ejemplo público. Este registro cubre cambios de solicitud/respuesta de endpoints existentes que pueden romper el código del cliente, no correcciones internas de funciones.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — cliente .NET

Cliente HTTPS/JSON tipado para las 149 operaciones públicas. No depende de otros paquetes Kombine, no accede a bases de datos ni contiene reglas de negocio. La referencia principal detallada está en [inglés](README.md); [OPERATIONS.md](OPERATIONS.md) enumera todas las operaciones.

La versión 0.8.1 corresponde al contrato API actual (149 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.

## Tiempo actual de una ubicación

La versión 0.8.1 añade `GetLocationWeatherAsync`; el SDK incluye 149 operaciones. La API usa las coordenadas guardadas de la ubicación autorizada o su dirección/código postal guardados. Solo se acepta `locationKid`; el cliente no puede enviar coordenadas ni seleccionar otro tenant. Se requieren administrador activo, Tab asignada, Bank Read, Location Read, ámbito correcto y visibilidad según retención. No se requieren Unit Read ni Write.

```csharp
var weather = await api.GetLocationWeatherAsync(locationKid, cancellationToken);
if (weather.Status == "Available" && weather.Current != null)
    Console.WriteLine($"{weather.Current.TemperatureCelsius} °C");
```

```vbnet
Dim weather = Await api.GetLocationWeatherAsync(locationKid, cancellationToken)
If weather.Status = "Available" AndAlso weather.Current IsNot Nothing Then
    Console.WriteLine("{0} °C", weather.Current.TemperatureCelsius)
End If
```

Compruebe `status` antes de usar `current`: `Available` contiene mediciones actuales; `LocationUnknown` y `Unavailable` tienen `current = null`. Las mediciones opcionales desconocidas son null; conserve los ceros reales. Las fechas son UTC, las temperaturas Celsius, el viento metros/segundo, la precipitación milímetros y la humedad porcentaje. `positionSource = "Address"` indica una posición aproximada por dirección/código postal. Muestre **Weather data by Open-Meteo, CC BY 4.0**; son datos de modelo, no de un sensor local.

Actualice al navegar. La API conserva resultados correctos diez minutos y fallos un minuto; las respuestas HTTP son no-store. Un fallo del proveedor puede devolver HTTP 200 con `Unavailable`; un fallo de almacenamiento o el plazo de doce segundos devuelve HTTP 503, código `location-weather-unavailable`. No sustituya datos ausentes por cero ni reintente automáticamente. Mantenga utilizable el resto de la aplicación. Consulte [tiempo de ubicación](/docs#location-weather) para permisos y errores.

## Capturas de cámara y medios privados

La versión 0.8.0 añadió seis operaciones de cámara tipadas. Se requieren Camera1 y Read sobre el recurso; preparar y guardar también requieren Write. Obtenga `resourceKid` de la API. El servidor selecciona el tenant y el propietario.

El ejemplo envía un JPEG recién capturado con su fecha real de captura. Calcule el hash de los bytes originales exactos y no recodifique el archivo después de prepararlo. La API valida el archivo y los metadatos. La aplicación sigue siendo responsable de la captura.

```csharp
using (var original = File.OpenRead(capturedJpegPath))
using (var sha256 = System.Security.Cryptography.SHA256.Create())
{
    var hash = BitConverter.ToString(sha256.ComputeHash(original)).Replace("-", "");
    original.Position = 0;
    var prepared = await api.PrepareCameraCaptureAsync(new CameraPrepareRequest
    {
        ResourceKid = resourceKid,
        Kind = "photo",
        OriginalFileName = Path.GetFileName(capturedJpegPath),
        OriginalNameAvailable = true,
        CapturedAtUtc = capturedAtUtc,
        MediaLength = original.Length,
        MediaSha256 = hash,
        SensorData = new Dictionary<string, object>()
    }, cancellationToken);
    var saved = await api.SaveCameraCaptureAsync(prepared.UploadToken,
        new FileParameter(original, Path.GetFileName(capturedJpegPath), "image/jpeg"),
        cancellationToken: cancellationToken);
}

var gallery = await api.GetCameraCapturesAsync(resourceKid, cancellationToken: cancellationToken);
foreach (var item in gallery.Items ?? Array.Empty<CameraCaptureItem>())
{
    using (var download = await api.GetCameraCaptureContentAsync(item.Id!, part: "thumbnail",
        cancellationToken: cancellationToken))
    using (var destination = File.Create(item.CaptureId + ".jpg"))
        await download.Stream.CopyToAsync(destination, 81920, cancellationToken);
}
```

Omita `motion` para fotos y vídeos normales. Para una Live Photo compatible, prepare `kind = "live-photo"`, `motionLength` y `motionSha256`; después envíe el stream QuickTime correspondiente como `new FileParameter(motionStream, "capture.mov", "video/quicktime")`. El método de carga cierra los streams; ábralos de nuevo para un reintento deliberado con el mismo token y bytes idénticos. Las cargas nunca se reintentan automáticamente. El timeout del transporte predeterminado es de 30 segundos. Para vídeos grandes, inyecte un `HttpClient` con un timeout apropiado, `AllowAutoRedirect = false` y `UseCookies = false`, y conserve un plazo de cancelación. Use `motion-playback` para el MP4 portátil derivado del movimiento de una Live Photo.

Guardar correctamente significa que el conjunto completo de medios/JSON existe en al menos una región. Siga `nextCursor` sin cambios con el mismo recurso, incluso tras una página vacía. `isDegraded` indica que una región no respondió; reinicie la consulta tras la recuperación. Sin `resourceKid` se enumeran las capturas propias del administrador actual. Use el `id` opaco devuelto para acceder al contenido autorizado. `part` puede ser `original`, `thumbnail`, `metadata`, `preview`, `motion`, `motion-playback` o `playback`, según los indicadores. El parámetro opcional `range: "bytes=0-1023"` envía una cabecera Range; HTTP 206 devuelve `FileResponse` con `IsPartial`. Libere cada descarga mediante Dispose. Nunca convierta rutas de almacenamiento en URL públicas. Consulte la [guía de cámara](/docs#camera-captures) para límites y códigos de error.

## Instalación y plataformas

Las versiones de producción se publican en [nuget.org](https://www.nuget.org/packages/Kombine.Flex.Portal.Client). Instale una versión publicada con el comando siguiente y nuget.org como fuente. Si una versión beta aún no está disponible allí, añada el archivo revisado Kombine.Flex.Portal.Client.0.8.1.nupkg de la documentación API a una fuente NuGet local.

```powershell
dotnet nuget add source ./packages --name flex-local
dotnet add package Kombine.Flex.Portal.Client --version 0.8.1
```

.NET Framework 4.7.2/4.8/4.8.1 usa netstandard2.0 con Microsoft System.Text.Json 10.0.12 y sus dependencias. .NET 8/9 usa net8.0; .NET 10 usa net10.0 sin paquetes adicionales. Mantenga nuget.org o un mirror aprobado para dependencias Microsoft. Framework puede necesitar binding redirects automáticos y System.Net.Http al inyectar HttpClient. Las pruebas Framework compilan contra 4.7.2/4.8 y se ejecutan en 4.8.1 instalado; no se ha probado una instalación original de 4.7.2.

## Conexión e inicio de sesión

Seleccione primero la URL HTTPS de la API del tenant, terminada en /, y después correo y contraseña. No use la URL del portal. Cree otro cliente y una nueva sesión al cambiar de tenant o entorno.

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

LoginAsync conserva el token solo en memoria. LoginManagerAsync es la operación directa y no lo conserva automáticamente. ClearSession/Dispose eliminan el token local; no existe un token de renovación separado ni revocación/cierre de sesión en el servidor. Otras copias siguen sujetas a caducidad y controles de cuenta. Nunca registre credenciales indiscriminadamente.

## Operaciones, datos y errores

Los métodos se llaman OperationIdAsync y aceptan cancellationToken. KIDs, cursores y revisiones son cadenas opacas que deben conservarse exactamente. Continúe la paginación hasta que no haya cursor, incluso tras una página vacía. GetBankUserBalancesAsync acepta 1–50 residentes del mismo banco. Los saldos son enteros en unidades monetarias menores; null no es cero y las monedas deben permanecer separadas. La API comprueba cuenta, pestañas, Kids, retención y permisos. No se incluyen el inicio de sesión local de desarrollo ni diagnósticos.

PortalApiException expone StatusCode y Code. 400: corrija entrada; 401: inicie sesión; 403: acceso denegado; 404: no disponible; 409: recargue revisión; 429/503: respete Retry-After. HttpRequestException indica red/TLS; OperationCanceledException indica cancelación/timeout. No hay reintentos automáticos: una modificación puede haberse completado aunque su respuesta se pierda. JSON inválido produce un error, no datos vacíos. Los errores tipados ofrecen Result; Response puede contener datos personales y se omite de Message/ToString.

Las descargas son streams que deben cerrarse con using/Dispose. El constructor URI administra su HttpClient, usa 30 segundos y desactiva cookies/redirecciones. HTTPS conserva la validación normal; HTTP solo se permite en loopback para pruebas. Al inyectar HttpClient, use BaseAddress fija terminada en /, desactive cookies/redirecciones y conserve TLS normal. El transporte pertenece entonces al llamador. No use una cabecera Authorization compartida.

## Mantenimiento

scripts/Update-PortalClient.ps1 regenera desde OpenAPI con la versión fijada de NSwag. El código generado se incluye; el consumidor no necesita generadores ni feeds privados. scripts/Test-PortalClients.ps1 prueba los clientes y aplicaciones, crea el paquete y lo verifica en un consumidor NuGet independiente con caché nueva y datos sintéticos. Consulte la referencia inglesa para más detalles.

## Editor y soporte

![Kombine](https://raw.githubusercontent.com/KombineTech/Kombine.Flex.Portal.Client/5c87078b8a0b2439a4e68a0b432537d458dd31f4/Kombine.Flex.Portal.Client/icon.png)

**Kombine Technology ApS**  
Finlandsvej 61 st. th.  
DK-7100 Vejle, Dinamarca  
CVR: 44637928  
+45 76 43 70 20  
[support@kombinetech.com](mailto:support@kombinetech.com)  
[kombinetech.com](https://kombinetech.com/)

## Gestión automática de sesiones — 0.8.1 (sin publicar)

`SendRequestAsync` también admite descargas, respuestas en streaming y operaciones añadidas después del contrato generado incluido. Comprueba que la solicitud permanezca dentro de la dirección fija de la API, conserva las cabeceras de la aplicación y nunca reintenta. El código que llama es responsable de la solicitud y la respuesta. Use `HttpCompletionOption.ResponseHeadersRead` para streaming. La aplicación puede utilizar sus propios modelos de respuesta; la API sigue aplicando los permisos.

Mantenga una `PortalSession` por dirección API y cuenta/inicio de sesión. Los clientes creados a partir de ella renuevan al usarse poco antes de caducar; la autenticación simultánea se coordina. No hay temporizador en segundo plano. Dispose del cliente no cierra la sesión compartida; use `session.ClearSession()`. La autenticación pendiente no puede restaurar una sesión borrada. No registre tokens ni contraseñas.

Las aplicaciones interactivas llaman a `Login`/`LoginAsync` una vez. Una sesión caducada requiere otro inicio de sesión. Una aplicación web puede usar `Restore` con el token y vencimiento fiables de su cookie protegida, llamar a `Renew`/`RenewAsync` después de actividad verificada del usuario y actualizar la cookie. Las comprobaciones de estado en segundo plano deben usar otro cliente anónimo. La renovación no concede permisos adicionales.

Las aplicaciones con cuenta configurada pueden proporcionar una función: `PortalCredentialsProvider` para frameworks antiguos o `Func<CancellationToken, Task<PortalCredentials>>` para .NET moderno. Devuelve `PortalCredentials(email, password)` desde la configuración segura y actual de la aplicación solo cuando hace falta iniciar sesión. La biblioteca no conserva la contraseña devuelta. Las sesiones interactivas del navegador no necesitan esta función.

Use `ExecuteRead`/`ExecuteReadAsync` solo para lecturas explícitamente seguras: HTTP 401 invalida la sesión correspondiente y permite un nuevo inicio y un único reintento si existe un proveedor. No se reintentan HTTP 403, 409, 429, 503, fallos de red ni tiempos de espera. Los métodos normales nunca repiten automáticamente operaciones de negocio, incluidas escrituras. Sin proveedor, una sesión caducada o borrada produce `InvalidOperationException`; un rechazo de la API conserva estado y código en `PortalApiException`. Solicite otro inicio de sesión, sin bucles ilimitados.

C# y VB.NET usan la misma DLL. Los ejemplos interactivos reciben las credenciales del llamador:

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
