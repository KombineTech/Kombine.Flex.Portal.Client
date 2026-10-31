La versión 0.22.0 añade diseños personales de Wallboard, registro de pantallas escaneadas y lectura del diseño por revisión. Guarde solo identificadores ya escaneados con la última revisión. Conserve los borradores ante conflictos y nunca repita automáticamente escrituras inciertas. Las sesiones de pantalla solo pueden leer su pantalla aprobada. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.22.0 incluye 206 operaciones, entre ellas GetUnitTimeline y GetUnitTimelineFields. Las respuestas de Wallboard identifican la pantalla aprobada exacta; las sesiones de pantalla exponen solo una identidad mínima, sin permisos de administrador. Use una sesión normal para las operaciones de Portal. La aprobación permanente y UserBalance siguen siendo compatibles. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.18.0 añade FindWallboardPairings y GetWallboardDevice (200 operaciones en total), además de metadatos opcionales de ubicación al aprobar una pantalla. La configuración central de Wallboard utiliza un único escaneo QR; la ubicación privada solo está disponible para el administrador que aprobó el dispositivo. La aprobación no caduca automáticamente y conserva las comprobaciones de revocación, credenciales, tenant y entorno. Los clientes UserBalance existentes siguen siendo compatibles. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog) y la [guía Wallboard](https://api.team.kombine.technology/docs#wallboard-pairing).

La versión 0.17.0 añade siete operaciones para vincular y gestionar pantallas Wallboard (198 en total). Un administrador activo aprueba cada pantalla una vez; la aprobación del dispositivo no caduca automáticamente. Mantenga la clave privada ECDSA P-256 no exportable en la pantalla, firme desafíos de un solo uso para reconectar y no incluya credenciales ni tokens bearer en URL o almacenamiento del navegador. Se conservan la revocación y las comprobaciones de la cuenta y credenciales del administrador. La sesión de diez días no limita la aprobación. UserBalance mantiene la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog) y la [guía Wallboard](https://api.team.kombine.technology/docs#wallboard-pairing).

La versión 0.16.0 añade la lista de liquidaciones de solo lectura, el historial y reconocimiento de errores, la consulta y restauración de máquinas fuera de servicio y el acceso autorizado a eVaskeri del residente. La búsqueda de residentes incluye bankKid. Todas las operaciones mantienen la autorización del administrador, tenant y recurso. Los enlaces de eVaskeri son credenciales sensibles: ábralos inmediatamente sin opener/referrer y nunca los registre ni almacene. No repita automáticamente solicitudes de modificación tras una respuesta incierta. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.15.0 utiliza GetPublicCycleWidget y GetCycleChartPresentation. Sustituya las rutas retiradas de widgets/presentación WashDoc por /api/v1/public/widgets/cycle y /api/v1/public/cycle-chart/presentation. Los parámetros de ruta y los campos de tablas/gráficos/widgets usan cycleKid; el campo de visualización del widget es cycleKidText. Se mantienen los valores KID y los ID de las operaciones de documentos. Recompile los clientes y actualice las referencias a campos. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.14.0 sincroniza idioma, fecha/hora, formato numérico y espaciado personal. Los widgets WashDoc sustituyen unitKidText por documentKidText; graphSvg puede ser null sin mediciones. Detenga el sondeo con refreshAfterSeconds=0; los documentos en curso usan 15 segundos. Las sesiones de administrador duran diez días: use expiresIn de la respuesta y renueve solo tras actividad. UserBalance sigue siendo compatible. Consulte el [registro de cambios](/docs#changelog).

La versión 0.13.0 mueve ConvertToolTime e InspectToolKid a /api/v1/tenant/tools/time y /api/v1/tenant/tools/kid. Quite el argumento bankKid al recompilar; el sitio selecciona el tenant. Se mantienen manager activo, More1, Bank Read y un permiso de recurso del tenant del sitio. Los cuerpos y respuestas JSON no cambian. GetUnitDocumentNeighbors añade navegación autorizada entre documentos de la misma unidad. Consulte el [registro de cambios](/docs#changelog).

## Calendarios de reservas de la ubicación · 0.13.0

`GetLocationBookingCalendars` devuelve calendarios con fechas y horarios de apertura aplicados por la API. Parámetros opcionales: from=yyyy-MM-dd y days=1-31 (14 por defecto); la respuesta contiene timeZone, from, days y date para cada día. Muestre las fechas directamente y solicite otro intervalo al navegar, sin repetir semanas ni combinar horarios en el cliente. Los grupos incluyen unidades autorizadas y estado Configured; se omiten los calendarios almacenados no válidos. startMinute es 0-1439, durationMinutes es positivo y su suma no supera 1440. Tipo 0=reserva, 1=oportunidad, 2=cerrado, 3=horario desconocido. No muestre lo desconocido como reservable. Requiere Bookings1, Location Read, Unit Read y acceso al recurso. Muestre cada máquina por separado. Es configuración, no ocupación ni disponibilidad. Gestione 400/401/403/404/503 explícitamente. Consulte [calendarios](/docs#location-booking-calendars) y [changelog](/docs#changelog).

La versión 0.13.0 incluye 182 operaciones. SaveCameraCapture admite procesamiento opcional en segundo plano; HTTP 202 solo confirma almacenamiento temporal. Conserve los archivos originales y el token de carga y llame a ConfirmCameraCapture hasta que confirmed sea true. processingPercent es una estimación y puede ser null; errorCode puede indicar un fallo. Tras reiniciar el servidor, reintente con los mismos archivos y token si la publicación no está confirmada. Recompile las llamadas con las firmas actualizadas de SaveCameraCapture y use argumentos con nombre cuando estén disponibles. El comportamiento síncrono predeterminado de la API no cambia. Consulte /docs#camera-captures y /docs#changelog.

La versión 0.13.0 incluye GetCameraNearestLocation para seleccionar ubicación mediante GPS y GetRecentCameraPhotoMetadata para información protegida. Los recursos incluyen control de proximidad y coordenadas anulables. Los nuevos nombres son GUID opacos; no extraigas región ni nombre original. La selección exige Camera1 y Location Read/Write; los metadatos exigen Read del recurso. Sin GPS o con 404/409, elige la ubicación manualmente. Consulta /docs#camera-captures y /docs#changelog.

## Fotos recientes de la cámara · 0.13.0

Añade `GetPublicRecentCameraPhotos` y `GetPublicCameraThumbnail`. Estas operaciones públicas no requieren inicio de sesión y están vinculadas al tenant del sitio. La lista devuelve hasta diez fotos con URL temporales de miniaturas y rutas del portal. Las miniaturas son públicas; los originales y metadatos siguen protegidos. Abrir el espacio requiere los permisos normales del administrador. Gestione 503 si la lista no está disponible y 400/404 para miniaturas no válidas, caducadas o ausentes. Consulte [widgets públicos](/docs#public-widgets).

## Tiempo de la ubicación · 0.13.0

La versión 0.13.0 incluye las 182 operaciones y contiene `GetLocationWeather` para un KID canónico de ubicación. Reutilice la sesión del administrador. La API exige Tab asignado, Bank Read, Location Read, ámbito autorizado y ubicación/banco visibles. Resuelve coordenadas guardadas o la dirección de la ubicación; el cliente nunca envía claves del proveedor ni coordenadas. Compruebe `status`: `Available` contiene `current`; `LocationUnknown` y `Unavailable` no contienen mediciones. Los valores desconocidos son null, nunca cero. Temperatura en Celsius, viento en m/s, precipitación en mm, humedad en porcentaje y horas UTC. La posición obtenida de la dirección puede ser aproximada. Muestre: Weather data by Open-Meteo, CC BY 4.0. Gestione HTTP 400/401/403/404/503 normalmente y reintente de forma deliberada; un fallo del proveedor también puede devolver HTTP 200 con `Unavailable`. Consulte [tiempo de la ubicación](/docs#location-weather).

```python
weather = api.get_location_weather(location_kid)
if weather.get("status") == "Available" and weather.get("current") is not None:
    print(weather["current"]["temperatureCelsius"])
```

## Camera1 · 0.8.0

La versión 0.8.0 incluye las 148 operaciones públicas, incluida Camera1. Llame a PrepareCameraCapture con SHA-256 y longitud exactos del original, fecha UTC, KID del recurso y objeto de sensores; cargue los mismos bytes con uploadToken. Live Photos requiere además la longitud/hash y el MOV original asociado. Conserve el token y los bytes para un reintento deliberado; no hay reintentos automáticos. Aumente el plazo para procesar vídeo. La API exige Camera1 y permisos Read/Write del recurso exacto. Las listas pueden estar degradadas o devolver páginas vacías con nextCursor; continúe hasta que no haya cursor. Descargue por la API; Range puede devolver HTTP 206. Consulte /docs#camera-captures para límites y errores.

```python
from kombine_flex_portal import PortalUploadFile

# upload_token comes from prepare_camera_capture for these exact bytes.
with open(original_path, "rb") as original:
    saved = api.save_camera_capture({
        "uploadToken": upload_token,
        "original": PortalUploadFile(original, "capture.jpg"),
    })
```

Streams remain caller-owned and must be seekable. Rewind before a deliberate retry. Add `motion: PortalUploadFile(...)` for Live Photos. Maximum multipart body: 140 MiB; text fields: 512 KiB each.

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

# Kombine Flex Portal — cliente Python

`kombine-flex-portal-client` admite **Python 3.11+** y las **182 operaciones públicas**. No necesita dependencias de ejecución, .NET, NuGet ni otras bibliotecas Kombine. Solo usa la biblioteca estándar de Python. Los permisos y las reglas de negocio siguen en la API.

El paquete **todavía no está publicado en PyPI**. Instale la distribución local:

```sh
python -m pip install ./kombine_flex_portal_client-0.13.0-py3-none-any.whl
```

La versión 0.13.0 corresponde al candidato beta actual (182 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

La versión 0.2.5 añade GetLocationOpeningHours y GetLocationBookingRules. Ambas requieren Location Read, Unit Read y acceso a la ubicación. Las reglas contienen texto plano y parts ordenadas con text/isValue para resaltar valores de forma opcional; nunca interprete estas cadenas como HTML. Use text como alternativa para respuestas anteriores. Consulte /docs#location-opening-hours y /docs#location-booking-rules para permisos, ejemplos y límites.

## Tenant, inicio de sesión y pestañas

Seleccione primero la **URL HTTPS de la API**, terminada en `/`, y después introduzca las credenciales. Obtenga la dirección del administrador, por ejemplo https://api.team.kombine.technology/; no use la dirección del portal. Cree un cliente y una sesión independientes por usuario, tenant y entorno. Los valores del ejemplo proceden de su aplicación; no incluya contraseñas reales en el código.

```python
from kombine_flex_portal import PortalClient, PortalApiError

with PortalClient(tenant_api_url, timeout=30) as api:
    try:
        api.login(email, password)
        manager = api.get_current_manager()
        for tab in manager.get("tabDetails") or []:
            print(tab.get("id"), tab.get("name"))
    except PortalApiError as error:
        print(error.status, error.code)
```

`login()` conserva el bearer en memoria. `login_manager(body)` no conserva la sesión; puede asignar un token existente a `access_token`. Las operaciones públicas nunca envían el token. No se usan cookies ni almacenamiento persistente. `clear_session()`/`close()` eliminan el token local; 401 elimina la sesión afectada. No existe un token de renovación separado ni revocación de tokens en el servidor. No se conserva la contraseña. Nunca registre tokens o respuestas completas.

## Operaciones y datos

Los métodos usan los identificadores de operación en snake_case; consulte [OPERATIONS.md](OPERATIONS.md). Conserve KIDs, cursores y revisiones exactamente. El cliente codifica las URL y conserva los nombres originales de parámetros, como Period e IncludeZero. La paginación requiere llamadas explícitas hasta que no haya cursor. Los lotes de saldos admiten hasta 50 residentes del mismo banco; reduzca el lote si hay timeout. No hay reintentos automáticos, llamadas ocultas, permisos adicionales ni paginación automática.

```python
page = api.get_bank_users(bank_kid, page_size=25, sort="number", direction="asc")
balances = api.get_bank_user_balances(bank_kid, {"userKids": user_kids})
account = api.get_bank_account(bank_kid, period=0, include_zero=False, limit=50)
units = api.get_location_units(location_kid, accept_language="es-ES")
with api.export_bank_users(bank_kid) as download:
    with open("residents.csv", "wb") as target:
        for chunk in download.iter_bytes():
            target.write(chunk)
```

Los modelos son TypedDict en `kombine_flex_portal.models`. Los nombres JSON, como userKids, se conservan. También se conservan campos desconocidos; null y un campo ausente no son cero. Las fechas son cadenas ISO y todos los enteros, incluidos saldos int64, usan int exactos de Python.

Las llamadas son síncronas. Use un hilo de trabajo en aplicaciones asíncronas o gráficas. `timeout=30` es un tiempo de espera de E/S del socket, no un plazo total de descarga. `close()` impide nuevas llamadas, pero no cancela las existentes. Las descargas se leen por bloques y deben cerrarse con `with`.

## Errores y transporte

PortalApiError expone status, code, headers (claves en minúsculas) y response. Response puede contener datos personales; el texto de la excepción solo incluye el estado HTTP. 400: corrija la entrada; 401: inicie sesión; 403: acceso denegado; 404: recurso no disponible en el alcance actual; 409: recargue la revisión; 429/503: respete Retry-After y espere. No repita automáticamente modificaciones cuyo resultado sea desconocido. Los errores de red usan URLError/OSError/TimeoutError. PortalProtocolError indica JSON inválido o demasiado grande.

HTTPS mantiene la validación normal de certificados. HTTP solo se permite en loopback para pruebas; se rechazan redirecciones. JSON está limitado a 16 MiB (max_json_bytes) y 64 niveles. Las descargas no usan ese límite JSON. Tener una pestaña no concede acceso ilimitado, y no se incluye el inicio de sesión de desarrollo por ID numérico.

## Compilación y mantenimiento

```sh
python -m pip install -e . --no-deps
python -m unittest discover -s tests -v
```

Los dos clientes se generan desde Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json con `python scripts/Generate-PortalScriptClients.py`; `--check` detecta diferencias. El contrato no es una dependencia de ejecución. `scripts/Test-PortalScriptClients.ps1` prueba y crea wheel, sdist y tarball npm en artifacts/packages, con datos locales sintéticos. Setuptools y wheel son herramientas de desarrollo, no dependencias de ejecución. Las pruebas no publican los paquetes.

El inglés es el idioma principal; se incluyen alternativas en danés y español. Copyright Kombine Technology ApS.
