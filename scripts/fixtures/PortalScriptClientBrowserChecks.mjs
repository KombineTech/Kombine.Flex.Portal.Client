// Synthetic, read/write loopback fixtures only; never contacts tenant databases.
import assert from 'node:assert/strict';
import { readFile } from 'node:fs/promises';
import { createServer } from 'node:http';
import { pathToFileURL } from 'node:url';

const { chromium } = await import(process.env.PLAYWRIGHT_MODULE ? pathToFileURL(process.env.PLAYWRIGHT_MODULE).href : 'playwright');
const dist = new URL('../../Kombine.Flex.Portal.Client.JavaScript/dist/', import.meta.url);
const calls = [];
const server = createServer(async (req, res) => {
  try {
    if (req.url === '/') {
      res.writeHead(200, { 'Content-Type': 'text/html; charset=utf-8' });
      res.end('<!doctype html><title>SDK fixture</title>');
    } else if (req.url === '/favicon.ico') {
      res.writeHead(204);
      res.end();
    } else if (/^\/sdk\/[a-z]+\.js$/.test(req.url)) {
      res.writeHead(200, { 'Content-Type': 'text/javascript; charset=utf-8' });
      res.end(await readFile(new URL(req.url.slice(5), dist)));
    } else {
      const data = [];
      for await (const chunk of req) data.push(chunk);
      const body = Buffer.concat(data).toString();
      calls.push({ path: req.url, authorization: req.headers.authorization, body });
      res.setHeader('Content-Type', 'application/json');
      if (req.url === '/api/v1/session/login') {
        assert.deepEqual(JSON.parse(body), { email: 'browser@example.test', password: 'synthetic' });
        res.end('{"accessToken":"browser-fixture","expiresIn":3600,"tokenType":"Bearer"}');
      } else if (req.url === '/api/v1/session/me') {
        res.end('{"name":"Browser fixture","tabDetails":[{"id":35,"name":"Users2"}]}');
      } else if (req.url === '/api/v1/banks/bank-kid/users/balances') {
        assert.deepEqual(JSON.parse(body), { userKids: ['user-kid'] });
        res.end('{"items":[{"kid":"user-kid","balances":[{"currency":"DKK","currentBalanceMinor":9223372036854775807,"previousBalanceMinor":null}]}]}');
      } else if (req.url === '/api/v1/banks/bank-kid/users/export') {
        res.setHeader('Content-Type', 'text/csv');
        res.end('nummer;navn\n1;Beboer\n');
      } else if (req.url === '/api/v1/status') {
        res.end('{"status":"ok"}');
      } else {
        res.writeHead(404);
        res.end('{}');
      }
    }
  } catch {
    res.writeHead(500);
    res.end('{}');
  }
});
await new Promise(resolve => server.listen(0, '127.0.0.1', resolve));
const browser = await chromium.launch({ headless: true, ...(process.env.PORTAL_TEST_BROWSER_CHANNEL ? { channel: process.env.PORTAL_TEST_BROWSER_CHANNEL } : {}) });
try {
  const page = await browser.newPage();
  const errors = [];
  page.on('pageerror', error => errors.push(error.message));
  await page.goto(`http://127.0.0.1:${server.address().port}/`);
  const actual = await page.evaluate(async () => {
    const { PortalClient } = await import('/sdk/index.js');
    const api = new PortalClient(location.origin + '/');
    const session = await api.login('browser@example.test', 'synthetic');
    const manager = await api.getCurrentManager();
    const balance = await api.getBankUserBalances('bank-kid', { userKids: ['user-kid'] });
    const download = await api.exportBankUsers('bank-kid');
    let csv = '';
    try { for await (const bytes of download.chunks()) csv += new TextDecoder().decode(bytes); }
    finally { await download.close(); }
    const status = await api.getPortalStatus();
    api.clearSession();
    return {
      name: manager.name, tab: manager.tabDetails[0].id, tabType: typeof manager.tabDetails[0].id,
      amount: balance.items[0].balances[0].currentBalanceMinor.toString(),
      missing: balance.items[0].balances[0].previousBalanceMinor,
      expiryType: typeof session.expiresIn, csv, status: status.status, token: api.accessToken
    };
  });
  assert.deepEqual(actual, {
    name: 'Browser fixture', tab: 35, tabType: 'number', amount: '9223372036854775807',
    missing: null, expiryType: 'bigint', csv: 'nummer;navn\n1;Beboer\n', status: 'ok', token: null
  });
  assert.deepEqual(errors, []);
  assert.equal(calls.length, 5);
  assert.equal(calls[0].authorization, undefined);
  assert.equal(calls.at(-1).authorization, undefined);
  assert.ok(calls.slice(1, -1).every(call => call.authorization === 'Bearer browser-fixture'));
  console.log('Chromium browser checks passed: real fetch, login/session, profile, exact int64, null, streamed CSV, anonymous status and logout.');
} finally {
  await browser.close();
  server.closeAllConnections();
  await new Promise(resolve => server.close(resolve));
}
