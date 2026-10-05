"""Generated wire models. Dictionary keys match JSON; dates remain ISO 8601 strings."""
from __future__ import annotations
from typing import Any, TypedDict, Required

AccountDocumentResponse = TypedDict('AccountDocumentResponse', {
    'key': 'str | None',
    'docId': 'int | None',
    'lines': 'list[AccountEntryResponse] | None',
    'totals': 'list[AccountTotal] | None',
}, total=False)

AccountEntryResponse = TypedDict('AccountEntryResponse', {
    'kid': 'str | None',
    'locationKid': 'str | None',
    'unitKid': 'str | None',
    'userKid': 'str | None',
    'recordedAtUtc': 'str',
    'amountMinor': 'int',
    'currency': 'str | None',
    'description': 'str | None',
    'transactionType': 'str | None',
    'period': 'int',
    'reversed': 'bool',
    'reversalOfKid': 'str | None',
    'userName': 'str | None',
    'userNumber': 'str | None',
    'locationName': 'str | None',
    'unitName': 'str | None',
    'canReverse': 'bool',
    'unitIconKid': 'str | None',
    'documentKey': 'str | None',
    'documentId': 'int | None',
    'isAnonymized': 'bool',
    'paymentKind': 'str | None',
}, total=False)

AccountResponse = TypedDict('AccountResponse', {
    'items': 'list[AccountEntryResponse] | None',
    'units': 'list[AccountUnitResponse] | None',
    'periods': 'list[int] | None',
    'totals': 'list[AccountTotal] | None',
    'from': 'str',
    'through': 'str',
    'timeZone': 'str | None',
    'period': 'int | None',
    'offset': 'int',
    'limit': 'int',
    'hasMore': 'bool',
    'revision': 'str | None',
    'documents': 'list[AccountDocumentResponse] | None',
}, total=False)

AccountRevisionResponse = TypedDict('AccountRevisionResponse', {
    'revision': 'str | None',
}, total=False)

AccountTotal = TypedDict('AccountTotal', {
    'currency': 'str | None',
    'entries': 'int',
    'amountMinor': 'int',
}, total=False)

AccountUnitResponse = TypedDict('AccountUnitResponse', {
    'locationKid': 'str | None',
    'unitKid': 'str | None',
    'locationName': 'str | None',
    'name': 'str | None',
}, total=False)

ActiveLocationCountResponse = TypedDict('ActiveLocationCountResponse', {
    'count': 'int',
    'iconKid': 'str | None',
}, total=False)

AssistantLink = TypedDict('AssistantLink', {
    'kid': 'str | None',
    'path': 'str | None',
    'name': 'str | None',
    'bankKid': 'str | None',
    'iconKid': 'str | None',
}, total=False)

AssistantMessage = TypedDict('AssistantMessage', {
    'role': 'str | None',
    'content': 'str | None',
}, total=False)

AssistantRequest = TypedDict('AssistantRequest', {
    'question': Required['str'],
    'history': 'list[AssistantMessage] | None',
}, total=False)

AssistantResponse = TypedDict('AssistantResponse', {
    'answer': 'str | None',
    'operations': 'list[str] | None',
    'links': 'list[AssistantLink] | None',
}, total=False)

BankDocumentItem = TypedDict('BankDocumentItem', {
    'kid': 'str | None',
    'locationKid': 'str | None',
    'unitKid': 'str | None',
    'locationName': 'str | None',
    'unitName': 'str | None',
    'unitType': 'int | None',
    'lastActivityUtc': 'str',
    'unitIconKid': 'str | None',
}, total=False)

BankDocumentPage = TypedDict('BankDocumentPage', {
    'items': 'list[BankDocumentItem] | None',
    'locations': 'list[BankLocationResponse] | None',
    'units': 'list[DocumentUnitOption] | None',
    'from': 'str',
    'through': 'str',
    'offset': 'int',
    'limit': 'int',
    'hasMore': 'bool',
}, total=False)

BankIconResponse = TypedDict('BankIconResponse', {
    'kid': 'str | None',
    'iconKid': 'str | None',
    'offline': 'bool | None',
    'status': 'int',
}, total=False)

BankIconsResponse = TypedDict('BankIconsResponse', {
    'items': 'list[BankIconResponse] | None',
}, total=False)

BankLocationResponse = TypedDict('BankLocationResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'iconKid': 'str | None',
}, total=False)

BankLocationStatusResponse = TypedDict('BankLocationStatusResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'enabled': 'bool',
    'deleted': 'bool | None',
    'deletedAt': 'str | None',
    'iconKid': 'str | None',
}, total=False)

BankNavigationResponse = TypedDict('BankNavigationResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'iconKid': 'str | None',
}, total=False)

BankUserResponse = TypedDict('BankUserResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'number': 'str | None',
    'deletedAt': 'str | None',
    'locations': 'list[UserLocationResponse] | None',
    'tags': 'list[UserTagResponse] | None',
    'attributes': 'list[UserAttributeResponse] | None',
    'email': 'str | None',
    'sms': 'str | None',
    'iconKid': 'str | None',
}, total=False)

