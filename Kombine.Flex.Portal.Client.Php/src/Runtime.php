<?php
declare(strict_types=1);

namespace Kombine\Flex\Portal;

/** Transport and serialization only. Authorization and business rules belong to the API. */
abstract class BaseClient
{
    private ?string $token = null;
    private bool $closed = false;
    private array $contract;

    public function __construct(
        private readonly string $baseUrl,
        private readonly float $timeout = 30.0,
        private readonly int $maxJsonBytes = 16777216,
        private readonly int $maxDownloadBytes = 1073741824,
    ) {
        if (PHP_INT_SIZE !== 8 || !extension_loaded('curl')) {
            throw new \LogicException('The client requires 64-bit PHP and ext-curl.');
        }
        $url = parse_url($baseUrl);
        $local = is_array($url) && ($url['scheme'] ?? '') === 'http'
            && in_array($url['host'] ?? '', ['localhost', '127.0.0.1', '[::1]'], true);
        if (!$url || !isset($url['host']) || (($url['scheme'] ?? '') !== 'https' && !$local)
            || isset($url['user']) || isset($url['pass']) || isset($url['query']) || isset($url['fragment'])
            || preg_match('/[\x00-\x20\x7f\\\\?#]/', $baseUrl) || !str_ends_with($baseUrl, '/')
            || !filter_var($baseUrl, FILTER_VALIDATE_URL)) {
            throw new \InvalidArgumentException('Use an HTTPS API URL ending in / without credentials, query or fragment; HTTP is allowed only on loopback.');
        }
        if (!is_finite($timeout) || $timeout <= 0 || $timeout > 86400 || $maxJsonBytes < 1 || $maxDownloadBytes < 1) {
            throw new \InvalidArgumentException('Invalid timeout or response limits.');
        }
        $this->contract = json_decode(file_get_contents(__DIR__ . '/contract.json'), true, 64, JSON_THROW_ON_ERROR);
    }

    public function getBaseUrl(): string { return $this->baseUrl; }
    public function getAccessToken(): ?string { return $this->token; }

