import { contract } from "./contract.js";
import { parseJson, stringifyJson, PortalProtocolError } from "./json.js";
import type { ManagerSessionResponse } from "./models.js";
export { PortalProtocolError } from "./json.js";

export interface RequestOptions { signal?: AbortSignal; }
export interface ClientOptions {
  /** Deadline including response consumption, milliseconds. Default 30,000. */
  timeoutMs?: number;
  /** Maximum JSON request/response bytes. Does not limit streamed files. */
  maxJsonBytes?: number;
  /** Optional standards-compatible transport for hosts/tests. Must honor redirect and abort. */
  fetch?: typeof globalThis.fetch;
}
export class PortalSessionError extends Error { override name = "PortalSessionError"; }
export class PortalApiError extends Error {
  override name = "PortalApiError";
  readonly code?: string;
  constructor(readonly status: number, readonly response: string, readonly headers: Headers) {
    super(`Portal API request failed (HTTP ${status}).`);
    try {
      const data = parseJson(response);
      if (data && typeof data === "object" && "code" in data && typeof data.code === "string") this.code = data.code;
    } catch { /* Error responses need not be JSON. Avoid logging their potentially sensitive body. */ }
  }
}

type Schema = { $ref?: string; type?: string; format?: string; properties?: Record<string, Schema>; items?: Schema; additionalProperties?: Schema | boolean };
type Operation = { method: string; path: string; auth: boolean; status: number; binary: boolean; body: Schema | null; response: Schema; parameters: { name: string; where: string; schema: Schema }[] };
const schemas = contract.schemas as Record<string, Schema>;
const operations = contract.operations as Record<string, Operation>;

function checkShape(value: unknown, schema: Schema, incoming: boolean, depth = 0): unknown {
  if (depth > 64) throw new PortalProtocolError("JSON nesting limit exceeded.");
  if (value === null || value === undefined) return value;
  if (schema.$ref) schema = schemas[schema.$ref.split("/").at(-1)!];
  const fail = (): never => { throw new PortalProtocolError("Invalid API " + schema.type + "."); };
  switch (schema.type) {
    case "integer": {
      const bits = schema.format === "int64" ? 64n : 32n;
      if (!incoming && bits === 64n && typeof value !== "bigint") return fail();
      if (typeof value !== "bigint" && !(typeof value === "number" && Number.isSafeInteger(value))) return fail();
      const n = BigInt(value as bigint | number);
      if (n < -(1n << (bits - 1n)) || n >= (1n << (bits - 1n))) return fail();
      return bits === 64n ? n : Number(n);
    }
    case "number": {
      const n = typeof value === "bigint" ? Number(value) : value;
      if (typeof n !== "number" || !Number.isFinite(n)) return fail();
      return n;
    }
    case "string": if (typeof value !== "string") return fail(); break;
    case "boolean": if (typeof value !== "boolean") return fail(); break;
    case "array":
      if (!Array.isArray(value)) return fail();
      return value.map(item => checkShape(item, schema.items!, incoming, depth + 1));
    case "object": {
      if (typeof value !== "object" || Array.isArray(value)) return fail();
      const result: Record<string, unknown> = Object.create(null);
      for (const [key, item] of Object.entries(value)) {
        const field = Object.hasOwn(schema.properties ?? {}, key) ? schema.properties![key] : schema.additionalProperties;
        result[key] = typeof field === "object" ? checkShape(item, field, incoming, depth + 1) : item;
      }
      return result;
    }
  }
  return value;
}