BankUsersResponse = TypedDict('BankUsersResponse', {
    'items': 'list[BankUserResponse] | None',
    'previousCursor': 'str | None',
    'nextCursor': 'str | None',
    'scanLimitReached': 'bool',
}, total=False)

BookingCommand = TypedDict('BookingCommand', {
    'action': 'str | None',
}, total=False)

BookingResponse = TypedDict('BookingResponse', {
    'kid': 'str | None',
    'locationKid': 'str | None',
    'unitKid': 'str | None',
    'userKid': 'str | None',
    'startLocal': 'str | None',
    'endLocal': 'str | None',
    'weeklyMinute': 'int | None',
    'durationMinutes': 'int',
    'recordedAtUtc': 'str',
    'cancelled': 'bool',
    'synced': 'bool',
    'source': 'str | None',
    'userName': 'str | None',
    'userNumber': 'str | None',
    'locationName': 'str | None',
    'unitName': 'str | None',
    'canCancel': 'bool',
    'canRestore': 'bool',
    'unitIconKid': 'str | None',
}, total=False)

BookingRuleUnit = TypedDict('BookingRuleUnit', {
    'kid': 'str | None',
    'name': 'str | None',
}, total=False)

BookingUnitResponse = TypedDict('BookingUnitResponse', {
    'locationKid': 'str | None',
    'unitKid': 'str | None',
    'locationName': 'str | None',
    'name': 'str | None',
}, total=False)

BookingsResponse = TypedDict('BookingsResponse', {
    'items': 'list[BookingResponse] | None',
    'units': 'list[BookingUnitResponse] | None',
    'from': 'str',
    'through': 'str',
    'offset': 'int',
    'limit': 'int',
    'hasMore': 'bool',
}, total=False)

DatabaseAccessResponse = TypedDict('DatabaseAccessResponse', {
    'canWrite': 'bool | None',
    'checkedAtUtc': 'str',
}, total=False)

DocumentCell = TypedDict('DocumentCell', {
    'value': 'float | None',
    'text': 'str | None',
    'isCalculated': 'bool',
}, total=False)

DocumentColumn = TypedDict('DocumentColumn', {
    'kind': 'str | None',
    'name': 'str | None',
    'localization': 'str | None',
    'color': 'str | None',
    'onlyNumericValues': 'bool',
    'iconKid': 'str | None',
}, total=False)

DocumentTable = TypedDict('DocumentTable', {
    'documentKid': 'str | None',
    'unitKid': 'str | None',
    'unitName': 'str | None',
    'finished': 'bool',
    'fromMs2000': 'int',
    'toMs2000': 'int',
    'columns': 'list[DocumentColumn] | None',
    'rows': 'list[DocumentTableRow] | None',
}, total=False)

DocumentTableRow = TypedDict('DocumentTableRow', {
    'ms2000': 'int',
    'cells': 'list[DocumentCell] | None',
}, total=False)

DocumentUnitOption = TypedDict('DocumentUnitOption', {
    'kid': 'str | None',
    'locationKid': 'str | None',
    'name': 'str | None',
    'unitType': 'int | None',
}, total=False)

HostingBandwidth = TypedDict('HostingBandwidth', {
    'dateUtc': 'str',
    'bytes': 'str | None',
    'errorCode': 'str | None',
}, total=False)

HostingLogsResponse = TypedDict('HostingLogsResponse', {
    'environment': 'str | None',
    'application': 'str | None',
    'fetchedAtUtc': 'str',
    'lines': 'list[str] | None',
    'truncated': 'bool',
}, total=False)

HostingMetric = TypedDict('HostingMetric', {
    'name': 'str | None',
    'unit': 'str | None',
    'series': 'list[HostingSeries] | None',
    'errorCode': 'str | None',
}, total=False)

HostingMetricsResponse = TypedDict('HostingMetricsResponse', {
    'environment': 'str | None',
    'application': 'str | None',
    'fromUtc': 'str',
    'toUtc': 'str',
    'fetchedAtUtc': 'str',
    'refreshAfterSeconds': 'int',
    'metrics': 'list[HostingMetric] | None',
    'bandwidth': 'HostingBandwidth',
}, total=False)

HostingPoint = TypedDict('HostingPoint', {
    'timestampUtc': 'str',
    'value': 'float | None',
}, total=False)

HostingSeries = TypedDict('HostingSeries', {
    'component': 'str | None',
    'instance': 'str | None',
    'points': 'list[HostingPoint] | None',
}, total=False)

InstallerDetailsResponse = TypedDict('InstallerDetailsResponse', {
    'installer': 'InstallerDirectoryItem',
    'canEditIcon': 'bool',
    'iconRevision': 'str | None',
    'availableIcons': 'list[str] | None',
}, total=False)

InstallerDirectoryItem = TypedDict('InstallerDirectoryItem', {
    'kid': 'str | None',
    'name': 'str | None',
    'email': 'str | None',
    'locations': 'list[InstallerLocationResponse] | None',
    'tags': 'list[InstallerTagResponse] | None',
    'deleted': 'bool',
    'deletedAt': 'str | None',
    'enabled': 'bool | None',
    'lastActiveAt': 'str | None',
    'iconKid': 'str | None',
}, total=False)

