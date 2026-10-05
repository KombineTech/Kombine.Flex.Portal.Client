"""Generate the standalone Portal PHP client from their exported public API snapshots."""
import argparse
import hashlib
import json
import re
import sys
from pathlib import Path

ROOT = Path(__file__).resolve().parent.parent
sys.path.insert(0, str(ROOT / 'scripts/php-client'))
from documentation import generate as generate_docs
parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument('--check', action='store_true')
args = parser.parse_args()


def write(path, text):
    text = text.replace('\r\n', '\n')
    if args.check:
        if not path.exists() or path.read_text(encoding='utf-8') != text:
            raise SystemExit(f'Out of date: {path.relative_to(ROOT)}')
    else:
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(text, encoding='utf-8', newline='\n')


def php(value):
    return "'" + value.replace('\\', '\\\\').replace("'", "\\'") + "'"


def shape(schema):
    return {key: ({k: shape(v) for k, v in value.items()} if key == 'properties'
                  else shape(value) if isinstance(value, dict) else value)
            for key, value in schema.items() if key in
            ('$ref', 'type', 'format', 'nullable', 'required', 'properties', 'items', 'additionalProperties')}


def doc_type(schema):
    if '$ref' in schema:
        result = schema['$ref'].split('/')[-1]
    else:
        kind = schema.get('type')
        result = {'integer': 'int', 'number': 'int|float', 'string': 'string', 'boolean': 'bool',
                  'object': 'array<string,mixed>'}.get(kind, 'mixed')
        if kind == 'array': result = 'list<' + doc_type(schema['items']) + '>'
    return result + '|null' if schema.get('nullable') else result


