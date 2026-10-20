import 'dart:async';
import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:http_parser/http_parser.dart';

import 'json.dart';

class ApiSessionException implements Exception {
  final String message;
  const ApiSessionException(this.message);
  @override
  String toString() => 'ApiSessionException: $message';
}

class ApiCancelledException implements Exception {
  const ApiCancelledException();
  @override
  String toString() => 'API request cancelled.';
}

class ApiException implements Exception {
  final int status;
  final String responseBody;
  final Map<String, String> headers;
  final String? code;
  ApiException(this.status, this.responseBody, Map<String, String> headers)
    : headers = Map.unmodifiable(headers),
      code = _code(responseBody);
  static String? _code(String body) {
    try {
      final parsed = decodeApiJson(body);
      return parsed is Map && parsed['code'] is String
          ? parsed['code'] as String
          : null;
    } on ApiProtocolException {
      return null;
    }
  }

  @override
  String toString() => 'API request failed (HTTP $status).';
}

/// The stream factory must produce the exact bytes described by length.
class ApiUploadFile {
  final Stream<List<int>> Function() openRead;
  final int length;
  final String filename;
  final String contentType;
  ApiUploadFile(
    this.openRead,
    this.length,
    this.filename, {
    this.contentType = 'application/octet-stream',
  }) {
    if (length < 0 ||
        filename.isEmpty ||
        filename.contains(RegExp(r'[\x00-\x1f\x7f/\\"]'))) {
      throw ArgumentError('Invalid upload metadata.');
    }
    MediaType.parse(contentType);
  }
}

Stream<List<int>> _uploadBytes(ApiUploadFile file) async* {
  var count = 0;
  await for (final chunk in file.openRead()) {
    count += chunk.length;
    if (count > file.length || chunk.any((b) => b < 0 || b > 255)) {
      throw const ApiProtocolException(
        'Upload bytes do not match the declared length.',
      );
    }
    yield chunk;
  }
  if (count != file.length)
    throw const ApiProtocolException('Upload was truncated.');
}

class _Scope {
  final abort = Completer<void>();
  final failure = Completer<Never>();
  final void Function() onFinish;
  late final Timer timer;
  bool finished = false;
  _Scope(Duration timeout, Future<void>? cancel, this.onFinish) {
    // A download may be idle when its deadline expires; retain the failure for
    // its next read without emitting an unhandled asynchronous error.
    failure.future.then<void>((_) {}, onError: (Object e, StackTrace s) {});
    timer = Timer(
      timeout,
      () => stop(TimeoutException('API request deadline exceeded.')),
    );
    cancel?.then(
      (_) => stop(const ApiCancelledException()),
      onError: (Object e, StackTrace s) => stop(const ApiCancelledException()),
    );
  }
  Future<T> guard<T>(Future<T> action) =>
      Future.any<T>([action, failure.future]);
  void stop(Object reason) {
    if (finished) return;
    if (!failure.isCompleted) failure.completeError(reason);
    if (!abort.isCompleted) abort.complete();
    finish();
  }

  void finish() {
    if (finished) return;
    finished = true;
    timer.cancel();
    onFinish();
  }
}

/// Single-use streamed download. Consume chunks or explicitly close it.
class ApiDownload {
  final http.StreamedResponse _response;
  final _Scope _scope;
  bool _used = false, _closed = false;
  int get status => _response.statusCode;
  Map<String, String> get headers => Map.unmodifiable(_response.headers);
  ApiDownload._(this._response, this._scope);
  Stream<List<int>> get chunks async* {
    if (_used || _closed)
      throw const ApiProtocolException(
        'Download is closed or already consumed.',
      );
    _used = true;
    final iterator = StreamIterator(_response.stream);
    try {
      while (await _scope.guard(iterator.moveNext())) {
        yield iterator.current;
      }
    } finally {
      _closed = true;
      _scope.stop(const ApiCancelledException());
      await iterator.cancel();
      _scope.finish();
    }
  }