InstallerDirectoryResponse = TypedDict('InstallerDirectoryResponse', {
    'items': 'list[InstallerDirectoryItem] | None',
    'nextCursor': 'str | None',
}, total=False)

InstallerIconRequest = TypedDict('InstallerIconRequest', {
    'icon': Required['str | None'],
    'expectedRevision': Required['str | None'],
}, total=False)

InstallerIconResponse = TypedDict('InstallerIconResponse', {
    'kid': 'str | None',
    'iconRevision': 'str | None',
    'availableIcons': 'list[str] | None',
    'iconKid': 'str | None',
}, total=False)

InstallerLocationResponse = TypedDict('InstallerLocationResponse', {
    'kid': 'str | None',
    'state': 'str | None',
}, total=False)

InstallerTagResponse = TypedDict('InstallerTagResponse', {
    'kid': 'str | None',
    'state': 'str | None',
}, total=False)

LiveLogCard = TypedDict('LiveLogCard', {
    'server': 'str | None',
    'errorCode': 'str | None',
    'events': 'list[LiveLogEvent] | None',
}, total=False)

LiveLogEvent = TypedDict('LiveLogEvent', {
    'timestamp': 'str',
    'level': 'str | None',
    'message': 'str | None',
    'category': 'str | None',
    'statusCode': 'int | None',
    'elapsedMilliseconds': 'int | None',
    'bankId': 'int | None',
    'userIds': 'list[int] | None',
    'traceId': 'str | None',
    'question': 'str | None',
    'fields': 'dict[str, Any] | None',
}, total=False)

LiveLogsResponse = TypedDict('LiveLogsResponse', {
    'tenantKid': 'str | None',
    'fetchedAtUtc': 'str',
    'refreshAfterSeconds': 'int',
    'servers': 'list[LiveLogCard] | None',
}, total=False)

LocationBookingRule = TypedDict('LocationBookingRule', {
    'code': 'str | None',
    'text': 'str | None',
    'warning': 'bool',
    'parts': 'list[LocationBookingRulePart] | None',
}, total=False)

LocationBookingRuleGroup = TypedDict('LocationBookingRuleGroup', {
    'name': 'str | None',
    'units': 'list[BookingRuleUnit] | None',
    'rules': 'list[LocationBookingRule] | None',
    'common': 'bool',
    'help': 'str | None',
}, total=False)

LocationBookingRulePart = TypedDict('LocationBookingRulePart', {
    'text': 'str | None',
    'isValue': 'bool',
}, total=False)

LocationBookingRulesResponse = TypedDict('LocationBookingRulesResponse', {
    'locationKid': 'str | None',
    'calculatedAt': 'str',
    'groups': 'list[LocationBookingRuleGroup] | None',
}, total=False)

LocationDirectoryItem = TypedDict('LocationDirectoryItem', {
    'kid': 'str | None',
    'bankKid': 'str | None',
    'bankName': 'str | None',
    'name': 'str | None',
    'vismaCustNo': 'str | None',
    'bankActivationCode': 'str | None',
    'locationActivationCode': 'str | None',
    'enabled': 'bool',
    'deleted': 'bool | None',
    'deletedAt': 'str | None',
    'address': 'str | None',
    'zip': 'str | None',
    'longitude': 'float | None',
    'latitude': 'float | None',
    'teltonikaSms': 'str | None',
    'alternativeBankName': 'str | None',
    'mask': 'str | None',
    'timeZone': 'str | None',
    'online': 'bool | None',
    'lastContactAt': 'str | None',
    'vismaCrAcNo': 'str | None',
    'vismaInvoiceVersion': 'str | None',
    'vismaOrdre': 'str | None',
    'vismaPNTurnover': 'str | None',
    'vismaPNSettlement': 'str | None',
    'vismaSettlement': 'str | None',
    'vismaVAT': 'str | None',
    'vismaServiceKey': 'str | None',
    'vismaStart': 'str | None',
    'vismaNote': 'str | None',
    'hiddenNote': 'str | None',
    'vismaGuaranteeMonth': 'str | None',
    'vismaGuaranteeUnder': 'str | None',
    'vismaGuarantee': 'str | None',
    'vismaGuaranteeCustomer': 'str | None',
    'vismaGuaranteeOver': 'str | None',
    'gift': 'str | None',
    'giftBegin': 'str | None',
    'giftEnd': 'str | None',
    'giftSplit': 'str | None',
    'giftPN': 'str | None',
    'iconKid': 'str | None',
    'bankIconKid': 'str | None',
}, total=False)

LocationDirectoryResponse = TypedDict('LocationDirectoryResponse', {
    'items': 'list[LocationDirectoryItem] | None',
    'nextCursor': 'str | None',
    'hasAllBanksAccess': 'bool',
    'fields': 'list[str] | None',
}, total=False)

LocationIconResponse = TypedDict('LocationIconResponse', {
    'kid': 'str | None',
    'iconKid': 'str | None',
    'offline': 'bool | None',
    'status': 'int',
}, total=False)

LocationIconsResponse = TypedDict('LocationIconsResponse', {
    'items': 'list[LocationIconResponse] | None',
}, total=False)

