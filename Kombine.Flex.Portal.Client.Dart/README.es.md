# Cliente Dart de Kombine Flex Portal

La versión **0.2.1** incluye **178 operaciones** del contrato OpenAPI adjunto. Extraiga el ZIP junto a su aplicación, añada la dependencia local y ejecute `dart pub get` o `flutter pub get`. La aplicación proporciona las credenciales del ejemplo.

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

`login` conserva el token bearer; `clearSession()` lo elimina. Los métodos generados de inicio o renovación no actualizan la sesión automáticamente. Aplique el token renovado deliberadamente. Una respuesta tardía no restaura una sesión eliminada. El servidor siempre verifica identidad, tenant y permisos.

Capture `ApiException` y examine `status`, `code` y `headers`. Trate HTTP 400 como entrada inválida, 401 como problema de sesión, 403 como permiso insuficiente, 404 como recurso ausente y 409 como conflicto. Respete Retry-After para 429/503 cuando corresponda. No repita automáticamente una mutación cuyo resultado sea incierto. No registre credenciales ni cuerpos sensibles.

El plazo absoluto predeterminado es de 30 segundos, incluida la descarga, y el límite JSON es de 8 MiB; ambos son configurables. Cada método admite `cancel: completer.future`. La cancelación produce `ApiCancelledException`, el vencimiento `TimeoutException` y los datos inválidos `ApiProtocolException`. Cierre el cliente con `close()`; un transporte inyectado sigue perteneciendo a su aplicación.

Los archivos binarios usan `ApiDownload`: consuma `chunks` una vez y cierre en finally. Multipart usa `ApiUploadFile` con una fábrica de streams nueva y longitud exacta. Se requiere HTTPS salvo loopback local. No hay reintentos ni redirecciones automáticos. Flutter Web necesita CORS autorizado por el servidor y almacena las subidas en memoria; el transporte nativo permite streaming. Se probaron Dart 3.6.2 y 3.13.6 y precisión numérica en JavaScript, pero no dispositivos Flutter.

La [guía inglesa](README.md) documenta generación, pruebas y empaquetado. El ZIP incluye código, contrato, pruebas y las tres guías. El empaquetado no publica ni despliega nada. HTTP 202 de captura de cámara significa aceptada, no completada. Compruebe ConfirmCameraCapture explícitamente; no hay sondeo automático.

[Guía API](https://api.team.kombine.technology/docs/es) · [Cambios del contrato, en inglés](https://api.team.kombine.technology/docs#changelog) · [English](README.md) · [Dansk](README.da.md)
