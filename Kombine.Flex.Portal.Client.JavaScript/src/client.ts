// Generated operations; regenerate with scripts/Generate-PortalScriptClients.py.
import { BaseClient, PortalDownload, type RequestOptions } from "./runtime.js";
import type * as Models from "./models.js";

export class PortalClient extends BaseClient {
  /** Resolve the Forbrug icon text from the most frequent authorized Log1 currency. */
  getBankAccountIcon(bankKid: string, request: RequestOptions = {}): Promise<Models.AccountIconResponse> {
    return this.send("GetBankAccountIcon", {"bankKid": bankKid}, undefined, request) as Promise<Models.AccountIconResponse>;
  }

  /** Lists Account2 postings with full-selection totals per currency. */
  getBankAccount(bankKid: string, options: Models.GetBankAccountOptions = {}, request: RequestOptions = {}): Promise<Models.AccountResponse> {
    return this.send("GetBankAccount", {"bankKid": bankKid, "From": options.from, "Through": options.through, "TimeZone": options.timeZone, "Period": options.period, "LocationKid": options.locationKid, "LocationKids": options.locationKids, "UnitKid": options.unitKid, "UserKid": options.userKid, "Kind": options.kind, "IncludeZero": options.includeZero, "IncludeBookings": options.includeBookings, "IncludeMonthly": options.includeMonthly, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.AccountResponse>;
  }

  /** Checks whether filtered Account2 postings changed, including late arrivals with old event timestamps. */
  getBankAccountRevision(bankKid: string, options: Models.GetBankAccountRevisionOptions = {}, request: RequestOptions = {}): Promise<Models.AccountRevisionResponse> {
    return this.send("GetBankAccountRevision", {"bankKid": bankKid, "From": options.from, "Through": options.through, "TimeZone": options.timeZone, "Period": options.period, "LocationKid": options.locationKid, "LocationKids": options.locationKids, "UnitKid": options.unitKid, "UserKid": options.userKid, "Kind": options.kind, "IncludeZero": options.includeZero, "IncludeBookings": options.includeBookings, "IncludeMonthly": options.includeMonthly, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.AccountRevisionResponse>;
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

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getBankExportCount(options: Models.GetBankExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetBankExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "bankType": options.bankType}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** List authorized bank identities for Banks2 with selected metadata and stable global ordering. */
  getBanks(options: Models.GetBanksOptions = {}, request: RequestOptions = {}): Promise<Models.BankDirectoryResponse> {
    return this.send("GetBanks", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "bankType": options.bankType}, undefined, request) as Promise<Models.BankDirectoryResponse>;
  }

  /** Count accessible active banks for the Banks2 navigation icon. */
  getActiveBankCount(request: RequestOptions = {}): Promise<Models.ActiveBankCountResponse> {
    return this.send("GetActiveBankCount", {}, undefined, request) as Promise<Models.ActiveBankCountResponse>;
  }

  /** Search WashDoc document identities by location, unit and time without loading measurements. */
  getBankDocuments(bankKid: string, options: Models.GetBankDocumentsOptions = {}, request: RequestOptions = {}): Promise<Models.BankDocumentPage> {
    return this.send("GetBankDocuments", {"bankKid": bankKid, "LocationKid": options.locationKid, "LocationKids": options.locationKids, "Date": options.date, "Search": options.search, "UnitKids": options.unitKids, "Sort": options.sort, "Direction": options.direction, "UnitKid": options.unitKid, "From": options.from, "Through": options.through, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.BankDocumentPage>;
  }

  /** Count WashDocs across the authorized bank scope, without loading document pages or measurements. */
  getBankDocumentsCount(bankKid: string, options: Models.GetBankDocumentsCountOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDocumentCount> {
    return this.send("GetBankDocumentsCount", {"bankKid": bankKid, "LocationKid": options.locationKid, "LocationKids": options.locationKids, "Date": options.date, "Search": options.search, "UnitKids": options.unitKids, "Sort": options.sort, "Direction": options.direction, "UnitKid": options.unitKid, "From": options.from, "Through": options.through, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.UnitDocumentCount>;
  }

  /** List WashDocs for one authorized location, optionally selecting one or several units. */
  getLocationDocuments(locationKid: string, options: Models.GetLocationDocumentsOptions = {}, request: RequestOptions = {}): Promise<Models.BankDocumentPage> {
    return this.send("GetLocationDocuments", {"locationKid": locationKid, "Date": options.date, "Search": options.search, "UnitKids": options.unitKids, "Sort": options.sort, "Direction": options.direction, "UnitKid": options.unitKid, "From": options.from, "Through": options.through, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.BankDocumentPage>;
  }

  /** Count distinct WashDocs for the selected location and unit choices. */
  getLocationDocumentsCount(locationKid: string, options: Models.GetLocationDocumentsCountOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDocumentCount> {
    return this.send("GetLocationDocumentsCount", {"locationKid": locationKid, "Date": options.date, "Search": options.search, "UnitKids": options.unitKids, "Sort": options.sort, "Direction": options.direction, "UnitKid": options.unitKid, "From": options.from, "Through": options.through, "Offset": options.offset, "Limit": options.limit}, undefined, request) as Promise<Models.UnitDocumentCount>;
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

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getBankUserExportCount(bankKid: string, options: Models.GetBankUserExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetBankUserExportCount", {"bankKid": bankKid, "filter": options.filter, "sort": options.sort, "direction": options.direction, "locationKid": options.locationKid, "deleted": options.deleted, "locationKids": options.locationKids}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** Read one page of users for a bank. */
  getBankUsers(bankKid: string, options: Models.GetBankUsersOptions = {}, request: RequestOptions = {}): Promise<Models.BankUsersResponse> {
    return this.send("GetBankUsers", {"bankKid": bankKid, "pageSize": options.pageSize, "cursor": options.cursor, "sort": options.sort, "direction": options.direction, "filter": options.filter, "userKid": options.userKid, "locationKid": options.locationKid, "deleted": options.deleted, "locationKids": options.locationKids}, undefined, request) as Promise<Models.BankUsersResponse>;
  }

  /** Create a resident. Requires bank-wide Users2/User Create. Action must be create. No hardware access is assigned automatically. */
  createBankUser(bankKid: string, body: Models.UserCommandRequest, request: RequestOptions = {}): Promise<Models.UserWorkspaceResponse> {
    return this.send("CreateBankUser", {"bankKid": bankKid}, body, request) as Promise<Models.UserWorkspaceResponse>;
  }

  /** Lists the latest nonsuperseded Log5 event for each location/unit/resident/start. */
  getBankBookings(bankKid: string, options: Models.GetBankBookingsOptions = {}, request: RequestOptions = {}): Promise<Models.BookingsResponse> {
    return this.send("GetBankBookings", {"bankKid": bankKid, "from": options.from, "through": options.through, "locationKid": options.locationKid, "unitKid": options.unitKid, "userKid": options.userKid, "status": options.status, "search": options.search, "offset": options.offset, "limit": options.limit, "locationKids": options.locationKids}, undefined, request) as Promise<Models.BookingsResponse>;
  }

  /** Appends a cancellation or restoration, preserving history and requesting backend synchronization. */
  executeBankBookingCommand(bankKid: string, bookingKid: string, body: Models.BookingCommand, request: RequestOptions = {}): Promise<Models.BookingResponse> {
    return this.send("ExecuteBankBookingCommand", {"bankKid": bankKid, "bookingKid": bookingKid}, body, request) as Promise<Models.BookingResponse>;
  }

  /** Resolve the nearest writable location within 100 metres for tenant-level camera capture. */
  getCameraNearestLocation(options: Models.GetCameraNearestLocationOptions = {}, request: RequestOptions = {}): Promise<Models.CameraResourceResponse> {
    return this.send("GetCameraNearestLocation", {"latitude": options.latitude, "longitude": options.longitude, "accuracyMeters": options.accuracyMeters}, undefined, request) as Promise<Models.CameraResourceResponse>;
  }

  /** Read the display identity of one authorized camera resource. */
  getCameraResource(options: Models.GetCameraResourceOptions = {}, request: RequestOptions = {}): Promise<Models.CameraResourceResponse> {
    return this.send("GetCameraResource", {"resourceKid": options.resourceKid}, undefined, request) as Promise<Models.CameraResourceResponse>;
  }

  /** Check the lazy local camera tab and capture permission for one exact resource. */
  getCameraAvailability(options: Models.GetCameraAvailabilityOptions = {}, request: RequestOptions = {}): Promise<Models.CameraAvailabilityResponse> {
    return this.send("GetCameraAvailability", {"resourceKid": options.resourceKid}, undefined, request) as Promise<Models.CameraAvailabilityResponse>;
  }

  /** Prepare a bounded, immutable capture plan including optional weather. */
  prepareCameraCapture(body: Models.CameraPrepareRequest, request: RequestOptions = {}): Promise<Models.CameraPrepareResponse> {
    return this.send("PrepareCameraCapture", {}, body, request) as Promise<Models.CameraPrepareResponse>;
  }

  /** Save camera media synchronously, or accept bounded background processing. */
  saveCameraCapture(body: FormData, options: Models.SaveCameraCaptureOptions = {}, request: RequestOptions = {}): Promise<Models.CameraSaveResponse> {
    return this.send("SaveCameraCapture", {"background": options.background}, body, request) as Promise<Models.CameraSaveResponse>;
  }

  /** List own tenant captures, or all authorized captures on one exact bank, location or unit. */
  getCameraCaptures(options: Models.GetCameraCapturesOptions = {}, request: RequestOptions = {}): Promise<Models.CameraCapturePage> {
    return this.send("GetCameraCaptures", {"resourceKid": options.resourceKid, "cursor": options.cursor}, undefined, request) as Promise<Models.CameraCapturePage>;
  }

  /** Confirm publication of an exact prepared capture after an uncertain upload response. */
  confirmCameraCapture(body: Models.CameraConfirmationRequest, request: RequestOptions = {}): Promise<Models.CameraConfirmationResponse> {
    return this.send("ConfirmCameraCapture", {}, body, request) as Promise<Models.CameraConfirmationResponse>;
  }

  /** Stream one capture component through the API, with current resource authorization. */
  getCameraCaptureContent(id: string, options: Models.GetCameraCaptureContentOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetCameraCaptureContent", {"id": id, "part": options.part, "Range": options.range}, undefined, request) as Promise<PortalDownload>;
  }

  /** Read private capture metadata for a public recent-photo thumbnail. */
  getRecentCameraPhotoMetadata(id: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetRecentCameraPhotoMetadata", {"id": id}, undefined, request) as Promise<PortalDownload>;
  }

  /** List authorized settlement periods requiring attention, as in DatPro2 Checklist1. */
  getChecklist(options: Models.GetChecklistOptions = {}, request: RequestOptions = {}): Promise<Models.ChecklistPage> {
    return this.send("GetChecklist", {"scopeKid": options.scopeKid, "includeResolved": options.includeResolved, "pageSize": options.pageSize, "cursor": options.cursor}, undefined, request) as Promise<Models.ChecklistPage>;
  }

  /** Read one current checklist period, including its hidden/completed status. */
  getChecklistPeriod(periodKid: string, request: RequestOptions = {}): Promise<Models.ChecklistItem> {
    return this.send("GetChecklistPeriod", {"periodKid": periodKid}, undefined, request) as Promise<Models.ChecklistItem>;
  }

  /** Downloads the complete filtered selection as CSV or a genuine Excel workbook. */
  exportBankAccount(bankKid: string, options: Models.ExportBankAccountOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("ExportBankAccount", {"bankKid": bankKid, "From": options.from, "Through": options.through, "TimeZone": options.timeZone, "Period": options.period, "LocationKid": options.locationKid, "LocationKids": options.locationKids, "UnitKid": options.unitKid, "UserKid": options.userKid, "Kind": options.kind, "IncludeZero": options.includeZero, "IncludeBookings": options.includeBookings, "IncludeMonthly": options.includeMonthly, "Offset": options.offset, "Limit": options.limit, "format": options.format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text. */
  exportBankUsers(bankKid: string, options: Models.ExportBankUsersOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("ExportBankUsers", {"bankKid": bankKid, "filter": options.filter, "locationKid": options.locationKid, "deleted": options.deleted, "sort": options.sort, "direction": options.direction, "locationKids": options.locationKids}, undefined, request) as Promise<PortalDownload>;
  }

  /** Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest. */
  downloadBankSettlement(bankKid: string, period: number, options: Models.DownloadBankSettlementOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadBankSettlement", {"bankKid": bankKid, "period": period, "format": options.format}, undefined, request) as Promise<PortalDownload>;
  }

  /** Download a UTF-8 CSV table for one document. */
  downloadUnitDocumentCsv(cycleKid: string, options: Models.DownloadUnitDocumentCsvOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadUnitDocumentCsv", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<PortalDownload>;
  }

  /** Download an Excel 97–2003 binary .xls workbook for one document. */
  downloadUnitDocumentXls(cycleKid: string, options: Models.DownloadUnitDocumentXlsOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("DownloadUnitDocumentXls", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<PortalDownload>;
  }

  /** List a bank's machine errors, as in DatPro2 Errors2. */
  getBankErrors(bankKid: string, options: Models.GetBankErrorsOptions = {}, request: RequestOptions = {}): Promise<Models.UnitErrorPage> {
    return this.send("GetBankErrors", {"bankKid": bankKid, "days": options.days, "level": options.level, "includeAcknowledged": options.includeAcknowledged, "pageSize": options.pageSize, "cursor": options.cursor}, undefined, request) as Promise<Models.UnitErrorPage>;
  }

  /** Read one authorized error event, including its current acknowledgement and revision. */
  getError(errorKid: string, request: RequestOptions = {}): Promise<Models.UnitErrorItem> {
    return this.send("GetError", {"errorKid": errorKid}, undefined, request) as Promise<Models.UnitErrorItem>;
  }

  /** Acknowledge one error without deleting its log or changing machine status. */
  acknowledgeError(errorKid: string, body: Models.AcknowledgeErrorRequest, request: RequestOptions = {}): Promise<Models.UnitErrorItem> {
    return this.send("AcknowledgeError", {"errorKid": errorKid}, body, request) as Promise<Models.UnitErrorItem>;
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

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getInstallerExportCount(options: Models.GetInstallerExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetInstallerExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction, "includeActivationCode": options.includeActivationCode}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** List installers with locations, tags, account state and last activity. */
  getInstallers(options: Models.GetInstallersOptions = {}, request: RequestOptions = {}): Promise<Models.InstallerDirectoryResponse> {
    return this.send("GetInstallers", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "includeActivationCode": options.includeActivationCode}, undefined, request) as Promise<Models.InstallerDirectoryResponse>;
  }

  /** Read one installer and the same Person icon catalog used for administrators. */
  getInstaller(installerKid: string, request: RequestOptions = {}): Promise<Models.InstallerDetailsResponse> {
    return this.send("GetInstaller", {"installerKid": installerKid}, undefined, request) as Promise<Models.InstallerDetailsResponse>;
  }

  /** Read recent live logs from Portal API, Equipment API and Portal Web. */
  getLiveLogs(request: RequestOptions = {}): Promise<Models.LiveLogsResponse> {
    return this.send("GetLiveLogs", {}, undefined, request) as Promise<Models.LiveLogsResponse>;
  }

  /** Count accessible active locations for the Locations1 navigation icon. */
  getActiveLocationCount(options: Models.GetActiveLocationCountOptions = {}, request: RequestOptions = {}): Promise<Models.ActiveLocationCountResponse> {
    return this.send("GetActiveLocationCount", {"bankKid": options.bankKid}, undefined, request) as Promise<Models.ActiveLocationCountResponse>;
  }

  /** List accessible locations with parent banks, Visma customer numbers and authorized activation codes. */
  getLocations(options: Models.GetLocationsOptions = {}, request: RequestOptions = {}): Promise<Models.LocationDirectoryResponse> {
    return this.send("GetLocations", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "includeCoordinates": options.includeCoordinates, "bankKid": options.bankKid}, undefined, request) as Promise<Models.LocationDirectoryResponse>;
  }

  /** Count every location matching the same filters, selected search columns and permissions as GetLocations. */
  getLocationCount(options: Models.GetLocationCountOptions = {}, request: RequestOptions = {}): Promise<Models.LocationCountResponse> {
    return this.send("GetLocationCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "bankKid": options.bankKid}, undefined, request) as Promise<Models.LocationCountResponse>;
  }

  /** Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24. */
  searchLocations(options: Models.SearchLocationsOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchLocations", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Decode a location activation code and resolve its visible name and icon in Log24. */
  searchLocationActivation(options: Models.SearchLocationActivationOptions = {}, request: RequestOptions = {}): Promise<Models.SearchResults> {
    return this.send("SearchLocationActivation", {"q": options.q}, undefined, request) as Promise<Models.SearchResults>;
  }

  /** Read dated reservation calendars with location opening hours already applied. */
  getLocationBookingCalendars(locationKid: string, options: Models.GetLocationBookingCalendarsOptions = {}, request: RequestOptions = {}): Promise<Models.LocationBookingCalendarsResponse> {
    return this.send("GetLocationBookingCalendars", {"locationKid": locationKid, "Accept-Language": options.acceptLanguage, "from": options.from, "days": options.days}, undefined, request) as Promise<Models.LocationBookingCalendarsResponse>;
  }

  /** Read localized configured reservation rules for the location's visible units. */
  getLocationBookingRules(locationKid: string, options: Models.GetLocationBookingRulesOptions = {}, request: RequestOptions = {}): Promise<Models.LocationBookingRulesResponse> {
    return this.send("GetLocationBookingRules", {"locationKid": locationKid, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.LocationBookingRulesResponse>;
  }

  /** Read an authorized controller using its canonical Controller KID with MainId. */
  getControllerOverview(controllerKid: string, options: Models.GetControllerOverviewOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDetailsResponse> {
    return this.send("GetControllerOverview", {"controllerKid": controllerKid, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.UnitDetailsResponse>;
  }

  /** Read the controller's temporary Core settings or states from its main unit. */
  getControllerGroup(controllerKid: string, kind: string, group: string, options: Models.GetControllerGroupOptions = {}, request: RequestOptions = {}): Promise<Models.UnitGroupResponse> {
    return this.send("GetControllerGroup", {"controllerKid": controllerKid, "kind": kind, "group": group, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.UnitGroupResponse>;
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

  /** Read bank Log5 reservation history for the location's authorized visible units. */
  getLocationReservationHistory(locationKid: string, options: Models.GetLocationReservationHistoryOptions = {}, request: RequestOptions = {}): Promise<Models.LocationReservationHistoryResponse> {
    return this.send("GetLocationReservationHistory", {"locationKid": locationKid, "from": options.from, "days": options.days, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.LocationReservationHistoryResponse>;
  }

  /** Read active tenant Log5 reservations for the location's authorized visible units. */
  getLocationReservations(locationKid: string, options: Models.GetLocationReservationsOptions = {}, request: RequestOptions = {}): Promise<Models.LocationReservationsResponse> {
    return this.send("GetLocationReservations", {"locationKid": locationKid, "from": options.from, "days": options.days, "Accept-Language": options.acceptLanguage}, undefined, request) as Promise<Models.LocationReservationsResponse>;
  }

  /** Get current weather for the authorized location's stored position or address. */
  getLocationWeather(locationKid: string, request: RequestOptions = {}): Promise<Models.LocationWeatherResponse> {
    return this.send("GetLocationWeather", {"locationKid": locationKid}, undefined, request) as Promise<Models.LocationWeatherResponse>;
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

  /** Replace all nine permission categories with a predefined administrator role. */
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

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getManagerExportCount(options: Models.GetManagerExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetManagerExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** Read one administrator by canonical manager KID for a workspace shortcut. */
  getManager(managerKid: string, request: RequestOptions = {}): Promise<Models.ManagerDirectoryItem> {
    return this.send("GetManager", {"managerKid": managerKid}, undefined, request) as Promise<Models.ManagerDirectoryItem>;
  }

  /** List other visible administrators with the same stored email as this manager. */
  getManagersWithSameEmail(managerKid: string, request: RequestOptions = {}): Promise<Models.ManagerEmailMatch[]> {
    return this.send("GetManagersWithSameEmail", {"managerKid": managerKid}, undefined, request) as Promise<Models.ManagerEmailMatch[]>;
  }

  /** Log in with manager email/password or manager username/API key. */
  loginManager(body: Models.ManagerLoginRequest, options: Models.LoginManagerOptions = {}, request: RequestOptions = {}): Promise<Models.ManagerSessionResponse> {
    return this.send("LoginManager", {"X-Portal-Login-Client-IP": options.xPortalLoginClientIp}, body, request) as Promise<Models.ManagerSessionResponse>;
  }

  /** Renew an unexpired manager session for ten days. */
  renewManagerSession(request: RequestOptions = {}): Promise<Models.ManagerSessionResponse> {
    return this.send("RenewManagerSession", {}, undefined, request) as Promise<Models.ManagerSessionResponse>;
  }

  /** Get your profile, permitted tabs, bank/location access, and operation permissions. */
  getCurrentManager(options: Models.GetCurrentManagerOptions = {}, request: RequestOptions = {}): Promise<Models.ManagerProfileResponse> {
    return this.send("GetCurrentManager", {"refresh": options.refresh}, undefined, request) as Promise<Models.ManagerProfileResponse>;
  }

  /** Create a pending manager with a password and queue a manager-bound verification email. */
  requestManagerSignUp(body: Models.ManagerSignUpRequest, request: RequestOptions = {}): Promise<Models.PersonalAccountResult> {
    return this.send("RequestManagerSignUp", {}, body, request) as Promise<Models.PersonalAccountResult>;
  }

  /** Verify the email and activate only the manager already created by self-registration. */
  confirmManagerSignUp(body: Models.ManagerSignUpConfirmation, request: RequestOptions = {}): Promise<Models.PersonalAccountResult> {
    return this.send("ConfirmManagerSignUp", {}, body, request) as Promise<Models.PersonalAccountResult>;
  }

  /** Assign or remove one available eTab on an administrator. */
  setManagerTab(managerKid: string, tabId: number, body: Models.ManagerTabChangeRequest, request: RequestOptions = {}): Promise<Models.ManagerTabChangeResponse> {
    return this.send("SetManagerTab", {"managerKid": managerKid, "tabId": tabId}, body, request) as Promise<Models.ManagerTabChangeResponse>;
  }

  /** Save your own theme preference. */
  setCurrentManagerTheme(body: Models.ManagerThemeRequest, request: RequestOptions = {}): Promise<Models.ManagerThemeResponse> {
    return this.send("SetCurrentManagerTheme", {}, body, request) as Promise<Models.ManagerThemeResponse>;
  }

  /** Get up to ten authorized locations nearest to a supplied position. */
  getNearestLocations(options: Models.GetNearestLocationsOptions = {}, request: RequestOptions = {}): Promise<Models.NearestLocationItem[]> {
    return this.send("GetNearestLocations", {"latitude": options.latitude, "longitude": options.longitude}, undefined, request) as Promise<Models.NearestLocationItem[]>;
  }

  /** Count all visible administrators, independently of the current page/filter. */
  getManagerCount(request: RequestOptions = {}): Promise<Models.PeopleDirectoryCount> {
    return this.send("GetManagerCount", {}, undefined, request) as Promise<Models.PeopleDirectoryCount>;
  }

  /** Count all visible installers, independently of the current page/filter. */
  getInstallerCount(request: RequestOptions = {}): Promise<Models.PeopleDirectoryCount> {
    return this.send("GetInstallerCount", {}, undefined, request) as Promise<Models.PeopleDirectoryCount>;
  }

  /** Read your own personal settings and available person icons. */
  getMyManagerProfile(request: RequestOptions = {}): Promise<Models.PersonalManagerProfile> {
    return this.send("GetMyManagerProfile", {}, undefined, request) as Promise<Models.PersonalManagerProfile>;
  }

  /** Add a scanned display to your own WallBoards layout setting. */
  addMyManagerWallboard(body: Models.PersonalWallboardRequest, request: RequestOptions = {}): Promise<Models.PersonalAccountResult> {
    return this.send("AddMyManagerWallboard", {}, body, request) as Promise<Models.PersonalAccountResult>;
  }

  /** Read your own Wallboard1 editor layouts and concurrency revision. */
  getMyManagerWallboards(request: RequestOptions = {}): Promise<Models.PersonalWallboardsResponse> {
    return this.send("GetMyManagerWallboards", {}, undefined, request) as Promise<Models.PersonalWallboardsResponse>;
  }

  /** Save your own Wallboard1 layouts and optional portal overview layout. */
  saveMyManagerWallboards(body: Models.SavePersonalWallboardsRequest, request: RequestOptions = {}): Promise<Models.PersonalWallboardsResponse> {
    return this.send("SaveMyManagerWallboards", {}, body, request) as Promise<Models.PersonalWallboardsResponse>;
  }

  /** Read the selected orientation for one of your Wallboards. */
  getMyManagerWallboardDisplay(displayId: string, options: Models.GetMyManagerWallboardDisplayOptions = {}, request: RequestOptions = {}): Promise<Models.WallboardDisplayResponse> {
    return this.send("GetMyManagerWallboardDisplay", {"displayId": displayId, "portrait": options.portrait, "after": options.after}, undefined, request) as Promise<Models.WallboardDisplayResponse>;
  }

  /** Read your own API-key configuration status and revision without exposing credentials. */
  getMyManagerApiKey(request: RequestOptions = {}): Promise<Models.PersonalManagerApiKey> {
    return this.send("GetMyManagerApiKey", {}, undefined, request) as Promise<Models.PersonalManagerApiKey>;
  }

  /** Generate your own API key and commit its hash to eSetting.ApiKeyHash. */
  generateMyManagerApiKey(body: Models.PersonalApiKeyRequest, request: RequestOptions = {}): Promise<Models.PersonalApiKeyResponse> {
    return this.send("GenerateMyManagerApiKey", {}, body, request) as Promise<Models.PersonalApiKeyResponse>;
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

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getServiceExportCount(options: Models.GetServiceExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetServiceExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** List concrete service enum identities, including services without saved settings. */
  getServices(options: Models.GetServicesOptions = {}, request: RequestOptions = {}): Promise<Models.ServiceDirectoryResponse> {
    return this.send("GetServices", {"filter": options.filter, "sort": options.sort, "direction": options.direction}, undefined, request) as Promise<Models.ServiceDirectoryResponse>;
  }

  /** Count the predefined service identities without reading service settings. */
  getServiceCount(request: RequestOptions = {}): Promise<Models.PeopleDirectoryCount> {
    return this.send("GetServiceCount", {}, undefined, request) as Promise<Models.PeopleDirectoryCount>;
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

  /** Convert MS2000, MI2000, SS2000, UTC or a local wall time without floating-point integers. */
  convertToolTime(body: Models.ToolTimeRequest, request: RequestOptions = {}): Promise<Models.ToolTimeResponse> {
    return this.send("ConvertToolTime", {}, body, request) as Promise<Models.ToolTimeResponse>;
  }

  /** Inspect only the supplied KID with the installed Kombine.Flex.Kid parser. */
  inspectToolKid(body: Models.ToolKidInspectionRequest, request: RequestOptions = {}): Promise<Models.ToolKidInspectionResponse> {
    return this.send("InspectToolKid", {}, body, request) as Promise<Models.ToolKidInspectionResponse>;
  }

  /** Get the authorized machine context, log categories and readable timeline fields. */
  getUnitTimelineFields(unitKid: string, request: RequestOptions = {}): Promise<Models.UnitTimelineFields> {
    return this.send("GetUnitTimelineFields", {"unitKid": unitKid}, undefined, request) as Promise<Models.UnitTimelineFields>;
  }

  /** Page chronologically through one machine's authorized Log0–Log6 events. */
  getUnitTimeline(unitKid: string, options: Models.GetUnitTimelineOptions = {}, request: RequestOptions = {}): Promise<Models.UnitTimelinePage> {
    return this.send("GetUnitTimeline", {"unitKid": unitKid, "fromUtc": options.fromUtc, "untilUtc": options.untilUtc, "sources": options.sources, "field": options.field, "pageSize": options.pageSize, "cursor": options.cursor}, undefined, request) as Promise<Models.UnitTimelinePage>;
  }

  /** List document identities produced by the selected Unit for WashDoc3. */
  getUnitDocuments(unitKid: string, options: Models.GetUnitDocumentsOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDocumentPage> {
    return this.send("GetUnitDocuments", {"unitKid": unitKid, "Sort": options.sort, "Direction": options.direction, "Offset": options.offset, "Limit": options.limit, "Search": options.search, "Date": options.date}, undefined, request) as Promise<Models.UnitDocumentPage>;
  }

  /** Count distinct WashDoc3 document identities for exactly one unit, separately from list loading. */
  getUnitDocumentsCount(unitKid: string, options: Models.GetUnitDocumentsCountOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDocumentCount> {
    return this.send("GetUnitDocumentsCount", {"unitKid": unitKid, "Search": options.search, "Date": options.date}, undefined, request) as Promise<Models.UnitDocumentCount>;
  }

  /** Find the previous (higher Doc ID) and next (lower Doc ID) existing document for this exact unit. */
  getUnitDocumentNeighbors(cycleKid: string, request: RequestOptions = {}): Promise<Models.DocumentNeighbors> {
    return this.send("GetUnitDocumentNeighbors", {"cycleKid": cycleKid}, undefined, request) as Promise<Models.DocumentNeighbors>;
  }

  /** Read a document's table as JSON with original values and column metadata. */
  getUnitDocumentTable(cycleKid: string, options: Models.GetUnitDocumentTableOptions = {}, request: RequestOptions = {}): Promise<Models.DocumentTable> {
    return this.send("GetUnitDocumentTable", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<Models.DocumentTable>;
  }

  /** View a document as a printable HTML table. */
  getUnitDocumentHtml(cycleKid: string, options: Models.GetUnitDocumentHtmlOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentHtml", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<PortalDownload>;
  }

  /** Render a document's numeric series as an SVG chart, caching completed documents privately. */
  getUnitDocumentSvg(cycleKid: string, options: Models.GetUnitDocumentSvgOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentSvg", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements, "width": options.width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Render a responsive WashDoc chart with independent text and graph layers. */
  getUnitDocumentSvg2(cycleKid: string, options: Models.GetUnitDocumentSvg2Options = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentSvg2", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<PortalDownload>;
  }

  /** Read semantic WashDoc graph JSON for interactive charts and image rendering. */
  getUnitDocumentGraph(cycleKid: string, options: Models.GetUnitDocumentGraphOptions = {}, request: RequestOptions = {}): Promise<Models.WashDocChartResponse> {
    return this.send("GetUnitDocumentGraph", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<Models.WashDocChartResponse>;
  }

  /** Render a document KID as a PNG image with the shared local Chart.js renderer. */
  getUnitDocumentPng(cycleKid: string, options: Models.GetUnitDocumentPngOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentPng", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<PortalDownload>;
  }

  /** Render the first WashDoc curve as a monochrome line icon. */
  getUnitDocumentIcon(cycleKid: string, options: Models.GetUnitDocumentIconOptions = {}, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetUnitDocumentIcon", {"cycleKid": cycleKid, "States": options.states, "Settings": options.settings, "HistoricalMeasurements": options.historicalMeasurements}, undefined, request) as Promise<PortalDownload>;
  }

  /** List out-of-order machines, including manual, automatic and repair states. */
  getOutOfOrderUnits(options: Models.GetOutOfOrderUnitsOptions = {}, request: RequestOptions = {}): Promise<Models.OutOfOrderPage> {
    return this.send("GetOutOfOrderUnits", {"pageSize": options.pageSize, "cursor": options.cursor}, undefined, request) as Promise<Models.OutOfOrderPage>;
  }

  /** Return one out-of-order machine to service by setting OutOfOrder to Enabled (0). */
  restoreOutOfOrderUnit(unitKid: string, body: Models.OutOfOrderRestoreRequest, request: RequestOptions = {}): Promise<Models.OutOfOrderRestoreResponse> {
    return this.send("RestoreOutOfOrderUnit", {"unitKid": unitKid}, body, request) as Promise<Models.OutOfOrderRestoreResponse>;
  }

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getUnitExportCount(options: Models.GetUnitExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetUnitExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "locationKid": options.locationKid, "terminalKid": options.terminalKid, "runningOnly": options.runningOnly, "autoOutOfOrderOnly": options.autoOutOfOrderOnly}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** Count authorized main terminals matching the export filters. */
  getTerminalExportCount(options: Models.GetTerminalExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetTerminalExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "locationKid": options.locationKid, "terminalKid": options.terminalKid, "runningOnly": options.runningOnly}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** Count accessible active units for the Units1 navigation icon. */
  getActiveUnitCount(request: RequestOptions = {}): Promise<Models.ActiveUnitCountResponse> {
    return this.send("GetActiveUnitCount", {}, undefined, request) as Promise<Models.ActiveUnitCountResponse>;
  }

  /** Count accessible active terminals for the Terminals1 navigation icon. */
  getActiveTerminalCount(request: RequestOptions = {}): Promise<Models.ActiveUnitCountResponse> {
    return this.send("GetActiveTerminalCount", {}, undefined, request) as Promise<Models.ActiveUnitCountResponse>;
  }

  /** List authorized units, including child units, for Units1. */
  getUnits(options: Models.GetUnitsOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDirectoryResponse> {
    return this.send("GetUnits", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "includeCoordinates": options.includeCoordinates, "locationKid": options.locationKid, "terminalKid": options.terminalKid, "runningOnly": options.runningOnly, "autoOutOfOrderOnly": options.autoOutOfOrderOnly}, undefined, request) as Promise<Models.UnitDirectoryResponse>;
  }

  /** List authorized main units for Terminals1. */
  getTerminals(options: Models.GetTerminalsOptions = {}, request: RequestOptions = {}): Promise<Models.UnitDirectoryResponse> {
    return this.send("GetTerminals", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly, "fields": options.fields, "includeCoordinates": options.includeCoordinates, "locationKid": options.locationKid, "terminalKid": options.terminalKid, "runningOnly": options.runningOnly}, undefined, request) as Promise<Models.UnitDirectoryResponse>;
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

  /** Count the complete filtered export selection using the same directory authorization and visibility. */
  getUserExportCount(options: Models.GetUserExportCountOptions = {}, request: RequestOptions = {}): Promise<Models.DirectoryExportCountResponse> {
    return this.send("GetUserExportCount", {"filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly}, undefined, request) as Promise<Models.DirectoryExportCountResponse>;
  }

  /** List authorized residents for UserFinder1 (77). */
  getUsers(options: Models.GetUsersOptions = {}, request: RequestOptions = {}): Promise<Models.UserDirectoryResponse> {
    return this.send("GetUsers", {"pageSize": options.pageSize, "cursor": options.cursor, "filter": options.filter, "sort": options.sort, "direction": options.direction, "enabledOnly": options.enabledOnly}, undefined, request) as Promise<Models.UserDirectoryResponse>;
  }

  /** Count active authorized residents for the UserFinder1 badge. */
  getUserCount(request: RequestOptions = {}): Promise<Models.PeopleDirectoryCount> {
    return this.send("GetUserCount", {}, undefined, request) as Promise<Models.PeopleDirectoryCount>;
  }

  /** Create an eVaskeri login link for one active Nortec resident. */
  createUserEvaskeriSession(userKid: string, request: RequestOptions = {}): Promise<Models.UserEvaskeriSession> {
    return this.send("CreateUserEvaskeriSession", {"userKid": userKid}, undefined, request) as Promise<Models.UserEvaskeriSession>;
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

  /** Start a five-minute pairing. Keep deviceCode private; show only pairingId in the QR code. */
  startWallboardPairing(body: Models.StartWallboardPairing, request: RequestOptions = {}): Promise<Models.WallboardPairingStarted> {
    return this.send("StartWallboardPairing", {}, body, request) as Promise<Models.WallboardPairingStarted>;
  }

  /** Find up to ten pending screens with an exact display ID in this tenant and environment. */
  findWallboardPairings(options: Models.FindWallboardPairingsOptions = {}, request: RequestOptions = {}): Promise<Models.WallboardPairingInfo[]> {
    return this.send("FindWallboardPairings", {"displayId": options.displayId}, undefined, request) as Promise<Models.WallboardPairingInfo[]>;
  }

  /** Read the screen ID and expiry before explicitly approving its QR code. */
  getWallboardPairing(pairingId: string, request: RequestOptions = {}): Promise<Models.WallboardPairingInfo> {
    return this.send("GetWallboardPairing", {"pairingId": pairingId}, undefined, request) as Promise<Models.WallboardPairingInfo>;
  }

  /** Approve one screen using your current manager bearer session, including sessions created with kid and apiKey. */
  approveWallboardPairing(pairingId: string, body: Models.ApproveWallboardPairing, request: RequestOptions = {}): Promise<void> {
    return this.send("ApproveWallboardPairing", {"pairingId": pairingId}, body, request) as Promise<void>;
  }

  /** Poll with the private deviceCode. Successful redemption consumes the pairing atomically. */
  redeemWallboardPairing(pairingId: string, body: Models.RedeemWallboardPairing, request: RequestOptions = {}): Promise<Models.WallboardPairingToken> {
    return this.send("RedeemWallboardPairing", {"pairingId": pairingId}, body, request) as Promise<Models.WallboardPairingToken>;
  }

  /** Request a two-minute signing challenge for a permanently approved screen. */
  challengeWallboardDevice(deviceId: string, request: RequestOptions = {}): Promise<Models.WallboardDeviceChallenge> {
    return this.send("ChallengeWallboardDevice", {"deviceId": deviceId}, undefined, request) as Promise<Models.WallboardDeviceChallenge>;
  }

  /** Resume a permanently approved screen after proving possession of its private signing key. */
  resumeWallboardSession(deviceId: string, body: Models.ResumeWallboardSession, request: RequestOptions = {}): Promise<Models.WallboardPairingToken> {
    return this.send("ResumeWallboardSession", {"deviceId": deviceId}, body, request) as Promise<Models.WallboardPairingToken>;
  }

  /** Read a screen you approved, including the optional scanner location stored with its approval. */
  getWallboardDevice(deviceId: string, request: RequestOptions = {}): Promise<Models.WallboardDeviceInfo> {
    return this.send("GetWallboardDevice", {"deviceId": deviceId}, undefined, request) as Promise<Models.WallboardDeviceInfo>;
  }

  /** Revoke a screen you approved. Its existing bearer sessions also lose access. */
  revokeWallboardDevice(deviceId: string, request: RequestOptions = {}): Promise<void> {
    return this.send("RevokeWallboardDevice", {"deviceId": deviceId}, undefined, request) as Promise<void>;
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
    return this.send("GetIconPresentation", {"iconKid": options.iconKid, "text": options.text, "count": options.count, "color": options.color, "useCalendarText": options.useCalendarText}, undefined, request) as Promise<Models.IconPresentationResponse>;
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

  /** Renders selected parts of the Kombine symbol in its original square viewport. */
  getKombineLogoParts(parts: string, color: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoParts", {"parts": parts, "color": color}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders selected Kombine symbol parts at the selected width. */
  getKombineLogoPartsSized(parts: string, color: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoPartsSized", {"parts": parts, "color": color, "width": width}, undefined, request) as Promise<PortalDownload>;
  }

  /** Renders selected Kombine symbol parts with an explicit background and width. */
  getKombineLogoPartsWithBackground(parts: string, color: string, background: string, width: number, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetKombineLogoPartsWithBackground", {"parts": parts, "color": color, "background": background, "width": width}, undefined, request) as Promise<PortalDownload>;
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

  /** Get the portal chart's localized messages and stable state identifiers. */
  getCycleChartPresentation(request: RequestOptions = {}): Promise<Models.CycleChartPresentationResponse> {
    return this.send("GetCycleChartPresentation", {}, undefined, request) as Promise<Models.CycleChartPresentationResponse>;
  }

  /** Returns the site overview's running-machine pool, refreshed at most once a minute. */
  getPublicLiveMachines(request: RequestOptions = {}): Promise<Models.LiveMachineResponse[]> {
    return this.send("GetPublicLiveMachines", {}, undefined, request) as Promise<Models.LiveMachineResponse[]>;
  }

  /** List machines with a positive AutoOutOfOrder Id without login. */
  getPublicMachineErrors(options: Models.GetPublicMachineErrorsOptions = {}, request: RequestOptions = {}): Promise<Models.PublicMachineErrorsPage> {
    return this.send("GetPublicMachineErrors", {"pageSize": options.pageSize, "cursor": options.cursor}, undefined, request) as Promise<Models.PublicMachineErrorsPage>;
  }

  /** Get the ten newest photos, including Live Photo stills, newest first. */
  getPublicRecentCameraPhotos(request: RequestOptions = {}): Promise<Models.PublicCameraPhoto[]> {
    return this.send("GetPublicRecentCameraPhotos", {}, undefined, request) as Promise<Models.PublicCameraPhoto[]>;
  }

  /** Read only the JPEG thumbnail authorized by a ten-minute, tenant-bound public ticket. */
  getPublicCameraThumbnail(id: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetPublicCameraThumbnail", {"id": id}, undefined, request) as Promise<PortalDownload>;
  }

  /** Get a square WashDoc widget's graph, machine/location names and document times. */
  getPublicCycleWidget(options: Models.GetPublicCycleWidgetOptions = {}, request: RequestOptions = {}): Promise<Models.PublicCycleWidgetResponse> {
    return this.send("GetPublicCycleWidget", {"cycleKid": options.cycleKid, "unitKid": options.unitKid}, undefined, request) as Promise<Models.PublicCycleWidgetResponse>;
  }

  /** Draws purchase counts for the last hour in twelve five-minute intervals. */
  getPublicPurchasesChart(color: string, request: RequestOptions = {}): Promise<PortalDownload> {
    return this.send("GetPublicPurchasesChart", {"color": color}, undefined, request) as Promise<PortalDownload>;
  }

  /** Shows recent purchases as coin markers on a map. No login required. */
  getPublicDisp73(options: Models.GetPublicDisp73Options = {}, request: RequestOptions = {}): Promise<Models.PurchaseMapSnapshot> {
    return this.send("GetPublicDisp73", {"limit": options.limit}, undefined, request) as Promise<Models.PurchaseMapSnapshot>;
  }

  /** Get progress for one unit or a page of all public units in a location or bank. */
  getPublicScopedUnitProgress(kid: string, options: Models.GetPublicScopedUnitProgressOptions = {}, request: RequestOptions = {}): Promise<Models.PublicScopedProgressResponse> {
    return this.send("GetPublicScopedUnitProgress", {"kid": kid, "pageSize": options.pageSize, "cursor": options.cursor}, undefined, request) as Promise<Models.PublicScopedProgressResponse>;
  }

  /** Counts purchases in the site's Log1Hour without login. */
  getPublicPurchases(request: RequestOptions = {}): Promise<Models.PurchasesResponse> {
    return this.send("GetPublicPurchases", {}, undefined, request) as Promise<Models.PurchasesResponse>;
  }

  /** Counts active users in the site's current Log7 during the last 100 days, without login. */
  getPublicActiveUsers(request: RequestOptions = {}): Promise<Models.ActiveUsersResponse> {
    return this.send("GetPublicActiveUsers", {}, undefined, request) as Promise<Models.ActiveUsersResponse>;
  }

  /** Get localized labels and the site's palette for the shared JavaScript widgets. */
  getPublicWidgetPresentation(request: RequestOptions = {}): Promise<Models.PublicWidgetPresentationResponse> {
    return this.send("GetPublicWidgetPresentation", {}, undefined, request) as Promise<Models.PublicWidgetPresentationResponse>;
  }

  /** Counts noncancelled dated reservations that have not ended, including ongoing reservations. */
  getPublicReservations(request: RequestOptions = {}): Promise<Models.ReservationsStatisticsResponse> {
    return this.send("GetPublicReservations", {}, undefined, request) as Promise<Models.ReservationsStatisticsResponse>;
  }

  /** Counts machines whose current Started is before now and Done is after now. */
  getPublicRunningMachines(request: RequestOptions = {}): Promise<Models.RunningMachinesResponse> {
    return this.send("GetPublicRunningMachines", {}, undefined, request) as Promise<Models.RunningMachinesResponse>;
  }

  /** Gets public API availability. This does not check database readiness. */
  getPortalStatus(request: RequestOptions = {}): Promise<Models.ApiStatusResponse> {
    return this.send("GetPortalStatus", {}, undefined, request) as Promise<Models.ApiStatusResponse>;
  }

}
