## 0.4.0

Version 0.4.0 synchronizes personal language, date/time, number and line-spacing preferences. WashDoc widgets replace unitKidText with documentKidText; graphSvg may be null when no measurements exist. Treat refreshAfterSeconds=0 as stop polling; running documents use 15 seconds. Manager sessions last ten days: use the returned expiresIn and renew only after activity. UserBalance remains compatible. See the [API changelog](/docs#changelog).

## 0.3.0

Breaking: More1 time/KID methods no longer accept bankKid and use tenant routes. Adds GetUnitDocumentNeighbors.

## 0.3.0 — 2026-10-25

- Add scoped WashDoc list/count operations.
- No registry publication.

## 0.2.1

- Refresh the reviewed API contract and generated operations for beta preparation on 2026-10-23.
- No registry publication.

# Changelog

## 0.1.0 — 2026-10-20

Initial Dart/Flutter source client: 155 operations from the bundled Portal contract,
bearer sessions, lossless int64 values, streaming, multipart, cancellation and deadlines.
Not deployed or published to pub.dev. See the API contract changelog at `/docs#changelog`.