  Future<void> close() async {
    if (_closed) return;
    _closed = true;
    _scope.stop(const ApiCancelledException());
    try {
      if (!_used) await _response.stream.listen((_) {}).cancel();
    } finally {
      _scope.finish();
    }
  }
}

class ApiClient {
  final Uri baseUri;
  final Map<String, dynamic> contract;
  final String loginOperation;
  final Duration timeout;
  final int maxJsonBytes;
  final http.Client _http;
  final bool _ownsHttp;
  final Set<_Scope> _active = {};
  bool _closed = false;
  String? _token;
  int _epoch = 0;

  ApiClient(
    String baseUrl,
    this.contract,
    this.loginOperation, {
    http.Client? httpClient,
    this.timeout = const Duration(seconds: 30),
    this.maxJsonBytes = 8 * 1024 * 1024,
  }) : baseUri = _base(baseUrl),
       _http = httpClient ?? http.Client(),
       _ownsHttp = httpClient == null {
    if (timeout <= Duration.zero || maxJsonBytes <= 0) {
      if (_ownsHttp) _http.close();
      throw ArgumentError('Invalid client limits.');
    }
  }
  static Uri _base(String url) {
    final uri = Uri.parse(url);
    final loopback =
        uri.host == 'localhost' || uri.host == '127.0.0.1' || uri.host == '::1';
    if ((uri.scheme != 'https' && !(uri.scheme == 'http' && loopback)) ||
        uri.host.isEmpty ||
        uri.userInfo.isNotEmpty ||
        uri.hasQuery ||
        uri.hasFragment ||
        uri.path.contains(RegExp(r'%2[fF]|%5[cC]'))) {
      throw ArgumentError('Use an HTTPS API base URL (HTTP only on loopback).');
    }
    return uri.replace(
      path: uri.path.endsWith('/') ? uri.path : '${uri.path}/',
    );
  }

  String? get accessToken => _token;
  set accessToken(String? token) {
    if (_closed) throw const ApiSessionException('Client is closed.');
    if (token != null &&
        (token.isEmpty ||
            token.length > 32768 ||
            !RegExp(r'^[A-Za-z0-9\-._~+/]+=*$').hasMatch(token))) {
      throw ArgumentError('Invalid bearer token.');
    }
    _epoch++;
    _token = token;
  }

  void clearSession() {
    _epoch++;
    _token = null;
  }

  void close() {
    if (_closed) return;
    _closed = true;
    clearSession();
    for (final scope in _active.toList()) {
      scope.stop(const ApiCancelledException());
      scope.finish();
    }
    if (_ownsHttp) _http.close();
  }

  Future<Map<String, Object?>> login(
    Map<String, Object?> credentials, {
    Future<void>? cancel,
  }) async {
    if (_closed) throw const ApiSessionException('Client is closed.');
    clearSession();
    final epoch = _epoch;
    final result = await call(loginOperation, {}, credentials, cancel: cancel);
    if (_closed || epoch != _epoch)
      throw const ApiSessionException('Login was superseded.');
    if (result is! Map<String, Object?> || result['accessToken'] is! String) {
      throw const ApiProtocolException('Login response has no access token.');
    }
    accessToken = result['accessToken'] as String;
    return result;
  }

  dynamic _schema(dynamic schema) {
    if (schema == null) return <String, dynamic>{};
    if (schema['\$ref'] != null)
      return contract['schemas'][(schema['\$ref'] as String).split('/').last];
    return schema;
  }

