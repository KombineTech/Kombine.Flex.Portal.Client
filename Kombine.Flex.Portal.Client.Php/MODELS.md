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

### DatabaseAccessResponse

```php
array{'canWrite'?: bool|null, 'checkedAtUtc'?: string}
```

### DocumentCell

```php
array{'value'?: int|float|null, 'text'?: string|null, 'isCalculated'?: bool}
```

### DocumentColumn

```php
array{'kind'?: string|null, 'name'?: string|null, 'localization'?: string|null, 'color'?: string|null, 'onlyNumericValues'?: bool, 'iconKid'?: string|null}
```

### DocumentTable

```php
array{'documentKid'?: string|null, 'unitKid'?: string|null, 'unitName'?: string|null, 'finished'?: bool, 'fromMs2000'?: int, 'toMs2000'?: int, 'columns'?: list<DocumentColumn>|null, 'rows'?: list<DocumentTableRow>|null}
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

### LocationDirectoryItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'bankName'?: string|null, 'name'?: string|null, 'vismaCustNo'?: string|null, 'bankActivationCode'?: string|null, 'locationActivationCode'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'address'?: string|null, 'zip'?: string|null, 'longitude'?: int|float|null, 'latitude'?: int|float|null, 'teltonikaSms'?: string|null, 'alternativeBankName'?: string|null, 'mask'?: string|null, 'timeZone'?: string|null, 'online'?: bool|null, 'lastContactAt'?: string|null, 'vismaCrAcNo'?: string|null, 'vismaInvoiceVersion'?: string|null, 'vismaOrdre'?: string|null, 'vismaPNTurnover'?: string|null, 'vismaPNSettlement'?: string|null, 'vismaSettlement'?: string|null, 'vismaVAT'?: string|null, 'vismaServiceKey'?: string|null, 'vismaStart'?: string|null, 'vismaNote'?: string|null, 'hiddenNote'?: string|null, 'vismaGuaranteeMonth'?: string|null, 'vismaGuaranteeUnder'?: string|null, 'vismaGuarantee'?: string|null, 'vismaGuaranteeCustomer'?: string|null, 'vismaGuaranteeOver'?: string|null, 'gift'?: string|null, 'giftBegin'?: string|null, 'giftEnd'?: string|null, 'giftSplit'?: string|null, 'giftPN'?: string|null, 'iconKid'?: string|null, 'bankIconKid'?: string|null}
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

### LocationUnitsResponse

```php
array{'location'?: BankLocationResponse, 'items'?: list<UnitOverviewResponse>|null}
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
array{'email': string, 'password': string}
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
array{'kid'?: string|null, 'name'?: string|null, 'tabs'?: list<int>|null, 'hasBankAccess'?: bool, 'iconKid'?: string|null, 'databaseAccess'?: DatabaseAccessResponse, 'navigationBanks'?: list<BankNavigationResponse>|null, 'organisation'?: string|null, 'gravatarUrl'?: string|null, 'retentionDays'?: int, 'themeMode'?: eThemeMode, 'iconSet'?: string|null, 'tabDetails'?: list<ManagerTabResponse>|null, 'resourceGrants'?: list<ManagerResourceGrantResponse>|null, 'operationPermissions'?: list<ManagerOperationPermissionResponse>|null}
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

### PeopleDirectoryCount

```php
array{'count'?: int, 'iconKid'?: string|null}
```

### PersonalAccountResult

```php
array{'code'?: string|null}
```

### PersonalEmailConfirmation

```php
array{'token': string|null}
```

### PersonalEmailRequest

```php
array{'email': string|null, 'currentPassword': string|null, 'language'?: string|null}
```

### PersonalManagerProfile

```php
array{'kid'?: string|null, 'name'?: string|null, 'organisation'?: string|null, 'iconKid'?: string|null, 'email'?: string|null, 'emailVerified'?: bool, 'themeMode'?: eThemeMode, 'revision'?: string|null, 'availableIcons'?: list<string>|null, 'retentionDays'?: int, 'iconSet'?: string|null}
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

### ProblemDetails

```php
array{'type'?: string|null, 'title'?: string|null, 'status'?: int|null, 'detail'?: string|null, 'instance'?: string|null}
```

### SearchResult

```php
array{'kid'?: string|null, 'kind'?: string|null, 'name'?: string|null, 'zip'?: string|null, 'matchedSetting'?: string|null, 'matchedValue'?: string|null, 'isContext'?: bool, 'number'?: string|null, 'iconKid'?: string|null}
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

### UnitDetailsResponse

```php
array{'location'?: BankLocationResponse, 'unit'?: UnitOverviewResponse, 'descriptorAvailable'?: bool, 'settingGroups'?: list<string>|null, 'stateGroups'?: list<string>|null}
```

### UnitDirectoryItem

```php
array{'kid'?: string|null, 'bankKid'?: string|null, 'locationKid'?: string|null, 'name'?: string|null, 'iconKid'?: string|null, 'bankName'?: string|null, 'bankIconKid'?: string|null, 'locationName'?: string|null, 'locationIconKid'?: string|null, 'enabled'?: bool, 'deleted'?: bool|null, 'deletedAt'?: string|null, 'unitType'?: string|null, 'washDocId'?: string|null, 'outOfOrder'?: string|null, 'latitude'?: int|float|null, 'longitude'?: int|float|null, 'versionMinor'?: string|null, 'bootReason'?: string|null, 'booted'?: string|null, 'firmware'?: string|null, 'storageCardSerialNumber'?: string|null, 'page'?: string|null, 'backLight'?: string|null, 'terminal'?: UnitTerminalResponse}
```

### UnitDirectoryResponse

```php
array{'items'?: list<UnitDirectoryItem>|null, 'nextCursor'?: string|null, 'hasAllBanksAccess'?: bool, 'fields'?: list<string>|null}
```

### UnitGroupFieldResponse

```php
array{'name'?: string|null, 'valueType'?: string|null, 'scope'?: string|null, 'valueStatus'?: string|null, 'value'?: string|null, 'ms2000'?: int|null, 'canEdit'?: bool, 'revision'?: string|null, 'required'?: bool, 'minimum'?: int|null, 'maximum'?: int|null, 'options'?: list<UnitSettingOption>|null, 'sync'?: int|null, 'changedBy'?: UnitSettingEditorResponse, 'canReadHistory'?: bool, 'hasHistory'?: bool}
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
array{'unitKid'?: string|null, 'group'?: string|null, 'setting'?: string|null, 'items'?: list<UnitSettingHistoryItem>|null, 'nextBeforeMs2000'?: int|null}
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

### eThemeMode

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

### IconPresentationResponse

```php
array{'iconKid'?: string|null}
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
array{'tenantKid'?: string|null, 'count'?: int, 'lookbackHours'?: int, 'sinceUtc'?: string, 'measuredAtUtc'?: string, 'amount'?: int|float, 'currency'?: string|null}
```