export class PortalDownload {
  readonly status: number;
  readonly headers: Headers;
  #used = false;
  #closed = false;
  #reader?: ReadableStreamDefaultReader<Uint8Array>;
  constructor(private response: Response, private abort: AbortController, private finish: () => void) {
    this.status = response.status;
    this.headers = new Headers(response.headers);
  }
  /** Single-use, bounded-memory streaming. Breaking out also closes the response. */
  async *chunks(): AsyncGenerator<Uint8Array> {
    if (this.#used || this.#closed) throw new PortalProtocolError("Download already consumed or closed.");
    this.#used = true;
    try {
      this.abort.signal.throwIfAborted();
      this.#reader = this.response.body?.getReader();
      while (this.#reader) {
        const chunk = await this.#reader.read();
        this.abort.signal.throwIfAborted();
        if (chunk.done) break;
        yield chunk.value;
      }
    } finally { await this.close(); }
  }
  async close(): Promise<void> {
    if (this.#closed) return;
    this.#closed = true;
    this.finish();
    try {
      if (this.#reader) await this.#reader.cancel();
      else await this.response.body?.cancel();
    } catch { /* An aborted network body may already be closed. */ }
    finally { this.#reader?.releaseLock(); this.abort.abort(); }
  }
}

export class BaseClient {
  #baseUrl: string;
  #fetch: typeof globalThis.fetch;
  #timeout: number;
  #maxBytes: number;
  #token: string | null = null;
  #version = 0;
  #closed = false;
  constructor(apiBaseUrl: string, options: ClientOptions = {}) {
    if (typeof apiBaseUrl !== "string" || /[\x00-\x20\x7f\\?#]/.test(apiBaseUrl) || !apiBaseUrl.endsWith("/")) throw new TypeError("Use an absolute HTTPS API URL ending in /.");
    const url = new URL(apiBaseUrl);
    const local = url.protocol === "http:" && ["localhost", "127.0.0.1", "[::1]"].includes(url.hostname);
    if ((url.protocol !== "https:" && !local) || url.username || url.password) throw new TypeError("Use HTTPS, without credentials, query or fragment.");
    this.#baseUrl = url.href;
    this.#fetch = options.fetch ?? globalThis.fetch.bind(globalThis);
    this.#timeout = options.timeoutMs ?? 30_000;
    this.#maxBytes = options.maxJsonBytes ?? 16 * 1024 * 1024;
    if (!Number.isSafeInteger(this.#timeout) || this.#timeout <= 0 || this.#timeout > 2_147_483_647) throw new TypeError("Invalid timeoutMs.");
    if (!Number.isSafeInteger(this.#maxBytes) || this.#maxBytes <= 0) throw new TypeError("Invalid maxJsonBytes.");
  }
  get baseUrl(): string { return this.#baseUrl; }
  get accessToken(): string | null { return this.#token; }
  set accessToken(value: string | null) {
    this.ensureOpen();
    if (value !== null && !validToken(value)) throw new TypeError("Invalid bearer token.");
    this.#version++;
    this.#token = value;
  }
  /** Local logout only. Copies of a token retain their original server expiry. */
  clearSession(): void { this.#version++; this.#token = null; }
  /** Stops new calls; callers cancel active calls with their AbortSignal. */
  close(): void { this.clearSession(); this.#closed = true; }
  private ensureOpen(): void { if (this.#closed) throw new PortalSessionError("Client closed."); }
  async login(email: string, password: string, request: RequestOptions = {}): Promise<ManagerSessionResponse> {
    this.ensureOpen();
    if (typeof email !== "string" || !email.trim() || typeof password !== "string" || !password) throw new TypeError("Email and password are required.");
    this.clearSession();
    const version = this.#version;
    const response = await this.send("LoginManager", {}, { email, password }, request) as ManagerSessionResponse;
    if (!validToken(response.accessToken) || response.tokenType?.toLowerCase() !== "bearer" || typeof response.expiresIn !== "bigint" || response.expiresIn <= 0n) throw new PortalProtocolError("Incomplete login response.");
    if (this.#closed || version !== this.#version) throw new PortalSessionError("The session changed during login.");
    this.#token = response.accessToken;
    return response;
  }
  protected async send(operation: string, values: Record<string, unknown>, body: unknown, request: RequestOptions): Promise<unknown> {
    this.ensureOpen();
    const spec = operations[operation];
    const version = this.#version;
    const token = spec.auth ? this.#token : null;
    let path = spec.path;
    const query = new URLSearchParams();
    const headers = new Headers({ Accept: "application/json, application/zip, text/csv" });
    if (token) headers.set("Authorization", "Bearer " + token);
    for (const param of spec.parameters) {
      const value = values[param.name];
      if (value == null && param.where !== "path") continue;
      checkShape(value, param.schema, false);
      const text = String(value);
      if (param.where === "path") {
        if (value == null || ["", ".", ".."].includes(text)) throw new TypeError("A route identifier is required.");
        path = path.replace("{" + param.name + "}", encodeURIComponent(text));
      } else if (param.where === "query") query.append(param.name, text);
      else {
        if (/[^\x20-\x7e]/.test(text)) throw new TypeError("Invalid header value.");
        headers.set(param.name, text);
      }
    }
    let serialized: string | undefined;
    if (spec.body) {
      if (body == null) throw new TypeError("A request body is required.");
      checkShape(body, spec.body, false);
      serialized = stringifyJson(body);
      if (new TextEncoder().encode(serialized).length > this.#maxBytes) throw new PortalProtocolError("JSON request exceeds configured limit.");
      headers.set("Content-Type", "application/json; charset=utf-8");
    }
    const abort = new AbortController();
    const relay = () => abort.abort(request.signal?.reason);
    request.signal?.addEventListener("abort", relay, { once: true });
    if (request.signal?.aborted) relay();
    const timer = setTimeout(() => abort.abort(new DOMException("Portal request timed out.", "TimeoutError")), this.#timeout);
    const finish = () => { clearTimeout(timer); request.signal?.removeEventListener("abort", relay); };
    let transferred = false;
    let response: Response | undefined;
    try {
      abort.signal.throwIfAborted();
      response = await this.#fetch(this.#baseUrl + path + (query.size ? "?" + query : ""), {
        method: spec.method, headers, body: serialized, signal: abort.signal,
        redirect: "error", credentials: "omit", cache: "no-store"
      });
      abort.signal.throwIfAborted();
      if (response.status === 401 && token && version === this.#version && this.#token === token) this.clearSession();
      if (response.status === spec.status && spec.binary) {
        transferred = true;
        return new PortalDownload(response, abort, finish);
      }
      const text = await this.readJsonBody(response, abort.signal);
      if (response.status !== spec.status) throw new PortalApiError(response.status, text, new Headers(response.headers));
      const result = parseJson(text);
      if (result === null) throw new PortalProtocolError("Missing response data.");
      return checkShape(result, spec.response, true);
    } finally {
      if (!transferred) {
        finish();
        try { await response?.body?.cancel(); } catch { /* Reader has already released/closed the response. */ }
        abort.abort();
      }
    }
  }
  private async readJsonBody(response: Response, signal: AbortSignal): Promise<string> {
    const reader = response.body?.getReader();
    if (!reader) return "";
    const decoder = new TextDecoder("utf-8", { fatal: true });
    let size = 0;
    const parts: string[] = [];
    try {
      while (true) {
        const part = await reader.read();
        signal.throwIfAborted();
        if (part.done) break;
        size += part.value.byteLength;
        if (size > this.#maxBytes) throw new PortalProtocolError("JSON response exceeds configured limit.");
        try { parts.push(decoder.decode(part.value, { stream: true })); }
        catch { throw new PortalProtocolError("Invalid response UTF-8."); }
      }
      try { parts.push(decoder.decode()); } catch { throw new PortalProtocolError("Invalid response UTF-8."); }
      return parts.join("");
    } finally { try { await reader.cancel(); } finally { reader.releaseLock(); } }
  }
}

function validToken(value: unknown): value is string { return typeof value === "string" && /^[\x21-\x7e]+$/.test(value); }
