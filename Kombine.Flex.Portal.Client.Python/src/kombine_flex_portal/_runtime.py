"""HTTP/JSON mechanics only. Authorization and business rules stay in the API."""
from __future__ import annotations

import json
import math
import ssl
import threading
from importlib.resources import files
from types import MappingProxyType
from typing import Any, Iterator, TYPE_CHECKING
from urllib.error import HTTPError
from urllib.parse import quote, urlencode, urlsplit
from urllib.request import Request, build_opener, HTTPRedirectHandler, HTTPSHandler

if TYPE_CHECKING:
    from .models import ManagerSessionResponse

_CONTRACT = json.loads(files(__package__).joinpath('_contract.json').read_text(encoding='utf-8'))


class PortalProtocolError(ValueError):
    """Invalid/oversized API payload; the body is excluded from the exception text."""


class PortalSessionError(RuntimeError):
    """Client closed or session changed during login."""


class PortalApiError(Exception):
    """An HTTP response with status, optional API code and response headers."""
    def __init__(self, status: int, response: str, headers: dict[str, str]):
        super().__init__(f'Portal API request failed (HTTP {status}).')
        self.status = status
        self.response = response  # Sensitive: do not log without review.
        self.headers = MappingProxyType(headers)
        self.code: str | None = None
        try:
            data = _parse(response)
            if isinstance(data, dict) and isinstance(data.get('code'), str):
                self.code = data['code']
        except PortalProtocolError:
            pass


class _NoRedirect(HTTPRedirectHandler):
    def redirect_request(self, req, fp, code, msg, headers, newurl):
        return None


def _pairs(pairs):
    result = {}
    for key, value in pairs:
        if key in result:
            raise PortalProtocolError('Duplicate JSON field.')
        result[key] = value
    return result


def _constant(value):
    raise PortalProtocolError('Non-finite JSON number.')


def _validate_tree(value: Any, depth: int = 0) -> None:
    if depth > 64:
        raise PortalProtocolError('JSON nesting limit exceeded.')
    if isinstance(value, str):
        value.encode('utf-8', errors='strict')
    elif isinstance(value, float) and not math.isfinite(value):
        raise PortalProtocolError('Non-finite JSON number.')
    elif isinstance(value, dict):
        for key, child in value.items():
            if not isinstance(key, str):
                raise PortalProtocolError('JSON keys must be strings.')
            _validate_tree(key, depth + 1)
            _validate_tree(child, depth + 1)
    elif isinstance(value, (list, tuple)):
        for child in value:
            _validate_tree(child, depth + 1)


def _parse(text: str) -> Any:
    try:
        data = json.loads(text.lstrip('\ufeff'), object_pairs_hook=_pairs, parse_constant=_constant)
        _validate_tree(data)
        return data
    except (ValueError, UnicodeError, RecursionError) as error:
        raise PortalProtocolError('The API returned invalid JSON.') from None


def _check_shape(value: Any, spec: dict) -> Any:
    if value is None:  # Nullable DTO/reference fields remain null, never fabricated zeroes.
        return None
    if '$ref' in spec:
        spec = _CONTRACT['schemas'][spec['$ref'].split('/')[-1]]
    kind = spec.get('type')
    if kind == 'integer':
        bits = 64 if spec.get('format') == 'int64' else 32
        if type(value) is not int or not -(1 << (bits - 1)) <= value < (1 << (bits - 1)):
            raise PortalProtocolError('Invalid API integer.')
    elif kind == 'number':
        if type(value) not in (int, float):
            raise PortalProtocolError('Invalid API number.')
    elif kind == 'string' and not isinstance(value, str):
        raise PortalProtocolError('Invalid API string.')
    elif kind == 'boolean' and type(value) is not bool:
        raise PortalProtocolError('Invalid API boolean.')
    elif kind == 'array':
        if not isinstance(value, list):
            raise PortalProtocolError('Invalid API array.')
        for item in value:
            _check_shape(item, spec['items'])
    elif kind == 'object':
        if not isinstance(value, dict):
            raise PortalProtocolError('Invalid API object.')
        for key, item in value.items():
            field = spec.get('properties', {}).get(key, spec.get('additionalProperties'))
            if isinstance(field, dict):
                _check_shape(item, field)
    return value


