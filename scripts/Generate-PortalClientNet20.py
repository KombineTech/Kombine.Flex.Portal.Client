"""Developer-only generator. Consumer builds use checked-in C# 2.0; no Python/NuGet required."""
from pathlib import Path
import json
import re
import html
import argparse

parser = argparse.ArgumentParser(description=__doc__)
variant = parser.add_mutually_exclusive_group()
variant.add_argument('--compact', action='store_true', help='Generate the Compact Framework 2.0 contract instead of the desktop contract.')
variant.add_argument('--net45', action='store_true', help='Generate the .NET Framework 4.5 contract instead of the 2.0 contract.')
cli = parser.parse_args()
project_name = 'Kombine.Flex.Portal.Client.' + ('Compact20' if cli.compact else 'Net45' if cli.net45 else 'Net20')

ROOT = Path(__file__).resolve().parent.parent
PROJECT = ROOT / project_name
CONTRACT = ROOT / 'Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json'
contract = json.loads(CONTRACT.read_text(encoding='utf-8-sig'))
schemas = contract['components']['schemas']


def name(value):
    return ''.join(part[0].upper() + part[1:] for part in re.split('[^A-Za-z0-9_]', value) if part)


def cs(value):
    return json.dumps(value, ensure_ascii=True)


def kind(schema, nullable=True):
    if '$ref' in schema:
        key = schema['$ref'].split('/')[-1]
        if 'enum' in schemas[key]:
            return 'int?' if nullable else 'int'
        return name(key)
    t = schema.get('type', 'object')
    if t == 'string': return 'string'  # Preserve date/time offsets exactly; .NET 2 has no DateTimeOffset.
    if t == 'integer': return ('long' if schema.get('format') == 'int64' else 'int') + ('?' if nullable else '')
    if t == 'number': return 'double' + ('?' if nullable else '')
    if t == 'boolean': return 'bool' + ('?' if nullable else '')
    if t == 'array': return kind(schema['items'], False) + '[]'
    if isinstance(schema.get('additionalProperties'), dict): return 'Dictionary<string, ' + kind(schema['additionalProperties'], False) + '>'
    return 'object'


def doc(text, indent='    '):
    return indent + '/// <summary>' + html.escape(' '.join(text.split()), quote=False) + '</summary>\n'


def prop(key, schema, indent='        ', attribute=True):
    member = name(key)
    result = doc(schema.get('description', key) + (' ISO 8601 text, sent unchanged.' if schema.get('format') in ('date', 'date-time') else ''), indent)
    if 'enum' in schema: result += doc('Wire values: ' + ', '.join(map(str, schema['enum'])), indent)
    if attribute: result += indent + '[JsonField(' + cs(key) + ')]\n'
    result += indent + 'public ' + kind(schema) + ' ' + member + ' { get { return _' + member + '; } set { _' + member + ' = value; } }\n'
    result += indent + 'private ' + kind(schema) + ' _' + member + ';\n\n'
    return result


header = '// Generated from the public OpenAPI snapshot. Regenerate with scripts/Generate-PortalClientNet20.py' + (' --compact' if cli.compact else ' --net45' if cli.net45 else '') + '.\n'
header += 'using System;\nusing System.Collections.Generic;\n\nnamespace ' + project_name + '\n{\n'
models = header
for key, schema in schemas.items():
    if 'enum' in schema: continue  # Numeric identities remain ints; no external enum assembly.
    models += doc(schema.get('description', key)) + '    public sealed class ' + name(key) + '\n    {\n'
    for p, spec in schema.get('properties', {}).items(): models += prop(p, spec)
    models += '    }\n\n'

