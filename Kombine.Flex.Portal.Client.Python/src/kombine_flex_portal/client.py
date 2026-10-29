"""Generated operations; regenerate with scripts/Generate-PortalScriptClients.py."""
from __future__ import annotations
from typing import Any
from .models import *
from ._runtime import BaseClient, PortalDownload, PortalUploadFile


class PortalClient(BaseClient):

    def get_bank_account_icon(self, bank_kid: str) -> AccountIconResponse:
        'Resolve the Forbrug icon text from the most frequent authorized Log1 currency.'
        return self._request('GetBankAccountIcon', {'bankKid': bank_kid}, None)

    def get_bank_account(self, bank_kid: str, *, from_: str | None = None, through: str | None = None, time_zone: str | None = None, period: int | None = None, location_kid: str | None = None, unit_kid: str | None = None, user_kid: str | None = None, kind: str | None = None, include_zero: bool | None = None, include_bookings: bool | None = None, include_monthly: bool | None = None, offset: int | None = None, limit: int | None = None) -> AccountResponse:
        'Lists Account2 postings with full-selection totals per currency.'
        return self._request('GetBankAccount', {'bankKid': bank_kid, 'From': from_, 'Through': through, 'TimeZone': time_zone, 'Period': period, 'LocationKid': location_kid, 'UnitKid': unit_kid, 'UserKid': user_kid, 'Kind': kind, 'IncludeZero': include_zero, 'IncludeBookings': include_bookings, 'IncludeMonthly': include_monthly, 'Offset': offset, 'Limit': limit}, None)

    def get_bank_account_revision(self, bank_kid: str, *, from_: str | None = None, through: str | None = None, time_zone: str | None = None, period: int | None = None, location_kid: str | None = None, unit_kid: str | None = None, user_kid: str | None = None, kind: str | None = None, include_zero: bool | None = None, include_bookings: bool | None = None, include_monthly: bool | None = None, offset: int | None = None, limit: int | None = None) -> AccountRevisionResponse:
        'Checks whether filtered Account2 postings changed, including late arrivals with old event timestamps.'
        return self._request('GetBankAccountRevision', {'bankKid': bank_kid, 'From': from_, 'Through': through, 'TimeZone': time_zone, 'Period': period, 'LocationKid': location_kid, 'UnitKid': unit_kid, 'UserKid': user_kid, 'Kind': kind, 'IncludeZero': include_zero, 'IncludeBookings': include_bookings, 'IncludeMonthly': include_monthly, 'Offset': offset, 'Limit': limit}, None)

    def reverse_bank_account_entry(self, bank_kid: str, transaction_kid: str) -> AccountEntryResponse:
        'Reverses one eligible resident consumption posting by appending a linked compensation.'
        return self._request('ReverseBankAccountEntry', {'bankKid': bank_kid, 'transactionKid': transaction_kid}, None)

    def get_object_address(self, kid: str) -> ObjectAddressResponse:
        "Read the object's own address, coordinate pair, provenance and concurrency revision."
        return self._request('GetObjectAddress', {'kid': kid}, None)

    def update_object_address(self, kid: str, body: UpdateObjectAddressRequest) -> ObjectAddressResponse:
        'Save Address and Zip together and resolve automatic coordinates once if either field changes.'
        return self._request('UpdateObjectAddress', {'kid': kid}, body)

    def lookup_object_coordinates(self, kid: str, body: ObjectAddressRevisionRequest) -> ObjectAddressResponse:
        'Explicitly look up the current address, replacing manual coordinates only on success.'
        return self._request('LookupObjectCoordinates', {'kid': kid}, body)

    def set_object_coordinates(self, kid: str, body: SetObjectCoordinatesRequest) -> ObjectAddressResponse:
        'Save manual Latitude and Longitude atomically with AutoLatitudeLongitude=30.'
        return self._request('SetObjectCoordinates', {'kid': kid}, body)

    def set_object_coordinate_provenance(self, kid: str, body: SetObjectCoordinateProvenanceRequest) -> ObjectAddressResponse:
        'Change AutoLatitudeLongitude without changing the coordinate pair or making a Google request.'
        return self._request('SetObjectCoordinateProvenance', {'kid': kid}, body)

    def ask_portal_assistant(self, body: AssistantRequest) -> AssistantResponse:
        'Ask the portal assistant to discover and combine approved read operations.'
        return self._request('AskPortalAssistant', {}, body)

    def get_bank_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, bank_type: str | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetBankExportCount', {'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'bankType': bank_type}, None)

    def get_banks(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, bank_type: str | None = None) -> BankDirectoryResponse:
        'List authorized bank identities for Banks2 with selected metadata and stable global ordering.'
        return self._request('GetBanks', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'bankType': bank_type}, None)

    def get_active_bank_count(self) -> ActiveBankCountResponse:
        'Count accessible active banks for the Banks2 navigation icon.'
        return self._request('GetActiveBankCount', {}, None)

    def get_bank_documents(self, bank_kid: str, *, location_kid: str | None = None, date: str | None = None, search: str | None = None, unit_kids: list[str] | None = None, sort: str | None = None, direction: str | None = None, unit_kid: str | None = None, from_: str | None = None, through: str | None = None, offset: int | None = None, limit: int | None = None) -> BankDocumentPage:
        'Search WashDoc document identities by location, unit and time without loading measurements.'
        return self._request('GetBankDocuments', {'bankKid': bank_kid, 'LocationKid': location_kid, 'Date': date, 'Search': search, 'UnitKids': unit_kids, 'Sort': sort, 'Direction': direction, 'UnitKid': unit_kid, 'From': from_, 'Through': through, 'Offset': offset, 'Limit': limit}, None)

    def get_bank_documents_count(self, bank_kid: str, *, location_kid: str | None = None, date: str | None = None, search: str | None = None, unit_kids: list[str] | None = None, sort: str | None = None, direction: str | None = None, unit_kid: str | None = None, from_: str | None = None, through: str | None = None, offset: int | None = None, limit: int | None = None) -> UnitDocumentCount:
        'Count WashDocs across the authorized bank scope, without loading document pages or measurements.'
        return self._request('GetBankDocumentsCount', {'bankKid': bank_kid, 'LocationKid': location_kid, 'Date': date, 'Search': search, 'UnitKids': unit_kids, 'Sort': sort, 'Direction': direction, 'UnitKid': unit_kid, 'From': from_, 'Through': through, 'Offset': offset, 'Limit': limit}, None)

    def get_location_documents(self, location_kid: str, *, date: str | None = None, search: str | None = None, unit_kids: list[str] | None = None, sort: str | None = None, direction: str | None = None, unit_kid: str | None = None, from_: str | None = None, through: str | None = None, offset: int | None = None, limit: int | None = None) -> BankDocumentPage:
        'List WashDocs for one authorized location, optionally selecting one or several units.'
        return self._request('GetLocationDocuments', {'locationKid': location_kid, 'Date': date, 'Search': search, 'UnitKids': unit_kids, 'Sort': sort, 'Direction': direction, 'UnitKid': unit_kid, 'From': from_, 'Through': through, 'Offset': offset, 'Limit': limit}, None)

    def get_location_documents_count(self, location_kid: str, *, date: str | None = None, search: str | None = None, unit_kids: list[str] | None = None, sort: str | None = None, direction: str | None = None, unit_kid: str | None = None, from_: str | None = None, through: str | None = None, offset: int | None = None, limit: int | None = None) -> UnitDocumentCount:
        'Count distinct WashDocs for the selected location and unit choices.'
        return self._request('GetLocationDocumentsCount', {'locationKid': location_kid, 'Date': date, 'Search': search, 'UnitKids': unit_kids, 'Sort': sort, 'Direction': direction, 'UnitKid': unit_kid, 'From': from_, 'Through': through, 'Offset': offset, 'Limit': limit}, None)

    def get_bank_icons(self, *, kid: list[str] | None = None) -> BankIconsResponse:
        "Resolve up to eight bank icons with their authorized units' combined status."
        return self._request('GetBankIcons', {'kid': kid}, None)

    def get_bank_locations(self, bank_kid: str) -> list[BankLocationStatusResponse]:
        'List location names, icons, status and canonical KIDs in bank overview order (location number).'
        return self._request('GetBankLocations', {'bankKid': bank_kid}, None)

    def search_banks(self, *, q: str | None = None) -> SearchResults:
        'Search current bank names and settlement emails; literal case-insensitive substring matching.'
        return self._request('SearchBanks', {'q': q}, None)

    def search_bank_activation(self, *, q: str | None = None) -> SearchResults:
        'Decode a bank activation code and resolve its name and icon from the cached Log24 bank catalogue.'
        return self._request('SearchBankActivation', {'q': q}, None)

    def get_search_bank(self, bank_kid: str) -> SearchResults:
        'Resolve a search result before opening its bank overview, including tenant-wide managers.'
        return self._request('GetSearchBank', {'bankKid': bank_kid}, None)

    def get_bank_user_export_count(self, bank_kid: str, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, location_kid: str | None = None, deleted: str | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetBankUserExportCount', {'bankKid': bank_kid, 'filter': filter, 'sort': sort, 'direction': direction, 'locationKid': location_kid, 'deleted': deleted}, None)

    def get_bank_users(self, bank_kid: str, *, page_size: int | None = None, cursor: str | None = None, sort: str | None = None, direction: str | None = None, filter: str | None = None, user_kid: str | None = None, location_kid: str | None = None, deleted: str | None = None) -> BankUsersResponse:
        'Read one page of users for a bank.'
        return self._request('GetBankUsers', {'bankKid': bank_kid, 'pageSize': page_size, 'cursor': cursor, 'sort': sort, 'direction': direction, 'filter': filter, 'userKid': user_kid, 'locationKid': location_kid, 'deleted': deleted}, None)

    def create_bank_user(self, bank_kid: str, body: UserCommandRequest) -> UserWorkspaceResponse:
        'Create a resident. Requires bank-wide Users2/User Create. Action must be create. No hardware access is assigned automatically.'
        return self._request('CreateBankUser', {'bankKid': bank_kid}, body)

    def get_bank_bookings(self, bank_kid: str, *, from_: str | None = None, through: str | None = None, location_kid: str | None = None, unit_kid: str | None = None, user_kid: str | None = None, status: str | None = None, search: str | None = None, offset: int | None = None, limit: int | None = None) -> BookingsResponse:
        'Lists the latest nonsuperseded Log5 event for each location/unit/resident/start.'
        return self._request('GetBankBookings', {'bankKid': bank_kid, 'from': from_, 'through': through, 'locationKid': location_kid, 'unitKid': unit_kid, 'userKid': user_kid, 'status': status, 'search': search, 'offset': offset, 'limit': limit}, None)

    def execute_bank_booking_command(self, bank_kid: str, booking_kid: str, body: BookingCommand) -> BookingResponse:
        'Appends a cancellation or restoration, preserving history and requesting backend synchronization.'
        return self._request('ExecuteBankBookingCommand', {'bankKid': bank_kid, 'bookingKid': booking_kid}, body)

    def get_camera_nearest_location(self, *, latitude: float | None = None, longitude: float | None = None, accuracy_meters: float | None = None) -> CameraResourceResponse:
        'Resolve the nearest writable location within 100 metres for tenant-level camera capture.'
        return self._request('GetCameraNearestLocation', {'latitude': latitude, 'longitude': longitude, 'accuracyMeters': accuracy_meters}, None)

    def get_camera_resource(self, *, resource_kid: str | None = None) -> CameraResourceResponse:
        'Read the display identity of one authorized camera resource.'
        return self._request('GetCameraResource', {'resourceKid': resource_kid}, None)

    def get_camera_availability(self, *, resource_kid: str | None = None) -> CameraAvailabilityResponse:
        'Check the lazy local camera tab and capture permission for one exact resource.'
        return self._request('GetCameraAvailability', {'resourceKid': resource_kid}, None)

    def prepare_camera_capture(self, body: CameraPrepareRequest) -> CameraPrepareResponse:
        'Prepare a bounded, immutable capture plan including optional weather.'
        return self._request('PrepareCameraCapture', {}, body)

    def save_camera_capture(self, body: dict[str, str | PortalUploadFile], *, background: bool | None = None) -> CameraSaveResponse:
        'Save camera media synchronously, or accept bounded background processing.'
        return self._request('SaveCameraCapture', {'background': background}, body)

    def get_camera_captures(self, *, resource_kid: str | None = None, cursor: str | None = None) -> CameraCapturePage:
        'List own tenant captures, or all authorized captures on one exact bank, location or unit.'
        return self._request('GetCameraCaptures', {'resourceKid': resource_kid, 'cursor': cursor}, None)

    def confirm_camera_capture(self, body: CameraConfirmationRequest) -> CameraConfirmationResponse:
        'Confirm publication of an exact prepared capture after an uncertain upload response.'
        return self._request('ConfirmCameraCapture', {}, body)

    def get_camera_capture_content(self, id: str, *, part: str | None = None, range: str | None = None) -> PortalDownload:
        'Stream one capture component through the API, with current resource authorization.'
        return self._request('GetCameraCaptureContent', {'id': id, 'part': part, 'Range': range}, None)

    def get_recent_camera_photo_metadata(self, id: str) -> PortalDownload:
        'Read private capture metadata for a public recent-photo thumbnail.'
        return self._request('GetRecentCameraPhotoMetadata', {'id': id}, None)

    def get_checklist(self, *, scope_kid: str | None = None, include_resolved: bool | None = None, page_size: int | None = None, cursor: str | None = None) -> ChecklistPage:
        'List authorized settlement periods requiring attention, as in DatPro2 Checklist1.'
        return self._request('GetChecklist', {'scopeKid': scope_kid, 'includeResolved': include_resolved, 'pageSize': page_size, 'cursor': cursor}, None)

    def get_checklist_period(self, period_kid: str) -> ChecklistItem:
        'Read one current checklist period, including its hidden/completed status.'
        return self._request('GetChecklistPeriod', {'periodKid': period_kid}, None)

    def export_bank_account(self, bank_kid: str, *, from_: str | None = None, through: str | None = None, time_zone: str | None = None, period: int | None = None, location_kid: str | None = None, unit_kid: str | None = None, user_kid: str | None = None, kind: str | None = None, include_zero: bool | None = None, include_bookings: bool | None = None, include_monthly: bool | None = None, offset: int | None = None, limit: int | None = None, format: str | None = None) -> PortalDownload:
        'Downloads the complete filtered selection as CSV or a genuine Excel workbook.'
        return self._request('ExportBankAccount', {'bankKid': bank_kid, 'From': from_, 'Through': through, 'TimeZone': time_zone, 'Period': period, 'LocationKid': location_kid, 'UnitKid': unit_kid, 'UserKid': user_kid, 'Kind': kind, 'IncludeZero': include_zero, 'IncludeBookings': include_bookings, 'IncludeMonthly': include_monthly, 'Offset': offset, 'Limit': limit, 'format': format}, None)

    def export_bank_users(self, bank_kid: str, *, filter: str | None = None, location_kid: str | None = None, deleted: str | None = None, sort: str | None = None, direction: str | None = None) -> PortalDownload:
        'Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text.'
        return self._request('ExportBankUsers', {'bankKid': bank_kid, 'filter': filter, 'locationKid': location_kid, 'deleted': deleted, 'sort': sort, 'direction': direction}, None)

    def download_bank_settlement(self, bank_kid: str, period: int, *, format: str | None = None) -> PortalDownload:
        'Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest.'
        return self._request('DownloadBankSettlement', {'bankKid': bank_kid, 'period': period, 'format': format}, None)

    def download_unit_document_csv(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> PortalDownload:
        'Download a UTF-8 CSV table for one document.'
        return self._request('DownloadUnitDocumentCsv', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def download_unit_document_xls(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> PortalDownload:
        'Download an Excel 97–2003 binary .xls workbook for one document.'
        return self._request('DownloadUnitDocumentXls', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_bank_errors(self, bank_kid: str, *, days: int | None = None, level: str | None = None, include_acknowledged: bool | None = None, page_size: int | None = None, cursor: str | None = None) -> UnitErrorPage:
        "List a bank's machine errors, as in DatPro2 Errors2."
        return self._request('GetBankErrors', {'bankKid': bank_kid, 'days': days, 'level': level, 'includeAcknowledged': include_acknowledged, 'pageSize': page_size, 'cursor': cursor}, None)

    def get_error(self, error_kid: str) -> UnitErrorItem:
        'Read one authorized error event, including its current acknowledgement and revision.'
        return self._request('GetError', {'errorKid': error_kid}, None)

    def acknowledge_error(self, error_kid: str, body: AcknowledgeErrorRequest) -> UnitErrorItem:
        'Acknowledge one error without deleting its log or changing machine status.'
        return self._request('AcknowledgeError', {'errorKid': error_kid}, body)

    def get_hosting_logs(self, *, environment: str | None = None, application: str | None = None) -> HostingLogsResponse:
        'Read recent DigitalOcean runtime logs for a configured shared app.'
        return self._request('GetHostingLogs', {'environment': environment, 'application': application}, None)

    def get_hosting_metrics(self, *, environment: str | None = None, application: str | None = None, hours: int | None = None) -> HostingMetricsResponse:
        'Read hosting metrics for one configured application or Managed MySQL cluster.'
        return self._request('GetHostingMetrics', {'environment': environment, 'application': application, 'hours': hours}, None)

    def set_installer_icon(self, installer_kid: str, body: InstallerIconRequest) -> InstallerIconResponse:
        "Save an installer's selected Person icon."
        return self._request('SetInstallerIcon', {'installerKid': installer_kid}, body)

    def get_installer_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, include_activation_code: bool | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetInstallerExportCount', {'filter': filter, 'sort': sort, 'direction': direction, 'includeActivationCode': include_activation_code}, None)

    def get_installers(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, include_activation_code: bool | None = None) -> InstallerDirectoryResponse:
        'List installers with locations, tags, account state and last activity.'
        return self._request('GetInstallers', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'includeActivationCode': include_activation_code}, None)

    def get_installer(self, installer_kid: str) -> InstallerDetailsResponse:
        'Read one installer and the same Person icon catalog used for administrators.'
        return self._request('GetInstaller', {'installerKid': installer_kid}, None)

    def get_live_logs(self) -> LiveLogsResponse:
        'Read recent live logs from Portal API, Equipment API and Portal Web.'
        return self._request('GetLiveLogs', {}, None)

    def get_active_location_count(self, *, bank_kid: str | None = None) -> ActiveLocationCountResponse:
        'Count accessible active locations for the Locations1 navigation icon.'
        return self._request('GetActiveLocationCount', {'bankKid': bank_kid}, None)

    def get_locations(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, include_coordinates: bool | None = None, bank_kid: str | None = None) -> LocationDirectoryResponse:
        'List accessible locations with parent banks, Visma customer numbers and authorized activation codes.'
        return self._request('GetLocations', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'includeCoordinates': include_coordinates, 'bankKid': bank_kid}, None)

    def get_location_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, bank_kid: str | None = None) -> LocationCountResponse:
        'Count every location matching the same filters, selected search columns and permissions as GetLocations.'
        return self._request('GetLocationCount', {'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'bankKid': bank_kid}, None)

    def search_locations(self, *, q: str | None = None) -> SearchResults:
        'Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24.'
        return self._request('SearchLocations', {'q': q}, None)

    def search_location_activation(self, *, q: str | None = None) -> SearchResults:
        'Decode a location activation code and resolve its visible name and icon in Log24.'
        return self._request('SearchLocationActivation', {'q': q}, None)

    def get_location_booking_calendars(self, location_kid: str, *, accept_language: str | None = None, from_: str | None = None, days: int | None = None) -> LocationBookingCalendarsResponse:
        'Read dated reservation calendars with location opening hours already applied.'
        return self._request('GetLocationBookingCalendars', {'locationKid': location_kid, 'Accept-Language': accept_language, 'from': from_, 'days': days}, None)

    def get_location_booking_rules(self, location_kid: str, *, accept_language: str | None = None) -> LocationBookingRulesResponse:
        "Read localized configured reservation rules for the location's visible units."
        return self._request('GetLocationBookingRules', {'locationKid': location_kid, 'Accept-Language': accept_language}, None)

    def get_controller_overview(self, controller_kid: str, *, accept_language: str | None = None) -> UnitDetailsResponse:
        'Read an authorized controller using its canonical Controller KID with MainId.'
        return self._request('GetControllerOverview', {'controllerKid': controller_kid, 'Accept-Language': accept_language}, None)

    def get_controller_group(self, controller_kid: str, kind: str, group: str, *, accept_language: str | None = None) -> UnitGroupResponse:
        "Read the controller's temporary Core settings or states from its main unit."
        return self._request('GetControllerGroup', {'controllerKid': controller_kid, 'kind': kind, 'group': group, 'Accept-Language': accept_language}, None)

    def get_location_units(self, location_kid: str, *, accept_language: str | None = None) -> LocationUnitsResponse:
        'Get the location label and its units, ordered by unit number.'
        return self._request('GetLocationUnits', {'locationKid': location_kid, 'Accept-Language': accept_language}, None)

    def get_unit_overview(self, unit_kid: str, *, accept_language: str | None = None) -> UnitDetailsResponse:
        "Read an authorized unit and its type's setting/state groups."
        return self._request('GetUnitOverview', {'unitKid': unit_kid, 'Accept-Language': accept_language}, None)

    def get_unit_group(self, unit_kid: str, kind: str, group: str, *, accept_language: str | None = None) -> UnitGroupResponse:
        'Read the declared settings or states in one authorized unit group.'
        return self._request('GetUnitGroup', {'unitKid': unit_kid, 'kind': kind, 'group': group, 'Accept-Language': accept_language}, None)

    def get_unit_setting_history(self, unit_kid: str, group: str, setting: str, *, before_ms2000: int | None = None, limit: int | None = None) -> UnitSettingHistoryResponse:
        'Read a bounded page of changes to one declared unit setting.'
        return self._request('GetUnitSettingHistory', {'unitKid': unit_kid, 'group': group, 'setting': setting, 'beforeMs2000': before_ms2000, 'limit': limit}, None)

    def get_unit_icons(self, *, kid: list[str] | None = None) -> UnitIconsResponse:
        'Resolve up to 32 visible unit icons, adding the online/offline under-icon on demand.'
        return self._request('GetUnitIcons', {'kid': kid}, None)

    def get_location_icons(self, *, kid: list[str] | None = None) -> LocationIconsResponse:
        "Resolve up to 32 visible location icons with their units' combined online/offline status."
        return self._request('GetLocationIcons', {'kid': kid}, None)

    def get_location_opening_hours(self, location_kid: str, *, accept_language: str | None = None) -> LocationOpeningHoursResponse:
        'Read grouped opening hours, upcoming exceptions and the current opening status for a location.'
        return self._request('GetLocationOpeningHours', {'locationKid': location_kid, 'Accept-Language': accept_language}, None)

    def get_location_reservation_history(self, location_kid: str, *, from_: str | None = None, days: int | None = None, accept_language: str | None = None) -> LocationReservationHistoryResponse:
        "Read bank Log5 reservation history for the location's authorized visible units."
        return self._request('GetLocationReservationHistory', {'locationKid': location_kid, 'from': from_, 'days': days, 'Accept-Language': accept_language}, None)

    def get_location_reservations(self, location_kid: str, *, from_: str | None = None, days: int | None = None, accept_language: str | None = None) -> LocationReservationsResponse:
        "Read active tenant Log5 reservations for the location's authorized visible units."
        return self._request('GetLocationReservations', {'locationKid': location_kid, 'from': from_, 'days': days, 'Accept-Language': accept_language}, None)

    def get_location_weather(self, location_kid: str) -> LocationWeatherResponse:
        "Get current weather for the authorized location's stored position or address."
        return self._request('GetLocationWeather', {'locationKid': location_kid}, None)

    def create_manager(self) -> ManagerCreationResponse:
        'Create an empty enabled administrator with a previously unused manager identity.'
        return self._request('CreateManager', {}, None)

    def get_managers(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None) -> ManagerDirectoryResponse:
        "List administrators in the site's eUserId.Managers through ManagersLast range."
        return self._request('GetManagers', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction}, None)

    def invite_manager(self, manager_kid: str, body: ManagerInvitationRequest) -> ManagerInvitationResponse:
        'Send an invitation allowing an existing manager to choose a password.'
        return self._request('InviteManager', {'managerKid': manager_kid}, body)

    def set_manager_kid(self, manager_kid: str, body: ManagerKidChangeRequest) -> ManagerKidChangeResponse:
        'Add or remove a tenant, whole-bank or single-location grant on an administrator.'
        return self._request('SetManagerKid', {'managerKid': manager_kid}, body)

    def request_manager_password_reset(self, body: ManagerForgotPasswordRequest) -> ManagerPasswordResetResponse:
        'Request a manager password reset email.'
        return self._request('RequestManagerPasswordReset', {}, body)

    def reset_manager_password(self, body: ManagerResetPasswordRequest) -> ManagerPasswordResetResponse:
        'Replace a manager password using the emailed recovery token.'
        return self._request('ResetManagerPassword', {}, body)

    def set_manager_permission_role(self, manager_kid: str, body: ManagerPermissionRoleRequest) -> ManagerPermissionRoleResponse:
        'Replace all nine permission categories with a predefined administrator role.'
        return self._request('SetManagerPermissionRole', {'managerKid': manager_kid}, body)

    def set_manager_permission(self, manager_kid: str, resource: str, body: ManagerPermissionChangeRequest) -> ManagerOperationPermissionResponse:
        'Set one administrator permission checkbox, including your own if you are the sole active tenant-wide manager.'
        return self._request('SetManagerPermission', {'managerKid': manager_kid, 'resource': resource}, body)

    def set_manager_profile_field(self, manager_kid: str, field: str, body: ManagerProfileChangeRequest) -> ManagerProfileChangeResponse:
        'Change Name, Organisation, Enabled, Deleted, RetentionDays, Icon or Email on an administrator.'
        return self._request('SetManagerProfileField', {'managerKid': manager_kid, 'field': field}, body)

    def get_manager_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetManagerExportCount', {'filter': filter, 'sort': sort, 'direction': direction}, None)

    def get_manager(self, manager_kid: str) -> ManagerDirectoryItem:
        'Read one administrator by canonical manager KID for a workspace shortcut.'
        return self._request('GetManager', {'managerKid': manager_kid}, None)

    def get_managers_with_same_email(self, manager_kid: str) -> list[ManagerEmailMatch]:
        'List other visible administrators with the same stored email as this manager.'
        return self._request('GetManagersWithSameEmail', {'managerKid': manager_kid}, None)

    def login_manager(self, body: ManagerLoginRequest, *, x_portal_login_client_ip: str | None = None) -> ManagerSessionResponse:
        'Log in with manager email/password or manager username/API key.'
        return self._request('LoginManager', {'X-Portal-Login-Client-IP': x_portal_login_client_ip}, body)

    def renew_manager_session(self) -> ManagerSessionResponse:
        'Renew an unexpired manager session for ten days.'
        return self._request('RenewManagerSession', {}, None)

    def get_current_manager(self) -> ManagerProfileResponse:
        'Get your profile, permitted tabs, bank/location access, and operation permissions.'
        return self._request('GetCurrentManager', {}, None)

    def request_manager_sign_up(self, body: ManagerSignUpRequest) -> PersonalAccountResult:
        'Create a pending manager with a password and queue a manager-bound verification email.'
        return self._request('RequestManagerSignUp', {}, body)

    def confirm_manager_sign_up(self, body: ManagerSignUpConfirmation) -> PersonalAccountResult:
        'Verify the email and activate only the manager already created by self-registration.'
        return self._request('ConfirmManagerSignUp', {}, body)

    def set_manager_tab(self, manager_kid: str, tab_id: int, body: ManagerTabChangeRequest) -> ManagerTabChangeResponse:
        'Assign or remove one available eTab on an administrator.'
        return self._request('SetManagerTab', {'managerKid': manager_kid, 'tabId': tab_id}, body)

    def set_current_manager_theme(self, body: ManagerThemeRequest) -> ManagerThemeResponse:
        'Save your own theme preference.'
        return self._request('SetCurrentManagerTheme', {}, body)

    def get_nearest_locations(self, *, latitude: float | None = None, longitude: float | None = None) -> list[NearestLocationItem]:
        'Get up to ten authorized locations nearest to a supplied position.'
        return self._request('GetNearestLocations', {'latitude': latitude, 'longitude': longitude}, None)

    def get_manager_count(self) -> PeopleDirectoryCount:
        'Count all visible administrators, independently of the current page/filter.'
        return self._request('GetManagerCount', {}, None)

    def get_installer_count(self) -> PeopleDirectoryCount:
        'Count all visible installers, independently of the current page/filter.'
        return self._request('GetInstallerCount', {}, None)

    def get_my_manager_profile(self) -> PersonalManagerProfile:
        'Read your own personal settings and available person icons.'
        return self._request('GetMyManagerProfile', {}, None)

    def get_my_manager_api_key(self) -> PersonalManagerApiKey:
        'Read your own API-key configuration status and revision without exposing credentials.'
        return self._request('GetMyManagerApiKey', {}, None)

    def generate_my_manager_api_key(self, body: PersonalApiKeyRequest) -> PersonalApiKeyResponse:
        'Generate your own API key and commit its hash to eSetting.ApiKeyHash.'
        return self._request('GenerateMyManagerApiKey', {}, body)

    def get_my_manager_tabs(self) -> PersonalManagerTabs:
        'Read your own tab selection, available tabs and editing eligibility.'
        return self._request('GetMyManagerTabs', {}, None)

    def set_my_manager_tab(self, tab_id: int, body: PersonalTabRequest) -> PersonalManagerTabs:
        'Select or deselect one of your own tabs when you have access to all banks.'
        return self._request('SetMyManagerTab', {'tabId': tab_id}, body)

    def set_my_manager_profile_field(self, field: str, body: PersonalProfileRequest) -> PersonalManagerProfile:
        'Save one personal name, organisation, person icon, theme or deleted-record visibility preference.'
        return self._request('SetMyManagerProfileField', {'field': field}, body)

    def request_my_manager_email_verification(self, body: PersonalEmailRequest) -> PersonalAccountResult:
        'Send a verification link to your new email address.'
        return self._request('RequestMyManagerEmailVerification', {}, body)

    def confirm_my_manager_email(self, body: PersonalEmailConfirmation) -> PersonalAccountResult:
        'Confirm the new mailbox with its single-use verification token.'
        return self._request('ConfirmMyManagerEmail', {}, body)

    def change_my_manager_password(self, body: PersonalPasswordRequest) -> PersonalAccountResult:
        'Change your password after reauthentication and repeated new-password entry.'
        return self._request('ChangeMyManagerPassword', {}, body)

    def get_service_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetServiceExportCount', {'filter': filter, 'sort': sort, 'direction': direction}, None)

    def get_services(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None) -> ServiceDirectoryResponse:
        'List concrete service enum identities, including services without saved settings.'
        return self._request('GetServices', {'filter': filter, 'sort': sort, 'direction': direction}, None)

    def get_service_count(self) -> PeopleDirectoryCount:
        'Count the predefined service identities without reading service settings.'
        return self._request('GetServiceCount', {}, None)

    def get_service(self, service_kid: str) -> ServiceDetailsResponse:
        'Read one predefined service, editable metadata and its icon catalog.'
        return self._request('GetService', {'serviceKid': service_kid}, None)

    def set_service_profile_field(self, service_kid: str, field: str, body: ServiceProfileRequest) -> ServiceDetailsResponse:
        'Save one service Name or Icon.'
        return self._request('SetServiceProfileField', {'serviceKid': service_kid, 'field': field}, body)

    def generate_service_api_key(self, service_kid: str, body: ServiceApiKeyRequest) -> ServiceApiKeyResponse:
        'Generate a service API key beginning with kt_ and save its password-compatible hash.'
        return self._request('GenerateServiceApiKey', {'serviceKid': service_kid}, body)

    def get_bank_settlements(self, bank_kid: str, *, before_period: int | None = None) -> SettlementHistoryResponse:
        'Lists 25 closed settlement periods, newest first, and the next scheduled settlement.'
        return self._request('GetBankSettlements', {'bankKid': bank_kid, 'beforePeriod': before_period}, None)

    def get_bank_settlement_period(self, bank_kid: str, period: int) -> SettlementDetailResponse:
        'Reads grouped totals for one period (zero is the provisional current period) and lists available export formats.'
        return self._request('GetBankSettlementPeriod', {'bankKid': bank_kid, 'period': period}, None)

    def get_tenant_status(self, *, limit: int | None = None) -> TenantStatusResponse:
        'List Offline and AutoOutOfOrder alerts, newest first, using parallel lookups.'
        return self._request('GetTenantStatus', {'limit': limit}, None)

    def get_tenant_status_page(self, *, page_size: int | None = None, cursor: str | None = None, offset: int | None = None, anchor: str | None = None) -> TenantStatusPageResponse:
        'Read 25 status rows at a time with next/previous cursors.'
        return self._request('GetTenantStatusPage', {'pageSize': page_size, 'cursor': cursor, 'offset': offset, 'anchor': anchor}, None)

    def convert_tool_time(self, body: ToolTimeRequest) -> ToolTimeResponse:
        'Convert MS2000, MI2000, SS2000, UTC or a local wall time without floating-point integers.'
        return self._request('ConvertToolTime', {}, body)

    def inspect_tool_kid(self, body: ToolKidInspectionRequest) -> ToolKidInspectionResponse:
        'Inspect only the supplied KID with the installed Kombine.Flex.Kid parser.'
        return self._request('InspectToolKid', {}, body)

    def get_unit_documents(self, unit_kid: str, *, sort: str | None = None, direction: str | None = None, offset: int | None = None, limit: int | None = None, search: str | None = None, date: str | None = None) -> UnitDocumentPage:
        'List document identities produced by the selected Unit for WashDoc3.'
        return self._request('GetUnitDocuments', {'unitKid': unit_kid, 'Sort': sort, 'Direction': direction, 'Offset': offset, 'Limit': limit, 'Search': search, 'Date': date}, None)

    def get_unit_documents_count(self, unit_kid: str, *, search: str | None = None, date: str | None = None) -> UnitDocumentCount:
        'Count distinct WashDoc3 document identities for exactly one unit, separately from list loading.'
        return self._request('GetUnitDocumentsCount', {'unitKid': unit_kid, 'Search': search, 'Date': date}, None)

    def get_unit_document_neighbors(self, cycle_kid: str) -> DocumentNeighbors:
        'Find the previous (higher Doc ID) and next (lower Doc ID) existing document for this exact unit.'
        return self._request('GetUnitDocumentNeighbors', {'cycleKid': cycle_kid}, None)

    def get_unit_document_table(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> DocumentTable:
        "Read a document's table as JSON with original values and column metadata."
        return self._request('GetUnitDocumentTable', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_unit_document_html(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> PortalDownload:
        'View a document as a printable HTML table.'
        return self._request('GetUnitDocumentHtml', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_unit_document_svg(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None, width: int | None = None) -> PortalDownload:
        "Render a document's numeric series as an SVG chart, caching completed documents privately."
        return self._request('GetUnitDocumentSvg', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements, 'width': width}, None)

    def get_unit_document_svg2(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> PortalDownload:
        'Render a responsive WashDoc chart with independent text and graph layers.'
        return self._request('GetUnitDocumentSvg2', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_unit_document_graph(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> WashDocChartResponse:
        'Read semantic WashDoc graph JSON for interactive charts and image rendering.'
        return self._request('GetUnitDocumentGraph', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_unit_document_png(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> PortalDownload:
        'Render a document KID as a PNG image with the shared local Chart.js renderer.'
        return self._request('GetUnitDocumentPng', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_unit_document_icon(self, cycle_kid: str, *, states: str | None = None, settings: str | None = None, historical_measurements: bool | None = None) -> PortalDownload:
        'Render the first WashDoc curve as a monochrome line icon.'
        return self._request('GetUnitDocumentIcon', {'cycleKid': cycle_kid, 'States': states, 'Settings': settings, 'HistoricalMeasurements': historical_measurements}, None)

    def get_out_of_order_units(self, *, page_size: int | None = None, cursor: str | None = None) -> OutOfOrderPage:
        'List out-of-order machines, including manual, automatic and repair states.'
        return self._request('GetOutOfOrderUnits', {'pageSize': page_size, 'cursor': cursor}, None)

    def restore_out_of_order_unit(self, unit_kid: str, body: OutOfOrderRestoreRequest) -> OutOfOrderRestoreResponse:
        'Return one out-of-order machine to service by setting OutOfOrder to Enabled (0).'
        return self._request('RestoreOutOfOrderUnit', {'unitKid': unit_kid}, body)

    def get_unit_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, location_kid: str | None = None, terminal_kid: str | None = None, running_only: bool | None = None, auto_out_of_order_only: bool | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetUnitExportCount', {'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'locationKid': location_kid, 'terminalKid': terminal_kid, 'runningOnly': running_only, 'autoOutOfOrderOnly': auto_out_of_order_only}, None)

    def get_terminal_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, location_kid: str | None = None, terminal_kid: str | None = None, running_only: bool | None = None) -> DirectoryExportCountResponse:
        'Count authorized main terminals matching the export filters.'
        return self._request('GetTerminalExportCount', {'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'locationKid': location_kid, 'terminalKid': terminal_kid, 'runningOnly': running_only}, None)

    def get_active_unit_count(self) -> ActiveUnitCountResponse:
        'Count accessible active units for the Units1 navigation icon.'
        return self._request('GetActiveUnitCount', {}, None)

    def get_active_terminal_count(self) -> ActiveUnitCountResponse:
        'Count accessible active terminals for the Terminals1 navigation icon.'
        return self._request('GetActiveTerminalCount', {}, None)

    def get_units(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, include_coordinates: bool | None = None, location_kid: str | None = None, terminal_kid: str | None = None, running_only: bool | None = None, auto_out_of_order_only: bool | None = None) -> UnitDirectoryResponse:
        'List authorized units, including child units, for Units1.'
        return self._request('GetUnits', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'includeCoordinates': include_coordinates, 'locationKid': location_kid, 'terminalKid': terminal_kid, 'runningOnly': running_only, 'autoOutOfOrderOnly': auto_out_of_order_only}, None)

    def get_terminals(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, include_coordinates: bool | None = None, location_kid: str | None = None, terminal_kid: str | None = None, running_only: bool | None = None) -> UnitDirectoryResponse:
        'List authorized main units for Terminals1.'
        return self._request('GetTerminals', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'includeCoordinates': include_coordinates, 'locationKid': location_kid, 'terminalKid': terminal_kid, 'runningOnly': running_only}, None)

    def set_unit_setting(self, unit_kid: str, group: str, setting: str, body: UnitSettingRequest) -> UnitSettingResponse:
        'Save one editable current-unit setting with revision protection.'
        return self._request('SetUnitSetting', {'unitKid': unit_kid, 'group': group, 'setting': setting}, body)

    def get_bank_user_balances(self, bank_kid: str, body: UserBalancesRequest) -> UserBalancesResponse:
        'Read current and previous-period balances for up to 50 residents in one bank.'
        return self._request('GetBankUserBalances', {'bankKid': bank_kid}, body)

    def get_bank_user_number_for_new_user(self, bank_kid: str) -> UserNumberSuggestionResponse:
        "Suggest the next resident number from the bank's first NumberFormats entry and stored NumberFormatUserIndex (default 1)."
        return self._request('GetBankUserNumberForNewUser', {'bankKid': bank_kid}, None)

    def get_bank_next_user_number(self, bank_kid: str, *, user_number: str | None = None) -> UserNumberSuggestionResponse:
        "Suggest the next resident number after userNumber using the bank's first NumberFormats entry."
        return self._request('GetBankNextUserNumber', {'bankKid': bank_kid, 'userNumber': user_number}, None)

    def get_bank_user_workspace(self, bank_kid: str, user_kid: str) -> UserWorkspaceResponse:
        'Read authoritative editing fields and an opaque concurrency revision. Bank-wide Users2/User Read required.'
        return self._request('GetBankUserWorkspace', {'bankKid': bank_kid, 'userKid': user_kid}, None)

    def get_bank_user_activation(self, bank_kid: str, user_kid: str) -> UserActivationResponse:
        'Read the resident activation code for printing. Requires bank-wide Users2/User Create.'
        return self._request('GetBankUserActivation', {'bankKid': bank_kid, 'userKid': user_kid}, None)

    def execute_bank_user_command(self, bank_kid: str, user_kid: str, body: UserCommandRequest) -> UserWorkspaceResponse:
        'Execute profile, icon, attributes, tag, location, delete, restore or replace with the revision from GetBankUserWorkspace.'
        return self._request('ExecuteBankUserCommand', {'bankKid': bank_kid, 'userKid': user_kid}, body)

    def get_user_export_count(self, *, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None) -> DirectoryExportCountResponse:
        'Count the complete filtered export selection using the same directory authorization and visibility.'
        return self._request('GetUserExportCount', {'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only}, None)

    def get_users(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None) -> UserDirectoryResponse:
        'List authorized residents for UserFinder1 (77).'
        return self._request('GetUsers', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only}, None)

    def get_user_count(self) -> PeopleDirectoryCount:
        'Count active authorized residents for the UserFinder1 badge.'
        return self._request('GetUserCount', {}, None)

    def create_user_evaskeri_session(self, user_kid: str) -> UserEvaskeriSession:
        'Create an eVaskeri login link for one active Nortec resident.'
        return self._request('CreateUserEvaskeriSession', {'userKid': user_kid}, None)

    def get_user_receipts(self, user_kid: str, *, offset: int | None = None, revision: str | None = None) -> UserReceiptsResponse:
        'Read complete receipts for one resident, newest first, twenty receipts at a time.'
        return self._request('GetUserReceipts', {'userKid': user_kid, 'offset': offset, 'revision': revision}, None)

    def search_users(self, *, q: str | None = None, kid_only: bool | None = None) -> SearchResults:
        'Search resident Number, Name, Email, SMS and partial numeric TagId using current Log7.'
        return self._request('SearchUsers', {'q': q, 'kidOnly': kid_only}, None)

    def search_user_sms(self, *, q: str | None = None) -> SearchResults:
        'Search complete resident SMS numbers with indexed exact Log7 Text matches.'
        return self._request('SearchUserSms', {'q': q}, None)

    def search_user_activation(self, *, q: str | None = None) -> SearchResults:
        'Decode an ordinary resident activation code and resolve name and icon from current Log7.'
        return self._request('SearchUserActivation', {'q': q}, None)

    def start_wallboard_pairing(self, body: StartWallboardPairing) -> WallboardPairingStarted:
        'Start a five-minute pairing. Keep deviceCode private; show only pairingId in the QR code.'
        return self._request('StartWallboardPairing', {}, body)

    def get_wallboard_pairing(self, pairing_id: str) -> WallboardPairingInfo:
        'Read the screen ID and expiry before explicitly approving its QR code.'
        return self._request('GetWallboardPairing', {'pairingId': pairing_id}, None)

    def approve_wallboard_pairing(self, pairing_id: str) -> None:
        'Approve one screen using your current manager bearer session, including sessions created with kid and apiKey.'
        return self._request('ApproveWallboardPairing', {'pairingId': pairing_id}, None)

    def redeem_wallboard_pairing(self, pairing_id: str, body: RedeemWallboardPairing) -> WallboardPairingToken:
        'Poll with the private deviceCode. Successful redemption consumes the pairing atomically.'
        return self._request('RedeemWallboardPairing', {'pairingId': pairing_id}, body)

    def challenge_wallboard_device(self, device_id: str) -> WallboardDeviceChallenge:
        'Request a two-minute signing challenge for a permanently approved screen.'
        return self._request('ChallengeWallboardDevice', {'deviceId': device_id}, None)

    def resume_wallboard_session(self, device_id: str, body: ResumeWallboardSession) -> WallboardPairingToken:
        'Resume a permanently approved screen after proving possession of its private signing key.'
        return self._request('ResumeWallboardSession', {'deviceId': device_id}, body)

    def revoke_wallboard_device(self, device_id: str) -> None:
        'Revoke a screen you approved. Its existing bearer sessions also lose access.'
        return self._request('RevokeWallboardDevice', {'deviceId': device_id}, None)

    def get_portal_app_download_page(self) -> PortalDownload:
        'Displays Windows downloads for this tenant, or an explicit unavailable state.'
        return self._request('GetPortalAppDownloadPage', {}, None)

    def download_portal_windows_app_installer(self, architecture: str) -> PortalDownload:
        'Downloads a tenant-bound Windows App Installer file with update checks at launch.'
        return self._request('DownloadPortalWindowsAppInstaller', {'architecture': architecture}, None)

    def download_portal_windows_package(self, architecture: str, file_name: str) -> PortalDownload:
        'Downloads an immutable signed Windows package, with byte-range and conditional request support.'
        return self._request('DownloadPortalWindowsPackage', {'architecture': architecture, 'fileName': file_name}, None)

    def get_circle_gradient(self, colors: str) -> PortalDownload:
        'Renders an angular color-gradient background at 200 × 200 pixels.'
        return self._request('GetCircleGradient', {'colors': colors}, None)

    def get_circle_gradient_sized(self, colors: str, width: int, height: int) -> PortalDownload:
        'Renders an angular gradient at a selected width and height.'
        return self._request('GetCircleGradientSized', {'colors': colors, 'width': width, 'height': height}, None)

    def get_circle_progress(self, background: str, colors: str, percent: int) -> PortalDownload:
        'Renders a progress circle with one square mark per percentage point.'
        return self._request('GetCircleProgress', {'background': background, 'colors': colors, 'percent': percent}, None)

    def get_circle_progress_sized(self, background: str, colors: str, percent: int, width: int, height: int) -> PortalDownload:
        'Renders a progress circle at a selected width and height.'
        return self._request('GetCircleProgressSized', {'background': background, 'colors': colors, 'percent': percent, 'width': width, 'height': height}, None)

    def get_circle_running(self, color: str) -> PortalDownload:
        'Renders a rotating semicircle to indicate running or indeterminate progress.'
        return self._request('GetCircleRunning', {'color': color}, None)

    def get_circle_running_sized(self, color: str, width: int, height: int) -> PortalDownload:
        'Renders a running indicator at a selected width and height.'
        return self._request('GetCircleRunningSized', {'color': color, 'width': width, 'height': height}, None)

    def get_linear_gradient(self, colors: str, angle: float) -> PortalDownload:
        'Renders a linear gradient at 200 × 200 pixels.'
        return self._request('GetLinearGradient', {'colors': colors, 'angle': angle}, None)

    def get_linear_gradient_sized(self, colors: str, angle: float, width: int, height: int) -> PortalDownload:
        'Renders a linear gradient at a selected width and height.'
        return self._request('GetLinearGradientSized', {'colors': colors, 'angle': angle, 'width': width, 'height': height}, None)

    def get_icon_presentation(self, *, icon_kid: str | None = None, text: str | None = None, count: int | None = None, color: int | None = None) -> IconPresentationResponse:
        'Resolve an IconKid, optionally changing its text, count or RGB colour.'
        return self._request('GetIconPresentation', {'iconKid': icon_kid, 'text': text, 'count': count, 'color': color}, None)

    def get_icon_asset_catalog(self, icon_set: str) -> list[str]:
        'Lists canonical icon names with an asset in the requested local set.'
        return self._request('GetIconAssetCatalog', {'iconSet': icon_set}, None)

    def get_icon_from_set(self, icon_set: str, kid: str, format: str) -> PortalDownload:
        'Renders Kid.Icon from a named local asset set, with Kid.Count as the badge.'
        return self._request('GetIconFromSet', {'iconSet': icon_set, 'kid': kid, 'format': format}, None)

    def get_icon_image_from_set(self, icon_set: str, kid: str, size: int, format: str) -> PortalDownload:
        'Renders Kid.Icon and Kid.Count from a named set at a square pixel size.'
        return self._request('GetIconImageFromSet', {'iconSet': icon_set, 'kid': kid, 'size': size, 'format': format}, None)

    def get_icon_image_with_background_from_set(self, icon_set: str, kid: str, back_color: str, size: int, format: str) -> PortalDownload:
        'Renders Kid.Icon and Kid.Count from a named set with a raster background.'
        return self._request('GetIconImageWithBackgroundFromSet', {'iconSet': icon_set, 'kid': kid, 'backColor': back_color, 'size': size, 'format': format}, None)

    def get_kombine_logo(self, color: str) -> PortalDownload:
        'Renders a responsive Kombine symbol that fits its viewport without stretching.'
        return self._request('GetKombineLogo', {'color': color}, None)

    def get_kombine_logo_sized(self, color: str, width: int) -> PortalDownload:
        'Renders the square Kombine symbol at the selected width.'
        return self._request('GetKombineLogoSized', {'color': color, 'width': width}, None)

    def get_kombine_logo_with_background(self, color: str, background: str, width: int) -> PortalDownload:
        'Renders the Kombine symbol with an explicit background and width.'
        return self._request('GetKombineLogoWithBackground', {'color': color, 'background': background, 'width': width}, None)

    def get_kombine_logo_parts(self, parts: str, color: str) -> PortalDownload:
        'Renders selected parts of the Kombine symbol in its original square viewport.'
        return self._request('GetKombineLogoParts', {'parts': parts, 'color': color}, None)

    def get_kombine_logo_parts_sized(self, parts: str, color: str, width: int) -> PortalDownload:
        'Renders selected Kombine symbol parts at the selected width.'
        return self._request('GetKombineLogoPartsSized', {'parts': parts, 'color': color, 'width': width}, None)

    def get_kombine_logo_parts_with_background(self, parts: str, color: str, background: str, width: int) -> PortalDownload:
        'Renders selected Kombine symbol parts with an explicit background and width.'
        return self._request('GetKombineLogoPartsWithBackground', {'parts': parts, 'color': color, 'background': background, 'width': width}, None)

    def get_kombine_text(self, color: str) -> PortalDownload:
        'Renders the Kombine name and registered mark, without the symbol.'
        return self._request('GetKombineText', {'color': color}, None)

    def get_kombine_text_sized(self, color: str, width: int) -> PortalDownload:
        'Renders the Kombine wordmark at the selected width.'
        return self._request('GetKombineTextSized', {'color': color, 'width': width}, None)

    def get_kombine_text_with_background(self, color: str, background: str, width: int) -> PortalDownload:
        'Renders the Kombine wordmark with an explicit background and width.'
        return self._request('GetKombineTextWithBackground', {'color': color, 'background': background, 'width': width}, None)

    def get_kombine_logo_text(self, color: str) -> PortalDownload:
        'Renders the Kombine symbol and name together.'
        return self._request('GetKombineLogoText', {'color': color}, None)

    def get_kombine_logo_text_sized(self, color: str, width: int) -> PortalDownload:
        'Renders the combined Kombine logo at the selected width.'
        return self._request('GetKombineLogoTextSized', {'color': color, 'width': width}, None)

    def get_kombine_logo_text_with_background(self, color: str, background: str, width: int) -> PortalDownload:
        'Renders the combined Kombine logo with an explicit background and width.'
        return self._request('GetKombineLogoTextWithBackground', {'color': color, 'background': background, 'width': width}, None)

    def get_cycle_chart_presentation(self) -> CycleChartPresentationResponse:
        "Get the portal chart's localized messages and stable state identifiers."
        return self._request('GetCycleChartPresentation', {}, None)

    def get_public_live_machines(self) -> list[LiveMachineResponse]:
        "Returns the site overview's running-machine pool, refreshed at most once a minute."
        return self._request('GetPublicLiveMachines', {}, None)

    def get_public_machine_errors(self, *, page_size: int | None = None, cursor: str | None = None) -> PublicMachineErrorsPage:
        'List machines with a positive AutoOutOfOrder Id without login.'
        return self._request('GetPublicMachineErrors', {'pageSize': page_size, 'cursor': cursor}, None)

    def get_public_recent_camera_photos(self) -> list[PublicCameraPhoto]:
        'Get the ten newest photos, including Live Photo stills, newest first.'
        return self._request('GetPublicRecentCameraPhotos', {}, None)

    def get_public_camera_thumbnail(self, id: str) -> PortalDownload:
        'Read only the JPEG thumbnail authorized by a ten-minute, tenant-bound public ticket.'
        return self._request('GetPublicCameraThumbnail', {'id': id}, None)

    def get_public_cycle_widget(self, *, cycle_kid: str | None = None, unit_kid: str | None = None) -> PublicCycleWidgetResponse:
        "Get a square WashDoc widget's graph, machine/location names and document times."
        return self._request('GetPublicCycleWidget', {'cycleKid': cycle_kid, 'unitKid': unit_kid}, None)

    def get_public_purchases_chart(self, color: str) -> PortalDownload:
        'Draws purchase counts for the last hour in twelve five-minute intervals.'
        return self._request('GetPublicPurchasesChart', {'color': color}, None)

    def get_public_disp73(self, *, limit: int | None = None) -> PurchaseMapSnapshot:
        'Shows recent purchases as coin markers on a map. No login required.'
        return self._request('GetPublicDisp73', {'limit': limit}, None)

    def get_public_scoped_unit_progress(self, kid: str, *, page_size: int | None = None, cursor: str | None = None) -> PublicScopedProgressResponse:
        'Get progress for one unit or a page of all public units in a location or bank.'
        return self._request('GetPublicScopedUnitProgress', {'kid': kid, 'pageSize': page_size, 'cursor': cursor}, None)

    def get_public_purchases(self) -> PurchasesResponse:
        "Counts purchases in the site's Log1Hour without login."
        return self._request('GetPublicPurchases', {}, None)

    def get_public_active_users(self) -> ActiveUsersResponse:
        "Counts active users in the site's current Log7 during the last 100 days, without login."
        return self._request('GetPublicActiveUsers', {}, None)

    def get_public_widget_presentation(self) -> PublicWidgetPresentationResponse:
        "Get localized labels and the site's palette for the shared JavaScript widgets."
        return self._request('GetPublicWidgetPresentation', {}, None)

    def get_public_reservations(self) -> ReservationsStatisticsResponse:
        'Counts noncancelled dated reservations that have not ended, including ongoing reservations.'
        return self._request('GetPublicReservations', {}, None)

    def get_public_running_machines(self) -> RunningMachinesResponse:
        'Counts machines whose current Started is before now and Done is after now.'
        return self._request('GetPublicRunningMachines', {}, None)

    def get_portal_status(self) -> ApiStatusResponse:
        'Gets public API availability. This does not check database readiness.'
        return self._request('GetPortalStatus', {}, None)
