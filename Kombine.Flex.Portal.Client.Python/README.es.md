La versión 0.5.2 incluye 120 operaciones. GetUnits añade el directorio de unidades autorizado: mantenga filtros y fields al paginar y reinicie ante invalid-cursor. Los roles de administrador requieren las nueve categorías de expectedFlags, incluidas Tabs y Kids; gestione sus permisos independientes y las respuestas 403. Se eliminan las asignaciones de acceso de servicios: deje de enviar esas solicitudes y de leer el objeto access. Las partes del logotipo se indican en la ruta antes del color, no en parámetros de consulta. UserBalance sigue siendo compatible. Consulte /docs#changelog para la migración y /docs#unit-directory para paginación y ejemplos.

Versión 0.5.2: GetLocations requiere ahora fields=vismaCustNo,bankActivationCode,locationActivationCode para conservar los valores opcionales anteriores; acepte null para campos no seleccionados. Mantenga fields al paginar y reinicie los cursores anteriores. Las nuevas sugerencias de números de residentes son de solo lectura y no reservan un número. Las respuestas de activación incluyen qrCodeDataV1 y qrCodeDataV2 (cinco valores con ruido y suma de comprobación de 30 bits); trate ambos como credenciales. Consulte /docs#changelog para la migración y /docs para permisos y errores.

a versión 0.5.2 actualiza la documentación de GetBankUserBalances al plazo de base de datos de 20 segundos. Los campos de solicitud y respuesta no cambian. Reserve tiempo adicional para transporte y autorización; HTTP 503 sigue sin devolver saldos parciales.

La versión 0.2.5 añade los campos opcionales latestPostingMs2000 y hasActiveSubscription a GetBankUserBalances. La fecha del asiento es un entero de 64 bits en milisegundos UTC desde 2000-01-01; cero indica que no hay asientos. Null o un campo ausente significa desconocido; los residentes inexistentes u ocultos devuelven null. El estado de suscripción no confirma un pago. Mantenga el tratamiento de saldos y los permisos existentes; consulte /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

La versión 0.2.5 añade `GetUserReceipts` y `GetHostingMetrics` para versiones de la API que ofrecen estas operaciones. Cargue los recibos bajo demanda: solicite offset 0 y continúe con `nextOffset` y la misma `revision`. Ante HTTP 409 (`receipts-changed`), descarte las páginas anteriores y reinicie en offset 0. Mantenga las monedas separadas y los importes como enteros de 64 bits en unidades menores. Consulte [recibos](/docs#user-receipts) y [métricas](/docs#hosting) para los permisos y límites.

<!-- api-contract-changelog -->
[Changelog del contrato de la API (inglés)](https://api.team.kombine.technology/docs#changelog)

Use el mismo tenant y entorno que su cliente: añada /docs#changelog a la URL base de la API. El enlace anterior usa Team como ejemplo público. Este registro cubre cambios de solicitud/respuesta de endpoints existentes que pueden romper el código del cliente, no correcciones internas de funciones.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — cliente Python

`kombine-flex-portal-client` admite **Python 3.11+** y las **120 operaciones públicas**. No necesita dependencias de ejecución, .NET, NuGet ni otras bibliotecas Kombine. Solo usa la biblioteca estándar de Python. Los permisos y las reglas de negocio siguen en la API.

El paquete **todavía no está publicado en PyPI**. Instale la distribución local:

```sh
python -m pip install ./kombine_flex_portal_client-0.5.2-py3-none-any.whl
```

La versión 0.5.2 corresponde al candidato beta actual (120 operaciones). Cambie los campos de respuesta `icon`, `bankIcon` y `unitIcon` por `iconKid`, `bankIconKid` y `unitIconKid`. Use las rutas de iconos con un conjunto explícito descritas en el [registro de cambios de la API](/docs#changelog). La operación generada `RenewManagerSession` renueva una sesión de administrador que aún no ha caducado; asigne el token devuelto al mismo cliente antes de continuar. No existe un token de renovación separado ni renovación automática. Las descargas de Windows devuelven streams; estos clientes solicitan archivos completos, sin cabeceras de rango ni condicionales.

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
