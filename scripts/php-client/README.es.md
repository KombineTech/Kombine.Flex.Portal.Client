[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

# Cliente PHP de Kombine Flex __API__

[Changelog del contrato API](__ORIGIN__/docs#changelog) — utiliza `/docs#changelog` en la API del mismo tenant y entorno que el cliente. El changelog está solo en inglés.

Versión **0.1.0**, preparada localmente; no desplegada ni publicada en Packagist. Incluye __COUNT__ operaciones públicas del contrato OpenAPI adjunto. Requiere **PHP 8.2+ de 64 bits**, `ext-curl`, `ext-json`, HTTPS y certificados CA de confianza. No necesita bibliotecas PHP externas ni ensamblados internos de Kombine. El transporte admite Windows, Linux y macOS; esta versión se probó con Windows CLI. Utiliza una versión de PHP con soporte vigente.

## Instalación

Descarga `__ZIP__` desde la sección PHP de la guía API. Con Composer, guarda el ZIP en el directorio `packages/` de la aplicación:

```sh
composer config repositories.kombine artifact ./packages
composer require kombine/flex-__LOWER__-client:0.1.0
```

El repositorio artifact de Composer requiere `ext-zip` durante la instalación. Sin Composer, extrae el ZIP en `flex-__LOWER__-client/` y sustituye la línea de autoload por `require __DIR__ . '/flex-__LOWER__-client/autoload.php';`. Conserva todo `src/`, incluido `contract.json`. Ambos paquetes se pueden cargar juntos.

## Inicio de sesión y primera llamada

__AUTH__ Obtén las variables siguientes de la configuración protegida o del formulario de acceso. La URL de la API del tenant debe terminar en `/`.

```php
<?php
declare(strict_types=1);
require __DIR__ . '/vendor/autoload.php';

use Kombine\Flex\__API__\__API__Client;
use Kombine\Flex\__API__\ApiException;
use Kombine\Flex\__API__\ProtocolException;
use Kombine\Flex\__API__\TransportException;

$api = new __API__Client($tenantUrl, timeout: 30);
try {
    $session = $api->login(__LOGIN__);
    $result = $api->__FIRST__();
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

`login()` conserva el bearer en memoria; la operación directa `__RAWLOGIN__($body)` solo lo devuelve. `setAccessToken($token)` y `getAccessToken()` permiten reutilizar una sesión desde almacenamiento protegido del servidor. No compartas clientes entre usuarios o tenants. `clearSession()` y `close()` descartan el token local; las copias existentes conservan su caducidad. No se guardan credenciales. Las operaciones anónimas omiten el token. HTTP 401 lo elimina, incluso con respuestas de error incorrectas o demasiado grandes. __SESSION__

## Métodos y valores

[OPERATIONS.md](OPERATIONS.md) enumera los identificadores estables y métodos PHP; [MODELS.md](MODELS.md) describe los arrays. Las claves de `$options` respetan exactamente los nombres y mayúsculas de la API. Los objetos son arrays asociativos; las listas son arrays indexados. Un array vacío se convierte en objeto JSON cuando el contrato exige un objeto. Fechas, KID, cursores y revisiones permanecen como cadenas; no los reconstruyas ni interpretes. Los enteros, incluidos MS2000 e importes en unidades monetarias menores, usan `int` de 64 bits. Se rechazan valores decimales, cadenas y números fuera de rango en campos enteros conocidos. Conserva la diferencia entre valores ausentes y `null`; ninguno significa cero.

__DETAILS__

## Errores, permisos y límites

| Resultado | Tratamiento |
| --- | --- |
| 400 | Corrige la solicitud según el código de error de la API. |
| 401 | La sesión se ha eliminado; inicia sesión de nuevo. |
| 403 | Revisa los permisos de la cuenta; repetir no concede acceso. |
| 404 / 409 | Recarga el objeto o revisión y resuelve datos ausentes/conflictos. |
| 429 | Respeta `Retry-After`; evita bucles de reintentos sincronizados. |
| 5xx | Muestra el fallo temporal y aplica espera y reintentos solo cuando sea seguro. |

El cliente no reintenta, pagina, renueva ni confirma automáticamente. __PERMISSIONS__ La URL del tenant queda fija al construir el cliente. Redirecciones y cookies están desactivadas. Los certificados TLS siempre se verifican; HTTP solo se acepta para direcciones loopback explícitas de desarrollo. Las llamadas desde PHP en el servidor no necesitan CORS del navegador.

Límites predeterminados: 30 segundos por llamada completa, hasta 10 segundos de conexión, 16 MiB de JSON por solicitud/respuesta, 64 KiB de cabeceras y 1 GiB por descarga. Ajusta `timeout`, `maxJsonBytes` y `maxDownloadBytes` en el constructor. Las descargas se escriben en un recurso abierto por la aplicación, que debe cerrarlo. Descarta archivos parciales tras un error. No hay reanudación de descargas ni uso simultáneo/compartido del cliente. Las cabeceras de resultados y excepciones usan minúsculas. No registres credenciales, tokens, payloads completos ni cabeceras sensibles. Protege las cookies de sesión y los formularios que modifican datos con protección CSRF.

## Compilación y verificación

Para mantenedores: `scripts/Update-PhpClients.ps1` exporta metadatos del código API actual sin iniciar trabajos ni acceder a bases de datos y genera PHP. `scripts/Test-PhpClients.ps1` comprueba la generación, prueba todas las operaciones con fixtures HTTP locales, crea ZIP deterministas, prueba los paquetes extraídos y copia únicamente las descargas PHP a ambas API. Los demás clientes conservan sus propios contratos de versión. No se publica en registros ni se despliega.


GetTerminals usa el ComputerName comunicado para el nombre, el filtro y la ordenación; los nombres ausentes están vacíos. Solicite fields=versionMinor,bootReason,booted,firmware,storageCardSerialNumber,page,backLight para los datos del terminal. Son cadenas, null si no se seleccionan y vacías si faltan. Mantenga fields al paginar y reinicie los cursores anteriores. Cada fila incluye el nombre de la ubicación. Consulte /docs#changelog para todos los requisitos de migración.