  Object? _shape(
    Object? value,
    dynamic original,
    bool incoming, [
    int depth = 0,
  ]) {
    if (depth > 64)
      throw const ApiProtocolException('JSON nesting limit exceeded.');
    final schema = _schema(original);
    if (value == null) {
      if (original?['nullable'] == true ||
          schema['nullable'] == true ||
          schema['type'] == null)
        return null;
      throw const ApiProtocolException('Unexpected null API value.');
    }
    Never fail() => throw const ApiProtocolException(
      'API value has an invalid wire type or range.',
    );
    switch (schema['type']) {
      case 'integer':
        final bits = schema['format'] == 'int64' ? 64 : 32;
        if (value is! int && value is! BigInt) fail();
        if (value is int && value.abs() > 9007199254740991) fail();
        if (!incoming && bits == 64 && value is! BigInt) fail();
        final n = value is BigInt ? value : BigInt.from(value as int);
        if (n < -(BigInt.one << (bits - 1)) || n >= BigInt.one << (bits - 1))
          fail();
        return bits == 64 ? n : n.toInt();
      case 'number':
        final n = value is BigInt ? value.toDouble() : value;
        if (n is! num || !n.isFinite) fail();
        return n;
      case 'string':
        if (value is! String) fail();
        break;
      case 'boolean':
        if (value is! bool) fail();
        break;
      case 'array':
        if (value is! List) fail();
        return value
            .map((v) => _shape(v, schema['items'], incoming, depth + 1))
            .toList();
      case 'object':
        if (value is! Map<String, Object?>) fail();
        if (!incoming) {
          for (final key in schema['required'] ?? []) {
            if (!value.containsKey(key)) fail();
          }
        }
        return value.map((key, v) {
          final field =
              schema['properties']?[key] ?? schema['additionalProperties'];
          return MapEntry(
            key,
            field is Map ? _shape(v, field, incoming, depth + 1) : v,
          );
        });
    }
    return value;
  }

