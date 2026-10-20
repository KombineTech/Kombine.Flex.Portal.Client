import 'dart:async';
import 'dart:convert';
import 'dart:io';

import 'package:http/http.dart' as http;
import 'package:http/testing.dart';
import 'package:test/test.dart';
import 'package:kombine_flex_portal_client/kombine_flex_portal_client.dart';

Map<String, dynamic> operation({
  bool auth = false,
  bool binary = false,
  Object? response = const {'type': 'object'},
  Object? body,
}) => {
  'method': body == null ? 'GET' : 'POST',
  'path': 'resource',
  'auth': auth,
  'statuses': [200, 202],
  'parameters': [],
  'body': body,
  'bodyRequired': body != null,
  'multipart': null,
  'binary': binary,
  'response': response,
};
Map<String, dynamic> contract(Map<String, dynamic> operations) => {
  'schemas': <String, dynamic>{},
  'operations': operations,
};

void main() {
  test('lossless signed integers, Unicode, nulls and JSON rejection', () {
    final value = decodeApiJson(
      r'{"max":9223372036854775807,"min":-9223372036854775808,"s":"æ☀️","a":[null,false,1.25]}',
    ) as Map;
    expect(value['max'], BigInt.parse('9223372036854775807'));
    expect(value['min'], BigInt.parse('-9223372036854775808'));
    expect(
      (decodeApiJson(encodeApiJson(value.cast<String, Object?>()))
          as Map)['max'],
      value['max'],
    );
    for (final malformed in [
      '01',
      '1.',
      '[1,]',
      '{"a":1,"a":2}',
      'true false',
      '1e999',
      '"unterminated',
      '${'[' * 66}0${']' * 66}',
    ]) {
      expect(
        () => decodeApiJson(malformed),
        throwsA(isA<ApiProtocolException>()),
        reason: malformed,
      );
    }
    expect(
      () => encodeApiJson(double.nan),
      throwsA(isA<ApiProtocolException>()),
    );
  });

  test('base URLs and bearer values reject untrusted destinations and control characters', () {
    for (final url in [
      'http://example.org/',
      'https://a:b@example.org/',
      'https://example.org/?secret=x',
      'https://example.org/#fragment',
      'file:///tmp/',
    ]) {
      expect(() => ApiClient(url, contract({}), 'Login'), throwsArgumentError);
    }
    final api = ApiClient('https://example.invalid/', contract({}), 'Login');
    addTearDown(api.close);
    for (final token in ['', 'x\r\ny', 'Bearer token', 'æ']) {
      expect(() => api.accessToken = token, throwsArgumentError);
    }
  });

  test(
    'missing session and invalid outgoing values never reach the transport',
    () async {
      var sends = 0;
      final api = ApiClient(
        'https://example.invalid/',
        contract({
          'Read': operation(auth: true),
          'Write': operation(
            body: {
              'type': 'object',
              'properties': {
                'value': {'type': 'integer', 'format': 'int64'},
              },
              'required': ['value'],
            },
          ),
        }),
        'Login',
        httpClient: MockClient((_) async {
          sends++;
          return http.Response('{}', 200);
        }),
      );
      addTearDown(api.close);
      await expectLater(
        api.call('Read', {}, null),
        throwsA(isA<ApiSessionException>()),
      );
      await expectLater(
        api.call('Write', {}, {'value': 12}),
        throwsA(isA<ApiProtocolException>()),
      );
      await expectLater(
        api.call('Write', {}, {'value': BigInt.one << 63}),
        throwsA(isA<ApiProtocolException>()),
      );
      expect(sends, 0);
    },
  );

  test('session helper clears failures and does not let a late login restore a closed session', () async {
    final response = Completer<http.Response>();
    final api = ApiClient(
      'https://example.invalid/',
      contract({
        'Login': operation(body: {'type': 'object'}),
      }),
      'Login',
      httpClient: MockClient((request) {
        expect(request.headers.containsKey('authorization'), isFalse);
        return response.future;
      }),
    );
    api.accessToken = 'old';
    final pending = api.login({'email': 'fixture@example.invalid'});
    final assertion = expectLater(
      pending,
      throwsA(anyOf(isA<ApiCancelledException>(), isA<ApiSessionException>())),
    );
    api.close();
    response.complete(http.Response('{"accessToken":"late"}', 200));
    await assertion;
    expect(api.accessToken, isNull);
  });

  test('replacement token survives an older 401 and API errors do not expose bodies in toString', () async {
    final response = Completer<http.Response>();
    final api = ApiClient(
      'https://example.invalid/',
      contract({'Read': operation(auth: true)}),
      'Login',
      httpClient: MockClient((request) {
        expect(request.headers['authorization'], 'Bearer first');
        return response.future;
      }),
    );
    addTearDown(api.close);
    api.accessToken = 'first';
    final pending = api.call('Read', {}, null);
    api.accessToken = 'second';
    response.complete(
      http.Response(
        '{"code":"expired","secret":"private"}',
        401,
        headers: {'retry-after': '60'},
      ),
    );
    try {
      await pending;
      fail('Expected API error');
    } on ApiException catch (e) {
      expect(e.status, 401);
      expect(e.code, 'expired');
      expect(e.headers['retry-after'], '60');
      expect(e.toString(), isNot(contains('private')));
    }
    expect(api.accessToken, 'second');
  });

  test('successful login retains the token, failed login clears it and clearSession fences late login', () async {
    var failLogin = false;
    Completer<http.Response>? delayed;
    final api = ApiClient(
      'https://example.invalid/',
      contract({
        'Login': operation(body: {'type': 'object'}),
        'Read': operation(auth: true),
      }),
      'Login',
      httpClient: MockClient((request) async {
        if (request.method == 'POST') {
          expect(request.headers.containsKey('authorization'), isFalse);
          final pendingResponse = delayed;
          if (pendingResponse != null) return pendingResponse.future;
          return http.Response(
            failLogin ? '{}' : '{"accessToken":"new-token","expiresIn":259200}',
            failLogin ? 401 : 200,
          );
        }
        expect(request.headers['authorization'], 'Bearer new-token');
        return http.Response('{}', 200);
      }),
    );
    addTearDown(api.close);
    await api.login({'email': 'fixture@example.invalid'});
    expect(api.accessToken, 'new-token');
    await api.call('Read', {}, null);
    failLogin = true;
    await expectLater(api.login({}), throwsA(isA<ApiException>()));
    expect(api.accessToken, isNull);
    final lateResponse = Completer<http.Response>();
    delayed = lateResponse;
    final pending = api.login({});
    api.clearSession();
    lateResponse.complete(http.Response('{"accessToken":"late"}', 200));
    await expectLater(pending, throwsA(isA<ApiSessionException>()));
    expect(api.accessToken, isNull);
  });

  test(
    'a response arriving after timeout is cancelled without leaking its body',
    () async {
      final response = Completer<http.StreamedResponse>();
      var cancelled = false;
      final stream = StreamController<List<int>>(
        onCancel: () {
          cancelled = true;
        },
      );
      final api = ApiClient(
        'https://example.invalid/',
        contract({'Read': operation()}),
        'Login',
        timeout: const Duration(milliseconds: 20),
        httpClient: _DeferredClient(response.future),
      );
      addTearDown(api.close);
      await expectLater(
        api.call('Read', {}, null),
        throwsA(isA<TimeoutException>()),
      );
      response.complete(http.StreamedResponse(stream.stream, 200));
      await Future<void>.delayed(Duration.zero);
      expect(cancelled, isTrue);
      await stream.close();
    },
  );

  test(
    'current 401 clears session and raw 202 remains a successful response',
    () async {
      var status = 401;
      final api = ApiClient(
        'https://example.invalid/',
        contract({'Read': operation(auth: true)}),
        'Login',
        httpClient: MockClient((_) async => http.Response('{}', status)),
      );
      addTearDown(api.close);
      api.accessToken = 'first';
      await expectLater(
        api.call('Read', {}, null),
        throwsA(isA<ApiException>()),
      );
      expect(api.accessToken, isNull);
      status = 202;
      api.accessToken = 'second';
      expect(await api.call('Read', {}, null), isA<Map>());
    },
  );

  test(
    'JSON response limit and malformed UTF-8 fail without a retry',
    () async {
      var sends = 0;
      var bytes = <int>[0xff];
      final api = ApiClient(
        'https://example.invalid/',
        contract({'Read': operation()}),
        'Login',
        maxJsonBytes: 8,
        httpClient: MockClient((_) async {
          sends++;
          return http.Response.bytes(bytes, 200);
        }),
      );
      addTearDown(api.close);
      await expectLater(
        api.call('Read', {}, null),
        throwsA(isA<ApiProtocolException>()),
      );
      bytes = utf8.encode('{"long":"0123456789"}');
      await expectLater(
        api.call('Read', {}, null),
        throwsA(isA<ApiProtocolException>()),
      );
      expect(sends, 2);
    },
  );

  test('timeout and explicit cancellation abort stalled transport', () async {
    final api = ApiClient(
      'https://example.invalid/',
      contract({'Read': operation()}),
      'Login',
      timeout: const Duration(milliseconds: 20),
      httpClient: _StalledClient(),
    );
    addTearDown(api.close);
    await expectLater(
      api.call('Read', {}, null),
      throwsA(isA<TimeoutException>()),
    );
    final cancel = Completer<void>();
    final pending = api.call('Read', {}, null, cancel: cancel.future);
    final assertion = expectLater(
      pending,
      throwsA(isA<ApiCancelledException>()),
    );
    cancel.complete();
    await assertion;
  });

  test(
    'streamed downloads are single-use and close releases an unread response',
    () async {
      var cancelled = false;
      final controller = StreamController<List<int>>(
        onCancel: () {
          cancelled = true;
        },
      );
      final api = ApiClient(
        'https://example.invalid/',
        contract({'Read': operation(binary: true)}),
        'Login',
        httpClient: _StreamClient(controller.stream),
      );
      addTearDown(api.close);
      final download = await api.call('Read', {}, null) as ApiDownload;
      await download.close();
      expect(cancelled, isTrue);
      await expectLater(
        download.chunks.toList(),
        throwsA(isA<ApiProtocolException>()),
      );
      await controller.close();
    },
  );

  test('deadline covers a stalled download body', () async {
    final controller = StreamController<List<int>>();
    final api = ApiClient(
      'https://example.invalid/',
      contract({'Read': operation(binary: true)}),
      'Login',
      timeout: const Duration(milliseconds: 30),
      httpClient: _StreamClient(controller.stream),
    );
    addTearDown(api.close);
    final download = await api.call('Read', {}, null) as ApiDownload;
    await expectLater(
      download.chunks.toList(),
      throwsA(isA<TimeoutException>()),
    );
    await controller.close();
  });

  test(
    'real loopback HTTP preserves query encoding and refuses redirects',
    () async {
      final server = await HttpServer.bind(InternetAddress.loopbackIPv4, 0);
      var requests = 0;
      server.listen((request) async {
        requests++;
        expect(request.uri.queryParameters['q'], 'æ & /');
        request.response.statusCode = 302;
        request.response.headers.set('location', '/should-not-follow');
        await request.response.close();
      });
      final op = operation();
      op['parameters'] = [
        {
          'name': 'q',
          'where': 'query',
          'required': true,
          'schema': {'type': 'string'},
        },
      ];
      final api = ApiClient(
        'http://127.0.0.1:${server.port}/',
        contract({'Read': op}),
        'Login',
      );
      try {
        await expectLater(
          api.call('Read', {'q': 'æ & /'}, null),
          throwsA(isA<ApiException>().having((e) => e.status, 'status', 302)),
        );
        expect(requests, 1);
      } finally {
        api.close();
        await server.close(force: true);
      }
    },
  );

  test('multipart streams exact file bytes and rejects missing/unknown fields before sending', () async {
    final server = await HttpServer.bind(InternetAddress.loopbackIPv4, 0);
    var requests = 0;
    final observed = Completer<String>();
    server.listen((request) async {
      requests++;
      expect(request.headers.contentType?.mimeType, 'multipart/form-data');
      observed.complete(await utf8.decoder.bind(request).join());
      request.response.headers.contentType = ContentType.json;
      request.response.write('{}');
      await request.response.close();
    });
    final op = operation();
    op['method'] = 'POST';
    op['multipart'] = {
      'type': 'object',
      'required': ['token', 'original'],
      'properties': {
        'token': {'type': 'string'},
        'original': {'type': 'string', 'format': 'binary'},
      },
    };
    final api = ApiClient(
      'http://127.0.0.1:${server.port}/',
      contract({'Upload': op}),
      'Login',
    );
    final file = ApiUploadFile(
      () => Stream.value(utf8.encode('exact original bytes')),
      20,
      'fixture.txt',
      contentType: 'text/plain',
    );
    try {
      await expectLater(
        api.call('Upload', {}, {'token': 'x'}),
        throwsArgumentError,
      );
      await expectLater(
        api.call('Upload', {}, {'token': 'x', 'original': file, 'other': 'no'}),
        throwsArgumentError,
      );
      expect(requests, 0);
      await api.call('Upload', {}, {'token': 'x', 'original': file});
      final body = await observed.future;
      expect(body, contains('exact original bytes'));
      expect(body, contains('filename="fixture.txt"'));
      expect(requests, 1);
    } finally {
      api.close();
      await server.close(force: true);
    }
  });
}

class _StalledClient extends http.BaseClient {
  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) =>
      Completer<http.StreamedResponse>().future;
}

class _DeferredClient extends http.BaseClient {
  final Future<http.StreamedResponse> response;
  _DeferredClient(this.response);
  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) => response;
}

class _StreamClient extends http.BaseClient {
  final Stream<List<int>> stream;
  _StreamClient(this.stream);
  @override
  Future<http.StreamedResponse> send(http.BaseRequest request) async =>
      http.StreamedResponse(stream, 200);
}
