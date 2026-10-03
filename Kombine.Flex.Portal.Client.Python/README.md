Version 0.3.1 synchronizes GetBankUserBalances documentation with its 20-second database deadline. Request and response fields are unchanged. Allow extra time for transport and authorization; HTTP 503 still returns no partial balances.

Version 0.2.5 adds optional latestPostingMs2000 and hasActiveSubscription fields to GetBankUserBalances. The posting time is a 64-bit UTC millisecond count since 2000-01-01; zero means no postings. Null or an absent field means unknown, and missing or hidden residents return null. Subscription status is not payment confirmation. Keep existing balance handling and permissions; see /docs#user-balances.

[English](README.md) · [Dansk](README.da.md) · [Español](README.es.md)

Version 0.2.5 adds `GetUserReceipts` and `GetHostingMetrics` for API releases that expose these operations. Load receipts on demand: request offset 0, then use `nextOffset` with the same `revision`. On HTTP 409 (`receipts-changed`), discard earlier pages and restart at offset 0. Keep currencies separate and amounts as signed 64-bit minor units. See [receipts](/docs#user-receipts) and [hosting metrics](/docs#hosting) for permissions and limits.

<!-- api-contract-changelog -->
[API contract changelog](https://api.team.kombine.technology/docs#changelog)

Use the same tenant and environment as your client: append /docs#changelog to its API base URL. The link above uses Team as the public example. This log covers potentially breaking request/response changes to existing endpoints, not internal functional fixes.
<!-- /api-contract-changelog -->

# Kombine Flex Portal — Python client

`kombine-flex-portal-client` supports **Python 3.11+** and all **110 public API operations**. No runtime packages, .NET, NuGet or other Kombine libraries are required. It uses only the Python standard library. Business rules and authorization remain in the API.

The package is **not yet published to PyPI**. Install the supplied local distribution:

```sh
python -m pip install ./kombine_flex_portal_client-0.3.1-py3-none-any.whl
```

Version 0.3.1 targets the current beta candidate (110 operations). Migrate response fields `icon`, `bankIcon` and `unitIcon` to `iconKid`, `bankIconKid` and `unitIconKid`. Use the explicit-set icon routes described in the [API changelog](/docs#changelog). The generated `RenewManagerSession` operation renews an unexpired manager session; assign its returned access token to the same client before further calls. There is no separate refresh token or automatic renewal. Windows application downloads return streams; these clients request complete files, without range or conditional headers.

Version 0.2.5 adds GetLocationOpeningHours and GetLocationBookingRules. Both require Location Read, Unit Read and the authorized location scope. Reservation rules contain plain text plus ordered parts with text/isValue for optional value emphasis; never render these strings as HTML. Keep text as the fallback for older responses. See /docs#location-opening-hours and /docs#location-booking-rules for permissions, examples and limits.

## Tenant, login and tabs

Select the tenant's HTTPS **API URL**, ending in `/`, before entering credentials. Obtain it from your administrator; for example https://api.team.kombine.technology/. Do not use the portal website. Use a separate client and login for each user, tenant and environment. Values in the following example come from your application input; never embed real passwords in source.

```python
from kombine_flex_portal import PortalClient, PortalApiError

with PortalClient(tenant_api_url, timeout=30) as api:
    try:
        api.login(email, password)
        manager = api.get_current_manager()
        for tab in manager.get("tabDetails") or []:
            print(tab.get("id"), tab.get("name"))
    except PortalApiError as error:
        print(error.status, error.code)
```

`login()` stores the bearer in memory. Raw `login_manager(body)` does not retain a session; an existing token can be assigned to `access_token`. Public operations never send it. No cookies or persistent token storage are used. `clear_session()`/`close()` remove the local token; HTTP 401 clears the affected session. The API has no separate refresh token or server-side token revocation. Passwords are not retained. Do not log tokens or complete payloads.

## Operations and data

Methods use operation IDs in snake_case; see [OPERATIONS.md](OPERATIONS.md). KIDs, cursors and revisions remain unchanged and case-sensitive. The client performs URL encoding and preserves wire query names such as Period and IncludeZero. Paging requires explicit calls; keep requesting until the cursor is absent. Balance batches accept up to 50 residents from one bank; use smaller batches on timeout. No automatic retries, hidden calls, extra privileges or automatic paging.

```python
page = api.get_bank_users(bank_kid, page_size=25, sort="number", direction="asc")
balances = api.get_bank_user_balances(bank_kid, {"userKids": user_kids})
account = api.get_bank_account(bank_kid, period=0, include_zero=False, limit=50)
units = api.get_location_units(location_kid, accept_language="en-GB")
with api.export_bank_users(bank_kid) as download:
    with open("residents.csv", "wb") as target:
        for chunk in download.iter_bytes():
            target.write(chunk)
```

Request and response models are TypedDict in `kombine_flex_portal.models`. JSON names such as userKids are unchanged. Unknown response fields are retained; null/missing is not zero. Dates are ISO strings and all integers, including int64 balances, use exact Python int.

Calls are synchronous. Use a worker thread in async/GUI applications. `timeout=30` is a socket I/O timeout, not a total deadline for a long stream. `close()` prevents new calls but does not cancel an existing request/download. Downloads must be closed with `with` and are streamed in chunks.

## Errors and transport

PortalApiError exposes status, code, headers (lowercase dictionary keys) and raw response. Response may contain personal data; the exception text only contains HTTP status. 400: correct input. 401: sign in. 403: denied account/Tab/KID/operation access. 404: unavailable in current scope. 409: reload the revision before editing. 429/503: respect Retry-After and retry later; never automatically repeat mutations whose outcome may be unknown. Network/cancellation errors use URLError/OSError/TimeoutError. Invalid or oversized JSON raises PortalProtocolError.

HTTPS retains normal platform certificate validation. HTTP is allowed only on loopback for tests; redirects are refused. JSON defaults to 16 MiB (max_json_bytes), nesting 64. Streaming downloads are not bounded by the JSON limit. Tabs do not grant unrestricted API access, and local numeric-ID developer login is excluded.

## Build and maintenance

```sh
python -m pip install -e . --no-deps
python -m unittest discover -s tests -v
```

Both script clients are generated from Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json with `python scripts/Generate-PortalScriptClients.py`; add `--check` to detect drift. The snapshot is a development input, not a runtime dependency. `scripts/Test-PortalScriptClients.ps1` tests both clients and builds wheel, sdist and npm tarball in artifacts/packages, using only local synthetic fixtures. Setuptools and wheel are development tools, not customer runtime dependencies. Nothing is published by these checks.

English is the primary documentation language; Danish and Spanish alternatives are included. Copyright Kombine Technology ApS.
