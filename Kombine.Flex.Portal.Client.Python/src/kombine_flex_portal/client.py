"""Generated operations; regenerate with scripts/Generate-PortalScriptClients.py."""
from __future__ import annotations
from typing import Any
from .models import *
from ._runtime import BaseClient, PortalDownload


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

    def get_banks(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, bank_type: str | None = None) -> BankDirectoryResponse:
        'List authorized bank identities for Banks2 with selected metadata and stable global ordering.'
        return self._request('GetBanks', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'bankType': bank_type}, None)

    def get_active_bank_count(self) -> ActiveBankCountResponse:
        'Count accessible active banks for the Banks2 navigation icon.'
        return self._request('GetActiveBankCount', {}, None)

    def get_bank_documents(self, bank_kid: str, *, location_kid: str | None = None, unit_kid: str | None = None, from_: str | None = None, through: str | None = None, offset: int | None = None, limit: int | None = None) -> BankDocumentPage:
        'Search WashDoc document identities by location, unit and time without loading measurements.'
        return self._request('GetBankDocuments', {'bankKid': bank_kid, 'LocationKid': location_kid, 'UnitKid': unit_kid, 'From': from_, 'Through': through, 'Offset': offset, 'Limit': limit}, None)

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

    def export_bank_account(self, bank_kid: str, *, from_: str | None = None, through: str | None = None, time_zone: str | None = None, period: int | None = None, location_kid: str | None = None, unit_kid: str | None = None, user_kid: str | None = None, kind: str | None = None, include_zero: bool | None = None, include_bookings: bool | None = None, include_monthly: bool | None = None, offset: int | None = None, limit: int | None = None, format: str | None = None) -> PortalDownload:
        'Downloads the complete filtered selection as CSV or a genuine Excel workbook.'
        return self._request('ExportBankAccount', {'bankKid': bank_kid, 'From': from_, 'Through': through, 'TimeZone': time_zone, 'Period': period, 'LocationKid': location_kid, 'UnitKid': unit_kid, 'UserKid': user_kid, 'Kind': kind, 'IncludeZero': include_zero, 'IncludeBookings': include_bookings, 'IncludeMonthly': include_monthly, 'Offset': offset, 'Limit': limit, 'format': format}, None)

    def export_bank_users(self, bank_kid: str, *, filter: str | None = None, location_kid: str | None = None, deleted: str | None = None, sort: str | None = None, direction: str | None = None) -> PortalDownload:
        'Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text.'
        return self._request('ExportBankUsers', {'bankKid': bank_kid, 'filter': filter, 'locationKid': location_kid, 'deleted': deleted, 'sort': sort, 'direction': direction}, None)

    def download_bank_settlement(self, bank_kid: str, period: int, *, format: str | None = None) -> PortalDownload:
        'Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest.'
        return self._request('DownloadBankSettlement', {'bankKid': bank_kid, 'period': period, 'format': format}, None)

    def download_unit_document_csv(self, document_kid: str, *, states: str | None = None, settings: str | None = None) -> PortalDownload:
        'Download a UTF-8 CSV table for one document.'
        return self._request('DownloadUnitDocumentCsv', {'documentKid': document_kid, 'States': states, 'Settings': settings}, None)

    def download_unit_document_xls(self, document_kid: str, *, states: str | None = None, settings: str | None = None) -> PortalDownload:
        'Download an Excel 97–2003 binary .xls workbook for one document.'
        return self._request('DownloadUnitDocumentXls', {'documentKid': document_kid, 'States': states, 'Settings': settings}, None)

    def get_hosting_logs(self, *, environment: str | None = None, application: str | None = None) -> HostingLogsResponse:
        'Read recent DigitalOcean runtime logs for a configured shared app.'
        return self._request('GetHostingLogs', {'environment': environment, 'application': application}, None)

    def get_hosting_metrics(self, *, environment: str | None = None, application: str | None = None, hours: int | None = None) -> HostingMetricsResponse:
        'Read hosting metrics for one configured application or Managed MySQL cluster.'
        return self._request('GetHostingMetrics', {'environment': environment, 'application': application, 'hours': hours}, None)

    def set_installer_icon(self, installer_kid: str, body: InstallerIconRequest) -> InstallerIconResponse:
        "Save an installer's selected Person icon."
        return self._request('SetInstallerIcon', {'installerKid': installer_kid}, body)

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

    def search_locations(self, *, q: str | None = None) -> SearchResults:
        'Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24.'
        return self._request('SearchLocations', {'q': q}, None)

    def search_location_activation(self, *, q: str | None = None) -> SearchResults:
        'Decode a location activation code and resolve its visible name and icon in Log24.'
        return self._request('SearchLocationActivation', {'q': q}, None)

    def get_location_booking_rules(self, location_kid: str, *, accept_language: str | None = None) -> LocationBookingRulesResponse:
        "Read localized configured reservation rules for the location's visible units."
        return self._request('GetLocationBookingRules', {'locationKid': location_kid, 'Accept-Language': accept_language}, None)

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

    def get_manager(self, manager_kid: str) -> ManagerDirectoryItem:
        'Read one administrator by canonical manager KID for a workspace shortcut.'
        return self._request('GetManager', {'managerKid': manager_kid}, None)

    def get_managers_with_same_email(self, manager_kid: str) -> list[ManagerEmailMatch]:
        'List other visible administrators with the same stored email as this manager.'
        return self._request('GetManagersWithSameEmail', {'managerKid': manager_kid}, None)

    def login_manager(self, body: ManagerLoginRequest, *, x_portal_login_client_ip: str | None = None) -> ManagerSessionResponse:
        'Log in with a manager email and password.'
        return self._request('LoginManager', {'X-Portal-Login-Client-IP': x_portal_login_client_ip}, body)

    def renew_manager_session(self) -> ManagerSessionResponse:
        'Renew an unexpired manager session for three days.'
        return self._request('RenewManagerSession', {}, None)

    def get_current_manager(self) -> ManagerProfileResponse:
        'Get your profile, permitted tabs, bank/location access, and operation permissions.'
        return self._request('GetCurrentManager', {}, None)

    def set_manager_tab(self, manager_kid: str, tab_id: int, body: ManagerTabChangeRequest) -> ManagerTabChangeResponse:
        'Assign or remove one available eTab on an administrator.'
        return self._request('SetManagerTab', {'managerKid': manager_kid, 'tabId': tab_id}, body)

    def set_current_manager_theme(self, body: ManagerThemeRequest) -> ManagerThemeResponse:
        'Save your own theme preference.'
        return self._request('SetCurrentManagerTheme', {}, body)

    def get_manager_count(self) -> PeopleDirectoryCount:
        'Count all visible administrators, independently of the current page/filter.'
        return self._request('GetManagerCount', {}, None)

    def get_installer_count(self) -> PeopleDirectoryCount:
        'Count all visible installers, independently of the current page/filter.'
        return self._request('GetInstallerCount', {}, None)

    def get_my_manager_profile(self) -> PersonalManagerProfile:
        'Read your own personal settings and available person icons.'
        return self._request('GetMyManagerProfile', {}, None)

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

    def get_unit_document_table(self, document_kid: str, *, states: str | None = None, settings: str | None = None) -> DocumentTable:
        "Read a document's table as JSON with original values and column metadata."
        return self._request('GetUnitDocumentTable', {'documentKid': document_kid, 'States': states, 'Settings': settings}, None)

    def get_unit_document_html(self, document_kid: str, *, states: str | None = None, settings: str | None = None) -> PortalDownload:
        'View a document as a printable HTML table.'
        return self._request('GetUnitDocumentHtml', {'documentKid': document_kid, 'States': states, 'Settings': settings}, None)

    def get_unit_document_svg(self, document_kid: str, *, states: str | None = None, settings: str | None = None, width: int | None = None) -> PortalDownload:
        "Render a document's numeric series as an SVG chart, caching completed documents privately."
        return self._request('GetUnitDocumentSvg', {'documentKid': document_kid, 'States': states, 'Settings': settings, 'width': width}, None)

    def get_active_unit_count(self) -> ActiveUnitCountResponse:
        'Count accessible active units for the Units1 navigation icon.'
        return self._request('GetActiveUnitCount', {}, None)

    def get_active_terminal_count(self) -> ActiveUnitCountResponse:
        'Count accessible active terminals for the Terminals1 navigation icon.'
        return self._request('GetActiveTerminalCount', {}, None)

    def get_units(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, include_coordinates: bool | None = None, location_kid: str | None = None, terminal_kid: str | None = None) -> UnitDirectoryResponse:
        'List authorized units, including child units, for Units1.'
        return self._request('GetUnits', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'includeCoordinates': include_coordinates, 'locationKid': location_kid, 'terminalKid': terminal_kid}, None)

    def get_terminals(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None, fields: str | None = None, include_coordinates: bool | None = None, location_kid: str | None = None, terminal_kid: str | None = None) -> UnitDirectoryResponse:
        'List authorized main units for Terminals1.'
        return self._request('GetTerminals', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only, 'fields': fields, 'includeCoordinates': include_coordinates, 'locationKid': location_kid, 'terminalKid': terminal_kid}, None)

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

    def get_users(self, *, page_size: int | None = None, cursor: str | None = None, filter: str | None = None, sort: str | None = None, direction: str | None = None, enabled_only: bool | None = None) -> UserDirectoryResponse:
        'List authorized residents for UserFinder1 (77).'
        return self._request('GetUsers', {'pageSize': page_size, 'cursor': cursor, 'filter': filter, 'sort': sort, 'direction': direction, 'enabledOnly': enabled_only}, None)

    def get_user_count(self) -> PeopleDirectoryCount:
        'Count active authorized residents for the UserFinder1 badge.'
        return self._request('GetUserCount', {}, None)

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

    def get_public_disp73(self, *, limit: int | None = None) -> PurchaseMapSnapshot:
        'Shows recent purchases as coin markers on a map. No login required.'
        return self._request('GetPublicDisp73', {'limit': limit}, None)

    def get_public_purchases(self) -> PurchasesResponse:
        "Counts purchases in the site's Log1Hour without login."
        return self._request('GetPublicPurchases', {}, None)

    def get_public_active_users(self) -> ActiveUsersResponse:
        "Counts active users in the site's current Log7 during the last 100 days, without login."
        return self._request('GetPublicActiveUsers', {}, None)

    def get_portal_status(self) -> ApiStatusResponse:
        'Gets public API availability. This does not check database readiness.'
        return self._request('GetPortalStatus', {}, None)
