"""Generate Python and TypeScript clients from the shared, checked-in public contract."""
from pathlib import Path
import json
import re
import keyword
import argparse

parser = argparse.ArgumentParser(description=__doc__)
parser.add_argument('--check', action='store_true', help='Verify generated files without modifying them.')
args = parser.parse_args()

ROOT = Path(__file__).resolve().parent.parent
contract = json.loads((ROOT / 'Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json').read_text(encoding='utf-8-sig'))
schemas = contract['components']['schemas']
py = ROOT / 'Kombine.Flex.Portal.Client.Python'
js = ROOT / 'Kombine.Flex.Portal.Client.JavaScript'


def snake(s):
    s = re.sub(r'([a-z0-9])([A-Z])', r'\1_\2', s).replace('-', '_').lower()
    return s + '_' if keyword.iskeyword(s) else s


def type_name(s):
    return s[0].upper() + s[1:]


def kind(s, language):
    if '$ref' in s:
        t = type_name(s['$ref'].split('/')[-1])
    else:
        t = s.get('type')
        if t == 'array':
            t = ('list[' + kind(s['items'], language) + ']') if language == 'py' else '(' + kind(s['items'], language) + ')[]'
        elif t == 'object':
            inner = s.get('additionalProperties')
            t = ('dict[str, ' + kind(inner, language) + ']') if isinstance(inner, dict) and language == 'py' else ('Record<string, ' + kind(inner, language) + '>') if isinstance(inner, dict) else 'Any' if language == 'py' else 'unknown'
        else:
            t = {'string': 'str', 'integer': 'int', 'number': 'float', 'boolean': 'bool'}.get(t, 'Any') if language == 'py' else {'string': 'string', 'integer': 'bigint' if s.get('format') == 'int64' else 'number', 'number': 'number', 'boolean': 'boolean'}.get(t, 'unknown')
    return t + (' | None' if language == 'py' else ' | null') if s.get('nullable') else t


def brief(text):
    return ' '.join(text.split()).replace('*/', '* /')


def shape(s):
    # Preserve wire types and numeric width; authorization/validation rules remain in the API.
    return {k: ({p: shape(v) for p, v in value.items()} if k == 'properties' else shape(value) if isinstance(value, dict) else value)
            for k, value in s.items() if k in ('$ref', 'type', 'format', 'nullable', 'properties', 'items', 'additionalProperties')}


pym = '"""Generated wire models. Dictionary keys match JSON; dates remain ISO 8601 strings."""\nfrom __future__ import annotations\nfrom typing import Any, TypedDict, Required\n\n'
tsm = '// Generated wire models. int64 is bigint; dates remain ISO 8601 strings.\n'
for name, spec in schemas.items():
    name = type_name(name)
    if 'enum' in spec:
        pym += f'{name} = int\n\n'
        tsm += f'/** Wire values: {spec["enum"]}. */\nexport type {name} = number;\n\n'
        continue
    pym += f'{name} = TypedDict({name!r}, {{\n'
    tsm += f'/** {brief(spec.get("description", name))} */\nexport interface {name} {{\n'
    for prop, value in spec.get('properties', {}).items():
        required = prop in spec.get('required', [])
        pt = kind(value, 'py')
        pym += f'    {prop!r}: ' + ('Required[' + repr(pt) + ']' if required else repr(pt)) + ',\n'
        tsm += f'  /** {brief(value.get("description", prop))} */\n  {json.dumps(prop)}' + ('' if required else '?') + ': ' + kind(value, 'ts') + ';\n'
    pym += '}, total=False)\n\n'
    tsm += '}\n\n'

