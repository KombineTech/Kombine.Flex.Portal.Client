## Calendarios de reservas de la ubicación · 0.18.0

`GetLocationBookingCalendars` devuelve calendarios con fechas y horarios de apertura aplicados por la API. Parámetros opcionales: from=yyyy-MM-dd y days=1-31 (14 por defecto); la respuesta contiene timeZone, from, days y date para cada día. Muestre las fechas directamente y solicite otro intervalo al navegar, sin repetir semanas ni combinar horarios en el cliente. Los grupos incluyen unidades autorizadas y estado Configured; se omiten los calendarios almacenados no válidos. startMinute es 0-1439, durationMinutes es positivo y su suma no supera 1440. Tipo 0=reserva, 1=oportunidad, 2=cerrado, 3=horario desconocido. No muestre lo desconocido como reservable. Requiere Bookings1, Location Read, Unit Read y acceso al recurso. Muestre cada máquina por separado. Es configuración, no ocupación ni disponibilidad. Gestione 400/401/403/404/503 explícitamente. Consulte [calendarios](/docs#location-booking-calendars) y [changelog](/docs#changelog).

## Tiempo de la ubicación · 0.18.0

La versión 0.18.0 incluye las 200 operaciones y contiene `GetLocationWeather` para un KID canónico de ubicación. Reutilice la sesión del administrador. La API exige Tab asignado, Bank Read, Location Read, ámbito autorizado y ubicación/banco visibles. Resuelve coordenadas guardadas o la dirección de la ubicación; el cliente nunca envía claves del proveedor ni coordenadas. Compruebe `status`: `Available` contiene `current`; `LocationUnknown` y `Unavailable` no contienen mediciones. Los valores desconocidos son null, nunca cero. Temperatura en Celsius, viento en m/s, precipitación en mm, humedad en porcentaje y horas UTC. La posición obtenida de la dirección puede ser aproximada. Muestre: Weather data by Open-Meteo, CC BY 4.0. Gestione HTTP 400/401/403/404/503 normalmente y reintente de forma deliberada; un fallo del proveedor también puede devolver HTTP 200 con `Unavailable`. Consulte [tiempo de la ubicación](/docs#location-weather).

```php
$weather = $api->getLocationWeather($locationKid);
if (($weather["status"] ?? null) === "Available" && ($weather["current"] ?? null) !== null) {
    echo $weather["current"]["temperatureCelsius"];
}
```

Versión 0.4.3: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.

La versión 0.8.0 incluye las 148 operaciones públicas, incluida Camera1. Llame a PrepareCameraCapture con SHA-256 y longitud exactos del original, fecha UTC, KID del recurso y objeto de sensores; cargue los mismos bytes con uploadToken. Live Photos requiere además la longitud/hash y el MOV original asociado. Conserve el token y los bytes para un reintento deliberado; no hay reintentos automáticos. Aumente el plazo para procesar vídeo. La API exige Camera1 y permisos Read/Write del recurso exacto. Las listas pueden estar degradadas o devolver páginas vacías con nextCursor; continúe hasta que no haya cursor. Descargue por la API; Range puede devolver HTTP 206. Consulte /docs#camera-captures para límites y errores.

```php
// $uploadToken comes from prepareCameraCapture for these exact original bytes.
$saved = $api->saveCameraCapture([
    'uploadToken' => $uploadToken,
    'original' => new \CURLFile($originalPath, 'application/octet-stream', 'capture.jpg'),
]);
```

Add a `motion` CURLFile for Live Photos. Only readable local files are accepted; cURL streams them. Payloads together are limited to 139 MiB plus framing; text fields: 512 KiB each.


La versión 0.18.0 incluye GetCameraNearestLocation para seleccionar ubicación mediante GPS y GetRecentCameraPhotoMetadata para información protegida. Los recursos incluyen control de proximidad y coordenadas anulables. Los nuevos nombres son GUID opacos; no extraigas región ni nombre original. La selección exige Camera1 y Location Read/Write; los metadatos exigen Read del recurso. Sin GPS o con 404/409, elige la ubicación manualmente. Consulta /docs#camera-captures y /docs#changelog.

La versión 0.18.0 incluye 200 operaciones. SaveCameraCapture admite procesamiento opcional en segundo plano; HTTP 202 solo confirma almacenamiento temporal. Conserve los archivos originales y el token de carga y llame a ConfirmCameraCapture hasta que confirmed sea true. processingPercent es una estimación y puede ser null; errorCode puede indicar un fallo. Tras reiniciar el servidor, reintente con los mismos archivos y token si la publicación no está confirmada. Recompile las llamadas con las firmas actualizadas de SaveCameraCapture y use argumentos con nombre cuando estén disponibles. El comportamiento síncrono predeterminado de la API no cambia. Consulte /docs#camera-captures y /docs#changelog.

La versión 0.18.0 añade FindWallboardPairings y GetWallboardDevice (200 operaciones en total), además de metadatos opcionales de ubicación al aprobar una pantalla. La configuración central de Wallboard utiliza un único escaneo QR; la ubicación privada solo está disponible para el administrador que aprobó el dispositivo. La aprobación no caduca automáticamente y conserva las comprobaciones de revocación, credenciales, tenant y entorno. Los clientes UserBalance existentes siguen siendo compatibles. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog) y la [guía Wallboard](https://api.team.kombine.technology/docs#wallboard-pairing).

La versión 0.17.0 añade siete operaciones para vincular y gestionar pantallas Wallboard (198 en total). Un administrador activo aprueba cada pantalla una vez; la aprobación del dispositivo no caduca automáticamente. Mantenga la clave privada ECDSA P-256 no exportable en la pantalla, firme desafíos de un solo uso para reconectar y no incluya credenciales ni tokens bearer en URL o almacenamiento del navegador. Se conservan la revocación y las comprobaciones de la cuenta y credenciales del administrador. La sesión de diez días no limita la aprobación. UserBalance mantiene la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog) y la [guía Wallboard](https://api.team.kombine.technology/docs#wallboard-pairing).

La versión 0.16.1 añade la lista de liquidaciones de solo lectura, el historial y reconocimiento de errores, la consulta y restauración de máquinas fuera de servicio y el acceso autorizado a eVaskeri del residente. La búsqueda de residentes incluye bankKid. Todas las operaciones mantienen la autorización del administrador, tenant y recurso. Los enlaces de eVaskeri son credenciales sensibles: ábralos inmediatamente sin opener/referrer y nunca los registre ni almacene. No repita automáticamente solicitudes de modificación tras una respuesta incierta. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.15.0 utiliza GetPublicCycleWidget y GetCycleChartPresentation. Sustituya las rutas retiradas de widgets/presentación WashDoc por /api/v1/public/widgets/cycle y /api/v1/public/cycle-chart/presentation. Los parámetros de ruta y los campos de tablas/gráficos/widgets usan cycleKid; el campo de visualización del widget es cycleKidText. Se mantienen los valores KID y los ID de las operaciones de documentos. Recompile los clientes y actualice las referencias a campos. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.14.0 sincroniza idioma, fecha/hora, formato numérico y espaciado personal. Los widgets WashDoc sustituyen unitKidText por documentKidText; graphSvg puede ser null sin mediciones. Detenga el sondeo con refreshAfterSeconds=0; los documentos en curso usan 15 segundos. Las sesiones de administrador duran diez días: use expiresIn de la respuesta y renueve solo tras actividad. UserBalance sigue siendo compatible. Consulte el [registro de cambios](/docs#changelog).

La versión 0.13.0 mueve ConvertToolTime e InspectToolKid a /api/v1/tenant/tools/time y /api/v1/tenant/tools/kid. Quite el argumento bankKid al recompilar; el sitio selecciona el tenant. Se mantienen manager activo, More1, Bank Read y un permiso de recurso del tenant del sitio. Los cuerpos y respuestas JSON no cambian. GetUnitDocumentNeighbors añade navegación autorizada entre documentos de la misma unidad. Consulte el [registro de cambios](/docs#changelog).

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Cliente PHP de Kombine Flex Portal

[Changelog del contrato API](https://api.team.kombine.technology/docs#changelog) — utiliza `/docs#changelog` en la API del mismo tenant y entorno que el cliente. El changelog está solo en inglés.

Versión **0.18.0**, preparada localmente; no desplegada ni publicada en Packagist. Incluye 200 operaciones públicas del contrato OpenAPI adjunto. Requiere **PHP 8.2+ de 64 bits**, `ext-curl`, `ext-json`, HTTPS y certificados CA de confianza. No necesita bibliotecas PHP externas ni ensamblados internos de Kombine. El transporte admite Windows, Linux y macOS; esta versión se probó con Windows CLI. Utiliza una versión de PHP con soporte vigente.

La versión 0.3.1 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales. La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances. La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites. La versión 0.2.5 añade GetUserReceipts y GetHostingMetrics para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda desde offset 0. Continúe con nextOffset y la misma revision; ante HTTP 409 (receipts-changed), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte /docs#user-receipts y /docs#hosting para los permisos y límites.

Para este candidato beta, cambie los campos icon/bankIcon/unitIcon por iconKid/bankIconKid/unitIconKid y use rutas de iconos con un conjunto explícito. Consulte el registro de cambios para las rutas eliminadas. Las descargas de aplicaciones devuelven DownloadResponse y escriben bytes en el stream proporcionado.

## Instalación

Descarga `kombine-flex-portal-client-php-0.18.0.zip` desde la sección PHP de la guía API. Con Composer, guarda el ZIP en el directorio `packages/` de la aplicación:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-portal-client:0.18.0
```

El repositorio artifact de Composer requiere `ext-zip` durante la instalación. Sin Composer, extrae el ZIP en `flex-portal-client/` y sustituye la línea de autoload por `require __DIR__ . '/flex-portal-client/autoload.php';`. Conserva todo `src/`, incluido `contract.json`. Ambos paquetes se pueden cargar juntos.

## Inicio de sesión y primera llamada

Usa el correo y la contraseña de un administrador para la API Portal del tenant. Obtén las variables siguientes de la configuración protegida o del formulario de acceso. La URL de la API del tenant debe terminar en `/`.

```php
<?php
declare(strict_types=1);
require __DIR__ . '/vendor/autoload.php';

use Kombine\Flex\Portal\PortalClient;
use Kombine\Flex\Portal\ApiException;
use Kombine\Flex\Portal\ProtocolException;
use Kombine\Flex\Portal\TransportException;

$api = new PortalClient($tenantUrl, timeout: 30);
try {
    $session = $api->login($email, $password);
    $result = $api->getCurrentManager();
} catch (ApiException $error) {
    $status = $error->status;
    $code = $error->apiCode;
    $retryAfter = $error->headers['retry-after'] ?? null;
    // Gestiona el error según la tabla; no repitas escrituras a ciegas.
} catch (TransportException | ProtocolException $error) {
    // Timeout, fallo de red, datos incorrectos o límite de respuesta.
    // Una escritura puede haberse completado: comprueba el estado antes de repetirla.
} finally {
    $api->close();
}
```

`login()` conserva el bearer en memoria; la operación directa `loginManager($body)` solo lo devuelve. `setAccessToken($token)` y `getAccessToken()` permiten reutilizar una sesión desde almacenamiento protegido del servidor. No compartas clientes entre usuarios o tenants. `clearSession()` y `close()` descartan el token local; las copias existentes conservan su caducidad. No se guardan credenciales. Las operaciones anónimas omiten el token. HTTP 401 lo elimina, incluso con respuestas de error incorrectas o demasiado grandes. `renew()` llama explícitamente a RenewManagerSession y guarda el token nuevo. `renewManagerSession()` solo devuelve la respuesta. Renueva antes de caducar y según la actividad del usuario; tras caducidad o revocación, inicia sesión de nuevo. No hay refresh-token separado.

## Métodos y valores

[OPERATIONS.md](OPERATIONS.md) enumera los identificadores estables y métodos PHP; [MODELS.md](MODELS.md) describe los arrays. Las claves de `$options` respetan exactamente los nombres y mayúsculas de la API. Los objetos son arrays asociativos; las listas son arrays indexados. Un array vacío se convierte en objeto JSON cuando el contrato exige un objeto. Fechas, KID, cursores y revisiones permanecen como cadenas; no los reconstruyas ni interpretes. Los enteros, incluidos MS2000 e importes en unidades monetarias menores, usan `int` de 64 bits. Se rechazan valores decimales, cadenas y números fuera de rango en campos enteros conocidos. Conserva la diferencia entre valores ausentes y `null`; ninguno significa cero.

La paginación es explícita: reutiliza el cursor recibido y continúa hasta que falte, incluso tras una página vacía. Conserva las revisiones para escribir. Descarga a un archivo temporal y renómbralo solo tras completar la operación.

```php
$page = $api->getBankUsers($bankKid, ['pageSize' => 25, 'sort' => 'number']);
$balances = $api->getBankUserBalances($bankKid, ['userKids' => $userKids]);
$receipts = $api->getUserReceipts($userKid, ['offset' => 0]);
// Request the next page only when needed, using nextOffset and the same revision.
$stream = fopen($temporaryPath, 'w+b');
try {
    $download = $api->exportBankUsers($bankKid, $stream);
} finally {
    fclose($stream);
}
rename($temporaryPath, $completedPath);
```

## Errores, permisos y límites

| Resultado | Tratamiento |
| --- | --- |
| 400 | Corrige la solicitud según el código de error de la API. |
| 401 | La sesión se ha eliminado; inicia sesión de nuevo. |
| 403 | Revisa los permisos de la cuenta; repetir no concede acceso. |
| 404 / 409 | Recarga el objeto o revisión y resuelve datos ausentes/conflictos. |
| 429 | Respeta `Retry-After`; evita bucles de reintentos sincronizados. |
| 5xx | Muestra el fallo temporal y aplica espera y reintentos solo cuando sea seguro. |

El cliente no reintenta, pagina, renueva ni confirma automáticamente. Cada operación sigue comprobando el estado de la cuenta, Tab permitido, ámbito KID y permiso de operación del administrador. Un KID por sí solo no concede acceso. La URL del tenant queda fija al construir el cliente. Redirecciones y cookies están desactivadas. Los certificados TLS siempre se verifican; HTTP solo se acepta para direcciones loopback explícitas de desarrollo. Las llamadas desde PHP en el servidor no necesitan CORS del navegador.

Límites predeterminados: 30 segundos por llamada completa, hasta 10 segundos de conexión, 16 MiB de JSON por solicitud/respuesta, 64 KiB de cabeceras y 1 GiB por descarga. Ajusta `timeout`, `maxJsonBytes` y `maxDownloadBytes` en el constructor. Las descargas se escriben en un recurso abierto por la aplicación, que debe cerrarlo. Descarta archivos parciales tras un error. No hay reanudación de descargas ni uso simultáneo/compartido del cliente. Las cabeceras de resultados y excepciones usan minúsculas. No registres credenciales, tokens, payloads completos ni cabeceras sensibles. Protege las cookies de sesión y los formularios que modifican datos con protección CSRF.

## Compilación y verificación

Para mantenedores: `scripts/Update-PhpClients.ps1` exporta metadatos del código API actual sin iniciar trabajos ni acceder a bases de datos y genera PHP. `scripts/Test-PhpClients.ps1` comprueba la generación, prueba todas las operaciones con fixtures HTTP locales, crea ZIP deterministas, prueba los paquetes extraídos y copia únicamente las descargas PHP a ambas API. Los demás clientes conservan sus propios contratos de versión. No se publica en registros ni se despliega.


GetTerminals usa el ComputerName comunicado para el nombre, el filtro y la ordenación; los nombres ausentes están vacíos. Solicite fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight para los datos del terminal. Son cadenas, null si no se seleccionan y vacías si faltan. Mantenga fields al paginar y reinicie los cursores anteriores. Cada fila incluye el nombre de la ubicación. Consulte /docs#changelog para todos los requisitos de migración.
