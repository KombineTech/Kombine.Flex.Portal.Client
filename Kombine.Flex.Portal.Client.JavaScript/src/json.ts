// Preserve JSON int64 exactly; native JSON.parse would round before a reviver runs.
export class PortalProtocolError extends Error {
  override name = "PortalProtocolError";
}

function validString(value: string): void {
  for (let i = 0; i < value.length; i++) {
    const c = value.charCodeAt(i);
    if (c >= 0xd800 && c <= 0xdbff) {
      const next = value.charCodeAt(++i);
      if (!(next >= 0xdc00 && next <= 0xdfff)) throw new PortalProtocolError("Invalid Unicode string.");
    } else if (c >= 0xdc00 && c <= 0xdfff) throw new PortalProtocolError("Invalid Unicode string.");
  }
}

export function parseJson(text: string): unknown {
  let at = text.charCodeAt(0) === 0xfeff ? 1 : 0;
  const fail = (): never => { throw new PortalProtocolError("The API returned invalid JSON."); };
  const space = () => { while (/[\x20\t\r\n]/.test(text[at] ?? "x")) at++; };
  const string = (): string => {
    const start = at++;
    while (at < text.length) {
      const c = text[at++];
      if (c === "\\") at++;
      else if (c === '"') {
        try {
          const value: string = JSON.parse(text.slice(start, at));
          validString(value);
          return value;
        } catch { return fail(); }
      }
    }
    return fail();
  };
  const value = (depth: number): unknown => {
    if (depth > 64) throw new PortalProtocolError("JSON nesting limit exceeded.");
    space();
    const c = text[at];
    if (c === '"') return string();
    if (c === "{" || c === "[") {
      at++;
      const object = c === "{";
      const end = object ? "}" : "]";
      const result: Record<string, unknown> | unknown[] = object ? Object.create(null) : [];
      space();
      if (text[at] === end) { at++; return result; }
      while (true) {
        space();
        if (object) {
          if (text[at] !== '"') return fail();
          const key = string();
          space();
          if (text[at++] !== ":" || Object.hasOwn(result, key)) return fail();
          (result as Record<string, unknown>)[key] = value(depth + 1);
        } else (result as unknown[]).push(value(depth + 1));
        space();
        if (text[at] === end) { at++; return result; }
        if (text[at++] !== ",") return fail();
      }
    }
    for (const [literal, decoded] of [["true", true], ["false", false], ["null", null]] as const) {
      if (text.startsWith(literal, at)) { at += literal.length; return decoded; }
    }
    const match = /^-?(?:0|[1-9]\d*)(?:\.\d+)?(?:[eE][+-]?\d+)?/.exec(text.slice(at));
    if (!match) return fail();
    at += match[0].length;
    if (!/[.eE]/.test(match[0])) return BigInt(match[0]);
    const n = Number(match[0]);
    return Number.isFinite(n) ? n : fail();
  };
  const result = value(0);
  space();
  if (at !== text.length) return fail();
  return result;
}

export function stringifyJson(value: unknown): string {
  const ancestors = new Set<object>();
  const encode = (v: unknown, depth: number): string => {
    if (depth > 64) throw new PortalProtocolError("JSON nesting limit exceeded.");
    if (v === null) return "null";
    if (typeof v === "string") { validString(v); return JSON.stringify(v); }
    if (typeof v === "bigint" || typeof v === "boolean") return String(v);
    if (typeof v === "number" && Number.isFinite(v) && (!Number.isInteger(v) || Number.isSafeInteger(v))) return String(v);
    if (typeof v !== "object") throw new PortalProtocolError("Invalid JSON value; use bigint for int64 values.");
    if (ancestors.has(v)) throw new PortalProtocolError("Circular JSON value.");
    if (!Array.isArray(v) && Object.getPrototypeOf(v) !== Object.prototype && Object.getPrototypeOf(v) !== null) throw new PortalProtocolError("Use plain JSON objects; dates must be ISO strings.");
    ancestors.add(v);
    try {
      if (Array.isArray(v)) return "[" + Array.from(v, item => encode(item, depth + 1)).join(",") + "]";
      return "{" + Object.entries(v).filter(([, item]) => item !== undefined).map(([key, item]) => {
        validString(key);
        return JSON.stringify(key) + ":" + encode(item, depth + 1);
      }).join(",") + "}";
    } finally { ancestors.delete(v); }
  };
  return encode(value, 0);
}