class PortalDownload:
    """Streaming response. Use as a context manager and consume iter_bytes()."""
    def __init__(self, response, status: int, headers: dict[str, str]):
        self._response = response
        self.status = status
        self.headers = MappingProxyType(headers)
        self._closed = False

    def iter_bytes(self, chunk_size: int = 65536) -> Iterator[bytes]:
        if type(chunk_size) is not int or chunk_size <= 0:
            raise ValueError('chunk_size must be positive.')
        if self._closed:
            raise ValueError('Download closed.')
        try:
            while True:
                chunk = self._response.read(chunk_size)
                if not chunk:
                    break
                yield chunk
        finally:
            self.close()

    def close(self) -> None:
        if not self._closed:
            self._closed = True
            self._response.close()

    def __enter__(self):
        return self

    def __exit__(self, *args):
        self.close()


class BaseClient:
    def __init__(self, api_base_url: str, *, timeout: float = 30, max_json_bytes: int = 16 * 1024 * 1024):
        """One tenant and user per instance. timeout is socket I/O timeout in seconds."""
        if not isinstance(api_base_url, str) or any(ord(c) < 33 or ord(c) == 127 for c in api_base_url):
            raise ValueError('Use an absolute HTTPS API URL ending in /.')
        try:
            address = urlsplit(api_base_url)
            port = address.port  # Validate the port before any I/O.
        except ValueError:
            raise ValueError('Invalid API URL.') from None
        local = address.scheme == 'http' and address.hostname in ('localhost', '127.0.0.1', '::1')
        if (address.scheme != 'https' and not local) or not address.hostname or address.username is not None or address.password is not None or address.query or address.fragment or '?' in api_base_url or '#' in api_base_url or not api_base_url.endswith('/') or '\\' in api_base_url:
            raise ValueError('Use an absolute HTTPS API URL ending in /, without credentials, query or fragment.')
        if not isinstance(timeout, (int, float)) or not math.isfinite(timeout) or timeout <= 0:
            raise ValueError('timeout must be positive and finite.')
        if type(max_json_bytes) is not int or max_json_bytes <= 0:
            raise ValueError('max_json_bytes must be positive.')
        self._base_url = api_base_url
        self._timeout = timeout
        self._max_json_bytes = max_json_bytes
        self._token: str | None = None
        self._version = 0
        self._lock = threading.RLock()
        self._closed = False
        self._opener = build_opener(_NoRedirect(), HTTPSHandler(context=ssl.create_default_context()))

    @property
    def base_url(self) -> str:
        return self._base_url

    @property
    def access_token(self) -> str | None:
        with self._lock:
            return self._token

    @access_token.setter
    def access_token(self, value: str | None) -> None:
        if value is not None and not self._valid_token(value):
            raise ValueError('Invalid bearer token.')
        with self._lock:
            self._ensure_open()
            self._version += 1
            self._token = value

    @staticmethod
    def _valid_token(value) -> bool:
        return isinstance(value, str) and bool(value) and all(33 <= ord(c) <= 126 for c in value)

    def _ensure_open(self):
        if self._closed:
            raise PortalSessionError('Client closed.')

    def clear_session(self) -> None:
        """Local logout only; token copies retain their server expiry."""
        with self._lock:
            self._version += 1
            self._token = None

    def login(self, email: str, password: str) -> ManagerSessionResponse:
        """LoginManager plus in-memory session retention. Password is not retained."""
        if not isinstance(email, str) or not email.strip() or not isinstance(password, str) or not password:
            raise ValueError('Email and password are required.')
        with self._lock:
            self._ensure_open()
            self.clear_session()
            version = self._version
        response = self._request('LoginManager', {}, {'email': email, 'password': password})
        if not self._valid_token(response.get('accessToken')) or str(response.get('tokenType', '')).lower() != 'bearer' or type(response.get('expiresIn')) is not int or response['expiresIn'] <= 0:
            raise PortalProtocolError('Incomplete login response.')
        with self._lock:
            if self._closed or version != self._version:
                raise PortalSessionError('The session changed during login.')
            self._token = response['accessToken']
        return response

    def close(self) -> None:
        """Clear token and stop new calls; already-started calls/downloads are not cancelled."""
        with self._lock:
            self.clear_session()
            self._closed = True

    def __enter__(self):
        self._ensure_open()
        return self

    def __exit__(self, *args):
        self.close()

    def _request(self, operation: str, values: dict, body: Any) -> Any:
        spec = _CONTRACT['operations'][operation]
        with self._lock:
            self._ensure_open()
            token = self._token if spec['auth'] else None
            version = self._version
        path = spec['path']
        query = []
        headers = {'Accept': 'application/json, application/zip, text/csv', 'Cache-Control': 'no-store'}
        if token:
            headers['Authorization'] = 'Bearer ' + token
        for param in spec['parameters']:
            value = values.get(param['name'])
            if value is None and param['where'] != 'path':
                continue
            _check_shape(value, param['schema'])
            text = ('true' if value else 'false') if isinstance(value, bool) else str(value)
            if param['where'] == 'path':
                if value is None or text in ('', '.', '..'):
                    raise ValueError('A route identifier is required.')
                path = path.replace('{' + param['name'] + '}', quote(text, safe=''))
            elif param['where'] == 'query':
                query.append((param['name'], text))
            else:
                if any(ord(c) < 32 or ord(c) > 126 for c in text):
                    raise ValueError('Invalid header value.')
                headers[param['name']] = text
        data = None
        if spec['body'] is not None:
            if body is None:
                raise ValueError('A request body is required.')
            try:
                _validate_tree(body)
                _check_shape(body, spec['body'])
                data = json.dumps(body, ensure_ascii=False, allow_nan=False, separators=(',', ':')).encode('utf-8')
            except (ValueError, UnicodeError, RecursionError, TypeError):
                raise PortalProtocolError('Invalid request JSON.') from None
            if len(data) > self._max_json_bytes:
                raise PortalProtocolError('JSON request exceeds configured limit.')
            headers['Content-Type'] = 'application/json; charset=utf-8'
        elif spec['method'] == 'POST':
            data = b''
        url = self._base_url + path + ('?' + urlencode(query, quote_via=quote) if query else '')
        request = Request(url, data=data, headers=headers, method=spec['method'])
        try:
            response = self._opener.open(request, timeout=self._timeout)
        except HTTPError as error:
            response = error
        status = response.code
        response_headers = {k.lower(): v for k, v in response.headers.items()}
        if status == 401 and token:
            with self._lock:
                if self._version == version and self._token == token:
                    self.clear_session()
        if spec['binary'] and status == spec['status']:
            return PortalDownload(response, status, response_headers)
        try:
            chunks = []
            remaining = self._max_json_bytes + 1
            while remaining:
                chunk = response.read(min(remaining, 65536))
                if not chunk:
                    break
                chunks.append(chunk)
                remaining -= len(chunk)
            payload = b''.join(chunks)
            if len(payload) > self._max_json_bytes:
                raise PortalProtocolError('JSON response exceeds configured limit.')
            if status != spec['status']:
                raise PortalApiError(status, payload.decode('utf-8', errors='replace'), response_headers)
            try:
                result = _parse(payload.decode('utf-8-sig', errors='strict'))
            except UnicodeError:
                raise PortalProtocolError('Invalid response UTF-8.') from None
            if result is None:
                raise PortalProtocolError('Missing response data.')
            return _check_shape(result, spec['response'])
        finally:
            response.close()
