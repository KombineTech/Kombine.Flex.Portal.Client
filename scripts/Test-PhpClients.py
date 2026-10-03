"""Test PHP clients over real loopback HTTP against independently read OpenAPI snapshots.

No third-party Python/PHP packages, credentials, real services or databases are used.
"""
import argparse
from collections import Counter
from http.server import BaseHTTPRequestHandler, ThreadingHTTPServer
import json
import os
from pathlib import Path
import subprocess
import tempfile
import threading
import time
from urllib.parse import parse_qs, quote, urlsplit

ROOT = Path(__file__).resolve().parent.parent
parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument('--php', default='php')
parser.add_argument('--extension-dir')
parser.add_argument('--packages-root', type=Path, default=ROOT)
args = parser.parse_args()
php = [args.php]
if args.extension_dir:
    php += ['-n', '-d', 'extension_dir=' + str(Path(args.extension_dir).resolve()), '-d', 'extension=curl']
php += ['-d', 'error_reporting=-1', '-d', 'display_errors=1']


def sample(schema, schemas, depth=0):
    if '$ref' in schema: schema = schemas[schema['$ref'].split('/')[-1]]
    if depth > 12: return None
    kind = schema.get('type')
    if kind == 'object': return {k: sample(s, schemas, depth + 1) for k, s in schema.get('properties', {}).items()}
    if kind == 'array': return [sample(schema['items'], schemas, depth + 1)]
    if kind == 'integer': return 9223372036854775807 if schema.get('format') == 'int64' else 17
    if kind == 'number': return 1.25
    if kind == 'boolean': return True
    return 'test /?&+ æ'


def string(value):
    return ('true' if value else 'false') if isinstance(value, bool) else str(value)


def cases(api):
    doc = json.loads((args.packages_root / f'Kombine.Flex.{api}.Client.Php/OpenApi/{api.lower()}.openapi.json').read_text(encoding='utf-8-sig'))
    result = []
    for path, verbs in doc['paths'].items():
        for verb, op in verbs.items():
            if 'operationId' not in op: continue
            path_values, options, query, headers = {}, {}, {}, {}
            parameters = op.get('parameters', [])
            for param in parameters:
                value = sample(param['schema'], doc['components']['schemas'])
                if param['in'] == 'path': path_values[param['name']] = value
                else:
                    if param['in'] == 'header': value = 'en-GB'
                    options[param['name']] = value
                    if param['in'] == 'query': query[param['name']] = [string(v) for v in value] if isinstance(value, list) else [string(value)]
                    else: headers[param['name'].lower()] = value
            wire_path = path
            for key, value in path_values.items(): wire_path = wire_path.replace('{' + key + '}', quote(string(value), safe=''))
            body_schema = op.get('requestBody', {}).get('content', {}).get('application/json', {}).get('schema')
            body = sample(body_schema, doc['components']['schemas']) if body_schema is not None else None
            status, success = next((int(k), v) for k, v in op['responses'].items() if k.isdigit() and k.startswith('2'))
            response_schema = (success.get('content', {}).get('application/json') or next(iter(success.get('content', {}).values()), {})).get('schema')
            binary = response_schema is not None and response_schema.get('format') == 'binary'
            response = 'binary\0data\n' if binary else sample(response_schema, doc['components']['schemas']) if response_schema else None
            call_args = list(path_values.values())
            if body is not None: call_args.append(body)
            sink_index = len(call_args)
            if options: call_args.append(options)
            result.append(dict(method=op['operationId'][0].lower() + op['operationId'][1:], args=call_args,
                               sinkIndex=sink_index, verb=verb.upper(), path=wire_path, query=query, headers=headers, body=body,
                               auth=bool(op.get('security', doc.get('security'))), binary=binary, response=response, status=status))
    return result


matrices = {api: cases(api) for api in ('Portal',)}
hits = Counter()
failures = []