LocationOpeningHoursResponse = TypedDict('LocationOpeningHoursResponse', {
    'locationKid': 'str | None',
    'timeZone': 'str | None',
    'calculatedAt': 'str',
    'groups': 'list[OpeningHoursGroup] | None',
}, total=False)

LocationUnitsResponse = TypedDict('LocationUnitsResponse', {
    'location': 'BankLocationResponse',
    'items': 'list[UnitOverviewResponse] | None',
}, total=False)

ManagerDirectoryItem = TypedDict('ManagerDirectoryItem', {
    'kid': 'str | None',
    'name': 'str | None',
    'email': 'str | None',
    'resourceGrants': 'list[ManagerResourceGrantResponse] | None',
    'tabs': 'list[ManagerTabResponse] | None',
    'iconKid': 'str | None',
    'organisation': 'str | None',
    'enabled': 'bool | None',
    'deleted': 'bool',
    'deletedAt': 'str | None',
    'lastActiveAt': 'str | None',
    'operationPermissions': 'list[ManagerOperationPermissionResponse] | None',
    'retentionDays': 'int',
    'isCurrentManager': 'bool',
    'canEditPermissions': 'bool',
    'canEditTabs': 'bool',
    'canEditProfile': 'bool',
    'profileRevision': 'str | None',
    'tabsRevision': 'str | None',
    'kidsRevision': 'str | None',
    'canEditKids': 'bool',
    'availableTabs': 'list[ManagerTabResponse] | None',
    'availableIcons': 'list[str] | None',
}, total=False)

ManagerDirectoryResponse = TypedDict('ManagerDirectoryResponse', {
    'items': 'list[ManagerDirectoryItem] | None',
    'nextCursor': 'str | None',
}, total=False)

ManagerForgotPasswordRequest = TypedDict('ManagerForgotPasswordRequest', {
    'email': Required['str'],
    'language': 'str | None',
}, total=False)

ManagerInvitationRequest = TypedDict('ManagerInvitationRequest', {
    'expectedRevision': Required['str'],
    'language': 'str | None',
}, total=False)

ManagerInvitationResponse = TypedDict('ManagerInvitationResponse', {
    'code': 'str | None',
}, total=False)

ManagerKidChangeRequest = TypedDict('ManagerKidChangeRequest', {
    'resourceKid': Required['str | None'],
    'enabled': 'bool | None',
    'expectedRevision': Required['str | None'],
}, total=False)

ManagerKidChangeResponse = TypedDict('ManagerKidChangeResponse', {
    'resourceGrants': 'list[ManagerResourceGrantResponse] | None',
    'kidsRevision': 'str | None',
    'canEditKids': 'bool',
}, total=False)

ManagerLoginErrorResponse = TypedDict('ManagerLoginErrorResponse', {
    'code': 'str | None',
}, total=False)

ManagerLoginRequest = TypedDict('ManagerLoginRequest', {
    'email': Required['str'],
    'password': Required['str'],
}, total=False)

ManagerOperationPermissionResponse = TypedDict('ManagerOperationPermissionResponse', {
    'resource': 'str | None',
    'level': 'str | None',
    'canRead': 'bool',
    'canWrite': 'bool',
    'canCreate': 'bool',
    'flags': 'int | None',
    'canDelete': 'bool',
    'canRenameExternalId': 'bool',
    'canRename': 'bool',
}, total=False)

ManagerPasswordResetResponse = TypedDict('ManagerPasswordResetResponse', {
    'code': 'str | None',
}, total=False)

ManagerPermissionChangeRequest = TypedDict('ManagerPermissionChangeRequest', {
    'flag': 'int | None',
    'enabled': 'bool | None',
    'expectedFlags': Required['int | None'],
}, total=False)

ManagerPermissionRoleRequest = TypedDict('ManagerPermissionRoleRequest', {
    'role': Required['str | None'],
    'expectedFlags': Required['dict[str, int | None] | None'],
    'expectedTabsRevision': 'str | None',
}, total=False)

ManagerPermissionRoleResponse = TypedDict('ManagerPermissionRoleResponse', {
    'role': 'str | None',
    'operationPermissions': 'list[ManagerOperationPermissionResponse] | None',
    'canEditPermissions': 'bool',
    'tabs': 'list[ManagerTabResponse] | None',
    'tabsRevision': 'str | None',
    'canEditTabs': 'bool',
}, total=False)

ManagerProfileChangeRequest = TypedDict('ManagerProfileChangeRequest', {
    'value': Required['Any'],
    'expectedRevision': Required['str | None'],
}, total=False)

ManagerProfileChangeResponse = TypedDict('ManagerProfileChangeResponse', {
    'field': Required['str | None'],
    'name': Required['str | None'],
    'organisation': Required['str | None'],
    'email': Required['str | None'],
    'iconKid': Required['str | None'],
    'availableIcons': 'list[str] | None',
    'enabled': 'bool | None',
    'deleted': 'bool',
    'deletedMs2000': 'int',
    'deletedAt': 'str | None',
    'retentionDays': 'int',
    'profileRevision': Required['str | None'],
    'canEditProfile': 'bool',
}, total=False)

