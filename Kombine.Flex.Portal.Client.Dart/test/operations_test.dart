// Generated contract coverage.
import 'package:http/http.dart' as http;
import 'package:http/testing.dart';
import 'package:test/test.dart';
import 'package:kombine_flex_portal_client/kombine_flex_portal_client.dart';
void main() {
  test("wire GetBankAccountIcon", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/account/icon");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"currency": null, "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankAccountIcon(bankKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"currency": null, "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetBankAccount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/account");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["From"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["TimeZone"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Period"], <Object?>["7"]);
      expect(request.url.queryParametersAll["LocationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UserKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Kind"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["IncludeZero"], <Object?>["false"]);
      expect(request.url.queryParametersAll["IncludeBookings"], <Object?>["false"]);
      expect(request.url.queryParametersAll["IncludeMonthly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "units": null, "periods": null, "totals": null, "from": "2026-10-20", "through": "2026-10-20", "timeZone": null, "period": null, "offset": 7, "limit": 7, "hasMore": false, "revision": null, "documents": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankAccount(bankKid: "fixture /\u00e6?&", from: "2026-10-20", through: "2026-10-20", timeZone: "fixture", period: 7, locationKid: "fixture", unitKid: "fixture", userKid: "fixture", kind: "fixture", includeZero: false, includeBookings: false, includeMonthly: false, offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "units": null, "periods": null, "totals": null, "from": "2026-10-20", "through": "2026-10-20", "timeZone": null, "period": null, "offset": 7, "limit": 7, "hasMore": false, "revision": null, "documents": null}));
    expect(sends, 1);
  });

  test("wire GetBankAccountRevision", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/account/revision");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["From"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["TimeZone"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Period"], <Object?>["7"]);
      expect(request.url.queryParametersAll["LocationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UserKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Kind"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["IncludeZero"], <Object?>["false"]);
      expect(request.url.queryParametersAll["IncludeBookings"], <Object?>["false"]);
      expect(request.url.queryParametersAll["IncludeMonthly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"revision": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankAccountRevision(bankKid: "fixture /\u00e6?&", from: "2026-10-20", through: "2026-10-20", timeZone: "fixture", period: 7, locationKid: "fixture", unitKid: "fixture", userKid: "fixture", kind: "fixture", includeZero: false, includeBookings: false, includeMonthly: false, offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"revision": null}));
    expect(sends, 1);
  });

  test("wire ReverseBankAccountEntry", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/account/fixture%20%2F%C3%A6%3F%26/reversal");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "locationKid": null, "unitKid": null, "userKid": null, "recordedAtUtc": "2026-10-20T10:00:00Z", "amountMinor": BigInt.parse('9007199254740993'), "currency": null, "description": null, "transactionType": null, "period": 7, "reversed": false, "reversalOfKid": null, "userName": null, "userNumber": null, "locationName": null, "unitName": null, "canReverse": false, "unitIconKid": null, "documentKey": null, "documentId": null, "isAnonymized": false, "paymentKind": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.reverseBankAccountEntry(bankKid: "fixture /\u00e6?&", transactionKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "locationKid": null, "unitKid": null, "userKid": null, "recordedAtUtc": "2026-10-20T10:00:00Z", "amountMinor": BigInt.parse('9007199254740993'), "currency": null, "description": null, "transactionType": null, "period": 7, "reversed": false, "reversalOfKid": null, "userName": null, "userNumber": null, "locationName": null, "unitName": null, "canReverse": false, "unitIconKid": null, "documentKey": null, "documentId": null, "isAnonymized": false, "paymentKind": null}));
    expect(sends, 1);
  });

  test("wire GetObjectAddress", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/addresses/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getObjectAddress(kid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}));
    expect(sends, 1);
  });

  test("wire UpdateObjectAddress", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "PUT");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/addresses/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"address": null, "zip": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.updateObjectAddress(kid: "fixture /\u00e6?&", body: <String, Object?>{"address": null, "zip": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}));
    expect(sends, 1);
  });

  test("wire LookupObjectCoordinates", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/addresses/fixture%20%2F%C3%A6%3F%26/lookup");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.lookupObjectCoordinates(kid: "fixture /\u00e6?&", body: <String, Object?>{"expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}));
    expect(sends, 1);
  });

  test("wire SetObjectCoordinates", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "PUT");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/addresses/fixture%20%2F%C3%A6%3F%26/coordinates");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"latitude": BigInt.parse('9007199254740993'), "longitude": BigInt.parse('9007199254740993'), "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setObjectCoordinates(kid: "fixture /\u00e6?&", body: <String, Object?>{"latitude": BigInt.parse('9007199254740993'), "longitude": BigInt.parse('9007199254740993'), "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}));
    expect(sends, 1);
  });

  test("wire SetObjectCoordinateProvenance", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "PUT");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/addresses/fixture%20%2F%C3%A6%3F%26/provenance");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"value": 7, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setObjectCoordinateProvenance(kid: "fixture /\u00e6?&", body: <String, Object?>{"value": 7, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "address": null, "zip": null, "latitude": null, "longitude": null, "autoLatitudeLongitude": null, "revision": null, "outcome": null, "canWrite": false}));
    expect(sends, 1);
  });

  test("wire AskPortalAssistant", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/assistant/query");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"question": "fixture", "history": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"answer": null, "operations": null, "links": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.askPortalAssistant(body: <String, Object?>{"question": "fixture", "history": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"answer": null, "operations": null, "links": null}));
    expect(sends, 1);
  });

  test("wire GetBankExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["bankType"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankExportCount(filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", bankType: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetBanks", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["bankType"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "fields": null, "canReadBankActivationCode": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBanks(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", bankType: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "fields": null, "canReadBankActivationCode": false}));
    expect(sends, 1);
  });

  test("wire GetActiveBankCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/active-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getActiveBankCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetBankDocuments", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/documents");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["LocationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Date"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKids"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["From"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "locations": null, "units": null, "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z", "offset": 7, "limit": 7, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankDocuments(bankKid: "fixture /\u00e6?&", locationKid: "fixture", date: "fixture", search: "fixture", unitKids: <String>["fixture"], sort: "fixture", direction: "fixture", unitKid: "fixture", from: "fixture", through: "fixture", offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "locations": null, "units": null, "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z", "offset": 7, "limit": 7, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetBankDocumentsCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/documents/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["LocationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Date"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKids"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["From"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z"}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankDocumentsCount(bankKid: "fixture /\u00e6?&", locationKid: "fixture", date: "fixture", search: "fixture", unitKids: <String>["fixture"], sort: "fixture", direction: "fixture", unitKid: "fixture", from: "fixture", through: "fixture", offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z"}));
    expect(sends, 1);
  });

  test("wire GetLocationDocuments", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/documents");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["Date"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKids"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["From"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "locations": null, "units": null, "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z", "offset": 7, "limit": 7, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationDocuments(locationKid: "fixture /\u00e6?&", date: "fixture", search: "fixture", unitKids: <String>["fixture"], sort: "fixture", direction: "fixture", unitKid: "fixture", from: "fixture", through: "fixture", offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "locations": null, "units": null, "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z", "offset": 7, "limit": 7, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetLocationDocumentsCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/documents/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["Date"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKids"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["From"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z"}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationDocumentsCount(locationKid: "fixture /\u00e6?&", date: "fixture", search: "fixture", unitKids: <String>["fixture"], sort: "fixture", direction: "fixture", unitKid: "fixture", from: "fixture", through: "fixture", offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z"}));
    expect(sends, 1);
  });

  test("wire GetBankIcons", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/icons");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["kid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankIcons(kid: <String>["fixture"]);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null}));
    expect(sends, 1);
  });

  test("wire GetBankLocations", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/locations");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<Object?>[<String, Object?>{"kid": null, "name": null, "enabled": false, "deleted": null, "deletedAt": null, "iconKid": null}]), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankLocations(bankKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<Object?>[<String, Object?>{"kid": null, "name": null, "enabled": false, "deleted": null, "deletedAt": null, "iconKid": null}]));
    expect(sends, 1);
  });

  test("wire SearchBanks", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/banks");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchBanks(q: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire SearchBankActivation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/bank-activation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchBankActivation(q: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetSearchBank", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/banks/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getSearchBank(bankKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetBankUserExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["deleted"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankUserExportCount(bankKid: "fixture /\u00e6?&", filter: "fixture", sort: "fixture", direction: "fixture", locationKid: "fixture", deleted: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetBankUsers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["userKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["deleted"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "previousCursor": null, "nextCursor": null, "scanLimitReached": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankUsers(bankKid: "fixture /\u00e6?&", pageSize: 7, cursor: "fixture", sort: "fixture", direction: "fixture", filter: "fixture", userKid: "fixture", locationKid: "fixture", deleted: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "previousCursor": null, "nextCursor": null, "scanLimitReached": false}));
    expect(sends, 1);
  });

  test("wire CreateBankUser", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"action": null, "revision": null, "name": null, "number": null, "deleteAtUtc": null, "tagKid": null, "state": null, "locationKid": null, "attributes": null, "icon": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "revision": null, "name": null, "number": null, "deletedAtUtc": null, "deleteAtUtc": null, "locations": null, "tags": null, "attributes": null, "canWrite": false, "canCreate": false, "synchronization": null, "canDelete": false, "canRenameExternalId": false, "canRename": false, "iconKid": null, "availableIcons": null, "canEditIcon": false}), 201);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.createBankUser(bankKid: "fixture /\u00e6?&", body: <String, Object?>{"action": null, "revision": null, "name": null, "number": null, "deleteAtUtc": null, "tagKid": null, "state": null, "locationKid": null, "attributes": null, "icon": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "revision": null, "name": null, "number": null, "deletedAtUtc": null, "deleteAtUtc": null, "locations": null, "tags": null, "attributes": null, "canWrite": false, "canCreate": false, "synchronization": null, "canDelete": false, "canRenameExternalId": false, "canRename": false, "iconKid": null, "availableIcons": null, "canEditIcon": false}));
    expect(sends, 1);
  });

  test("wire GetBankBookings", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/bookings");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["from"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["through"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["unitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["userKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["status"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "units": null, "from": "2026-10-20", "through": "2026-10-20", "offset": 7, "limit": 7, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankBookings(bankKid: "fixture /\u00e6?&", from: "2026-10-20", through: "2026-10-20", locationKid: "fixture", unitKid: "fixture", userKid: "fixture", status: "fixture", search: "fixture", offset: 7, limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "units": null, "from": "2026-10-20", "through": "2026-10-20", "offset": 7, "limit": 7, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire ExecuteBankBookingCommand", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/bookings/fixture%20%2F%C3%A6%3F%26/commands");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"action": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "locationKid": null, "unitKid": null, "userKid": null, "startLocal": null, "endLocal": null, "weeklyMinute": null, "durationMinutes": 7, "recordedAtUtc": "2026-10-20T10:00:00Z", "cancelled": false, "synced": false, "source": null, "userName": null, "userNumber": null, "locationName": null, "unitName": null, "canCancel": false, "canRestore": false, "unitIconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.executeBankBookingCommand(bankKid: "fixture /\u00e6?&", bookingKid: "fixture /\u00e6?&", body: <String, Object?>{"action": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "locationKid": null, "unitKid": null, "userKid": null, "startLocal": null, "endLocal": null, "weeklyMinute": null, "durationMinutes": 7, "recordedAtUtc": "2026-10-20T10:00:00Z", "cancelled": false, "synced": false, "source": null, "userName": null, "userNumber": null, "locationName": null, "unitName": null, "canCancel": false, "canRestore": false, "unitIconKid": null}));
    expect(sends, 1);
  });

  test("wire GetCameraNearestLocation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/nearest-location");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["latitude"], <Object?>["1.25"]);
      expect(request.url.queryParametersAll["longitude"], <Object?>["1.25"]);
      expect(request.url.queryParametersAll["accuracyMeters"], <Object?>["1.25"]);
      return http.Response(encodeApiJson(<String, Object?>{"resourceKid": null, "name": null, "iconKid": null, "requiresProximityCheck": false, "latitude": null, "longitude": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCameraNearestLocation(latitude: 1.25, longitude: 1.25, accuracyMeters: 1.25);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"resourceKid": null, "name": null, "iconKid": null, "requiresProximityCheck": false, "latitude": null, "longitude": null}));
    expect(sends, 1);
  });

  test("wire GetCameraResource", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/resource");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["resourceKid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"resourceKid": null, "name": null, "iconKid": null, "requiresProximityCheck": false, "latitude": null, "longitude": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCameraResource(resourceKid: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"resourceKid": null, "name": null, "iconKid": null, "requiresProximityCheck": false, "latitude": null, "longitude": null}));
    expect(sends, 1);
  });

  test("wire GetCameraAvailability", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/availability");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["resourceKid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"hasCaptures": false, "isDegraded": false, "canCapture": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCameraAvailability(resourceKid: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"hasCaptures": false, "isDegraded": false, "canCapture": false}));
    expect(sends, 1);
  });

  test("wire PrepareCameraCapture", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/prepare");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"resourceKid": null, "kind": null, "originalFileName": null, "originalNameAvailable": false, "capturedAtUtc": "2026-10-20T10:00:00Z", "mediaLength": BigInt.parse('9007199254740993'), "mediaSha256": null, "sensorData": <String, Object?>{}, "motionLength": null, "motionSha256": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"uploadToken": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.prepareCameraCapture(body: <String, Object?>{"resourceKid": null, "kind": null, "originalFileName": null, "originalNameAvailable": false, "capturedAtUtc": "2026-10-20T10:00:00Z", "mediaLength": BigInt.parse('9007199254740993'), "mediaSha256": null, "sensorData": <String, Object?>{}, "motionLength": null, "motionSha256": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"uploadToken": null}));
    expect(sends, 1);
  });

  test("wire SaveCameraCapture", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["background"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"captureId": null, "resourceKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.saveCameraCapture(background: false, body: <String, Object?>{"uploadToken": "fixture", "original": ApiUploadFile(() => Stream.value([1, 2, 3]), 3, 'fixture.bin'), "motion": ApiUploadFile(() => Stream.value([1, 2, 3]), 3, 'fixture.bin')});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"captureId": null, "resourceKid": null}));
    expect(sends, 1);
  });

  test("wire GetCameraCaptures", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["resourceKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "isDegraded": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCameraCaptures(resourceKid: "fixture", cursor: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "isDegraded": false}));
    expect(sends, 1);
  });

  test("wire ConfirmCameraCapture", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/confirmation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"uploadToken": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"confirmed": false, "errorCode": null, "processingPercent": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.confirmCameraCapture(body: <String, Object?>{"uploadToken": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"confirmed": false, "errorCode": null, "processingPercent": null}));
    expect(sends, 1);
  });

  test("wire GetCameraCaptureContent", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/fixture%20%2F%C3%A6%3F%26/content");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["part"], <Object?>["fixture"]);
      expect(request.headers["Range"], "fixture");
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCameraCaptureContent(id: "fixture /\u00e6?&", partValue: "fixture", range: "fixture");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetRecentCameraPhotoMetadata", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/camera/recent/fixture%20%2F%C3%A6%3F%26/metadata");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getRecentCameraPhotoMetadata(id: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire ExportBankAccount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/account/export");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["From"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["Through"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["TimeZone"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Period"], <Object?>["7"]);
      expect(request.url.queryParametersAll["LocationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UnitKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["UserKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Kind"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["IncludeZero"], <Object?>["false"]);
      expect(request.url.queryParametersAll["IncludeBookings"], <Object?>["false"]);
      expect(request.url.queryParametersAll["IncludeMonthly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      expect(request.url.queryParametersAll["format"], <Object?>["fixture"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.exportBankAccount(bankKid: "fixture /\u00e6?&", from: "2026-10-20", through: "2026-10-20", timeZone: "fixture", period: 7, locationKid: "fixture", unitKid: "fixture", userKid: "fixture", kind: "fixture", includeZero: false, includeBookings: false, includeMonthly: false, offset: 7, limit: 7, format: "fixture");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire ExportBankUsers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/export");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["deleted"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.exportBankUsers(bankKid: "fixture /\u00e6?&", filter: "fixture", locationKid: "fixture", deleted: "fixture", sort: "fixture", direction: "fixture");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire DownloadBankSettlement", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/settlements/7/download");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["format"], <Object?>["fixture"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.downloadBankSettlement(bankKid: "fixture /\u00e6?&", period: 7, format: "fixture");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire DownloadUnitDocumentCsv", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/table.csv");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.downloadUnitDocumentCsv(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire DownloadUnitDocumentXls", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/table.xls");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.downloadUnitDocumentXls(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetHostingLogs", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/hosting/logs");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["environment"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["application"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"environment": null, "application": null, "fetchedAtUtc": "2026-10-20T10:00:00Z", "lines": null, "truncated": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getHostingLogs(environment: "fixture", application: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"environment": null, "application": null, "fetchedAtUtc": "2026-10-20T10:00:00Z", "lines": null, "truncated": false}));
    expect(sends, 1);
  });

  test("wire GetHostingMetrics", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/hosting/metrics");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["environment"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["application"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["hours"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"environment": null, "application": null, "fromUtc": "2026-10-20T10:00:00Z", "toUtc": "2026-10-20T10:00:00Z", "fetchedAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "metrics": null, "bandwidth": <String, Object?>{"dateUtc": "2026-10-20", "bytes": null, "errorCode": null}}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getHostingMetrics(environment: "fixture", application: "fixture", hours: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"environment": null, "application": null, "fromUtc": "2026-10-20T10:00:00Z", "toUtc": "2026-10-20T10:00:00Z", "fetchedAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "metrics": null, "bandwidth": <String, Object?>{"dateUtc": "2026-10-20", "bytes": null, "errorCode": null}}));
    expect(sends, 1);
  });

  test("wire SetInstallerIcon", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/installers/fixture%20%2F%C3%A6%3F%26/icon");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"icon": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "iconRevision": null, "availableIcons": null, "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setInstallerIcon(installerKid: "fixture /\u00e6?&", body: <String, Object?>{"icon": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "iconRevision": null, "availableIcons": null, "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetInstallerExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/installers/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["includeActivationCode"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getInstallerExportCount(filter: "fixture", sort: "fixture", direction: "fixture", includeActivationCode: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetInstallers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/installers");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["includeActivationCode"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getInstallers(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture", includeActivationCode: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null}));
    expect(sends, 1);
  });

  test("wire GetInstaller", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/installers/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"installer": <String, Object?>{"kid": null, "name": null, "email": null, "locations": null, "tags": null, "deleted": false, "deletedAt": null, "enabled": null, "lastActiveAt": null, "activationCode": null, "iconKid": null}, "canEditIcon": false, "iconRevision": null, "availableIcons": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getInstaller(installerKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"installer": <String, Object?>{"kid": null, "name": null, "email": null, "locations": null, "tags": null, "deleted": false, "deletedAt": null, "enabled": null, "lastActiveAt": null, "activationCode": null, "iconKid": null}, "canEditIcon": false, "iconRevision": null, "availableIcons": null}));
    expect(sends, 1);
  });

  test("wire GetLiveLogs", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/diagnostics/live-logs");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"tenantKid": null, "fetchedAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "servers": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLiveLogs();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"tenantKid": null, "fetchedAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "servers": null}));
    expect(sends, 1);
  });

  test("wire GetActiveLocationCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/active-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["bankKid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getActiveLocationCount(bankKid: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetLocations", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["includeCoordinates"], <Object?>["false"]);
      expect(request.url.queryParametersAll["bankKid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "hasAllBanksAccess": false, "fields": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocations(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", includeCoordinates: false, bankKid: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "hasAllBanksAccess": false, "fields": null}));
    expect(sends, 1);
  });

  test("wire GetLocationCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["bankKid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationCount(filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", bankKid: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire SearchLocations", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/locations");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchLocations(q: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire SearchLocationActivation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/location-activation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchLocationActivation(q: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetLocationBookingCalendars", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/booking-calendars");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      expect(request.url.queryParametersAll["from"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["days"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"locationKid": null, "groups": null, "timeZone": null, "from": "2026-10-20", "days": 7}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationBookingCalendars(locationKid: "fixture /\u00e6?&", acceptLanguage: "fixture", from: "2026-10-20", days: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"locationKid": null, "groups": null, "timeZone": null, "from": "2026-10-20", "days": 7}));
    expect(sends, 1);
  });

  test("wire GetLocationBookingRules", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/booking-rules");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"locationKid": null, "calculatedAt": "2026-10-20T10:00:00Z", "groups": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationBookingRules(locationKid: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"locationKid": null, "calculatedAt": "2026-10-20T10:00:00Z", "groups": null}));
    expect(sends, 1);
  });

  test("wire GetControllerOverview", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/controllers/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "descriptorAvailable": false, "settingGroups": null, "stateGroups": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getControllerOverview(controllerKid: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "descriptorAvailable": false, "settingGroups": null, "stateGroups": null}));
    expect(sends, 1);
  });

  test("wire GetControllerGroup", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/controllers/fixture%20%2F%C3%A6%3F%26/groups/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "kind": null, "group": null, "items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getControllerGroup(controllerKid: "fixture /\u00e6?&", kind: "fixture /\u00e6?&", group: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "kind": null, "group": null, "items": null}));
    expect(sends, 1);
  });

  test("wire GetLocationUnits", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/units");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationUnits(locationKid: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "items": null}));
    expect(sends, 1);
  });

  test("wire GetUnitOverview", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "descriptorAvailable": false, "settingGroups": null, "stateGroups": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitOverview(unitKid: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "descriptorAvailable": false, "settingGroups": null, "stateGroups": null}));
    expect(sends, 1);
  });

  test("wire GetUnitGroup", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/fixture%20%2F%C3%A6%3F%26/groups/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "kind": null, "group": null, "items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitGroup(unitKid: "fixture /\u00e6?&", kind: "fixture /\u00e6?&", group: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"location": <String, Object?>{"kid": null, "name": null, "iconKid": null}, "unit": <String, Object?>{"kid": null, "name": null, "cycle": null, "cycleText": null, "unitType": null, "unitTypeName": null, "unitTypeSource": null, "iconKid": null, "progress": <String, Object?>{}, "terminal": <String, Object?>{}}, "kind": null, "group": null, "items": null}));
    expect(sends, 1);
  });

  test("wire GetUnitSettingHistory", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/fixture%20%2F%C3%A6%3F%26/groups/settings/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/history");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["beforeMs2000"], <Object?>["9007199254740993"]);
      expect(request.url.queryParametersAll["limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"unitKid": null, "group": null, "setting": null, "items": null, "nextBeforeMs2000": null, "valueFormat": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitSettingHistory(unitKid: "fixture /\u00e6?&", group: "fixture /\u00e6?&", setting: "fixture /\u00e6?&", beforeMs2000: BigInt.parse('9007199254740993'), limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"unitKid": null, "group": null, "setting": null, "items": null, "nextBeforeMs2000": null, "valueFormat": null}));
    expect(sends, 1);
  });

  test("wire GetUnitIcons", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/icons");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["kid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitIcons(kid: <String>["fixture"]);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null}));
    expect(sends, 1);
  });

  test("wire GetLocationIcons", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/icons");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["kid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationIcons(kid: <String>["fixture"]);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null}));
    expect(sends, 1);
  });

  test("wire GetLocationOpeningHours", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/opening-hours");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"locationKid": null, "timeZone": null, "calculatedAt": "2026-10-20T10:00:00Z", "groups": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationOpeningHours(locationKid: "fixture /\u00e6?&", acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"locationKid": null, "timeZone": null, "calculatedAt": "2026-10-20T10:00:00Z", "groups": null}));
    expect(sends, 1);
  });

  test("wire GetLocationReservationHistory", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/reservation-history");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["from"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["days"], <Object?>["7"]);
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"locationKid": null, "from": "2026-10-20", "days": 7, "items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationReservationHistory(locationKid: "fixture /\u00e6?&", from: "2026-10-20", days: 7, acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"locationKid": null, "from": "2026-10-20", "days": 7, "items": null}));
    expect(sends, 1);
  });

  test("wire GetLocationReservations", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/reservations");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["from"], <Object?>["2026-10-20"]);
      expect(request.url.queryParametersAll["days"], <Object?>["7"]);
      expect(request.headers["Accept-Language"], "fixture");
      return http.Response(encodeApiJson(<String, Object?>{"locationKid": null, "from": "2026-10-20", "days": 7, "items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationReservations(locationKid: "fixture /\u00e6?&", from: "2026-10-20", days: 7, acceptLanguage: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"locationKid": null, "from": "2026-10-20", "days": 7, "items": null}));
    expect(sends, 1);
  });

  test("wire GetLocationWeather", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/fixture%20%2F%C3%A6%3F%26/weather");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"locationKid": null, "status": null, "address": null, "zip": null, "positionSource": null, "current": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLocationWeather(locationKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"locationKid": null, "status": null, "address": null, "zip": null, "positionSource": null, "current": null}));
    expect(sends, 1);
  });

  test("wire CreateManager", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null}), 201);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.createManager();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null}));
    expect(sends, 1);
  });

  test("wire GetManagers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getManagers(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null}));
    expect(sends, 1);
  });

  test("wire InviteManager", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/invitation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"expectedRevision": "fixture", "language": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 202);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.inviteManager(managerKid: "fixture /\u00e6?&", body: <String, Object?>{"expectedRevision": "fixture", "language": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire SetManagerKid", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/kids");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"resourceKid": null, "enabled": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"resourceGrants": null, "kidsRevision": null, "canEditKids": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setManagerKid(managerKid: "fixture /\u00e6?&", body: <String, Object?>{"resourceKid": null, "enabled": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"resourceGrants": null, "kidsRevision": null, "canEditKids": false}));
    expect(sends, 1);
  });

  test("wire RequestManagerPasswordReset", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/forgot-password");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.body, encodeApiJson(<String, Object?>{"email": "fixture", "language": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 202);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.requestManagerPasswordReset(body: <String, Object?>{"email": "fixture", "language": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire ResetManagerPassword", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/reset-password");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.body, encodeApiJson(<String, Object?>{"token": "fixture", "password": "fixture", "confirmPassword": "fixture"}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.resetManagerPassword(body: <String, Object?>{"token": "fixture", "password": "fixture", "confirmPassword": "fixture"});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire SetManagerPermissionRole", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/permission-role");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"role": null, "expectedFlags": null, "expectedTabsRevision": null, "expectedKidsRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"role": null, "operationPermissions": null, "canEditPermissions": false, "tabs": null, "tabsRevision": null, "canEditTabs": false, "resourceGrants": null, "kidsRevision": null, "canEditKids": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setManagerPermissionRole(managerKid: "fixture /\u00e6?&", body: <String, Object?>{"role": null, "expectedFlags": null, "expectedTabsRevision": null, "expectedKidsRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"role": null, "operationPermissions": null, "canEditPermissions": false, "tabs": null, "tabsRevision": null, "canEditTabs": false, "resourceGrants": null, "kidsRevision": null, "canEditKids": false}));
    expect(sends, 1);
  });

  test("wire SetManagerPermission", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/permissions/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"flag": null, "enabled": null, "expectedFlags": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"resource": null, "level": null, "canRead": false, "canWrite": false, "canCreate": false, "flags": null, "canDelete": false, "canRenameExternalId": false, "canRename": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setManagerPermission(managerKid: "fixture /\u00e6?&", resource: "fixture /\u00e6?&", body: <String, Object?>{"flag": null, "enabled": null, "expectedFlags": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"resource": null, "level": null, "canRead": false, "canWrite": false, "canCreate": false, "flags": null, "canDelete": false, "canRenameExternalId": false, "canRename": false}));
    expect(sends, 1);
  });

  test("wire SetManagerProfileField", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/profile/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"value": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"field": null, "name": null, "organisation": null, "email": null, "iconKid": null, "gravatarUrl": null, "availableIcons": null, "enabled": null, "deleted": false, "deletedMs2000": BigInt.parse('9007199254740993'), "deletedAt": null, "retentionDays": 7, "profileRevision": null, "canEditProfile": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setManagerProfileField(managerKid: "fixture /\u00e6?&", field: "fixture /\u00e6?&", body: <String, Object?>{"value": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"field": null, "name": null, "organisation": null, "email": null, "iconKid": null, "gravatarUrl": null, "availableIcons": null, "enabled": null, "deleted": false, "deletedMs2000": BigInt.parse('9007199254740993'), "deletedAt": null, "retentionDays": 7, "profileRevision": null, "canEditProfile": false}));
    expect(sends, 1);
  });

  test("wire GetManagerExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getManagerExportCount(filter: "fixture", sort: "fixture", direction: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetManager", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "name": null, "email": null, "resourceGrants": null, "tabs": null, "iconKid": null, "gravatarUrl": null, "organisation": null, "enabled": null, "deleted": false, "deletedAt": null, "lastActiveAt": null, "operationPermissions": null, "retentionDays": 7, "isCurrentManager": false, "canEditPermissions": false, "canEditTabs": false, "canEditProfile": false, "profileRevision": null, "tabsRevision": null, "kidsRevision": null, "canEditKids": false, "availableTabs": null, "availableIcons": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getManager(managerKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "name": null, "email": null, "resourceGrants": null, "tabs": null, "iconKid": null, "gravatarUrl": null, "organisation": null, "enabled": null, "deleted": false, "deletedAt": null, "lastActiveAt": null, "operationPermissions": null, "retentionDays": 7, "isCurrentManager": false, "canEditPermissions": false, "canEditTabs": false, "canEditProfile": false, "profileRevision": null, "tabsRevision": null, "kidsRevision": null, "canEditKids": false, "availableTabs": null, "availableIcons": null}));
    expect(sends, 1);
  });

  test("wire GetManagersWithSameEmail", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/same-email");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<Object?>[<String, Object?>{"kid": null, "name": null, "iconKid": null, "gravatarUrl": null}]), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getManagersWithSameEmail(managerKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<Object?>[<String, Object?>{"kid": null, "name": null, "iconKid": null, "gravatarUrl": null}]));
    expect(sends, 1);
  });

  test("wire LoginManager", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/login");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.headers["X-Portal-Login-Client-IP"], "fixture");
      expect(request.body, encodeApiJson(<String, Object?>{"email": null, "password": null, "kid": null, "apiKey": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"accessToken": null, "expiresIn": BigInt.parse('9007199254740993'), "tokenType": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.loginManager(xPortalLoginClientIP: "fixture", body: <String, Object?>{"email": null, "password": null, "kid": null, "apiKey": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"accessToken": null, "expiresIn": BigInt.parse('9007199254740993'), "tokenType": null}));
    expect(sends, 1);
  });

  test("wire RenewManagerSession", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/renew");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"accessToken": null, "expiresIn": BigInt.parse('9007199254740993'), "tokenType": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.renewManagerSession();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"accessToken": null, "expiresIn": BigInt.parse('9007199254740993'), "tokenType": null}));
    expect(sends, 1);
  });

  test("wire GetCurrentManager", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "name": null, "tabs": null, "hasBankAccess": false, "iconKid": null, "databaseAccess": <String, Object?>{"canWrite": null, "checkedAtUtc": "2026-10-20T10:00:00Z"}, "navigationBanks": null, "organisation": null, "gravatarUrl": null, "retentionDays": 7, "themeMode": 7, "iconSet": null, "language": null, "dateFormat": null, "numberFormat": null, "lineSpacing": 1.25, "tabDetails": null, "resourceGrants": null, "operationPermissions": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCurrentManager();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "name": null, "tabs": null, "hasBankAccess": false, "iconKid": null, "databaseAccess": <String, Object?>{"canWrite": null, "checkedAtUtc": "2026-10-20T10:00:00Z"}, "navigationBanks": null, "organisation": null, "gravatarUrl": null, "retentionDays": 7, "themeMode": 7, "iconSet": null, "language": null, "dateFormat": null, "numberFormat": null, "lineSpacing": 1.25, "tabDetails": null, "resourceGrants": null, "operationPermissions": null}));
    expect(sends, 1);
  });

  test("wire RequestManagerSignUp", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/signup");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.body, encodeApiJson(<String, Object?>{"email": null, "name": null, "organisation": null, "password": null, "confirmPassword": null, "language": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 202);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.requestManagerSignUp(body: <String, Object?>{"email": null, "name": null, "organisation": null, "password": null, "confirmPassword": null, "language": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire ConfirmManagerSignUp", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/signup-confirmation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.body, encodeApiJson(<String, Object?>{"token": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.confirmManagerSignUp(body: <String, Object?>{"token": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire SetManagerTab", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/fixture%20%2F%C3%A6%3F%26/tabs/7");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"enabled": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"tabs": null, "tabsRevision": null, "canEditTabs": false, "canEditPermissions": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setManagerTab(managerKid: "fixture /\u00e6?&", tabId: 7, body: <String, Object?>{"enabled": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"tabs": null, "tabsRevision": null, "canEditTabs": false, "canEditPermissions": false}));
    expect(sends, 1);
  });

  test("wire SetCurrentManagerTheme", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/theme");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"themeMode": 7}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"themeMode": 7}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setCurrentManagerTheme(body: <String, Object?>{"themeMode": 7});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"themeMode": 7}));
    expect(sends, 1);
  });

  test("wire GetNearestLocations", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/locations/nearest");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["latitude"], <Object?>["1.25"]);
      expect(request.url.queryParametersAll["longitude"], <Object?>["1.25"]);
      return http.Response(encodeApiJson(<Object?>[<String, Object?>{"kid": null, "name": null, "bankName": null, "iconKid": null, "distanceMeters": 1.25}]), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getNearestLocations(latitude: 1.25, longitude: 1.25);
    expect(encodeApiJson(result), encodeApiJson(<Object?>[<String, Object?>{"kid": null, "name": null, "bankName": null, "iconKid": null, "distanceMeters": 1.25}]));
    expect(sends, 1);
  });

  test("wire GetManagerCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/managers/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getManagerCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetInstallerCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/installers/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getInstallerCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetMyManagerProfile", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/profile");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "name": null, "organisation": null, "iconKid": null, "email": null, "emailVerified": false, "themeMode": 7, "revision": null, "availableIcons": null, "retentionDays": 7, "iconSet": null, "language": null, "dateFormat": null, "numberFormat": null, "lineSpacing": 1.25}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getMyManagerProfile();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "name": null, "organisation": null, "iconKid": null, "email": null, "emailVerified": false, "themeMode": 7, "revision": null, "availableIcons": null, "retentionDays": 7, "iconSet": null, "language": null, "dateFormat": null, "numberFormat": null, "lineSpacing": 1.25}));
    expect(sends, 1);
  });

  test("wire GetMyManagerApiKey", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/api-key");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"hasApiKey": false, "revision": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getMyManagerApiKey();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"hasApiKey": false, "revision": null}));
    expect(sends, 1);
  });

  test("wire GenerateMyManagerApiKey", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/api-key");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"revision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"apiKey": null, "details": <String, Object?>{"hasApiKey": false, "revision": null}}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.generateMyManagerApiKey(body: <String, Object?>{"revision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"apiKey": null, "details": <String, Object?>{"hasApiKey": false, "revision": null}}));
    expect(sends, 1);
  });

  test("wire GetMyManagerTabs", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/tabs");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "tabs": null, "availableTabs": null, "revision": null, "canEdit": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getMyManagerTabs();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "tabs": null, "availableTabs": null, "revision": null, "canEdit": false}));
    expect(sends, 1);
  });

  test("wire SetMyManagerTab", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/tabs/7");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"revision": null, "enabled": false}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "tabs": null, "availableTabs": null, "revision": null, "canEdit": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setMyManagerTab(tabId: 7, body: <String, Object?>{"revision": null, "enabled": false});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "tabs": null, "availableTabs": null, "revision": null, "canEdit": false}));
    expect(sends, 1);
  });

  test("wire SetMyManagerProfileField", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/profile/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"revision": null, "value": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "name": null, "organisation": null, "iconKid": null, "email": null, "emailVerified": false, "themeMode": 7, "revision": null, "availableIcons": null, "retentionDays": 7, "iconSet": null, "language": null, "dateFormat": null, "numberFormat": null, "lineSpacing": 1.25}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setMyManagerProfileField(field: "fixture /\u00e6?&", body: <String, Object?>{"revision": null, "value": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "name": null, "organisation": null, "iconKid": null, "email": null, "emailVerified": false, "themeMode": 7, "revision": null, "availableIcons": null, "retentionDays": 7, "iconSet": null, "language": null, "dateFormat": null, "numberFormat": null, "lineSpacing": 1.25}));
    expect(sends, 1);
  });

  test("wire RequestMyManagerEmailVerification", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/email-verification");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"email": null, "currentPassword": null, "language": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 202);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.requestMyManagerEmailVerification(body: <String, Object?>{"email": null, "currentPassword": null, "language": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire ConfirmMyManagerEmail", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/email-confirmation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.body, encodeApiJson(<String, Object?>{"token": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.confirmMyManagerEmail(body: <String, Object?>{"token": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire ChangeMyManagerPassword", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/session/me/password");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"currentPassword": null, "password": null, "confirmPassword": null, "language": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"code": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.changeMyManagerPassword(body: <String, Object?>{"currentPassword": null, "password": null, "confirmPassword": null, "language": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"code": null}));
    expect(sends, 1);
  });

  test("wire GetServiceExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/services/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getServiceExportCount(filter: "fixture", sort: "fixture", direction: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetServices", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/services");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getServices(filter: "fixture", sort: "fixture", direction: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null}));
    expect(sends, 1);
  });

  test("wire GetServiceCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/services/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getServiceCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetService", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/services/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"service": <String, Object?>{"kid": null, "identity": null, "name": null, "iconName": null, "iconKid": null}, "hasApiKeyHash": false, "apiKeyHash": null, "canEdit": false, "profileRevision": null, "availableIcons": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getService(serviceKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"service": <String, Object?>{"kid": null, "identity": null, "name": null, "iconName": null, "iconKid": null}, "hasApiKeyHash": false, "apiKeyHash": null, "canEdit": false, "profileRevision": null, "availableIcons": null}));
    expect(sends, 1);
  });

  test("wire SetServiceProfileField", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/services/fixture%20%2F%C3%A6%3F%26/profile/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"value": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"service": <String, Object?>{"kid": null, "identity": null, "name": null, "iconName": null, "iconKid": null}, "hasApiKeyHash": false, "apiKeyHash": null, "canEdit": false, "profileRevision": null, "availableIcons": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setServiceProfileField(serviceKid: "fixture /\u00e6?&", field: "fixture /\u00e6?&", body: <String, Object?>{"value": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"service": <String, Object?>{"kid": null, "identity": null, "name": null, "iconName": null, "iconKid": null}, "hasApiKeyHash": false, "apiKeyHash": null, "canEdit": false, "profileRevision": null, "availableIcons": null}));
    expect(sends, 1);
  });

  test("wire GenerateServiceApiKey", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/services/fixture%20%2F%C3%A6%3F%26/api-key");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"apiKey": null, "details": <String, Object?>{"service": <String, Object?>{}, "hasApiKeyHash": false, "apiKeyHash": null, "canEdit": false, "profileRevision": null, "availableIcons": null}}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.generateServiceApiKey(serviceKid: "fixture /\u00e6?&", body: <String, Object?>{"expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"apiKey": null, "details": <String, Object?>{"service": <String, Object?>{}, "hasApiKeyHash": false, "apiKeyHash": null, "canEdit": false, "profileRevision": null, "availableIcons": null}}));
    expect(sends, 1);
  });

  test("wire GetBankSettlements", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/settlements");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["beforePeriod"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "nextSettlement": null, "periods": null, "nextBeforePeriod": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankSettlements(bankKid: "fixture /\u00e6?&", beforePeriod: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "nextSettlement": null, "periods": null, "nextBeforePeriod": null}));
    expect(sends, 1);
  });

  test("wire GetBankSettlementPeriod", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/settlements/7");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "period": 7, "sourceEntries": 7, "includedEntries": 7, "groups": null, "formats": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankSettlementPeriod(bankKid: "fixture /\u00e6?&", period: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "period": 7, "sourceEntries": 7, "includedEntries": 7, "groups": null, "formats": null}));
    expect(sends, 1);
  });

  test("wire GetTenantStatus", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/tenant/status");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "sources": null, "items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getTenantStatus(limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "sources": null, "items": null}));
    expect(sends, 1);
  });

  test("wire GetTenantStatusPage", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/tenant/status/page");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["anchor"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"status": <String, Object?>{"measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "sources": null, "items": null}, "offset": 7, "totalCount": 7, "previousCursor": null, "nextCursor": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getTenantStatusPage(pageSize: 7, cursor: "fixture", offset: 7, anchor: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"status": <String, Object?>{"measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "sources": null, "items": null}, "offset": 7, "totalCount": 7, "previousCursor": null, "nextCursor": null}));
    expect(sends, 1);
  });

  test("wire ConvertToolTime", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/tenant/tools/time");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"format": null, "value": null, "timeZone": null, "offset": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"success": false, "error": null, "result": <String, Object?>{"ms2000": null, "mi2000": null, "ss2000": null, "utc": null, "local": null, "timeZone": null, "offset": null, "dateInputRounded": false, "millisecondRemainder": null, "secondRemainder": null}, "offsetChoices": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.convertToolTime(body: <String, Object?>{"format": null, "value": null, "timeZone": null, "offset": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"success": false, "error": null, "result": <String, Object?>{"ms2000": null, "mi2000": null, "ss2000": null, "utc": null, "local": null, "timeZone": null, "offset": null, "dateInputRounded": false, "millisecondRemainder": null, "secondRemainder": null}, "offsetChoices": null}));
    expect(sends, 1);
  });

  test("wire InspectToolKid", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/tenant/tools/kid");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"kid": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"canonicalKid": null, "fields": null, "normalized": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.inspectToolKid(body: <String, Object?>{"kid": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"canonicalKid": null, "fields": null, "normalized": false}));
    expect(sends, 1);
  });

  test("wire GetUnitDocuments", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/fixture%20%2F%C3%A6%3F%26/documents");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["Sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Limit"], <Object?>["7"]);
      expect(request.url.queryParametersAll["Search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Date"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z", "sort": null, "direction": null, "offset": 7, "limit": 7, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocuments(unitKid: "fixture /\u00e6?&", sort: "fixture", direction: "fixture", offset: 7, limit: 7, search: "fixture", date: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z", "sort": null, "direction": null, "offset": 7, "limit": 7, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetUnitDocumentsCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/fixture%20%2F%C3%A6%3F%26/documents/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["Search"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Date"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z"}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentsCount(unitKid: "fixture /\u00e6?&", search: "fixture", date: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "from": "2026-10-20T10:00:00Z", "through": "2026-10-20T10:00:00Z"}));
    expect(sends, 1);
  });

  test("wire GetUnitDocumentNeighbors", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/neighbors");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"previous": <String, Object?>{"kid": null, "lastActivityUtc": "2026-10-20T10:00:00Z"}, "next": <String, Object?>{"kid": null, "lastActivityUtc": "2026-10-20T10:00:00Z"}}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentNeighbors(documentKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"previous": <String, Object?>{"kid": null, "lastActivityUtc": "2026-10-20T10:00:00Z"}, "next": <String, Object?>{"kid": null, "lastActivityUtc": "2026-10-20T10:00:00Z"}}));
    expect(sends, 1);
  });

  test("wire GetUnitDocumentTable", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/table");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"documentKid": null, "unitKid": null, "unitName": null, "finished": false, "fromMs2000": BigInt.parse('9007199254740993'), "toMs2000": BigInt.parse('9007199254740993'), "columns": null, "rows": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentTable(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"documentKid": null, "unitKid": null, "unitName": null, "finished": false, "fromMs2000": BigInt.parse('9007199254740993'), "toMs2000": BigInt.parse('9007199254740993'), "columns": null, "rows": null}));
    expect(sends, 1);
  });

  test("wire GetUnitDocumentHtml", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/table.html");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentHtml(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetUnitDocumentSvg", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/graph.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      expect(request.url.queryParametersAll["width"], <Object?>["7"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentSvg(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false, width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetUnitDocumentSvg2", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/graph2.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentSvg2(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetUnitDocumentGraph", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/graph");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"documentKid": null, "unitKid": null, "unitName": null, "finished": false, "fromMs2000": BigInt.parse('9007199254740993'), "toMs2000": BigInt.parse('9007199254740993'), "startedMs2000": null, "endedMs2000": null, "series": null, "events": null, "signals": null, "dosing": null, "presentation": <String, Object?>{"unitType": null, "kind": null, "groupOrder": null}}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentGraph(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"documentKid": null, "unitKid": null, "unitName": null, "finished": false, "fromMs2000": BigInt.parse('9007199254740993'), "toMs2000": BigInt.parse('9007199254740993'), "startedMs2000": null, "endedMs2000": null, "series": null, "events": null, "signals": null, "dosing": null, "presentation": <String, Object?>{"unitType": null, "kind": null, "groupOrder": null}}));
    expect(sends, 1);
  });

  test("wire GetUnitDocumentPng", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/graph.png");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentPng(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetUnitDocumentIcon", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/documents/fixture%20%2F%C3%A6%3F%26/icon.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["States"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["Settings"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["HistoricalMeasurements"], <Object?>["false"]);
      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitDocumentIcon(documentKid: "fixture /\u00e6?&", states: "fixture", settings: "fixture", historicalMeasurements: false);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetUnitExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["terminalKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["runningOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["autoOutOfOrderOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnitExportCount(filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", locationKid: "fixture", terminalKid: "fixture", runningOnly: false, autoOutOfOrderOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetTerminalExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/terminals/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["terminalKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["runningOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getTerminalExportCount(filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", locationKid: "fixture", terminalKid: "fixture", runningOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetActiveUnitCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/active-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getActiveUnitCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetActiveTerminalCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/terminals/active-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getActiveTerminalCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetUnits", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["includeCoordinates"], <Object?>["false"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["terminalKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["runningOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["autoOutOfOrderOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "hasAllBanksAccess": false, "fields": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUnits(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", includeCoordinates: false, locationKid: "fixture", terminalKid: "fixture", runningOnly: false, autoOutOfOrderOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "hasAllBanksAccess": false, "fields": null}));
    expect(sends, 1);
  });

  test("wire GetTerminals", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/terminals");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      expect(request.url.queryParametersAll["fields"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["includeCoordinates"], <Object?>["false"]);
      expect(request.url.queryParametersAll["locationKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["terminalKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["runningOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "hasAllBanksAccess": false, "fields": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getTerminals(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false, fields: "fixture", includeCoordinates: false, locationKid: "fixture", terminalKid: "fixture", runningOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "hasAllBanksAccess": false, "fields": null}));
    expect(sends, 1);
  });

  test("wire SetUnitSetting", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/units/fixture%20%2F%C3%A6%3F%26/groups/settings/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"value": null, "expectedRevision": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"unitKid": null, "group": null, "setting": null, "value": null, "ms2000": BigInt.parse('9007199254740993'), "revision": null, "sync": null, "changedBy": <String, Object?>{"kid": null, "kind": null, "name": null, "iconKid": null}}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.setUnitSetting(unitKid: "fixture /\u00e6?&", group: "fixture /\u00e6?&", setting: "fixture /\u00e6?&", body: <String, Object?>{"value": null, "expectedRevision": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"unitKid": null, "group": null, "setting": null, "value": null, "ms2000": BigInt.parse('9007199254740993'), "revision": null, "sync": null, "changedBy": <String, Object?>{"kid": null, "kind": null, "name": null, "iconKid": null}}));
    expect(sends, 1);
  });

  test("wire GetBankUserBalances", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/balances");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"userKids": <Object?>["fixture"]}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"items": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankUserBalances(bankKid: "fixture /\u00e6?&", body: <String, Object?>{"userKids": <Object?>["fixture"]});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null}));
    expect(sends, 1);
  });

  test("wire GetBankUserNumberForNewUser", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/next-number");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"bankKid": null, "number": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankUserNumberForNewUser(bankKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"bankKid": null, "number": null}));
    expect(sends, 1);
  });

  test("wire GetBankNextUserNumber", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/next-number-after");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["userNumber"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"bankKid": null, "number": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankNextUserNumber(bankKid: "fixture /\u00e6?&", userNumber: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"bankKid": null, "number": null}));
    expect(sends, 1);
  });

  test("wire GetBankUserWorkspace", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/fixture%20%2F%C3%A6%3F%26/workspace");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "revision": null, "name": null, "number": null, "deletedAtUtc": null, "deleteAtUtc": null, "locations": null, "tags": null, "attributes": null, "canWrite": false, "canCreate": false, "synchronization": null, "canDelete": false, "canRenameExternalId": false, "canRename": false, "iconKid": null, "availableIcons": null, "canEditIcon": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankUserWorkspace(bankKid: "fixture /\u00e6?&", userKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "revision": null, "name": null, "number": null, "deletedAtUtc": null, "deleteAtUtc": null, "locations": null, "tags": null, "attributes": null, "canWrite": false, "canCreate": false, "synchronization": null, "canDelete": false, "canRenameExternalId": false, "canRename": false, "iconKid": null, "availableIcons": null, "canEditIcon": false}));
    expect(sends, 1);
  });

  test("wire GetBankUserActivation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/fixture%20%2F%C3%A6%3F%26/activation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "name": null, "number": null, "activationCode": null, "qrCodeDataV1": null, "qrCodeDataV2": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getBankUserActivation(bankKid: "fixture /\u00e6?&", userKid: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "name": null, "number": null, "activationCode": null, "qrCodeDataV1": null, "qrCodeDataV2": null}));
    expect(sends, 1);
  });

  test("wire ExecuteBankUserCommand", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "POST");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/banks/fixture%20%2F%C3%A6%3F%26/users/fixture%20%2F%C3%A6%3F%26/commands");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.body, encodeApiJson(<String, Object?>{"action": null, "revision": null, "name": null, "number": null, "deleteAtUtc": null, "tagKid": null, "state": null, "locationKid": null, "attributes": null, "icon": null}));
      expect(request.headers['content-type'], contains('application/json'));
      return http.Response(encodeApiJson(<String, Object?>{"kid": null, "revision": null, "name": null, "number": null, "deletedAtUtc": null, "deleteAtUtc": null, "locations": null, "tags": null, "attributes": null, "canWrite": false, "canCreate": false, "synchronization": null, "canDelete": false, "canRenameExternalId": false, "canRename": false, "iconKid": null, "availableIcons": null, "canEditIcon": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.executeBankUserCommand(bankKid: "fixture /\u00e6?&", userKid: "fixture /\u00e6?&", body: <String, Object?>{"action": null, "revision": null, "name": null, "number": null, "deleteAtUtc": null, "tagKid": null, "state": null, "locationKid": null, "attributes": null, "icon": null});
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"kid": null, "revision": null, "name": null, "number": null, "deletedAtUtc": null, "deleteAtUtc": null, "locations": null, "tags": null, "attributes": null, "canWrite": false, "canCreate": false, "synchronization": null, "canDelete": false, "canRenameExternalId": false, "canRename": false, "iconKid": null, "availableIcons": null, "canEditIcon": false}));
    expect(sends, 1);
  });

  test("wire GetUserExportCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/users/export-count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUserExportCount(filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993')}));
    expect(sends, 1);
  });

  test("wire GetUsers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/users");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["filter"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["sort"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["direction"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["enabledOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "scanLimitReached": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUsers(pageSize: 7, cursor: "fixture", filter: "fixture", sort: "fixture", direction: "fixture", enabledOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "scanLimitReached": false}));
    expect(sends, 1);
  });

  test("wire GetUserCount", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/users/count");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");

      return http.Response(encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUserCount();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"count": BigInt.parse('9007199254740993'), "iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetUserReceipts", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/users/fixture%20%2F%C3%A6%3F%26/receipts");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["offset"], <Object?>["7"]);
      expect(request.url.queryParametersAll["revision"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"userKid": null, "revision": null, "items": null, "nextOffset": null, "periodCount": 7}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getUserReceipts(userKid: "fixture /\u00e6?&", offset: 7, revision: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"userKid": null, "revision": null, "items": null, "nextOffset": null, "periodCount": 7}));
    expect(sends, 1);
  });

  test("wire SearchUsers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/users");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["kidOnly"], <Object?>["false"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchUsers(q: "fixture", kidOnly: false);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire SearchUserSms", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/user-sms");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchUserSms(q: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire SearchUserActivation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/search/user-activation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], "Bearer fixture-token");
      expect(request.url.queryParametersAll["q"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "hasMore": false}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.searchUserActivation(q: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "hasMore": false}));
    expect(sends, 1);
  });

  test("wire GetPortalAppDownloadPage", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/download");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPortalAppDownloadPage();
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire DownloadPortalWindowsAppInstaller", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/download/windows/fixture%20%2F%C3%A6%3F%26/portal.appinstaller");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.downloadPortalWindowsAppInstaller(architecture: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire DownloadPortalWindowsPackage", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/download/windows/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.downloadPortalWindowsPackage(architecture: "fixture /\u00e6?&", fileName: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetCircleGradient", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/circles/gradient/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCircleGradient(colors: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetCircleGradientSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/circles/gradient/fixture%20%2F%C3%A6%3F%26/7x7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCircleGradientSized(colors: "fixture /\u00e6?&", width: 7, height: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetCircleProgress", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/circles/progress/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCircleProgress(background: "fixture /\u00e6?&", colors: "fixture /\u00e6?&", percent: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetCircleProgressSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/circles/progress/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7/7x7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCircleProgressSized(background: "fixture /\u00e6?&", colors: "fixture /\u00e6?&", percent: 7, width: 7, height: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetCircleRunning", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/circles/running/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCircleRunning(color: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetCircleRunningSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/circles/running/fixture%20%2F%C3%A6%3F%26/7x7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getCircleRunningSized(color: "fixture /\u00e6?&", width: 7, height: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetLinearGradient", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/gradients/linear/fixture%20%2F%C3%A6%3F%26/1.25.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLinearGradient(colors: "fixture /\u00e6?&", angle: 1.25);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetLinearGradientSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/gradients/linear/fixture%20%2F%C3%A6%3F%26/1.25/7x7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getLinearGradientSized(colors: "fixture /\u00e6?&", angle: 1.25, width: 7, height: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetIconPresentation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/icon/presentation");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.url.queryParametersAll["iconKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["text"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["count"], <Object?>["9007199254740993"]);
      expect(request.url.queryParametersAll["color"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"iconKid": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getIconPresentation(iconKid: "fixture", text: "fixture", count: BigInt.parse('9007199254740993'), color: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"iconKid": null}));
    expect(sends, 1);
  });

  test("wire GetIconAssetCatalog", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/icon/catalog/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<Object?>["fixture"]), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getIconAssetCatalog(iconSet: "fixture /\u00e6?&");
    expect(encodeApiJson(result), encodeApiJson(<Object?>["fixture"]));
    expect(sends, 1);
  });

  test("wire GetIconFromSet", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/icon/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26.fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getIconFromSet(iconSet: "fixture /\u00e6?&", kid: "fixture /\u00e6?&", format: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetIconImageFromSet", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/icon/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getIconImageFromSet(iconSet: "fixture /\u00e6?&", kid: "fixture /\u00e6?&", size: 7, format: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetIconImageWithBackgroundFromSet", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/icon/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getIconImageWithBackgroundFromSet(iconSet: "fixture /\u00e6?&", kid: "fixture /\u00e6?&", backColor: "fixture /\u00e6?&", size: 7, format: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogo", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogo(color: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoSized(color: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoWithBackground", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoWithBackground(color: "fixture /\u00e6?&", background: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoParts", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoParts(parts: "fixture /\u00e6?&", color: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoPartsSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoPartsSized(parts: "fixture /\u00e6?&", color: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoPartsWithBackground", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoPartsWithBackground(parts: "fixture /\u00e6?&", color: "fixture /\u00e6?&", background: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineText", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine-text/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineText(color: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineTextSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine-text/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineTextSized(color: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineTextWithBackground", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine-text/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineTextWithBackground(color: "fixture /\u00e6?&", background: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoText", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine-logo-text/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoText(color: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoTextSized", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine-logo-text/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoTextSized(color: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetKombineLogoTextWithBackground", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/logos/kombine-logo-text/fixture%20%2F%C3%A6%3F%26/fixture%20%2F%C3%A6%3F%26/7.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getKombineLogoTextWithBackground(color: "fixture /\u00e6?&", background: "fixture /\u00e6?&", width: 7);
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetPublicLiveMachines", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/statistics/live-machines");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<Object?>[<String, Object?>{"unitKid": null, "unitName": null, "locationName": null, "startedAtUtc": "2026-10-20T10:00:00Z", "doneAtUtc": null, "temperature": null}]), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicLiveMachines();
    expect(encodeApiJson(result), encodeApiJson(<Object?>[<String, Object?>{"unitKid": null, "unitName": null, "locationName": null, "startedAtUtc": "2026-10-20T10:00:00Z", "doneAtUtc": null, "temperature": null}]));
    expect(sends, 1);
  });

  test("wire GetPublicMachineErrors", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/widgets/machine-errors");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "refreshAfterSeconds": 7}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicMachineErrors(pageSize: 7, cursor: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"items": null, "nextCursor": null, "refreshAfterSeconds": 7}));
    expect(sends, 1);
  });

  test("wire GetPublicRecentCameraPhotos", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/camera/photos");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<Object?>[<String, Object?>{"thumbnailUrl": null, "workspacePath": null}]), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicRecentCameraPhotos();
    expect(encodeApiJson(result), encodeApiJson(<Object?>[<String, Object?>{"thumbnailUrl": null, "workspacePath": null}]));
    expect(sends, 1);
  });

  test("wire GetPublicCameraThumbnail", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/camera/photos/fixture%20%2F%C3%A6%3F%26/thumbnail");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicCameraThumbnail(id: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetPublicPurchasesChart", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/statistics/purchases/chart/fixture%20%2F%C3%A6%3F%26.svg");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response.bytes([1, 2, 3], 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicPurchasesChart(color: "fixture /\u00e6?&");
    expect(await result.chunks.expand((chunk) => chunk).toList(), [1, 2, 3]);
    expect(sends, 1);
  });

  test("wire GetPublicDisp73", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/displays/Map1");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.url.queryParametersAll["limit"], <Object?>["7"]);
      return http.Response(encodeApiJson(<String, Object?>{"measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "items": null, "heatmap": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicDisp73(limit: 7);
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "items": null, "heatmap": null}));
    expect(sends, 1);
  });

  test("wire GetPublicScopedUnitProgress", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/widgets/progress/fixture%20%2F%C3%A6%3F%26");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.url.queryParametersAll["pageSize"], <Object?>["7"]);
      expect(request.url.queryParametersAll["cursor"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"scopeKid": null, "scopeKind": null, "calculatedAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "items": null, "nextCursor": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicScopedUnitProgress(kid: "fixture /\u00e6?&", pageSize: 7, cursor: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"scopeKid": null, "scopeKind": null, "calculatedAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7, "items": null, "nextCursor": null}));
    expect(sends, 1);
  });

  test("wire GetPublicPurchases", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/statistics/purchases");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "lookbackHours": 7, "sinceUtc": "2026-10-20T10:00:00Z", "measuredAtUtc": "2026-10-20T10:00:00Z", "currencies": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicPurchases();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "lookbackHours": 7, "sinceUtc": "2026-10-20T10:00:00Z", "measuredAtUtc": "2026-10-20T10:00:00Z", "currencies": null}));
    expect(sends, 1);
  });

  test("wire GetPublicActiveUsers", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/statistics/active-users");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "lookbackDays": 7, "sinceUtc": "2026-10-20T10:00:00Z", "measuredAtUtc": "2026-10-20T10:00:00Z"}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicActiveUsers();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "lookbackDays": 7, "sinceUtc": "2026-10-20T10:00:00Z", "measuredAtUtc": "2026-10-20T10:00:00Z"}));
    expect(sends, 1);
  });

  test("wire GetPublicWashDocWidget", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/widgets/washdoc");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);
      expect(request.url.queryParametersAll["documentKid"], <Object?>["fixture"]);
      expect(request.url.queryParametersAll["unitKid"], <Object?>["fixture"]);
      return http.Response(encodeApiJson(<String, Object?>{"documentKid": null, "unitKid": null, "unitName": null, "locationName": null, "startedAtUtc": "2026-10-20T10:00:00Z", "endedAtUtc": null, "finished": false, "graphSvg": null, "refreshAfterSeconds": 7, "documentKidText": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicWashDocWidget(documentKid: "fixture", unitKid: "fixture");
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"documentKid": null, "unitKid": null, "unitName": null, "locationName": null, "startedAtUtc": "2026-10-20T10:00:00Z", "endedAtUtc": null, "finished": false, "graphSvg": null, "refreshAfterSeconds": 7, "documentKidText": null}));
    expect(sends, 1);
  });

  test("wire GetPublicWidgetPresentation", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/widgets");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<String, Object?>{"language": null, "colors": null, "background": null, "webBase": null, "labels": null, "googleMapsBrowserKey": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicWidgetPresentation();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"language": null, "colors": null, "background": null, "webBase": null, "labels": null, "googleMapsBrowserKey": null}));
    expect(sends, 1);
  });

  test("wire GetPublicReservations", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/statistics/reservations");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicReservations();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7}));
    expect(sends, 1);
  });

  test("wire GetPublicRunningMachines", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/public/statistics/running-machines");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPublicRunningMachines();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"tenantKid": null, "count": BigInt.parse('9007199254740993'), "measuredAtUtc": "2026-10-20T10:00:00Z", "refreshAfterSeconds": 7}));
    expect(sends, 1);
  });

  test("wire GetPortalStatus", () async {
    var sends = 0;
    final client = PortalClient('https://example.invalid/', httpClient: MockClient((request) async {
      sends++;
      expect(request.method, "GET");
      expect(request.url.origin, 'https://example.invalid');
      expect(request.url.toString().split('?').first, "https://example.invalid/api/v1/status");
      expect(request.followRedirects, isFalse);
      expect(request.headers['authorization'], isNull);

      return http.Response(encodeApiJson(<String, Object?>{"service": null, "status": null, "apiVersion": null}), 200);
    }));
    addTearDown(client.close); client.accessToken = 'fixture-token';
    final result = await client.getPortalStatus();
    expect(encodeApiJson(result), encodeApiJson(<String, Object?>{"service": null, "status": null, "apiVersion": null}));
    expect(sends, 1);
  });
}