class Handler(BaseHTTPRequestHandler):
    def log_message(self, *unused): pass

    def respond(self, status, payload, headers=None, slow=False):
        payload = payload.encode('utf-8') if isinstance(payload, str) else payload
        self.send_response(status)
        self.send_header('Content-Length', str(len(payload)))
        self.send_header('Content-Type', 'application/json')
        for key, value in (headers or {}).items(): self.send_header(key, value)
        self.end_headers()
        if slow: time.sleep(0.4)
        try: self.wfile.write(payload)
        except (ConnectionError, OSError): pass

    def handle_request(self):
        parts = self.path.split('/', 4)
        api, mode = parts[1:3]
        hits[(api, mode)] += 1
        raw = self.rfile.read(int(self.headers.get('Content-Length', '0')))
        if mode == 'matrix':
            index = int(parts[3])
            case = matrices[api][index]
            try:
                actual = urlsplit('/' + parts[4])
                assert self.command == case['verb'], 'verb'
                assert actual.path == case['path'], 'path'
                assert parse_qs(actual.query, keep_blank_values=True) == case['query'], 'query'
                assert self.headers.get('Authorization') == ('Bearer synthetic-token' if case['auth'] else None), 'auth'
                for name, value in case['headers'].items(): assert self.headers.get(name) == value, 'header'
                assert (json.loads(raw) if raw else None) == case['body'], 'body'
                if raw: assert self.headers.get('Content-Type') == 'application/json', 'content type'
            except (AssertionError, ValueError) as error:
                failures.append(f'{api}/{case["method"]}: {error}')
                self.respond(500, '{"code":"fixture-mismatch"}')
                return
            response = case['response'] if case['binary'] else json.dumps(case['response'], ensure_ascii=False)
            self.respond(case['status'], response)
        elif mode == 'login':
            renew = self.path.endswith('/renew')
            expected_auth = 'Bearer retained-token' if renew else None
            if self.headers.get('Authorization') != expected_auth:
                failures.append('login/renew bearer mismatch')
                self.respond(500, '{}'); return
            if not renew:
                expected = {'email': 'test@example.invalid', 'password': 'synthetic-password'} if api == 'Portal' else {'kid': 'synthetic-kid', 'apiKey': 'synthetic-key'}
                if json.loads(raw) != expected: failures.append('login body mismatch')
            self.respond(200, json.dumps(dict(accessToken='renewed-token' if renew else 'retained-token', expiresIn=259200 if api == 'Portal' else 3600, tokenType='Bearer')))
        elif mode == 'anonymous':
            if self.headers.get('Authorization') is not None: failures.append('anonymous bearer leaked')
            self.respond(200, '{}')
        elif mode in ('fractional', 'overflow'):
            value = '1.5' if mode == 'fractional' else '9223372036854775808'
            self.respond(200, '{"accessToken":"token","tokenType":"Bearer","expiresIn":' + value + '}')
        elif mode == 'bad-login': self.respond(200, '{"accessToken":"token"}')
        elif mode == 'malformed': self.respond(200, '{')
        elif mode == 'wrong-shape': self.respond(200, '{"accessToken":17}')
        elif mode in ('oversized', 'unauthorized-oversized'): self.respond(401 if mode.startswith('unauthorized') else 200, 'x' * 4096)
        elif mode.startswith('error-'):
            self.respond(int(mode.split('-')[1]), '{"code":"synthetic-error","detail":"secret-body"}', {'Retry-After': '60', 'Location': self.server.base + api + '/redirect-target/'})
        elif mode == 'redirect-target':
            failures.append('Redirect followed!'); self.respond(200, '{}')
        elif mode.startswith('slow-'):
            if mode == 'slow-headers': time.sleep(0.4)
            self.respond(200, '{}', slow=mode == 'slow-body')
        elif mode == 'balances':
            self.respond(200, '{"items":[{"currentBalanceMinor":9223372036854775807},{"currentBalanceMinor":-9223372036854775808},{"currentBalanceMinor":null},{}]}')
        elif mode == 'large-download': self.respond(200, b'z' * 2097152)
        else:
            failures.append('Unexpected request: ' + mode); self.respond(500, '{}')

    do_GET = do_POST = do_PUT = do_PATCH = do_DELETE = handle_request


server = ThreadingHTTPServer(('127.0.0.1', 0), Handler)
server.base = f'http://127.0.0.1:{server.server_port}/'
thread = threading.Thread(target=server.serve_forever, daemon=True)
thread.start()
try:
    for api, fixtures in matrices.items():
        project = args.packages_root / f'Kombine.Flex.{api}.Client.Php'
        for path in project.rglob('*.php'):
            subprocess.run(php + ['-l', str(path)], check=True, capture_output=True)
        with tempfile.TemporaryDirectory(prefix='kombine-php-') as temp:
            fixture_path = Path(temp) / 'cases.json'
            fixture_path.write_text(json.dumps(fixtures, ensure_ascii=False), encoding='utf-8')
            subprocess.run(php + [str(ROOT / 'scripts/php-client/client-tests.php'), str(project.resolve()), api, server.base + api + '/', str(fixture_path)], check=True)
        assert hits[(api, 'matrix')] == len(fixtures), 'Every public operation must be called exactly once'
        for status in (401, 403, 429, 503, 302):
            assert hits[(api, f'error-{status}')] == (2 if api == 'Portal' and status == 403 else 1), 'No automatic retries'
    assert not failures, failures
    print(f'All {sum(len(values) for values in matrices.values())} operations verified over loopback HTTP; no redirects or automatic retries.')
finally:
    server.shutdown()
    server.server_close()
