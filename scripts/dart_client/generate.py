"""Reusable Dart generator. Call generate() with an explicit contract and destination."""
from pathlib import Path
import hashlib,json,re

HERE=Path(__file__).resolve().parent
RESERVED={'class','enum','extends','with','switch','case','default','final','const','var','void','return','throw','new','this','super','in','is','as','if','else','for','while','do','try','catch','finally','import','export','part','library','assert','break','continue','rethrow','null','true','false','dynamic','required','covariant','abstract','external','factory','static','operator','get','set','late','typedef','extension','mixin','on','sync','yield','await','async'}
def identifier(name):
    name=re.sub(r'[-_](\w)',lambda m:m[1].upper(),name)
    name=name[0].lower()+name[1:]
    return name+'Value' if name in RESERVED or name=='cancel' else name
def shape(schema):
    if len(schema.get('allOf',[]))==1 and '$ref' in schema['allOf'][0]:
        schema={**schema['allOf'][0],**{k:v for k,v in schema.items() if k!='allOf'}}
    return {k:({p:shape(v) for p,v in value.items()} if k=='properties' else shape(value) if isinstance(value,dict) else value)
            for k,value in schema.items() if k in ('$ref','type','format','nullable','properties','items','additionalProperties','required','enum')}
def kind(schema):
    schema=shape(schema)
    if '$ref' in schema:t=schema['$ref'].split('/')[-1]
    elif schema.get('type')=='array':t='List<'+kind(schema['items'])+'>'
    else:t={'string':'String','integer':'BigInt' if schema.get('format')=='int64' else 'int','boolean':'bool','number':'num','object':'Map<String, Object?>'}.get(schema.get('type'),'Object?')
    return t+'?' if schema.get('nullable') and not t.endswith('?') else t
def cast(value,schema):
    if schema is None:return value
    if schema.get('type')=='array':
        expr=f'({value} as List).map((v) => {cast("v",schema["items"])}).toList()'
        return f'{value} == null ? null : {expr}' if schema.get('nullable') else expr
    return f'{value} as {kind(schema)}'
class Int64(int):pass
def literal(value):
    if isinstance(value,Int64):return f"BigInt.parse('{value}')"
    if value is None:return 'null'
    if isinstance(value,bool):return str(value).lower()
    if isinstance(value,str):return json.dumps(value,ensure_ascii=True).replace('$',r'\$')
    if isinstance(value,list):return '<Object?>['+', '.join(literal(v) for v in value)+']'
    if isinstance(value,dict):return '<String, Object?>{'+', '.join(literal(k)+': '+literal(v) for k,v in value.items())+'}'
    return str(value)
def sample(schema,schemas,depth=0):
    if schema is None:return None
    schema=shape(schema)
    if schema.get('nullable'):return None
    if '$ref' in schema:return sample(schemas[schema['$ref'].split('/')[-1]],schemas,depth+1)
    t=schema.get('type')
    if t=='object':return {} if depth>4 else {k:sample(v,schemas,depth+1) for k,v in schema.get('properties',{}).items()}
    if t=='array':return [] if depth>4 else [sample(schema['items'],schemas,depth+1)]
    if t=='integer':return Int64(9007199254740993) if schema.get('format')=='int64' else 7
    if t=='number':return 1.25
    if t=='boolean':return False
    if t=='string':return '2026-10-20' if schema.get('format')=='date' else '2026-10-20T10:00:00Z' if schema.get('format')=='date-time' else 'fixture'
    return None
