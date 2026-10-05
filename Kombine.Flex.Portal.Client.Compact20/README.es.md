La versión 0.3.2 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.

La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

La versión 0.2.5 añade `GetUserReceipts` y `GetHostingMetrics` para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda: solicite offset 0 y continúe con `nextOffset` y la misma `revision`. Ante HTTP 409 (`receipts-changed`), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte [recibos](/docs#user-receipts) y [métricas](/docs#hosting) para los permisos y límites.

<!-- api-contract-changelog -->
[Changelog del contrato de la API (inglés)](https://api.team.kombine.technology/docs#changelog)

Use el mismo tenant y entorno que su cliente: añada /docs#changelog a la URL base de la API. El enlace anterior usa Team como ejemplo público. Este registro cubre cambios de solicitud/respuesta de endpoints existentes que pueden romper el código del cliente, no correcciones internas de funciones.
<!-- /api-contract-changelog -->

# Cliente Flex Portal para .NET Compact Framework 2.0

`Kombine.Flex.Portal.Client.Compact20` ofrece métodos síncronos y tipados para las **110 operaciones públicas**. No requiere NuGet, bibliotecas Kombine, acceso a bases de datos ni cálculos de KID. Las reglas de negocio y los permisos se aplican en la API. Consulte [OPERATIONS.md](OPERATIONS.md).

La versión 0.3.2 corresponde al candidato beta actual (110 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.

## Instalación

Extraiga `Kombine.Flex.Portal.Client.Compact20.0.3.2.zip` y seleccione **Add Reference → Browse → Kombine.Flex.Portal.Client.Compact20.dll**. Conserve el XML junto a la DLL para IntelliSense y distribuya la DLL con su aplicación. `Source` contiene el código y `Kombine.Flex.Portal.Client.Compact2008.sln`. Cree un proyecto Smart Device para CF 2.0; no es .NET Framework de escritorio ni .NET Standard.

## Primero la URL de la API, después las credenciales

Solicite al administrador la URL HTTPS de la API del tenant, terminada en `/`; no use la dirección del portal. Por ejemplo, `https://api.team.kombine.technology/`. Seleccione el tenant antes de introducir correo y contraseña. Al cambiar de tenant o entorno, cree otro cliente e inicie sesión de nuevo.

Coloque using/Imports al principio del archivo y el resto del código dentro de un método. Las variables de entrada (tenantApiUrl, credenciales y KIDs) proceden de su aplicación. Ambos lenguajes usan la misma DLL.

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

`Login` conserva el token en memoria. `LoginManager(request)` solo devuelve la respuesta; con esa operación debe asignar `api.AccessToken = response.AccessToken`. No se conserva la contraseña. `ClearSession` y `Dispose` eliminan el token local e impiden que un inicio de sesión pendiente lo restablezca. No existe renovación ni cierre de sesión/revocación en el servidor: otras copias siguen sujetas a caducidad y controles de cuenta. Nunca registre credenciales. El inicio de sesión local por ID y los diagnósticos no forman parte del cliente.

## Datos y descargas

Los métodos conservan los identificadores de operación, sin Async. Los filtros opcionales se encuentran en la clase Options correspondiente; null usa el valor predeterminado de la API. `GetBankUsersOptions` permite PageSize, Sort y Cursor; `UserBalancesRequest.UserKids` contiene los KIDs para `GetBankUserBalances`.

- Conserve KIDs, cursores y revisiones exactamente, incluidas las mayúsculas. Continúe hasta que no haya cursor, incluso después de una página vacía.
- Los saldos son Int64 anulables en unidades monetarias menores. Null no es cero; mantenga separadas las monedas. Se admiten 1–50 residentes del mismo banco por lote.
- Las fechas son cadenas ISO 8601 con su zona y precisión. Los filtros de fecha usan yyyy-MM-dd; los enums son enteros. Los campos adicionales desconocidos se ignoran.
- Las llamadas son bloqueantes: use un hilo de trabajo en interfaces gráficas y actualice la pantalla en su hilo de interfaz. Dispose impide nuevas llamadas, pero no cancela las que ya están en curso.
- JSON está limitado a **2 MiB** por defecto, configurable con MaxJsonResponseBytes. El uso total de memoria puede ser mayor.
- PortalDownload proporciona Stream. Copie en bloques pequeños y use siempre Dispose; no se carga todo el archivo en memoria. `TimeoutMilliseconds` es un plazo total HTTP, incluida la lectura de respuestas y descargas, normalmente 30 segundos. CF 2.0 no dispone de ReadWriteTimeout: un temporizador interrumpe la solicitud; el controlador del dispositivo también debe admitir la interrupción de E/S bloqueante.

## Errores y permisos

PortalApiException expone StatusCode, Code, Headers y Response. Message/ToString no incluyen el cuerpo; Response puede contener datos personales. 400: corrija la entrada; 401: inicie sesión; 403: acceso denegado; 404: recurso no disponible para el alcance actual; 409: recargue la revisión; 429/503: respete Retry-After y espere. WebException y errores de E/S indican problemas de red, TLS, tiempo de espera o lectura. PortalProtocolException indica JSON inválido o demasiado grande.

No hay reintentos automáticos. Si se pierde la respuesta de una modificación, su resultado puede ser desconocido. Cookies y redirecciones están desactivadas y no se envían credenciales de Windows automáticamente. La API sigue comprobando cuenta, pestañas, KIDs, retención y permisos de operación.

## Compatibilidad HTTPS

Compilar para CF 2.0 **no garantiza** conectividad con un servidor HTTPS moderno. El sistema operativo y la imagen OEM deben admitir TLS, los algoritmos criptográficos, los certificados, la hora correcta y SNI. El cliente usa HttpWebRequest del dispositivo y no actualiza su pila de red. No existe `EnableTls12()` en esta variante. Pruebe `GetPortalStatus()` en el dispositivo real antes del inicio de sesión. No se permite omitir la validación de certificados ni usar HTTP inseguro; HTTP de loopback solo se admite para pruebas sintéticas.

La [guía de Microsoft sobre Compact Framework](https://learn.microsoft.com/en-us/archive/msdn-magazine/2007/july/share-code-write-code-once-for-both-mobile-and-desktop-apps) explica la compilación específica para dispositivos. La [actualización TLS para Compact 7](https://support.microsoft.com/en-gb/topic/update-to-add-support-for-tls-1-1-and-tls-1-2-in-windows-embedded-compact-7-608b4129-2081-ddde-d078-a94665853b9b) no demuestra compatibilidad con cualquier dispositivo CE 5/6 o Windows Mobile.

## Compilación y pruebas

Use Visual Studio 2008 Professional con Smart Device y el SDK CF 2.0. Extraiga el código en una ruta corta, como C:\FlexCF. Las referencias son mscorlib/System 2.0 de Compact Framework; no use la DLL Net20 de escritorio en CE/Mobile. El código es managed AnyCPU y requiere el runtime y la pila de red del dispositivo.

Copie el EXE, la DLL y ContractCases.tsv de DeviceTests al mismo directorio del dispositivo. El host de pruebas de escritorio usa datos sintéticos y HTTP local; no sustituye una prueba en el dispositivo.

Verificados: compilación con MSBuild 3.5 y referencias CF 2.0, las 110 operaciones y comprobaciones sintéticas en escritorio, incluidas las identidades de ensamblado. El programa para dispositivos compila. **No se han verificado la ejecución ni HTTPS en dispositivos o emuladores CE/Mobile.** No se realizaron inicios de sesión reales ni cambios en bases de datos.

En el repositorio de desarrollo, `scripts/Test-PortalClientCompact20.ps1` compila, prueba y empaqueta el ZIP; PowerShell 7 no es necesario en el equipo cliente. `scripts/Generate-PortalClientNet20.py --compact` regenera los contratos desde OpenAPI. Para usar o compilar la DLL, el cliente no necesita Python, generadores ni una API en ejecución. El idioma principal de la documentación es inglés; se incluyen alternativas en danés y español.

## Gestión automática de sesiones — 0.4.0 (sin publicar)

Mantenga una `PortalSession` por dirección API y cuenta/inicio de sesión. Los clientes creados a partir de ella renuevan al usarse poco antes de caducar; la autenticación simultánea se coordina. No hay temporizador en segundo plano. Dispose del cliente no cierra la sesión compartida; use `session.ClearSession()`. La autenticación pendiente no puede restaurar una sesión borrada. No registre tokens ni contraseñas.

Las aplicaciones interactivas llaman a `Login`/`LoginAsync` una vez. Una sesión caducada requiere otro inicio de sesión. Una aplicación web puede usar `Restore` con el token y vencimiento fiables de su cookie protegida, llamar a `Renew`/`RenewAsync` después de actividad verificada del usuario y actualizar la cookie. Las comprobaciones de estado en segundo plano deben usar otro cliente anónimo. La renovación no concede permisos adicionales.

Las aplicaciones con cuenta configurada pueden proporcionar una función: `PortalCredentialsProvider` para frameworks antiguos o `Func<CancellationToken, Task<PortalCredentials>>` para .NET moderno. Devuelve `PortalCredentials(email, password)` desde la configuración segura y actual de la aplicación solo cuando hace falta iniciar sesión. La biblioteca no conserva la contraseña devuelta. Las sesiones interactivas del navegador no necesitan esta función.

Use `ExecuteRead`/`ExecuteReadAsync` solo para lecturas explícitamente seguras: HTTP 401 invalida la sesión correspondiente y permite un nuevo inicio y un único reintento si existe un proveedor. No se reintentan HTTP 403, 409, 429, 503, fallos de red ni tiempos de espera. Los métodos normales nunca repiten automáticamente operaciones de negocio, incluidas escrituras. Sin proveedor, una sesión caducada o borrada produce `InvalidOperationException`; un rechazo de la API conserva estado y código en `PortalApiException`. Solicite otro inicio de sesión, sin bucles ilimitados.

C# y VB.NET usan la misma DLL. Los ejemplos interactivos reciben las credenciales del llamador:

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
