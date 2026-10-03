<?php
declare(strict_types=1);

require $argv[1] . '/autoload.php';
$api = $argv[2];
$base = $argv[3];
$fixtures = json_decode(file_get_contents($argv[4]), true, 64, JSON_THROW_ON_ERROR);
$class = 'Kombine\\Flex\\' . $api . '\\' . $api . 'Client';
$namespace = 'Kombine\\Flex\\' . $api . '\\';
$checks = 0;
function check(bool $value, string $message): void {
    global $checks;
    if (!$value) throw new RuntimeException($message);
    $checks++;
}
function raises(string $type, callable $action): Throwable {
    try { $action(); } catch (Throwable $error) {
        check($error instanceof $type, 'Unexpected exception: ' . get_class($error) . ': ' . $error->getMessage());
        return $error;
    }
    throw new RuntimeException('Expected ' . $type);
}
$statusMethod = $api === 'Portal' ? 'getCurrentManager' : 'getEquipmentStatus';
$login = fn($client) => $api === 'Portal' ? $client->login('test@example.invalid', 'synthetic-password') : $client->login('synthetic-kid', 'synthetic-key');
foreach ($fixtures as $i => $case) {
    $client = new $class($base . 'matrix/' . $i . '/');
    $client->setAccessToken('synthetic-token');
    $args = $case['args'];
    if ($case['binary']) {
        $stream = fopen('php://temp', 'w+b');
        array_splice($args, $case['sinkIndex'], 0, [$stream]);
    }
    $result = $client->{$case['method']}(...$args);
    if ($case['binary']) {
        check($result->bytes === strlen($case['response']), 'Download byte count ' . $case['method']);
        rewind($stream);
        check(stream_get_contents($stream) === $case['response'], 'Download contents ' . $case['method']);
        check(is_resource($stream), 'The client must leave the stream open');
        fclose($stream);
    } else check($result === $case['response'], 'Response model ' . $case['method']);
    check($client->getAccessToken() === 'synthetic-token', 'Raw operations do not replace the session');
}

foreach (['http://example.com/', 'https://user:pass@example.com/', 'https://example.com/?', 'https://example.com/#',
          'https://example.com', "https://example.com/\n", 'https://example.com\\@evil.invalid/'] as $bad) {
    raises(InvalidArgumentException::class, fn() => new $class($bad));
}
raises(InvalidArgumentException::class, fn() => new $class($base, timeout: NAN));
raises(InvalidArgumentException::class, fn() => new $class($base, maxJsonBytes: 0));
$client = new $class($base . 'login/');
raises(LogicException::class, fn() => $client->$statusMethod());
raises(InvalidArgumentException::class, fn() => $client->setAccessToken("token\r\nX-Bad: yes"));
$session = $login($client);
check($session['accessToken'] === 'retained-token' && $client->getAccessToken() === 'retained-token', 'Retained login');
check($client->getBaseUrl() === $base . 'login/', 'Fixed base URL');
ob_start(); var_dump($client); $debug = ob_get_clean();
check(!str_contains($debug, 'retained-token'), 'No token in debug output');
raises(LogicException::class, fn() => serialize($client));
if ($api === 'Portal') {
    $client->renew();
    check($client->getAccessToken() === 'renewed-token', 'Renew replaces the token');
    $anonymous = new $class($base . 'anonymous/');
    $anonymous->setAccessToken('must-not-be-sent');
    check($anonymous->getPortalStatus() === [], 'Anonymous operation omits bearer');
}
$client->clearSession();
check($client->getAccessToken() === null, 'Local logout');
$client->close();
raises(LogicException::class, fn() => $login($client));
raises(LogicException::class, fn() => $client->setAccessToken('token'));