def generate(destination,source,api,package,check=False):
    destination,source=Path(destination),Path(source)
    raw=source.read_bytes();doc=json.loads(raw.decode('utf-8-sig'));operations={};methods=[];rows=[];cases=[];tests=[]
    models=['// Generated wire aliases. Object fields retain their exact JSON names.\n']
    for name,schema in doc['components']['schemas'].items():
        models.append(f'typedef {name} = '+('String' if schema.get('type')=='string' else 'int' if schema.get('type')=='integer' else 'Map<String, Object?>')+';')
    for path,verbs in doc['paths'].items():
        for verb,op in verbs.items():
            if 'operationId' not in op:continue
            oid=op['operationId'];name=identifier(oid);params=op.get('parameters',[])
            content=op.get('requestBody',{}).get('content',{})
            body=content.get('application/json',{}).get('schema');multipart=content.get('multipart/form-data',{}).get('schema')
            successes=sorted((int(k),v) for k,v in op['responses'].items() if k.isdigit() and 200<=int(k)<300)
            if not successes:raise ValueError('No documented success: '+oid)
            response_content=successes[0][1].get('content',{})
            response=next(iter(response_content.values())).get('schema') if response_content else None
            binary=bool(response and response.get('format')=='binary')
            metadata=dict(method=verb.upper(),path=path.lstrip('/'),auth=bool(op.get('security',doc.get('security'))),statuses=[s for s,_ in successes],
                parameters=[dict(name=p['name'],where=p['in'],required=bool(p.get('required')),schema=shape(p['schema'])) for p in params],
                body=shape(body) if body else None,bodyRequired=bool(op.get('requestBody',{}).get('required')),multipart=shape(multipart) if multipart else None,response=shape(response) if response else None,binary=binary)
            operations[oid]=metadata
            args=[]
            for p in params:
                t=kind(p['schema']);required=p.get('required',False)
                if not required and not t.endswith('?'):t+='?'
                args.append(('required ' if required else '')+t+' '+identifier(p['name']))
            if body or multipart:
                t='Map<String, Object?>' if multipart else kind(body)
                req=metadata['bodyRequired']
                if not req and not t.endswith('?'):t+='?'
                args.append(('required ' if req else '')+t+' body')
            args.append('Future<void>? cancel')
            returns='ApiDownload' if binary else kind(response) if response else 'void'
            values='{'+', '.join(json.dumps(p['name'])+': '+identifier(p['name']) for p in params)+'}'
            invocation=f'await call({json.dumps(oid)}, {values}, '+('body' if body or multipart else 'null')+', cancel: cancel)'
            lines=(f'    final result = {invocation};\n    return '+('result as ApiDownload' if binary else cast('result',response))+';') if response else f'    {invocation};'
            summary=' '.join(op.get('summary',oid).split()).replace('*/','* /')
            methods.append(f'  /// {summary}\n  Future<{returns}> {name}({{'+', '.join(args)+'}) async {\n'+lines+'\n  }\n')
            rows.append(f'| `{oid}` | `{name}` | {verb.upper()} | `{path}` |')
            example=next((c['example'] for c in response_content.values() if 'example' in c),None)
            cases.append(dict(operation=oid,dartMethod=name,example=example,**metadata))
            arguments=[];assertions=[];expected_path=path
            for p in params:
                value=sample(p['schema'],doc['components']['schemas'])
                if value is None:
                    value=sample({k:v for k,v in p['schema'].items() if k!='nullable'},doc['components']['schemas'])
                if p['in']=='path' and isinstance(value,str):value='fixture /æ?&'
                if p['in']=='path':
                    from urllib.parse import quote
                    expected_path=expected_path.replace('{'+p['name']+'}',quote(str(value),safe="~!*'()-._"))
                expression=literal(value)
                if isinstance(value,list):expression=expression.replace('<Object?>','<'+kind(p['schema']['items'])+'>',1)
                arguments.append(identifier(p['name'])+': '+expression)
                if p['in']=='query':
                    expected=[str(v).lower() if isinstance(v,bool) else str(v) for v in value] if isinstance(value,list) else [str(value).lower() if isinstance(value,bool) else str(value)]
                    assertions.append(f"      expect(request.url.queryParametersAll[{literal(p['name'])}], {literal(expected)});")
                if p['in']=='header':assertions.append(f"      expect(request.headers[{literal(p['name'])}], {literal(str(value))});")
            if body:
                request_sample=literal(sample(body,doc['components']['schemas']))
                arguments.append('body: '+request_sample)
                assertions.append(f"      expect(request.body, encodeApiJson({request_sample}));")
                assertions.append("      expect(request.headers['content-type'], contains('application/json'));")
            if multipart:
                multipart_schema=doc['components']['schemas'][multipart['$ref'].split('/')[-1]] if '$ref' in multipart else multipart
                fields=[]
                for key,field in multipart_schema.get('properties',{}).items():
                    value="ApiUploadFile(() => Stream.value([1, 2, 3]), 3, 'fixture.bin')" if field.get('format')=='binary' else literal(sample(field,doc['components']['schemas']))
                    fields.append(literal(key)+': '+value)
                arguments.append('body: <String, Object?>{'+', '.join(fields)+'}')
            result=sample(response,doc['components']['schemas']) if response and not binary else None
            response_expression="http.Response.bytes([1, 2, 3], "+str(successes[0][0])+")" if binary else f"http.Response({('encodeApiJson('+literal(result)+')') if response else literal('')}, {successes[0][0]})"
            verify="expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);" if binary else f"expect(encodeApiJson(result), encodeApiJson({literal(result)}));" if response else ''
            invocation=f"await client.{name}("+', '.join(arguments)+')'
            tests.append(f'''  test({literal('wire '+oid)}, () async {{
    var sends = 0;
    final client = {api}Client('https://example.invalid/', httpClient: MockClient((request) async {{
      sends++;
      expect(request.method, {literal(verb.upper())});
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, {literal('https://example.invalid'+expected_path)});
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], {literal('Bearer fixture-token') if metadata['auth'] else 'isNull'});
{chr(10).join(assertions)}
      return {response_expression};
    }}));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    {'final result = ' if response else ''}{invocation};
    {verify}
    expect(sends, 1);
  }});
''')
    payload=dict(schemas={k:shape(v) for k,v in doc['components']['schemas'].items()},operations=operations)
    contract_json=json.dumps(payload,ensure_ascii=True,separators=(',',':'))
    if "'''" in contract_json:raise ValueError('Unexpected raw string delimiter')
    client=f'''// Generated from the bundled OpenAPI contract. Do not edit by hand.
import 'dart:convert';
import 'package:http/http.dart' as http;
import 'runtime.dart';
import 'models.dart';
final Map<String, dynamic> _{api.lower()}Contract = jsonDecode(r\x27\x27\x27{contract_json}\x27\x27\x27) as Map<String, dynamic>;
class {api}Client extends ApiClient {{
  {api}Client(String baseUrl, {{http.Client? httpClient, Duration timeout = const Duration(seconds: 30), int maxJsonBytes = 8 * 1024 * 1024}})
      : super(baseUrl, _{api.lower()}Contract, '{'LoginManager' if api=='Portal' else 'LoginService'}', httpClient: httpClient, timeout: timeout, maxJsonBytes: maxJsonBytes);
{chr(10).join(methods)}
}}
'''
    files={destination/'lib/src/client.dart':client,destination/'lib/src/models.dart':'\n'.join(models)+'\n',
        destination/'lib'/f'{package}.dart':"export 'src/client.dart';\nexport 'src/models.dart';\nexport 'src/runtime.dart';\nexport 'src/json.dart';\n",
        destination/'lib/src/runtime.dart':(HERE/'runtime.dart').read_text(encoding='utf-8'),destination/'lib/src/json.dart':(HERE/'json.dart').read_text(encoding='utf-8'),
        destination/'OpenApi'/f'{api.lower()}.openapi.json':raw.decode('utf-8-sig').replace('\r\n','\n'),
        destination/'test/contract-cases.json':json.dumps(cases,indent=2)+'\n',
        destination/'OPERATIONS.md':f'# {api} Dart operations\n\n{len(operations)} operations. OpenAPI SHA-256: `{hashlib.sha256(raw).hexdigest()}`.\n\n| Stable operation ID | Dart method | HTTP | Path |\n| --- | --- | --- | --- |\n'+'\n'.join(rows)+'\n',
        destination/'test/operations_test.dart':"// Generated contract coverage.\nimport 'package:http/http.dart' as http;\nimport 'package:http/testing.dart';\nimport 'package:test/test.dart';\nimport 'package:"+package+'/'+package+".dart';\nvoid main() {\n"+'\n'.join(tests)+'}\n',
        destination/'test/runtime_test.dart':(HERE/'runtime_test.dart').read_text(encoding='utf-8').replace('PACKAGE',package),
        destination/'example/browser_smoke.dart':(HERE/'browser_smoke.dart').read_text(encoding='utf-8').replace('PACKAGE',package)}
    stale=[]
    for path,text in files.items():
        if check:
            if not path.exists() or path.read_text(encoding='utf-8')!=text:stale.append(str(path))
        else:
            path.parent.mkdir(parents=True,exist_ok=True);path.write_text(text,encoding='utf-8',newline='\n')
    if stale:raise SystemExit('Regenerate Dart files:\n'+'\n'.join(stale))
    print(f'{api}: {len(operations)} Dart operations '+('verified.' if check else 'generated.'))