    public function setAccessToken(#[\SensitiveParameter] ?string $token): void
    {
        $this->ensureOpen();
        if ($token !== null && !self::validToken($token)) throw new \InvalidArgumentException('Invalid bearer token.');
        $this->token = $token;
    }

    /** Local logout only; existing token copies retain their server expiry. */
    public function clearSession(): void { $this->token = null; }
    public function close(): void { $this->clearSession(); $this->closed = true; }

    /** Prevent accidental credential exposure through debug output or serialization. */
    public function __debugInfo(): array { return ['client' => static::class, 'closed' => $this->closed]; }
    public function __serialize(): array { throw new \LogicException('Clients cannot be serialized.'); }

    protected function signIn(string $operation, #[\SensitiveParameter] array $body): array
    {
        $this->ensureOpen();
        $this->clearSession();
        $response = $this->request($operation, [], $body);
        $this->retainSession($response);
        return $response;
    }

    protected function renewSession(string $operation): array
    {
        $response = $this->request($operation, []);
        // A malformed response must never extend the locally held session.
        try { $this->retainSession($response); }
        catch (ProtocolException $error) { $this->clearSession(); throw $error; }
        return $response;
    }

    private function retainSession(mixed $response): void
    {
        if (!is_array($response) || !self::validToken($response['accessToken'] ?? null)
            || !is_string($response['tokenType'] ?? null) || strcasecmp($response['tokenType'], 'Bearer') !== 0
            || !is_int($response['expiresIn'] ?? null) || $response['expiresIn'] <= 0) {
            throw new ProtocolException('Incomplete login/session response.');
        }
        $this->token = $response['accessToken'];
    }

    private static function validToken(mixed $value): bool
    {
        return is_string($value) && preg_match('/\A[A-Za-z0-9._~+\/-]+=*\z/D', $value) === 1;
    }

    private function ensureOpen(): void
    {
        if ($this->closed) throw new \LogicException('Client closed.');
    }

    /** @param resource|null $destination Caller-owned writable stream for binary operations. */
    protected function request(string $operation, #[\SensitiveParameter] array $parameters, #[\SensitiveParameter] ?array $body = null, mixed $destination = null): mixed
    {
        $this->ensureOpen();
        $spec = $this->contract['operations'][$operation];
        if ($spec['auth'] && $this->token === null) throw new \LogicException('Sign in or set a bearer token first.');
        if ($spec['binary'] && (!is_resource($destination) || get_resource_type($destination) !== 'stream')) {
            throw new \InvalidArgumentException('A writable destination stream is required.');
        }
        if ($spec['binary'] && !preg_match('/[waxc+]/', stream_get_meta_data($destination)['mode'])) {
            throw new \InvalidArgumentException('The destination stream is not writable.');
        }
        $path = $spec['path'];
        $query = [];
        $headers = ['Accept: ' . ($spec['binary'] ? '*/*' : 'application/json'), 'Expect:'];
        $allowed = array_column($spec['parameters'], 'name');
        if (array_diff(array_keys($parameters), $allowed)) throw new \InvalidArgumentException('Unknown operation parameter.');
        foreach ($spec['parameters'] as $parameter) {
            $name = $parameter['name'];
            $value = $parameters[$name] ?? null;
            if ($value === null) {
                if ($parameter['required']) throw new \InvalidArgumentException('Missing required operation parameter.');
                continue;
            }
            $value = $this->shape($value, $parameter['schema'], true);
            $scalar = static fn($v): string => is_bool($v) ? ($v ? 'true' : 'false') : (string)$v;
            if ($parameter['where'] === 'path') {
                $encoded = rawurlencode($scalar($value));
                if ($encoded === '' || $encoded === '.' || $encoded === '..') throw new \InvalidArgumentException('Invalid path value.');
                $path = str_replace('{' . $name . '}', $encoded, $path);
            } elseif ($parameter['where'] === 'header') {
                $text = $scalar($value);
                if (preg_match('/[\x00-\x1f\x7f]/', $text)) throw new \InvalidArgumentException('Invalid header value.');
                $headers[] = $name . ': ' . $text;
            } else {
                foreach (is_array($value) ? $value : [$value] as $item) $query[] = rawurlencode($name) . '=' . rawurlencode($scalar($item));
            }
        }
        $json = null;
        if ($spec['body'] !== null) {
            if ($body === null) throw new \InvalidArgumentException('A JSON request object is required.');
            try { $json = json_encode($this->shape($body, $spec['body'], true), JSON_THROW_ON_ERROR | JSON_PRESERVE_ZERO_FRACTION, 64); }
            catch (\JsonException) { throw new \InvalidArgumentException('Invalid request JSON.'); }
            if (strlen($json) > $this->maxJsonBytes) throw new \InvalidArgumentException('Request JSON exceeds the configured limit.');
            $headers[] = 'Content-Type: application/json';
        }
        if ($spec['auth']) $headers[] = 'Authorization: Bearer ' . $this->token;
        $handle = curl_init($this->baseUrl . $path . ($query ? '?' . implode('&', $query) : ''));
        if ($handle === false) throw new TransportException('Cannot initialize HTTP transport.');
        $status = 0; $responseHeaders = []; $headerBytes = 0; $payload = ''; $bytes = 0; $failure = null;
        try {
            curl_setopt_array($handle, [
                CURLOPT_CUSTOMREQUEST => $spec['method'], CURLOPT_HTTPHEADER => $headers,
                CURLOPT_FOLLOWLOCATION => false, CURLOPT_MAXREDIRS => 0,
                CURLOPT_PROTOCOLS => CURLPROTO_HTTP | CURLPROTO_HTTPS,
                CURLOPT_SSL_VERIFYPEER => true, CURLOPT_SSL_VERIFYHOST => 2,
                CURLOPT_TIMEOUT_MS => max(1, (int)ceil($this->timeout * 1000)),
                CURLOPT_CONNECTTIMEOUT_MS => max(1, (int)ceil(min($this->timeout, 10) * 1000)),
                CURLOPT_NOSIGNAL => true,
                CURLOPT_HEADERFUNCTION => function ($curl, string $line) use (&$status, &$responseHeaders, &$headerBytes, &$failure, $spec): int {
                    $length = strlen($line); $headerBytes += $length;
                    if ($headerBytes > 65536) { $failure = 'Response headers exceed the limit.'; return 0; }
                    if (preg_match('/^HTTP\/\S+\s+(\d{3})/', $line, $match)) { $status = (int)$match[1]; $responseHeaders = []; }
                    elseif (str_contains($line, ':')) {
                        [$name, $value] = explode(':', $line, 2);
                        $responseHeaders[strtolower(trim($name))] = trim($value);
                    }
                    if ($line === "\r\n" && $status === 401 && $spec['auth']) $this->clearSession();
                    return $length;
                },
                CURLOPT_WRITEFUNCTION => function ($curl, string $chunk) use (&$status, &$payload, &$bytes, &$failure, $spec, $destination): int {
                    $length = strlen($chunk); $bytes += $length;
                    $download = $spec['binary'] && in_array($status, $spec['statuses'], true);
                    if ($bytes > ($download ? $this->maxDownloadBytes : $this->maxJsonBytes)) {
                        $failure = 'Response exceeds the configured limit.'; return 0;
                    }
                    if (!$download) $payload .= $chunk;
                    else {
                        $offset = 0;
                        while ($offset < $length) {
                            $written = @fwrite($destination, substr($chunk, $offset));
                            if ($written === false || $written === 0) { $failure = 'Cannot write the download stream.'; return 0; }
                            $offset += $written;
                        }
                    }
                    return $length;
                },
            ]);
            if ($json !== null) curl_setopt($handle, CURLOPT_POSTFIELDS, $json);
            $ok = curl_exec($handle);
            if ($failure !== null) throw new ProtocolException($failure);
            if ($ok === false) throw new TransportException('HTTP transport failed (cURL ' . curl_errno($handle) . ').');
        } finally {
            // Dropping the handle works on PHP 8.2+ (curl_close is deprecated in 8.5).
            unset($handle);
        }
        if (!in_array($status, $spec['statuses'], true)) {
            $code = null;
            try { $error = json_decode($payload, true, 64, JSON_THROW_ON_ERROR); $code = is_array($error) && is_string($error['code'] ?? null) ? $error['code'] : null; }
            catch (\JsonException) { }
            throw new ApiException($status, $code, $responseHeaders);
        }
        if ($spec['binary']) return new DownloadResponse($status, $responseHeaders, $bytes);
        if ($spec['response'] === null || $status === 204) return null;
        try {
            $value = json_decode(str_starts_with($payload, "\xEF\xBB\xBF") ? substr($payload, 3) : $payload,
                false, 64, JSON_THROW_ON_ERROR | JSON_BIGINT_AS_STRING);
        } catch (\JsonException) { throw new ProtocolException('The API returned invalid JSON.'); }
        $this->shape($value, $spec['response'], false);
        return self::toArrays($value);
    }

    private static function toArrays(mixed $value): mixed
    {
        if ($value instanceof \stdClass) $value = get_object_vars($value);
        if (is_array($value)) return array_map(self::toArrays(...), $value);
        return $value;
    }

    private function shape(#[\SensitiveParameter] mixed $value, array $schema, bool $request, int $depth = 0): mixed
    {
        $fail = static function () use ($request): never {
            if ($request) throw new \InvalidArgumentException('Request value does not match the API contract.');
            throw new ProtocolException('Response value does not match the API contract.');
        };
        if ($depth > 64) $fail();
        if (isset($schema['$ref'])) $schema = $this->contract['schemas'][basename($schema['$ref'])];
        if ($value === null) {
            // Reference fields can be null in current ASP.NET DTOs even without OpenAPI nullable.
            if (($schema['nullable'] ?? false) || in_array($schema['type'] ?? '', ['object', 'array'], true)) return null;
            $fail();
        }
        $type = $schema['type'] ?? null;
        if ($type === 'integer') {
            if (!is_int($value) || (($schema['format'] ?? '') !== 'int64' && ($value < -2147483648 || $value > 2147483647))) $fail();
        } elseif ($type === 'number') {
            if ((!is_int($value) && !is_float($value)) || !is_finite((float)$value)) $fail();
        } elseif ($type === 'string') { if (!is_string($value)) $fail(); }
        elseif ($type === 'boolean') { if (!is_bool($value)) $fail(); }
        elseif ($type === 'array') {
            if (!is_array($value) || !array_is_list($value)) $fail();
            return array_map(fn($item) => $this->shape($item, $schema['items'], $request, $depth + 1), $value);
        } elseif ($type === 'object') {
            if ($request) {
                if (!is_array($value) && !$value instanceof \stdClass) $fail();
                if (is_array($value) && $value !== [] && array_is_list($value)) $fail();
                $value = (object)$value;
            } elseif (!$value instanceof \stdClass) $fail();
            foreach ($schema['required'] ?? [] as $required) if (!property_exists($value, $required)) $fail();
            $result = new \stdClass();
            foreach (get_object_vars($value) as $key => $child) {
                $field = $schema['properties'][$key] ?? $schema['additionalProperties'] ?? null;
                if ($request && $field === false) $fail();
                $result->$key = is_array($field) ? $this->shape($child, $field, $request, $depth + 1) : $child;
            }
            return $result;
        }
        return $value;
    }
}

final class ProtocolException extends \RuntimeException { }
final class TransportException extends \RuntimeException { }
final class ApiException extends \RuntimeException
{
    public function __construct(public readonly int $status, public readonly ?string $apiCode, public readonly array $headers)
    {
        parent::__construct('API request failed (HTTP ' . $status . ').');
    }
}
final class DownloadResponse
{
    public function __construct(public readonly int $status, public readonly array $headers, public readonly int $bytes) { }
}
