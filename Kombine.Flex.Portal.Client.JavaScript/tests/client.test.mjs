import { test } from 'node:test';
import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
import { createServer } from 'node:http';
import { PortalClient, PortalDownload, PortalApiError, PortalProtocolError, PortalSessionError } from '../dist/index.js';
import { contract } from '../dist/contract.js';
import { parseJson, stringifyJson } from '../dist/json.js';

const cases = JSON.parse(await readFile(new URL('contract-cases.json', import.meta.url)));
const json = (value, status = 200, headers = {}) => new Response(stringifyJson(value), { status, headers });
function sample(spec) {
  if (spec.$ref) return sample(contract.schemas[spec.$ref.split('/').at(-1)]);
  switch (spec.type) {
    case 'integer': return spec.format === 'int64' ? 9223372036854775807n : 17;
    case 'number': return 12.5;
    case 'string': return 'tekst æ 😀';
    case 'boolean': return false;
    case 'array': return [sample(spec.items)];
    case 'object': return Object.fromEntries(Object.entries(spec.properties ?? {}).map(([k, v]) => [k, sample(v)]));
    default: return null;
  }
}

assert.equal(cases.length, 131);
for (const spec of cases) {
  test('wire contract: ' + spec.operation, async () => {
    let observed;
    let count = 0;
    const responseBody = spec.binary ? new Uint8Array([80, 75, 0, 255]) : sample(spec.response);
    const client = new PortalClient('https://api.example.test/sub/', { fetch: async (url, init) => {
      count++;
      observed = { url: new URL(url), init };
      return spec.binary ? new Response(responseBody, { status: spec.status }) : json(responseBody, spec.status);
    }});
    client.accessToken = 'fixture-token';
    let path = '/sub/' + spec.path;
    const query = {};
    const expectedHeaders = {};
    const args = [];
    const options = {};
    let hasOptions = false;
    for (const param of spec.parameters) {
      const value = param.schema.type === 'string'
        ? param.where === 'path' ? 'Kid /?&+#æ' : param.where === 'header' ? 'da-DK' : 'a b/&?+æ'
        : sample(param.schema);
      if (param.where === 'path') {
        args.push(value);
        path = path.replace('{' + param.name + '}', encodeURIComponent(String(value)));
      } else {
        hasOptions = true;
        options[param.js] = value;
        if (param.where === 'query') query[param.name] = String(value);
        else expectedHeaders[param.name.toLowerCase()] = String(value);
      }
    }
    const body = spec.body ? sample(spec.body) : undefined;
    if (spec.body) args.push(body);
    if (hasOptions) args.push(options);
    const result = await client[spec.javascript](...args);
    assert.equal(count, 1);
    assert.equal(observed.url.pathname, path);
    assert.deepEqual(Object.fromEntries(observed.url.searchParams), query);
    assert.equal(observed.init.method, spec.method);
    assert.equal(observed.init.headers.get('authorization'), spec.auth ? 'Bearer fixture-token' : null);
    assert.equal(observed.init.redirect, 'error');
    assert.equal(observed.init.credentials, 'omit');
    assert.equal(observed.init.cache, 'no-store');
    for (const [name, value] of Object.entries(expectedHeaders)) assert.equal(observed.init.headers.get(name), value);
    if (spec.body) assert.equal(observed.init.body, stringifyJson(body));
    if (spec.binary) {
      assert.ok(result instanceof PortalDownload);
      const chunks = [];
      for await (const chunk of result.chunks()) chunks.push(...chunk);
      assert.deepEqual(chunks, [...responseBody]);
    } else assert.equal(stringifyJson(result), stringifyJson(responseBody));
  });
}

test('URL, token and options validation', () => {
  for (const base of ['http://example.test/', 'https://user:pass@example.test/', 'https://x/?', 'https://x/#', 'https://x', '//x/', 'https://x:wrong/', 'https://x/\r\n', 'https://x\\evil/']) {
    assert.throws(() => new PortalClient(base));
  }
  for (const base of ['https://api.example.test/', 'http://localhost:123/', 'http://127.0.0.1:123/', 'http://[::1]:123/']) assert.equal(new PortalClient(base).baseUrl, base);
  for (const timeoutMs of [-1, 0, Infinity, 2 ** 32]) assert.throws(() => new PortalClient('https://x/', { timeoutMs }));
  const client = new PortalClient('https://x/');
  for (const value of ['', 'a b', 'x\r\nb', 'æ']) assert.throws(() => { client.accessToken = value; });
  assert.throws(() => { client.baseUrl = 'https://y/'; });
});

