import 'dart:convert';

/// A malformed or incompatible wire value. Messages never contain credentials.
class ApiProtocolException implements Exception {
  final String message;
  const ApiProtocolException(this.message);
  @override
  String toString() => 'ApiProtocolException: $message';
}

/// Lossless on the Dart VM and JavaScript: JSON integers initially become BigInt.
Object? decodeApiJson(String text) => _Parser(text).parse();

String encodeApiJson(Object? value, [int depth = 0]) {
  if (depth > 64)
    throw const ApiProtocolException('JSON nesting limit exceeded.');
  if (value == null || value is bool || value is String)
    return jsonEncode(value);
  if (value is BigInt) return value.toString();
  if (value is int) {
    if (value.abs() > 9007199254740991) {
      throw const ApiProtocolException('Use BigInt for large integers.');
    }
    return value.toString();
  }
  if (value is double && value.isFinite) return jsonEncode(value);
  if (value is List) {
    return '[${value.map((v) => encodeApiJson(v, depth + 1)).join(',')}]';
  }
  if (value is Map<String, Object?>) {
    return '{${value.entries.map((e) => '${jsonEncode(e.key)}:${encodeApiJson(e.value, depth + 1)}').join(',')}}';
  }
  throw const ApiProtocolException('Unsupported JSON value.');
}

class _Parser {
  final String text;
  int index = 0;
  _Parser(this.text);
  Never fail() => throw const ApiProtocolException('Invalid JSON.');
  void space() {
    while (index < text.length && ' \t\r\n'.contains(text[index])) {
      index++;
    }
  }

  Object? parse() {
    final result = value(0);
    space();
    if (index != text.length) fail();
    return result;
  }

  String string() {
    final start = index++;
    while (index < text.length) {
      final c = text[index++];
      if (c == '"') {
        try {
          return jsonDecode(text.substring(start, index)) as String;
        } on FormatException {
          fail();
        }
      }
      if (c == '\\') index++;
    }
    return fail();
  }

  Object? value(int depth) {
    if (depth > 64) fail();
    space();
    if (index >= text.length) fail();
    final c = text[index];
    if (c == '"') return string();
    if (c == '{') {
      index++;
      space();
      final result = <String, Object?>{};
      if (index < text.length && text[index] == '}') {
        index++;
        return result;
      }
      while (true) {
        space();
        if (index >= text.length || text[index] != '"') fail();
        final key = string();
        space();
        if (result.containsKey(key) ||
            index >= text.length ||
            text[index++] != ':')
          fail();
        result[key] = value(depth + 1);
        space();
        if (index >= text.length) fail();
        final separator = text[index++];
        if (separator == '}') return result;
        if (separator != ',') fail();
      }
    }
    if (c == '[') {
      index++;
      space();
      final result = <Object?>[];
      if (index < text.length && text[index] == ']') {
        index++;
        return result;
      }
      while (true) {
        result.add(value(depth + 1));
        space();
        if (index >= text.length) fail();
        final separator = text[index++];
        if (separator == ']') return result;
        if (separator != ',') fail();
      }
    }
    for (final literal in ['null', 'true', 'false']) {
      if (text.startsWith(literal, index)) {
        index += literal.length;
        return literal == 'null' ? null : literal == 'true';
      }
    }
    final match = RegExp(
      r'-?(?:0|[1-9][0-9]*)(?:\.[0-9]+)?(?:[eE][+-]?[0-9]+)?',
    ).matchAsPrefix(text, index);
    if (match == null) fail();
    final token = match.group(0)!;
    index = match.end;
    if (!token.contains(RegExp(r'[.eE]'))) return BigInt.parse(token);
    final number = double.tryParse(token);
    if (number == null || !number.isFinite) fail();
    return number;
  }
}
