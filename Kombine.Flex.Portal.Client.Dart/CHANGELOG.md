## 0.9.0

Version 0.9.0 covers 202 operations, including GetUnitTimeline and GetUnitTimelineFields. Wallboard responses identify the exact approved display; screen sessions expose minimal identity without ordinary manager permissions. Use a normal manager login for Portal operations. Permanent device approval and UserBalance remain compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog).

## 0.8.0

Version 0.8.0 adds FindWallboardPairings and GetWallboardDevice (200 operations total), plus optional location metadata when approving a screen. Central Wallboard setup uses one QR scan; private location is available only to the approving manager through the device endpoint. Device approval has no automatic expiry and still checks revocation, manager credentials and tenant/environment binding. Existing UserBalance clients remain compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog) and [Wallboard guide](https://api.team.kombine.technology/docs#wallboard-pairing).

## 0.7.0

Version 0.7.0 adds seven Wallboard pairing/device operations (198 operations total). An active manager approves a screen once; its device approval has no automatic expiry. Keep the non-exportable ECDSA P-256 private key on the screen, sign one-use challenges to reconnect, and keep manager credentials and bearer tokens out of URLs and browser storage. Explicit revocation and manager credential/account checks remain enforced. Ten-day bearer sessions do not limit device approval. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog) and [Wallboard guide](https://api.team.kombine.technology/docs#wallboard-pairing).

## 0.6.0

Version 0.6.0 adds the read-only settlement checklist, machine error history and acknowledgement, out-of-service listing and restore, and authorized eVaskeri resident delegation. Resident search includes bankKid. All operations retain manager, tenant and resource authorization. eVaskeri links are sensitive bearer credentials: open immediately without opener/referrer and never log or persist them. Never replay mutation requests automatically after an uncertain response. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog).

## 0.5.0

Version 0.5.0 uses GetPublicCycleWidget and GetCycleChartPresentation. Replace the retired WashDoc widget/presentation routes with /api/v1/public/widgets/cycle and /api/v1/public/cycle-chart/presentation. Document path parameters and table/graph/widget fields use cycleKid; the widget display field is cycleKidText. Existing KID values and document operation IDs remain valid. Rebuild callers and update property bindings. UserBalance remains compatible. See the [API changelog](https://api.team.kombine.technology/docs#changelog).

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