test('login retains token, never sends old token, and 401 clears session', async () => {
  const calls = [];
  const client = new PortalClient('https://x/', { fetch: async (url, init) => {
    calls.push(init);
    return url.endsWith('/session/login') ? json({ accessToken: 'new-token', expiresIn: 3600n, tokenType: 'Bearer' }) : json({ code: 'unauthorized' }, 401);
  }});
  client.accessToken = 'old-token';
  const response = await client.login('x@example.test', 'secret');
  assert.equal(response.expiresIn, 3600n);
  assert.equal(calls[0].headers.has('authorization'), false);
  assert.equal(client.accessToken, 'new-token');
  await assert.rejects(client.getCurrentManager(), e => e instanceof PortalApiError && e.code === 'unauthorized');
  assert.equal(client.accessToken, null);
});

test('login failure clears previous token; raw loginManager does not retain token', async () => {
  const client = new PortalClient('https://x/', { fetch: async () => json({ code: 'invalid' }, 401) });
  client.accessToken = 'old-token';
  await assert.rejects(client.login('x@example.test', 'password'), PortalApiError);
  assert.equal(client.accessToken, null);
  const raw = new PortalClient('https://x/', { fetch: async () => json({ accessToken: 'new-token', expiresIn: 3600n, tokenType: 'Bearer' }) });
  await raw.loginManager({ email: 'x', password: 'x' });
  assert.equal(raw.accessToken, null);
});

test('late login cannot resurrect a cleared or closed session', async () => {
  for (const action of ['clearSession', 'close']) {
    let release;
    const client = new PortalClient('https://x/', { fetch: () => new Promise(resolve => { release = resolve; }) });
    const pending = client.login('x@example.test', 'password');
    client[action]();
    release(json({ accessToken: 'late', expiresIn: 3600n, tokenType: 'Bearer' }));
    await assert.rejects(pending, PortalSessionError);
    assert.equal(client.accessToken, null);
  }
});

test('older 401 cannot clear a replacement session', async () => {
  let release;
  const client = new PortalClient('https://x/', { fetch: () => new Promise(resolve => { release = resolve; }) });
  client.accessToken = 'old-token';
  const pending = client.getCurrentManager();
  client.accessToken = 'new-token';
  release(json({ code: 'unauthorized' }, 401));
  await assert.rejects(pending, PortalApiError);
  assert.equal(client.accessToken, 'new-token');
});

test('int64, Unicode and JSON parser preserve values and reject invalid documents', () => {
  const original = { x: 9223372036854775807n, y: -9223372036854775808n, value: 'æ 😀 \\ " \n', nullable: null, list: [true, false, 0n, 12.5] };
  assert.equal(stringifyJson(parseJson(stringifyJson(original))), stringifyJson(original));
  for (const text of ['{"a":1,"a":2}', 'NaN', 'Infinity', '01', '1e999', '{"a":}', '{"a":1,}', '[1,]', '{} trailing', '"\\ud800"', '"\\udc00"', '"unescaped\nline"', '['.repeat(70) + ']'.repeat(70)]) assert.throws(() => parseJson(text), PortalProtocolError);
  for (const value of [NaN, Infinity, 9007199254740992, new Date(), '\ud800', [undefined], Array(1)]) assert.throws(() => stringifyJson(value), PortalProtocolError);
  const circular = {}; circular.self = circular;
  assert.throws(() => stringifyJson(circular), PortalProtocolError);
  const pollution = parseJson('{"__proto__":{"polluted":true}}');
  assert.equal(Object.getPrototypeOf(pollution), null);
  assert.equal({}.polluted, undefined);
  assert.equal(stringifyJson(pollution), '{"__proto__":{"polluted":true}}');
});

test('malformed API schema, invalid UTF-8 and size limits', async () => {
  for (const payload of ['null', '[]', '{"expiresIn":9223372036854775808}', '{"expiresIn":true}', '{"expiresIn":"1"}', '{"x":"\\ud800"}', new Uint8Array([123, 34, 120, 34, 58, 34, 255, 34, 125])]) {
    const client = new PortalClient('https://x/', { fetch: async () => new Response(payload) });
    await assert.rejects(client.loginManager({ email: 'x', password: 'x' }), PortalProtocolError);
  }
  const client = new PortalClient('https://x/', { maxJsonBytes: 4, fetch: async () => json({ data: 'large' }) });
  await assert.rejects(client.getPortalStatus(), PortalProtocolError);
  await assert.rejects(client.loginManager({ email: 'x', password: 'x' }), PortalProtocolError);
});