for api in ('Portal',):
    project = ROOT / f'Kombine.Flex.{api}.Client.Php'
    snapshot = project / 'OpenApi' / f'{api.lower()}.openapi.json'
    raw = snapshot.read_bytes()
    contract = json.loads(raw.decode('utf-8-sig'))
    namespace = 'Kombine\\Flex\\' + api
    operations = {}
    methods = []
    rows = []
    model_rows = []
    aliases = []
    for name, schema in contract['components']['schemas'].items():
        fields = []
        for field, value in schema.get('properties', {}).items():
            fields.append(php(field) + ('' if field in schema.get('required', []) else '?') + ': ' + doc_type(value))
        alias = 'array{' + ', '.join(fields) + '}' if schema.get('type') == 'object' else doc_type(schema)
        aliases.append(f' * @phpstan-type {name} {alias}')
        model_rows.append(f'### {name}\n\n```php\n{alias}\n```\n')
    for path, verbs in contract['paths'].items():
        for verb, op in verbs.items():
            if 'operationId' not in op: continue
            oid = op['operationId']
            assert oid not in operations, oid
            method = oid[0].lower() + oid[1:]
            parameters = op.get('parameters', [])
            assert all(p['in'] in ('path', 'query', 'header') for p in parameters)
            assert all(p.get('style', 'form' if p['in'] == 'query' else 'simple') in ('form', 'simple') for p in parameters)
            body = op.get('requestBody', {}).get('content', {}).get('application/json', {}).get('schema')
            successes = [(int(k), v) for k, v in op['responses'].items() if k.isdigit() and k.startswith('2')]
            schemas = [(v.get('content', {}).get('application/json') or next(iter(v.get('content', {}).values()), {})).get('schema') for _, v in successes]
            response = next((s for s in schemas if s is not None), None)
            binary = response is not None and response.get('format') == 'binary'
            assert len({json.dumps(s, sort_keys=True) for s in schemas if s is not None}) <= 1, oid
            metadata = dict(method=verb.upper(), path=path.lstrip('/'), statuses=[s for s, _ in successes],
                            auth=bool(op.get('security', contract.get('security'))),
                            parameters=[dict(name=p['name'], where=p['in'], required=p.get('required', False), schema=shape(p['schema'])) for p in parameters],
                            body=shape(body) if body is not None else None,
                            response=shape(response) if response is not None else None, binary=binary)
            operations[oid] = metadata
            path_params = [p for p in parameters if p['in'] == 'path']
            optional = [p for p in parameters if p['in'] != 'path']
            assert all(re.fullmatch(r'[A-Za-z_][A-Za-z0-9_]*', p['name']) for p in path_params)
            params = ['mixed $' + p['name'] for p in path_params]
            docs = ['    /**', '     * ' + ' '.join(op.get('summary', oid).split()).replace('*/', '* /')]
            docs.extend('     * @param ' + doc_type(p['schema']) + ' $' + p['name'] for p in path_params)
            if body is not None:
                params.append('#[\\SensitiveParameter] array $body')
                docs.append('     * @param ' + doc_type(body) + ' $body')
            if binary:
                params.append('mixed $destination')
                docs.append('     * @param resource $destination Writable stream; may contain partial data on failure.')
            if optional:
                params.append('array $options = []')
                docs.append('     * @param array{' + ', '.join(php(p['name']) + ('' if p.get('required') else '?') + ': ' + doc_type(p['schema']) for p in optional) + '} $options')
            docs.append('     * @return ' + ('DownloadResponse' if binary else doc_type(response) if response else 'null'))
            docs.append('     */')
            fields = '[' + ', '.join(php(p['name']) + ' => $' + p['name'] for p in path_params) + ']'
            values = fields + (' + $options' if optional else '')
            methods.append('\n'.join(docs) + f'\n    public function {method}(' + ', '.join(params) + '): mixed\n    {\n'
                           + f'        return $this->request({php(oid)}, {values}, ' + ('$body' if body is not None else 'null') + (', $destination' if binary else '') + ');\n    }\n')
            rows.append(f'| `{method}` | `{oid}` | {verb.upper()} | `{path}` | {"Bearer" if metadata["auth"] else "Anonymous"} |')
    login = "return $this->signIn('LoginManager', ['email' => $email, 'password' => $password]);" if api == 'Portal' else "return $this->signIn('LoginService', ['kid' => $kid, 'apiKey' => $apiKey]);"
    login_args = '#[\\SensitiveParameter] string $email, #[\\SensitiveParameter] string $password' if api == 'Portal' else 'string $kid, #[\\SensitiveParameter] string $apiKey'
    convenience = f'    /** Sign in and retain the bearer in memory. Credentials are not stored. */\n    public function login({login_args}): array\n    {{\n        {login}\n    }}\n'
    if 'RenewManagerSession' in operations:
        convenience += "\n    /** Explicit renewal that replaces the in-memory bearer. */\n    public function renew(): array\n    {\n        return $this->renewSession('RenewManagerSession');\n    }\n"
    source = '<?php\ndeclare(strict_types=1);\n\nnamespace ' + namespace + ';\n\n/**\n * Generated wire models: associative arrays; missing and null values remain distinct.\n' + '\n'.join(aliases) + '\n */\nfinal class ' + api + 'Client extends BaseClient\n{\n' + convenience + '\n' + '\n'.join(methods) + '}\n'
    write(project / 'src' / f'{api}Client.php', source)
    write(project / 'src' / 'Runtime.php', (ROOT / 'scripts/php-client/Runtime.php').read_text(encoding='utf-8').replace('__API__', api))
    write(project / 'src' / 'contract.json', json.dumps(dict(schemas={k: shape(v) for k, v in contract['components']['schemas'].items()}, operations=operations), ensure_ascii=False, indent=2) + '\n')
    write(project / 'autoload.php', f"<?php\ndeclare(strict_types=1);\nrequire_once __DIR__ . '/src/Runtime.php';\nrequire_once __DIR__ . '/src/{api}Client.php';\n")
    write(project / 'composer.json', json.dumps(dict(name=f'kombine/flex-{api.lower()}-client', description=f'Standalone HTTPS/JSON client for Kombine Flex {api}.',
        type='library', version='0.4.1' if api == 'Portal' else '0.1.0', license='proprietary', require={'php': '^8.2', 'php-64bit': '^8.2', 'ext-curl': '*', 'ext-json': '*'},
        autoload={'classmap': ['src/']}), indent=2) + '\n')
    write(project / 'OPERATIONS.md', f'# {api} PHP operations\n\nGenerated from the bundled public OpenAPI snapshot (SHA-256 `{hashlib.sha256(raw).hexdigest()}`).\n{len(operations)} operations. Business permissions are enforced by the API.\n\n| PHP method | Stable operation ID | HTTP | Path | Access |\n| --- | --- | --- | --- | --- |\n' + '\n'.join(sorted(rows)) + '\n')
    write(project / 'MODELS.md', '# PHP wire models\n\nRequests and responses use associative arrays with exact JSON field names. Dates remain strings. All integer fields use 64-bit PHP integers; never convert them to floats. Null and absent values are preserved.\n\n' + '\n'.join(model_rows))
    generate_docs(ROOT, project, api, len(operations), write)
    print(f'{api}: {len(operations)} PHP operations {"verified" if args.check else "generated"}.')