foreach (['bad-login', 'malformed', 'oversized', 'fractional', 'overflow', 'wrong-shape'] as $mode) {
    $client = new $class($base . $mode . '/', maxJsonBytes: 256);
    $client->setAccessToken('old-token');
    raises($namespace . 'ProtocolException', fn() => $login($client));
    check($client->getAccessToken() === null, 'Failed login clears the old token: ' . $mode);
}
foreach ([401, 403, 429, 503, 302] as $status) {
    $client = new $class($base . 'error-' . $status . '/');
    $client->setAccessToken('old-token');
    $error = raises($namespace . 'ApiException', fn() => $client->$statusMethod());
    check($error->status === $status && $error->apiCode === 'synthetic-error', 'HTTP error details');
    check(($error->headers['retry-after'] ?? '') === '60', 'Retry-After retained');
    check(!str_contains($error->getMessage(), 'secret-body'), 'Exception message excludes response body');
    check($client->getAccessToken() === ($status === 401 ? null : 'old-token'), 'Only 401 clears session');
}
$client = new $class($base . 'unauthorized-oversized/', maxJsonBytes: 256);
$client->setAccessToken('old-token');
raises($namespace . 'ProtocolException', fn() => $client->$statusMethod());
check($client->getAccessToken() === null, '401 clears session even with an oversized error body');
foreach (['slow-headers', 'slow-body'] as $mode) {
    $client = new $class($base . $mode . '/', timeout: 0.15);
    $client->setAccessToken('token');
    $started = microtime(true);
    raises($namespace . 'TransportException', fn() => $client->$statusMethod());
    check(microtime(true) - $started < 1.5, 'Total request deadline');
}

if ($api === 'Portal') {
    $client = new $class($base . 'balances/'); $client->setAccessToken('token');
    $balances = $client->getBankUserBalances('test-bank', ['userKids' => ['a', 'b', 'c']]);
    check($balances['items'][0]['currentBalanceMinor'] === PHP_INT_MAX, 'Int64 maximum');
    check($balances['items'][1]['currentBalanceMinor'] === PHP_INT_MIN, 'Int64 minimum');
    check($balances['items'][2]['currentBalanceMinor'] === null, 'Null balance remains null');
    check(!array_key_exists('currentBalanceMinor', $balances['items'][3]), 'Absent balance remains absent');
    raises(InvalidArgumentException::class, fn() => $client->getBankUsers('bank', ['unexpected' => 1]));
    raises(InvalidArgumentException::class, fn() => $client->getBankUsers('..'));
    raises(InvalidArgumentException::class, fn() => $client->getBankUsers('bank', ['pageSize' => 1.5]));
    $stream = fopen('php://temp', 'w+b');
    $client = new $class($base . 'large-download/'); $client->setAccessToken('token');
    $download = $client->exportBankUsers('bank', $stream);
    check($download->bytes === 2097152, 'Large streamed download'); fclose($stream);
    $stream = fopen('php://temp', 'w+b');
    $client = new $class($base . 'large-download/', maxDownloadBytes: 1024); $client->setAccessToken('token');
    raises($namespace . 'ProtocolException', fn() => $client->exportBankUsers('bank', $stream)); fclose($stream);
    $stream = fopen('php://temp', 'w+b');
    $client = new $class($base . 'error-403/'); $client->setAccessToken('token');
    raises($namespace . 'ApiException', fn() => $client->exportBankUsers('bank', $stream));
    check(ftell($stream) === 0, 'Error body never written into download'); fclose($stream);
} else {
    $client = new $class($base . 'sync/'); $client->setAccessToken('token');
    raises(InvalidArgumentException::class, fn() => $client->syncEquipment('kid', 1.5, []));
    raises(InvalidArgumentException::class, fn() => $client->syncEquipment('kid', 1, ['SyncKrumbData' => [['MS2000' => 9.22e18]]]));
    raises(InvalidArgumentException::class, fn() => $client->syncEquipment('kid', 1, ['SyncKrumbData' => [['MS2000' => '9223372036854775807']]]));
}
echo $api . ': ' . $checks . " PHP checks passed.\n";
