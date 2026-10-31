# PHP wire models

Requests and responses use associative arrays with exact JSON field names. Dates remain strings. All integer fields use 64-bit PHP integers; never convert them to floats. Null and absent values are preserved.

### AccountDocumentResponse

```php
array{'key'?: string|null, 'docId'?: int|null, 'lines'?: list<AccountEntryResponse>|null, 'totals'?: list<AccountTotal>|null}
```

### AccountEntryResponse

```php
array{'kid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'userKid'?: string|null, 'recordedAtUtc'?: string, 'amountMinor'?: int, 'currency'?: string|null, 'description'?: string|null, 'transactionType'?: string|null, 'period'?: int, 'reversed'?: bool, 'reversalOfKid'?: string|null, 'userName'?: string|null, 'userNumber'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'canReverse'?: bool, 'unitIconKid'?: string|null, 'documentKey'?: string|null, 'documentId'?: int|null, 'isAnonymized'?: bool, 'paymentKind'?: string|null}
```

### AccountIconResponse

```php
array{'currency'?: string|null, 'iconKid'?: string|null}
```

### AccountResponse

```php
array{'items'?: list<AccountEntryResponse>|null, 'units'?: list<AccountUnitResponse>|null, 'periods'?: list<int>|null, 'totals'?: list<AccountTotal>|null, 'from'?: string, 'through'?: string, 'timeZone'?: string|null, 'period'?: int|null, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool, 'revision'?: string|null, 'documents'?: list<AccountDocumentResponse>|null}
```

### AccountRevisionResponse

```php
array{'revision'?: string|null}
```

### AccountTotal

```php
array{'currency'?: string|null, 'entries'?: int, 'amountMinor'?: int}
```

### AccountUnitResponse

```php
array{'locationKid'?: string|null, 'unitKid'?: string|null, 'locationName'?: string|null, 'name'?: string|null}
```

### AcknowledgeErrorRequest

```php
array{'expectedRevision': string|null}
```

### ActiveBankCountResponse

```php
array{'count'?: int, 'iconKid'?: string|null}
```

### ActiveLocationCountResponse

```php
array{'count'?: int, 'iconKid'?: string|null}
```

### ActiveUnitCountResponse

```php
array{'count'?: int, 'iconKid'?: string|null}
```

### ApproveWallboardPairing

```php
array{'location'?: WallboardScanLocation}
```

### AssistantLink

```php
array{'kid'?: string|null, 'path'?: string|null, 'name'?: string|null, 'bankKid'?: string|null, 'iconKid'?: string|null}
```

### AssistantMessage

```php
array{'role'?: string|null, 'content'?: string|null}
```

### AssistantRequest

```php
array{'question': string, 'history'?: list<AssistantMessage>|null}
```

### AssistantResponse

```php
array{'answer'?: string|null, 'operations'?: list<string>|null, 'links'?: list<AssistantLink>|null}
```

### BankDirectoryItem

```php
array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'fields'?: array<string,mixed>|null}
```

### BankDirectoryResponse

```php
array{'items'?: list<BankDirectoryItem>|null, 'nextCursor'?: string|null, 'fields'?: list<string>|null, 'canReadBankActivationCode'?: bool}
```

### BankDocumentItem

```php
array{'kid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int|null, 'lastActivityUtc'?: string, 'unitIconKid'?: string|null}
```

### BankDocumentPage

```php
array{'items'?: list<BankDocumentItem>|null, 'locations'?: list<BankLocationResponse>|null, 'units'?: list<DocumentUnitOption>|null, 'from'?: string, 'through'?: string, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool}
```

### BankIconResponse

```php
array{'kid'?: string|null, 'iconKid'?: string|null, 'offline'?: bool|null, 'status'?: int}
```

### BankIconsResponse

```php
array{'items'?: list<BankIconResponse>|null}
```

### BankLocationResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
```

### BankLocationStatusResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'iconKid'?: string|null}
```

### BankNavigationResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
```

### BankUserResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'number'?: string|null, 'deletedAt'?: string|null, 'locations'?: list<UserLocationResponse>|null, 'tags'?: list<UserTagResponse>|null, 'attributes'?: list<UserAttributeResponse>|null, 'email'?: string|null, 'sms'?: string|null, 'iconKid'?: string|null}
```

### BankUsersResponse

```php
array{'items'?: list<BankUserResponse>|null, 'previousCursor'?: string|null, 'nextCursor'?: string|null, 'scanLimitReached'?: bool}
```

### BookingCommand

```php
array{'action'?: string|null}
```

### BookingResponse

```php
array{'kid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'userKid'?: string|null, 'startLocal'?: string|null, 'endLocal'?: string|null, 'weeklyMinute'?: int|null, 'durationMinutes'?: int, 'recordedAtUtc'?: string, 'cancelled'?: bool, 'synced'?: bool, 'source'?: string|null, 'userName'?: string|null, 'userNumber'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'canCancel'?: bool, 'canRestore'?: bool, 'unitIconKid'?: string|null}
```

### BookingRuleUnit

```php
array{'kid'?: string|null, 'name'?: string|null}
```

### BookingUnitResponse

```php
array{'locationKid'?: string|null, 'unitKid'?: string|null, 'locationName'?: string|null, 'name'?: string|null}
```

### BookingsResponse

```php
array{'items'?: list<BookingResponse>|null, 'units'?: list<BookingUnitResponse>|null, 'from'?: string, 'through'?: string, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool}
```

### CameraAvailabilityResponse

```php
array{'hasCaptures'?: bool, 'isDegraded'?: bool, 'canCapture'?: bool}
```

### CameraCaptureItem

```php
array{'id'?: string|null, 'captureId'?: string|null, 'resourceKid'?: string|null, 'ownerKid'?: string|null, 'fileName'?: string|null, 'kind'?: string|null, 'capturedAtUtc'?: string, 'hasPreview'?: bool, 'hasMotion'?: bool, 'hasPlayback'?: bool, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null}
```

### CameraCapturePage

```php
array{'items'?: list<CameraCaptureItem>|null, 'nextCursor'?: string|null, 'isDegraded'?: bool}
```

### CameraConfirmationRequest

```php
array{'uploadToken'?: string|null}
```

### CameraConfirmationResponse

```php
array{'confirmed'?: bool, 'errorCode'?: string|null, 'processingPercent'?: int|null}
```

