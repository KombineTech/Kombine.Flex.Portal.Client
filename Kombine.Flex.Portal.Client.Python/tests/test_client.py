import io
import json
from pathlib import Path
import threading
import time
import unittest
from http.server import BaseHTTPRequestHandler, ThreadingHTTPServer
from urllib.parse import parse_qs, urlsplit, quote
from urllib.error import HTTPError

from kombine_flex_portal import PortalClient, PortalApiError, PortalProtocolError, PortalSessionError, PortalDownload
from kombine_flex_portal import models
from kombine_flex_portal._runtime import _CONTRACT

CASES = json.loads(Path(__file__).with_name('contract-cases.json').read_text())


class Response(io.BytesIO):
    def __init__(self, data=b'{}', status=200, headers=None):
        super().__init__(data)
        self.code = status
        self.headers = headers or {'Content-Type': 'application/json'}


class Opener:
    def __init__(self, handler):
        self.handler = handler

    def open(self, request, timeout):
        return self.handler(request)


def client(handler):
    value = PortalClient('https://api.example.test/sub/')
    value._opener = Opener(handler)
    return value


def sample(spec):
    if '$ref' in spec:
        return sample(_CONTRACT['schemas'][spec['$ref'].split('/')[-1]])
    kind = spec.get('type')
    if kind == 'integer':
        return 9223372036854775807 if spec.get('format') == 'int64' else 17
    if kind == 'number':
        return 12.5
    if kind == 'string':
        return 'tekst æ 😀'
    if kind == 'boolean':
        return False
    if kind == 'array':
        return [sample(spec['items'])]
    if kind == 'object':
        return {k: sample(v) for k, v in spec.get('properties', {}).items()}
    return None


class ContractTests(unittest.TestCase):
    def test_every_public_operation(self):
        self.assertEqual(len(CASES), 131)
        for case in CASES:
            with self.subTest(operation=case['operation']):
                response_data = b'PK\x00\xff' if case['binary'] else json.dumps(sample(case['response']), ensure_ascii=False).encode()
                response = Response(response_data, case['status'])
                observed = []
                api = client(lambda req: (observed.append(req), response)[1])
                api.access_token = 'test-token'
                args, kwargs = [], {}
                expected_path = '/sub/' + case['path']
                expected_query = {}
                expected_headers = {}
                for param in case['parameters']:
                    value = sample(param['schema'])
                    if param['schema'].get('type') == 'string':
                        value = 'Kid /?&+#æ' if param['where'] == 'path' else 'da-DK' if param['where'] == 'header' else 'a b/&?+æ'
                    text = str(value).lower() if isinstance(value, bool) else str(value)
                    if param['where'] == 'path':
                        args.append(value)
                        expected_path = expected_path.replace('{' + param['name'] + '}', quote(text, safe=''))
                    else:
                        kwargs[param['py']] = value
                        if param['where'] == 'query':
                            expected_query[param['name']] = [text]
                        else:
                            expected_headers[param['name'].lower()] = text
                body = sample(case['body']) if case['body'] else None
                if case['body']:
                    args.append(body)
                result = getattr(api, case['python'])(*args, **kwargs)
                self.assertEqual(len(observed), 1)
                request = observed[0]
                url = urlsplit(request.full_url)
                self.assertEqual(url.path, expected_path)
                self.assertEqual(parse_qs(url.query), expected_query)
                self.assertEqual(request.method, case['method'])
                headers = {k.lower(): v for k, v in request.header_items()}
                self.assertEqual(headers.get('authorization'), 'Bearer test-token' if case['auth'] else None)
                for name, value in expected_headers.items():
                    self.assertEqual(headers[name], value)
                if body is not None:
                    self.assertEqual(json.loads(request.data), body)
                if case['binary']:
                    self.assertIsInstance(result, PortalDownload)
                    self.assertFalse(response.closed)
                    with result:
                        self.assertEqual(b''.join(result.iter_bytes(2)), response_data)
                else:
                    self.assertEqual(result, sample(case['response']))
                self.assertTrue(response.closed)

    def test_model_hints_resolve(self):
        from typing import get_type_hints, is_typeddict
        for value in vars(models).values():
            if is_typeddict(value):
                get_type_hints(value)
        self.assertEqual(models.ManagerLoginRequest.__required_keys__, frozenset({'email', 'password'}))

    def test_empty_query_and_false_are_not_omitted(self):
        observed = []
        api = client(lambda req: (observed.append(req), Response())[1])
        api.search_users(q='', kid_only=False)
        self.assertEqual(parse_qs(urlsplit(observed[0].full_url).query, keep_blank_values=True), {'q': [''], 'kidOnly': ['false']})


