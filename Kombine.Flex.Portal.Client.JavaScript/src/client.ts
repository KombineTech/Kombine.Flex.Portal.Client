// Generated operations; regenerate with scripts/Generate-PortalScriptClients.py.
import { BaseClient, PortalDownload, type RequestOptions } from "./runtime.js";
import type * as Models from "./models.js";

export class PortalClient extends BaseClient {
  /** Lists Account2 postings with full-selection totals per currency. */
  getBankAccount(bankKid: string, options: Models.GetBankAccountOptions = {}, request: RequestOptions = {}): Promise<Models.AccountResponse> {
    return this.send("GetBankAccount", {"bankKid": bankKid, "From": options.from, "Through": options.through, "TimeZone": options.timeZone, "Period": options.period, "LocationKid": options.locationKid, "UnitKid": options.unitKid, "UserKid": options.userKid, "Kind": options.kind, "IncludeZero": options.includeZero, "IncludeBookings": options.includeBookings, "IncludeMonthly": options.includeMonthly, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.AccountResponse>;
  }

  /** Checks whether filtered Account2 postings changed, including late arrivals with old event timestamps. */
  getBankAccountRevision(bankKid: string, options: Models.GetBankAccountRevisionOptions = {}, request: RequestOptions = {}): Promise<Models.AccountRevisionResponse> {
    return this.send("GetBankAccountRevision", {"bankKid": bankKid, "From": options.from, "Through": options.through, "TimeZone": options.timeZone, "Period": options.period, "LocationKid": options.locationKid, "UnitKid": options.unitKid, "UserKid": options.userKid, "Kind": options.kind, "IncludeZero": options.includeZero, "IncludeBookings": options.includeBookings, "IncludeMonthly": options.includeMonthly, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.AccountRevisionResponse>;
  }

  /** Reverses one eligible resident consumption posting by appending a linked compensation. */
  reverseBankAccountEntry(bankKid: string, transactionKid: string, request: RequestOptions = {}): Promise<Models.AccountEntryResponse> {
    return this.send("ReverseBankAccountEntry", {"bankKid": bankKid, "transactionKid": transactionKid}, undefined, request) as Promise<Models.AccountEntryResponse>;
  }

  /** Read the object's own address, coordinate pair, provenance and concurrency revision. */
  getObjectAddress(kid: string, request: RequestOptions = {}): Promise<Models.ObjectAddressResponse> {
    return this.send("GetObjectAddress", {"kid": kid}, undefined, request) as Promise<Models.ObjectAddressResponse>;
  }

  /** Save Address and Zip together and resolve automatic coordinates once if either field changes. */
  updateObjectAddress(kid: string, body: Models.UpdateObjectAddressRequest, request: RequestOptions = {}): Promise<Models.ObjectAddressResponse> {
    return this.send("UpdateObjectAddress", {"kid": kid}, body, request) as Promise<Models.ObjectAddressResponse>;
  }

  /** Explicitly look up the current address, replacing manual coordinates only on success. */
  lookupObjectCoordinates(kid: string, body: Models.ObjectAddressRevisionRequest, request: RequestOptions = {}): Promise<Models.ObjectAddressResponse> {
    return this.send("LookupObjectCoordinates", {"kid": kid}, body, request) as Promise<Models.ObjectAddressResponse>;
  }

  /** Save manual Latitude and Longitude atomically with AutoLatitudeLongitude=30. */
  setObjectCoordinates(kid: string, body: Models.SetObjectCoordinatesRequest, request: RequestOptions = {}): Promise<Models.ObjectAddressResponse> {
    return this.send("SetObjectCoordinates", {"kid": kid}, body, request) as Promise<Models.ObjectAddressResponse>;
  }

  /** Change AutoLatitudeLongitude without changing the coordinate pair or making a Google request. */
  setObjectCoordinateProvenance(kid: string, body: Models.SetObjectCoordinateProvenanceRequest, request: RequestOptions = {}): Promise<Models.ObjectAddressResponse> {
    return this.send("SetObjectCoordinateProvenance", {"kid": kid}, body, request) as Promise<Models.ObjectAddressResponse>;
  }

  /** Ask the portal assistant to discover and combine approved read operations. */
  askPortalAssistant(body: Models.AssistantRequest, request: RequestOptions = {}): Promise<Models.AssistantResponse> {
    return this.send("AskPortalAssistant", {}, body, request) as Promise<Models.AssistantResponse>;
  }

  /** Search WashDoc document identities by location, unit and time without loading measurements. */
  getBankDocuments(bankKid: string, options: Models.GetBankDocumentsOptions = {}, request: RequestOptions = {}): Promise<Models.BankDocumentPage> {
    return this.send("GetBankDocuments", {"bankKid": bankKid, "LocationKid": options.locationKid, "UnitKid": options.unitKid, "From": options.from, "Through": options.through, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.BankDocumentPage>;
  }

  /** Resolve up to eight bank icons with their authorized units' combined status. */
  getBankIcons(options: Models.GetBankIconsOptions = {}, request: RequestOptions = {}): Promise<Models.BankIconsResponse> {
    return this.send("GetBankIcons", {"kid": options.kid}, undefined, request) as Promise<Models.BankIconsResponse>;
  }

  /** List location names, icons, status and canonical KIDs in bank overview order (location number). */
  getBankLocations(bankKid: string, request: RequestOptions = {}): Promise<Models.BankLocationStatusResponse[]> {
    return this.send("GetBankLocations", {"bankKid": bankKid}, undefined, request) as Promise<Models.BankLocationStatusResponse[]>;
  }

  /** Search current bank names and settlement emails; literal case-insensitive substring matching. */
  searchBanks(options: Models.SearchBanksOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchBanks", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Decode a bank activation code and resolve its name and icon from the cached Log24 bank catalogue. */
  searchBankActivation(options: Models.SearchBankActivationOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchBankActivation", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Resolve a search result before opening its bank overview, including tenant-wide managers. */
  getSearchBank(bankKid: string, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("GetSearchBank", {"bankKid": bankKid}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Read one page of users for a bank. */
  getBankUsers(bankKid: string, options: Models.GetBankUsersOptions = {}, request: RequestOptions = {}): Promise<Models.BankUsersResponse> {
    return this.send("GetBankUsers", {"bankKid": bankKid, "pageSize": options.pageSize, "cursor": options.cursor, "sort": options.sort, "direction": options.direction, "filter": options.filter, "userKid": options.userKid, "locationKid": options.locationKid, "deleted": options.deleted}, undefined, request) as Promise<Models.BankUsersResponse>;
  }

  /** Create a resident. Requires bank-wide Users2/User Create. Action must be create. No hardware access is assigned automatically. */
  createBankUser(bankKid: string, body: Models.UserCommandRequest, request: RequestOptions = {}): Promise<Models.UserWorkspaceResponse> {
    return this.send("CreateBankUser", {"bankKid": bankKid}, body, request) as Promise<Models.UserWorkspaceResponse>;
  }

  /** Lists the latest nonsuperseded Log5 event for each location/unit/resident/start. */
  getBankBookings(bankKid: string, options: Models.GetBankBookingsOptions = {}, request: RequestOptions = {}): Promise<Models.BookingsResponse> {
    return this.send("GetBankBookings", {"bankKid": bankKid, "from": options.from, "through": options.through, "locationKid": options.locationKid, "unitKid": options.unitKid, "userKid": options.userKid, "status": options.status, "search": options.search, "offset": options.offset, "limit": options.limit}, undefined, request) as Promise<Models.BookingsResponse>;
  }

  /** Appends a cancellation or restoration, preserving history and requesting backend synchronization. */
  executeBankBookingCommand(bankKid: string, bookingKid: string, body: Models.BookingCommand, request: RequestOptions = {}): Promise<Models.BookingResponse> {
    return this.send("ExecuteBankBookingCommand", {"bankKid": bankKid, "bookingKid": bookingKid}, body, request) as Promise<Models.BookingResponse>;
  }

  /** Downloads the complete filtered selection as CSV or a genuine Excel workbook. */
  exportBankAccount(bankKid: string, options: Models.ExportBankAccountOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("ExportBankAccount", {"bankKid": bankKid, "From": options.from, "Through": options.through, "TimeZone": options.timeZone, "Period": options.period, "LocationKid": options.locationKid, "UnitKid": options.unitKid, "UserKid": options.userKid, "Kind": options.kind, "IncludeZero": options.includeZero, "IncludeBookings": options.includeBookings, "IncludeMonthly": options.includeMonthly, "Offset": options.offset, "Limit": options.limit, "format": options.format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text. */
  exportBankUsers(bankKid: string, options: Models.ExportBankUsersOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("ExportBankUsers", {"bankKid": bankKid, "filter": options.filter, "locationKid": options.locationKid, "deleted": options.deleted, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<PortalDownload>;
  }

  /** Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest. */
  downloadBankSettlement(bankKid: string, period: number, options: Models.DownloadBankSettlementOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadBankSettlement", {"bankKid": bankKid, "period": period, "format": options.format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Download a UTF-8 CSV table for one document. */
  downloadUnitDocumentCsv(documentKid: string, options: Models.DownloadUnitDocumentCsvOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadUnitDocumentCsv", {"documentKid": documentKid, "States": options.states, "Settings": options.settings}, undefined, request) as Promise<PortalDownload>;
  }

  /** Download an Excel 97–2003 binary .xls workbook for one document. */
  downloadUnitDocumentXls(documentKid: string, options: Models.DownloadUnitDocumentXlsOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadUnitDocumentXls", {"documentKid": documentKid, "States": options.states, "Settings": options.settings}, undefined, request) as Promise<PortalDownload>;
  }

  /** Read recent DigitalOcean runtime logs for a configured shared app. */
  getHostingLogs(options: Models.GetHostingLogsOptions = {}, request: RequestOptions = {}): Promise<Models.HostingLogsResponse> {
    return this.send("GetHostingLogs", {"environment": options.environment, "application": options.application}, undefined, request) as Promise<Models.HostingLogsResponse>;
  }

  /** Read hosting metrics for one configured application or Managed MySQL cluster. */
  getHostingMetrics(options: Models.GetHostingMetricsOptions = {}, request: RequestOptions = {}): Promise<Models.HostingMetricsResponse> {
    return this.send("GetHostingMetrics", {"environment": options.environment, "application": options.application, "hours": options.hours}, undefined, request) as Promise<Models.HostingMetricsResponse>;
  }

  /** Save an installer's selected Person icon. */
  setInstallerIcon(installerKid: string, body: Models.InstallerIconRequest, request: RequestOptions = {}): Promise<Models.InstallerIconResponse> {
    return this.send("SetInstallerIcon", {"installerKid": installerKid}, body, request) as Promise<Models.InstallerIconResponse>;
  }

  /** List installers with locations, tags, account state and last activity. */
  getInstallers(options: Models.GetInstallersOptions = {}, request: RequestOptions = {}): Promise<Models.InstallerDirectoryResponse> {
    return this.send("GetInstallers", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<Models.InstallerDirectoryResponse>;
  }

  /** Read one installer and the same Person icon catalog used for administrators. */
  getInstaller(installerKid: string, request: RequestOptions = {}): Promise<Models.InstallerDetailsResponse> {
    return this.send("GetInstaller", {"installerKid": installerKid}, undefined, request) as Promise<Models.InstallerDetailsResponse>;
  }

  /** Read recent live logs from Portal API, Equipment API and Portal Web. */
  getLiveLogs(request: RequestOptions = {}): Promise<Models.LiveLogsResponse> {
    return this.send("GetLiveLogs", {}, undefined, request) as Promise<Models.LiveLogsResponse>;
  }

  /** Count accessible active locations for the Banks2 navigation icon. */
  getActiveLocationCount(request: RequestOptions = {}): Promise<Models.ActiveLocationCountResponse> {
    return this.send("GetActiveLocationCount", {}, undefined, request) as Promise<Models.ActiveLocationCountResponse>;
  }

  /** List accessible locations with parent banks, Visma customer numbers and authorized activation codes. */
  getLocations(options: Models.GetLocationsOptions = {}, request: RequestOptions = {}): Promise<Models.LocationDirectoryResponse> {
    return this.send("GetLocations", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "includeCoordinates": options.includeCoordinates}, undefined, request) as Promise<Models.LocationDirectoryResponse>;
  }

  /** Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24. */
  searchLocations(options: Models.SearchLocationsOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchLocations", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Decode a location activation code and resolve its visible name and icon in Log24. */
  searchLocationActivation(options: Models.SearchLocationActivationOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchLocationActivation", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Read localized configured reservation rules for the location's visible units. */
  getLocationBookingRules(locationKid: string, options: Models.GetLocationBookingRulesOptions = {}, request: RequestOptions = {}): Promise<Models.LocationBookingRulesResponse> {
    return this.send("GetLocationBookingRules", {"locationKid": locationKid, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.LocationBookingRulesResponse>;
  }

  /** Get the location label and its units, ordered by unit number. */
  getLocationUnits(locationKid: string, options: Models.GetLocationUnitsOptions = {}, request: RequestOptions = {}): Promise<Models.LocationUnitsResponse> {
    return this.send("GetLocationUnits", {"locationKid": locationKid, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.LocationUnitsResponse>;
  }

  /** Read an authorized unit and its type's setting/state groups. */
  getUnitOverview(unitKid: string, options: Models.GetUnitOverviewOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDetailsResponse> {
    return this.send("GetUnitOverview", {"unitKid": unitKid, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.UnitDetailsResponse>;
  }

  /** Read the declared settings or states in one authorized unit group. */
  getUnitGroup(unitKid: string, kind: string, group: string, options: Models.GetUnitGroupOptions = {}, request: RequestOptions = {}): Promise<Models.UnitGroupResponse> {
    return this.send("GetUnitGroup", {"unitKid": unitKid, "kind": kind, "group": group, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.UnitGroupResponse>;
  }

  /** Read a bounded page of changes to one declared unit setting. */
  getUnitSettingHistory(unitKid: string, group: string, setting: string, options: Models.GetUnitSettingHistoryOptions = {}, request: RequestOptions = {}): Promise<Models.UnitSettingHistoryResponse> {
    return this.send("GetUnitSettingHistory", {"unitKid": unitKid, "group": group, "setting": setting, "beforeMs2000": options.beforeMs2000, "limit": options.limit}, undefined, request) as Promise<Models.UnitSettingHistoryResponse>;
  }

  /** Resolve up to 32 visible unit icons, adding the online/offline under-icon on demand. */
  getUnitIcons(options: Models.GetUnitIconsOptions = {}, request: RequestOptions = {}): Promise<Models.UnitIconsResponse> {
    return this.send("GetUnitIcons", {"kid": options.kid}, undefined, request) as Promise<Models.UnitIconsResponse>;
  }

  /** Resolve up to 32 visible location icons with their units' combined online/offline status. */
  getLocationIcons(options: Models.GetLocationIconsOptions = {}, request: RequestOptions = {}): Promise<Models.LocationIconsResponse> {
    return this.send("GetLocationIcons", {"kid": options.kid}, undefined, request) as Promise<Models.LocationIconsResponse>;
  }

  /** Read grouped opening hours, upcoming exceptions and the current opening status for a location. */
  getLocationOpeningHours(locationKid: string, options: Models.GetLocationOpeningHoursOptions = {}, request: RequestOptions = {}): Promise<Models.LocationOpeningHoursResponse> {
    return this.send("GetLocationOpeningHours", {"locationKid": locationKid, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.LocationOpeningHoursResponse>;
  }

  /** Create an empty enabled administrator with a previously unused manager identity. */
  createManager(request: RequestOptions = {}): Promise<Models.ManagerCreationResponse> {
    return this.send("CreateManager", {}, undefined, request) as Promise<Models.ManagerCreationResponse>;
  }

  /** List administrators in the site's eUserId.Managers through ManagersLast range. */
  getManagers(options: Models.GetManagersOptions = {}, request: RequestOptions = {}): Promise<Models.ManagerDirectoryResponse> {
    return this.send("GetManagers", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<Models.ManagerDirectoryResponse>;
  }

  /** Send an invitation allowing an existing manager to choose a password. */
  inviteManager(managerKid: string, body: Models.ManagerInvitationRequest, request: RequestOptions = {}): Promise<Models.ManagerInvitationResponse> {
    return this.send("InviteManager", {"managerKid": managerKid}, body, request) as Promise<Models.ManagerInvitationResponse>;
  }

  /** Add or remove a tenant, whole-bank or single-location grant on an administrator. */
  setManagerKid(managerKid: string, body: Models.ManagerKidChangeRequest, request: RequestOptions = {}): Promise<Models.ManagerKidChangeResponse> {
    return this.send("SetManagerKid", {"managerKid": managerKid}, body, request) as Promise<Models.ManagerKidChangeResponse>;
  }

  /** Request a manager password reset email. */
  requestManagerPasswordReset(body: Models.ManagerForgotPasswordRequest, request: RequestOptions = {}): Promise<Models.ManagerPasswordResetResponse> {
    return this.send("RequestManagerPasswordReset", {}, body, request) as Promise<Models.ManagerPasswordResetResponse>;
  }

  /** Replace a manager password using the emailed recovery token. */
  resetManagerPassword(body: Models.ManagerResetPasswordRequest, request: RequestOptions = {}): Promise<Models.ManagerPasswordResetResponse> {
    return this.send("ResetManagerPassword", {}, body, request) as Promise<Models.ManagerPasswordResetResponse>;
  }

  /** Replace all seven permission categories with a predefined administrator role. */
  setManagerPermissionRole(managerKid: string, body: Models.ManagerPermissionRoleRequest, request: RequestOptions = {}): Promise<Models.ManagerPermissionRoleResponse> {
    return this.send("SetManagerPermissionRole", {"managerKid": managerKid}, body, request) as Promise<Models.ManagerPermissionRoleResponse>;
  }

  /** Set one administrator permission checkbox, including your own if you are the sole active tenant-wide manager. */
  setManagerPermission(managerKid: string, resource: string, body: Models.ManagerPermissionChangeRequest, request: RequestOptions = {}): Promise<Models.ManagerOperationPermissionResponse> {
    return this.send("SetManagerPermission", {"managerKid": managerKid, "resource": resource}, body, request) as Promise<Models.ManagerOperationPermissionResponse>;
  }

  /** Change Name, Organisation, Enabled, Deleted, RetentionDays, Icon or Email on an administrator. */
  setManagerProfileField(managerKid: string, field: string, body: Models.ManagerProfileChangeRequest, request: RequestOptions = {}): Promise<Models.ManagerProfileChangeResponse> {
    return this.send("SetManagerProfileField", {"managerKid": managerKid, "field": field}, body, request) as Promise<Models.ManagerProfileChangeResponse>;
  }

  /** Read one administrator by canonical manager KID for a workspace shortcut. */
  getManager(managerKid: string, request: RequestOptions = {}): Promise<Models.ManagerDirectoryItem> {
    return this.send("GetManager", {"managerKid": managerKid}, undefined, request) as Promise<Models.ManagerDirectoryItem>;
  }

  /** List other visible administrators with the same stored email as this manager. */
  getManagersWithSameEmail(managerKid: string, request: RequestOptions = {}): Promise<Models.ManagerEmailMatch[]> {
    return this.send("GetManagersWithSameEmail", {"managerKid": managerKid}, undefined, request) as Promise<Models.ManagerEmailMatch[]>;
  }

  /** Log in with a manager email and password. */
  loginManager(body: Models.ManagerLoginRequest, options: Models.LoginManagerOptions = {}, request: RequestOptions = {}): Promise<Models.ManagerSessionResponse> {
    return this.send("LoginManager", {"X-Portal-Login-Client-IP": options.xPortalLoginClientIp}, body, request) as Promise<Models.ManagerSessionResponse>;
  }

  /** Renew an unexpired manager session for three days. */
  renewManagerSession(request: RequestOptions = {}): Promise<Models.ManagerSessionResponse> {
    return this.send("RenewManagerSession", {}, undefined, request) as Promise<Models.ManagerSessionResponse>;
  }

  /** Get your profile, permitted tabs, bank/location access, and operation permissions. */
  getCurrentManager(request: RequestOptions = {}): Promise<Models.ManagerProfileResponse> {
    return this.send("GetCurrentManager", {}, undefined, request) as Promise<Models.ManagerProfileResponse>;
  }

  /** Assign or remove one available eTab on an administrator. */
  setManagerTab(managerKid: string, tabId: number, body: Models.ManagerTabChangeRequest, request: RequestOptions = {}): Promise<Models.ManagerTabChangeResponse> {
    return this.send("SetManagerTab", {"managerKid": managerKid, "tabId": tabId}, body, request) as Promise<Models.ManagerTabChangeResponse>;
  }

  /** Save your own theme preference. */
  setCurrentManagerTheme(body: Models.ManagerThemeRequest, request: RequestOptions = {}): Promise<Models.ManagerThemeResponse> {
    return this.send("SetCurrentManagerTheme", {}, body, request) as Promise<Models.ManagerThemeResponse>;
  }

  /** Read your own personal settings and available person icons. */
  getMyManagerProfile(request: RequestOptions = {}): Promise<Models.PersonalManagerProfile> {
    return this.send("GetMyManagerProfile", {}, undefined, request) as Promise<Models.PersonalManagerProfile>;
  }

  /** Read your own tab selection, available tabs and editing eligibility. */
  getMyManagerTabs(request: RequestOptions = {}): Promise<Models.PersonalManagerTabs> {
    return this.send("GetMyManagerTabs", {}, undefined, request) as Promise<Models.PersonalManagerTabs>;
  }

  /** Select or deselect one of your own tabs when you have access to all banks. */
  setMyManagerTab(tabId: number, body: Models.PersonalTabRequest, request: RequestOptions = {}): Promise<Models.PersonalManagerTabs> {
    return this.send("SetMyManagerTab", {"tabId": tabId}, body, request) as Promise<Models.PersonalManagerTabs>;
  }

  /** Save one personal name, organisation, person icon, theme or deleted-record visibility preference. */
  setMyManagerProfileField(field: string, body: Models.PersonalProfileRequest, request: RequestOptions = {}): Promise<Models.PersonalManagerProfile> {
    return this.send("SetMyManagerProfileField", {"field": field}, body, request) as Promise<Models.PersonalManagerProfile>;
  }

  /** Send a verification link to your new email address. */
  requestMyManagerEmailVerification(body: Models.PersonalEmailRequest, request: RequestOptions = {}): Promise<Models.PersonalAccountResult> {
    return this.send("RequestMyManagerEmailVerification", {}, body, request) as Promise<Models.PersonalAccountResult>;
  }

  /** Confirm the new mailbox with its single-use verification token. */
  confirmMyManagerEmail(body: Models.PersonalEmailConfirmation, request: RequestOptions = {}): Promise<Models.PersonalAccountResult> {
    return this.send("ConfirmMyManagerEmail", {}, body, request) as Promise<Models.PersonalAccountResult>;
  }

  /** Change your password after reauthentication and repeated new-password entry. */
  changeMyManagerPassword(body: Models.PersonalPasswordRequest, request: RequestOptions = {}): Promise<Models.PersonalAccountResult> {
    return this.send("ChangeMyManagerPassword", {}, body, request) as Promise<Models.PersonalAccountResult>;
  }

  /** List concrete service enum identities, including services without saved settings. */
  getServices(options: Models.GetServicesOptions = {}, request: RequestOptions = {}): Promise<Models.ServiceDirectoryResponse> {
    return this.send("GetServices", {"filter": options.filter, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<Models.ServiceDirectoryResponse>;
  }

  /** Read one predefined service, editable metadata and its icon catalog. */
  getService(serviceKid: string, request: RequestOptions = {}): Promise<Models.ServiceDetailsResponse> {
    return this.send("GetService", {"serviceKid": serviceKid}, undefined, request) as Promise<Models.ServiceDetailsResponse>;
  }

  /** Save one service Name or Icon. */
  setServiceProfileField(serviceKid: string, field: string, body: Models.ServiceProfileRequest, request: RequestOptions = {}): Promise<Models.ServiceDetailsResponse> {
    return this.send("SetServiceProfileField", {"serviceKid": serviceKid, "field": field}, body, request) as Promise<Models.ServiceDetailsResponse>;
  }

  /** Generate a service API key beginning with kt_ and save its password-compatible hash. */
  generateServiceApiKey(serviceKid: string, body: Models.ServiceApiKeyRequest, request: RequestOptions = {}): Promise<Models.ServiceApiKeyResponse> {
    return this.send("GenerateServiceApiKey", {"serviceKid": serviceKid}, body, request) as Promise<Models.ServiceApiKeyResponse>;
  }

  /** Lists 25 closed settlement periods, newest first, and the next scheduled settlement. */
  getBankSettlements(bankKid: string, options: Models.GetBankSettlementsOptions = {}, request: RequestOptions = {}): Promise<Models.SettlementHistoryResponse> {
    return this.send("GetBankSettlements", {"bankKid": bankKid, "beforePeriod": options.beforePeriod}, undefined, request) as Promise<Models.SettlementHistoryResponse>;
  }

  /** Reads grouped totals for one period (zero is the provisional current period) and lists available export formats. */
  getBankSettlementPeriod(bankKid: string, period: number, request: RequestOptions = {}): Promise<Models.SettlementDetailResponse> {
    return this.send("GetBankSettlementPeriod", {"bankKid": bankKid, "period": period}, undefined, request) as Promise<Models.SettlementDetailResponse>;
  }

  /** List Offline and AutoOutOfOrder alerts, newest first, using parallel lookups. */
  getTenantStatus(options: Models.GetTenantStatusOptions = {}, request: RequestOptions = {}): Promise<Models.TenantStatusResponse> {
    return this.send("GetTenantStatus", {"limit": options.limit}, undefined, request) as Promise<Models.TenantStatusResponse>;
  }

  /** Read 25 status rows at a time with next/previous cursors. */
  getTenantStatusPage(options: Models.GetTenantStatusPageOptions = {}, request: RequestOptions = {}): Promise<Models.TenantStatusPageResponse> {
    return this.send("GetTenantStatusPage", {"pageSize": options.pageSize, "cursor": options.cursor, "offset": options.offset, "anchor": options.anchor}, undefined, request) as Promise<Models.TenantStatusPageResponse>;
  }

  /** Read a document's table as JSON with original values and column metadata. */
  getUnitDocumentTable(documentKid: string, options: Models.GetUnitDocumentTableOptions = {}, request: RequestOptions = {}): Promise<Models.DocumentTable> {
    return this.send("GetUnitDocumentTable", {"documentKid": documentKid, "States": options.states, "Settings": options.settings}, undefined, request) as Promise<Models.DocumentTable>;
  }

  /** View a document as a printable HTML table. */
  getUnitDocumentHtml(documentKid: string, options: Models.GetUnitDocumentHtmlOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentHtml", {"documentKid": documentKid, "States": options.states, "Settings": options.settings}, undefined, request) as Promise<PortalDownload>;
  }

  /** Render a document's numeric series as an SVG chart, caching completed documents privately. */
  getUnitDocumentSvg(documentKid: string, options: Models.GetUnitDocumentSvgOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentSvg", {"documentKid": documentKid, "States": options.states, "Settings": options.settings, "width": options.width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Save one editable current-unit setting with revision protection. */
  setUnitSetting(unitKid: string, group: string, setting: string, body: Models.UnitSettingRequest, request: RequestOptions = {}): Promise<Models.UnitSettingResponse> {
    return this.send("SetUnitSetting", {"unitKid": unitKid, "group": group, "setting": setting}, body, request) as Promise<Models.UnitSettingResponse>;
  }

  /** Read current and previous-period balances for up to 50 residents in one bank. */
  getBankUserBalances(bankKid: string, body: Models.UserBalancesRequest, request: RequestOptions = {}): Promise<Models.UserBalancesResponse> {
    return this.send("GetBankUserBalances", {"bankKid": bankKid}, body, request) as Promise<Models.UserBalancesResponse>;
  }

  /** Suggest the next resident number from the bank's first NumberFormats entry and stored NumberFormatUserIndex (default 1). */
  getBankUserNumberForNewUser(bankKid: string, request: RequestOptions = {}): Promise<Models.UserNumberSuggestionResponse> {
    return this.send("GetBankUserNumberForNewUser", {"bankKid": bankKid}, undefined, request) as Promise<Models.UserNumberSuggestionResponse>;
  }

  /** Suggest the next resident number after userNumber using the bank's first NumberFormats entry. */
  getBankNextUserNumber(bankKid: string, options: Models.GetBankNextUserNumberOptions = {}, request: RequestOptions = {}): Promise<Models.UserNumberSuggestionResponse> {
    return this.send("GetBankNextUserNumber", {"bankKid": bankKid, "userNumber": options.userNumber}, undefined, request) as Promise<Models.UserNumberSuggestionResponse>;
  }

  /** Read authoritative editing fields and an opaque concurrency revision. Bank-wide Users2/User Read required. */
  getBankUserWorkspace(bankKid: string, userKid: string, request: RequestOptions = {}): Promise<Models.UserWorkspaceResponse> {
    return this.send("GetBankUserWorkspace", {"bankKid": bankKid, "userKid": userKid}, undefined, request) as Promise<Models.UserWorkspaceResponse>;
  }

  /** Read the resident activation code for printing. Requires bank-wide Users2/User Create. */
  getBankUserActivation(bankKid: string, userKid: string, request: RequestOptions = {}): Promise<Models.UserActivationResponse> {
    return this.send("GetBankUserActivation", {"bankKid": bankKid, "userKid": userKid}, undefined, request) as Promise<Models.UserActivationResponse>;
  }

  /** Execute profile, icon, attributes, tag, location, delete, restore or replace with the revision from GetBankUserWorkspace. */
  executeBankUserCommand(bankKid: string, userKid: string, body: Models.UserCommandRequest, request: RequestOptions = {}): Promise<Models.UserWorkspaceResponse> {
    return this.send("ExecuteBankUserCommand", {"bankKid": bankKid, "userKid": userKid}, body, request) as Promise<Models.UserWorkspaceResponse>;
  }

  /** Read complete receipts for one resident, newest first, twenty receipts at a time. */
  getUserReceipts(userKid: string, options: Models.GetUserReceiptsOptions = {}, request: RequestOptions = {}): Promise<Models.UserReceiptsResponse> {
    return this.send("GetUserReceipts", {"userKid": userKid, "offset": options.offset, "revision": options.revision}, undefined, request) as Promise<Models.UserReceiptsResponse>;
  }

  /** Search resident Number, Name, Email, SMS and partial numeric TagId using current Log7. */
  searchUsers(options: Models.SearchUsersOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchUsers", {"q": options.q, "kidOnly": options.kidOnly}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Search complete resident SMS numbers with indexed exact Log7 Text matches. */
  searchUserSms(options: Models.SearchUserSmsOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchUserSms", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Decode an ordinary resident activation code and resolve name and icon from current Log7. */
  searchUserActivation(options: Models.SearchUserActivationOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchUserActivation", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Displays Windows downloads for this tenant, or an explicit unavailable state. */
  getPortalAppDownloadPage(request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetPortalAppDownloadPage", {}, undefined, request) as Promise<PortalDownload>;
  }

  /** Downloads a tenant-bound Windows App Installer file with update checks at launch. */
  downloadPortalWindowsAppInstaller(architecture: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadPortalWindowsAppInstaller", {"architecture": architecture}, undefined, request) as Promise<PortalDownload>;
  }

  /** Downloads an immutable signed Windows package, with byte-range and conditional request support. */
  downloadPortalWindowsPackage(architecture: string, fileName: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadPortalWindowsPackage", {"architecture": architecture, "fileName": fileName}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders an angular color-gradient background at 200 × 200 pixels. */
  getCircleGradient(colors: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCircleGradient", {"colors": colors}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders an angular gradient at a selected width and height. */
  getCircleGradientSized(colors: string, width: number, height: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCircleGradientSized", {"colors": colors, "width": width, "height": height}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a progress circle with one square mark per percentage point. */
  getCircleProgress(background: string, colors: string, percent: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCircleProgress", {"background": background, "colors": colors, "percent": percent}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a progress circle at a selected width and height. */
  getCircleProgressSized(background: string, colors: string, percent: number, width: number, height: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCircleProgressSized", {"background": background, "colors": colors, "percent": percent, "width": width, "height": height}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a rotating semicircle to indicate running or indeterminate progress. */
  getCircleRunning(color: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCircleRunning", {"color": color}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a running indicator at a selected width and height. */
  getCircleRunningSized(color: string, width: number, height: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCircleRunningSized", {"color": color, "width": width, "height": height}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a linear gradient at 200 × 200 pixels. */
  getLinearGradient(colors: string, angle: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetLinearGradient", {"colors": colors, "angle": angle}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a linear gradient at a selected width and height. */
  getLinearGradientSized(colors: string, angle: number, width: number, height: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetLinearGradientSized", {"colors": colors, "angle": angle, "width": width, "height": height}, undefined, request) as Promise<PortalDownload>;
  }

  /** Resolve an IconKid, optionally changing its text, count or RGB colour. */
  getIconPresentation(options: Models.GetIconPresentationOptions = {}, request: RequestOptions = {}): Promise<Models.IconPresentationResponse> {
    return this.send("GetIconPresentation", {"iconKid": options.iconKid, "text": options.text, "count": options.count, "color": options.color}, undefined, request) as Promise<Models.IconPresentationResponse>;
  }

  /** Lists canonical icon names with an asset in the requested local set. */
  getIconAssetCatalog(iconSet: string, request: RequestOptions = {}): Promise<(string)[]> {
    return this.send("GetIconAssetCatalog", {"iconSet": iconSet}, undefined, request) as Promise<(string)[]>;
  }

  /** Renders Kid.Icon from a named local asset set, with Kid.Count as the badge. */
  getIconFromSet(iconSet: string, kid: string, format: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetIconFromSet", {"iconSet": iconSet, "kid": kid, "format": format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders Kid.Icon and Kid.Count from a named set at a square pixel size. */
  getIconImageFromSet(iconSet: string, kid: string, size: number, format: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetIconImageFromSet", {"iconSet": iconSet, "kid": kid, "size": size, "format": format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders Kid.Icon and Kid.Count from a named set with a raster background. */
  getIconImageWithBackgroundFromSet(iconSet: string, kid: string, backColor: string, size: number, format: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetIconImageWithBackgroundFromSet", {"iconSet": iconSet, "kid": kid, "backColor": backColor, "size": size, "format": format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders a responsive Kombine symbol that fits its viewport without stretching. */
  getKombineLogo(color: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogo", {"color": color}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the square Kombine symbol at the selected width. */
  getKombineLogoSized(color: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoSized", {"color": color, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the Kombine symbol with an explicit background and width. */
  getKombineLogoWithBackground(color: string, background: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoWithBackground", {"color": color, "background": background, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the Kombine name and registered mark, without the symbol. */
  getKombineText(color: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineText", {"color": color}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the Kombine wordmark at the selected width. */
  getKombineTextSized(color: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineTextSized", {"color": color, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the Kombine wordmark with an explicit background and width. */
  getKombineTextWithBackground(color: string, background: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineTextWithBackground", {"color": color, "background": background, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the Kombine symbol and name together. */
  getKombineLogoText(color: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoText", {"color": color}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the combined Kombine logo at the selected width. */
  getKombineLogoTextSized(color: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoTextSized", {"color": color, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders the combined Kombine logo with an explicit background and width. */
  getKombineLogoTextWithBackground(color: string, background: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoTextWithBackground", {"color": color, "background": background, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Shows recent purchases as coin markers on a map. No login required. */
  getPublicDisp73(options: Models.GetPublicDisp73Options = {}, request: RequestOptions = {}): Promise<Models.PurchaseMapSnapshot> {
    return this.send("GetPublicDisp73", {"limit": options.limit}, undefined, request) as Promise<Models.PurchaseMapSnapshot>;
  }

  /** Counts purchases in the site's Log1Hour without login. */
  getPublicPurchases(request: RequestOptions = {}): Promise<Models.PurchasesResponse> {
    return this.send("GetPublicPurchases", {}, undefined, request) as Promise<Models.PurchasesResponse>;
  }

  /** Counts active users in the site's current Log7 during the last 100 days, without login. */
  getPublicActiveUsers(request: RequestOptions = {}): Promise<Models.ActiveUsersResponse> {
    return this.send("GetPublicActiveUsers", {}, undefined, request) as Promise<Models.ActiveUsersResponse>;
  }

  /** Gets public API availability. This does not check database readiness. */
  getPortalStatus(request: RequestOptions = {}): Promise<Models.ApiStatusResponse> {
    return this.send("GetPortalStatus", {}, undefined, request) as Promise<Models.ApiStatusResponse>;
  }

}
