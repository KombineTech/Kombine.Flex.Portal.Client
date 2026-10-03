La versión 0.3.3 utiliza el [logotipo oficial de Kombine](https://static.kombine.services/kombinelogotext1/black.svg), conservado como logo.svg y convertido a icon.png para NuGet. Los contratos API y el comportamiento del cliente no cambian.

La versión 0.3.2 añade el logotipo oficial de Kombine, los metadatos del editor y los datos de contacto de la empresa. Los contratos API y el comportamiento del cliente no cambian.

La versión 0.3.1 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.

La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

La versión 0.2.5 añade `GetUserReceipts` y `GetHostingMetrics` para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda: solicite offset 0 y continúe con `nextOffset` y la misma `revision`. Ante HTTP 409 (`receipts-changed`), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte [recibos](/docs#user-receipts) y [métricas](/docs#hosting) para los permisos y límites.

<!-- api-contract-changelog -->
[Changelog del contrato de la API (inglés)](https://api.team.kombine.technology/docs#changelog)

Use el mismo tenant y entorno que su cliente: añada /docs#changelog a la URL base de la API. El enlace anterior usa Team como ejemplo público. Este registro cubre cambios de solicitud/respuesta de endpoints existentes que pueden romper el código del cliente, no correcciones internas de funciones.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — cliente .NET

Cliente HTTPS/JSON tipado para las 110 operaciones públicas. No depende de otros paquetes Kombine, no accede a bases de datos ni contiene reglas de negocio. La referencia principal detallada está en [inglés](README.md); [OPERATIONS.md](OPERATIONS.md) enumera todas las operaciones.

La versión 0.3.1 corresponde al contrato API actual (110 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.

## Instalación y plataformas

Las versiones de producción se publican en [nuget.org](https://www.nuget.org/packages/Kombine.Flex.Portal.Client). Instale una versión publicada con el comando siguiente y nuget.org como fuente. Si una versión beta aún no está disponible allí, añada el archivo revisado Kombine.Flex.Portal.Client.0.3.4.nupkg de la documentación API a una fuente NuGet local.

```powershell
dotnet nuget add source ./packages --name flex-local
dotnet add package Kombine.Flex.Portal.Client --version 0.3.4
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