class RuntimeTests(unittest.TestCase):
    def test_url_and_token_validation(self):
        for url in ['http://example.test/', 'https://user:pass@example.test/', 'https://x/?', 'https://x/#', 'https://x', '//x/', 'https://x:wrong/', 'https://x/\r\n', 'https://x\\evil/']:
            with self.subTest(url=url), self.assertRaises(ValueError):
                PortalClient(url)
        for url in ['https://api.example.test/', 'http://localhost:123/', 'http://127.0.0.1:123/', 'http://[::1]:123/']:
            self.assertEqual(PortalClient(url).base_url, url)
        api = PortalClient('https://api.example.test/')
        for token in ['', 'a b', 'a\r\nb', 'æ']:
            with self.assertRaises(ValueError):
                api.access_token = token
        with self.assertRaises(AttributeError):
            api.base_url = 'https://another.test/'

    def test_login_session_and_401(self):
        calls = []
        def handle(req):
            calls.append(req)
            if req.full_url.endswith('/session/login'):
                return Response(b'{"accessToken":"new-token","expiresIn":3600,"tokenType":"Bearer"}')
            return Response(b'{"code":"unauthorized"}', 401)
        api = client(handle)
        api.access_token = 'old-token'
        result = api.login('jens@example.test', 'secret')
        self.assertEqual(api.access_token, 'new-token')
        self.assertEqual(result['expiresIn'], 3600)
        self.assertNotIn('Authorization', dict(calls[0].header_items()))
        with self.assertRaises(PortalApiError) as error:
            api.get_current_manager()
        self.assertEqual(error.exception.code, 'unauthorized')
        self.assertIsNone(api.access_token)
        self.assertNotIn('secret', str(error.exception))

    def test_login_failure_clears_old_session(self):
        api = client(lambda _: Response(b'{"code":"invalid"}', 401))
        api.access_token = 'old-token'
        with self.assertRaises(PortalApiError):
            api.login('x@example.test', 'password')
        self.assertIsNone(api.access_token)

    def test_late_login_cannot_restore_logout_or_closed_session(self):
        for action in ['clear_session', 'close']:
            api = None
            def handle(_):
                getattr(api, action)()
                return Response(b'{"accessToken":"late-token","expiresIn":3600,"tokenType":"Bearer"}')
            api = client(handle)
            with self.assertRaises(PortalSessionError):
                api.login('x@example.test', 'password')
            self.assertIsNone(api.access_token)

    def test_stale_401_preserves_new_session(self):
        api = None
        def handle(_):
            api.access_token = 'new-token'
            return Response(b'{}', 401)
        api = client(handle)
        api.access_token = 'old-token'
        with self.assertRaises(PortalApiError):
            api.get_current_manager()
        self.assertEqual(api.access_token, 'new-token')

    def test_precision_null_and_failures(self):
        api = client(lambda _: Response(b'{"accessToken":null,"expiresIn":9223372036854775807,"tokenType":null}'))
        self.assertEqual(api.login_manager({'email': 'x', 'password': 'x'})['expiresIn'], 9223372036854775807)
        self.assertIsNone(api.access_token)  # Raw LoginManager does not retain a session.
        for payload in [b'null', b'[]', b'{"expiresIn":9223372036854775808}', b'{"expiresIn":true}', b'{"a":1,"a":2}', b'{"x":NaN}', b'{"x":"\xff"}', b'{"x":"\\ud800"}', b'{} trailing', b'[' * 70 + b']' * 70]:
            with self.subTest(payload=payload):
                response = Response(payload)
                api = client(lambda _: response)
                with self.assertRaises(PortalProtocolError):
                    api.login_manager({'email': 'x', 'password': 'x'})
                self.assertTrue(response.closed)

    def test_size_limits_no_retry_and_error_details(self):
        calls = []
        response = Response(b'{"code":"busy","detail":"private"}', 503, {'Retry-After': '60'})
        api = client(lambda req: (calls.append(req), response)[1])
        with self.assertRaises(PortalApiError) as error:
            api.get_portal_status()
        self.assertEqual(error.exception.status, 503)
        self.assertEqual(error.exception.headers['retry-after'], '60')
        self.assertEqual(error.exception.code, 'busy')
        self.assertNotIn('private', str(error.exception))
        self.assertEqual(len(calls), 1)
        api = client(lambda _: Response(b'{"data":"too large"}'))
        api._max_json_bytes = 5
        with self.assertRaises(PortalProtocolError):
            api.get_portal_status()
        with self.assertRaises(PortalProtocolError):
            api.login_manager({'email': 'x', 'password': 'x'})

    def test_invalid_route_header_body_and_closed_client(self):
        def no_network(_):
            self.fail('Invalid input must not send an HTTP request.')
        api = client(no_network)
        for kid in ['', '.', '..']:
            with self.assertRaises(ValueError):
                api.get_manager(kid)
        with self.assertRaises(ValueError):
            api.get_location_units('kid', accept_language='da\r\nX: bad')
        with self.assertRaises(PortalProtocolError):
            api.login_manager({'email': 'x', 'password': object()})
        api.close()
        with self.assertRaises(PortalSessionError):
            api.get_portal_status()