ManagerProfileResponse = TypedDict('ManagerProfileResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'tabs': 'list[int] | None',
    'hasBankAccess': 'bool',
    'iconKid': 'str | None',
    'databaseAccess': 'DatabaseAccessResponse',
    'navigationBanks': 'list[BankNavigationResponse] | None',
    'organisation': 'str | None',
    'retentionDays': 'int',
    'themeMode': 'EThemeMode',
    'iconSet': 'str | None',
    'tabDetails': 'list[ManagerTabResponse] | None',
    'resourceGrants': 'list[ManagerResourceGrantResponse] | None',
    'operationPermissions': 'list[ManagerOperationPermissionResponse] | None',
}, total=False)

ManagerResetPasswordRequest = TypedDict('ManagerResetPasswordRequest', {
    'token': Required['str'],
    'password': Required['str'],
    'confirmPassword': Required['str'],
}, total=False)

ManagerResourceGrantResponse = TypedDict('ManagerResourceGrantResponse', {
    'kid': 'str | None',
    'scope': 'str | None',
}, total=False)

ManagerSessionResponse = TypedDict('ManagerSessionResponse', {
    'accessToken': 'str | None',
    'expiresIn': 'int',
    'tokenType': 'str | None',
}, total=False)

ManagerTabChangeRequest = TypedDict('ManagerTabChangeRequest', {
    'enabled': 'bool | None',
    'expectedRevision': Required['str | None'],
}, total=False)

ManagerTabChangeResponse = TypedDict('ManagerTabChangeResponse', {
    'tabs': 'list[ManagerTabResponse] | None',
    'tabsRevision': 'str | None',
    'canEditTabs': 'bool',
    'canEditPermissions': 'bool',
}, total=False)

ManagerTabResponse = TypedDict('ManagerTabResponse', {
    'id': 'int',
    'name': 'str | None',
    'iconKid': 'str | None',
}, total=False)

ManagerThemeRequest = TypedDict('ManagerThemeRequest', {
    'themeMode': Required['EThemeMode'],
}, total=False)

ManagerThemeResponse = TypedDict('ManagerThemeResponse', {
    'themeMode': 'EThemeMode',
}, total=False)

ObjectAddressResponse = TypedDict('ObjectAddressResponse', {
    'kid': 'str | None',
    'address': 'str | None',
    'zip': 'str | None',
    'latitude': 'int | None',
    'longitude': 'int | None',
    'autoLatitudeLongitude': 'int | None',
    'revision': 'str | None',
    'outcome': 'str | None',
    'canWrite': 'bool',
}, total=False)

ObjectAddressRevisionRequest = TypedDict('ObjectAddressRevisionRequest', {
    'expectedRevision': Required['str | None'],
}, total=False)

OpeningHoursGroup = TypedDict('OpeningHoursGroup', {
    'units': 'list[OpeningHoursUnit] | None',
    'weekly': 'list[OpeningHoursLine] | None',
    'exceptions': 'list[OpeningHoursLine] | None',
    'isOpenNow': 'bool | None',
    'nextChange': 'str | None',
}, total=False)

OpeningHoursLine = TypedDict('OpeningHoursLine', {
    'label': 'str | None',
    'status': 'str | None',
    'opens': 'str | None',
    'closes': 'str | None',
    'closesNextDay': 'bool',
    'daysOfWeek': 'list[int] | None',
    'date': 'str | None',
}, total=False)

OpeningHoursUnit = TypedDict('OpeningHoursUnit', {
    'kid': 'str | None',
    'name': 'str | None',
}, total=False)

PersonalAccountResult = TypedDict('PersonalAccountResult', {
    'code': 'str | None',
}, total=False)

PersonalEmailConfirmation = TypedDict('PersonalEmailConfirmation', {
    'token': Required['str | None'],
}, total=False)

PersonalEmailRequest = TypedDict('PersonalEmailRequest', {
    'email': Required['str | None'],
    'currentPassword': Required['str | None'],
    'language': 'str | None',
}, total=False)

PersonalManagerProfile = TypedDict('PersonalManagerProfile', {
    'kid': 'str | None',
    'name': 'str | None',
    'organisation': 'str | None',
    'iconKid': 'str | None',
    'email': 'str | None',
    'emailVerified': 'bool',
    'themeMode': 'EThemeMode',
    'revision': 'str | None',
    'availableIcons': 'list[str] | None',
    'retentionDays': 'int',
    'iconSet': 'str | None',
}, total=False)

PersonalManagerTab = TypedDict('PersonalManagerTab', {
    'id': 'int',
    'name': 'str | None',
}, total=False)

PersonalManagerTabs = TypedDict('PersonalManagerTabs', {
    'kid': 'str | None',
    'tabs': 'list[PersonalManagerTab] | None',
    'availableTabs': 'list[PersonalManagerTab] | None',
    'revision': 'str | None',
    'canEdit': 'bool',
}, total=False)

PersonalPasswordRequest = TypedDict('PersonalPasswordRequest', {
    'currentPassword': Required['str | None'],
    'password': Required['str | None'],
    'confirmPassword': Required['str | None'],
    'language': 'str | None',
}, total=False)