### CameraPrepareRequest

```php
array{'resourceKid'?: string|null, 'kind'?: string|null, 'originalFileName'?: string|null, 'originalNameAvailable'?: bool, 'capturedAtUtc'?: string, 'mediaLength'?: int, 'mediaSha256'?: string|null, 'sensorData'?: array<string,mixed>, 'motionLength'?: int|null, 'motionSha256'?: string|null}
```

### CameraPrepareResponse

```php
array{'uploadToken'?: string|null}
```

### CameraResourceResponse

```php
array{'resourceKid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'requiresProximityCheck'?: bool, 'latitude'?: int|float|null, 'longitude'?: int|float|null}
```

### CameraSaveResponse

```php
array{'captureId'?: string|null, 'resourceKid'?: string|null}
```

### ChecklistItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'period'?: int, 'isLatest'?: bool, 'bankName'?: string|null, 'locationName'?: string|null, 'hardware'?: string|null, 'periodDateUtc'?: string|null, 'nextSettlementUtc'?: string|null, 'lastRunUtc'?: string|null, 'updatedAtUtc'?: string|null, 'hidden'?: bool, 'onChecklist'?: bool, 'scheduleStatus'?: string|null, 'processing'?: ChecklistProcessing}
```

### ChecklistPage

```php
array{'items'?: list<ChecklistItem>|null, 'nextCursor'?: string|null, 'readAtUtc'?: string}
```

### ChecklistProcessing

```php
array{'invoice'?: ChecklistStatus, 'soapInvoice'?: ChecklistStatus, 'soapCredit'?: ChecklistStatus, 'easyPay'?: ChecklistStatus}
```

### ChecklistStatus

```php
array{'code'?: int|null, 'state'?: string|null}
```

### DatabaseAccessResponse

```php
array{'canWrite'?: bool|null, 'checkedAtUtc'?: string}
```

### DirectoryExportCountResponse

```php
array{'count'?: int}
```

### DocumentCell

```php
array{'value'?: int|float|null, 'text'?: string|null, 'isCalculated'?: bool}
```

### DocumentColumn

```php
array{'kind'?: string|null, 'name'?: string|null, 'localization'?: string|null, 'color'?: string|null, 'onlyNumericValues'?: bool, 'iconKid'?: string|null}
```

### DocumentNeighbor

```php
array{'kid'?: string|null, 'lastActivityUtc'?: string}
```

### DocumentNeighbors

```php
array{'previous'?: DocumentNeighbor, 'next'?: DocumentNeighbor}
```

### DocumentTable

```php
array{'cycleKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'finished'?: bool, 'fromMs2000'?: int, 'toMs2000'?: int, 'columns'?: list<DocumentColumn>|null, 'rows'?: list<DocumentTableRow>|null}
```

### DocumentTableRow

```php
array{'ms2000'?: int, 'cells'?: list<DocumentCell>|null}
```

### DocumentUnitOption

```php
array{'kid'?: string|null, 'locationKid'?: string|null, 'name'?: string|null, 'unitType'?: int|null}
```

### HostingBandwidth

```php
array{'dateUtc'?: string, 'bytes'?: string|null, 'errorCode'?: string|null}
```

### HostingLogsResponse

```php
array{'environment'?: string|null, 'application'?: string|null, 'fetchedAtUtc'?: string, 'lines'?: list<string>|null, 'truncated'?: bool}
```

### HostingMetric

```php
array{'name'?: string|null, 'unit'?: string|null, 'series'?: list<HostingSeries>|null, 'errorCode'?: string|null}
```

### HostingMetricsResponse

```php
array{'environment'?: string|null, 'application'?: string|null, 'fromUtc'?: string, 'toUtc'?: string, 'fetchedAtUtc'?: string, 'refreshAfterSeconds'?: int, 'metrics'?: list<HostingMetric>|null, 'bandwidth'?: HostingBandwidth}
```

### HostingPoint

```php
array{'timestampUtc'?: string, 'value'?: int|float|null}
```

### HostingSeries

```php
array{'component'?: string|null, 'instance'?: string|null, 'points'?: list<HostingPoint>|null}
```

### InstallerDetailsResponse

```php
array{'installer'?: InstallerDirectoryItem, 'canEditIcon'?: bool, 'iconRevision'?: string|null, 'availableIcons'?: list<string>|null}
```

### InstallerDirectoryItem

```php
array{'kid'?: string|null, 'name'?: string|null, 'email'?: string|null, 'locations'?: list<InstallerLocationResponse>|null, 'tags'?: list<InstallerTagResponse>|null, 'deleted'?: bool, 'deletedAt'?: string|null, 'enabled'?: bool|null, 'lastActiveAt'?: string|null, 'activationCode'?: string|null, 'iconKid'?: string|null}
```

### InstallerDirectoryResponse

```php
array{'items'?: list<InstallerDirectoryItem>|null, 'nextCursor'?: string|null}
```

### InstallerIconRequest

```php
array{'icon': string|null, 'expectedRevision': string|null}
```

### InstallerIconResponse

```php
array{'kid'?: string|null, 'iconRevision'?: string|null, 'availableIcons'?: list<string>|null, 'iconKid'?: string|null}
```

### InstallerLocationResponse

```php
array{'kid'?: string|null, 'state'?: string|null}
```

### InstallerTagResponse

```php
array{'kid'?: string|null, 'state'?: string|null}
```

### LiveLogCard

```php
array{'server'?: string|null, 'errorCode'?: string|null, 'events'?: list<LiveLogEvent>|null}
```

### LiveLogEvent

```php
array{'timestamp'?: string, 'level'?: string|null, 'message'?: string|null, 'category'?: string|null, 'statusCode'?: int|null, 'elapsedMilliseconds'?: int|null, 'bankId'?: int|null, 'userIds'?: list<int>|null, 'traceId'?: string|null, 'question'?: string|null, 'fields'?: array<string,mixed>|null}
```

### LiveLogsResponse

```php
array{'tenantKid'?: string|null, 'fetchedAtUtc'?: string, 'refreshAfterSeconds'?: int, 'servers'?: list<LiveLogCard>|null}
```

### LocationBookingCalendarDayResponse

```php
array{'dayOfWeek'?: int, 'slots'?: list<LocationBookingCalendarSlotResponse>|null, 'date'?: string}
```

### LocationBookingCalendarGroup

```php
array{'units'?: list<LocationBookingCalendarUnit>|null, 'status'?: string|null, 'days'?: list<LocationBookingCalendarDayResponse>|null}
```

### LocationBookingCalendarSlotResponse

```php
array{'startMinute'?: int, 'durationMinutes'?: int, 'type'?: int}
```

### LocationBookingCalendarUnit

```php
array{'kid'?: string|null, 'name'?: string|null}
```

### LocationBookingCalendarsResponse

```php
array{'locationKid'?: string|null, 'groups'?: list<LocationBookingCalendarGroup>|null, 'timeZone'?: string|null, 'from'?: string, 'days'?: int}
```

### LocationBookingRule

```php
array{'code'?: string|null, 'text'?: string|null, 'warning'?: bool, 'parts'?: list<LocationBookingRulePart>|null}
```

### LocationBookingRuleGroup

```php
array{'name'?: string|null, 'units'?: list<BookingRuleUnit>|null, 'rules'?: list<LocationBookingRule>|null, 'common'?: bool, 'help'?: string|null}
```

### LocationBookingRulePart

```php
array{'text'?: string|null, 'isValue'?: bool}
```

### LocationBookingRulesResponse

```php
array{'locationKid'?: string|null, 'calculatedAt'?: string, 'groups'?: list<LocationBookingRuleGroup>|null}
```

### LocationCountResponse

```php
array{'count'?: int}
```

### LocationDirectoryItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'bankName'?: string|null, 'name'?: string|null, 'vismaCustNo'?: string|null, 'bankActivationCode'?: string|null, 'locationActivationCode'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'longitude'?: int|float|null, 'latitude'?: int|float|null, 'teltonikaSms'?: string|null, 'alternativeBankName'?: string|null, 'mask'?: string|null, 'timeZone'?: string|null, 'online'?: bool|null, 'lastContactAt'?: string|null, 'vismaCrAcNo'?: string|null, 'vismaInvoiceVersion'?: string|null, 'vismaOrdre'?: string|null, 'vismaPNTurnover'?: string|null, 'vismaPNSettlement'?: string|null, 'vismaSettlement'?: string|null, 'vismaVAT'?: string|null, 'vismaServiceKey'?: string|null, 'vismaStart'?: string|null, 'vismaNote'?: string|null, 'hiddenNote'?: string|null, 'vismaGuaranteeMonth'?: string|null, 'vismaGuaranteeUnder'?: string|null, 'vismaGuarantee'?: string|null, 'vismaGuaranteeCustomer'?: string|null, 'vismaGuaranteeOver'?: string|null, 'gift'?: string|null, 'giftBegin'?: string|null, 'giftEnd'?: string|null, 'giftSplit'?: string|null, 'giftPN'?: string|null, 'soapEnd'?: string|null, 'iconKid'?: string|null, 'bankIconKid'?: string|null}
```

### LocationDirectoryResponse

```php
array{'items'?: list<LocationDirectoryItem>|null, 'nextCursor'?: string|null, 'hasAllBanksAccess'?: bool, 'fields'?: list<string>|null}
```

### LocationIconResponse

```php
array{'kid'?: string|null, 'iconKid'?: string|null, 'offline'?: bool|null, 'status'?: int}
```

### LocationIconsResponse

```php
array{'items'?: list<LocationIconResponse>|null}
```

### LocationOpeningHoursResponse

```php
array{'locationKid'?: string|null, 'timeZone'?: string|null, 'calculatedAt'?: string, 'groups'?: list<OpeningHoursGroup>|null}
```

### LocationReservationHistoryItem

```php
array{'unitKid'?: string|null, 'startMinute'?: int, 'durationMinutes'?: int, 'revision'?: int, 'cancelled'?: bool, 'userNumber'?: string|null, 'userName'?: string|null, 'userKid'?: string|null}
```

### LocationReservationHistoryResponse

```php
array{'locationKid'?: string|null, 'from'?: string, 'days'?: int, 'items'?: list<LocationReservationHistoryItem>|null}
```

### LocationReservationResponse

```php
array{'unitKid'?: string|null, 'startMinute'?: int, 'durationMinutes'?: int, 'userNumber'?: string|null, 'userName'?: string|null, 'userKid'?: string|null}
```

### LocationReservationsResponse

```php
array{'locationKid'?: string|null, 'from'?: string, 'days'?: int, 'items'?: list<LocationReservationResponse>|null}
```

### LocationUnitsResponse

```php
array{'location'?: BankLocationResponse, 'items'?: list<UnitOverviewResponse>|null}
```

### LocationWeatherCurrent

```php
array{'observedAtUtc'?: string, 'retrievedAtUtc'?: string, 'temperatureCelsius'?: int|float, 'apparentTemperatureCelsius'?: int|float|null, 'windSpeedMetresPerSecond'?: int|float|null, 'precipitationMillimetres'?: int|float|null, 'relativeHumidityPercent'?: int|float|null, 'weatherCode'?: int|null, 'isDay'?: bool|null}
```

### LocationWeatherResponse

```php
array{'locationKid'?: string|null, 'status'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'positionSource'?: string|null, 'current'?: LocationWeatherCurrent|null}
```

### ManagerCreationResponse

```php
array{'kid'?: string|null}
```

### ManagerDirectoryItem

```php
array{'kid'?: string|null, 'name'?: string|null, 'email'?: string|null, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'tabs'?: list<ManagerTabResponse>|null, 'iconKid'?: string|null, 'gravatarUrl'?: string|null, 'organisation'?: string|null, 'enabled'?: bool|null, 'deleted'?: bool, 'deletedAt'?: string|null, 'lastActiveAt'?: string|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null, 'retentionDays'?: int, 'isCurrentManager'?: bool, 'canEditPermissions'?: bool, 'canEditTabs'?: bool, 'canEditProfile'?: bool, 'profileRevision'?: string|null, 'tabsRevision'?: string|null, 'kidsRevision'?: string|null, 'canEditKids'?: bool, 'availableTabs'?: list<ManagerTabResponse>|null, 'availableIcons'?: list<string>|null}
```

### ManagerDirectoryResponse

```php
array{'items'?: list<ManagerDirectoryItem>|null, 'nextCursor'?: string|null}
```

### ManagerEmailMatch

```php
array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'gravatarUrl'?: string|null}
```

### ManagerForgotPasswordRequest

```php
array{'email': string, 'language'?: string|null}
```

### ManagerInvitationRequest

```php
array{'expectedRevision': string, 'language'?: string|null}
```

### ManagerInvitationResponse

```php
array{'code'?: string|null}
```

### ManagerKidChangeRequest

```php
array{'resourceKid': string|null, 'enabled'?: bool|null, 'expectedRevision': string|null}
```

### ManagerKidChangeResponse

```php
array{'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'kidsRevision'?: string|null, 'canEditKids'?: bool}
```

### ManagerLoginErrorResponse

```php
array{'code'?: string|null}
```

### ManagerLoginRequest

```php
array{'email'?: string|null, 'password'?: string|null, 'kid'?: string|null, 'apiKey'?: string|null}
```

### ManagerOperationPermissionResponse

```php
array{'resource'?: string|null, 'level'?: string|null, 'canRead'?: bool, 'canWrite'?: bool, 'canCreate'?: bool, 'flags'?: int|null, 'canDelete'?: bool, 'canRenameExternalId'?: bool, 'canRename'?: bool}
```

### ManagerPasswordResetResponse

```php
array{'code'?: string|null}
```

### ManagerPermissionChangeRequest

```php
array{'flag'?: int|null, 'enabled'?: bool|null, 'expectedFlags': int|null}
```

### ManagerPermissionRoleRequest

```php
array{'role': string|null, 'expectedFlags': array<string,mixed>|null, 'expectedTabsRevision'?: string|null, 'expectedKidsRevision'?: string|null}
```

### ManagerPermissionRoleResponse

```php
array{'role'?: string|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null, 'canEditPermissions'?: bool, 'tabs'?: list<ManagerTabResponse>|null, 'tabsRevision'?: string|null, 'canEditTabs'?: bool, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'kidsRevision'?: string|null, 'canEditKids'?: bool}
```

### ManagerProfileChangeRequest

```php
array{'value': mixed, 'expectedRevision': string|null}
```

### ManagerProfileChangeResponse

```php
array{'field': string|null, 'name': string|null, 'organisation': string|null, 'email': string|null, 'iconKid': string|null, 'gravatarUrl'?: string|null, 'availableIcons'?: list<string>|null, 'enabled'?: bool|null, 'deleted'?: bool, 'deletedMs2000'?: int, 'deletedAt'?: string|null, 'retentionDays'?: int, 'profileRevision': string|null, 'canEditProfile'?: bool}
```

### ManagerProfileResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'tabs'?: list<int>|null, 'hasBankAccess'?: bool, 'wallboardDisplayId'?: string|null, 'iconKid'?: string|null, 'databaseAccess'?: DatabaseAccessResponse, 'navigationBanks'?: list<BankNavigationResponse>|null, 'organisation'?: string|null, 'gravatarUrl'?: string|null, 'retentionDays'?: int, 'themeMode'?: eThemeMode, 'iconSet'?: string|null, 'language'?: int|null, 'dateFormat'?: string|null, 'numberFormat'?: string|null, 'lineSpacing'?: int|float, 'portalMaxOpenBanks'?: int|null, 'tabDetails'?: list<ManagerTabResponse>|null, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null}
```

### ManagerResetPasswordRequest

```php
array{'token': string, 'password': string, 'confirmPassword': string}
```

### ManagerResourceGrantResponse

```php
array{'kid'?: string|null, 'scope'?: string|null}
```

### ManagerSessionResponse

```php
array{'accessToken'?: string|null, 'expiresIn'?: int, 'tokenType'?: string|null}
```

### ManagerSignUpConfirmation

```php
array{'token'?: string|null}
```

### ManagerSignUpRequest

```php
array{'email'?: string|null, 'name'?: string|null, 'organisation'?: string|null, 'password'?: string|null, 'confirmPassword'?: string|null, 'language'?: string|null}
```

### ManagerTabChangeRequest

```php
array{'enabled'?: bool|null, 'expectedRevision': string|null}
```

### ManagerTabChangeResponse

```php
array{'tabs'?: list<ManagerTabResponse>|null, 'tabsRevision'?: string|null, 'canEditTabs'?: bool, 'canEditPermissions'?: bool}
```

### ManagerTabResponse

```php
array{'id'?: int, 'name'?: string|null, 'iconKid'?: string|null}
```

### ManagerThemeRequest

```php
array{'themeMode': eThemeMode}
```

### ManagerThemeResponse

```php
array{'themeMode'?: eThemeMode}
```

### NearestLocationItem

```php
array{'kid'?: string|null, 'name'?: string|null, 'bankName'?: string|null, 'iconKid'?: string|null, 'distanceMeters'?: int|float}
```

### ObjectAddressResponse

```php
array{'kid'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'latitude'?: int|null, 'longitude'?: int|null, 'autoLatitudeLongitude'?: int|null, 'revision'?: string|null, 'outcome'?: string|null, 'canWrite'?: bool}
```

### ObjectAddressRevisionRequest

```php
array{'expectedRevision': string|null}
```

### OpeningHoursGroup

```php
array{'units'?: list<OpeningHoursUnit>|null, 'weekly'?: list<OpeningHoursLine>|null, 'exceptions'?: list<OpeningHoursLine>|null, 'isOpenNow'?: bool|null, 'nextChange'?: string|null}
```

### OpeningHoursLine

```php
array{'label'?: string|null, 'status'?: string|null, 'opens'?: string|null, 'closes'?: string|null, 'closesNextDay'?: bool, 'daysOfWeek'?: list<int>|null, 'date'?: string|null}
```

### OpeningHoursUnit

```php
array{'kid'?: string|null, 'name'?: string|null}
```

### OutOfOrderItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int, 'outOfOrder'?: int, 'status'?: string|null, 'statusLabel'?: string|null, 'timestampUtc'?: string, 'changedBy'?: UnitSettingEditorResponse, 'revision'?: string|null, 'canRestore'?: bool}
```

### OutOfOrderPage

```php
array{'items'?: list<OutOfOrderItem>|null, 'nextCursor'?: string|null, 'refreshAfterSeconds'?: int}
```

### OutOfOrderRestoreRequest

```php
array{'expectedRevision': string|null}
```

### OutOfOrderRestoreResponse

```php
array{'kid'?: string|null, 'outOfOrder'?: int, 'status'?: string|null, 'timestampUtc'?: string, 'revision'?: string|null, 'sync'?: int|null}
```

### PeopleDirectoryCount

```php
array{'count'?: int, 'iconKid'?: string|null}
```

### PersonalAccountResult

```php
array{'code'?: string|null}
```

### PersonalApiKeyRequest

```php
array{'revision': string|null}
```

### PersonalApiKeyResponse

```php
array{'apiKey'?: string|null, 'details'?: PersonalManagerApiKey}
```

### PersonalEmailConfirmation

```php
array{'token': string|null}
```

### PersonalEmailRequest

```php
array{'email': string|null, 'currentPassword': string|null, 'language'?: string|null}
```

### PersonalManagerApiKey

```php
array{'hasApiKey'?: bool, 'revision'?: string|null}
```

### PersonalManagerProfile

```php
array{'kid'?: string|null, 'name'?: string|null, 'organisation'?: string|null, 'iconKid'?: string|null, 'email'?: string|null, 'emailVerified'?: bool, 'themeMode'?: eThemeMode, 'revision'?: string|null, 'availableIcons'?: list<string>|null, 'retentionDays'?: int, 'iconSet'?: string|null, 'language'?: int|null, 'dateFormat'?: string|null, 'numberFormat'?: string|null, 'lineSpacing'?: int|float, 'portalMaxOpenBanks'?: int|null}
```

### PersonalManagerTab

```php
array{'id'?: int, 'name'?: string|null}
```

### PersonalManagerTabs

```php
array{'kid'?: string|null, 'tabs'?: list<PersonalManagerTab>|null, 'availableTabs'?: list<PersonalManagerTab>|null, 'revision'?: string|null, 'canEdit'?: bool}
```

### PersonalPasswordRequest

```php
array{'currentPassword': string|null, 'password': string|null, 'confirmPassword': string|null, 'language'?: string|null}
```

### PersonalProfileRequest

```php
array{'revision': string|null, 'value': mixed}
```

### PersonalTabRequest

```php
array{'revision': string|null, 'enabled': bool}
```

### PersonalWallboardRequest

```php
array{'displayId': string|null}
```

### PersonalWallboardsResponse

```php
array{'wallboards'?: list<Wallboard>|null, 'revision'?: string|null, 'storageUsedCharacters'?: int, 'storageLimitCharacters'?: int}
```

### ProblemDetails

```php
array{'type'?: string|null, 'title'?: string|null, 'status'?: int|null, 'detail'?: string|null, 'instance'?: string|null}
```

### RedeemWallboardPairing

```php
array{'deviceCode'?: string|null}
```

### ResumeWallboardSession

```php
array{'challenge'?: string|null, 'signature'?: string|null}
```

### SavePersonalWallboardsRequest

```php
array{'revision'?: string|null, 'wallboards': mixed}
```

### SearchResult

```php
array{'kid'?: string|null, 'kind'?: string|null, 'name'?: string|null, 'zip'?: string|null, 'matchedSetting'?: string|null, 'matchedValue'?: string|null, 'isContext'?: bool, 'number'?: string|null, 'bankKid'?: string|null, 'iconKid'?: string|null}
```

### SearchResults

```php
array{'items'?: list<SearchResult>|null, 'hasMore'?: bool}
```

### ServiceApiKeyRequest

```php
array{'expectedRevision': string|null}
```

### ServiceApiKeyResponse

```php
array{'apiKey'?: string|null, 'details'?: ServiceDetailsResponse}
```

### ServiceDetailsResponse

```php
array{'service'?: ServiceDirectoryItem, 'hasApiKeyHash'?: bool, 'apiKeyHash'?: string|null, 'canEdit'?: bool, 'profileRevision'?: string|null, 'availableIcons'?: list<string>|null}
```

### ServiceDirectoryItem

```php
array{'kid'?: string|null, 'identity'?: string|null, 'name'?: string|null, 'iconName'?: string|null, 'iconKid'?: string|null}
```

### ServiceDirectoryResponse

```php
array{'items'?: list<ServiceDirectoryItem>|null, 'nextCursor'?: string|null}
```

### ServiceProfileRequest

```php
array{'value': string|null, 'expectedRevision': string|null}
```

### SetObjectCoordinateProvenanceRequest

```php
array{'value': int, 'expectedRevision': string|null}
```

### SetObjectCoordinatesRequest

```php
array{'latitude': int, 'longitude': int, 'expectedRevision': string|null}
```

### SettlementDetailResponse

```php
array{'kid'?: string|null, 'period'?: int, 'sourceEntries'?: int, 'includedEntries'?: int, 'groups'?: list<SettlementGroupResponse>|null, 'formats'?: list<string>|null}
```

### SettlementGroupResponse

```php
array{'group'?: string|null, 'currency'?: string|null, 'entries'?: int, 'amountMinor'?: int}
```

### SettlementHistoryResponse

```php
array{'kid'?: string|null, 'nextSettlement'?: string|null, 'periods'?: list<SettlementPeriodResponse>|null, 'nextBeforePeriod'?: int|null}
```

### SettlementPeriodResponse

```php
array{'period'?: int, 'settlementDate'?: string|null, 'settlementRun'?: string|null, 'firstTransaction'?: string|null, 'lastTransaction'?: string|null, 'amountMinor'?: int|null, 'transactionCount'?: int|null}
```

### StartWallboardPairing

```php
array{'displayId'?: string|null, 'publicKey'?: string|null}
```

### TenantStatusItem

```php
array{'kind'?: string|null, 'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'computerName'?: string|null, 'bankType'?: string|null, 'unitType'?: int|null, 'errorId'?: int|null, 'timestampUtc'?: string, 'iconKid'?: string|null, 'bankIconKid'?: string|null, 'locationIconKid'?: string|null}
```

### TenantStatusPageResponse

```php
array{'status'?: TenantStatusResponse, 'offset'?: int, 'totalCount'?: int, 'previousCursor'?: string|null, 'nextCursor'?: string|null}
```

### TenantStatusResponse

```php
array{'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int, 'sources'?: list<TenantStatusSourceResult>|null, 'items'?: list<TenantStatusItem>|null}
```

### TenantStatusSourceResult

```php
array{'kind'?: string|null, 'count'?: int, 'hasMore'?: bool, 'errorCode'?: string|null}
```

### ToolKidField

```php
array{'name'?: string|null, 'value'?: string|null, 'enumName'?: string|null, 'enumNumber'?: string|null, 'index'?: int|null}
```

### ToolKidInspectionRequest

```php
array{'kid'?: string|null}
```

### ToolKidInspectionResponse

```php
array{'canonicalKid'?: string|null, 'fields'?: list<ToolKidField>|null, 'normalized'?: bool}
```

### ToolTimeOffsetChoice

```php
array{'offset'?: string|null, 'utc'?: string|null}
```

### ToolTimeRequest

```php
array{'format'?: string|null, 'value'?: string|null, 'timeZone'?: string|null, 'offset'?: string|null}
```

### ToolTimeResponse

```php
array{'success'?: bool, 'error'?: string|null, 'result'?: ToolTimeResult, 'offsetChoices'?: list<ToolTimeOffsetChoice>|null}
```

### ToolTimeResult

```php
array{'ms2000'?: string|null, 'mi2000'?: string|null, 'ss2000'?: string|null, 'utc'?: string|null, 'local'?: string|null, 'timeZone'?: string|null, 'offset'?: string|null, 'dateInputRounded'?: bool, 'millisecondRemainder'?: string|null, 'secondRemainder'?: string|null}
```

### UnitDetailsResponse

```php
array{'location'?: BankLocationResponse, 'unit'?: UnitOverviewResponse, 'descriptorAvailable'?: bool, 'settingGroups'?: list<string>|null, 'stateGroups'?: list<string>|null}
```

### UnitDirectoryItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'bankName'?: string|null, 'bankIconKid'?: string|null, 'locationName'?: string|null, 'locationIconKid'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'unitType'?: string|null, 'washDocId'?: string|null, 'outOfOrder'?: string|null, 'latitude'?: int|float|null, 'longitude'?: int|float|null, 'errorUnit'?: string|null, 'autoOutOfOrder'?: string|null, 'versionMinor'?: string|null, 'bootReason'?: string|null, 'booted'?: string|null, 'firmware'?: string|null, 'storageCardSerialNumber'?: string|null, 'page'?: string|null, 'backLight'?: string|null, 'terminal'?: UnitTerminalResponse, 'progress'?: UnitProgressResponse}
```

### UnitDirectoryResponse

```php
array{'items'?: list<UnitDirectoryItem>|null, 'nextCursor'?: string|null, 'hasAllBanksAccess'?: bool, 'fields'?: list<string>|null}
```

### UnitDocumentCount

```php
array{'count'?: int, 'from'?: string, 'through'?: string}
```

### UnitDocumentPage

```php
array{'items'?: list<BankDocumentItem>|null, 'from'?: string, 'through'?: string, 'sort'?: string|null, 'direction'?: string|null, 'offset'?: int, 'limit'?: int, 'hasMore'?: bool}
```

### UnitErrorItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'unitKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int|null, 'timestampUtc'?: string, 'severity'?: string|null, 'level'?: string|null, 'code'?: int|null, 'count'?: int|null, 'description'?: string|null, 'payloadFormat'?: string|null, 'acknowledged'?: bool, 'revision'?: string|null, 'canAcknowledge'?: bool}
```

### UnitErrorPage

```php
array{'items'?: list<UnitErrorItem>|null, 'nextCursor'?: string|null, 'fromUtc'?: string, 'untilUtc'?: string}
```

### UnitGroupFieldResponse

```php
array{'name'?: string|null, 'valueType'?: string|null, 'scope'?: string|null, 'valueStatus'?: string|null, 'value'?: string|null, 'ms2000'?: int|null, 'canEdit'?: bool, 'revision'?: string|null, 'required'?: bool, 'minimum'?: int|null, 'maximum'?: int|null, 'options'?: list<UnitSettingOption>|null, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse, 'canReadHistory'?: bool, 'hasHistory'?: bool, 'valueFormat'?: string|null, 'pattern'?: string|null}
```

### UnitGroupResponse

```php
array{'location'?: BankLocationResponse, 'unit'?: UnitOverviewResponse, 'kind'?: string|null, 'group'?: string|null, 'items'?: list<UnitGroupFieldResponse>|null}
```

### UnitIconResponse

```php
array{'kid'?: string|null, 'iconKid'?: string|null, 'offline'?: bool|null, 'status'?: int}
```

### UnitIconsResponse

```php
array{'items'?: list<UnitIconResponse>|null}
```

### UnitOverviewResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'cycle'?: string|null, 'cycleText'?: string|null, 'unitType'?: int|null, 'unitTypeName'?: string|null, 'unitTypeSource'?: string|null, 'iconKid'?: string|null, 'progress'?: UnitProgressResponse, 'terminal'?: UnitTerminalResponse}
```

### UnitProgressResponse

```php
array{'status'?: string|null, 'percent'?: int|null, 'remainingSeconds'?: int|null, 'calculatedAtUtc'?: string}
```

### UnitSettingEditorResponse

```php
array{'kid'?: string|null, 'kind'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
```

### UnitSettingHistoryItem

```php
array{'value'?: string|null, 'ms2000'?: int, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse}
```

### UnitSettingHistoryResponse

```php
array{'unitKid'?: string|null, 'group'?: string|null, 'setting'?: string|null, 'items'?: list<UnitSettingHistoryItem>|null, 'nextBeforeMs2000'?: int|null, 'valueFormat'?: string|null}
```

### UnitSettingOption

```php
array{'value'?: string|null, 'label'?: string|null}
```

### UnitSettingRequest

```php
array{'value': string|null, 'expectedRevision': string|null}
```

### UnitSettingResponse

```php
array{'unitKid'?: string|null, 'group'?: string|null, 'setting'?: string|null, 'value'?: string|null, 'ms2000'?: int, 'revision'?: string|null, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse}
```

### UnitTerminalResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
```

### UnitTimelineField

```php
array{'kind'?: string|null, 'id'?: int, 'name'?: string|null}
```

### UnitTimelineFields

```php
array{'unitKid'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'unitName'?: string|null, 'unitType'?: int|null, 'sources'?: list<string>|null, 'fields'?: list<UnitTimelineField>|null, 'canReadTextDiagnostics'?: bool, 'canReadDocuments'?: bool}
```

### UnitTimelineItem

```php
array{'eventKey'?: string|null, 'source'?: string|null, 'ms2000'?: string|null, 'timestampUtc'?: string, 'sync'?: int|null, 'field'?: string|null, 'amount'?: string|null, 'currency'?: string|null, 'text'?: string|null, 'contentStatus'?: string|null, 'period'?: int, 'userKid'?: string|null, 'documentKid'?: string|null, 'auxiliaryValue'?: string|null}
```

### UnitTimelinePage

```php
array{'context'?: UnitTimelineFields, 'fromUtc'?: string, 'untilUtc'?: string, 'items'?: list<UnitTimelineItem>|null, 'nextCursor'?: string|null}
```

### UpdateObjectAddressRequest

```php
array{'address': string|null, 'zip': string|null, 'expectedRevision': string|null}
```

### UserActivationResponse

```php
array{'kid'?: string|null, 'name'?: string|null, 'number'?: string|null, 'activationCode'?: string|null, 'qrCodeDataV1'?: string|null, 'qrCodeDataV2'?: string|null}
```

### UserAttributeInput

```php
array{'attribute'?: string|null, 'value'?: int}
```

### UserAttributeResponse

```php
array{'attribute'?: string|null, 'value'?: int}
```

### UserBalanceItem

```php
array{'kid'?: string|null, 'status'?: string|null, 'currentBalanceMinor'?: int|null, 'previousBalanceMinor'?: int|null, 'previousPeriod'?: int|null, 'previousPeriodIsProvisional'?: bool, 'latestPostingMs2000'?: int|null, 'hasActiveSubscription'?: bool|null, 'balances'?: list<UserCurrencyBalanceItem>|null}
```

### UserBalancesRequest

```php
array{'userKids': list<string>}
```

### UserBalancesResponse

```php
array{'items'?: list<UserBalanceItem>|null}
```

### UserCommandRequest

```php
array{'action'?: string|null, 'revision'?: string|null, 'name'?: string|null, 'number'?: string|null, 'deleteAtUtc'?: string|null, 'tagKid'?: string|null, 'state'?: string|null, 'locationKid'?: string|null, 'attributes'?: list<UserAttributeInput>|null, 'icon'?: string|null}
```

### UserCurrencyBalanceItem

```php
array{'currency'?: string|null, 'currentBalanceMinor'?: int, 'previousBalanceMinor'?: int|null, 'previousPeriod'?: int|null, 'previousPeriodIsProvisional'?: bool}
```

### UserDirectoryItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'name'?: string|null, 'number'?: string|null, 'iconKid'?: string|null, 'deletedAt'?: string|null}
```

### UserDirectoryResponse

```php
array{'items'?: list<UserDirectoryItem>|null, 'nextCursor'?: string|null, 'scanLimitReached'?: bool}
```

### UserEvaskeriSession

```php
array{'kid'?: string|null, 'url'?: string|null, 'expiresAtUtc'?: string}
```

### UserLocationResponse

```php
array{'kid'?: string|null, 'state'?: string|null, 'name'?: string|null, 'iconKid'?: string|null}
```

### UserNumberSuggestionResponse

```php
array{'bankKid'?: string|null, 'number'?: string|null}
```

### UserReceipt

```php
array{'key'?: string|null, 'date'?: string, 'locationKid'?: string|null, 'locationName'?: string|null, 'period'?: int, 'provisional'?: bool, 'kind'?: string|null, 'currency'?: string|null, 'totalMinor'?: int, 'vatMinor'?: int|null, 'balanceAfterMinor'?: int, 'lines'?: list<UserReceiptLine>|null}
```

### UserReceiptLine

```php
array{'kid'?: string|null, 'occurredAt'?: string, 'unitKid'?: string|null, 'unitName'?: string|null, 'texts'?: list<string>|null, 'amountMinor'?: int, 'calculated'?: bool}
```

### UserReceiptsResponse

```php
array{'userKid'?: string|null, 'revision'?: string|null, 'items'?: list<UserReceipt>|null, 'nextOffset'?: int|null, 'periodCount'?: int}
```

### UserScopeState

```php
array{'kid'?: string|null, 'state'?: string|null}
```

### UserTagResponse

```php
array{'kid'?: string|null, 'state'?: string|null}
```

### UserWorkspaceResponse

```php
array{'kid'?: string|null, 'revision'?: string|null, 'name'?: string|null, 'number'?: string|null, 'deletedAtUtc'?: string|null, 'deleteAtUtc'?: string|null, 'locations'?: list<UserScopeState>|null, 'tags'?: list<UserScopeState>|null, 'attributes'?: list<UserAttributeInput>|null, 'canWrite'?: bool, 'canCreate'?: bool, 'synchronization'?: string|null, 'canDelete'?: bool, 'canRenameExternalId'?: bool, 'canRename'?: bool, 'iconKid'?: string|null, 'availableIcons'?: list<string>|null, 'canEditIcon'?: bool}
```

### ValidationProblemDetails

```php
array{'type'?: string|null, 'title'?: string|null, 'status'?: int|null, 'detail'?: string|null, 'instance'?: string|null, 'errors'?: array<string,mixed>|null}
```

### Wallboard

```php
array{'i'?: string|null, 'n'?: string|null, 'p'?: int, 'c'?: list<eColor>|null, 's'?: list<WallboardPage>|null}
```

### WallboardDeviceChallenge

```php
array{'challenge'?: string|null, 'message'?: string|null, 'expiresIn'?: int}
```

### WallboardDeviceInfo

```php
array{'deviceId'?: string|null, 'displayId'?: string|null, 'createdAt'?: string, 'location'?: WallboardScanLocation}
```

### WallboardDisplayResponse

```php
array{'layout'?: Wallboard, 'revision'?: string|null}
```

### WallboardPage

```php
array{'n'?: string|null, 'd'?: int, 's'?: list<WallboardWidget>|null}
```

### WallboardPairingInfo

```php
array{'pairingId'?: string|null, 'displayId'?: string|null, 'expiresAt'?: string, 'approved'?: bool}
```

### WallboardPairingStarted

```php
array{'pairingId'?: string|null, 'deviceCode'?: string|null, 'displayId'?: string|null, 'expiresAt'?: string, 'intervalSeconds'?: int}
```

### WallboardPairingToken

```php
array{'status'?: string|null, 'accessToken'?: string|null, 'expiresIn'?: int|null, 'displayId'?: string|null}
```

### WallboardScanLocation

```php
array{'latitude'?: int|float, 'longitude'?: int|float, 'accuracyMeters'?: int|float, 'capturedAt'?: string}
```

### WallboardWidget

```php
array{'t'?: eWidgetType, 'k'?: string|null, 'x'?: int, 'y'?: int, 'w'?: int, 'h'?: int}
```

### WashDocChartDosing

```php
array{'ms2000'?: int, 'name'?: string|null, 'durationMs'?: int|null, 'volumeMl'?: int|float|null, 'massGrams'?: int|float|null, 'process'?: string|null, 'step'?: string|null}
```

### WashDocChartEvent

```php
array{'ms2000'?: int, 'kind'?: string|null, 'name'?: string|null, 'value'?: int|float|null, 'label'?: string|null, 'localization'?: string|null, 'isCalculated'?: bool}
```

### WashDocChartPoint

```php
array{'ms2000'?: int, 'value'?: int|float|null, 'isCalculated'?: bool, 'isEdge'?: bool, 'unit'?: string|null}
```

### WashDocChartResponse

```php
array{'cycleKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'finished'?: bool, 'fromMs2000'?: int, 'toMs2000'?: int, 'startedMs2000'?: int|null, 'endedMs2000'?: int|null, 'series'?: list<WashDocChartSeries>|null, 'events'?: list<WashDocChartEvent>|null, 'signals'?: list<WashDocChartSignal>|null, 'dosing'?: list<WashDocChartDosing>|null, 'presentation'?: WashDocPresentation}
```

### WashDocChartSeries

```php
array{'kind'?: string|null, 'name'?: string|null, 'label'?: string|null, 'localization'?: string|null, 'group'?: string|null, 'role'?: string|null, 'unit'?: string|null, 'step'?: bool, 'points'?: list<WashDocChartPoint>|null}
```

### WashDocChartSignal

```php
array{'ms2000'?: int, 'flags'?: int|null, 'heat'?: bool|null, 'inlet'?: bool|null, 'outlet'?: bool|null, 'isCalculated'?: bool, 'airflow'?: bool|null}
```

### WashDocPresentation

```php
array{'unitType'?: int|null, 'kind'?: string|null, 'groupOrder'?: list<string>|null}
```

### eColor

```php
int
```

### eThemeMode

```php
int
```

### eWidgetType

```php
int
```

### ActiveUsersResponse

```php
array{'tenantKid'?: string|null, 'count'?: int, 'lookbackDays'?: int, 'sinceUtc'?: string, 'measuredAtUtc'?: string}
```

### ApiStatusResponse

```php
array{'service'?: string|null, 'status'?: string|null, 'apiVersion'?: string|null}
```

### CycleChartPresentationResponse

```php
array{'language'?: string|null, 'messages'?: array<string,mixed>|null, 'stateNames'?: array<string,mixed>|null}
```

### IconPresentationResponse

```php
array{'iconKid'?: string|null}
```

### LiveMachineResponse

```php
array{'unitKid'?: string|null, 'unitName'?: string|null, 'locationName'?: string|null, 'startedAtUtc'?: string, 'doneAtUtc'?: string|null, 'temperature'?: int|float|null}
```

### PublicCameraPhoto

```php
array{'thumbnailUrl'?: string|null, 'workspacePath'?: string|null}
```

### PublicCycleWidgetResponse

```php
array{'cycleKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'locationName'?: string|null, 'startedAtUtc'?: string, 'endedAtUtc'?: string|null, 'finished'?: bool, 'graphSvg'?: string|null, 'refreshAfterSeconds'?: int, 'cycleKidText'?: string|null}
```

### PublicMachineError

```php
array{'kid'?: string|null, 'name'?: string|null, 'bankName'?: string|null, 'locationName'?: string|null, 'errorId'?: string|null}
```

### PublicMachineErrorsPage

```php
array{'items'?: list<PublicMachineError>|null, 'nextCursor'?: string|null, 'refreshAfterSeconds'?: int}
```

### PublicScopedProgressItem

```php
array{'unitKid'?: string|null, 'unitName'?: string|null, 'locationName'?: string|null, 'startedAtUtc'?: string|null, 'doneAtUtc'?: string|null, 'progress'?: UnitProgressResponse}
```

### PublicScopedProgressResponse

```php
array{'scopeKid'?: string|null, 'scopeKind'?: string|null, 'calculatedAtUtc'?: string, 'refreshAfterSeconds'?: int, 'items'?: list<PublicScopedProgressItem>|null, 'nextCursor'?: string|null}
```

### PublicWidgetPresentationResponse

```php
array{'language'?: string|null, 'colors'?: string|null, 'background'?: string|null, 'webBase'?: string|null, 'labels'?: array<string,mixed>|null, 'googleMapsBrowserKey'?: string|null, 'brandIconUrl'?: string|null, 'brandLightTokens'?: array<string,mixed>|null, 'brandDarkTokens'?: array<string,mixed>|null}
```

### PurchaseCurrencySnapshot

```php
array{'currency'?: string|null, 'count'?: int, 'amount'?: int|float}
```

### PurchaseHeatmapPoint

```php
array{'latitude'?: int|float, 'longitude'?: int|float, 'amount'?: int|float}
```

### PurchaseMapPoint

```php
array{'kid'?: string|null, 'latitude'?: int|float, 'longitude'?: int|float, 'timestampUtc'?: string, 'amount'?: int|float}
```

### PurchaseMapSnapshot

```php
array{'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int, 'items'?: list<PurchaseMapPoint>|null, 'heatmap'?: list<PurchaseHeatmapPoint>|null}
```

### PurchasesResponse

```php
array{'tenantKid'?: string|null, 'count'?: int, 'lookbackHours'?: int, 'sinceUtc'?: string, 'measuredAtUtc'?: string, 'currencies'?: list<PurchaseCurrencySnapshot>|null}
```

### ReservationsStatisticsResponse

```php
array{'tenantKid'?: string|null, 'count'?: int, 'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int}
```

### RunningMachinesResponse

```php
array{'tenantKid'?: string|null, 'count'?: int, 'measuredAtUtc'?: string, 'refreshAfterSeconds'?: int}
```