class HttpTests(unittest.TestCase):
    @classmethod
    def setUpClass(cls):
        cls.paths = []
        class Handler(BaseHTTPRequestHandler):
            def log_message(self, *args):
                pass

            def do_GET(self):
                cls.paths.append(self.path)
                if self.path.startswith('/redirect/'):
                    self.send_response(302)
                    self.send_header('Location', '/should-never-be-called')
                    self.end_headers()
                elif self.path.startswith('/slow/'):
                    time.sleep(.12)
                    self.send_response(200)
                    self.end_headers()
                else:
                    payload = b'{"status":"ok"}'
                    self.send_response(200)
                    self.send_header('Content-Type', 'application/json')
                    self.send_header('Content-Length', str(len(payload)))
                    self.end_headers()
                    self.wfile.write(payload)
        cls.server = ThreadingHTTPServer(('127.0.0.1', 0), Handler)
        cls.worker = threading.Thread(target=cls.server.serve_forever, daemon=True)
        cls.worker.start()
        cls.base = f'http://127.0.0.1:{cls.server.server_port}/'

    @classmethod
    def tearDownClass(cls):
        cls.server.shutdown()
        cls.server.server_close()
        cls.worker.join()

    def test_real_http_and_redirect_block(self):
        with PortalClient(self.base) as api:
            self.assertEqual(api.get_portal_status()['status'], 'ok')
        with PortalClient(self.base + 'redirect/') as api:
            with self.assertRaises(PortalApiError) as error:
                api.get_portal_status()
            self.assertEqual(error.exception.status, 302)
        self.assertNotIn('/should-never-be-called', self.paths)

    def test_socket_timeout(self):
        with PortalClient(self.base + 'slow/', timeout=.025) as api:
            with self.assertRaises(TimeoutError):
                api.get_portal_status()


if __name__ == '__main__':
    unittest.main()
