// Generated from the public OpenAPI snapshot. Regenerate with scripts/Generate-PortalClientNet20.py.
using System;
using System.Collections.Generic;

namespace Kombine.Flex.Portal.Client.Net20
{
    /// <summary>Synchronous public integration operations. Authorization and business rules remain in the API.</summary>
    public sealed partial class PortalApiClient
    {
        /// <summary>Resolve the Forbrug icon text from the most frequent authorized Log1 currency.</summary>
        public AccountIconResponse GetBankAccountIcon(string @bankKid)
        {
            string path = "api/v1/banks/{bankKid}/account/icon";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (AccountIconResponse)SendJson("GET", path, null, headers, 200, typeof(AccountIconResponse));
        }

        /// <summary>Lists Account2 postings with full-selection totals per currency.</summary>
        public AccountResponse GetBankAccount(string @bankKid)
        {
            return GetBankAccount(@bankKid, null);
        }

        /// <summary>Lists Account2 postings with full-selection totals per currency.</summary>
        public AccountResponse GetBankAccount(string @bankKid, GetBankAccountOptions options)
        {
            string path = "api/v1/banks/{bankKid}/account";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "TimeZone", options.TimeZone);
                path = AddQuery(path, "Period", options.Period);
                path = AddQuery(path, "LocationKid", options.LocationKid);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "UserKid", options.UserKid);
                path = AddQuery(path, "Kind", options.Kind);
                path = AddQuery(path, "IncludeZero", options.IncludeZero);
                path = AddQuery(path, "IncludeBookings", options.IncludeBookings);
                path = AddQuery(path, "IncludeMonthly", options.IncludeMonthly);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
            }
            return (AccountResponse)SendJson("GET", path, null, headers, 200, typeof(AccountResponse));
        }

        /// <summary>Checks whether filtered Account2 postings changed, including late arrivals with old event timestamps.</summary>
        public AccountRevisionResponse GetBankAccountRevision(string @bankKid)
        {
            return GetBankAccountRevision(@bankKid, null);
        }

        /// <summary>Checks whether filtered Account2 postings changed, including late arrivals with old event timestamps.</summary>
        public AccountRevisionResponse GetBankAccountRevision(string @bankKid, GetBankAccountRevisionOptions options)
        {
            string path = "api/v1/banks/{bankKid}/account/revision";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "TimeZone", options.TimeZone);
                path = AddQuery(path, "Period", options.Period);
                path = AddQuery(path, "LocationKid", options.LocationKid);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "UserKid", options.UserKid);
                path = AddQuery(path, "Kind", options.Kind);
                path = AddQuery(path, "IncludeZero", options.IncludeZero);
                path = AddQuery(path, "IncludeBookings", options.IncludeBookings);
                path = AddQuery(path, "IncludeMonthly", options.IncludeMonthly);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
            }
            return (AccountRevisionResponse)SendJson("GET", path, null, headers, 200, typeof(AccountRevisionResponse));
        }

        /// <summary>Reverses one eligible resident consumption posting by appending a linked compensation.</summary>
        public AccountEntryResponse ReverseBankAccountEntry(string @bankKid, string @transactionKid)
        {
            string path = "api/v1/banks/{bankKid}/account/{transactionKid}/reversal";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{transactionKid}", PathValue(@transactionKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (AccountEntryResponse)SendJson("POST", path, null, headers, 200, typeof(AccountEntryResponse));
        }

        /// <summary>Read the object's own address, coordinate pair, provenance and concurrency revision.</summary>
        public ObjectAddressResponse GetObjectAddress(string @kid)
        {
            string path = "api/v1/addresses/{kid}";
            path = path.Replace("{kid}", PathValue(@kid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ObjectAddressResponse)SendJson("GET", path, null, headers, 200, typeof(ObjectAddressResponse));
        }

        /// <summary>Save Address and Zip together and resolve automatic coordinates once if either field changes.</summary>
        public ObjectAddressResponse UpdateObjectAddress(string @kid, UpdateObjectAddressRequest body)
        {
            string path = "api/v1/addresses/{kid}";
            path = path.Replace("{kid}", PathValue(@kid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ObjectAddressResponse)SendJson("PUT", path, body, headers, 200, typeof(ObjectAddressResponse));
        }

        /// <summary>Explicitly look up the current address, replacing manual coordinates only on success.</summary>
        public ObjectAddressResponse LookupObjectCoordinates(string @kid, ObjectAddressRevisionRequest body)
        {
            string path = "api/v1/addresses/{kid}/lookup";
            path = path.Replace("{kid}", PathValue(@kid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ObjectAddressResponse)SendJson("POST", path, body, headers, 200, typeof(ObjectAddressResponse));
        }

        /// <summary>Save manual Latitude and Longitude atomically with AutoLatitudeLongitude=30.</summary>
        public ObjectAddressResponse SetObjectCoordinates(string @kid, SetObjectCoordinatesRequest body)
        {
            string path = "api/v1/addresses/{kid}/coordinates";
            path = path.Replace("{kid}", PathValue(@kid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ObjectAddressResponse)SendJson("PUT", path, body, headers, 200, typeof(ObjectAddressResponse));
        }

        /// <summary>Change AutoLatitudeLongitude without changing the coordinate pair or making a Google request.</summary>
        public ObjectAddressResponse SetObjectCoordinateProvenance(string @kid, SetObjectCoordinateProvenanceRequest body)
        {
            string path = "api/v1/addresses/{kid}/provenance";
            path = path.Replace("{kid}", PathValue(@kid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ObjectAddressResponse)SendJson("PUT", path, body, headers, 200, typeof(ObjectAddressResponse));
        }

        /// <summary>Ask the portal assistant to discover and combine approved read operations.</summary>
        public AssistantResponse AskPortalAssistant(AssistantRequest body)
        {
            string path = "api/v1/assistant/query";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (AssistantResponse)SendJson("POST", path, body, headers, 200, typeof(AssistantResponse));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetBankExportCount()
        {
            return GetBankExportCount(null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetBankExportCount(GetBankExportCountOptions options)
        {
            string path = "api/v1/banks/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "bankType", options.BankType);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>List authorized bank identities for Banks2 with selected metadata and stable global ordering.</summary>
        public BankDirectoryResponse GetBanks()
        {
            return GetBanks(null);
        }

        /// <summary>List authorized bank identities for Banks2 with selected metadata and stable global ordering.</summary>
        public BankDirectoryResponse GetBanks(GetBanksOptions options)
        {
            string path = "api/v1/banks";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "bankType", options.BankType);
            }
            return (BankDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(BankDirectoryResponse));
        }

        /// <summary>Count accessible active banks for the Banks2 navigation icon.</summary>
        public ActiveBankCountResponse GetActiveBankCount()
        {
            string path = "api/v1/banks/active-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ActiveBankCountResponse)SendJson("GET", path, null, headers, 200, typeof(ActiveBankCountResponse));
        }

        /// <summary>Search WashDoc document identities by location, unit and time without loading measurements.</summary>
        public BankDocumentPage GetBankDocuments(string @bankKid)
        {
            return GetBankDocuments(@bankKid, null);
        }

        /// <summary>Search WashDoc document identities by location, unit and time without loading measurements.</summary>
        public BankDocumentPage GetBankDocuments(string @bankKid, GetBankDocumentsOptions options)
        {
            string path = "api/v1/banks/{bankKid}/documents";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "LocationKid", options.LocationKid);
                path = AddQuery(path, "Date", options.Date);
                path = AddQuery(path, "Search", options.Search);
                path = AddQuery(path, "UnitKids", options.UnitKids);
                path = AddQuery(path, "Sort", options.Sort);
                path = AddQuery(path, "Direction", options.Direction);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
            }
            return (BankDocumentPage)SendJson("GET", path, null, headers, 200, typeof(BankDocumentPage));
        }

        /// <summary>Count WashDocs across the authorized bank scope, without loading document pages or measurements.</summary>
        public UnitDocumentCount GetBankDocumentsCount(string @bankKid)
        {
            return GetBankDocumentsCount(@bankKid, null);
        }

        /// <summary>Count WashDocs across the authorized bank scope, without loading document pages or measurements.</summary>
        public UnitDocumentCount GetBankDocumentsCount(string @bankKid, GetBankDocumentsCountOptions options)
        {
            string path = "api/v1/banks/{bankKid}/documents/count";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "LocationKid", options.LocationKid);
                path = AddQuery(path, "Date", options.Date);
                path = AddQuery(path, "Search", options.Search);
                path = AddQuery(path, "UnitKids", options.UnitKids);
                path = AddQuery(path, "Sort", options.Sort);
                path = AddQuery(path, "Direction", options.Direction);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
            }
            return (UnitDocumentCount)SendJson("GET", path, null, headers, 200, typeof(UnitDocumentCount));
        }

        /// <summary>List WashDocs for one authorized location, optionally selecting one or several units.</summary>
        public BankDocumentPage GetLocationDocuments(string @locationKid)
        {
            return GetLocationDocuments(@locationKid, null);
        }

        /// <summary>List WashDocs for one authorized location, optionally selecting one or several units.</summary>
        public BankDocumentPage GetLocationDocuments(string @locationKid, GetLocationDocumentsOptions options)
        {
            string path = "api/v1/locations/{locationKid}/documents";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "Date", options.Date);
                path = AddQuery(path, "Search", options.Search);
                path = AddQuery(path, "UnitKids", options.UnitKids);
                path = AddQuery(path, "Sort", options.Sort);
                path = AddQuery(path, "Direction", options.Direction);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
            }
            return (BankDocumentPage)SendJson("GET", path, null, headers, 200, typeof(BankDocumentPage));
        }

        /// <summary>Count distinct WashDocs for the selected location and unit choices.</summary>
        public UnitDocumentCount GetLocationDocumentsCount(string @locationKid)
        {
            return GetLocationDocumentsCount(@locationKid, null);
        }

        /// <summary>Count distinct WashDocs for the selected location and unit choices.</summary>
        public UnitDocumentCount GetLocationDocumentsCount(string @locationKid, GetLocationDocumentsCountOptions options)
        {
            string path = "api/v1/locations/{locationKid}/documents/count";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "Date", options.Date);
                path = AddQuery(path, "Search", options.Search);
                path = AddQuery(path, "UnitKids", options.UnitKids);
                path = AddQuery(path, "Sort", options.Sort);
                path = AddQuery(path, "Direction", options.Direction);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
            }
            return (UnitDocumentCount)SendJson("GET", path, null, headers, 200, typeof(UnitDocumentCount));
        }

        /// <summary>Resolve up to eight bank icons with their authorized units' combined status.</summary>
        public BankIconsResponse GetBankIcons()
        {
            return GetBankIcons(null);
        }

        /// <summary>Resolve up to eight bank icons with their authorized units' combined status.</summary>
        public BankIconsResponse GetBankIcons(GetBankIconsOptions options)
        {
            string path = "api/v1/banks/icons";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "kid", options.Kid);
            }
            return (BankIconsResponse)SendJson("GET", path, null, headers, 200, typeof(BankIconsResponse));
        }

        /// <summary>List location names, icons, status and canonical KIDs in bank overview order (location number).</summary>
        public BankLocationStatusResponse[] GetBankLocations(string @bankKid)
        {
            string path = "api/v1/banks/{bankKid}/locations";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (BankLocationStatusResponse[])SendJson("GET", path, null, headers, 200, typeof(BankLocationStatusResponse[]));
        }

        /// <summary>Search current bank names and settlement emails; literal case-insensitive substring matching.</summary>
        public SearchResults SearchBanks()
        {
            return SearchBanks(null);
        }

        /// <summary>Search current bank names and settlement emails; literal case-insensitive substring matching.</summary>
        public SearchResults SearchBanks(SearchBanksOptions options)
        {
            string path = "api/v1/search/banks";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Decode a bank activation code and resolve its name and icon from the cached Log24 bank catalogue.</summary>
        public SearchResults SearchBankActivation()
        {
            return SearchBankActivation(null);
        }

        /// <summary>Decode a bank activation code and resolve its name and icon from the cached Log24 bank catalogue.</summary>
        public SearchResults SearchBankActivation(SearchBankActivationOptions options)
        {
            string path = "api/v1/search/bank-activation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Resolve a search result before opening its bank overview, including tenant-wide managers.</summary>
        public SearchResults GetSearchBank(string @bankKid)
        {
            string path = "api/v1/search/banks/{bankKid}";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetBankUserExportCount(string @bankKid)
        {
            return GetBankUserExportCount(@bankKid, null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetBankUserExportCount(string @bankKid, GetBankUserExportCountOptions options)
        {
            string path = "api/v1/banks/{bankKid}/users/export-count";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "deleted", options.Deleted);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>Read one page of users for a bank.</summary>
        public BankUsersResponse GetBankUsers(string @bankKid)
        {
            return GetBankUsers(@bankKid, null);
        }

        /// <summary>Read one page of users for a bank.</summary>
        public BankUsersResponse GetBankUsers(string @bankKid, GetBankUsersOptions options)
        {
            string path = "api/v1/banks/{bankKid}/users";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "userKid", options.UserKid);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "deleted", options.Deleted);
            }
            return (BankUsersResponse)SendJson("GET", path, null, headers, 200, typeof(BankUsersResponse));
        }

        /// <summary>Create a resident. Requires bank-wide Users2/User Create. Action must be create. No hardware access is assigned automatically.</summary>
        public UserWorkspaceResponse CreateBankUser(string @bankKid, UserCommandRequest body)
        {
            string path = "api/v1/banks/{bankKid}/users";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserWorkspaceResponse)SendJson("POST", path, body, headers, 201, typeof(UserWorkspaceResponse));
        }

        /// <summary>Lists the latest nonsuperseded Log5 event for each location/unit/resident/start.</summary>
        public BookingsResponse GetBankBookings(string @bankKid)
        {
            return GetBankBookings(@bankKid, null);
        }

        /// <summary>Lists the latest nonsuperseded Log5 event for each location/unit/resident/start.</summary>
        public BookingsResponse GetBankBookings(string @bankKid, GetBankBookingsOptions options)
        {
            string path = "api/v1/banks/{bankKid}/bookings";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "from", options.From);
                path = AddQuery(path, "through", options.Through);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "unitKid", options.UnitKid);
                path = AddQuery(path, "userKid", options.UserKid);
                path = AddQuery(path, "status", options.Status);
                path = AddQuery(path, "search", options.Search);
                path = AddQuery(path, "offset", options.Offset);
                path = AddQuery(path, "limit", options.Limit);
            }
            return (BookingsResponse)SendJson("GET", path, null, headers, 200, typeof(BookingsResponse));
        }

        /// <summary>Appends a cancellation or restoration, preserving history and requesting backend synchronization.</summary>
        public BookingResponse ExecuteBankBookingCommand(string @bankKid, string @bookingKid, BookingCommand body)
        {
            string path = "api/v1/banks/{bankKid}/bookings/{bookingKid}/commands";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{bookingKid}", PathValue(@bookingKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (BookingResponse)SendJson("POST", path, body, headers, 200, typeof(BookingResponse));
        }

        /// <summary>Resolve the nearest writable location within 100 metres for tenant-level camera capture.</summary>
        public CameraResourceResponse GetCameraNearestLocation()
        {
            return GetCameraNearestLocation(null);
        }

        /// <summary>Resolve the nearest writable location within 100 metres for tenant-level camera capture.</summary>
        public CameraResourceResponse GetCameraNearestLocation(GetCameraNearestLocationOptions options)
        {
            string path = "api/v1/camera/nearest-location";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "latitude", options.Latitude);
                path = AddQuery(path, "longitude", options.Longitude);
                path = AddQuery(path, "accuracyMeters", options.AccuracyMeters);
            }
            return (CameraResourceResponse)SendJson("GET", path, null, headers, 200, typeof(CameraResourceResponse));
        }

        /// <summary>Read the display identity of one authorized camera resource.</summary>
        public CameraResourceResponse GetCameraResource()
        {
            return GetCameraResource(null);
        }

        /// <summary>Read the display identity of one authorized camera resource.</summary>
        public CameraResourceResponse GetCameraResource(GetCameraResourceOptions options)
        {
            string path = "api/v1/camera/resource";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "resourceKid", options.ResourceKid);
            }
            return (CameraResourceResponse)SendJson("GET", path, null, headers, 200, typeof(CameraResourceResponse));
        }

        /// <summary>Check the lazy local camera tab and capture permission for one exact resource.</summary>
        public CameraAvailabilityResponse GetCameraAvailability()
        {
            return GetCameraAvailability(null);
        }

        /// <summary>Check the lazy local camera tab and capture permission for one exact resource.</summary>
        public CameraAvailabilityResponse GetCameraAvailability(GetCameraAvailabilityOptions options)
        {
            string path = "api/v1/camera/availability";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "resourceKid", options.ResourceKid);
            }
            return (CameraAvailabilityResponse)SendJson("GET", path, null, headers, 200, typeof(CameraAvailabilityResponse));
        }

        /// <summary>Prepare a bounded, immutable capture plan including optional weather.</summary>
        public CameraPrepareResponse PrepareCameraCapture(CameraPrepareRequest body)
        {
            string path = "api/v1/camera/prepare";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (CameraPrepareResponse)SendJson("POST", path, body, headers, 200, typeof(CameraPrepareResponse));
        }

        /// <summary>Save camera media synchronously, or accept bounded background processing.</summary>
        public CameraSaveResponse SaveCameraCapture(PortalMultipart body)
        {
            return SaveCameraCapture(body, null);
        }

        /// <summary>Save camera media synchronously, or accept bounded background processing.</summary>
        public CameraSaveResponse SaveCameraCapture(PortalMultipart body, SaveCameraCaptureOptions options)
        {
            string path = "api/v1/camera";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "background", options.Background);
            }
            return (CameraSaveResponse)SendJson("POST", path, body, headers, options != null && options.Background == true ? 202 : 200, typeof(CameraSaveResponse));
        }

        /// <summary>List own tenant captures, or all authorized captures on one exact bank, location or unit.</summary>
        public CameraCapturePage GetCameraCaptures()
        {
            return GetCameraCaptures(null);
        }

        /// <summary>List own tenant captures, or all authorized captures on one exact bank, location or unit.</summary>
        public CameraCapturePage GetCameraCaptures(GetCameraCapturesOptions options)
        {
            string path = "api/v1/camera";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "resourceKid", options.ResourceKid);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (CameraCapturePage)SendJson("GET", path, null, headers, 200, typeof(CameraCapturePage));
        }

        /// <summary>Confirm publication of an exact prepared capture after an uncertain upload response.</summary>
        public CameraConfirmationResponse ConfirmCameraCapture(CameraConfirmationRequest body)
        {
            string path = "api/v1/camera/confirmation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (CameraConfirmationResponse)SendJson("POST", path, body, headers, 200, typeof(CameraConfirmationResponse));
        }

        /// <summary>Stream one capture component through the API, with current resource authorization.</summary>
        public PortalDownload GetCameraCaptureContent(string @id)
        {
            return GetCameraCaptureContent(@id, null);
        }

        /// <summary>Stream one capture component through the API, with current resource authorization.</summary>
        public PortalDownload GetCameraCaptureContent(string @id, GetCameraCaptureContentOptions options)
        {
            string path = "api/v1/camera/{id}/content";
            path = path.Replace("{id}", PathValue(@id));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "part", options.Part);
                if (options.Range != null) headers.Add("Range", options.Range);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Read private capture metadata for a public recent-photo thumbnail.</summary>
        public PortalDownload GetRecentCameraPhotoMetadata(string @id)
        {
            string path = "api/v1/camera/recent/{id}/metadata";
            path = path.Replace("{id}", PathValue(@id));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>List authorized settlement periods requiring attention, as in DatPro2 Checklist1.</summary>
        public ChecklistPage GetChecklist()
        {
            return GetChecklist(null);
        }

        /// <summary>List authorized settlement periods requiring attention, as in DatPro2 Checklist1.</summary>
        public ChecklistPage GetChecklist(GetChecklistOptions options)
        {
            string path = "api/v1/settlement-checklist";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "scopeKid", options.ScopeKid);
                path = AddQuery(path, "includeResolved", options.IncludeResolved);
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (ChecklistPage)SendJson("GET", path, null, headers, 200, typeof(ChecklistPage));
        }

        /// <summary>Read one current checklist period, including its hidden/completed status.</summary>
        public ChecklistItem GetChecklistPeriod(string @periodKid)
        {
            string path = "api/v1/settlement-checklist/{periodKid}";
            path = path.Replace("{periodKid}", PathValue(@periodKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ChecklistItem)SendJson("GET", path, null, headers, 200, typeof(ChecklistItem));
        }

        /// <summary>Downloads the complete filtered selection as CSV or a genuine Excel workbook.</summary>
        public PortalDownload ExportBankAccount(string @bankKid)
        {
            return ExportBankAccount(@bankKid, null);
        }

        /// <summary>Downloads the complete filtered selection as CSV or a genuine Excel workbook.</summary>
        public PortalDownload ExportBankAccount(string @bankKid, ExportBankAccountOptions options)
        {
            string path = "api/v1/banks/{bankKid}/account/export";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "From", options.From);
                path = AddQuery(path, "Through", options.Through);
                path = AddQuery(path, "TimeZone", options.TimeZone);
                path = AddQuery(path, "Period", options.Period);
                path = AddQuery(path, "LocationKid", options.LocationKid);
                path = AddQuery(path, "UnitKid", options.UnitKid);
                path = AddQuery(path, "UserKid", options.UserKid);
                path = AddQuery(path, "Kind", options.Kind);
                path = AddQuery(path, "IncludeZero", options.IncludeZero);
                path = AddQuery(path, "IncludeBookings", options.IncludeBookings);
                path = AddQuery(path, "IncludeMonthly", options.IncludeMonthly);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
                path = AddQuery(path, "format", options.Format);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text.</summary>
        public PortalDownload ExportBankUsers(string @bankKid)
        {
            return ExportBankUsers(@bankKid, null);
        }

        /// <summary>Download filtered residents as UTF-8 CSV, at most 10,000 residents and 4 MiB text.</summary>
        public PortalDownload ExportBankUsers(string @bankKid, ExportBankUsersOptions options)
        {
            string path = "api/v1/banks/{bankKid}/users/export";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "deleted", options.Deleted);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest.</summary>
        public PortalDownload DownloadBankSettlement(string @bankKid, int @period)
        {
            return DownloadBankSettlement(@bankKid, @period, null);
        }

        /// <summary>Downloads a ZIP with one settlement file per group and currency, plus a reconciliation manifest.</summary>
        public PortalDownload DownloadBankSettlement(string @bankKid, int @period, DownloadBankSettlementOptions options)
        {
            string path = "api/v1/banks/{bankKid}/settlements/{period}/download";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{period}", PathValue(@period));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "format", options.Format);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Download a UTF-8 CSV table for one document.</summary>
        public PortalDownload DownloadUnitDocumentCsv(string @cycleKid)
        {
            return DownloadUnitDocumentCsv(@cycleKid, null);
        }

        /// <summary>Download a UTF-8 CSV table for one document.</summary>
        public PortalDownload DownloadUnitDocumentCsv(string @cycleKid, DownloadUnitDocumentCsvOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/table.csv";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Download an Excel 97–2003 binary .xls workbook for one document.</summary>
        public PortalDownload DownloadUnitDocumentXls(string @cycleKid)
        {
            return DownloadUnitDocumentXls(@cycleKid, null);
        }

        /// <summary>Download an Excel 97–2003 binary .xls workbook for one document.</summary>
        public PortalDownload DownloadUnitDocumentXls(string @cycleKid, DownloadUnitDocumentXlsOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/table.xls";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>List a bank's machine errors, as in DatPro2 Errors2.</summary>
        public UnitErrorPage GetBankErrors(string @bankKid)
        {
            return GetBankErrors(@bankKid, null);
        }

        /// <summary>List a bank's machine errors, as in DatPro2 Errors2.</summary>
        public UnitErrorPage GetBankErrors(string @bankKid, GetBankErrorsOptions options)
        {
            string path = "api/v1/banks/{bankKid}/errors";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "days", options.Days);
                path = AddQuery(path, "level", options.Level);
                path = AddQuery(path, "includeAcknowledged", options.IncludeAcknowledged);
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (UnitErrorPage)SendJson("GET", path, null, headers, 200, typeof(UnitErrorPage));
        }

        /// <summary>Read one authorized error event, including its current acknowledgement and revision.</summary>
        public UnitErrorItem GetError(string @errorKid)
        {
            string path = "api/v1/errors/{errorKid}";
            path = path.Replace("{errorKid}", PathValue(@errorKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UnitErrorItem)SendJson("GET", path, null, headers, 200, typeof(UnitErrorItem));
        }

        /// <summary>Acknowledge one error without deleting its log or changing machine status.</summary>
        public UnitErrorItem AcknowledgeError(string @errorKid, AcknowledgeErrorRequest body)
        {
            string path = "api/v1/errors/{errorKid}/acknowledge";
            path = path.Replace("{errorKid}", PathValue(@errorKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UnitErrorItem)SendJson("POST", path, body, headers, 200, typeof(UnitErrorItem));
        }

        /// <summary>Read recent DigitalOcean runtime logs for a configured shared app.</summary>
        public HostingLogsResponse GetHostingLogs()
        {
            return GetHostingLogs(null);
        }

        /// <summary>Read recent DigitalOcean runtime logs for a configured shared app.</summary>
        public HostingLogsResponse GetHostingLogs(GetHostingLogsOptions options)
        {
            string path = "api/v1/hosting/logs";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "environment", options.Environment);
                path = AddQuery(path, "application", options.Application);
            }
            return (HostingLogsResponse)SendJson("GET", path, null, headers, 200, typeof(HostingLogsResponse));
        }

        /// <summary>Read hosting metrics for one configured application or Managed MySQL cluster.</summary>
        public HostingMetricsResponse GetHostingMetrics()
        {
            return GetHostingMetrics(null);
        }

        /// <summary>Read hosting metrics for one configured application or Managed MySQL cluster.</summary>
        public HostingMetricsResponse GetHostingMetrics(GetHostingMetricsOptions options)
        {
            string path = "api/v1/hosting/metrics";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "environment", options.Environment);
                path = AddQuery(path, "application", options.Application);
                path = AddQuery(path, "hours", options.Hours);
            }
            return (HostingMetricsResponse)SendJson("GET", path, null, headers, 200, typeof(HostingMetricsResponse));
        }

        /// <summary>Save an installer's selected Person icon.</summary>
        public InstallerIconResponse SetInstallerIcon(string @installerKid, InstallerIconRequest body)
        {
            string path = "api/v1/installers/{installerKid}/icon";
            path = path.Replace("{installerKid}", PathValue(@installerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (InstallerIconResponse)SendJson("POST", path, body, headers, 200, typeof(InstallerIconResponse));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetInstallerExportCount()
        {
            return GetInstallerExportCount(null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetInstallerExportCount(GetInstallerExportCountOptions options)
        {
            string path = "api/v1/installers/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "includeActivationCode", options.IncludeActivationCode);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>List installers with locations, tags, account state and last activity.</summary>
        public InstallerDirectoryResponse GetInstallers()
        {
            return GetInstallers(null);
        }

        /// <summary>List installers with locations, tags, account state and last activity.</summary>
        public InstallerDirectoryResponse GetInstallers(GetInstallersOptions options)
        {
            string path = "api/v1/installers";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "includeActivationCode", options.IncludeActivationCode);
            }
            return (InstallerDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(InstallerDirectoryResponse));
        }

        /// <summary>Read one installer and the same Person icon catalog used for administrators.</summary>
        public InstallerDetailsResponse GetInstaller(string @installerKid)
        {
            string path = "api/v1/installers/{installerKid}";
            path = path.Replace("{installerKid}", PathValue(@installerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (InstallerDetailsResponse)SendJson("GET", path, null, headers, 200, typeof(InstallerDetailsResponse));
        }

        /// <summary>Read recent live logs from Portal API, Equipment API and Portal Web.</summary>
        public LiveLogsResponse GetLiveLogs()
        {
            string path = "api/v1/diagnostics/live-logs";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (LiveLogsResponse)SendJson("GET", path, null, headers, 200, typeof(LiveLogsResponse));
        }

        /// <summary>Count accessible active locations for the Locations1 navigation icon.</summary>
        public ActiveLocationCountResponse GetActiveLocationCount()
        {
            return GetActiveLocationCount(null);
        }

        /// <summary>Count accessible active locations for the Locations1 navigation icon.</summary>
        public ActiveLocationCountResponse GetActiveLocationCount(GetActiveLocationCountOptions options)
        {
            string path = "api/v1/locations/active-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "bankKid", options.BankKid);
            }
            return (ActiveLocationCountResponse)SendJson("GET", path, null, headers, 200, typeof(ActiveLocationCountResponse));
        }

        /// <summary>List accessible locations with parent banks, Visma customer numbers and authorized activation codes.</summary>
        public LocationDirectoryResponse GetLocations()
        {
            return GetLocations(null);
        }

        /// <summary>List accessible locations with parent banks, Visma customer numbers and authorized activation codes.</summary>
        public LocationDirectoryResponse GetLocations(GetLocationsOptions options)
        {
            string path = "api/v1/locations";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "includeCoordinates", options.IncludeCoordinates);
                path = AddQuery(path, "bankKid", options.BankKid);
            }
            return (LocationDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(LocationDirectoryResponse));
        }

        /// <summary>Count every location matching the same filters, selected search columns and permissions as GetLocations.</summary>
        public LocationCountResponse GetLocationCount()
        {
            return GetLocationCount(null);
        }

        /// <summary>Count every location matching the same filters, selected search columns and permissions as GetLocations.</summary>
        public LocationCountResponse GetLocationCount(GetLocationCountOptions options)
        {
            string path = "api/v1/locations/count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "bankKid", options.BankKid);
            }
            return (LocationCountResponse)SendJson("GET", path, null, headers, 200, typeof(LocationCountResponse));
        }

        /// <summary>Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24.</summary>
        public SearchResults SearchLocations()
        {
            return SearchLocations(null);
        }

        /// <summary>Search location Name, Bank (alternative bank name), Zip, Address, VismaCustNo and TeltonikaSMS in Log24.</summary>
        public SearchResults SearchLocations(SearchLocationsOptions options)
        {
            string path = "api/v1/search/locations";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Decode a location activation code and resolve its visible name and icon in Log24.</summary>
        public SearchResults SearchLocationActivation()
        {
            return SearchLocationActivation(null);
        }

        /// <summary>Decode a location activation code and resolve its visible name and icon in Log24.</summary>
        public SearchResults SearchLocationActivation(SearchLocationActivationOptions options)
        {
            string path = "api/v1/search/location-activation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Read dated reservation calendars with location opening hours already applied.</summary>
        public LocationBookingCalendarsResponse GetLocationBookingCalendars(string @locationKid)
        {
            return GetLocationBookingCalendars(@locationKid, null);
        }

        /// <summary>Read dated reservation calendars with location opening hours already applied.</summary>
        public LocationBookingCalendarsResponse GetLocationBookingCalendars(string @locationKid, GetLocationBookingCalendarsOptions options)
        {
            string path = "api/v1/locations/{locationKid}/booking-calendars";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
                path = AddQuery(path, "from", options.From);
                path = AddQuery(path, "days", options.Days);
            }
            return (LocationBookingCalendarsResponse)SendJson("GET", path, null, headers, 200, typeof(LocationBookingCalendarsResponse));
        }

        /// <summary>Read localized configured reservation rules for the location's visible units.</summary>
        public LocationBookingRulesResponse GetLocationBookingRules(string @locationKid)
        {
            return GetLocationBookingRules(@locationKid, null);
        }

        /// <summary>Read localized configured reservation rules for the location's visible units.</summary>
        public LocationBookingRulesResponse GetLocationBookingRules(string @locationKid, GetLocationBookingRulesOptions options)
        {
            string path = "api/v1/locations/{locationKid}/booking-rules";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (LocationBookingRulesResponse)SendJson("GET", path, null, headers, 200, typeof(LocationBookingRulesResponse));
        }

        /// <summary>Read an authorized controller using its canonical Controller KID with MainId.</summary>
        public UnitDetailsResponse GetControllerOverview(string @controllerKid)
        {
            return GetControllerOverview(@controllerKid, null);
        }

        /// <summary>Read an authorized controller using its canonical Controller KID with MainId.</summary>
        public UnitDetailsResponse GetControllerOverview(string @controllerKid, GetControllerOverviewOptions options)
        {
            string path = "api/v1/controllers/{controllerKid}";
            path = path.Replace("{controllerKid}", PathValue(@controllerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (UnitDetailsResponse)SendJson("GET", path, null, headers, 200, typeof(UnitDetailsResponse));
        }

        /// <summary>Read the controller's temporary Core settings or states from its main unit.</summary>
        public UnitGroupResponse GetControllerGroup(string @controllerKid, string @kind, string @group)
        {
            return GetControllerGroup(@controllerKid, @kind, @group, null);
        }

        /// <summary>Read the controller's temporary Core settings or states from its main unit.</summary>
        public UnitGroupResponse GetControllerGroup(string @controllerKid, string @kind, string @group, GetControllerGroupOptions options)
        {
            string path = "api/v1/controllers/{controllerKid}/groups/{kind}/{group}";
            path = path.Replace("{controllerKid}", PathValue(@controllerKid));
            path = path.Replace("{kind}", PathValue(@kind));
            path = path.Replace("{group}", PathValue(@group));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (UnitGroupResponse)SendJson("GET", path, null, headers, 200, typeof(UnitGroupResponse));
        }

        /// <summary>Get the location label and its units, ordered by unit number.</summary>
        public LocationUnitsResponse GetLocationUnits(string @locationKid)
        {
            return GetLocationUnits(@locationKid, null);
        }

        /// <summary>Get the location label and its units, ordered by unit number.</summary>
        public LocationUnitsResponse GetLocationUnits(string @locationKid, GetLocationUnitsOptions options)
        {
            string path = "api/v1/locations/{locationKid}/units";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (LocationUnitsResponse)SendJson("GET", path, null, headers, 200, typeof(LocationUnitsResponse));
        }

        /// <summary>Read an authorized unit and its type's setting/state groups.</summary>
        public UnitDetailsResponse GetUnitOverview(string @unitKid)
        {
            return GetUnitOverview(@unitKid, null);
        }

        /// <summary>Read an authorized unit and its type's setting/state groups.</summary>
        public UnitDetailsResponse GetUnitOverview(string @unitKid, GetUnitOverviewOptions options)
        {
            string path = "api/v1/units/{unitKid}";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (UnitDetailsResponse)SendJson("GET", path, null, headers, 200, typeof(UnitDetailsResponse));
        }

        /// <summary>Read the declared settings or states in one authorized unit group.</summary>
        public UnitGroupResponse GetUnitGroup(string @unitKid, string @kind, string @group)
        {
            return GetUnitGroup(@unitKid, @kind, @group, null);
        }

        /// <summary>Read the declared settings or states in one authorized unit group.</summary>
        public UnitGroupResponse GetUnitGroup(string @unitKid, string @kind, string @group, GetUnitGroupOptions options)
        {
            string path = "api/v1/units/{unitKid}/groups/{kind}/{group}";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            path = path.Replace("{kind}", PathValue(@kind));
            path = path.Replace("{group}", PathValue(@group));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (UnitGroupResponse)SendJson("GET", path, null, headers, 200, typeof(UnitGroupResponse));
        }

        /// <summary>Read a bounded page of changes to one declared unit setting.</summary>
        public UnitSettingHistoryResponse GetUnitSettingHistory(string @unitKid, string @group, string @setting)
        {
            return GetUnitSettingHistory(@unitKid, @group, @setting, null);
        }

        /// <summary>Read a bounded page of changes to one declared unit setting.</summary>
        public UnitSettingHistoryResponse GetUnitSettingHistory(string @unitKid, string @group, string @setting, GetUnitSettingHistoryOptions options)
        {
            string path = "api/v1/units/{unitKid}/groups/settings/{group}/{setting}/history";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            path = path.Replace("{group}", PathValue(@group));
            path = path.Replace("{setting}", PathValue(@setting));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "beforeMs2000", options.BeforeMs2000);
                path = AddQuery(path, "limit", options.Limit);
            }
            return (UnitSettingHistoryResponse)SendJson("GET", path, null, headers, 200, typeof(UnitSettingHistoryResponse));
        }

        /// <summary>Resolve up to 32 visible unit icons, adding the online/offline under-icon on demand.</summary>
        public UnitIconsResponse GetUnitIcons()
        {
            return GetUnitIcons(null);
        }

        /// <summary>Resolve up to 32 visible unit icons, adding the online/offline under-icon on demand.</summary>
        public UnitIconsResponse GetUnitIcons(GetUnitIconsOptions options)
        {
            string path = "api/v1/units/icons";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "kid", options.Kid);
            }
            return (UnitIconsResponse)SendJson("GET", path, null, headers, 200, typeof(UnitIconsResponse));
        }

        /// <summary>Resolve up to 32 visible location icons with their units' combined online/offline status.</summary>
        public LocationIconsResponse GetLocationIcons()
        {
            return GetLocationIcons(null);
        }

        /// <summary>Resolve up to 32 visible location icons with their units' combined online/offline status.</summary>
        public LocationIconsResponse GetLocationIcons(GetLocationIconsOptions options)
        {
            string path = "api/v1/locations/icons";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "kid", options.Kid);
            }
            return (LocationIconsResponse)SendJson("GET", path, null, headers, 200, typeof(LocationIconsResponse));
        }

        /// <summary>Read grouped opening hours, upcoming exceptions and the current opening status for a location.</summary>
        public LocationOpeningHoursResponse GetLocationOpeningHours(string @locationKid)
        {
            return GetLocationOpeningHours(@locationKid, null);
        }

        /// <summary>Read grouped opening hours, upcoming exceptions and the current opening status for a location.</summary>
        public LocationOpeningHoursResponse GetLocationOpeningHours(string @locationKid, GetLocationOpeningHoursOptions options)
        {
            string path = "api/v1/locations/{locationKid}/opening-hours";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (LocationOpeningHoursResponse)SendJson("GET", path, null, headers, 200, typeof(LocationOpeningHoursResponse));
        }

        /// <summary>Read bank Log5 reservation history for the location's authorized visible units.</summary>
        public LocationReservationHistoryResponse GetLocationReservationHistory(string @locationKid)
        {
            return GetLocationReservationHistory(@locationKid, null);
        }

        /// <summary>Read bank Log5 reservation history for the location's authorized visible units.</summary>
        public LocationReservationHistoryResponse GetLocationReservationHistory(string @locationKid, GetLocationReservationHistoryOptions options)
        {
            string path = "api/v1/locations/{locationKid}/reservation-history";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "from", options.From);
                path = AddQuery(path, "days", options.Days);
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (LocationReservationHistoryResponse)SendJson("GET", path, null, headers, 200, typeof(LocationReservationHistoryResponse));
        }

        /// <summary>Read active tenant Log5 reservations for the location's authorized visible units.</summary>
        public LocationReservationsResponse GetLocationReservations(string @locationKid)
        {
            return GetLocationReservations(@locationKid, null);
        }

        /// <summary>Read active tenant Log5 reservations for the location's authorized visible units.</summary>
        public LocationReservationsResponse GetLocationReservations(string @locationKid, GetLocationReservationsOptions options)
        {
            string path = "api/v1/locations/{locationKid}/reservations";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "from", options.From);
                path = AddQuery(path, "days", options.Days);
                if (options.AcceptLanguage != null) headers.Add("Accept-Language", options.AcceptLanguage);
            }
            return (LocationReservationsResponse)SendJson("GET", path, null, headers, 200, typeof(LocationReservationsResponse));
        }

        /// <summary>Get current weather for the authorized location's stored position or address.</summary>
        public LocationWeatherResponse GetLocationWeather(string @locationKid)
        {
            string path = "api/v1/locations/{locationKid}/weather";
            path = path.Replace("{locationKid}", PathValue(@locationKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (LocationWeatherResponse)SendJson("GET", path, null, headers, 200, typeof(LocationWeatherResponse));
        }

        /// <summary>Create an empty enabled administrator with a previously unused manager identity.</summary>
        public ManagerCreationResponse CreateManager()
        {
            string path = "api/v1/managers";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerCreationResponse)SendJson("POST", path, null, headers, 201, typeof(ManagerCreationResponse));
        }

        /// <summary>List administrators in the site's eUserId.Managers through ManagersLast range.</summary>
        public ManagerDirectoryResponse GetManagers()
        {
            return GetManagers(null);
        }

        /// <summary>List administrators in the site's eUserId.Managers through ManagersLast range.</summary>
        public ManagerDirectoryResponse GetManagers(GetManagersOptions options)
        {
            string path = "api/v1/managers";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
            }
            return (ManagerDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(ManagerDirectoryResponse));
        }

        /// <summary>Send an invitation allowing an existing manager to choose a password.</summary>
        public ManagerInvitationResponse InviteManager(string @managerKid, ManagerInvitationRequest body)
        {
            string path = "api/v1/managers/{managerKid}/invitation";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerInvitationResponse)SendJson("POST", path, body, headers, 202, typeof(ManagerInvitationResponse));
        }

        /// <summary>Add or remove a tenant, whole-bank or single-location grant on an administrator.</summary>
        public ManagerKidChangeResponse SetManagerKid(string @managerKid, ManagerKidChangeRequest body)
        {
            string path = "api/v1/managers/{managerKid}/kids";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerKidChangeResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerKidChangeResponse));
        }

        /// <summary>Request a manager password reset email.</summary>
        public ManagerPasswordResetResponse RequestManagerPasswordReset(ManagerForgotPasswordRequest body)
        {
            string path = "api/v1/session/forgot-password";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerPasswordResetResponse)SendJson("POST", path, body, headers, 202, typeof(ManagerPasswordResetResponse));
        }

        /// <summary>Replace a manager password using the emailed recovery token.</summary>
        public ManagerPasswordResetResponse ResetManagerPassword(ManagerResetPasswordRequest body)
        {
            string path = "api/v1/session/reset-password";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerPasswordResetResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerPasswordResetResponse));
        }

        /// <summary>Replace all nine permission categories with a predefined administrator role.</summary>
        public ManagerPermissionRoleResponse SetManagerPermissionRole(string @managerKid, ManagerPermissionRoleRequest body)
        {
            string path = "api/v1/managers/{managerKid}/permission-role";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerPermissionRoleResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerPermissionRoleResponse));
        }

        /// <summary>Set one administrator permission checkbox, including your own if you are the sole active tenant-wide manager.</summary>
        public ManagerOperationPermissionResponse SetManagerPermission(string @managerKid, string @resource, ManagerPermissionChangeRequest body)
        {
            string path = "api/v1/managers/{managerKid}/permissions/{resource}";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            path = path.Replace("{resource}", PathValue(@resource));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerOperationPermissionResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerOperationPermissionResponse));
        }

        /// <summary>Change Name, Organisation, Enabled, Deleted, RetentionDays, Icon or Email on an administrator.</summary>
        public ManagerProfileChangeResponse SetManagerProfileField(string @managerKid, string @field, ManagerProfileChangeRequest body)
        {
            string path = "api/v1/managers/{managerKid}/profile/{field}";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            path = path.Replace("{field}", PathValue(@field));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerProfileChangeResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerProfileChangeResponse));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetManagerExportCount()
        {
            return GetManagerExportCount(null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetManagerExportCount(GetManagerExportCountOptions options)
        {
            string path = "api/v1/managers/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>Read one administrator by canonical manager KID for a workspace shortcut.</summary>
        public ManagerDirectoryItem GetManager(string @managerKid)
        {
            string path = "api/v1/managers/{managerKid}";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerDirectoryItem)SendJson("GET", path, null, headers, 200, typeof(ManagerDirectoryItem));
        }

        /// <summary>List other visible administrators with the same stored email as this manager.</summary>
        public ManagerEmailMatch[] GetManagersWithSameEmail(string @managerKid)
        {
            string path = "api/v1/managers/{managerKid}/same-email";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerEmailMatch[])SendJson("GET", path, null, headers, 200, typeof(ManagerEmailMatch[]));
        }

        /// <summary>Log in with manager email/password or manager username/API key.</summary>
        public ManagerSessionResponse LoginManager(ManagerLoginRequest body)
        {
            return LoginManager(body, null);
        }

        /// <summary>Log in with manager email/password or manager username/API key.</summary>
        public ManagerSessionResponse LoginManager(ManagerLoginRequest body, LoginManagerOptions options)
        {
            string path = "api/v1/session/login";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                if (options.XPortalLoginClientIP != null) headers.Add("X-Portal-Login-Client-IP", options.XPortalLoginClientIP);
            }
            return (ManagerSessionResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerSessionResponse));
        }

        /// <summary>Renew an unexpired manager session for ten days.</summary>
        public ManagerSessionResponse RenewManagerSession()
        {
            string path = "api/v1/session/renew";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerSessionResponse)SendJson("POST", path, null, headers, 200, typeof(ManagerSessionResponse));
        }

        /// <summary>Get your profile, permitted tabs, bank/location access, and operation permissions.</summary>
        public ManagerProfileResponse GetCurrentManager()
        {
            string path = "api/v1/session/me";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerProfileResponse)SendJson("GET", path, null, headers, 200, typeof(ManagerProfileResponse));
        }

        /// <summary>Create a pending manager with a password and queue a manager-bound verification email.</summary>
        public PersonalAccountResult RequestManagerSignUp(ManagerSignUpRequest body)
        {
            string path = "api/v1/session/signup";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalAccountResult)SendJson("POST", path, body, headers, 202, typeof(PersonalAccountResult));
        }

        /// <summary>Verify the email and activate only the manager already created by self-registration.</summary>
        public PersonalAccountResult ConfirmManagerSignUp(ManagerSignUpConfirmation body)
        {
            string path = "api/v1/session/signup-confirmation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalAccountResult)SendJson("POST", path, body, headers, 200, typeof(PersonalAccountResult));
        }

        /// <summary>Assign or remove one available eTab on an administrator.</summary>
        public ManagerTabChangeResponse SetManagerTab(string @managerKid, int @tabId, ManagerTabChangeRequest body)
        {
            string path = "api/v1/managers/{managerKid}/tabs/{tabId}";
            path = path.Replace("{managerKid}", PathValue(@managerKid));
            path = path.Replace("{tabId}", PathValue(@tabId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerTabChangeResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerTabChangeResponse));
        }

        /// <summary>Save your own theme preference.</summary>
        public ManagerThemeResponse SetCurrentManagerTheme(ManagerThemeRequest body)
        {
            string path = "api/v1/session/me/theme";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ManagerThemeResponse)SendJson("POST", path, body, headers, 200, typeof(ManagerThemeResponse));
        }

        /// <summary>Get up to ten authorized locations nearest to a supplied position.</summary>
        public NearestLocationItem[] GetNearestLocations()
        {
            return GetNearestLocations(null);
        }

        /// <summary>Get up to ten authorized locations nearest to a supplied position.</summary>
        public NearestLocationItem[] GetNearestLocations(GetNearestLocationsOptions options)
        {
            string path = "api/v1/locations/nearest";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "latitude", options.Latitude);
                path = AddQuery(path, "longitude", options.Longitude);
            }
            return (NearestLocationItem[])SendJson("GET", path, null, headers, 200, typeof(NearestLocationItem[]));
        }

        /// <summary>Count all visible administrators, independently of the current page/filter.</summary>
        public PeopleDirectoryCount GetManagerCount()
        {
            string path = "api/v1/managers/count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PeopleDirectoryCount)SendJson("GET", path, null, headers, 200, typeof(PeopleDirectoryCount));
        }

        /// <summary>Count all visible installers, independently of the current page/filter.</summary>
        public PeopleDirectoryCount GetInstallerCount()
        {
            string path = "api/v1/installers/count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PeopleDirectoryCount)SendJson("GET", path, null, headers, 200, typeof(PeopleDirectoryCount));
        }

        /// <summary>Read your own personal settings and available person icons.</summary>
        public PersonalManagerProfile GetMyManagerProfile()
        {
            string path = "api/v1/session/me/profile";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalManagerProfile)SendJson("GET", path, null, headers, 200, typeof(PersonalManagerProfile));
        }

        /// <summary>Add a scanned display to your own WallBoards layout setting.</summary>
        public PersonalAccountResult AddMyManagerWallboard(PersonalWallboardRequest body)
        {
            string path = "api/v1/session/me/wallboards";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalAccountResult)SendJson("POST", path, body, headers, 200, typeof(PersonalAccountResult));
        }

        /// <summary>Read your own Wallboard1 editor layouts and concurrency revision.</summary>
        public PersonalWallboardsResponse GetMyManagerWallboards()
        {
            string path = "api/v1/session/me/wallboards";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalWallboardsResponse)SendJson("GET", path, null, headers, 200, typeof(PersonalWallboardsResponse));
        }

        /// <summary>Save your own complete Wallboard1 layout collection.</summary>
        public PersonalWallboardsResponse SaveMyManagerWallboards(SavePersonalWallboardsRequest body)
        {
            string path = "api/v1/session/me/wallboards";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalWallboardsResponse)SendJson("PUT", path, body, headers, 200, typeof(PersonalWallboardsResponse));
        }

        /// <summary>Read the selected orientation for one of your Wallboards.</summary>
        public WallboardDisplayResponse GetMyManagerWallboardDisplay(string @displayId)
        {
            return GetMyManagerWallboardDisplay(@displayId, null);
        }

        /// <summary>Read the selected orientation for one of your Wallboards.</summary>
        public WallboardDisplayResponse GetMyManagerWallboardDisplay(string @displayId, GetMyManagerWallboardDisplayOptions options)
        {
            string path = "api/v1/session/me/wallboards/display/{displayId}";
            path = path.Replace("{displayId}", PathValue(@displayId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "portrait", options.Portrait);
                path = AddQuery(path, "after", options.After);
            }
            return (WallboardDisplayResponse)SendJson("GET", path, null, headers, 200, typeof(WallboardDisplayResponse));
        }

        /// <summary>Read your own API-key configuration status and revision without exposing credentials.</summary>
        public PersonalManagerApiKey GetMyManagerApiKey()
        {
            string path = "api/v1/session/me/api-key";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalManagerApiKey)SendJson("GET", path, null, headers, 200, typeof(PersonalManagerApiKey));
        }

        /// <summary>Generate your own API key and commit its hash to eSetting.ApiKeyHash.</summary>
        public PersonalApiKeyResponse GenerateMyManagerApiKey(PersonalApiKeyRequest body)
        {
            string path = "api/v1/session/me/api-key";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalApiKeyResponse)SendJson("POST", path, body, headers, 200, typeof(PersonalApiKeyResponse));
        }

        /// <summary>Read your own tab selection, available tabs and editing eligibility.</summary>
        public PersonalManagerTabs GetMyManagerTabs()
        {
            string path = "api/v1/session/me/tabs";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalManagerTabs)SendJson("GET", path, null, headers, 200, typeof(PersonalManagerTabs));
        }

        /// <summary>Select or deselect one of your own tabs when you have access to all banks.</summary>
        public PersonalManagerTabs SetMyManagerTab(int @tabId, PersonalTabRequest body)
        {
            string path = "api/v1/session/me/tabs/{tabId}";
            path = path.Replace("{tabId}", PathValue(@tabId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalManagerTabs)SendJson("POST", path, body, headers, 200, typeof(PersonalManagerTabs));
        }

        /// <summary>Save one personal name, organisation, person icon, theme or deleted-record visibility preference.</summary>
        public PersonalManagerProfile SetMyManagerProfileField(string @field, PersonalProfileRequest body)
        {
            string path = "api/v1/session/me/profile/{field}";
            path = path.Replace("{field}", PathValue(@field));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalManagerProfile)SendJson("POST", path, body, headers, 200, typeof(PersonalManagerProfile));
        }

        /// <summary>Send a verification link to your new email address.</summary>
        public PersonalAccountResult RequestMyManagerEmailVerification(PersonalEmailRequest body)
        {
            string path = "api/v1/session/me/email-verification";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalAccountResult)SendJson("POST", path, body, headers, 202, typeof(PersonalAccountResult));
        }

        /// <summary>Confirm the new mailbox with its single-use verification token.</summary>
        public PersonalAccountResult ConfirmMyManagerEmail(PersonalEmailConfirmation body)
        {
            string path = "api/v1/session/me/email-confirmation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalAccountResult)SendJson("POST", path, body, headers, 200, typeof(PersonalAccountResult));
        }

        /// <summary>Change your password after reauthentication and repeated new-password entry.</summary>
        public PersonalAccountResult ChangeMyManagerPassword(PersonalPasswordRequest body)
        {
            string path = "api/v1/session/me/password";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PersonalAccountResult)SendJson("POST", path, body, headers, 200, typeof(PersonalAccountResult));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetServiceExportCount()
        {
            return GetServiceExportCount(null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetServiceExportCount(GetServiceExportCountOptions options)
        {
            string path = "api/v1/services/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>List concrete service enum identities, including services without saved settings.</summary>
        public ServiceDirectoryResponse GetServices()
        {
            return GetServices(null);
        }

        /// <summary>List concrete service enum identities, including services without saved settings.</summary>
        public ServiceDirectoryResponse GetServices(GetServicesOptions options)
        {
            string path = "api/v1/services";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
            }
            return (ServiceDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(ServiceDirectoryResponse));
        }

        /// <summary>Count the predefined service identities without reading service settings.</summary>
        public PeopleDirectoryCount GetServiceCount()
        {
            string path = "api/v1/services/count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PeopleDirectoryCount)SendJson("GET", path, null, headers, 200, typeof(PeopleDirectoryCount));
        }

        /// <summary>Read one predefined service, editable metadata and its icon catalog.</summary>
        public ServiceDetailsResponse GetService(string @serviceKid)
        {
            string path = "api/v1/services/{serviceKid}";
            path = path.Replace("{serviceKid}", PathValue(@serviceKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ServiceDetailsResponse)SendJson("GET", path, null, headers, 200, typeof(ServiceDetailsResponse));
        }

        /// <summary>Save one service Name or Icon.</summary>
        public ServiceDetailsResponse SetServiceProfileField(string @serviceKid, string @field, ServiceProfileRequest body)
        {
            string path = "api/v1/services/{serviceKid}/profile/{field}";
            path = path.Replace("{serviceKid}", PathValue(@serviceKid));
            path = path.Replace("{field}", PathValue(@field));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ServiceDetailsResponse)SendJson("POST", path, body, headers, 200, typeof(ServiceDetailsResponse));
        }

        /// <summary>Generate a service API key beginning with kt_ and save its password-compatible hash.</summary>
        public ServiceApiKeyResponse GenerateServiceApiKey(string @serviceKid, ServiceApiKeyRequest body)
        {
            string path = "api/v1/services/{serviceKid}/api-key";
            path = path.Replace("{serviceKid}", PathValue(@serviceKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ServiceApiKeyResponse)SendJson("POST", path, body, headers, 200, typeof(ServiceApiKeyResponse));
        }

        /// <summary>Lists 25 closed settlement periods, newest first, and the next scheduled settlement.</summary>
        public SettlementHistoryResponse GetBankSettlements(string @bankKid)
        {
            return GetBankSettlements(@bankKid, null);
        }

        /// <summary>Lists 25 closed settlement periods, newest first, and the next scheduled settlement.</summary>
        public SettlementHistoryResponse GetBankSettlements(string @bankKid, GetBankSettlementsOptions options)
        {
            string path = "api/v1/banks/{bankKid}/settlements";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "beforePeriod", options.BeforePeriod);
            }
            return (SettlementHistoryResponse)SendJson("GET", path, null, headers, 200, typeof(SettlementHistoryResponse));
        }

        /// <summary>Reads grouped totals for one period (zero is the provisional current period) and lists available export formats.</summary>
        public SettlementDetailResponse GetBankSettlementPeriod(string @bankKid, int @period)
        {
            string path = "api/v1/banks/{bankKid}/settlements/{period}";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{period}", PathValue(@period));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (SettlementDetailResponse)SendJson("GET", path, null, headers, 200, typeof(SettlementDetailResponse));
        }

        /// <summary>List Offline and AutoOutOfOrder alerts, newest first, using parallel lookups.</summary>
        public TenantStatusResponse GetTenantStatus()
        {
            return GetTenantStatus(null);
        }

        /// <summary>List Offline and AutoOutOfOrder alerts, newest first, using parallel lookups.</summary>
        public TenantStatusResponse GetTenantStatus(GetTenantStatusOptions options)
        {
            string path = "api/v1/tenant/status";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "limit", options.Limit);
            }
            return (TenantStatusResponse)SendJson("GET", path, null, headers, 200, typeof(TenantStatusResponse));
        }

        /// <summary>Read 25 status rows at a time with next/previous cursors.</summary>
        public TenantStatusPageResponse GetTenantStatusPage()
        {
            return GetTenantStatusPage(null);
        }

        /// <summary>Read 25 status rows at a time with next/previous cursors.</summary>
        public TenantStatusPageResponse GetTenantStatusPage(GetTenantStatusPageOptions options)
        {
            string path = "api/v1/tenant/status/page";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "offset", options.Offset);
                path = AddQuery(path, "anchor", options.Anchor);
            }
            return (TenantStatusPageResponse)SendJson("GET", path, null, headers, 200, typeof(TenantStatusPageResponse));
        }

        /// <summary>Convert MS2000, MI2000, SS2000, UTC or a local wall time without floating-point integers.</summary>
        public ToolTimeResponse ConvertToolTime(ToolTimeRequest body)
        {
            string path = "api/v1/tenant/tools/time";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ToolTimeResponse)SendJson("POST", path, body, headers, 200, typeof(ToolTimeResponse));
        }

        /// <summary>Inspect only the supplied KID with the installed Kombine.Flex.Kid parser.</summary>
        public ToolKidInspectionResponse InspectToolKid(ToolKidInspectionRequest body)
        {
            string path = "api/v1/tenant/tools/kid";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ToolKidInspectionResponse)SendJson("POST", path, body, headers, 200, typeof(ToolKidInspectionResponse));
        }

        /// <summary>Get the authorized machine context, log categories and readable timeline fields.</summary>
        public UnitTimelineFields GetUnitTimelineFields(string @unitKid)
        {
            string path = "api/v1/units/{unitKid}/timeline/fields";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UnitTimelineFields)SendJson("GET", path, null, headers, 200, typeof(UnitTimelineFields));
        }

        /// <summary>Page chronologically through one machine's authorized Log0–Log6 events.</summary>
        public UnitTimelinePage GetUnitTimeline(string @unitKid)
        {
            return GetUnitTimeline(@unitKid, null);
        }

        /// <summary>Page chronologically through one machine's authorized Log0–Log6 events.</summary>
        public UnitTimelinePage GetUnitTimeline(string @unitKid, GetUnitTimelineOptions options)
        {
            string path = "api/v1/units/{unitKid}/timeline";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "fromUtc", options.FromUtc);
                path = AddQuery(path, "untilUtc", options.UntilUtc);
                path = AddQuery(path, "sources", options.Sources);
                path = AddQuery(path, "field", options.Field);
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (UnitTimelinePage)SendJson("GET", path, null, headers, 200, typeof(UnitTimelinePage));
        }

        /// <summary>List document identities produced by the selected Unit for WashDoc3.</summary>
        public UnitDocumentPage GetUnitDocuments(string @unitKid)
        {
            return GetUnitDocuments(@unitKid, null);
        }

        /// <summary>List document identities produced by the selected Unit for WashDoc3.</summary>
        public UnitDocumentPage GetUnitDocuments(string @unitKid, GetUnitDocumentsOptions options)
        {
            string path = "api/v1/units/{unitKid}/documents";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "Sort", options.Sort);
                path = AddQuery(path, "Direction", options.Direction);
                path = AddQuery(path, "Offset", options.Offset);
                path = AddQuery(path, "Limit", options.Limit);
                path = AddQuery(path, "Search", options.Search);
                path = AddQuery(path, "Date", options.Date);
            }
            return (UnitDocumentPage)SendJson("GET", path, null, headers, 200, typeof(UnitDocumentPage));
        }

        /// <summary>Count distinct WashDoc3 document identities for exactly one unit, separately from list loading.</summary>
        public UnitDocumentCount GetUnitDocumentsCount(string @unitKid)
        {
            return GetUnitDocumentsCount(@unitKid, null);
        }

        /// <summary>Count distinct WashDoc3 document identities for exactly one unit, separately from list loading.</summary>
        public UnitDocumentCount GetUnitDocumentsCount(string @unitKid, GetUnitDocumentsCountOptions options)
        {
            string path = "api/v1/units/{unitKid}/documents/count";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "Search", options.Search);
                path = AddQuery(path, "Date", options.Date);
            }
            return (UnitDocumentCount)SendJson("GET", path, null, headers, 200, typeof(UnitDocumentCount));
        }

        /// <summary>Find the previous (higher Doc ID) and next (lower Doc ID) existing document for this exact unit.</summary>
        public DocumentNeighbors GetUnitDocumentNeighbors(string @cycleKid)
        {
            string path = "api/v1/documents/{cycleKid}/neighbors";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (DocumentNeighbors)SendJson("GET", path, null, headers, 200, typeof(DocumentNeighbors));
        }

        /// <summary>Read a document's table as JSON with original values and column metadata.</summary>
        public DocumentTable GetUnitDocumentTable(string @cycleKid)
        {
            return GetUnitDocumentTable(@cycleKid, null);
        }

        /// <summary>Read a document's table as JSON with original values and column metadata.</summary>
        public DocumentTable GetUnitDocumentTable(string @cycleKid, GetUnitDocumentTableOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/table";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return (DocumentTable)SendJson("GET", path, null, headers, 200, typeof(DocumentTable));
        }

        /// <summary>View a document as a printable HTML table.</summary>
        public PortalDownload GetUnitDocumentHtml(string @cycleKid)
        {
            return GetUnitDocumentHtml(@cycleKid, null);
        }

        /// <summary>View a document as a printable HTML table.</summary>
        public PortalDownload GetUnitDocumentHtml(string @cycleKid, GetUnitDocumentHtmlOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/table.html";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Render a document's numeric series as an SVG chart, caching completed documents privately.</summary>
        public PortalDownload GetUnitDocumentSvg(string @cycleKid)
        {
            return GetUnitDocumentSvg(@cycleKid, null);
        }

        /// <summary>Render a document's numeric series as an SVG chart, caching completed documents privately.</summary>
        public PortalDownload GetUnitDocumentSvg(string @cycleKid, GetUnitDocumentSvgOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/graph.svg";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
                path = AddQuery(path, "width", options.Width);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Render a responsive WashDoc chart with independent text and graph layers.</summary>
        public PortalDownload GetUnitDocumentSvg2(string @cycleKid)
        {
            return GetUnitDocumentSvg2(@cycleKid, null);
        }

        /// <summary>Render a responsive WashDoc chart with independent text and graph layers.</summary>
        public PortalDownload GetUnitDocumentSvg2(string @cycleKid, GetUnitDocumentSvg2Options options)
        {
            string path = "api/v1/documents/{cycleKid}/graph2.svg";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Read semantic WashDoc graph JSON for interactive charts and image rendering.</summary>
        public WashDocChartResponse GetUnitDocumentGraph(string @cycleKid)
        {
            return GetUnitDocumentGraph(@cycleKid, null);
        }

        /// <summary>Read semantic WashDoc graph JSON for interactive charts and image rendering.</summary>
        public WashDocChartResponse GetUnitDocumentGraph(string @cycleKid, GetUnitDocumentGraphOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/graph";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return (WashDocChartResponse)SendJson("GET", path, null, headers, 200, typeof(WashDocChartResponse));
        }

        /// <summary>Render a document KID as a PNG image with the shared local Chart.js renderer.</summary>
        public PortalDownload GetUnitDocumentPng(string @cycleKid)
        {
            return GetUnitDocumentPng(@cycleKid, null);
        }

        /// <summary>Render a document KID as a PNG image with the shared local Chart.js renderer.</summary>
        public PortalDownload GetUnitDocumentPng(string @cycleKid, GetUnitDocumentPngOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/graph.png";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Render the first WashDoc curve as a monochrome line icon.</summary>
        public PortalDownload GetUnitDocumentIcon(string @cycleKid)
        {
            return GetUnitDocumentIcon(@cycleKid, null);
        }

        /// <summary>Render the first WashDoc curve as a monochrome line icon.</summary>
        public PortalDownload GetUnitDocumentIcon(string @cycleKid, GetUnitDocumentIconOptions options)
        {
            string path = "api/v1/documents/{cycleKid}/icon.svg";
            path = path.Replace("{cycleKid}", PathValue(@cycleKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "States", options.States);
                path = AddQuery(path, "Settings", options.Settings);
                path = AddQuery(path, "HistoricalMeasurements", options.HistoricalMeasurements);
            }
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>List out-of-order machines, including manual, automatic and repair states.</summary>
        public OutOfOrderPage GetOutOfOrderUnits()
        {
            return GetOutOfOrderUnits(null);
        }

        /// <summary>List out-of-order machines, including manual, automatic and repair states.</summary>
        public OutOfOrderPage GetOutOfOrderUnits(GetOutOfOrderUnitsOptions options)
        {
            string path = "api/v1/units/out-of-service";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (OutOfOrderPage)SendJson("GET", path, null, headers, 200, typeof(OutOfOrderPage));
        }

        /// <summary>Return one out-of-order machine to service by setting OutOfOrder to Enabled (0).</summary>
        public OutOfOrderRestoreResponse RestoreOutOfOrderUnit(string @unitKid, OutOfOrderRestoreRequest body)
        {
            string path = "api/v1/units/{unitKid}/out-of-service/restore";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (OutOfOrderRestoreResponse)SendJson("POST", path, body, headers, 200, typeof(OutOfOrderRestoreResponse));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetUnitExportCount()
        {
            return GetUnitExportCount(null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetUnitExportCount(GetUnitExportCountOptions options)
        {
            string path = "api/v1/units/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "terminalKid", options.TerminalKid);
                path = AddQuery(path, "runningOnly", options.RunningOnly);
                path = AddQuery(path, "autoOutOfOrderOnly", options.AutoOutOfOrderOnly);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>Count authorized main terminals matching the export filters.</summary>
        public DirectoryExportCountResponse GetTerminalExportCount()
        {
            return GetTerminalExportCount(null);
        }

        /// <summary>Count authorized main terminals matching the export filters.</summary>
        public DirectoryExportCountResponse GetTerminalExportCount(GetTerminalExportCountOptions options)
        {
            string path = "api/v1/terminals/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "terminalKid", options.TerminalKid);
                path = AddQuery(path, "runningOnly", options.RunningOnly);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>Count accessible active units for the Units1 navigation icon.</summary>
        public ActiveUnitCountResponse GetActiveUnitCount()
        {
            string path = "api/v1/units/active-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ActiveUnitCountResponse)SendJson("GET", path, null, headers, 200, typeof(ActiveUnitCountResponse));
        }

        /// <summary>Count accessible active terminals for the Terminals1 navigation icon.</summary>
        public ActiveUnitCountResponse GetActiveTerminalCount()
        {
            string path = "api/v1/terminals/active-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ActiveUnitCountResponse)SendJson("GET", path, null, headers, 200, typeof(ActiveUnitCountResponse));
        }

        /// <summary>List authorized units, including child units, for Units1.</summary>
        public UnitDirectoryResponse GetUnits()
        {
            return GetUnits(null);
        }

        /// <summary>List authorized units, including child units, for Units1.</summary>
        public UnitDirectoryResponse GetUnits(GetUnitsOptions options)
        {
            string path = "api/v1/units";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "includeCoordinates", options.IncludeCoordinates);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "terminalKid", options.TerminalKid);
                path = AddQuery(path, "runningOnly", options.RunningOnly);
                path = AddQuery(path, "autoOutOfOrderOnly", options.AutoOutOfOrderOnly);
            }
            return (UnitDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(UnitDirectoryResponse));
        }

        /// <summary>List authorized main units for Terminals1.</summary>
        public UnitDirectoryResponse GetTerminals()
        {
            return GetTerminals(null);
        }

        /// <summary>List authorized main units for Terminals1.</summary>
        public UnitDirectoryResponse GetTerminals(GetTerminalsOptions options)
        {
            string path = "api/v1/terminals";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
                path = AddQuery(path, "fields", options.Fields);
                path = AddQuery(path, "includeCoordinates", options.IncludeCoordinates);
                path = AddQuery(path, "locationKid", options.LocationKid);
                path = AddQuery(path, "terminalKid", options.TerminalKid);
                path = AddQuery(path, "runningOnly", options.RunningOnly);
            }
            return (UnitDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(UnitDirectoryResponse));
        }

        /// <summary>Save one editable current-unit setting with revision protection.</summary>
        public UnitSettingResponse SetUnitSetting(string @unitKid, string @group, string @setting, UnitSettingRequest body)
        {
            string path = "api/v1/units/{unitKid}/groups/settings/{group}/{setting}";
            path = path.Replace("{unitKid}", PathValue(@unitKid));
            path = path.Replace("{group}", PathValue(@group));
            path = path.Replace("{setting}", PathValue(@setting));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UnitSettingResponse)SendJson("POST", path, body, headers, 200, typeof(UnitSettingResponse));
        }

        /// <summary>Read current and previous-period balances for up to 50 residents in one bank.</summary>
        public UserBalancesResponse GetBankUserBalances(string @bankKid, UserBalancesRequest body)
        {
            string path = "api/v1/banks/{bankKid}/users/balances";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserBalancesResponse)SendJson("POST", path, body, headers, 200, typeof(UserBalancesResponse));
        }

        /// <summary>Suggest the next resident number from the bank's first NumberFormats entry and stored NumberFormatUserIndex (default 1).</summary>
        public UserNumberSuggestionResponse GetBankUserNumberForNewUser(string @bankKid)
        {
            string path = "api/v1/banks/{bankKid}/users/next-number";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserNumberSuggestionResponse)SendJson("GET", path, null, headers, 200, typeof(UserNumberSuggestionResponse));
        }

        /// <summary>Suggest the next resident number after userNumber using the bank's first NumberFormats entry.</summary>
        public UserNumberSuggestionResponse GetBankNextUserNumber(string @bankKid)
        {
            return GetBankNextUserNumber(@bankKid, null);
        }

        /// <summary>Suggest the next resident number after userNumber using the bank's first NumberFormats entry.</summary>
        public UserNumberSuggestionResponse GetBankNextUserNumber(string @bankKid, GetBankNextUserNumberOptions options)
        {
            string path = "api/v1/banks/{bankKid}/users/next-number-after";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "userNumber", options.UserNumber);
            }
            return (UserNumberSuggestionResponse)SendJson("GET", path, null, headers, 200, typeof(UserNumberSuggestionResponse));
        }

        /// <summary>Read authoritative editing fields and an opaque concurrency revision. Bank-wide Users2/User Read required.</summary>
        public UserWorkspaceResponse GetBankUserWorkspace(string @bankKid, string @userKid)
        {
            string path = "api/v1/banks/{bankKid}/users/{userKid}/workspace";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{userKid}", PathValue(@userKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserWorkspaceResponse)SendJson("GET", path, null, headers, 200, typeof(UserWorkspaceResponse));
        }

        /// <summary>Read the resident activation code for printing. Requires bank-wide Users2/User Create.</summary>
        public UserActivationResponse GetBankUserActivation(string @bankKid, string @userKid)
        {
            string path = "api/v1/banks/{bankKid}/users/{userKid}/activation";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{userKid}", PathValue(@userKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserActivationResponse)SendJson("GET", path, null, headers, 200, typeof(UserActivationResponse));
        }

        /// <summary>Execute profile, icon, attributes, tag, location, delete, restore or replace with the revision from GetBankUserWorkspace.</summary>
        public UserWorkspaceResponse ExecuteBankUserCommand(string @bankKid, string @userKid, UserCommandRequest body)
        {
            string path = "api/v1/banks/{bankKid}/users/{userKid}/commands";
            path = path.Replace("{bankKid}", PathValue(@bankKid));
            path = path.Replace("{userKid}", PathValue(@userKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserWorkspaceResponse)SendJson("POST", path, body, headers, 200, typeof(UserWorkspaceResponse));
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetUserExportCount()
        {
            return GetUserExportCount(null);
        }

        /// <summary>Count the complete filtered export selection using the same directory authorization and visibility.</summary>
        public DirectoryExportCountResponse GetUserExportCount(GetUserExportCountOptions options)
        {
            string path = "api/v1/users/export-count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
            }
            return (DirectoryExportCountResponse)SendJson("GET", path, null, headers, 200, typeof(DirectoryExportCountResponse));
        }

        /// <summary>List authorized residents for UserFinder1 (77).</summary>
        public UserDirectoryResponse GetUsers()
        {
            return GetUsers(null);
        }

        /// <summary>List authorized residents for UserFinder1 (77).</summary>
        public UserDirectoryResponse GetUsers(GetUsersOptions options)
        {
            string path = "api/v1/users";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
                path = AddQuery(path, "filter", options.Filter);
                path = AddQuery(path, "sort", options.Sort);
                path = AddQuery(path, "direction", options.Direction);
                path = AddQuery(path, "enabledOnly", options.EnabledOnly);
            }
            return (UserDirectoryResponse)SendJson("GET", path, null, headers, 200, typeof(UserDirectoryResponse));
        }

        /// <summary>Count active authorized residents for the UserFinder1 badge.</summary>
        public PeopleDirectoryCount GetUserCount()
        {
            string path = "api/v1/users/count";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PeopleDirectoryCount)SendJson("GET", path, null, headers, 200, typeof(PeopleDirectoryCount));
        }

        /// <summary>Create an eVaskeri login link for one active Nortec resident.</summary>
        public UserEvaskeriSession CreateUserEvaskeriSession(string @userKid)
        {
            string path = "api/v1/users/{userKid}/evaskeri-session";
            path = path.Replace("{userKid}", PathValue(@userKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (UserEvaskeriSession)SendJson("POST", path, null, headers, 200, typeof(UserEvaskeriSession));
        }

        /// <summary>Read complete receipts for one resident, newest first, twenty receipts at a time.</summary>
        public UserReceiptsResponse GetUserReceipts(string @userKid)
        {
            return GetUserReceipts(@userKid, null);
        }

        /// <summary>Read complete receipts for one resident, newest first, twenty receipts at a time.</summary>
        public UserReceiptsResponse GetUserReceipts(string @userKid, GetUserReceiptsOptions options)
        {
            string path = "api/v1/users/{userKid}/receipts";
            path = path.Replace("{userKid}", PathValue(@userKid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "offset", options.Offset);
                path = AddQuery(path, "revision", options.Revision);
            }
            return (UserReceiptsResponse)SendJson("GET", path, null, headers, 200, typeof(UserReceiptsResponse));
        }

        /// <summary>Search resident Number, Name, Email, SMS and partial numeric TagId using current Log7.</summary>
        public SearchResults SearchUsers()
        {
            return SearchUsers(null);
        }

        /// <summary>Search resident Number, Name, Email, SMS and partial numeric TagId using current Log7.</summary>
        public SearchResults SearchUsers(SearchUsersOptions options)
        {
            string path = "api/v1/search/users";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
                path = AddQuery(path, "kidOnly", options.KidOnly);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Search complete resident SMS numbers with indexed exact Log7 Text matches.</summary>
        public SearchResults SearchUserSms()
        {
            return SearchUserSms(null);
        }

        /// <summary>Search complete resident SMS numbers with indexed exact Log7 Text matches.</summary>
        public SearchResults SearchUserSms(SearchUserSmsOptions options)
        {
            string path = "api/v1/search/user-sms";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Decode an ordinary resident activation code and resolve name and icon from current Log7.</summary>
        public SearchResults SearchUserActivation()
        {
            return SearchUserActivation(null);
        }

        /// <summary>Decode an ordinary resident activation code and resolve name and icon from current Log7.</summary>
        public SearchResults SearchUserActivation(SearchUserActivationOptions options)
        {
            string path = "api/v1/search/user-activation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "q", options.Q);
            }
            return (SearchResults)SendJson("GET", path, null, headers, 200, typeof(SearchResults));
        }

        /// <summary>Start a five-minute pairing. Keep deviceCode private; show only pairingId in the QR code.</summary>
        public WallboardPairingStarted StartWallboardPairing(StartWallboardPairing body)
        {
            string path = "api/v1/wallboard/pairings";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (WallboardPairingStarted)SendJson("POST", path, body, headers, 200, typeof(WallboardPairingStarted));
        }

        /// <summary>Find up to ten pending screens with an exact display ID in this tenant and environment.</summary>
        public WallboardPairingInfo[] FindWallboardPairings()
        {
            return FindWallboardPairings(null);
        }

        /// <summary>Find up to ten pending screens with an exact display ID in this tenant and environment.</summary>
        public WallboardPairingInfo[] FindWallboardPairings(FindWallboardPairingsOptions options)
        {
            string path = "api/v1/wallboard/pairings";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "displayId", options.DisplayId);
            }
            return (WallboardPairingInfo[])SendJson("GET", path, null, headers, 200, typeof(WallboardPairingInfo[]));
        }

        /// <summary>Read the screen ID and expiry before explicitly approving its QR code.</summary>
        public WallboardPairingInfo GetWallboardPairing(string @pairingId)
        {
            string path = "api/v1/wallboard/pairings/{pairingId}";
            path = path.Replace("{pairingId}", PathValue(@pairingId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (WallboardPairingInfo)SendJson("GET", path, null, headers, 200, typeof(WallboardPairingInfo));
        }

        /// <summary>Approve one screen using your current manager bearer session, including sessions created with kid and apiKey.</summary>
        public void ApproveWallboardPairing(string @pairingId, ApproveWallboardPairing body)
        {
            string path = "api/v1/wallboard/pairings/{pairingId}/approve";
            path = path.Replace("{pairingId}", PathValue(@pairingId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            SendJson("POST", path, body, headers, 204, typeof(object));
        }

        /// <summary>Poll with the private deviceCode. Successful redemption consumes the pairing atomically.</summary>
        public WallboardPairingToken RedeemWallboardPairing(string @pairingId, RedeemWallboardPairing body)
        {
            string path = "api/v1/wallboard/pairings/{pairingId}/token";
            path = path.Replace("{pairingId}", PathValue(@pairingId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (WallboardPairingToken)SendJson("POST", path, body, headers, 200, typeof(WallboardPairingToken));
        }

        /// <summary>Request a two-minute signing challenge for a permanently approved screen.</summary>
        public WallboardDeviceChallenge ChallengeWallboardDevice(string @deviceId)
        {
            string path = "api/v1/wallboard/devices/{deviceId}/challenge";
            path = path.Replace("{deviceId}", PathValue(@deviceId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (WallboardDeviceChallenge)SendJson("POST", path, null, headers, 200, typeof(WallboardDeviceChallenge));
        }

        /// <summary>Resume a permanently approved screen after proving possession of its private signing key.</summary>
        public WallboardPairingToken ResumeWallboardSession(string @deviceId, ResumeWallboardSession body)
        {
            string path = "api/v1/wallboard/devices/{deviceId}/session";
            path = path.Replace("{deviceId}", PathValue(@deviceId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (WallboardPairingToken)SendJson("POST", path, body, headers, 200, typeof(WallboardPairingToken));
        }

        /// <summary>Read a screen you approved, including the optional scanner location stored with its approval.</summary>
        public WallboardDeviceInfo GetWallboardDevice(string @deviceId)
        {
            string path = "api/v1/wallboard/devices/{deviceId}";
            path = path.Replace("{deviceId}", PathValue(@deviceId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (WallboardDeviceInfo)SendJson("GET", path, null, headers, 200, typeof(WallboardDeviceInfo));
        }

        /// <summary>Revoke a screen you approved. Its existing bearer sessions also lose access.</summary>
        public void RevokeWallboardDevice(string @deviceId)
        {
            string path = "api/v1/wallboard/devices/{deviceId}";
            path = path.Replace("{deviceId}", PathValue(@deviceId));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            SendJson("DELETE", path, null, headers, 204, typeof(object));
        }

        /// <summary>Displays Windows downloads for this tenant, or an explicit unavailable state.</summary>
        public PortalDownload GetPortalAppDownloadPage()
        {
            string path = "download";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Downloads a tenant-bound Windows App Installer file with update checks at launch.</summary>
        public PortalDownload DownloadPortalWindowsAppInstaller(string @architecture)
        {
            string path = "download/windows/{architecture}/portal.appinstaller";
            path = path.Replace("{architecture}", PathValue(@architecture));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Downloads an immutable signed Windows package, with byte-range and conditional request support.</summary>
        public PortalDownload DownloadPortalWindowsPackage(string @architecture, string @fileName)
        {
            string path = "download/windows/{architecture}/{fileName}";
            path = path.Replace("{architecture}", PathValue(@architecture));
            path = path.Replace("{fileName}", PathValue(@fileName));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders an angular color-gradient background at 200 × 200 pixels.</summary>
        public PortalDownload GetCircleGradient(string @colors)
        {
            string path = "api/v1/circles/gradient/{colors}.svg";
            path = path.Replace("{colors}", PathValue(@colors));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders an angular gradient at a selected width and height.</summary>
        public PortalDownload GetCircleGradientSized(string @colors, int @width, int @height)
        {
            string path = "api/v1/circles/gradient/{colors}/{width}x{height}.svg";
            path = path.Replace("{colors}", PathValue(@colors));
            path = path.Replace("{width}", PathValue(@width));
            path = path.Replace("{height}", PathValue(@height));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a progress circle with one square mark per percentage point.</summary>
        public PortalDownload GetCircleProgress(string @background, string @colors, int @percent)
        {
            string path = "api/v1/circles/progress/{background}/{colors}/{percent}.svg";
            path = path.Replace("{background}", PathValue(@background));
            path = path.Replace("{colors}", PathValue(@colors));
            path = path.Replace("{percent}", PathValue(@percent));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a progress circle at a selected width and height.</summary>
        public PortalDownload GetCircleProgressSized(string @background, string @colors, int @percent, int @width, int @height)
        {
            string path = "api/v1/circles/progress/{background}/{colors}/{percent}/{width}x{height}.svg";
            path = path.Replace("{background}", PathValue(@background));
            path = path.Replace("{colors}", PathValue(@colors));
            path = path.Replace("{percent}", PathValue(@percent));
            path = path.Replace("{width}", PathValue(@width));
            path = path.Replace("{height}", PathValue(@height));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a rotating semicircle to indicate running or indeterminate progress.</summary>
        public PortalDownload GetCircleRunning(string @color)
        {
            string path = "api/v1/circles/running/{color}.svg";
            path = path.Replace("{color}", PathValue(@color));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a running indicator at a selected width and height.</summary>
        public PortalDownload GetCircleRunningSized(string @color, int @width, int @height)
        {
            string path = "api/v1/circles/running/{color}/{width}x{height}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{width}", PathValue(@width));
            path = path.Replace("{height}", PathValue(@height));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a linear gradient at 200 × 200 pixels.</summary>
        public PortalDownload GetLinearGradient(string @colors, double @angle)
        {
            string path = "api/v1/gradients/linear/{colors}/{angle}.svg";
            path = path.Replace("{colors}", PathValue(@colors));
            path = path.Replace("{angle}", PathValue(@angle));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a linear gradient at a selected width and height.</summary>
        public PortalDownload GetLinearGradientSized(string @colors, double @angle, int @width, int @height)
        {
            string path = "api/v1/gradients/linear/{colors}/{angle}/{width}x{height}.svg";
            path = path.Replace("{colors}", PathValue(@colors));
            path = path.Replace("{angle}", PathValue(@angle));
            path = path.Replace("{width}", PathValue(@width));
            path = path.Replace("{height}", PathValue(@height));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Resolve an IconKid, optionally changing its text, count or RGB colour.</summary>
        public IconPresentationResponse GetIconPresentation()
        {
            return GetIconPresentation(null);
        }

        /// <summary>Resolve an IconKid, optionally changing its text, count or RGB colour.</summary>
        public IconPresentationResponse GetIconPresentation(GetIconPresentationOptions options)
        {
            string path = "api/v1/icon/presentation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "iconKid", options.IconKid);
                path = AddQuery(path, "text", options.Text);
                path = AddQuery(path, "count", options.Count);
                path = AddQuery(path, "color", options.Color);
            }
            return (IconPresentationResponse)SendJson("GET", path, null, headers, 200, typeof(IconPresentationResponse));
        }

        /// <summary>Lists canonical icon names with an asset in the requested local set.</summary>
        public string[] GetIconAssetCatalog(string @iconSet)
        {
            string path = "api/v1/icon/catalog/{iconSet}";
            path = path.Replace("{iconSet}", PathValue(@iconSet));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (string[])SendJson("GET", path, null, headers, 200, typeof(string[]));
        }

        /// <summary>Renders Kid.Icon from a named local asset set, with Kid.Count as the badge.</summary>
        public PortalDownload GetIconFromSet(string @iconSet, string @kid, string @format)
        {
            string path = "api/v1/icon/{iconSet}/{kid}.{format}";
            path = path.Replace("{iconSet}", PathValue(@iconSet));
            path = path.Replace("{kid}", PathValue(@kid));
            path = path.Replace("{format}", PathValue(@format));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders Kid.Icon and Kid.Count from a named set at a square pixel size.</summary>
        public PortalDownload GetIconImageFromSet(string @iconSet, string @kid, int @size, string @format)
        {
            string path = "api/v1/icon/{iconSet}/{kid}/{size}.{format}";
            path = path.Replace("{iconSet}", PathValue(@iconSet));
            path = path.Replace("{kid}", PathValue(@kid));
            path = path.Replace("{size}", PathValue(@size));
            path = path.Replace("{format}", PathValue(@format));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders Kid.Icon and Kid.Count from a named set with a raster background.</summary>
        public PortalDownload GetIconImageWithBackgroundFromSet(string @iconSet, string @kid, string @backColor, int @size, string @format)
        {
            string path = "api/v1/icon/{iconSet}/{kid}/{backColor}/{size}.{format}";
            path = path.Replace("{iconSet}", PathValue(@iconSet));
            path = path.Replace("{kid}", PathValue(@kid));
            path = path.Replace("{backColor}", PathValue(@backColor));
            path = path.Replace("{size}", PathValue(@size));
            path = path.Replace("{format}", PathValue(@format));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders a responsive Kombine symbol that fits its viewport without stretching.</summary>
        public PortalDownload GetKombineLogo(string @color)
        {
            string path = "api/v1/logos/kombine/{color}.svg";
            path = path.Replace("{color}", PathValue(@color));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the square Kombine symbol at the selected width.</summary>
        public PortalDownload GetKombineLogoSized(string @color, int @width)
        {
            string path = "api/v1/logos/kombine/{color}/{width}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the Kombine symbol with an explicit background and width.</summary>
        public PortalDownload GetKombineLogoWithBackground(string @color, string @background, int @width)
        {
            string path = "api/v1/logos/kombine/{color}/{background}/{width}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{background}", PathValue(@background));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders selected parts of the Kombine symbol in its original square viewport.</summary>
        public PortalDownload GetKombineLogoParts(string @parts, string @color)
        {
            string path = "api/v1/logos/kombine/{parts}/{color}.svg";
            path = path.Replace("{parts}", PathValue(@parts));
            path = path.Replace("{color}", PathValue(@color));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders selected Kombine symbol parts at the selected width.</summary>
        public PortalDownload GetKombineLogoPartsSized(string @parts, string @color, int @width)
        {
            string path = "api/v1/logos/kombine/{parts}/{color}/{width}.svg";
            path = path.Replace("{parts}", PathValue(@parts));
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders selected Kombine symbol parts with an explicit background and width.</summary>
        public PortalDownload GetKombineLogoPartsWithBackground(string @parts, string @color, string @background, int @width)
        {
            string path = "api/v1/logos/kombine/{parts}/{color}/{background}/{width}.svg";
            path = path.Replace("{parts}", PathValue(@parts));
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{background}", PathValue(@background));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the Kombine name and registered mark, without the symbol.</summary>
        public PortalDownload GetKombineText(string @color)
        {
            string path = "api/v1/logos/kombine-text/{color}.svg";
            path = path.Replace("{color}", PathValue(@color));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the Kombine wordmark at the selected width.</summary>
        public PortalDownload GetKombineTextSized(string @color, int @width)
        {
            string path = "api/v1/logos/kombine-text/{color}/{width}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the Kombine wordmark with an explicit background and width.</summary>
        public PortalDownload GetKombineTextWithBackground(string @color, string @background, int @width)
        {
            string path = "api/v1/logos/kombine-text/{color}/{background}/{width}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{background}", PathValue(@background));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the Kombine symbol and name together.</summary>
        public PortalDownload GetKombineLogoText(string @color)
        {
            string path = "api/v1/logos/kombine-logo-text/{color}.svg";
            path = path.Replace("{color}", PathValue(@color));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the combined Kombine logo at the selected width.</summary>
        public PortalDownload GetKombineLogoTextSized(string @color, int @width)
        {
            string path = "api/v1/logos/kombine-logo-text/{color}/{width}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Renders the combined Kombine logo with an explicit background and width.</summary>
        public PortalDownload GetKombineLogoTextWithBackground(string @color, string @background, int @width)
        {
            string path = "api/v1/logos/kombine-logo-text/{color}/{background}/{width}.svg";
            path = path.Replace("{color}", PathValue(@color));
            path = path.Replace("{background}", PathValue(@background));
            path = path.Replace("{width}", PathValue(@width));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Get the portal chart's localized messages and stable state identifiers.</summary>
        public CycleChartPresentationResponse GetCycleChartPresentation()
        {
            string path = "api/v1/public/cycle-chart/presentation";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (CycleChartPresentationResponse)SendJson("GET", path, null, headers, 200, typeof(CycleChartPresentationResponse));
        }

        /// <summary>Returns the site overview's running-machine pool, refreshed at most once a minute.</summary>
        public LiveMachineResponse[] GetPublicLiveMachines()
        {
            string path = "api/v1/public/statistics/live-machines";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (LiveMachineResponse[])SendJson("GET", path, null, headers, 200, typeof(LiveMachineResponse[]));
        }

        /// <summary>List machines with a positive AutoOutOfOrder Id without login.</summary>
        public PublicMachineErrorsPage GetPublicMachineErrors()
        {
            return GetPublicMachineErrors(null);
        }

        /// <summary>List machines with a positive AutoOutOfOrder Id without login.</summary>
        public PublicMachineErrorsPage GetPublicMachineErrors(GetPublicMachineErrorsOptions options)
        {
            string path = "api/v1/public/widgets/machine-errors";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (PublicMachineErrorsPage)SendJson("GET", path, null, headers, 200, typeof(PublicMachineErrorsPage));
        }

        /// <summary>Get the ten newest photos, including Live Photo stills, newest first.</summary>
        public PublicCameraPhoto[] GetPublicRecentCameraPhotos()
        {
            string path = "api/v1/public/camera/photos";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PublicCameraPhoto[])SendJson("GET", path, null, headers, 200, typeof(PublicCameraPhoto[]));
        }

        /// <summary>Read only the JPEG thumbnail authorized by a ten-minute, tenant-bound public ticket.</summary>
        public PortalDownload GetPublicCameraThumbnail(string @id)
        {
            string path = "api/v1/public/camera/photos/{id}/thumbnail";
            path = path.Replace("{id}", PathValue(@id));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Get a square WashDoc widget's graph, machine/location names and document times.</summary>
        public PublicCycleWidgetResponse GetPublicCycleWidget()
        {
            return GetPublicCycleWidget(null);
        }

        /// <summary>Get a square WashDoc widget's graph, machine/location names and document times.</summary>
        public PublicCycleWidgetResponse GetPublicCycleWidget(GetPublicCycleWidgetOptions options)
        {
            string path = "api/v1/public/widgets/cycle";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "cycleKid", options.CycleKid);
                path = AddQuery(path, "unitKid", options.UnitKid);
            }
            return (PublicCycleWidgetResponse)SendJson("GET", path, null, headers, 200, typeof(PublicCycleWidgetResponse));
        }

        /// <summary>Draws purchase counts for the last hour in twelve five-minute intervals.</summary>
        public PortalDownload GetPublicPurchasesChart(string @color)
        {
            string path = "api/v1/public/statistics/purchases/chart/{color}.svg";
            path = path.Replace("{color}", PathValue(@color));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return SendDownload("GET", path, null, headers, 200);
        }

        /// <summary>Shows recent purchases as coin markers on a map. No login required.</summary>
        public PurchaseMapSnapshot GetPublicDisp73()
        {
            return GetPublicDisp73(null);
        }

        /// <summary>Shows recent purchases as coin markers on a map. No login required.</summary>
        public PurchaseMapSnapshot GetPublicDisp73(GetPublicDisp73Options options)
        {
            string path = "api/v1/public/displays/Map1";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "limit", options.Limit);
            }
            return (PurchaseMapSnapshot)SendJson("GET", path, null, headers, 200, typeof(PurchaseMapSnapshot));
        }

        /// <summary>Get progress for one unit or a page of all public units in a location or bank.</summary>
        public PublicScopedProgressResponse GetPublicScopedUnitProgress(string @kid)
        {
            return GetPublicScopedUnitProgress(@kid, null);
        }

        /// <summary>Get progress for one unit or a page of all public units in a location or bank.</summary>
        public PublicScopedProgressResponse GetPublicScopedUnitProgress(string @kid, GetPublicScopedUnitProgressOptions options)
        {
            string path = "api/v1/public/widgets/progress/{kid}";
            path = path.Replace("{kid}", PathValue(@kid));
            Dictionary<string, string> headers = new Dictionary<string, string>();
            if (options != null)
            {
                path = AddQuery(path, "pageSize", options.PageSize);
                path = AddQuery(path, "cursor", options.Cursor);
            }
            return (PublicScopedProgressResponse)SendJson("GET", path, null, headers, 200, typeof(PublicScopedProgressResponse));
        }

        /// <summary>Counts purchases in the site's Log1Hour without login.</summary>
        public PurchasesResponse GetPublicPurchases()
        {
            string path = "api/v1/public/statistics/purchases";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PurchasesResponse)SendJson("GET", path, null, headers, 200, typeof(PurchasesResponse));
        }

        /// <summary>Counts active users in the site's current Log7 during the last 100 days, without login.</summary>
        public ActiveUsersResponse GetPublicActiveUsers()
        {
            string path = "api/v1/public/statistics/active-users";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ActiveUsersResponse)SendJson("GET", path, null, headers, 200, typeof(ActiveUsersResponse));
        }

        /// <summary>Get localized labels and the site's palette for the shared JavaScript widgets.</summary>
        public PublicWidgetPresentationResponse GetPublicWidgetPresentation()
        {
            string path = "api/v1/public/widgets";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (PublicWidgetPresentationResponse)SendJson("GET", path, null, headers, 200, typeof(PublicWidgetPresentationResponse));
        }

        /// <summary>Counts noncancelled dated reservations that have not ended, including ongoing reservations.</summary>
        public ReservationsStatisticsResponse GetPublicReservations()
        {
            string path = "api/v1/public/statistics/reservations";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ReservationsStatisticsResponse)SendJson("GET", path, null, headers, 200, typeof(ReservationsStatisticsResponse));
        }

        /// <summary>Counts machines whose current Started is before now and Done is after now.</summary>
        public RunningMachinesResponse GetPublicRunningMachines()
        {
            string path = "api/v1/public/statistics/running-machines";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (RunningMachinesResponse)SendJson("GET", path, null, headers, 200, typeof(RunningMachinesResponse));
        }

        /// <summary>Gets public API availability. This does not check database readiness.</summary>
        public ApiStatusResponse GetPortalStatus()
        {
            string path = "api/v1/status";
            Dictionary<string, string> headers = new Dictionary<string, string>();
            return (ApiStatusResponse)SendJson("GET", path, null, headers, 200, typeof(ApiStatusResponse));
        }

    }
}