test('response preserves null; errors retain code, status and headers without retry', async () => {
  const client = new PortalClient('https://x/', { fetch: async () => json({ accessToken: null, expiresIn: 17n, tokenType: null }) });
  const result = await client.loginManager({ email: 'x', password: 'x' });
  assert.equal(result.accessToken, null);
  let calls = 0;
  const failed = new PortalClient('https://x/', { fetch: async () => { calls++; return json({ code: 'busy', detail: 'private' }, 503, { 'Retry-After': '60' }); } });
  await assert.rejects(failed.getPortalStatus(), e => {
    assert.ok(e instanceof PortalApiError);
    assert.equal(e.status, 503);
    assert.equal(e.code, 'busy');
    assert.equal(e.headers.get('Retry-After'), '60');
    assert.equal(e.message.includes('private'), false);
    return true;
  });
  assert.equal(calls, 1);
});

test('streaming close, early break and cancellation release body', async () => {
  let cancelled = 0;
  const make = () => new PortalClient('https://x/', { fetch: async () => new Response(new ReadableStream({
    pull(controller) { controller.enqueue(new Uint8Array([1, 2, 3])); },
    cancel() { cancelled++; }
  })) });
  const download = await make().exportBankUsers('kid');
  assert.equal(cancelled, 0);
  for await (const chunk of download.chunks()) { assert.deepEqual([...chunk], [1, 2, 3]); break; }
  assert.equal(cancelled, 1);
  await download.close();
  assert.equal(cancelled, 1);
  await assert.rejects(async () => { for await (const _ of download.chunks()) {} }, PortalProtocolError);
  const unopened = await make().exportBankUsers('kid');
  await unopened.close();
  assert.equal(cancelled, 2);
});

test('invalid arguments and closed client do not reach transport', async () => {
  const client = new PortalClient('https://x/', { fetch: async () => assert.fail('Unexpected HTTP request') });
  for (const kid of ['', '.', '..']) await assert.rejects(client.getManager(kid), TypeError);
  await assert.rejects(client.getLocationUnits('kid', { acceptLanguage: 'da\r\nX: invalid' }), TypeError);
  await assert.rejects(client.loginManager({ email: 'x', password: {} }), PortalProtocolError);
  const abort = new AbortController(); abort.abort();
  await assert.rejects(client.getPortalStatus({ signal: abort.signal }), e => e.name === 'AbortError');
  client.close();
  await assert.rejects(client.getPortalStatus(), PortalSessionError);
});

test('real HTTP, no redirects, deadline and external abort including response body', async t => {
  const paths = [];
  const server = createServer((req, res) => {
    paths.push(req.url);
    if (req.url.startsWith('/redirect/')) { res.writeHead(302, { Location: '/never' }); res.end(); }
    else if (req.url.startsWith('/slow/')) {
      res.writeHead(200, { 'Content-Type': 'application/json' });
      res.write('{'); // Deadline must cover the body, not just headers.
      const timer = setTimeout(() => res.end('}'), 5000);
      res.on('close', () => clearTimeout(timer));
    } else { res.writeHead(200, { 'Content-Type': 'application/json' }); res.end('{"status":"ok"}'); }
  });
  await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
  t.after(() => { server.closeAllConnections(); server.close(); });
  const base = `http://127.0.0.1:${server.address().port}/`;
  assert.equal((await new PortalClient(base).getPortalStatus()).status, 'ok');
  await assert.rejects(new PortalClient(base + 'redirect/').getPortalStatus());
  assert.equal(paths.includes('/never'), false);
  await assert.rejects(new PortalClient(base + 'slow/', { timeoutMs: 80 }).getPortalStatus(), e => e.name === 'TimeoutError' || e.name === 'AbortError');
  const abort = new AbortController();
  const pending = new PortalClient(base + 'slow/').getPortalStatus({ signal: abort.signal });
  setTimeout(() => abort.abort(), 80);
  await assert.rejects(pending, e => e.name === 'AbortError');
});