PersonalProfileRequest = TypedDict('PersonalProfileRequest', {
    'revision': Required['str | None'],
    'value': Required['Any'],
}, total=False)

PersonalTabRequest = TypedDict('PersonalTabRequest', {
    'revision': Required['str | None'],
    'enabled': Required['bool'],
}, total=False)

ProblemDetails = TypedDict('ProblemDetails', {
    'type': 'str | None',
    'title': 'str | None',
    'status': 'int | None',
    'detail': 'str | None',
    'instance': 'str | None',
}, total=False)

SearchResult = TypedDict('SearchResult', {
    'kid': 'str | None',
    'kind': 'str | None',
    'name': 'str | None',
    'zip': 'str | None',
    'matchedSetting': 'str | None',
    'matchedValue': 'str | None',
    'isContext': 'bool',
    'number': 'str | None',
    'iconKid': 'str | None',
}, total=False)

SearchResults = TypedDict('SearchResults', {
    'items': 'list[SearchResult] | None',
    'hasMore': 'bool',
}, total=False)

ServiceApiKeyRequest = TypedDict('ServiceApiKeyRequest', {
    'expectedRevision': Required['str | None'],
}, total=False)

ServiceApiKeyResponse = TypedDict('ServiceApiKeyResponse', {
    'apiKey': 'str | None',
    'details': 'ServiceDetailsResponse',
}, total=False)

ServiceDetailsResponse = TypedDict('ServiceDetailsResponse', {
    'service': 'ServiceDirectoryItem',
    'hasApiKeyHash': 'bool',
    'apiKeyHash': 'str | None',
    'canEdit': 'bool',
    'profileRevision': 'str | None',
    'availableIcons': 'list[str] | None',
}, total=False)

ServiceDirectoryItem = TypedDict('ServiceDirectoryItem', {
    'kid': 'str | None',
    'identity': 'str | None',
    'name': 'str | None',
    'iconName': 'str | None',
    'iconKid': 'str | None',
}, total=False)

ServiceDirectoryResponse = TypedDict('ServiceDirectoryResponse', {
    'items': 'list[ServiceDirectoryItem] | None',
    'nextCursor': 'str | None',
}, total=False)

ServiceProfileRequest = TypedDict('ServiceProfileRequest', {
    'value': Required['str | None'],
    'expectedRevision': Required['str | None'],
}, total=False)

SetObjectCoordinateProvenanceRequest = TypedDict('SetObjectCoordinateProvenanceRequest', {
    'value': Required['int'],
    'expectedRevision': Required['str | None'],
}, total=False)

SetObjectCoordinatesRequest = TypedDict('SetObjectCoordinatesRequest', {
    'latitude': Required['int'],
    'longitude': Required['int'],
    'expectedRevision': Required['str | None'],
}, total=False)

SettlementDetailResponse = TypedDict('SettlementDetailResponse', {
    'kid': 'str | None',
    'period': 'int',
    'sourceEntries': 'int',
    'includedEntries': 'int',
    'groups': 'list[SettlementGroupResponse] | None',
    'formats': 'list[str] | None',
}, total=False)

SettlementGroupResponse = TypedDict('SettlementGroupResponse', {
    'group': 'str | None',
    'currency': 'str | None',
    'entries': 'int',
    'amountMinor': 'int',
}, total=False)

SettlementHistoryResponse = TypedDict('SettlementHistoryResponse', {
    'kid': 'str | None',
    'nextSettlement': 'str | None',
    'periods': 'list[SettlementPeriodResponse] | None',
    'nextBeforePeriod': 'int | None',
}, total=False)

SettlementPeriodResponse = TypedDict('SettlementPeriodResponse', {
    'period': 'int',
    'settlementDate': 'str | None',
    'settlementRun': 'str | None',
    'firstTransaction': 'str | None',
    'lastTransaction': 'str | None',
    'amountMinor': 'int | None',
    'transactionCount': 'int | None',
}, total=False)

TenantStatusItem = TypedDict('TenantStatusItem', {
    'kind': 'str | None',
    'kid': 'str | None',
    'bankKid': 'str | None',
    'locationKid': 'str | None',
    'bankName': 'str | None',
    'locationName': 'str | None',
    'unitName': 'str | None',
    'computerName': 'str | None',
    'bankType': 'str | None',
    'unitType': 'int | None',
    'errorId': 'int | None',
    'timestampUtc': 'str',
    'iconKid': 'str | None',
    'bankIconKid': 'str | None',
    'locationIconKid': 'str | None',
}, total=False)

TenantStatusPageResponse = TypedDict('TenantStatusPageResponse', {
    'status': 'TenantStatusResponse',
    'offset': 'int',
    'totalCount': 'int',
    'previousCursor': 'str | None',
    'nextCursor': 'str | None',
}, total=False)

TenantStatusResponse = TypedDict('TenantStatusResponse', {
    'measuredAtUtc': 'str',
    'refreshAfterSeconds': 'int',
    'sources': 'list[TenantStatusSourceResult] | None',
    'items': 'list[TenantStatusItem] | None',
}, total=False)

