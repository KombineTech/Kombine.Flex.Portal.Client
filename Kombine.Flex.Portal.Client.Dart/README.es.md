# Cliente Dart de Kombine Flex Portal

La versiÃ³n **0.2.2** incluye **181 operaciones** del contrato OpenAPI adjunto. Extraiga el ZIP junto a su aplicaciÃ³n, aÃ±ada la dependencia local y ejecute `dart pub get` o `flutter pub get`. La aplicaciÃ³n proporciona las credenciales del ejemplo.

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