  /// Raw operation access uses the stable OpenAPI operation ID and wire names.
  Future<Object?> call(
    String operation,
    Map<String, Object?> parameters,
    Object? body, {
    Future<void>? cancel,
  }) async {
    if (_closed) throw const ApiSessionException('Client is closed.');
    final dynamic op = contract['operations'][operation];
    if (op == null) throw ArgumentError('Unknown API operation.');
    final epoch = _epoch, token = _token;
    if (op['auth'] == true && token == null)
      throw const ApiSessionException('A bearer session is required.');
    var path = op['path'] as String;
    final query = <String, dynamic>{};
    final headers = <String, String>{
      'accept': op['binary'] == true ? '*/*' : 'application/json',
    };
    final names = <String>{};
    for (final dynamic parameter in op['parameters']) {
      final name = parameter['name'] as String;
      names.add(name);
      final value = parameters[name];
      if (value == null) {
        if (parameter['required'] == true)
          throw ArgumentError('A required API parameter is missing.');
        continue;
      }
      final checked = _shape(value, parameter['schema'], false);
      final text = checked.toString();
      if (parameter['where'] == 'path') {
        if (text.isEmpty || text == '.' || text == '..')
          throw ArgumentError('Invalid path parameter.');
        path = path.replaceAll('{$name}', Uri.encodeComponent(text));
      } else if (parameter['where'] == 'header') {
        if (text.contains(RegExp(r'[\x00-\x1f\x7f]')))
          throw ArgumentError('Invalid API header.');
        headers[name] = text;
      } else {
        query[name] = checked is List
            ? checked.map((v) => v.toString()).toList()
            : text;
      }
    }
    if (parameters.keys.any((p) => !names.contains(p)))
      throw ArgumentError('Unknown API parameter.');
    final uri = baseUri
        .resolve(path)
        .replace(queryParameters: query.isEmpty ? null : query);
    if (uri.origin != baseUri.origin || !uri.path.startsWith(baseUri.path))
      throw ArgumentError('Invalid API path.');
    if (op['auth'] == true) headers['authorization'] = 'Bearer $token';
    late final _Scope scope;
    scope = _Scope(timeout, cancel, () => _active.remove(scope));
    _active.add(scope);
    try {
      final http.BaseRequest request;
      if (op['multipart'] != null) {
        if (body is! Map<String, Object?>)
          throw ArgumentError('A multipart field map is required.');
        final dynamic schema = _schema(op['multipart']);
        final fields = schema['properties'] as Map;
        for (final name in schema['required'] ?? []) {
          if (body[name] == null)
            throw ArgumentError('A multipart field is missing.');
        }
        final multipart = http.AbortableMultipartRequest(
          op['method'],
          uri,
          abortTrigger: scope.abort.future,
        );
        var bytes = 0;
        for (final entry in body.entries) {
          if (!fields.containsKey(entry.key))
            throw ArgumentError('Unknown multipart field.');
          if (entry.value == null) continue;
          if (fields[entry.key]['format'] == 'binary') {
            final file = entry.value;
            if (file is! ApiUploadFile)
              throw ArgumentError('A streamed upload file is required.');
            bytes += file.length;
            if (bytes > 139 * 1024 * 1024)
              throw ArgumentError('Upload exceeds the API limit.');
            multipart.files.add(
              http.MultipartFile(
                entry.key,
                _uploadBytes(file),
                file.length,
                filename: file.filename,
                contentType: MediaType.parse(file.contentType),
              ),
            );
          } else {
            final value = _shape(
              entry.value,
              fields[entry.key],
              false,
            ).toString();
            if (utf8.encode(value).length > 512 * 1024)
              throw ArgumentError('Multipart field is too large.');
            multipart.fields[entry.key] = value;
          }
        }
        request = multipart;
      } else {
        final jsonRequest = http.AbortableRequest(
          op['method'],
          uri,
          abortTrigger: scope.abort.future,
        );
        if (op['body'] != null) {
          if (body == null && op['bodyRequired'] == true)
            throw ArgumentError('A request body is required.');
          if (body != null) {
            final bytes = utf8.encode(
              encodeApiJson(_shape(body, op['body'], false)),
            );
            if (bytes.length > maxJsonBytes)
              throw ArgumentError('JSON request is too large.');
            jsonRequest.bodyBytes = bytes;
            headers['content-type'] = 'application/json; charset=utf-8';
          }
        } else if (body != null) {
          throw ArgumentError('This operation has no request body.');
        }
        request = jsonRequest;
      }
      request.followRedirects = false;
      request.headers.addAll(headers);
      final response = await scope.guard(
        _http.send(request).then((response) {
          if (scope.failure.isCompleted) {
            response.stream.listen((_) {}).cancel().catchError((Object _) {});
          }
          return response;
        }),
      );
      if (response.statusCode == 401 &&
          op['auth'] == true &&
          token != null &&
          token == _token &&
          epoch == _epoch)
        clearSession();
      final success = (op['statuses'] as List).contains(response.statusCode);
      if (success && op['binary'] == true)
        return ApiDownload._(response, scope);
      final chunks = <int>[];
      final iterator = StreamIterator(response.stream);
      try {
        while (await scope.guard(iterator.moveNext())) {
          if (chunks.length + iterator.current.length > maxJsonBytes) {
            throw const ApiProtocolException(
              'JSON response exceeds the size limit.',
            );
          }
          chunks.addAll(iterator.current);
        }
      } finally {
        await iterator.cancel();
      }
      final String text;
      try {
        text = utf8.decode(chunks);
      } on FormatException {
        throw const ApiProtocolException('Response is not UTF-8.');
      }
      if (!success)
        throw ApiException(response.statusCode, text, response.headers);
      if (op['response'] == null) return null;
      return _shape(decodeApiJson(text), op['response'], true);
    } catch (_) {
      scope.stop(const ApiCancelledException());
      scope.finish();
      rethrow;
    } finally {
      // Streaming responses own the scope until EOF, cancellation or close.
      if (op['binary'] != true || scope.failure.isCompleted) scope.finish();
    }
  }
}