TenantStatusSourceResult = TypedDict('TenantStatusSourceResult', {
    'kind': 'str | None',
    'count': 'int',
    'hasMore': 'bool',
    'errorCode': 'str | None',
}, total=False)

UnitDetailsResponse = TypedDict('UnitDetailsResponse', {
    'location': 'BankLocationResponse',
    'unit': 'UnitOverviewResponse',
    'descriptorAvailable': 'bool',
    'settingGroups': 'list[str] | None',
    'stateGroups': 'list[str] | None',
}, total=False)

UnitGroupFieldResponse = TypedDict('UnitGroupFieldResponse', {
    'name': 'str | None',
    'valueType': 'str | None',
    'scope': 'str | None',
    'valueStatus': 'str | None',
    'value': 'str | None',
    'ms2000': 'int | None',
    'canEdit': 'bool',
    'revision': 'str | None',
    'required': 'bool',
    'minimum': 'int | None',
    'maximum': 'int | None',
    'options': 'list[UnitSettingOption] | None',
    'sync': 'int | None',
    'changedBy': 'UnitSettingEditorResponse',
    'canReadHistory': 'bool',
    'hasHistory': 'bool',
}, total=False)

UnitGroupResponse = TypedDict('UnitGroupResponse', {
    'location': 'BankLocationResponse',
    'unit': 'UnitOverviewResponse',
    'kind': 'str | None',
    'group': 'str | None',
    'items': 'list[UnitGroupFieldResponse] | None',
}, total=False)

UnitIconResponse = TypedDict('UnitIconResponse', {
    'kid': 'str | None',
    'iconKid': 'str | None',
    'offline': 'bool | None',
    'status': 'int',
}, total=False)

UnitIconsResponse = TypedDict('UnitIconsResponse', {
    'items': 'list[UnitIconResponse] | None',
}, total=False)

UnitOverviewResponse = TypedDict('UnitOverviewResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'cycle': 'str | None',
    'cycleText': 'str | None',
    'unitType': 'int | None',
    'unitTypeName': 'str | None',
    'unitTypeSource': 'str | None',
    'iconKid': 'str | None',
    'progress': 'UnitProgressResponse',
}, total=False)

UnitProgressResponse = TypedDict('UnitProgressResponse', {
    'status': 'str | None',
    'percent': 'int | None',
    'remainingSeconds': 'int | None',
    'calculatedAtUtc': 'str',
}, total=False)

UnitSettingEditorResponse = TypedDict('UnitSettingEditorResponse', {
    'kid': 'str | None',
    'kind': 'str | None',
    'name': 'str | None',
    'iconKid': 'str | None',
}, total=False)

UnitSettingHistoryItem = TypedDict('UnitSettingHistoryItem', {
    'value': 'str | None',
    'ms2000': 'int',
    'sync': 'int | None',
    'changedBy': 'UnitSettingEditorResponse',
}, total=False)

UnitSettingHistoryResponse = TypedDict('UnitSettingHistoryResponse', {
    'unitKid': 'str | None',
    'group': 'str | None',
    'setting': 'str | None',
    'items': 'list[UnitSettingHistoryItem] | None',
    'nextBeforeMs2000': 'int | None',
}, total=False)

UnitSettingOption = TypedDict('UnitSettingOption', {
    'value': 'str | None',
    'label': 'str | None',
}, total=False)

UnitSettingRequest = TypedDict('UnitSettingRequest', {
    'value': Required['str | None'],
    'expectedRevision': Required['str | None'],
}, total=False)

UnitSettingResponse = TypedDict('UnitSettingResponse', {
    'unitKid': 'str | None',
    'group': 'str | None',
    'setting': 'str | None',
    'value': 'str | None',
    'ms2000': 'int',
    'revision': 'str | None',
    'sync': 'int | None',
    'changedBy': 'UnitSettingEditorResponse',
}, total=False)

UpdateObjectAddressRequest = TypedDict('UpdateObjectAddressRequest', {
    'address': Required['str | None'],
    'zip': Required['str | None'],
    'expectedRevision': Required['str | None'],
}, total=False)

UserActivationResponse = TypedDict('UserActivationResponse', {
    'kid': 'str | None',
    'name': 'str | None',
    'number': 'str | None',
    'activationCode': 'str | None',
    'qrCodeDataV1': 'str | None',
    'qrCodeDataV2': 'str | None',
}, total=False)

UserAttributeInput = TypedDict('UserAttributeInput', {
    'attribute': 'str | None',
    'value': 'int',
}, total=False)

UserAttributeResponse = TypedDict('UserAttributeResponse', {
    'attribute': 'str | None',
    'value': 'int',
}, total=False)

UserBalanceItem = TypedDict('UserBalanceItem', {
    'kid': 'str | None',
    'status': 'str | None',
    'currentBalanceMinor': 'int | None',
    'previousBalanceMinor': 'int | None',
    'previousPeriod': 'int | None',
    'previousPeriodIsProvisional': 'bool',
    'latestPostingMs2000': 'int | None',
    'hasActiveSubscription': 'bool | None',
    'balances': 'list[UserCurrencyBalanceItem] | None',
}, total=False)