client = header + '    /// <summary>Synchronous public integration operations. Authorization and business rules remain in the API.</summary>\n    public sealed partial class PortalApiClient\n    {\n'
operations = []
cases = []
for path, methods in contract['paths'].items():
    for verb, op in methods.items():
        if 'operationId' not in op: continue
        method = op['operationId']
        path_params = [p for p in op.get('parameters', []) if p['in'] == 'path']
        options = [p for p in op.get('parameters', []) if p['in'] != 'path']
        for p in options:
            if p['in'] not in ('query', 'header'): raise ValueError('Unsupported parameter: ' + p['in'])
        body = op.get('requestBody', {}).get('content', {}).get('application/json', {}).get('schema')
        successes = [(int(k), v) for k, v in op['responses'].items() if k.startswith('2')]
        # These clients request complete downloads; 206 is only used when a caller sends Range.
        assert len(successes) == 1 or {s for s, _ in successes} == {200, 206}, (method, successes)
        successes.sort(key=lambda item: item[0])
        status, response = successes[0]
        content = response.get('content', {})
        response_schema = next(iter(content.values()))['schema'] if content else None
        binary = response_schema is not None and response_schema.get('format') == 'binary'
        result = 'PortalDownload' if binary else kind(response_schema, False) if response_schema else 'void'
        parameters = [kind(p['schema'], False) + ' @' + p['name'] for p in path_params]
        args = ['@' + p['name'] for p in path_params]
        if body:
            parameters.append(kind(body, False) + ' body')
            args.append('body')
        if options:
            models += doc('Optional query/header parameters for ' + method + '. Null values use API defaults.')
            models += '    public sealed class ' + method + 'Options\n    {\n'
            for p in options: models += prop(p['name'], dict(p['schema'], description=p.get('description', p['name'])), attribute=False)
            models += '    }\n\n'
            client += doc(op.get('summary', method), '        ')
            client += '        public ' + result + ' ' + method + '(' + ', '.join(parameters) + ')\n        {\n            '
            client += ('' if result == 'void' else 'return ') + method + '(' + ', '.join(args + ['null']) + ');\n        }\n\n'
            parameters.append(method + 'Options options')
        client += doc(op.get('summary', method), '        ')
        client += '        public ' + result + ' ' + method + '(' + ', '.join(parameters) + ')\n        {\n'
        client += '            string path = ' + cs(path.lstrip('/')) + ';\n'
        for p in path_params:
            client += '            path = path.Replace(' + cs('{' + p['name'] + '}') + ', PathValue(@' + p['name'] + '));\n'
        client += '            Dictionary<string, string> headers = new Dictionary<string, string>();\n'
        if options:
            client += '            if (options != null)\n            {\n'
            for p in options:
                v = 'options.' + name(p['name'])
                if p['in'] == 'query': client += '                path = AddQuery(path, ' + cs(p['name']) + ', ' + v + ');\n'
                else: client += '                if (' + v + ' != null) headers.Add(' + cs(p['name']) + ', ' + v + ');\n'
            client += '            }\n'
        invocation = 'SendDownload' if binary else 'SendJson'
        call_args = [cs(verb.upper()), 'path', 'body' if body else 'null', 'headers', str(status)]
        if not binary: call_args.append('typeof(' + ('object' if result == 'void' else result) + ')')
        client += '            ' + ('' if result == 'void' else 'return ' + ('' if binary else '(' + result + ')')) + invocation + '(' + ', '.join(call_args) + ');\n        }\n\n'
        operations.append('| `' + method + '` | ' + verb.upper() + ' | `' + path + '` |')
        sample = next((c['example'] for c in content.values() if 'example' in c), [] if response_schema and response_schema.get('type') == 'array' else {})
        cases.append('\t'.join([method, verb.upper(), path, str(status), json.dumps(sample, ensure_ascii=True, separators=(',', ':'))]))
models += '}\n'
client += '    }\n}\n'
(PROJECT / 'Generated').mkdir(parents=True, exist_ok=True)
(PROJECT / 'Generated/Models.cs').write_text(models, encoding='utf-8-sig', newline='\r\n')
(PROJECT / 'Generated/Operations.cs').write_text(client, encoding='utf-8-sig', newline='\r\n')
(PROJECT / 'OPERATIONS.md').write_text('# .NET ' + ('Compact Framework ' if cli.compact else '') + ('4.5' if cli.net45 else '2.0') + ' operations\n\n| Method | HTTP | Path |\n| --- | --- | --- |\n' + '\n'.join(sorted(operations)) + '\n', encoding='utf-8')
tests = ROOT / ('tests/' + project_name + '.Tests')
tests.mkdir(parents=True, exist_ok=True)
(tests / 'ContractCases.tsv').write_text('\n'.join(cases) + '\n', encoding='utf-8')
print('Generated', len(operations), 'operations and', len(schemas), 'schema mappings for C# 2.0.')
