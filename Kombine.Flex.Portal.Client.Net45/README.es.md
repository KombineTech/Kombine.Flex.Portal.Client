Todos los cambios de rol de administrador requieren Read y Write tanto de Tabs como de Kids. Gestione missing-tabs-read, missing-tabs-write, missing-kids-read y missing-kids-write (HTTP 403).

GetTerminals usa el ComputerName comunicado para el nombre, el filtro y la ordenación; los nombres ausentes están vacíos. Solicite fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight para los datos del terminal. Son cadenas, null si no se seleccionan y vacías si faltan. Mantenga fields al paginar y reinicie los cursores anteriores. Cada fila incluye el nombre de la ubicación. Consulte /docs#changelog para todos los requisitos de migración.

La versión 0.6.1 incluye 131 operaciones. GetUnits añade el directorio de unidades autorizado: mantenga filtros y fields al paginar y reinicie ante invalid-cursor. Los roles de administrador requieren las nueve categorías de expectedFlags, incluidas Tabs y Kids; gestione sus permisos independientes y las respuestas 403. Se eliminan las asignaciones de acceso de servicios: deje de enviar esas solicitudes y de leer el objeto access. Las partes del logotipo se indican en la ruta antes del color, no en parámetros de consulta. UserBalance sigue siendo compatible. Consulte /docs#changelog para la migración y /docs#unit-directory para paginación y ejemplos.

Versión 0.6.1: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.

a versión 0.6.1 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.

La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

La versión 0.2.5 añade `GetUserReceipts` y `GetHostingMetrics` para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda: solicite offset 0 y continúe con `nextOffset` y la misma `revision`. Ante HTTP 409 (`receipts-changed`), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte [recibos](/docs#user-receipts) y [métricas](/docs#hosting) para los permisos y límites.

<!-- api-contract-changelog -->
[Changelog del contrato de la API (inglés)](https://api.team.kombine.technology/docs#changelog)

Use el mismo tenant y entorno que su cliente: añada /docs#changelog a la URL base de la API. El enlace anterior usa Team como ejemplo público. Este registro cubre cambios de solicitud/respuesta de endpoints existentes que pueden romper el código del cliente, no correcciones internas de funciones.
<!-- /api-contract-changelog -->

# Cliente Flex Portal para .NET Framework 4.5

`Kombine.Flex.Portal.Client.Net45` ofrece métodos síncronos y tipados para las **131 operaciones públicas**. No requiere NuGet, bibliotecas Kombine, acceso a bases de datos ni cálculos de KID. Las reglas de negocio y los permisos se aplican en la API. Consulte [OPERATIONS.md](OPERATIONS.md).

La versión 0.6.1 corresponde al candidato beta actual (131 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.

## Instalación

Extraiga `Kombine.Flex.Portal.Client.Net45.0.6.1.zip` y seleccione **Add Reference → Browse → Kombine.Flex.Portal.Client.Net45.dll**. Conserve el XML junto a la DLL para IntelliSense y distribuya la DLL con su aplicación. `Source` contiene el código y `Kombine.Flex.Portal.Client.2012.sln`. La DLL solo referencia mscorlib y System 4.5; es un proyecto clásico independiente.

## Primero la URL de la API, después las credenciales

Solicite al administrador la URL HTTPS de la API del tenant, terminada en `/`; no use la dirección del portal. Por ejemplo, `https://api.team.kombine.technology/`. Seleccione el tenant antes de introducir correo y contraseña. Al cambiar de tenant o entorno, cree otro cliente e inicie sesión de nuevo.

Coloque using/Imports al principio del archivo y el resto del código dentro de un método. Las variables de entrada (tenantApiUrl, credenciales y KIDs) proceden de su aplicación. Ambos lenguajes usan la misma DLL.

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

## Compilación y pruebas

Use Visual Studio 2012 con el kit de destino de .NET 4.5. El proyecto clásico MSBuild 4.0 no tiene PackageReference ni referencias a otro cliente. El ejecutable de pruebas se encuentra en tests/Kombine.Flex.Portal.Client.Net45.Tests/bin/Release.

El script de desarrollo obtiene las referencias de Microsoft 1.0.3 solo si falta el kit; no son una dependencia del cliente. Se verificó la compilación contra .NET 4.5, 454 comprobaciones sintéticas y HTTPS anónimo local. La ejecución usó el CLR 4 más reciente instalado; no se probaron una instalación original de .NET 4.5 ni el IDE de VS2012.

En el repositorio de desarrollo, `scripts/Test-PortalClientNet45.ps1` compila, prueba y empaqueta el ZIP; PowerShell 7 no es necesario en el equipo cliente. `scripts/Generate-PortalClientNet20.py --net45` regenera los contratos desde OpenAPI. Para usar o compilar la DLL, el cliente no necesita Python, generadores ni una API en ejecución. El idioma principal de la documentación es inglés; se incluyen alternativas en danés y español.

## Gestión automática de sesiones — 0.6.1 (sin publicar)

Mantenga una `PortalSession` por dirección API y cuenta/inicio de sesión. Los clientes creados a partir de ella renuevan al usarse poco antes de caducar; la autenticación simultánea se coordina. No hay temporizador en segundo plano. Dispose del cliente no cierra la sesión compartida; use `session.ClearSession()`. La autenticación pendiente no puede restaurar una sesión borrada. No registre tokens ni contraseñas.

Las aplicaciones interactivas llaman a `Login`/`LoginAsync` una vez. Una sesión caducada requiere otro inicio de sesión. Una aplicación web puede usar `Restore` con el token y vencimiento fiables de su cookie protegida, llamar a `Renew`/`RenewAsync` después de actividad verificada del usuario y actualizar la cookie. Las comprobaciones de estado en segundo plano deben usar otro cliente anónimo. La renovación no concede permisos adicionales.

Las aplicaciones con cuenta configurada pueden proporcionar una función: `PortalCredentialsProvider` para frameworks antiguos o `Func<CancellationToken, Task<PortalCredentials>>` para .NET moderno. Devuelve `PortalCredentials(email, password)` desde la configuración segura y actual de la aplicación solo cuando hace falta iniciar sesión. La biblioteca no conserva la contraseña devuelta. Las sesiones interactivas del navegador no necesitan esta función.

Use `ExecuteRead`/`ExecuteReadAsync` solo para lecturas explícitamente seguras: HTTP 401 invalida la sesión correspondiente y permite un nuevo inicio y un único reintento si existe un proveedor. No se reintentan HTTP 403, 409, 429, 503, fallos de red ni tiempos de espera. Los métodos normales nunca repiten automáticamente operaciones de negocio, incluidas escrituras. Sin proveedor, una sesión caducada o borrada produce `InvalidOperationException`; un rechazo de la API conserva estado y código en `PortalApiException`. Solicite otro inicio de sesión, sin bucles ilimitados.

C# y VB.NET usan la misma DLL. Los ejemplos interactivos reciben las credenciales del llamador:

```csharp
using Kombine.Flex.Portal.Client.Net45;

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
Imports Kombine.Flex.Portal.Client.Net45

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
