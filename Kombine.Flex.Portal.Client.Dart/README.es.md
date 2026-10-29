La versión 0.9.0 incluye 202 operaciones, entre ellas GetUnitTimeline y GetUnitTimelineFields. Las respuestas de Wallboard identifican la pantalla aprobada exacta; las sesiones de pantalla exponen solo una identidad mínima, sin permisos de administrador. Use una sesión normal para las operaciones de Portal. La aprobación permanente y UserBalance siguen siendo compatibles. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.8.0 añade FindWallboardPairings y GetWallboardDevice (200 operaciones en total), además de metadatos opcionales de ubicación al aprobar una pantalla. La configuración central de Wallboard utiliza un único escaneo QR; la ubicación privada solo está disponible para el administrador que aprobó el dispositivo. La aprobación no caduca automáticamente y conserva las comprobaciones de revocación, credenciales, tenant y entorno. Los clientes UserBalance existentes siguen siendo compatibles. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog) y la [guía Wallboard](https://api.team.kombine.technology/docs#wallboard-pairing).

La versión 0.7.0 añade siete operaciones para vincular y gestionar pantallas Wallboard (198 en total). Un administrador activo aprueba cada pantalla una vez; la aprobación del dispositivo no caduca automáticamente. Mantenga la clave privada ECDSA P-256 no exportable en la pantalla, firme desafíos de un solo uso para reconectar y no incluya credenciales ni tokens bearer en URL o almacenamiento del navegador. Se conservan la revocación y las comprobaciones de la cuenta y credenciales del administrador. La sesión de diez días no limita la aprobación. UserBalance mantiene la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog) y la [guía Wallboard](https://api.team.kombine.technology/docs#wallboard-pairing).

La versión 0.6.0 añade la lista de liquidaciones de solo lectura, el historial y reconocimiento de errores, la consulta y restauración de máquinas fuera de servicio y el acceso autorizado a eVaskeri del residente. La búsqueda de residentes incluye bankKid. Todas las operaciones mantienen la autorización del administrador, tenant y recurso. Los enlaces de eVaskeri son credenciales sensibles: ábralos inmediatamente sin opener/referrer y nunca los registre ni almacene. No repita automáticamente solicitudes de modificación tras una respuesta incierta. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.5.0 utiliza GetPublicCycleWidget y GetCycleChartPresentation. Sustituya las rutas retiradas de widgets/presentación WashDoc por /api/v1/public/widgets/cycle y /api/v1/public/cycle-chart/presentation. Los parámetros de ruta y los campos de tablas/gráficos/widgets usan cycleKid; el campo de visualización del widget es cycleKidText. Se mantienen los valores KID y los ID de las operaciones de documentos. Recompile los clientes y actualice las referencias a campos. UserBalance conserva la compatibilidad. Consulte el [registro de cambios](https://api.team.kombine.technology/docs#changelog).

La versión 0.4.0 sincroniza idioma, fecha/hora, formato numérico y espaciado personal. Los widgets WashDoc sustituyen unitKidText por documentKidText; graphSvg puede ser null sin mediciones. Detenga el sondeo con refreshAfterSeconds=0; los documentos en curso usan 15 segundos. Las sesiones de administrador duran diez días: use expiresIn de la respuesta y renueve solo tras actividad. UserBalance sigue siendo compatible. Consulte el [registro de cambios](/docs#changelog).

La versión 0.3.0 mueve ConvertToolTime e InspectToolKid a /api/v1/tenant/tools/time y /api/v1/tenant/tools/kid. Quite el argumento bankKid al recompilar; el sitio selecciona el tenant. Se mantienen manager activo, More1, Bank Read y un permiso de recurso del tenant del sitio. Los cuerpos y respuestas JSON no cambian. GetUnitDocumentNeighbors añade navegación autorizada entre documentos de la misma unidad. Consulte el [registro de cambios](/docs#changelog).

# Cliente Dart de Kombine Flex Portal

La versiÃ³n **0.9.0** incluye **182 operaciones** del contrato OpenAPI adjunto. Extraiga el ZIP junto a su aplicaciÃ³n, aÃ±ada la dependencia local y ejecute `dart pub get` o `flutter pub get`. La aplicaciÃ³n proporciona las credenciales del ejemplo.

```yaml
dependencies:
  kombine_flex_portal_client:
    path: ../Kombine.Flex.Portal.Client.Dart
```

```dart
import 'package:kombine_flex_portal_client/kombine_flex_portal_client.dart';

final client = PortalClient('https://api.team.kombine.technology/');
try {
  await client.login({'email': email, 'password': password});
  final result = await client.getBanks();
  print(result); // Synthetic examples only: do not log personal data.
} finally {
  client.close();
}
```

Los objetos son mapas con los nombres JSON exactos, no clases con campos tipados. int64 siempre usa `BigInt`, int32 usa `int` y las fechas son cadenas ISO. Utilice `encodeApiJson` y `decodeApiJson` para conservar los enteros y la diferencia entre null y campos ausentes. Consulte [OPERATIONS.md](OPERATIONS.md).

`login` conserva el token bearer; `clearSession()` lo elimina. Los mÃ©todos generados de inicio o renovaciÃ³n no actualizan la sesiÃ³n automÃ¡ticamente. Aplique el token renovado deliberadamente. Una respuesta tardÃ­a no restaura una sesiÃ³n eliminada. El servidor siempre verifica identidad, tenant y permisos.

Capture `ApiException` y examine `status`, `code` y `headers`. Trate HTTP 400 como entrada invÃ¡lida, 401 como problema de sesiÃ³n, 403 como permiso insuficiente, 404 como recurso ausente y 409 como conflicto. Respete Retry-After para 429/503 cuando corresponda. No repita automÃ¡ticamente una mutaciÃ³n cuyo resultado sea incierto. No registre credenciales ni cuerpos sensibles.

El plazo absoluto predeterminado es de 30 segundos, incluida la descarga, y el lÃ­mite JSON es de 8 MiB; ambos son configurables. Cada mÃ©todo admite `cancel: completer.future`. La cancelaciÃ³n produce `ApiCancelledException`, el vencimiento `TimeoutException` y los datos invÃ¡lidos `ApiProtocolException`. Cierre el cliente con `close()`; un transporte inyectado sigue perteneciendo a su aplicaciÃ³n.

Los archivos binarios usan `ApiDownload`: consuma `chunks` una vez y cierre en finally. Multipart usa `ApiUploadFile` con una fÃ¡brica de streams nueva y longitud exacta. Se requiere HTTPS salvo loopback local. No hay reintentos ni redirecciones automÃ¡ticos. Flutter Web necesita CORS autorizado por el servidor y almacena las subidas en memoria; el transporte nativo permite streaming. Se probaron Dart 3.6.2 y 3.13.6 y precisiÃ³n numÃ©rica en JavaScript, pero no dispositivos Flutter.

La [guÃ­a inglesa](README.md) documenta generaciÃ³n, pruebas y empaquetado. El ZIP incluye cÃ³digo, contrato, pruebas y las tres guÃ­as. El empaquetado no publica ni despliega nada. HTTP 202 de captura de cÃ¡mara significa aceptada, no completada. Compruebe ConfirmCameraCapture explÃ­citamente; no hay sondeo automÃ¡tico.

[GuÃ­a API](https://api.team.kombine.technology/docs/es) Â· [Cambios del contrato, en inglÃ©s](https://api.team.kombine.technology/docs#changelog) Â· [English](README.md) Â· [Dansk](README.da.md)