UserBalancesRequest = TypedDict('UserBalancesRequest', {
    'userKids': Required['list[str]'],
}, total=False)

UserBalancesResponse = TypedDict('UserBalancesResponse', {
    'items': 'list[UserBalanceItem] | None',
}, total=False)

UserCommandRequest = TypedDict('UserCommandRequest', {
    'action': 'str | None',
    'revision': 'str | None',
    'name': 'str | None',
    'number': 'str | None',
    'deleteAtUtc': 'str | None',
    'tagKid': 'str | None',
    'state': 'str | None',
    'locationKid': 'str | None',
    'attributes': 'list[UserAttributeInput] | None',
    'icon': 'str | None',
}, total=False)

UserCurrencyBalanceItem = TypedDict('UserCurrencyBalanceItem', {
    'currency': 'str | None',
    'currentBalanceMinor': 'int',
    'previousBalanceMinor': 'int | None',
    'previousPeriod': 'int | None',
    'previousPeriodIsProvisional': 'bool',
}, total=False)

UserLocationResponse = TypedDict('UserLocationResponse', {
    'kid': 'str | None',
    'state': 'str | None',
    'name': 'str | None',
    'iconKid': 'str | None',
}, total=False)

UserNumberSuggestionResponse = TypedDict('UserNumberSuggestionResponse', {
    'bankKid': 'str | None',
    'number': 'str | None',
}, total=False)

UserReceipt = TypedDict('UserReceipt', {
    'key': 'str | None',
    'date': 'str',
    'locationKid': 'str | None',
    'locationName': 'str | None',
    'period': 'int',
    'provisional': 'bool',
    'kind': 'str | None',
    'currency': 'str | None',
    'totalMinor': 'int',
    'vatMinor': 'int | None',
    'balanceAfterMinor': 'int',
    'lines': 'list[UserReceiptLine] | None',
}, total=False)

UserReceiptLine = TypedDict('UserReceiptLine', {
    'kid': 'str | None',
    'occurredAt': 'str',
    'unitKid': 'str | None',
    'unitName': 'str | None',
    'texts': 'list[str] | None',
    'amountMinor': 'int',
    'calculated': 'bool',
}, total=False)

UserReceiptsResponse = TypedDict('UserReceiptsResponse', {
    'userKid': 'str | None',
    'revision': 'str | None',
    'items': 'list[UserReceipt] | None',
    'nextOffset': 'int | None',
    'periodCount': 'int',
}, total=False)

UserScopeState = TypedDict('UserScopeState', {
    'kid': 'str | None',
    'state': 'str | None',
}, total=False)

UserTagResponse = TypedDict('UserTagResponse', {
    'kid': 'str | None',
    'state': 'str | None',
}, total=False)

UserWorkspaceResponse = TypedDict('UserWorkspaceResponse', {
    'kid': 'str | None',
    'revision': 'str | None',
    'name': 'str | None',
    'number': 'str | None',
    'deletedAtUtc': 'str | None',
    'deleteAtUtc': 'str | None',
    'locations': 'list[UserScopeState] | None',
    'tags': 'list[UserScopeState] | None',
    'attributes': 'list[UserAttributeInput] | None',
    'canWrite': 'bool',
    'canCreate': 'bool',
    'synchronization': 'str | None',
    'canDelete': 'bool',
    'canRenameExternalId': 'bool',
    'canRename': 'bool',
    'iconKid': 'str | None',
    'availableIcons': 'list[str] | None',
    'canEditIcon': 'bool',
}, total=False)

ValidationProblemDetails = TypedDict('ValidationProblemDetails', {
    'type': 'str | None',
    'title': 'str | None',
    'status': 'int | None',
    'detail': 'str | None',
    'instance': 'str | None',
    'errors': 'dict[str, list[str]] | None',
}, total=False)

EThemeMode = int

ActiveUsersResponse = TypedDict('ActiveUsersResponse', {
    'tenantKid': 'str | None',
    'count': 'int',
    'lookbackDays': 'int',
    'sinceUtc': 'str',
    'measuredAtUtc': 'str',
}, total=False)

ApiStatusResponse = TypedDict('ApiStatusResponse', {
    'service': 'str | None',
    'status': 'str | None',
    'apiVersion': 'str | None',
}, total=False)

IconPresentationResponse = TypedDict('IconPresentationResponse', {
    'iconKid': 'str | None',
}, total=False)

PurchaseMapPoint = TypedDict('PurchaseMapPoint', {
    'kid': 'str | None',
    'latitude': 'float',
    'longitude': 'float',
    'timestampUtc': 'str',
    'amount': 'float',
}, total=False)

PurchaseMapSnapshot = TypedDict('PurchaseMapSnapshot', {
    'measuredAtUtc': 'str',
    'refreshAfterSeconds': 'int',
    'items': 'list[PurchaseMapPoint] | None',
}, total=False)

PurchasesResponse = TypedDict('PurchasesResponse', {
    'tenantKid': 'str | None',
    'count': 'int',
    'lookbackHours': 'int',
    'sinceUtc': 'str',
    'measuredAtUtc': 'str',
    'amount': 'float',
    'currency': 'str | None',
}, total=False)

