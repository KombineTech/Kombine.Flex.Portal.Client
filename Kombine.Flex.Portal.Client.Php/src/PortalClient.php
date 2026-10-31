<?php
declare(strict_types=1);

namespace Kombine\Flex\Portal;

/**
 * Generated wire models: associative arrays; missing and null values remain distinct.
 * @phpstan-type AccountDocumentResponse array{'key'?: string|null, 'docId'?: int|null, 'lines'?: list<AccountEntryResponse>|null, 'totals'?: list<AccountTotal>|null}
 * @phpstan-type AccountEntryResponse array{'kid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'userKid'?: string|null, 'recordedAtUtc'?: string, 'amountMinor'?: int, 'currency'?: string|null, 'description'?: string|null, 'transactionType'?: string|null, 'period'?: int, 'reversed'?: bool, 'reversalOfKid'?: string|null, 'userName'?: string|null, 'userNumber'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'canReverse'?: bool, 'unitIconKid'?: string|null, 'documentKey'?: string|null, 'documentId'?: int|null, 'isAnonymized'?: bool, 'paymentKind'?: string|null}
 * @phpstan-type AccountIconResponse array{'currency'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type AccountResponse array{'items'?: list<AccountEntryResponse>|null, 'units'?: list<AccountUnitResponse>|null, 'periods'?: list<int>|null, 'totals'?: list<AccountTotal>|null, 'from'?: string, 'through'?: string, 'timeZone'?: string|null, 'period'?: int|null, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool, 'revision'?: string|null, 'documents'?: list<AccountDocumentResponse>|null}
 * @phpstan-type AccountRevisionResponse array{'revision'?: string|null}
 * @phpstan-type AccountTotal array{'currency'?: string|null, 'entries'?: int, 'amountMinor'?: int}
 * @phpstan-type AccountUnitResponse array{'locationKid'?: string|null, 'unitKid'?: string|null, 'locationName'?: string|null, 'name'?: string|null}
 * @phpstan-type AcknowledgeErrorRequest array{'expectedRevision': string|null}
 * @phpstan-type ActiveBankCountResponse array{'count'?: int, 'iconKid'?: string|null}
 * @phpstan-type ActiveLocationCountResponse array{'count'?: int, 'iconKid'?: string|null}
 * @phpstan-type ActiveUnitCountResponse array{'count'?: int, 'iconKid'?: string|null}
 * @phpstan-type ApproveWallboardPairing array{'location'?: WallboardScanLocation}
 * @phpstan-type AssistantLink array{'kid'?: string|null, 'path'?: string|null, 'name'?: string|null, 'bankKid'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type AssistantMessage array{'role'?: string|null, 'content'?: string|null}
 * @phpstan-type AssistantRequest array{'question': string, 'history'?: list<AssistantMessage>|null}
 * @phpstan-type AssistantResponse array{'answer'?: string|null, 'operations'?: list<string>|null, 'links'?: list<AssistantLink>|null}
 * @phpstan-type BankDirectoryItem array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'fields'?: array<string,mixed>|null}
 * @phpstan-type BankDirectoryResponse array{'items'?: list<BankDirectoryItem>|null, 'nextCursor'?: string|null, 'fields'?: list<string>|null, 'canReadBankActivationCode'?: bool}
 * @phpstan-type BankDocumentItem array{'kid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int|null, 'lastActivityUtc'?: string, 'unitIconKid'?: string|null}
 * @phpstan-type BankDocumentPage array{'items'?: list<BankDocumentItem>|null, 'locations'?: list<BankLocationResponse>|null, 'units'?: list<DocumentUnitOption>|null, 'from'?: string, 'through'?: string, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool}
 * @phpstan-type BankIconResponse array{'kid'?: string|null, 'iconKid'?: string|null, 'offline'?: bool|null, 'status'?: int}
 * @phpstan-type BankIconsResponse array{'items'?: list<BankIconResponse>|null}
 * @phpstan-type BankLocationResponse array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type BankLocationStatusResponse array{'kid'?: string|null, 'name'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type BankNavigationResponse array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type BankUserResponse array{'kid'?: string|null, 'name'?: string|null, 'number'?: string|null, 'deletedAt'?: string|null, 'locations'?: list<UserLocationResponse>|null, 'tags'?: list<UserTagResponse>|null, 'attributes'?: list<UserAttributeResponse>|null, 'email'?: string|null, 'sms'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type BankUsersResponse array{'items'?: list<BankUserResponse>|null, 'previousCursor'?: string|null, 'nextCursor'?: string|null, 'scanLimitReached'?: bool}
 * @phpstan-type BookingCommand array{'action'?: string|null}
 * @phpstan-type BookingResponse array{'kid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'userKid'?: string|null, 'startLocal'?: string|null, 'endLocal'?: string|null, 'weeklyMinute'?: int|null, 'durationMinutes'?: int, 'recordedAtUtc'?: string, 'cancelled'?: bool, 'synced'?: bool, 'source'?: string|null, 'userName'?: string|null, 'userNumber'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'canCancel'?: bool, 'canRestore'?: bool, 'unitIconKid'?: string|null}
 * @phpstan-type BookingRuleUnit array{'kid'?: string|null, 'name'?: string|null}
 * @phpstan-type BookingUnitResponse array{'locationKid'?: string|null, 'unitKid'?: string|null, 'locationName'?: string|null, 'name'?: string|null}
 * @phpstan-type BookingsResponse array{'items'?: list<BookingResponse>|null, 'units'?: list<BookingUnitResponse>|null, 'from'?: string, 'through'?: string, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool}
 * @phpstan-type CameraAvailabilityResponse array{'hasCaptures'?: bool, 'isDegraded'?: bool, 'canCapture'?: bool}
 * @phpstan-type CameraCaptureItem array{'id'?: string|null, 'captureId'?: string|null, 'resourceKid'?: string|null, 'ownerKid'?: string|null, 'fileName'?: string|null, 'kind'?: string|null, 'capturedAtUtc'?: string, 'hasPreview'?: bool, 'hasMotion'?: bool, 'hasPlayback'?: bool, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null}
 * @phpstan-type CameraCapturePage array{'items'?: list<CameraCaptureItem>|null, 'nextCursor'?: string|null, 'isDegraded'?: bool}
 * @phpstan-type CameraConfirmationRequest array{'uploadToken'?: string|null}
 * @phpstan-type CameraConfirmationResponse array{'confirmed'?: bool, 'errorCode'?: string|null, 'processingPercent'?: int|null}
 * @phpstan-type CameraPrepareRequest array{'resourceKid'?: string|null, 'kind'?: string|null, 'originalFileName'?: string|null, 'originalNameAvailable'?: bool, 'capturedAtUtc'?: string, 'mediaLength'?: int, 'mediaSha256'?: string|null, 'sensorData'?: array<string,mixed>, 'motionLength'?: int|null, 'motionSha256'?: string|null}
 * @phpstan-type CameraPrepareResponse array{'uploadToken'?: string|null}
 * @phpstan-type CameraResourceResponse array{'resourceKid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'requiresProximityCheck'?: bool, 'latitude'?: int|float|null, 'longitude'?: int|float|null}
 * @phpstan-type CameraSaveResponse array{'captureId'?: string|null, 'resourceKid'?: string|null}
 * @phpstan-type ChecklistItem array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'period'?: int, 'isLatest'?: bool, 'bankName'?: string|null, 'locationName'?: string|null, 'hardware'?: string|null, 'periodDateUtc'?: string|null, 'nextSettlementUtc'?: string|null, 'lastRunUtc'?: string|null, 'updatedAtUtc'?: string|null, 'hidden'?: bool, 'onChecklist'?: bool, 'scheduleStatus'?: string|null, 'processing'?: ChecklistProcessing}
 * @phpstan-type ChecklistPage array{'items'?: list<ChecklistItem>|null, 'nextCursor'?: string|null, 'readAtUtc'?: string}
 * @phpstan-type ChecklistProcessing array{'invoice'?: ChecklistStatus, 'soapInvoice'?: ChecklistStatus, 'soapCredit'?: ChecklistStatus, 'easyPay'?: ChecklistStatus}
 * @phpstan-type ChecklistStatus array{'code'?: int|null, 'state'?: string|null}
 * @phpstan-type DatabaseAccessResponse array{'canWrite'?: bool|null, 'checkedAtUtc'?: string}
 * @phpstan-type DirectoryExportCountResponse array{'count'?: int}
 * @phpstan-type DocumentCell array{'value'?: int|float|null, 'text'?: string|null, 'isCalculated'?: bool}
 * @phpstan-type DocumentColumn array{'kind'?: string|null, 'name'?: string|null, 'localization'?: string|null, 'color'?: string|null, 'onlyNumericValues'?: bool, 'iconKid'?: string|null}
 * @phpstan-type DocumentNeighbor array{'kid'?: string|null, 'lastActivityUtc'?: string}
 * @phpstan-type DocumentNeighbors array{'previous'?: DocumentNeighbor, 'next'?: DocumentNeighbor}
 * @phpstan-type DocumentTable array{'cycleKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'finished'?: bool, 'fromMs2000'?: int, 'toMs2000'?: int, 'columns'?: list<DocumentColumn>|null, 'rows'?: list<DocumentTableRow>|null}
 * @phpstan-type DocumentTableRow array{'ms2000'?: int, 'cells'?: list<DocumentCell>|null}
 * @phpstan-type DocumentUnitOption array{'kid'?: string|null, 'locationKid'?: string|null, 'name'?: string|null, 'unitType'?: int|null}
 * @phpstan-type HostingBandwidth array{'dateUtc'?: string, 'bytes'?: string|null, 'errorCode'?: string|null}
 * @phpstan-type HostingLogsResponse array{'environment'?: string|null, 'application'?: string|null, 'fetchedAtUtc'?: string, 'lines'?: list<string>|null, 'truncated'?: bool}
 * @phpstan-type HostingMetric array{'name'?: string|null, 'unit'?: string|null, 'series'?: list<HostingSeries>|null, 'errorCode'?: string|null}
 * @phpstan-type HostingMetricsResponse array{'environment'?: string|null, 'application'?: string|null, 'fromUtc'?: string, 'toUtc'?: string, 'fetchedAtUtc'?: string, 'refreshAfterSeconds'?: int, 'metrics'?: list<HostingMetric>|null, 'bandwidth'?: HostingBandwidth}
 * @phpstan-type HostingPoint array{'timestampUtc'?: string, 'value'?: int|float|null}
 * @phpstan-type HostingSeries array{'component'?: string|null, 'instance'?: string|null, 'points'?: list<HostingPoint>|null}
 * @phpstan-type InstallerDetailsResponse array{'installer'?: InstallerDirectoryItem, 'canEditIcon'?: bool, 'iconRevision'?: string|null, 'availableIcons'?: list<string>|null}
 * @phpstan-type InstallerDirectoryItem array{'kid'?: string|null, 'name'?: string|null, 'email'?: string|null, 'locations'?: list<InstallerLocationResponse>|null, 'tags'?: list<InstallerTagResponse>|null, 'deleted'?: bool, 'deletedAt'?: string|null, 'enabled'?: bool|null, 'lastActiveAt'?: string|null, 'activationCode'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type InstallerDirectoryResponse array{'items'?: list<InstallerDirectoryItem>|null, 'nextCursor'?: string|null}
 * @phpstan-type InstallerIconRequest array{'icon': string|null, 'expectedRevision': string|null}
 * @phpstan-type InstallerIconResponse array{'kid'?: string|null, 'iconRevision'?: string|null, 'availableIcons'?: list<string>|null, 'iconKid'?: string|null}
 * @phpstan-type InstallerLocationResponse array{'kid'?: string|null, 'state'?: string|null}
 * @phpstan-type InstallerTagResponse array{'kid'?: string|null, 'state'?: string|null}
 * @phpstan-type LiveLogCard array{'server'?: string|null, 'errorCode'?: string|null, 'events'?: list<LiveLogEvent>|null}
 * @phpstan-type LiveLogEvent array{'timestamp'?: string, 'level'?: string|null, 'message'?: string|null, 'category'?: string|null, 'statusCode'?: int|null, 'elapsedMilliseconds'?: int|null, 'bankId'?: int|null, 'userIds'?: list<int>|null, 'traceId'?: string|null, 'question'?: string|null, 'fields'?: array<string,mixed>|null}
 * @phpstan-type LiveLogsResponse array{'tenantKid'?: string|null, 'fetchedAtUtc'?: string, 'refreshAfterSeconds'?: int, 'servers'?: list<LiveLogCard>|null}
 * @phpstan-type LocationBookingCalendarDayResponse array{'dayOfWeek'?: int, 'slots'?: list<LocationBookingCalendarSlotResponse>|null, 'date'?: string}
 * @phpstan-type LocationBookingCalendarGroup array{'units'?: list<LocationBookingCalendarUnit>|null, 'status'?: string|null, 'days'?: list<LocationBookingCalendarDayResponse>|null}
 * @phpstan-type LocationBookingCalendarSlotResponse array{'startMinute'?: int, 'durationMinutes'?: int, 'type'?: int}
 * @phpstan-type LocationBookingCalendarUnit array{'kid'?: string|null, 'name'?: string|null}
 * @phpstan-type LocationBookingCalendarsResponse array{'locationKid'?: string|null, 'groups'?: list<LocationBookingCalendarGroup>|null, 'timeZone'?: string|null, 'from'?: string, 'days'?: int}
 * @phpstan-type LocationBookingRule array{'code'?: string|null, 'text'?: string|null, 'warning'?: bool, 'parts'?: list<LocationBookingRulePart>|null}
 * @phpstan-type LocationBookingRuleGroup array{'name'?: string|null, 'units'?: list<BookingRuleUnit>|null, 'rules'?: list<LocationBookingRule>|null, 'common'?: bool, 'help'?: string|null}
 * @phpstan-type LocationBookingRulePart array{'text'?: string|null, 'isValue'?: bool}
 * @phpstan-type LocationBookingRulesResponse array{'locationKid'?: string|null, 'calculatedAt'?: string, 'groups'?: list<LocationBookingRuleGroup>|null}
 * @phpstan-type LocationCountResponse array{'count'?: int}
 * @phpstan-type LocationDirectoryItem array{'kid'?: string|null, 'bankKid'?: string|null, 'bankName'?: string|null, 'name'?: string|null, 'vismaCustNo'?: string|null, 'bankActivationCode'?: string|null, 'locationActivationCode'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'longitude'?: int|float|null, 'latitude'?: int|float|null, 'teltonikaSms'?: string|null, 'alternativeBankName'?: string|null, 'mask'?: string|null, 'timeZone'?: string|null, 'online'?: bool|null, 'lastContactAt'?: string|null, 'vismaCrAcNo'?: string|null, 'vismaInvoiceVersion'?: string|null, 'vismaOrdre'?: string|null, 'vismaPNTurnover'?: string|null, 'vismaPNSettlement'?: string|null, 'vismaSettlement'?: string|null, 'vismaVAT'?: string|null, 'vismaServiceKey'?: string|null, 'vismaStart'?: string|null, 'vismaNote'?: string|null, 'hiddenNote'?: string|null, 'vismaGuaranteeMonth'?: string|null, 'vismaGuaranteeUnder'?: string|null, 'vismaGuarantee'?: string|null, 'vismaGuaranteeCustomer'?: string|null, 'vismaGuaranteeOver'?: string|null, 'gift'?: string|null, 'giftBegin'?: string|null, 'giftEnd'?: string|null, 'giftSplit'?: string|null, 'giftPN'?: string|null, 'soapEnd'?: string|null, 'iconKid'?: string|null, 'bankIconKid'?: string|null}
 * @phpstan-type LocationDirectoryResponse array{'items'?: list<LocationDirectoryItem>|null, 'nextCursor'?: string|null, 'hasAllBanksAccess'?: bool, 'fields'?: list<string>|null}
 * @phpstan-type LocationIconResponse array{'kid'?: string|null, 'iconKid'?: string|null, 'offline'?: bool|null, 'status'?: int}
 * @phpstan-type LocationIconsResponse array{'items'?: list<LocationIconResponse>|null}
 * @phpstan-type LocationOpeningHoursResponse array{'locationKid'?: string|null, 'timeZone'?: string|null, 'calculatedAt'?: string, 'groups'?: list<OpeningHoursGroup>|null}
 * @phpstan-type LocationReservationHistoryItem array{'unitKid'?: string|null, 'startMinute'?: int, 'durationMinutes'?: int, 'revision'?: int, 'cancelled'?: bool, 'userNumber'?: string|null, 'userName'?: string|null, 'userKid'?: string|null}
 * @phpstan-type LocationReservationHistoryResponse array{'locationKid'?: string|null, 'from'?: string, 'days'?: int, 'items'?: list<LocationReservationHistoryItem>|null}
 * @phpstan-type LocationReservationResponse array{'unitKid'?: string|null, 'startMinute'?: int, 'durationMinutes'?: int, 'userNumber'?: string|null, 'userName'?: string|null, 'userKid'?: string|null}
 * @phpstan-type LocationReservationsResponse array{'locationKid'?: string|null, 'from'?: string, 'days'?: int, 'items'?: list<LocationReservationResponse>|null}
 * @phpstan-type LocationUnitsResponse array{'location'?: BankLocationResponse, 'items'?: list<UnitOverviewResponse>|null}
 * @phpstan-type LocationWeatherCurrent array{'observedAtUtc'?: string, 'retrievedAtUtc'?: string, 'temperatureCelsius'?: int|float, 'apparentTemperatureCelsius'?: int|float|null, 'windSpeedMetresPerSecond'?: int|float|null, 'precipitationMillimetres'?: int|float|null, 'relativeHumidityPercent'?: int|float|null, 'weatherCode'?: int|null, 'isDay'?: bool|null}
 * @phpstan-type LocationWeatherResponse array{'locationKid'?: string|null, 'status'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'positionSource'?: string|null, 'current'?: LocationWeatherCurrent|null}
 * @phpstan-type ManagerCreationResponse array{'kid'?: string|null}
 * @phpstan-type ManagerDirectoryItem array{'kid'?: string|null, 'name'?: string|null, 'email'?: string|null, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'tabs'?: list<ManagerTabResponse>|null, 'iconKid'?: string|null, 'gravatarUrl'?: string|null, 'organisation'?: string|null, 'enabled'?: bool|null, 'deleted'?: bool, 'deletedAt'?: string|null, 'lastActiveAt'?: string|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null, 'retentionDays'?: int, 'isCurrentManager'?: bool, 'canEditPermissions'?: bool, 'canEditTabs'?: bool, 'canEditProfile'?: bool, 'profileRevision'?: string|null, 'tabsRevision'?: string|null, 'kidsRevision'?: string|null, 'canEditKids'?: bool, 'availableTabs'?: list<ManagerTabResponse>|null, 'availableIcons'?: list<string>|null}
 * @phpstan-type ManagerDirectoryResponse array{'items'?: list<ManagerDirectoryItem>|null, 'nextCursor'?: string|null}
 * @phpstan-type ManagerEmailMatch array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'gravatarUrl'?: string|null}
 * @phpstan-type ManagerForgotPasswordRequest array{'email': string, 'language'?: string|null}
 * @phpstan-type ManagerInvitationRequest array{'expectedRevision': string, 'language'?: string|null}
 * @phpstan-type ManagerInvitationResponse array{'code'?: string|null}
 * @phpstan-type ManagerKidChangeRequest array{'resourceKid': string|null, 'enabled'?: bool|null, 'expectedRevision': string|null}
 * @phpstan-type ManagerKidChangeResponse array{'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'kidsRevision'?: string|null, 'canEditKids'?: bool}
 * @phpstan-type ManagerLoginErrorResponse array{'code'?: string|null}
 * @phpstan-type ManagerLoginRequest array{'email'?: string|null, 'password'?: string|null, 'kid'?: string|null, 'apiKey'?: string|null}
 * @phpstan-type ManagerOperationPermissionResponse array{'resource'?: string|null, 'level'?: string|null, 'canRead'?: bool, 'canWrite'?: bool, 'canCreate'?: bool, 'flags'?: int|null, 'canDelete'?: bool, 'canRenameExternalId'?: bool, 'canRename'?: bool}
 * @phpstan-type ManagerPasswordResetResponse array{'code'?: string|null}
 * @phpstan-type ManagerPermissionChangeRequest array{'flag'?: int|null, 'enabled'?: bool|null, 'expectedFlags': int|null}
 * @phpstan-type ManagerPermissionRoleRequest array{'role': string|null, 'expectedFlags': array<string,mixed>|null, 'expectedTabsRevision'?: string|null, 'expectedKidsRevision'?: string|null}
 * @phpstan-type ManagerPermissionRoleResponse array{'role'?: string|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null, 'canEditPermissions'?: bool, 'tabs'?: list<ManagerTabResponse>|null, 'tabsRevision'?: string|null, 'canEditTabs'?: bool, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'kidsRevision'?: string|null, 'canEditKids'?: bool}
 * @phpstan-type ManagerProfileChangeRequest array{'value': mixed, 'expectedRevision': string|null}
 * @phpstan-type ManagerProfileChangeResponse array{'field': string|null, 'name': string|null, 'organisation': string|null, 'email': string|null, 'iconKid': string|null, 'gravatarUrl'?: string|null, 'availableIcons'?: list<string>|null, 'enabled'?: bool|null, 'deleted'?: bool, 'deletedMs2000'?: int, 'deletedAt'?: string|null, 'retentionDays'?: int, 'profileRevision': string|null, 'canEditProfile'?: bool}
 * @phpstan-type ManagerProfileResponse array{'kid'?: string|null, 'name'?: string|null, 'tabs'?: list<int>|null, 'hasBankAccess'?: bool, 'wallboardDisplayId'?: string|null, 'iconKid'?: string|null, 'databaseAccess'?: DatabaseAccessResponse, 'navigationBanks'?: list<BankNavigationResponse>|null, 'organisation'?: string|null, 'gravatarUrl'?: string|null, 'retentionDays'?: int, 'themeMode'?: eThemeMode, 'iconSet'?: string|null, 'language'?: int|null, 'dateFormat'?: string|null, 'numberFormat'?: string|null, 'lineSpacing'?: int|float, 'portalMaxOpenBanks'?: int|null, 'tabDetails'?: list<ManagerTabResponse>|null, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null}
 * @phpstan-type ManagerResetPasswordRequest array{'token': string, 'password': string, 'confirmPassword': string}
 * @phpstan-type ManagerResourceGrantResponse array{'kid'?: string|null, 'scope'?: string|null}
 * @phpstan-type ManagerSessionResponse array{'accessToken'?: string|null, 'expiresIn'?: int, 'tokenType'?: string|null}
 * @phpstan-type ManagerSignUpConfirmation array{'token'?: string|null}
 * @phpstan-type ManagerSignUpRequest array{'email'?: string|null, 'name'?: string|null, 'organisation'?: string|null, 'password'?: string|null, 'confirmPassword'?: string|null, 'language'?: string|null}
 * @phpstan-type ManagerTabChangeRequest array{'enabled'?: bool|null, 'expectedRevision': string|null}
 * @phpstan-type ManagerTabChangeResponse array{'tabs'?: list<ManagerTabResponse>|null, 'tabsRevision'?: string|null, 'canEditTabs'?: bool, 'canEditPermissions'?: bool}
 * @phpstan-type ManagerTabResponse array{'id'?: int, 'name'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type ManagerThemeRequest array{'themeMode': eThemeMode}
 * @phpstan-type ManagerThemeResponse array{'themeMode'?: eThemeMode}
 * @phpstan-type NearestLocationItem array{'kid'?: string|null, 'name'?: string|null, 'bankName'?: string|null, 'iconKid'?: string|null, 'distanceMeters'?: int|float}
 * @phpstan-type ObjectAddressResponse array{'kid'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'latitude'?: int|null, 'longitude'?: int|null, 'autoLatitudeLongitude'?: int|null, 'revision'?: string|null, 'outcome'?: string|null, 'canWrite'?: bool}
 * @phpstan-type ObjectAddressRevisionRequest array{'expectedRevision': string|null}
 * @phpstan-type OpeningHoursGroup array{'units'?: list<OpeningHoursUnit>|null, 'weekly'?: list<OpeningHoursLine>|null, 'exceptions'?: list<OpeningHoursLine>|null, 'isOpenNow'?: bool|null, 'nextChange'?: string|null}
 * @phpstan-type OpeningHoursLine array{'label'?: string|null, 'status'?: string|null, 'opens'?: string|null, 'closes'?: string|null, 'closesNextDay'?: bool, 'daysOfWeek'?: list<int>|null, 'date'?: string|null}
 * @phpstan-type OpeningHoursUnit array{'kid'?: string|null, 'name'?: string|null}
 * @phpstan-type OutOfOrderItem array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int, 'outOfOrder'?: int, 'status'?: string|null, 'statusLabel'?: string|null, 'timestampUtc'?: string, 'changedBy'?: UnitSettingEditorResponse, 'revision'?: string|null, 'canRestore'?: bool}
 * @phpstan-type OutOfOrderPage array{'items'?: list<OutOfOrderItem>|null, 'nextCursor'?: string|null, 'refreshAfterSeconds'?: int}
 * @phpstan-type OutOfOrderRestoreRequest array{'expectedRevision': string|null}
 * @phpstan-type OutOfOrderRestoreResponse array{'kid'?: string|null, 'outOfOrder'?: int, 'status'?: string|null, 'timestampUtc'?: string, 'revision'?: string|null, 'sync'?: int|null}
 * @phpstan-type PeopleDirectoryCount array{'count'?: int, 'iconKid'?: string|null}
 * @phpstan-type PersonalAccountResult array{'code'?: string|null}
 * @phpstan-type PersonalApiKeyRequest array{'revision': string|null}
 * @phpstan-type PersonalApiKeyResponse array{'apiKey'?: string|null, 'details'?: PersonalManagerApiKey}
 * @phpstan-type PersonalEmailConfirmation array{'token': string|null}
 * @phpstan-type PersonalEmailRequest array{'email': string|null, 'currentPassword': string|null, 'language'?: string|null}
 * @phpstan-type PersonalManagerApiKey array{'hasApiKey'?: bool, 'revision'?: string|null}
 * @phpstan-type PersonalManagerProfile array{'kid'?: string|null, 'name'?: string|null, 'organisation'?: string|null, 'iconKid'?: string|null, 'email'?: string|null, 'emailVerified'?: bool, 'themeMode'?: eThemeMode, 'revision'?: string|null, 'availableIcons'?: list<string>|null, 'retentionDays'?: int, 'iconSet'?: string|null, 'language'?: int|null, 'dateFormat'?: string|null, 'numberFormat'?: string|null, 'lineSpacing'?: int|float, 'portalMaxOpenBanks'?: int|null}
 * @phpstan-type PersonalManagerTab array{'id'?: int, 'name'?: string|null}
 * @phpstan-type PersonalManagerTabs array{'kid'?: string|null, 'tabs'?: list<PersonalManagerTab>|null, 'availableTabs'?: list<PersonalManagerTab>|null, 'revision'?: string|null, 'canEdit'?: bool}
 * @phpstan-type PersonalPasswordRequest array{'currentPassword': string|null, 'password': string|null, 'confirmPassword': string|null, 'language'?: string|null}
 * @phpstan-type PersonalProfileRequest array{'revision': string|null, 'value': mixed}
 * @phpstan-type PersonalTabRequest array{'revision': string|null, 'enabled': bool}
 * @phpstan-type PersonalWallboardRequest array{'displayId': string|null, 'targetDisplayId'?: string|null}
 * @phpstan-type PersonalWallboardsResponse array{'wallboards'?: list<Wallboard>|null, 'revision'?: string|null, 'storageUsedCharacters'?: int, 'storageLimitCharacters'?: int, 'portalWallboard'?: Wallboard, 'portalStorageUsedCharacters'?: int, 'portalStorageLimitCharacters'?: int}
 * @phpstan-type ProblemDetails array{'type'?: string|null, 'title'?: string|null, 'status'?: int|null, 'detail'?: string|null, 'instance'?: string|null}
 * @phpstan-type RedeemWallboardPairing array{'deviceCode'?: string|null}
 * @phpstan-type ResumeWallboardSession array{'challenge'?: string|null, 'signature'?: string|null}
 * @phpstan-type SavePersonalWallboardsRequest array{'revision'?: string|null, 'wallboards': mixed, 'portalWallboard'?: mixed}
 * @phpstan-type SearchResult array{'kid'?: string|null, 'kind'?: string|null, 'name'?: string|null, 'zip'?: string|null, 'matchedSetting'?: string|null, 'matchedValue'?: string|null, 'isContext'?: bool, 'number'?: string|null, 'bankKid'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type SearchResults array{'items'?: list<SearchResult>|null, 'hasMore'?: bool}
 * @phpstan-type ServiceApiKeyRequest array{'expectedRevision': string|null}
 * @phpstan-type ServiceApiKeyResponse array{'apiKey'?: string|null, 'details'?: ServiceDetailsResponse}
 * @phpstan-type ServiceDetailsResponse array{'service'?: ServiceDirectoryItem, 'hasApiKeyHash'?: bool, 'apiKeyHash'?: string|null, 'canEdit'?: bool, 'profileRevision'?: string|null, 'availableIcons'?: list<string>|null}
 * @phpstan-type ServiceDirectoryItem array{'kid'?: string|null, 'identity'?: string|null, 'name'?: string|null, 'iconName'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type ServiceDirectoryResponse array{'items'?: list<ServiceDirectoryItem>|null, 'nextCursor'?: string|null}
 * @phpstan-type ServiceProfileRequest array{'value': string|null, 'expectedRevision': string|null}
 * @phpstan-type SetObjectCoordinateProvenanceRequest array{'value': int, 'expectedRevision': string|null}
 * @phpstan-type SetObjectCoordinatesRequest array{'latitude': int, 'longitude': int, 'expectedRevision': string|null}
 * @phpstan-type SettlementDetailResponse array{'kid'?: string|null, 'period'?: int, 'sourceEntries'?: int, 'includedEntries'?: int, 'groups'?: list<SettlementGroupResponse>|null, 'formats'?: list<string>|null}
 * @phpstan-type SettlementGroupResponse array{'group'?: string|null, 'currency'?: string|null, 'entries'?: int, 'amountMinor'?: int}
 * @phpstan-type SettlementHistoryResponse array{'kid'?: string|null, 'nextSettlement'?: string|null, 'periods'?: list<SettlementPeriodResponse>|null, 'nextBeforePeriod'?: int|null}
 * @phpstan-type SettlementPeriodResponse array{'period'?: int, 'settlementDate'?: string|null, 'settlementRun'?: string|null, 'firstTransaction'?: string|null, 'lastTransaction'?: string|null, 'amountMinor'?: int|null, 'transactionCount'?: int|null}
 * @phpstan-type StartWallboardPairing array{'displayId'?: string|null, 'publicKey'?: string|null}
 * @phpstan-type TenantStatusItem array{'kind'?: string|null, 'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'computerName'?: string|null, 'bankType'?: string|null, 'unitType'?: int|null, 'errorId'?: int|null, 'timestampUtc'?: string, 'iconKid'?: string|null, 'bankIconKid'?: string|null, 'locationIconKid'?: string|null}
 * @phpstan-type TenantStatusPageResponse array{'status'?: TenantStatusResponse, 'offset'?: int, 'totalCount'?: int, 'previousCursor'?: string|null, 'nextCursor'?: string|null}
 * @phpstan-type TenantStatusResponse array{'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int, 'sources'?: list<TenantStatusSourceResult>|null, 'items'?: list<TenantStatusItem>|null}
 * @phpstan-type TenantStatusSourceResult array{'kind'?: string|null, 'count'?: int, 'hasMore'?: bool, 'errorCode'?: string|null}
 * @phpstan-type ToolKidField array{'name'?: string|null, 'value'?: string|null, 'enumName'?: string|null, 'enumNumber'?: string|null, 'index'?: int|null}
 * @phpstan-type ToolKidInspectionRequest array{'kid'?: string|null}
 * @phpstan-type ToolKidInspectionResponse array{'canonicalKid'?: string|null, 'fields'?: list<ToolKidField>|null, 'normalized'?: bool}
 * @phpstan-type ToolTimeOffsetChoice array{'offset'?: string|null, 'utc'?: string|null}
 * @phpstan-type ToolTimeRequest array{'format'?: string|null, 'value'?: string|null, 'timeZone'?: string|null, 'offset'?: string|null}
 * @phpstan-type ToolTimeResponse array{'success'?: bool, 'error'?: string|null, 'result'?: ToolTimeResult, 'offsetChoices'?: list<ToolTimeOffsetChoice>|null}
 * @phpstan-type ToolTimeResult array{'ms2000'?: string|null, 'mi2000'?: string|null, 'ss2000'?: string|null, 'utc'?: string|null, 'local'?: string|null, 'timeZone'?: string|null, 'offset'?: string|null, 'dateInputRounded'?: bool, 'millisecondRemainder'?: string|null, 'secondRemainder'?: string|null}
 * @phpstan-type UnitDetailsResponse array{'location'?: BankLocationResponse, 'unit'?: UnitOverviewResponse, 'descriptorAvailable'?: bool, 'settingGroups'?: list<string>|null, 'stateGroups'?: list<string>|null}
 * @phpstan-type UnitDirectoryItem array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'bankName'?: string|null, 'bankIconKid'?: string|null, 'locationName'?: string|null, 'locationIconKid'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'unitType'?: string|null, 'washDocId'?: string|null, 'outOfOrder'?: string|null, 'latitude'?: int|float|null, 'longitude'?: int|float|null, 'errorUnit'?: string|null, 'autoOutOfOrder'?: string|null, 'versionMinor'?: string|null, 'bootReason'?: string|null, 'booted'?: string|null, 'firmware'?: string|null, 'storageCardSerialNumber'?: string|null, 'page'?: string|null, 'backLight'?: string|null, 'terminal'?: UnitTerminalResponse, 'progress'?: UnitProgressResponse}
 * @phpstan-type UnitDirectoryResponse array{'items'?: list<UnitDirectoryItem>|null, 'nextCursor'?: string|null, 'hasAllBanksAccess'?: bool, 'fields'?: list<string>|null}
 * @phpstan-type UnitDocumentCount array{'count'?: int, 'from'?: string, 'through'?: string}
 * @phpstan-type UnitDocumentPage array{'items'?: list<BankDocumentItem>|null, 'from'?: string, 'through'?: string, 'sort'?: string|null, 'direction'?: string|null, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool}
 * @phpstan-type UnitErrorItem array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int|null, 'timestampUtc'?: string, 'severity'?: string|null, 'level'?: string|null, 'code'?: int|null, 'count'?: int|null, 'description'?: string|null, 'payloadFormat'?: string|null, 'acknowledged'?: bool, 'revision'?: string|null, 'canAcknowledge'?: bool}
 * @phpstan-type UnitErrorPage array{'items'?: list<UnitErrorItem>|null, 'nextCursor'?: string|null, 'fromUtc'?: string, 'untilUtc'?: string}
 * @phpstan-type UnitGroupFieldResponse array{'name'?: string|null, 'valueType'?: string|null, 'scope'?: string|null, 'valueStatus'?: string|null, 'value'?: string|null, 'ms2000'?: int|null, 'canEdit'?: bool, 'revision'?: string|null, 'required'?: bool, 'minimum'?: int|null, 'maximum'?: int|null, 'options'?: list<UnitSettingOption>|null, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse, 'canReadHistory'?: bool, 'hasHistory'?: bool, 'valueFormat'?: string|null, 'pattern'?: string|null}
 * @phpstan-type UnitGroupResponse array{'location'?: BankLocationResponse, 'unit'?: UnitOverviewResponse, 'kind'?: string|null, 'group'?: string|null, 'items'?: list<UnitGroupFieldResponse>|null}
 * @phpstan-type UnitIconResponse array{'kid'?: string|null, 'iconKid'?: string|null, 'offline'?: bool|null, 'status'?: int}
 * @phpstan-type UnitIconsResponse array{'items'?: list<UnitIconResponse>|null}
 * @phpstan-type UnitOverviewResponse array{'kid'?: string|null, 'name'?: string|null, 'cycle'?: string|null, 'cycleText'?: string|null, 'unitType'?: int|null, 'unitTypeName'?: string|null, 'unitTypeSource'?: string|null, 'iconKid'?: string|null, 'progress'?: UnitProgressResponse, 'terminal'?: UnitTerminalResponse}
 * @phpstan-type UnitProgressResponse array{'status'?: string|null, 'percent'?: int|null, 'remainingSeconds'?: int|null, 'calculatedAtUtc'?: string}
 * @phpstan-type UnitSettingEditorResponse array{'kid'?: string|null, 'kind'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type UnitSettingHistoryItem array{'value'?: string|null, 'ms2000'?: int, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse}
 * @phpstan-type UnitSettingHistoryResponse array{'unitKid'?: string|null, 'group'?: string|null, 'setting'?: string|null, 'items'?: list<UnitSettingHistoryItem>|null, 'nextBeforeMs2000'?: int|null, 'valueFormat'?: string|null}
 * @phpstan-type UnitSettingOption array{'value'?: string|null, 'label'?: string|null}
 * @phpstan-type UnitSettingRequest array{'value': string|null, 'expectedRevision': string|null}
 * @phpstan-type UnitSettingResponse array{'unitKid'?: string|null, 'group'?: string|null, 'setting'?: string|null, 'value'?: string|null, 'ms2000'?: int, 'revision'?: string|null, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse}
 * @phpstan-type UnitTerminalResponse array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type UnitTimelineField array{'kind'?: string|null, 'id'?: int, 'name'?: string|null}
 * @phpstan-type UnitTimelineFields array{'unitKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int|null, 'sources'?: list<string>|null, 'fields'?: list<UnitTimelineField>|null, 'canReadTextDiagnostics'?: bool, 'canReadDocuments'?: bool}
 * @phpstan-type UnitTimelineItem array{'eventKey'?: string|null, 'source'?: string|null, 'ms2000'?: string|null, 'timestampUtc'?: string, 'sync'?: int|null, 'field'?: string|null, 'amount'?: string|null, 'currency'?: string|null, 'text'?: string|null, 'contentStatus'?: string|null, 'period'?: int, 'userKid'?: string|null, 'documentKid'?: string|null, 'auxiliaryValue'?: string|null}
 * @phpstan-type UnitTimelinePage array{'context'?: UnitTimelineFields, 'fromUtc'?: string, 'untilUtc'?: string, 'items'?: list<UnitTimelineItem>|null, 'nextCursor'?: string|null}
 * @phpstan-type UpdateObjectAddressRequest array{'address': string|null, 'zip': string|null, 'expectedRevision': string|null}
 * @phpstan-type UserActivationResponse array{'kid'?: string|null, 'name'?: string|null, 'number'?: string|null, 'activationCode'?: string|null, 'qrCodeDataV1'?: string|null, 'qrCodeDataV2'?: string|null}
 * @phpstan-type UserAttributeInput array{'attribute'?: string|null, 'value'?: int}
 * @phpstan-type UserAttributeResponse array{'attribute'?: string|null, 'value'?: int}
 * @phpstan-type UserBalanceItem array{'kid'?: string|null, 'status'?: string|null, 'currentBalanceMinor'?: int|null, 'previousBalanceMinor'?: int|null, 'previousPeriod'?: int|null, 'previousPeriodIsProvisional'?: bool, 'latestPostingMs2000'?: int|null, 'hasActiveSubscription'?: bool|null, 'balances'?: list<UserCurrencyBalanceItem>|null}
 * @phpstan-type UserBalancesRequest array{'userKids': list<string>}
 * @phpstan-type UserBalancesResponse array{'items'?: list<UserBalanceItem>|null}
 * @phpstan-type UserCommandRequest array{'action'?: string|null, 'revision'?: string|null, 'name'?: string|null, 'number'?: string|null, 'deleteAtUtc'?: string|null, 'tagKid'?: string|null, 'state'?: string|null, 'locationKid'?: string|null, 'attributes'?: list<UserAttributeInput>|null, 'icon'?: string|null}
 * @phpstan-type UserCurrencyBalanceItem array{'currency'?: string|null, 'currentBalanceMinor'?: int, 'previousBalanceMinor'?: int|null, 'previousPeriod'?: int|null, 'previousPeriodIsProvisional'?: bool}
 * @phpstan-type UserDirectoryItem array{'kid'?: string|null, 'bankKid'?: string|null, 'name'?: string|null, 'number'?: string|null, 'iconKid'?: string|null, 'deletedAt'?: string|null}
 * @phpstan-type UserDirectoryResponse array{'items'?: list<UserDirectoryItem>|null, 'nextCursor'?: string|null, 'scanLimitReached'?: bool}
 * @phpstan-type UserEvaskeriSession array{'kid'?: string|null, 'url'?: string|null, 'expiresAtUtc'?: string}
 * @phpstan-type UserLocationResponse array{'kid'?: string|null, 'state'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
 * @phpstan-type UserNumberSuggestionResponse array{'bankKid'?: string|null, 'number'?: string|null}
 * @phpstan-type UserReceipt array{'key'?: string|null, 'date'?: string, 'locationKid'?: string|null, 'locationName'?: string|null, 'period'?: int, 'provisional'?: bool, 'kind'?: string|null, 'currency'?: string|null, 'totalMinor'?: int, 'vatMinor'?: int|null, 'balanceAfterMinor'?: int, 'lines'?: list<UserReceiptLine>|null}
 * @phpstan-type UserReceiptLine array{'kid'?: string|null, 'occurredAt'?: string, 'unitKid'?: string|null, 'unitName'?: string|null, 'texts'?: list<string>|null, 'amountMinor'?: int, 'calculated'?: bool}
 * @phpstan-type UserReceiptsResponse array{'userKid'?: string|null, 'revision'?: string|null, 'items'?: list<UserReceipt>|null, 'nextOffset'?: int|null, 'periodCount'?: int}
 * @phpstan-type UserScopeState array{'kid'?: string|null, 'state'?: string|null}
 * @phpstan-type UserTagResponse array{'kid'?: string|null, 'state'?: string|null}
 * @phpstan-type UserWorkspaceResponse array{'kid'?: string|null, 'revision'?: string|null, 'name'?: string|null, 'number'?: string|null, 'deletedAtUtc'?: string|null, 'deleteAtUtc'?: string|null, 'locations'?: list<UserScopeState>|null, 'tags'?: list<UserScopeState>|null, 'attributes'?: list<UserAttributeInput>|null, 'canWrite'?: bool, 'canCreate'?: bool, 'synchronization'?: string|null, 'canDelete'?: bool, 'canRenameExternalId'?: bool, 'canRename'?: bool, 'iconKid'?: string|null, 'availableIcons'?: list<string>|null, 'canEditIcon'?: bool}
 * @phpstan-type ValidationProblemDetails array{'type'?: string|null, 'title'?: string|null, 'status'?: int|null, 'detail'?: string|null, 'instance'?: string|null, 'errors'?: array<string,mixed>|null}
 * @phpstan-type Wallboard array{'i'?: list<string>|null, 'n'?: string|null, 'a'?: int|float, 'c'?: list<eColor>|null, 's'?: list<WallboardPage>|null}
 * @phpstan-type WallboardDeviceChallenge array{'challenge'?: string|null, 'message'?: string|null, 'expiresIn'?: int}
 * @phpstan-type WallboardDeviceInfo array{'deviceId'?: string|null, 'displayId'?: string|null, 'createdAt'?: string, 'location'?: WallboardScanLocation}
 * @phpstan-type WallboardDisplayResponse array{'layout'?: Wallboard, 'revision'?: string|null}
 * @phpstan-type WallboardPage array{'n'?: string|null, 'd'?: int, 's'?: list<WallboardWidget>|null}
 * @phpstan-type WallboardPairingInfo array{'pairingId'?: string|null, 'displayId'?: string|null, 'expiresAt'?: string, 'approved'?: bool}
 * @phpstan-type WallboardPairingStarted array{'pairingId'?: string|null, 'deviceCode'?: string|null, 'displayId'?: string|null, 'expiresAt'?: string, 'intervalSeconds'?: int}
 * @phpstan-type WallboardPairingToken array{'status'?: string|null, 'accessToken'?: string|null, 'expiresIn'?: int|null, 'displayId'?: string|null}
 * @phpstan-type WallboardScanLocation array{'latitude'?: int|float, 'longitude'?: int|float, 'accuracyMeters'?: int|float, 'capturedAt'?: string}
 * @phpstan-type WallboardWidget array{'t'?: eWidgetType, 'k'?: string|null, 'r'?: list<int>|null}
 * @phpstan-type WashDocChartDosing array{'ms2000'?: int, 'name'?: string|null, 'durationMs'?: int|null, 'volumeMl'?: int|float|null, 'massGrams'?: int|float|null, 'process'?: string|null, 'step'?: string|null}
 * @phpstan-type WashDocChartEvent array{'ms2000'?: int, 'kind'?: string|null, 'name'?: string|null, 'value'?: int|float|null, 'label'?: string|null, 'localization'?: string|null, 'isCalculated'?: bool}
 * @phpstan-type WashDocChartPoint array{'ms2000'?: int, 'value'?: int|float|null, 'isCalculated'?: bool, 'isEdge'?: bool, 'unit'?: string|null}
 * @phpstan-type WashDocChartResponse array{'cycleKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'finished'?: bool, 'fromMs2000'?: int, 'toMs2000'?: int, 'startedMs2000'?: int|null, 'endedMs2000'?: int|null, 'series'?: list<WashDocChartSeries>|null, 'events'?: list<WashDocChartEvent>|null, 'signals'?: list<WashDocChartSignal>|null, 'dosing'?: list<WashDocChartDosing>|null, 'presentation'?: WashDocPresentation}
 * @phpstan-type WashDocChartSeries array{'kind'?: string|null, 'name'?: string|null, 'label'?: string|null, 'localization'?: string|null, 'group'?: string|null, 'role'?: string|null, 'unit'?: string|null, 'step'?: bool, 'points'?: list<WashDocChartPoint>|null}
 * @phpstan-type WashDocChartSignal array{'ms2000'?: int, 'flags'?: int|null, 'heat'?: bool|null, 'inlet'?: bool|null, 'outlet'?: bool|null, 'isCalculated'?: bool, 'airflow'?: bool|null}
 * @phpstan-type WashDocPresentation array{'unitType'?: int|null, 'kind'?: string|null, 'groupOrder'?: list<string>|null}
 * @phpstan-type eColor int
 * @phpstan-type eThemeMode int
 * @phpstan-type eWidgetType int
 * @phpstan-type ActiveUsersResponse array{'tenantKid'?: string|null, 'count'?: int, 'lookbackDays'?: int, 'sinceUtc'?: string, 'measuredAtUtc'?: string}
 * @phpstan-type ApiStatusResponse array{'service'?: string|null, 'status'?: string|null, 'apiVersion'?: string|null}
 * @phpstan-type CycleChartPresentationResponse array{'language'?: string|null, 'messages'?: array<string,mixed>|null, 'stateNames'?: array<string,mixed>|null}
 * @phpstan-type IconPresentationResponse array{'iconKid'?: string|null}
 * @phpstan-type LiveMachineResponse array{'unitKid'?: string|null, 'unitName'?: string|null, 'locationName'?: string|null, 'startedAtUtc'?: string, 'doneAtUtc'?: string|null, 'temperature'?: int|float|null}
 * @phpstan-type PublicCameraPhoto array{'thumbnailUrl'?: string|null, 'workspacePath'?: string|null}
 * @phpstan-type PublicCycleWidgetResponse array{'cycleKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'locationName'?: string|null, 'startedAtUtc'?: string, 'endedAtUtc'?: string|null, 'finished'?: bool, 'graphSvg'?: string|null, 'refreshAfterSeconds'?: int, 'cycleKidText'?: string|null}
 * @phpstan-type PublicMachineError array{'kid'?: string|null, 'name'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'errorId'?: string|null}
 * @phpstan-type PublicMachineErrorsPage array{'items'?: list<PublicMachineError>|null, 'nextCursor'?: string|null, 'refreshAfterSeconds'?: int}
 * @phpstan-type PublicScopedProgressItem array{'unitKid'?: string|null, 'unitName'?: string|null, 'locationName'?: string|null, 'startedAtUtc'?: string|null, 'doneAtUtc'?: string|null, 'progress'?: UnitProgressResponse}
 * @phpstan-type PublicScopedProgressResponse array{'scopeKid'?: string|null, 'scopeKind'?: string|null, 'calculatedAtUtc'?: string, 'refreshAfterSeconds'?: int, 'items'?: list<PublicScopedProgressItem>|null, 'nextCursor'?: string|null}
 * @phpstan-type PublicWidgetPresentationResponse array{'language'?: string|null, 'colors'?: string|null, 'background'?: string|null, 'webBase'?: string|null, 'labels'?: array<string,mixed>|null, 'googleMapsBrowserKey'?: string|null, 'brandIconUrl'?: string|null, 'brandLightTokens'?: array<string,mixed>|null, 'brandDarkTokens'?: array<string,mixed>|null}
 * @phpstan-type PurchaseCurrencySnapshot array{'currency'?: string|null, 'count'?: int, 'amount'?: int|float}
 * @phpstan-type PurchaseHeatmapPoint array{'latitude'?: int|float, 'longitude'?: int|float, 'amount'?: int|float}
 * @phpstan-type PurchaseMapPoint array{'kid'?: string|null, 'latitude'?: int|float, 'longitude'?: int|float, 'timestampUtc'?: string, 'amount'?: int|float}
 * @phpstan-type PurchaseMapSnapshot array{'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int, 'items'?: list<PurchaseMapPoint>|null, 'heatmap'?: list<PurchaseHeatmapPoint>|null}
 * @phpstan-type PurchasesResponse array{'tenantKid'?: string|null, 'count'?: int, 'lookbackHours'?: int, 'sinceUtc'?: string, 'measuredAtUtc'?: string, 'currencies'?: list<PurchaseCurrencySnapshot>|null}
 * @phpstan-type ReservationsStatisticsResponse array{'tenantKid'?: string|null, 'count'?: int, 'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int}
 * @phpstan-type RunningMachinesResponse array{'tenantKid'?: string|null, 'count'?: int, 'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int}
 */
