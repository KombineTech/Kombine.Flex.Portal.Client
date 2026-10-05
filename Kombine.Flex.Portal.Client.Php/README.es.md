Versión 0.4.1: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Cliente PHP de Kombine Flex Portal

[Changelog del contrato API](https://api.team.kombine.technology/docs#changelog) — utiliza `/docs#changelog` en la API del mismo tenant y entorno que el cliente. El changelog está solo en inglés.

Versión **0.4.1**, preparada localmente; no desplegada ni publicada en Packagist. Incluye 114 operaciones públicas del contrato OpenAPI adjunto. Requiere **PHP 8.2+ de 64 bits**, `ext-curl`, `ext-json`, HTTPS y certificados CA de confianza. No necesita bibliotecas PHP externas ni ensamblados internos de Kombine. El transporte admite Windows, Linux y macOS; esta versión se probó con Windows CLI. Utiliza una versión de PHP con soporte vigente.

La versión 0.3.1 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales. La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances. La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites. La versión 0.2.5 añade GetUserReceipts y GetHostingMetrics para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda desde offset 0. Continúe con nextOffset y la misma revision; ante HTTP 409 (receipts-changed), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte /docs#user-receipts y /docs#hosting para los permisos y límites.

Para este candidato beta, cambie los campos icon/bankIcon/unitIcon por iconKid/bankIconKid/unitIconKid y use rutas de iconos con un conjunto explícito. Consulte el registro de cambios para las rutas eliminadas. Las descargas de aplicaciones devuelven DownloadResponse y escriben bytes en el stream proporcionado.

## Instalación

Descarga `kombine-flex-portal-client-php-0.4.1.zip` desde la sección PHP de la guía API. Con Composer, guarda el ZIP en el directorio `packages/` de la aplicación:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-portal-client:0.4.1
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