operations = {}
cases = []
pyc = '"""Generated operations; regenerate with scripts/Generate-PortalScriptClients.py."""\nfrom __future__ import annotations\nfrom typing import Any\nfrom .models import *\nfrom ._runtime import BaseClient, PortalDownload\n\n\nclass PortalClient(BaseClient):\n'
tsc = '// Generated operations; regenerate with scripts/Generate-PortalScriptClients.py.\nimport { BaseClient, PortalDownload, type RequestOptions } from "./runtime.js";\nimport type * as Models from "./models.js";\n\nexport class PortalClient extends BaseClient {\n'
rows = []
for path, methods in contract['paths'].items():
    for verb, op in methods.items():
        if 'operationId' not in op:
            continue
        oid = op['operationId']
        pn, jn = snake(oid), oid[0].lower() + oid[1:]
        params = op.get('parameters', [])
        pp = [p for p in params if p['in'] == 'path']
        qp = [p for p in params if p['in'] != 'path']
        body = op.get('requestBody', {}).get('content', {}).get('application/json', {}).get('schema')
        successes = [(int(k), v) for k, v in op['responses'].items() if k.startswith('2')]
        # Generated methods do not send Range, so full downloads expect HTTP 200.
        assert len(successes) == 1 or {s for s, _ in successes} == {200, 206}
        successes.sort(key=lambda item: item[0])
        status, success = successes[0]
        content = success.get('content', {})
        response = next(iter(content.values()))['schema'] if content else None
        binary = bool(response and response.get('format') == 'binary')
        assert response is not None
        operations[oid] = dict(method=verb.upper(), path=path.lstrip('/'), status=status,
                               auth=bool(op.get('security', contract.get('security'))),
                               parameters=[dict(name=p['name'], where=p['in'], py=snake(p['name']), js=p['name'][0].lower()+p['name'][1:] if p['in'] != 'header' else re.sub(r'-(\w)', lambda m: m[1].upper(), p['name'].lower()), schema=shape(p['schema'])) for p in params],
                               body=shape(body) if body else None, response=shape(response), binary=binary)
        metadata = operations[oid]
        pyargs = [snake(p['name']) + ': ' + kind(p['schema'], 'py') for p in pp]
        tsargs = [p['name'] + ': ' + kind(p['schema'], 'ts') for p in pp]
        if body:
            pyargs.append('body: ' + kind(body, 'py'))
            tsargs.append('body: Models.' + kind(body, 'ts'))
        if qp:
            pyargs += ['*'] + [snake(p['name']) + ': ' + kind(p['schema'], 'py') + ' | None = None' for p in qp]
            opt_name = oid + 'Options'
            tsm += f'export interface {opt_name} {{\n'
            for p in metadata['parameters']:
                if p['where'] != 'path':
                    tsm += f'  {p["js"]}?: {kind(p["schema"], "ts")};\n'
            tsm += '}\n\n'
            tsargs.append('options: Models.' + opt_name + ' = {}')
        tsargs.append('request: RequestOptions = {}')
        pr = 'PortalDownload' if binary else kind(response, 'py')
        tr = 'PortalDownload' if binary else ('Models.' + kind(response, 'ts') if '$ref' in response else kind(response, 'ts'))
        if response.get('type') == 'array' and '$ref' in response.get('items', {}):
            tr = 'Models.' + type_name(response['items']['$ref'].split('/')[-1]) + '[]'
        pyc += '\n    def ' + pn + '(self' + (', ' + ', '.join(pyargs) if pyargs else '') + ') -> ' + pr + ':\n'
        pyc += '        ' + repr(brief(op.get('summary', oid))) + '\n'
        pyc += '        return self._request(' + repr(oid) + ', {' + ', '.join(repr(p['name']) + ': ' + snake(p['name']) for p in params) + '}, ' + ('body' if body else 'None') + ')\n'
        tsc += '  /** ' + brief(op.get('summary', oid)) + ' */\n  ' + jn + '(' + ', '.join(tsargs) + '): Promise<' + tr + '> {\n'
        values = [json.dumps(p['name']) + ': ' + (p['name'] if p['in'] == 'path' else 'options.' + next(m['js'] for m in metadata['parameters'] if m['name'] == p['name'])) for p in params]
        tsc += '    return this.send(' + json.dumps(oid) + ', {' + ', '.join(values) + '}, ' + ('body' if body else 'undefined') + ', request) as Promise<' + tr + '>;\n  }\n\n'
        example = next((c['example'] for c in content.values() if 'example' in c), [] if response.get('type') == 'array' else {})
        cases.append(dict(operation=oid, python=pn, javascript=jn, **metadata, example=example))
        rows.append(f'| `{oid}` | `{pn}` | `{jn}` | {verb.upper()} | `{path}` |')
tsc += '}\n'

payload = dict(schemas={k: shape(v) for k, v in schemas.items()}, operations=operations)
files = {
    py / 'src/kombine_flex_portal/models.py': pym,
    py / 'src/kombine_flex_portal/client.py': pyc,
    py / 'src/kombine_flex_portal/_contract.json': json.dumps(payload, ensure_ascii=True, separators=(',', ':')) + '\n',
    js / 'src/models.ts': tsm,
    js / 'src/client.ts': tsc,
    js / 'src/contract.ts': '// Generated wire metadata.\nexport const contract = ' + json.dumps(payload, ensure_ascii=True, separators=(',', ':')) + ';\n',
}
for folder in [py, js]:
    files[folder / 'tests/contract-cases.json'] = json.dumps(cases, ensure_ascii=True, indent=2) + '\n'
    files[folder / 'OPERATIONS.md'] = '# Public API operations\n\n| Operation ID | Python | JavaScript/TypeScript | HTTP | Path |\n| --- | --- | --- | --- | --- |\n' + '\n'.join(rows) + '\n'
stale = []
for path, text in files.items():
    if args.check:
        if not path.exists() or path.read_text(encoding='utf-8') != text:
            stale.append(str(path.relative_to(ROOT)))
    else:
        path.parent.mkdir(parents=True, exist_ok=True)
        path.write_text(text, encoding='utf-8', newline='\n')
if stale:
    raise SystemExit('Regenerate outdated client files:\n' + '\n'.join(stale))
print(f'{"Verified" if args.check else "Generated"} {len(operations)} operations for Python and TypeScript.')