final class PortalClient extends BaseClient
{
    /** Sign in and retain the bearer in memory. Credentials are not stored. */
    public function login(#[\SensitiveParameter] string $email, #[\SensitiveParameter] string $password): array
    {
        return $this->signIn('LoginManager', ['email' => $email, 'password' => $password]);
    }

    /** Explicit renewal that replaces the in-memory bearer. */
    public function renew(): array
    {
        return $this->renewSession('RenewManagerSession');
    }

    /**
     * Resolve the Forbrug icon text from the most frequent authorized Log1 currency.
     * @param string $bankKid
     * @return AccountIconResponse
     */
    public function getBankAccountIcon(mixed $bankKid): mixed
    {
        return $this->request('GetBankAccountIcon', ['bankKid' => $bankKid], null);
    }

    /**
     * Lists Account2 postings with full-selection totals per currency.
     * @param string $bankKid
     * @param array{'From'?: string, 'Through'?: string, 'TimeZone'?: string, 'Period'?: int, 'LocationKid'?: string, 'LocationKids'?: list<string>, 'UnitKid'?: string, 'UserKid'?: string, 'Kind'?: string, 'IncludeZero'?: bool, 'IncludeBookings'?: bool, 'IncludeMonthly'?: bool, 'Offset'?: int, 'Limit'?: int} $options
     * @return AccountResponse
     */
    public function getBankAccount(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankAccount', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Checks whether filtered Account2 postings changed, including late arrivals with old event timestamps.
     * @param string $bankKid
     * @param array{'From'?: string, 'Through'?: string, 'TimeZone'?: string, 'Period'?: int, 'LocationKid'?: string, 'LocationKids'?: list<string>, 'UnitKid'?: string, 'UserKid'?: string, 'Kind'?: string, 'IncludeZero'?: bool, 'IncludeBookings'?: bool, 'IncludeMonthly'?: bool, 'Offset'?: int, 'Limit'?: int} $options
     * @return AccountRevisionResponse
     */
    public function getBankAccountRevision(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankAccountRevision', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Reverses one eligible resident consumption posting by appending a linked compensation.
     * @param string $bankKid
     * @param string $transactionKid
     * @return AccountEntryResponse
     */
    public function reverseBankAccountEntry(mixed $bankKid, mixed $transactionKid): mixed
    {
        return $this->request('ReverseBankAccountEntry', ['bankKid' => $bankKid, 'transactionKid' => $transactionKid], null);
    }

    /**
     * Read the object's own address, coordinate pair, provenance and concurrency revision.
     * @param string $kid
     * @return ObjectAddressResponse
     */
    public function getObjectAddress(mixed $kid): mixed
    {
        return $this->request('GetObjectAddress', ['kid' => $kid], null);
    }

    /**
     * Save Address and Zip together and resolve automatic coordinates once if either field changes.
     * @param string $kid
     * @param UpdateObjectAddressRequest $body
     * @return ObjectAddressResponse
     */
    public function updateObjectAddress(mixed $kid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('UpdateObjectAddress', ['kid' => $kid], $body);
    }

    /**
     * Explicitly look up the current address, replacing manual coordinates only on success.
     * @param string $kid
     * @param ObjectAddressRevisionRequest $body
     * @return ObjectAddressResponse
     */
    public function lookupObjectCoordinates(mixed $kid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('LookupObjectCoordinates', ['kid' => $kid], $body);
    }

    /**
     * Save manual Latitude and Longitude atomically with AutoLatitudeLongitude=30.
     * @param string $kid
     * @param SetObjectCoordinatesRequest $body
     * @return ObjectAddressResponse
     */
    public function setObjectCoordinates(mixed $kid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetObjectCoordinates', ['kid' => $kid], $body);
    }

    /**
     * Change AutoLatitudeLongitude without changing the coordinate pair or making a Google request.
     * @param string $kid
     * @param SetObjectCoordinateProvenanceRequest $body
     * @return ObjectAddressResponse
     */
    public function setObjectCoordinateProvenance(mixed $kid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetObjectCoordinateProvenance', ['kid' => $kid], $body);
    }

    /**
     * Ask the portal assistant to discover and combine approved read operations.
     * @param AssistantRequest $body
     * @return AssistantResponse
     */
    public function askPortalAssistant(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('AskPortalAssistant', [], $body);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'bankType'?: string} $options
     * @return DirectoryExportCountResponse
     */
    public function getBankExportCount(array $options = []): mixed
    {
        return $this->request('GetBankExportCount', [] + $options, null);
    }

    /**
     * List authorized bank identities for Banks2 with selected metadata and stable global ordering.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'bankType'?: string} $options
     * @return BankDirectoryResponse
     */
    public function getBanks(array $options = []): mixed
    {
        return $this->request('GetBanks', [] + $options, null);
    }

    /**
     * Count accessible active banks for the Banks2 navigation icon.
     * @return ActiveBankCountResponse
     */
    public function getActiveBankCount(): mixed
    {
        return $this->request('GetActiveBankCount', [], null);
    }

    /**
     * Search WashDoc document identities by location, unit and time without loading measurements.
     * @param string $bankKid
     * @param array{'LocationKid'?: string, 'LocationKids'?: list<string>, 'Date'?: string, 'Search'?: string, 'UnitKids'?: list<string>, 'Sort'?: string, 'Direction'?: string, 'UnitKid'?: string, 'From'?: string, 'Through'?: string, 'Offset'?: int, 'Limit'?: int} $options
     * @return BankDocumentPage
     */
    public function getBankDocuments(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankDocuments', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Count WashDocs across the authorized bank scope, without loading document pages or measurements.
     * @param string $bankKid
     * @param array{'LocationKid'?: string, 'LocationKids'?: list<string>, 'Date'?: string, 'Search'?: string, 'UnitKids'?: list<string>, 'Sort'?: string, 'Direction'?: string, 'UnitKid'?: string, 'From'?: string, 'Through'?: string, 'Offset'?: int, 'Limit'?: int} $options
     * @return UnitDocumentCount
     */
    public function getBankDocumentsCount(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankDocumentsCount', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * List WashDocs for one authorized location, optionally selecting one or several units.
     * @param string $locationKid
     * @param array{'Date'?: string, 'Search'?: string, 'UnitKids'?: list<string>, 'Sort'?: string, 'Direction'?: string, 'UnitKid'?: string, 'From'?: string, 'Through'?: string, 'Offset'?: int, 'Limit'?: int} $options
     * @return BankDocumentPage
     */
    public function getLocationDocuments(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationDocuments', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Count distinct WashDocs for the selected location and unit choices.
     * @param string $locationKid
     * @param array{'Date'?: string, 'Search'?: string, 'UnitKids'?: list<string>, 'Sort'?: string, 'Direction'?: string, 'UnitKid'?: string, 'From'?: string, 'Through'?: string, 'Offset'?: int, 'Limit'?: int} $options
     * @return UnitDocumentCount
     */
    public function getLocationDocumentsCount(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationDocumentsCount', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Resolve up to eight bank icons with their authorized units' combined status.
     * @param array{'kid'?: list<string>} $options
     * @return BankIconsResponse
     */
    public function getBankIcons(array $options = []): mixed
    {
        return $this->request('GetBankIcons', [] + $options, null);
    }

    /**
     * List location names, icons, status and canonical KIDs in bank overview order (location number).
     * @param string $bankKid
     * @return list<BankLocationStatusResponse>
     */
    public function getBankLocations(mixed $bankKid): mixed
    {
        return $this->request('GetBankLocations', ['bankKid' => $bankKid], null);
    }

    /**
     * Search current bank names and settlement emails; literal case-insensitive substring matching.
     * @param array{'q'?: string} $options
     * @return SearchResults
     */
    public function searchBanks(array $options = []): mixed
    {
        return $this->request('SearchBanks', [] + $options, null);
    }

    /**
     * Decode a bank activation code and resolve its name and icon from the cached Log24 bank catalogue.
     * @param array{'q'?: string} $options
     * @return SearchResults
     */
    public function searchBankActivation(array $options = []): mixed
    {
        return $this->request('SearchBankActivation', [] + $options, null);
    }

    /**
     * Resolve a search result before opening its bank overview, including tenant-wide managers.
     * @param string $bankKid
     * @return SearchResults
     */
    public function getSearchBank(mixed $bankKid): mixed
    {
        return $this->request('GetSearchBank', ['bankKid' => $bankKid], null);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param string $bankKid
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'locationKid'?: string, 'deleted'?: string, 'locationKids'?: list<string>} $options
     * @return DirectoryExportCountResponse
     */
    public function getBankUserExportCount(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankUserExportCount', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Read one page of users for a bank.
     * @param string $bankKid
     * @param array{'pageSize'?: int, 'cursor'?: string, 'sort'?: string, 'direction'?: string, 'filter'?: string, 'userKid'?: string, 'locationKid'?: string, 'deleted'?: string, 'locationKids'?: list<string>} $options
     * @return BankUsersResponse
     */
    public function getBankUsers(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankUsers', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Create a resident. Requires bank-wide Users2/User Create. Action must be create. No hardware access is assigned automatically.
     * @param string $bankKid
     * @param UserCommandRequest $body
     * @return UserWorkspaceResponse
     */
    public function createBankUser(mixed $bankKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('CreateBankUser', ['bankKid' => $bankKid], $body);
    }

    /**
     * Lists the latest nonsuperseded Log5 event for each location/unit/resident/start.
     * @param string $bankKid
     * @param array{'from'?: string, 'through'?: string, 'locationKid'?: string, 'unitKid'?: string, 'userKid'?: string, 'status'?: string, 'search'?: string, 'offset'?: int, 'limit'?: int, 'locationKids'?: list<string>} $options
     * @return BookingsResponse
     */
    public function getBankBookings(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankBookings', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Appends a cancellation or restoration, preserving history and requesting backend synchronization.
     * @param string $bankKid
     * @param string $bookingKid
     * @param BookingCommand $body
     * @return BookingResponse
     */
    public function executeBankBookingCommand(mixed $bankKid, mixed $bookingKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ExecuteBankBookingCommand', ['bankKid' => $bankKid, 'bookingKid' => $bookingKid], $body);
    }

    /**
     * Resolve the nearest writable location within 100 metres for tenant-level camera capture.
     * @param array{'latitude'?: int|float, 'longitude'?: int|float, 'accuracyMeters'?: int|float} $options
     * @return CameraResourceResponse
     */
    public function getCameraNearestLocation(array $options = []): mixed
    {
        return $this->request('GetCameraNearestLocation', [] + $options, null);
    }

    /**
     * Read the display identity of one authorized camera resource.
     * @param array{'resourceKid'?: string} $options
     * @return CameraResourceResponse
     */
    public function getCameraResource(array $options = []): mixed
    {
        return $this->request('GetCameraResource', [] + $options, null);
    }

    /**
     * Check the lazy local camera tab and capture permission for one exact resource.
     * @param array{'resourceKid'?: string} $options
     * @return CameraAvailabilityResponse
     */
    public function getCameraAvailability(array $options = []): mixed
    {
        return $this->request('GetCameraAvailability', [] + $options, null);
    }

    /**
     * Prepare a bounded, immutable capture plan including optional weather.
     * @param CameraPrepareRequest $body
     * @return CameraPrepareResponse
     */
    public function prepareCameraCapture(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('PrepareCameraCapture', [], $body);
    }

    /**
     * Save camera media synchronously, or accept bounded background processing.
     * @param array<string,string|\CURLFile> $body Multipart fields and caller-owned file paths.
     * @param array{'background'?: bool} $options
     * @return CameraSaveResponse
     */
    public function saveCameraCapture(#[\SensitiveParameter] array $body, array $options = []): mixed
    {
        return $this->request('SaveCameraCapture', [] + $options, $body);
    }

    /**
     * List own tenant captures, or all authorized captures on one exact bank, location or unit.
     * @param array{'resourceKid'?: string, 'cursor'?: string} $options
     * @return CameraCapturePage
     */
    public function getCameraCaptures(array $options = []): mixed
    {
        return $this->request('GetCameraCaptures', [] + $options, null);
    }

    /**
     * Confirm publication of an exact prepared capture after an uncertain upload response.
     * @param CameraConfirmationRequest $body
     * @return CameraConfirmationResponse
     */
    public function confirmCameraCapture(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ConfirmCameraCapture', [], $body);
    }

    /**
     * Stream one capture component through the API, with current resource authorization.
     * @param string $id
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'part'?: string, 'Range'?: string} $options
     * @return DownloadResponse
     */
    public function getCameraCaptureContent(mixed $id, mixed $destination, array $options = []): mixed
    {
        return $this->request('GetCameraCaptureContent', ['id' => $id] + $options, null, $destination);
    }

    /**
     * Read private capture metadata for a public recent-photo thumbnail.
     * @param string $id
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getRecentCameraPhotoMetadata(mixed $id, mixed $destination): mixed
    {
        return $this->request('GetRecentCameraPhotoMetadata', ['id' => $id], null, $destination);
    }

    /**
     * List authorized settlement periods requiring attention, as in DatPro2 Checklist1.
     * @param array{'scopeKid'?: string, 'includeResolved'?: bool, 'pageSize'?: int, 'cursor'?: string} $options
     * @return ChecklistPage
     */
    public function getChecklist(array $options = []): mixed
    {
        return $this->request('GetChecklist', [] + $options, null);
    }

    /**
     * Read one current checklist period, including its hidden/completed status.
     * @param string $periodKid
     * @return ChecklistItem
     */
    public function getChecklistPeriod(mixed $periodKid): mixed
    {
        return $this->request('GetChecklistPeriod', ['periodKid' => $periodKid], null);
    }

    /**
     * Downloads the complete filtered selection as CSV or a genuine Excel workbook.
     * @param string $bankKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'From'?: string, 'Through'?: string, 'TimeZone'?: string, 'Period'?: int, 'LocationKid'?: string, 'LocationKids'?: list<string>, 'UnitKid'?: string, 'UserKid'?: string, 'Kind'?: string, 'IncludeZero'?: bool, 'IncludeBookings'?: bool, 'IncludeMonthly'?: bool, 'Offset'?: int, 'Limit'?: int, 'format'?: string} $options
     * @return DownloadResponse
     */
    public function exportBankAccount(mixed $bankKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('ExportBankAccount', ['bankKid' => $bankKid] + $options, null, $destination);
    }

    /**
     * Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text.
     * @param string $bankKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'filter'?: string, 'locationKid'?: string, 'deleted'?: string, 'sort'?: string, 'direction'?: string, 'locationKids'?: list<string>} $options
     * @return DownloadResponse
     */
    public function exportBankUsers(mixed $bankKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('ExportBankUsers', ['bankKid' => $bankKid] + $options, null, $destination);
    }

    /**
     * Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest.
     * @param string $bankKid
     * @param int $period
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'format'?: string} $options
     * @return DownloadResponse
     */
    public function downloadBankSettlement(mixed $bankKid, mixed $period, mixed $destination, array $options = []): mixed
    {
        return $this->request('DownloadBankSettlement', ['bankKid' => $bankKid, 'period' => $period] + $options, null, $destination);
    }

    /**
     * Download a UTF-8 CSV table for one document.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DownloadResponse
     */
    public function downloadUnitDocumentCsv(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('DownloadUnitDocumentCsv', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * Download an Excel 97–2003 binary .xls workbook for one document.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DownloadResponse
     */
    public function downloadUnitDocumentXls(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('DownloadUnitDocumentXls', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * List a bank's machine errors, as in DatPro2 Errors2.
     * @param string $bankKid
     * @param array{'days'?: int, 'level'?: string, 'includeAcknowledged'?: bool, 'pageSize'?: int, 'cursor'?: string} $options
     * @return UnitErrorPage
     */
    public function getBankErrors(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankErrors', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Read one authorized error event, including its current acknowledgement and revision.
     * @param string $errorKid
     * @return UnitErrorItem
     */
    public function getError(mixed $errorKid): mixed
    {
        return $this->request('GetError', ['errorKid' => $errorKid], null);
    }

    /**
     * Acknowledge one error without deleting its log or changing machine status.
     * @param string $errorKid
     * @param AcknowledgeErrorRequest $body
     * @return UnitErrorItem
     */
    public function acknowledgeError(mixed $errorKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('AcknowledgeError', ['errorKid' => $errorKid], $body);
    }

    /**
     * Read recent DigitalOcean runtime logs for a configured shared app.
     * @param array{'environment'?: string, 'application'?: string} $options
     * @return HostingLogsResponse
     */
    public function getHostingLogs(array $options = []): mixed
    {
        return $this->request('GetHostingLogs', [] + $options, null);
    }

    /**
     * Read hosting metrics for one configured application or Managed MySQL cluster.
     * @param array{'environment'?: string, 'application'?: string, 'hours'?: int} $options
     * @return HostingMetricsResponse
     */
    public function getHostingMetrics(array $options = []): mixed
    {
        return $this->request('GetHostingMetrics', [] + $options, null);
    }

    /**
     * Save an installer's selected Person icon.
     * @param string $installerKid
     * @param InstallerIconRequest $body
     * @return InstallerIconResponse
     */
    public function setInstallerIcon(mixed $installerKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetInstallerIcon', ['installerKid' => $installerKid], $body);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'includeActivationCode'?: bool} $options
     * @return DirectoryExportCountResponse
     */
    public function getInstallerExportCount(array $options = []): mixed
    {
        return $this->request('GetInstallerExportCount', [] + $options, null);
    }

    /**
     * List installers with locations, tags, account state and last activity.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string, 'includeActivationCode'?: bool} $options
     * @return InstallerDirectoryResponse
     */
    public function getInstallers(array $options = []): mixed
    {
        return $this->request('GetInstallers', [] + $options, null);
    }

    /**
     * Read one installer and the same Person icon catalog used for administrators.
     * @param string $installerKid
     * @return InstallerDetailsResponse
     */
    public function getInstaller(mixed $installerKid): mixed
    {
        return $this->request('GetInstaller', ['installerKid' => $installerKid], null);
    }

    /**
     * Read recent live logs from Portal API, Equipment API and Portal Web.
     * @return LiveLogsResponse
     */
    public function getLiveLogs(): mixed
    {
        return $this->request('GetLiveLogs', [], null);
    }

    /**
     * Count accessible active locations for the Locations1 navigation icon.
     * @param array{'bankKid'?: string} $options
     * @return ActiveLocationCountResponse
     */
    public function getActiveLocationCount(array $options = []): mixed
    {
        return $this->request('GetActiveLocationCount', [] + $options, null);
    }

    /**
     * List accessible locations with parent banks, Visma customer numbers and authorized activation codes.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'includeCoordinates'?: bool, 'bankKid'?: string} $options
     * @return LocationDirectoryResponse
     */
    public function getLocations(array $options = []): mixed
    {
        return $this->request('GetLocations', [] + $options, null);
    }

    /**
     * Count every location matching the same filters, selected search columns and permissions as GetLocations.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'bankKid'?: string} $options
     * @return LocationCountResponse
     */
    public function getLocationCount(array $options = []): mixed
    {
        return $this->request('GetLocationCount', [] + $options, null);
    }

    /**
     * Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24.
     * @param array{'q'?: string} $options
     * @return SearchResults
     */
    public function searchLocations(array $options = []): mixed
    {
        return $this->request('SearchLocations', [] + $options, null);
    }

    /**
     * Decode a location activation code and resolve its visible name and icon in Log24.
     * @param array{'q'?: string} $options
     * @return SearchResults
     */
    public function searchLocationActivation(array $options = []): mixed
    {
        return $this->request('SearchLocationActivation', [] + $options, null);
    }

    /**
     * Read dated reservation calendars with location opening hours already applied.
     * @param string $locationKid
     * @param array{'Accept-Language'?: string, 'from'?: string, 'days'?: int} $options
     * @return LocationBookingCalendarsResponse
     */
    public function getLocationBookingCalendars(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationBookingCalendars', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Read localized configured reservation rules for the location's visible units.
     * @param string $locationKid
     * @param array{'Accept-Language'?: string} $options
     * @return LocationBookingRulesResponse
     */
    public function getLocationBookingRules(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationBookingRules', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Read an authorized controller using its canonical Controller KID with MainId.
     * @param string $controllerKid
     * @param array{'Accept-Language'?: string} $options
     * @return UnitDetailsResponse
     */
    public function getControllerOverview(mixed $controllerKid, array $options = []): mixed
    {
        return $this->request('GetControllerOverview', ['controllerKid' => $controllerKid] + $options, null);
    }

    /**
     * Read the controller's temporary Core settings or states from its main unit.
     * @param string $controllerKid
     * @param string $kind
     * @param string $group
     * @param array{'Accept-Language'?: string} $options
     * @return UnitGroupResponse
     */
    public function getControllerGroup(mixed $controllerKid, mixed $kind, mixed $group, array $options = []): mixed
    {
        return $this->request('GetControllerGroup', ['controllerKid' => $controllerKid, 'kind' => $kind, 'group' => $group] + $options, null);
    }

    /**
     * Get the location label and its units, ordered by unit number.
     * @param string $locationKid
     * @param array{'Accept-Language'?: string} $options
     * @return LocationUnitsResponse
     */
    public function getLocationUnits(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationUnits', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Read an authorized unit and its type's setting/state groups.
     * @param string $unitKid
     * @param array{'Accept-Language'?: string} $options
     * @return UnitDetailsResponse
     */
    public function getUnitOverview(mixed $unitKid, array $options = []): mixed
    {
        return $this->request('GetUnitOverview', ['unitKid' => $unitKid] + $options, null);
    }

    /**
     * Read the declared settings or states in one authorized unit group.
     * @param string $unitKid
     * @param string $kind
     * @param string $group
     * @param array{'Accept-Language'?: string} $options
     * @return UnitGroupResponse
     */
    public function getUnitGroup(mixed $unitKid, mixed $kind, mixed $group, array $options = []): mixed
    {
        return $this->request('GetUnitGroup', ['unitKid' => $unitKid, 'kind' => $kind, 'group' => $group] + $options, null);
    }

    /**
     * Read a bounded page of changes to one declared unit setting.
     * @param string $unitKid
     * @param string $group
     * @param string $setting
     * @param array{'beforeMs2000'?: int, 'limit'?: int} $options
     * @return UnitSettingHistoryResponse
     */
    public function getUnitSettingHistory(mixed $unitKid, mixed $group, mixed $setting, array $options = []): mixed
    {
        return $this->request('GetUnitSettingHistory', ['unitKid' => $unitKid, 'group' => $group, 'setting' => $setting] + $options, null);
    }

    /**
     * Resolve up to 32 visible unit icons, adding the online/offline under-icon on demand.
     * @param array{'kid'?: list<string>} $options
     * @return UnitIconsResponse
     */
    public function getUnitIcons(array $options = []): mixed
    {
        return $this->request('GetUnitIcons', [] + $options, null);
    }

    /**
     * Resolve up to 32 visible location icons with their units' combined online/offline status.
     * @param array{'kid'?: list<string>} $options
     * @return LocationIconsResponse
     */
    public function getLocationIcons(array $options = []): mixed
    {
        return $this->request('GetLocationIcons', [] + $options, null);
    }

    /**
     * Read grouped opening hours, upcoming exceptions and the current opening status for a location.
     * @param string $locationKid
     * @param array{'Accept-Language'?: string} $options
     * @return LocationOpeningHoursResponse
     */
    public function getLocationOpeningHours(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationOpeningHours', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Read bank Log5 reservation history for the location's authorized visible units.
     * @param string $locationKid
     * @param array{'from'?: string, 'days'?: int, 'Accept-Language'?: string} $options
     * @return LocationReservationHistoryResponse
     */
    public function getLocationReservationHistory(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationReservationHistory', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Read active tenant Log5 reservations for the location's authorized visible units.
     * @param string $locationKid
     * @param array{'from'?: string, 'days'?: int, 'Accept-Language'?: string} $options
     * @return LocationReservationsResponse
     */
    public function getLocationReservations(mixed $locationKid, array $options = []): mixed
    {
        return $this->request('GetLocationReservations', ['locationKid' => $locationKid] + $options, null);
    }

    /**
     * Get current weather for the authorized location's stored position or address.
     * @param string $locationKid
     * @return LocationWeatherResponse
     */
    public function getLocationWeather(mixed $locationKid): mixed
    {
        return $this->request('GetLocationWeather', ['locationKid' => $locationKid], null);
    }

    /**
     * Create an empty enabled administrator with a previously unused manager identity.
     * @return ManagerCreationResponse
     */
    public function createManager(): mixed
    {
        return $this->request('CreateManager', [], null);
    }

    /**
     * List administrators in the site's eUserId.Managers through ManagersLast range.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string} $options
     * @return ManagerDirectoryResponse
     */
    public function getManagers(array $options = []): mixed
    {
        return $this->request('GetManagers', [] + $options, null);
    }

    /**
     * Send an invitation allowing an existing manager to choose a password.
     * @param string $managerKid
     * @param ManagerInvitationRequest $body
     * @return ManagerInvitationResponse
     */
    public function inviteManager(mixed $managerKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('InviteManager', ['managerKid' => $managerKid], $body);
    }

    /**
     * Add or remove a tenant, whole-bank or single-location grant on an administrator.
     * @param string $managerKid
     * @param ManagerKidChangeRequest $body
     * @return ManagerKidChangeResponse
     */
    public function setManagerKid(mixed $managerKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetManagerKid', ['managerKid' => $managerKid], $body);
    }

    /**
     * Request a manager password reset email.
     * @param ManagerForgotPasswordRequest $body
     * @return ManagerPasswordResetResponse
     */
    public function requestManagerPasswordReset(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('RequestManagerPasswordReset', [], $body);
    }

    /**
     * Replace a manager password using the emailed recovery token.
     * @param ManagerResetPasswordRequest $body
     * @return ManagerPasswordResetResponse
     */
    public function resetManagerPassword(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ResetManagerPassword', [], $body);
    }

    /**
     * Replace all nine permission categories with a predefined administrator role.
     * @param string $managerKid
     * @param ManagerPermissionRoleRequest $body
     * @return ManagerPermissionRoleResponse
     */
    public function setManagerPermissionRole(mixed $managerKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetManagerPermissionRole', ['managerKid' => $managerKid], $body);
    }

    /**
     * Set one administrator permission checkbox, including your own if you are the sole active tenant-wide manager.
     * @param string $managerKid
     * @param string $resource
     * @param ManagerPermissionChangeRequest $body
     * @return ManagerOperationPermissionResponse
     */
    public function setManagerPermission(mixed $managerKid, mixed $resource, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetManagerPermission', ['managerKid' => $managerKid, 'resource' => $resource], $body);
    }

    /**
     * Change Name, Organisation, Enabled, Deleted, RetentionDays, Icon or Email on an administrator.
     * @param string $managerKid
     * @param string $field
     * @param ManagerProfileChangeRequest $body
     * @return ManagerProfileChangeResponse
     */
    public function setManagerProfileField(mixed $managerKid, mixed $field, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetManagerProfileField', ['managerKid' => $managerKid, 'field' => $field], $body);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string} $options
     * @return DirectoryExportCountResponse
     */
    public function getManagerExportCount(array $options = []): mixed
    {
        return $this->request('GetManagerExportCount', [] + $options, null);
    }

    /**
     * Read one administrator by canonical manager KID for a workspace shortcut.
     * @param string $managerKid
     * @return ManagerDirectoryItem
     */
    public function getManager(mixed $managerKid): mixed
    {
        return $this->request('GetManager', ['managerKid' => $managerKid], null);
    }

    /**
     * List other visible administrators with the same stored email as this manager.
     * @param string $managerKid
     * @return list<ManagerEmailMatch>
     */
    public function getManagersWithSameEmail(mixed $managerKid): mixed
    {
        return $this->request('GetManagersWithSameEmail', ['managerKid' => $managerKid], null);
    }

    /**
     * Log in with manager email/password or manager username/API key.
     * @param ManagerLoginRequest $body
     * @param array{'X-Portal-Login-Client-IP'?: string} $options
     * @return ManagerSessionResponse
     */
    public function loginManager(#[\SensitiveParameter] array $body, array $options = []): mixed
    {
        return $this->request('LoginManager', [] + $options, $body);
    }

    /**
     * Renew an unexpired manager session for ten days.
     * @return ManagerSessionResponse
     */
    public function renewManagerSession(): mixed
    {
        return $this->request('RenewManagerSession', [], null);
    }

    /**
     * Get your profile, permitted tabs, bank/location access, and operation permissions.
     * @param array{'refresh'?: bool} $options
     * @return ManagerProfileResponse
     */
    public function getCurrentManager(array $options = []): mixed
    {
        return $this->request('GetCurrentManager', [] + $options, null);
    }

    /**
     * Create a pending manager with a password and queue a manager-bound verification email.
     * @param ManagerSignUpRequest $body
     * @return PersonalAccountResult
     */
    public function requestManagerSignUp(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('RequestManagerSignUp', [], $body);
    }

    /**
     * Verify the email and activate only the manager already created by self-registration.
     * @param ManagerSignUpConfirmation $body
     * @return PersonalAccountResult
     */
    public function confirmManagerSignUp(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ConfirmManagerSignUp', [], $body);
    }

    /**
     * Assign or remove one available eTab on an administrator.
     * @param string $managerKid
     * @param int $tabId
     * @param ManagerTabChangeRequest $body
     * @return ManagerTabChangeResponse
     */
    public function setManagerTab(mixed $managerKid, mixed $tabId, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetManagerTab', ['managerKid' => $managerKid, 'tabId' => $tabId], $body);
    }

    /**
     * Save your own theme preference.
     * @param ManagerThemeRequest $body
     * @return ManagerThemeResponse
     */
    public function setCurrentManagerTheme(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetCurrentManagerTheme', [], $body);
    }

    /**
     * Get up to ten authorized locations nearest to a supplied position.
     * @param array{'latitude'?: int|float, 'longitude'?: int|float} $options
     * @return list<NearestLocationItem>
     */
    public function getNearestLocations(array $options = []): mixed
    {
        return $this->request('GetNearestLocations', [] + $options, null);
    }

    /**
     * Count all visible administrators, independently of the current page/filter.
     * @return PeopleDirectoryCount
     */
    public function getManagerCount(): mixed
    {
        return $this->request('GetManagerCount', [], null);
    }

    /**
     * Count all visible installers, independently of the current page/filter.
     * @return PeopleDirectoryCount
     */
    public function getInstallerCount(): mixed
    {
        return $this->request('GetInstallerCount', [], null);
    }

    /**
     * Read your own personal settings and available person icons.
     * @return PersonalManagerProfile
     */
    public function getMyManagerProfile(): mixed
    {
        return $this->request('GetMyManagerProfile', [], null);
    }

    /**
     * Add a scanned display to your own WallBoards layout setting.
     * @param PersonalWallboardRequest $body
     * @return PersonalAccountResult
     */
    public function addMyManagerWallboard(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('AddMyManagerWallboard', [], $body);
    }

    /**
     * Read your own Wallboard1 editor layouts and concurrency revision.
     * @return PersonalWallboardsResponse
     */
    public function getMyManagerWallboards(): mixed
    {
        return $this->request('GetMyManagerWallboards', [], null);
    }

    /**
     * Save your own Wallboard1 layouts and optional portal overview layout.
     * @param SavePersonalWallboardsRequest $body
     * @return PersonalWallboardsResponse
     */
    public function saveMyManagerWallboards(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SaveMyManagerWallboards', [], $body);
    }

    /**
     * Read the selected orientation for one of your Wallboards.
     * @param string $displayId
     * @param array{'portrait'?: bool, 'after'?: string} $options
     * @return WallboardDisplayResponse
     */
    public function getMyManagerWallboardDisplay(mixed $displayId, array $options = []): mixed
    {
        return $this->request('GetMyManagerWallboardDisplay', ['displayId' => $displayId] + $options, null);
    }

    /**
     * Read your own API-key configuration status and revision without exposing credentials.
     * @return PersonalManagerApiKey
     */
    public function getMyManagerApiKey(): mixed
    {
        return $this->request('GetMyManagerApiKey', [], null);
    }

    /**
     * Generate your own API key and commit its hash to eSetting.ApiKeyHash.
     * @param PersonalApiKeyRequest $body
     * @return PersonalApiKeyResponse
     */
    public function generateMyManagerApiKey(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('GenerateMyManagerApiKey', [], $body);
    }

    /**
     * Read your own tab selection, available tabs and editing eligibility.
     * @return PersonalManagerTabs
     */
    public function getMyManagerTabs(): mixed
    {
        return $this->request('GetMyManagerTabs', [], null);
    }

    /**
     * Select or deselect one of your own tabs when you have access to all banks.
     * @param int $tabId
     * @param PersonalTabRequest $body
     * @return PersonalManagerTabs
     */
    public function setMyManagerTab(mixed $tabId, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetMyManagerTab', ['tabId' => $tabId], $body);
    }

    /**
     * Save one personal name, organisation, person icon, theme or deleted-record visibility preference.
     * @param string $field
     * @param PersonalProfileRequest $body
     * @return PersonalManagerProfile
     */
    public function setMyManagerProfileField(mixed $field, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetMyManagerProfileField', ['field' => $field], $body);
    }

    /**
     * Send a verification link to your new email address.
     * @param PersonalEmailRequest $body
     * @return PersonalAccountResult
     */
    public function requestMyManagerEmailVerification(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('RequestMyManagerEmailVerification', [], $body);
    }

    /**
     * Confirm the new mailbox with its single-use verification token.
     * @param PersonalEmailConfirmation $body
     * @return PersonalAccountResult
     */
    public function confirmMyManagerEmail(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ConfirmMyManagerEmail', [], $body);
    }

    /**
     * Change your password after reauthentication and repeated new-password entry.
     * @param PersonalPasswordRequest $body
     * @return PersonalAccountResult
     */
    public function changeMyManagerPassword(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ChangeMyManagerPassword', [], $body);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string} $options
     * @return DirectoryExportCountResponse
     */
    public function getServiceExportCount(array $options = []): mixed
    {
        return $this->request('GetServiceExportCount', [] + $options, null);
    }

    /**
     * List concrete service enum identities, including services without saved settings.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string} $options
     * @return ServiceDirectoryResponse
     */
    public function getServices(array $options = []): mixed
    {
        return $this->request('GetServices', [] + $options, null);
    }

    /**
     * Count the predefined service identities without reading service settings.
     * @return PeopleDirectoryCount
     */
    public function getServiceCount(): mixed
    {
        return $this->request('GetServiceCount', [], null);
    }

    /**
     * Read one predefined service, editable metadata and its icon catalog.
     * @param string $serviceKid
     * @return ServiceDetailsResponse
     */
    public function getService(mixed $serviceKid): mixed
    {
        return $this->request('GetService', ['serviceKid' => $serviceKid], null);
    }

    /**
     * Save one service Name or Icon.
     * @param string $serviceKid
     * @param string $field
     * @param ServiceProfileRequest $body
     * @return ServiceDetailsResponse
     */
    public function setServiceProfileField(mixed $serviceKid, mixed $field, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetServiceProfileField', ['serviceKid' => $serviceKid, 'field' => $field], $body);
    }

    /**
     * Generate a service API key beginning with kt_ and save its password-compatible hash.
     * @param string $serviceKid
     * @param ServiceApiKeyRequest $body
     * @return ServiceApiKeyResponse
     */
    public function generateServiceApiKey(mixed $serviceKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('GenerateServiceApiKey', ['serviceKid' => $serviceKid], $body);
    }

    /**
     * Lists 25 closed settlement periods, newest first, and the next scheduled settlement.
     * @param string $bankKid
     * @param array{'beforePeriod'?: int} $options
     * @return SettlementHistoryResponse
     */
    public function getBankSettlements(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankSettlements', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Reads grouped totals for one period (zero is the provisional current period) and lists available export formats.
     * @param string $bankKid
     * @param int $period
     * @return SettlementDetailResponse
     */
    public function getBankSettlementPeriod(mixed $bankKid, mixed $period): mixed
    {
        return $this->request('GetBankSettlementPeriod', ['bankKid' => $bankKid, 'period' => $period], null);
    }

    /**
     * List Offline and AutoOutOfOrder alerts, newest first, using parallel lookups.
     * @param array{'limit'?: int} $options
     * @return TenantStatusResponse
     */
    public function getTenantStatus(array $options = []): mixed
    {
        return $this->request('GetTenantStatus', [] + $options, null);
    }

    /**
     * Read 25 status rows at a time with next/previous cursors.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'offset'?: int, 'anchor'?: string} $options
     * @return TenantStatusPageResponse
     */
    public function getTenantStatusPage(array $options = []): mixed
    {
        return $this->request('GetTenantStatusPage', [] + $options, null);
    }

    /**
     * Convert MS2000, MI2000, SS2000, UTC or a local wall time without floating-point integers.
     * @param ToolTimeRequest $body
     * @return ToolTimeResponse
     */
    public function convertToolTime(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ConvertToolTime', [], $body);
    }

    /**
     * Inspect only the supplied KID with the installed Kombine.Flex.Kid parser.
     * @param ToolKidInspectionRequest $body
     * @return ToolKidInspectionResponse
     */
    public function inspectToolKid(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('InspectToolKid', [], $body);
    }

    /**
     * Get the authorized machine context, log categories and readable timeline fields.
     * @param string $unitKid
     * @return UnitTimelineFields
     */
    public function getUnitTimelineFields(mixed $unitKid): mixed
    {
        return $this->request('GetUnitTimelineFields', ['unitKid' => $unitKid], null);
    }

    /**
     * Page chronologically through one machine's authorized Log0–Log6 events.
     * @param string $unitKid
     * @param array{'fromUtc'?: string, 'untilUtc'?: string, 'sources'?: string, 'field'?: string, 'pageSize'?: int, 'cursor'?: string} $options
     * @return UnitTimelinePage
     */
    public function getUnitTimeline(mixed $unitKid, array $options = []): mixed
    {
        return $this->request('GetUnitTimeline', ['unitKid' => $unitKid] + $options, null);
    }

    /**
     * List document identities produced by the selected Unit for WashDoc3.
     * @param string $unitKid
     * @param array{'Sort'?: string, 'Direction'?: string, 'Offset'?: int, 'Limit'?: int, 'Search'?: string, 'Date'?: string} $options
     * @return UnitDocumentPage
     */
    public function getUnitDocuments(mixed $unitKid, array $options = []): mixed
    {
        return $this->request('GetUnitDocuments', ['unitKid' => $unitKid] + $options, null);
    }

    /**
     * Count distinct WashDoc3 document identities for exactly one unit, separately from list loading.
     * @param string $unitKid
     * @param array{'Search'?: string, 'Date'?: string} $options
     * @return UnitDocumentCount
     */
    public function getUnitDocumentsCount(mixed $unitKid, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentsCount', ['unitKid' => $unitKid] + $options, null);
    }

    /**
     * Find the previous (higher Doc ID) and next (lower Doc ID) existing document for this exact unit.
     * @param string $cycleKid
     * @return DocumentNeighbors
     */
    public function getUnitDocumentNeighbors(mixed $cycleKid): mixed
    {
        return $this->request('GetUnitDocumentNeighbors', ['cycleKid' => $cycleKid], null);
    }

    /**
     * Read a document's table as JSON with original values and column metadata.
     * @param string $cycleKid
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DocumentTable
     */
    public function getUnitDocumentTable(mixed $cycleKid, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentTable', ['cycleKid' => $cycleKid] + $options, null);
    }

    /**
     * View a document as a printable HTML table.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DownloadResponse
     */
    public function getUnitDocumentHtml(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentHtml', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * Render a document's numeric series as an SVG chart, caching completed documents privately.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool, 'width'?: int} $options
     * @return DownloadResponse
     */
    public function getUnitDocumentSvg(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentSvg', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * Render a responsive WashDoc chart with independent text and graph layers.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DownloadResponse
     */
    public function getUnitDocumentSvg2(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentSvg2', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * Read semantic WashDoc graph JSON for interactive charts and image rendering.
     * @param string $cycleKid
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return WashDocChartResponse
     */
    public function getUnitDocumentGraph(mixed $cycleKid, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentGraph', ['cycleKid' => $cycleKid] + $options, null);
    }

    /**
     * Render a document KID as a PNG image with the shared local Chart.js renderer.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DownloadResponse
     */
    public function getUnitDocumentPng(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentPng', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * Render the first WashDoc curve as a monochrome line icon.
     * @param string $cycleKid
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @param array{'States'?: string, 'Settings'?: string, 'HistoricalMeasurements'?: bool} $options
     * @return DownloadResponse
     */
    public function getUnitDocumentIcon(mixed $cycleKid, mixed $destination, array $options = []): mixed
    {
        return $this->request('GetUnitDocumentIcon', ['cycleKid' => $cycleKid] + $options, null, $destination);
    }

    /**
     * List out-of-order machines, including manual, automatic and repair states.
     * @param array{'pageSize'?: int, 'cursor'?: string} $options
     * @return OutOfOrderPage
     */
    public function getOutOfOrderUnits(array $options = []): mixed
    {
        return $this->request('GetOutOfOrderUnits', [] + $options, null);
    }

    /**
     * Return one out-of-order machine to service by setting OutOfOrder to Enabled (0).
     * @param string $unitKid
     * @param OutOfOrderRestoreRequest $body
     * @return OutOfOrderRestoreResponse
     */
    public function restoreOutOfOrderUnit(mixed $unitKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('RestoreOutOfOrderUnit', ['unitKid' => $unitKid], $body);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'locationKid'?: string, 'terminalKid'?: string, 'runningOnly'?: bool, 'autoOutOfOrderOnly'?: bool} $options
     * @return DirectoryExportCountResponse
     */
    public function getUnitExportCount(array $options = []): mixed
    {
        return $this->request('GetUnitExportCount', [] + $options, null);
    }

    /**
     * Count authorized main terminals matching the export filters.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'locationKid'?: string, 'terminalKid'?: string, 'runningOnly'?: bool} $options
     * @return DirectoryExportCountResponse
     */
    public function getTerminalExportCount(array $options = []): mixed
    {
        return $this->request('GetTerminalExportCount', [] + $options, null);
    }

    /**
     * Count accessible active units for the Units1 navigation icon.
     * @return ActiveUnitCountResponse
     */
    public function getActiveUnitCount(): mixed
    {
        return $this->request('GetActiveUnitCount', [], null);
    }

    /**
     * Count accessible active terminals for the Terminals1 navigation icon.
     * @return ActiveUnitCountResponse
     */
    public function getActiveTerminalCount(): mixed
    {
        return $this->request('GetActiveTerminalCount', [], null);
    }

    /**
     * List authorized units, including child units, for Units1.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'includeCoordinates'?: bool, 'locationKid'?: string, 'terminalKid'?: string, 'runningOnly'?: bool, 'autoOutOfOrderOnly'?: bool} $options
     * @return UnitDirectoryResponse
     */
    public function getUnits(array $options = []): mixed
    {
        return $this->request('GetUnits', [] + $options, null);
    }

    /**
     * List authorized main units for Terminals1.
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool, 'fields'?: string, 'includeCoordinates'?: bool, 'locationKid'?: string, 'terminalKid'?: string, 'runningOnly'?: bool} $options
     * @return UnitDirectoryResponse
     */
    public function getTerminals(array $options = []): mixed
    {
        return $this->request('GetTerminals', [] + $options, null);
    }

    /**
     * Save one editable current-unit setting with revision protection.
     * @param string $unitKid
     * @param string $group
     * @param string $setting
     * @param UnitSettingRequest $body
     * @return UnitSettingResponse
     */
    public function setUnitSetting(mixed $unitKid, mixed $group, mixed $setting, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('SetUnitSetting', ['unitKid' => $unitKid, 'group' => $group, 'setting' => $setting], $body);
    }

    /**
     * Read current and previous-period balances for up to 50 residents in one bank.
     * @param string $bankKid
     * @param UserBalancesRequest $body
     * @return UserBalancesResponse
     */
    public function getBankUserBalances(mixed $bankKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('GetBankUserBalances', ['bankKid' => $bankKid], $body);
    }

    /**
     * Suggest the next resident number from the bank's first NumberFormats entry and stored NumberFormatUserIndex (default 1).
     * @param string $bankKid
     * @return UserNumberSuggestionResponse
     */
    public function getBankUserNumberForNewUser(mixed $bankKid): mixed
    {
        return $this->request('GetBankUserNumberForNewUser', ['bankKid' => $bankKid], null);
    }

    /**
     * Suggest the next resident number after userNumber using the bank's first NumberFormats entry.
     * @param string $bankKid
     * @param array{'userNumber'?: string} $options
     * @return UserNumberSuggestionResponse
     */
    public function getBankNextUserNumber(mixed $bankKid, array $options = []): mixed
    {
        return $this->request('GetBankNextUserNumber', ['bankKid' => $bankKid] + $options, null);
    }

    /**
     * Read authoritative editing fields and an opaque concurrency revision. Bank-wide Users2/User Read required.
     * @param string $bankKid
     * @param string $userKid
     * @return UserWorkspaceResponse
     */
    public function getBankUserWorkspace(mixed $bankKid, mixed $userKid): mixed
    {
        return $this->request('GetBankUserWorkspace', ['bankKid' => $bankKid, 'userKid' => $userKid], null);
    }

    /**
     * Read the resident activation code for printing. Requires bank-wide Users2/User Create.
     * @param string $bankKid
     * @param string $userKid
     * @return UserActivationResponse
     */
    public function getBankUserActivation(mixed $bankKid, mixed $userKid): mixed
    {
        return $this->request('GetBankUserActivation', ['bankKid' => $bankKid, 'userKid' => $userKid], null);
    }

    /**
     * Execute profile, icon, attributes, tag, location, delete, restore or replace with the revision from GetBankUserWorkspace.
     * @param string $bankKid
     * @param string $userKid
     * @param UserCommandRequest $body
     * @return UserWorkspaceResponse
     */
    public function executeBankUserCommand(mixed $bankKid, mixed $userKid, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ExecuteBankUserCommand', ['bankKid' => $bankKid, 'userKid' => $userKid], $body);
    }

    /**
     * Count the complete filtered export selection using the same directory authorization and visibility.
     * @param array{'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool} $options
     * @return DirectoryExportCountResponse
     */
    public function getUserExportCount(array $options = []): mixed
    {
        return $this->request('GetUserExportCount', [] + $options, null);
    }

    /**
     * List authorized residents for UserFinder1 (77).
     * @param array{'pageSize'?: int, 'cursor'?: string, 'filter'?: string, 'sort'?: string, 'direction'?: string, 'enabledOnly'?: bool} $options
     * @return UserDirectoryResponse
     */
    public function getUsers(array $options = []): mixed
    {
        return $this->request('GetUsers', [] + $options, null);
    }

    /**
     * Count active authorized residents for the UserFinder1 badge.
     * @return PeopleDirectoryCount
     */
    public function getUserCount(): mixed
    {
        return $this->request('GetUserCount', [], null);
    }

    /**
     * Create an eVaskeri login link for one active Nortec resident.
     * @param string $userKid
     * @return UserEvaskeriSession
     */
    public function createUserEvaskeriSession(mixed $userKid): mixed
    {
        return $this->request('CreateUserEvaskeriSession', ['userKid' => $userKid], null);
    }

    /**
     * Read complete receipts for one resident, newest first, twenty receipts at a time.
     * @param string $userKid
     * @param array{'offset'?: int, 'revision'?: string} $options
     * @return UserReceiptsResponse
     */
    public function getUserReceipts(mixed $userKid, array $options = []): mixed
    {
        return $this->request('GetUserReceipts', ['userKid' => $userKid] + $options, null);
    }

    /**
     * Search resident Number, Name, Email, SMS and partial numeric TagId using current Log7.
     * @param array{'q'?: string, 'kidOnly'?: bool} $options
     * @return SearchResults
     */
    public function searchUsers(array $options = []): mixed
    {
        return $this->request('SearchUsers', [] + $options, null);
    }

    /**
     * Search complete resident SMS numbers with indexed exact Log7 Text matches.
     * @param array{'q'?: string} $options
     * @return SearchResults
     */
    public function searchUserSms(array $options = []): mixed
    {
        return $this->request('SearchUserSms', [] + $options, null);
    }

    /**
     * Decode an ordinary resident activation code and resolve name and icon from current Log7.
     * @param array{'q'?: string} $options
     * @return SearchResults
     */
    public function searchUserActivation(array $options = []): mixed
    {
        return $this->request('SearchUserActivation', [] + $options, null);
    }

    /**
     * Start a five-minute pairing. Keep deviceCode private; show only pairingId in the QR code.
     * @param StartWallboardPairing $body
     * @return WallboardPairingStarted
     */
    public function startWallboardPairing(#[\SensitiveParameter] array $body): mixed
    {
        return $this->request('StartWallboardPairing', [], $body);
    }

    /**
     * Find up to ten pending screens with an exact display ID in this tenant and environment.
     * @param array{'displayId'?: string} $options
     * @return list<WallboardPairingInfo>
     */
    public function findWallboardPairings(array $options = []): mixed
    {
        return $this->request('FindWallboardPairings', [] + $options, null);
    }

    /**
     * Read the screen ID and expiry before explicitly approving its QR code.
     * @param string $pairingId
     * @return WallboardPairingInfo
     */
    public function getWallboardPairing(mixed $pairingId): mixed
    {
        return $this->request('GetWallboardPairing', ['pairingId' => $pairingId], null);
    }

    /**
     * Approve one screen using your current manager bearer session, including sessions created with kid and apiKey.
     * @param string $pairingId
     * @param ApproveWallboardPairing $body
     * @return null
     */
    public function approveWallboardPairing(mixed $pairingId, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ApproveWallboardPairing', ['pairingId' => $pairingId], $body);
    }

    /**
     * Poll with the private deviceCode. Successful redemption consumes the pairing atomically.
     * @param string $pairingId
     * @param RedeemWallboardPairing $body
     * @return WallboardPairingToken
     */
    public function redeemWallboardPairing(mixed $pairingId, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('RedeemWallboardPairing', ['pairingId' => $pairingId], $body);
    }

    /**
     * Request a two-minute signing challenge for a permanently approved screen.
     * @param string $deviceId
     * @return WallboardDeviceChallenge
     */
    public function challengeWallboardDevice(mixed $deviceId): mixed
    {
        return $this->request('ChallengeWallboardDevice', ['deviceId' => $deviceId], null);
    }

    /**
     * Resume a permanently approved screen after proving possession of its private signing key.
     * @param string $deviceId
     * @param ResumeWallboardSession $body
     * @return WallboardPairingToken
     */
    public function resumeWallboardSession(mixed $deviceId, #[\SensitiveParameter] array $body): mixed
    {
        return $this->request('ResumeWallboardSession', ['deviceId' => $deviceId], $body);
    }

    /**
     * Read a screen you approved, including the optional scanner location stored with its approval.
     * @param string $deviceId
     * @return WallboardDeviceInfo
     */
    public function getWallboardDevice(mixed $deviceId): mixed
    {
        return $this->request('GetWallboardDevice', ['deviceId' => $deviceId], null);
    }

    /**
     * Revoke a screen you approved. Its existing bearer sessions also lose access.
     * @param string $deviceId
     * @return null
     */
    public function revokeWallboardDevice(mixed $deviceId): mixed
    {
        return $this->request('RevokeWallboardDevice', ['deviceId' => $deviceId], null);
    }

    /**
     * Displays Windows downloads for this tenant, or an explicit unavailable state.
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getPortalAppDownloadPage(mixed $destination): mixed
    {
        return $this->request('GetPortalAppDownloadPage', [], null, $destination);
    }

    /**
     * Downloads a tenant-bound Windows App Installer file with update checks at launch.
     * @param string $architecture
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function downloadPortalWindowsAppInstaller(mixed $architecture, mixed $destination): mixed
    {
        return $this->request('DownloadPortalWindowsAppInstaller', ['architecture' => $architecture], null, $destination);
    }

    /**
     * Downloads an immutable signed Windows package, with byte-range and conditional request support.
     * @param string $architecture
     * @param string $fileName
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function downloadPortalWindowsPackage(mixed $architecture, mixed $fileName, mixed $destination): mixed
    {
        return $this->request('DownloadPortalWindowsPackage', ['architecture' => $architecture, 'fileName' => $fileName], null, $destination);
    }

    /**
     * Renders an angular color-gradient background at 200 × 200 pixels.
     * @param string $colors
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getCircleGradient(mixed $colors, mixed $destination): mixed
    {
        return $this->request('GetCircleGradient', ['colors' => $colors], null, $destination);
    }

    /**
     * Renders an angular gradient at a selected width and height.
     * @param string $colors
     * @param int $width
     * @param int $height
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getCircleGradientSized(mixed $colors, mixed $width, mixed $height, mixed $destination): mixed
    {
        return $this->request('GetCircleGradientSized', ['colors' => $colors, 'width' => $width, 'height' => $height], null, $destination);
    }

    /**
     * Renders a progress circle with one square mark per percentage point.
     * @param string $background
     * @param string $colors
     * @param int $percent
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getCircleProgress(mixed $background, mixed $colors, mixed $percent, mixed $destination): mixed
    {
        return $this->request('GetCircleProgress', ['background' => $background, 'colors' => $colors, 'percent' => $percent], null, $destination);
    }

    /**
     * Renders a progress circle at a selected width and height.
     * @param string $background
     * @param string $colors
     * @param int $percent
     * @param int $width
     * @param int $height
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getCircleProgressSized(mixed $background, mixed $colors, mixed $percent, mixed $width, mixed $height, mixed $destination): mixed
    {
        return $this->request('GetCircleProgressSized', ['background' => $background, 'colors' => $colors, 'percent' => $percent, 'width' => $width, 'height' => $height], null, $destination);
    }

    /**
     * Renders a rotating semicircle to indicate running or indeterminate progress.
     * @param string $color
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getCircleRunning(mixed $color, mixed $destination): mixed
    {
        return $this->request('GetCircleRunning', ['color' => $color], null, $destination);
    }

    /**
     * Renders a running indicator at a selected width and height.
     * @param string $color
     * @param int $width
     * @param int $height
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getCircleRunningSized(mixed $color, mixed $width, mixed $height, mixed $destination): mixed
    {
        return $this->request('GetCircleRunningSized', ['color' => $color, 'width' => $width, 'height' => $height], null, $destination);
    }

    /**
     * Renders a linear gradient at 200 × 200 pixels.
     * @param string $colors
     * @param int|float $angle
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getLinearGradient(mixed $colors, mixed $angle, mixed $destination): mixed
    {
        return $this->request('GetLinearGradient', ['colors' => $colors, 'angle' => $angle], null, $destination);
    }

    /**
     * Renders a linear gradient at a selected width and height.
     * @param string $colors
     * @param int|float $angle
     * @param int $width
     * @param int $height
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getLinearGradientSized(mixed $colors, mixed $angle, mixed $width, mixed $height, mixed $destination): mixed
    {
        return $this->request('GetLinearGradientSized', ['colors' => $colors, 'angle' => $angle, 'width' => $width, 'height' => $height], null, $destination);
    }

    /**
     * Resolve an IconKid, optionally changing its text, count or RGB colour.
     * @param array{'iconKid'?: string, 'text'?: string, 'count'?: int, 'color'?: int, 'useCalendarText'?: bool} $options
     * @return IconPresentationResponse
     */
    public function getIconPresentation(array $options = []): mixed
    {
        return $this->request('GetIconPresentation', [] + $options, null);
    }

    /**
     * Lists canonical icon names with an asset in the requested local set.
     * @param string $iconSet
     * @return list<string>
     */
    public function getIconAssetCatalog(mixed $iconSet): mixed
    {
        return $this->request('GetIconAssetCatalog', ['iconSet' => $iconSet], null);
    }

    /**
     * Renders Kid.Icon from a named local asset set, with Kid.Count as the badge.
     * @param string $iconSet
     * @param string $kid
     * @param string $format
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getIconFromSet(mixed $iconSet, mixed $kid, mixed $format, mixed $destination): mixed
    {
        return $this->request('GetIconFromSet', ['iconSet' => $iconSet, 'kid' => $kid, 'format' => $format], null, $destination);
    }

    /**
     * Renders Kid.Icon and Kid.Count from a named set at a square pixel size.
     * @param string $iconSet
     * @param string $kid
     * @param int $size
     * @param string $format
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getIconImageFromSet(mixed $iconSet, mixed $kid, mixed $size, mixed $format, mixed $destination): mixed
    {
        return $this->request('GetIconImageFromSet', ['iconSet' => $iconSet, 'kid' => $kid, 'size' => $size, 'format' => $format], null, $destination);
    }

    /**
     * Renders Kid.Icon and Kid.Count from a named set with a raster background.
     * @param string $iconSet
     * @param string $kid
     * @param string $backColor
     * @param int $size
     * @param string $format
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getIconImageWithBackgroundFromSet(mixed $iconSet, mixed $kid, mixed $backColor, mixed $size, mixed $format, mixed $destination): mixed
    {
        return $this->request('GetIconImageWithBackgroundFromSet', ['iconSet' => $iconSet, 'kid' => $kid, 'backColor' => $backColor, 'size' => $size, 'format' => $format], null, $destination);
    }

    /**
     * Renders a responsive Kombine symbol that fits its viewport without stretching.
     * @param string $color
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogo(mixed $color, mixed $destination): mixed
    {
        return $this->request('GetKombineLogo', ['color' => $color], null, $destination);
    }

    /**
     * Renders the square Kombine symbol at the selected width.
     * @param string $color
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoSized(mixed $color, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoSized', ['color' => $color, 'width' => $width], null, $destination);
    }

    /**
     * Renders the Kombine symbol with an explicit background and width.
     * @param string $color
     * @param string $background
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoWithBackground(mixed $color, mixed $background, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoWithBackground', ['color' => $color, 'background' => $background, 'width' => $width], null, $destination);
    }

    /**
     * Renders selected parts of the Kombine symbol in its original square viewport.
     * @param string $parts
     * @param string $color
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoParts(mixed $parts, mixed $color, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoParts', ['parts' => $parts, 'color' => $color], null, $destination);
    }

    /**
     * Renders selected Kombine symbol parts at the selected width.
     * @param string $parts
     * @param string $color
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoPartsSized(mixed $parts, mixed $color, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoPartsSized', ['parts' => $parts, 'color' => $color, 'width' => $width], null, $destination);
    }

    /**
     * Renders selected Kombine symbol parts with an explicit background and width.
     * @param string $parts
     * @param string $color
     * @param string $background
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoPartsWithBackground(mixed $parts, mixed $color, mixed $background, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoPartsWithBackground', ['parts' => $parts, 'color' => $color, 'background' => $background, 'width' => $width], null, $destination);
    }

    /**
     * Renders the Kombine name and registered mark, without the symbol.
     * @param string $color
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineText(mixed $color, mixed $destination): mixed
    {
        return $this->request('GetKombineText', ['color' => $color], null, $destination);
    }

    /**
     * Renders the Kombine wordmark at the selected width.
     * @param string $color
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineTextSized(mixed $color, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineTextSized', ['color' => $color, 'width' => $width], null, $destination);
    }

    /**
     * Renders the Kombine wordmark with an explicit background and width.
     * @param string $color
     * @param string $background
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineTextWithBackground(mixed $color, mixed $background, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineTextWithBackground', ['color' => $color, 'background' => $background, 'width' => $width], null, $destination);
    }

    /**
     * Renders the Kombine symbol and name together.
     * @param string $color
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoText(mixed $color, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoText', ['color' => $color], null, $destination);
    }

    /**
     * Renders the combined Kombine logo at the selected width.
     * @param string $color
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoTextSized(mixed $color, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoTextSized', ['color' => $color, 'width' => $width], null, $destination);
    }

    /**
     * Renders the combined Kombine logo with an explicit background and width.
     * @param string $color
     * @param string $background
     * @param int $width
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getKombineLogoTextWithBackground(mixed $color, mixed $background, mixed $width, mixed $destination): mixed
    {
        return $this->request('GetKombineLogoTextWithBackground', ['color' => $color, 'background' => $background, 'width' => $width], null, $destination);
    }

    /**
     * Get the portal chart's localized messages and stable state identifiers.
     * @return CycleChartPresentationResponse
     */
    public function getCycleChartPresentation(): mixed
    {
        return $this->request('GetCycleChartPresentation', [], null);
    }

    /**
     * Returns the site overview's running-machine pool, refreshed at most once a minute.
     * @return list<LiveMachineResponse>
     */
    public function getPublicLiveMachines(): mixed
    {
        return $this->request('GetPublicLiveMachines', [], null);
    }

    /**
     * List machines with a positive AutoOutOfOrder Id without login.
     * @param array{'pageSize'?: int, 'cursor'?: string} $options
     * @return PublicMachineErrorsPage
     */
    public function getPublicMachineErrors(array $options = []): mixed
    {
        return $this->request('GetPublicMachineErrors', [] + $options, null);
    }

    /**
     * Get the ten newest photos, including Live Photo stills, newest first.
     * @return list<PublicCameraPhoto>
     */
    public function getPublicRecentCameraPhotos(): mixed
    {
        return $this->request('GetPublicRecentCameraPhotos', [], null);
    }

    /**
     * Read only the JPEG thumbnail authorized by a ten-minute, tenant-bound public ticket.
     * @param string $id
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getPublicCameraThumbnail(mixed $id, mixed $destination): mixed
    {
        return $this->request('GetPublicCameraThumbnail', ['id' => $id], null, $destination);
    }

    /**
     * Get a square WashDoc widget's graph, machine/location names and document times.
     * @param array{'cycleKid'?: string, 'unitKid'?: string} $options
     * @return PublicCycleWidgetResponse
     */
    public function getPublicCycleWidget(array $options = []): mixed
    {
        return $this->request('GetPublicCycleWidget', [] + $options, null);
    }

    /**
     * Draws purchase counts for the last hour in twelve five-minute intervals.
     * @param string $color
     * @param resource $destination Writable stream; may contain partial data on failure.
     * @return DownloadResponse
     */
    public function getPublicPurchasesChart(mixed $color, mixed $destination): mixed
    {
        return $this->request('GetPublicPurchasesChart', ['color' => $color], null, $destination);
    }

    /**
     * Shows recent purchases as coin markers on a map. No login required.
     * @param array{'limit'?: int} $options
     * @return PurchaseMapSnapshot
     */
    public function getPublicDisp73(array $options = []): mixed
    {
        return $this->request('GetPublicDisp73', [] + $options, null);
    }

    /**
     * Get progress for one unit or a page of all public units in a location or bank.
     * @param string $kid
     * @param array{'pageSize'?: int, 'cursor'?: string} $options
     * @return PublicScopedProgressResponse
     */
    public function getPublicScopedUnitProgress(mixed $kid, array $options = []): mixed
    {
        return $this->request('GetPublicScopedUnitProgress', ['kid' => $kid] + $options, null);
    }

    /**
     * Counts purchases in the site's Log1Hour without login.
     * @return PurchasesResponse
     */
    public function getPublicPurchases(): mixed
    {
        return $this->request('GetPublicPurchases', [], null);
    }

    /**
     * Counts active users in the site's current Log7 during the last 100 days, without login.
     * @return ActiveUsersResponse
     */
    public function getPublicActiveUsers(): mixed
    {
        return $this->request('GetPublicActiveUsers', [], null);
    }

    /**
     * Get localized labels and the site's palette for the shared JavaScript widgets.
     * @return PublicWidgetPresentationResponse
     */
    public function getPublicWidgetPresentation(): mixed
    {
        return $this->request('GetPublicWidgetPresentation', [], null);
    }

    /**
     * Counts noncancelled dated reservations that have not ended, including ongoing reservations.
     * @return ReservationsStatisticsResponse
     */
    public function getPublicReservations(): mixed
    {
        return $this->request('GetPublicReservations', [], null);
    }

    /**
     * Counts machines whose current Started is before now and Done is after now.
     * @return RunningMachinesResponse
     */
    public function getPublicRunningMachines(): mixed
    {
        return $this->request('GetPublicRunningMachines', [], null);
    }

    /**
     * Gets public API availability. This does not check database readiness.
     * @return ApiStatusResponse
     */
    public function getPortalStatus(): mixed
    {
        return $this->request('GetPortalStatus', [], null);
    }
}
