import 'package:PACKAGE/PACKAGE.dart';

void main() {
  final value = decodeApiJson(
    '{"id":9223372036854775807,"balance":-9223372036854775808}',
  ) as Map;
  if (value['id'] != BigInt.parse('9223372036854775807') ||
      value['balance'] != BigInt.parse('-9223372036854775808')) {
    throw StateError('JavaScript lost int64 precision.');
  }
  final encoded = encodeApiJson(value.cast<String, Object?>());
  if (encoded != '{"id":9223372036854775807,"balance":-9223372036854775808}')
    throw StateError('Invalid JSON encoding.');
  print('Dart JavaScript int64 smoke test passed.');
}
