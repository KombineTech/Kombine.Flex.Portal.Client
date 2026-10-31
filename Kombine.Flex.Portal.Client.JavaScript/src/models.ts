// Generated wire models. int64 is bigint; dates remain ISO 8601 strings.
/** A receipt assembled from this page's authorized lines. Further pages can contain more lines with the same key. */
export interface AccountDocumentResponse {
  /** key */
  "key"?: string | null;
  /** docId */
  "docId"?: number | null;
  /** lines */
  "lines"?: (AccountEntryResponse)[] | null;
  /** totals */
  "totals"?: (AccountTotal)[] | null;
}

/** One posting, with its original sign/currency and an independently authorized reversal capability. */
export interface AccountEntryResponse {
  /** kid */
  "kid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** userKid */
  "userKid"?: string | null;
  /** recordedAtUtc */
  "recordedAtUtc"?: string;
  /** amountMinor */
  "amountMinor"?: bigint;
  /** currency */
  "currency"?: string | null;
  /** description */
  "description"?: string | null;
  /** transactionType */
  "transactionType"?: string | null;
  /** period */
  "period"?: number;
  /** reversed */
  "reversed"?: boolean;
  /** reversalOfKid */
  "reversalOfKid"?: string | null;
  /** userName */
  "userName"?: string | null;
  /** userNumber */
  "userNumber"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** canReverse */
  "canReverse"?: boolean;
  /** API-computed unit icon identity, ready for the image URL. */
  "unitIconKid"?: string | null;
  /** Opaque bank-scoped receipt key, shared by lines belonging to the same document. */
  "documentKey"?: string | null;
  /** Positive decoded DocId; null for standalone, malformed or payment-managed lines. */
  "documentId"?: number | null;
  /** Identity and free text were masked by the effective retention settings. */
  "isAnonymized"?: boolean;
  /** Credit, ReserveRefund or Managed for payment-managed lines; empty otherwise. No payment IDs. */
  "paymentKind"?: string | null;
}

/** Most frequent authorized currency and the ready-to-render Forbrug icon. */
export interface AccountIconResponse {
  /** currency */
  "currency"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
}

/** Filtered postings, full-selection totals and server-resolved query defaults. No computed resident balance is implied. */
export interface AccountResponse {
  /** items */
  "items"?: (AccountEntryResponse)[] | null;
  /** units */
  "units"?: (AccountUnitResponse)[] | null;
  /** periods */
  "periods"?: (number)[] | null;
  /** totals */
  "totals"?: (AccountTotal)[] | null;
  /** from */
  "from"?: string;
  /** through */
  "through"?: string;
  /** timeZone */
  "timeZone"?: string | null;
  /** period */
  "period"?: number | null;
  /** offset */
  "offset"?: number;
  /** limit */
  "limit"?: number;
  /** hasMore */
  "hasMore"?: boolean;
  /** revision */
  "revision"?: string | null;
  /** FlexOrm-style receipt grouping of this page. Items/offset/limit remain posting-based. */
  "documents"?: (AccountDocumentResponse)[] | null;
}

/** Opaque revision of the filtered posting set; not an insertion time, cursor or access grant. */
export interface AccountRevisionResponse {
  /** revision */
  "revision"?: string | null;
}

/** AccountTotal */
export interface AccountTotal {
  /** currency */
  "currency"?: string | null;
  /** entries */
  "entries"?: bigint;
  /** amountMinor */
  "amountMinor"?: bigint;
}

/** Scoped choices for the location and machine filters. */
export interface AccountUnitResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** name */
  "name"?: string | null;
}

/** The latest event revision; no arbitrary log value can be supplied. */
export interface AcknowledgeErrorRequest {
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Accessible bank count for Enabled=1 and Deleted=0. */
export interface ActiveBankCountResponse {
  /** count */
  "count"?: bigint;
  /** Tab icon containing the authorized count. */
  "iconKid"?: string | null;
}

/** Number of accessible locations with Enabled=1 and Deleted=0, independent of search and paging. */
export interface ActiveLocationCountResponse {
  /** count */
  "count"?: bigint;
  /** Ready-to-render Locations1 icon with Count in Kid.Count. */
  "iconKid"?: string | null;
}

/** Accessible active units or terminals, independent of search and paging, with a ready-to-render navigation icon. */
export interface ActiveUnitCountResponse {
  /** count */
  "count"?: bigint;
  /** iconKid */
  "iconKid"?: string | null;
}

/** ApproveWallboardPairing */
export interface ApproveWallboardPairing {
  /** location */
  "location"?: WallboardScanLocation;
}

/** A portal link derived from an authorized API result, never from generated HTML. */
export interface AssistantLink {
  /** kid */
  "kid"?: string | null;
  /** path */
  "path"?: string | null;
  /** name */
  "name"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
}

/** A prior visible message. History is untrusted context, never authorization or evidence. */
export interface AssistantMessage {
  /** role */
  "role"?: string | null;
  /** content */
  "content"?: string | null;
}

/** A bounded question with optional visible conversation history; no tenant selector. */
export interface AssistantRequest {
  /** The required question, between 1 and 2000 characters. */
  "question": string;
  /** Optional prior visible messages; always treated as untrusted context. */
  "history"?: (AssistantMessage)[] | null;
}

/** Plain text answer, executed operation IDs and server-verified object links. */
export interface AssistantResponse {
  /** answer */
  "answer"?: string | null;
  /** operations */
  "operations"?: (string)[] | null;
  /** links */
  "links"?: (AssistantLink)[] | null;
}

/** Canonical bank identity, display metadata and stored state. */
export interface BankDirectoryItem {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** enabled */
  "enabled"?: boolean;
  /** deleted */
  "deleted"?: boolean | null;
  /** deletedAt */
  "deletedAt"?: string | null;
  /** Requested bank-level settings; null when scope does not authorize their disclosure. bankActivationCode additionally requires whole-tenant access and Bank Create. */
  "fields"?: Record<string, string | null> | null;
}

/** A bounded bank page and optional protected continuation. */
export interface BankDirectoryResponse {
  /** items */
  "items"?: (BankDirectoryItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** Selected optional field keys. Keep the same selection when following the cursor. */
  "fields"?: (string)[] | null;
  /** Whether this caller may display, search and sort bank activation codes. */
  "canReadBankActivationCode"?: boolean;
}

/** One document identity with authorized display metadata and the latest matching Cycle time. */
export interface BankDocumentItem {
  /** Canonical document KID. */
  "kid"?: string | null;
  /** Canonical location KID. */
  "locationKid"?: string | null;
  /** Canonical unit KID. */
  "unitKid"?: string | null;
  /** Current location name. */
  "locationName"?: string | null;
  /** Current unit name. */
  "unitName"?: string | null;
  /** Decoded unit type, when known. */
  "unitType"?: number | null;
  /** Latest Cycle timestamp within the requested interval, in UTC. */
  "lastActivityUtc"?: string;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "unitIconKid"?: string | null;
}

/** One bounded result page and authorized filter choices. */
export interface BankDocumentPage {
  /** Documents in descending activity order. */
  "items"?: (BankDocumentItem)[] | null;
  /** Visible, authorized locations in the bank. */
  "locations"?: (BankLocationResponse)[] | null;
  /** Visible units within the selected location scope. */
  "units"?: (DocumentUnitOption)[] | null;
  /** Effective inclusive search start. */
  "from"?: string;
  /** Effective inclusive search end. */
  "through"?: string;
  /** Effective offset. */
  "offset"?: number;
  /** Effective page size. */
  "limit"?: number;
  /** Another page existed when this query ran. */
  "hasMore"?: boolean;
}

/** Null offline means empty/incomplete status, never confirmed online. */
export interface BankIconResponse {
  /** kid */
  "kid"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** offline */
  "offline"?: boolean | null;
  /** status */
  "status"?: number;
}

/** Bounded, independently authorized bank icon results. */
export interface BankIconsResponse {
  /** items */
  "items"?: (BankIconResponse)[] | null;
}

/** Location display metadata; KID is its sole object identifier. */
export interface BankLocationResponse {
  /** Canonical site-bound location KID. */
  "kid"?: string | null;
  /** Location name, possibly empty. */
  "name"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** Bank overview location metadata with the same status fields as GetLocations. */
export interface BankLocationStatusResponse {
  /** Canonical site-bound location KID. */
  "kid"?: string | null;
  /** Location name, possibly empty. */
  "name"?: string | null;
  /** True only when the stored Enabled value is exactly 1. */
  "enabled"?: boolean;
  /** True for a positive Deleted MS2000 value; null for malformed values (visible only with a site-wide grant). */
  "deleted"?: boolean | null;
  /** UTC deletion timestamp, or null for zero or an unrepresentable value. */
  "deletedAt"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** Display metadata only, not a bank detail record or permission. */
export interface BankNavigationResponse {
  /** Canonical bank KID in this site's tenant. */
  "kid"?: string | null;
  /** Bank eSetting.Name, empty when absent. */
  "name"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** Current user settings. Missing Deleted means not deleted; Icon is an eIcon name, default user. Email and Sms are decoded from Log7 eSetting.Email and eSetting.SMS, empty when absent. Sms is the stored phone number, not a delivery operation. */
export interface BankUserResponse {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** number */
  "number"?: string | null;
  /** deletedAt */
  "deletedAt"?: string | null;
  /** locations */
  "locations"?: (UserLocationResponse)[] | null;
  /** tags */
  "tags"?: (UserTagResponse)[] | null;
  /** attributes */
  "attributes"?: (UserAttributeResponse)[] | null;
  /** email */
  "email"?: string | null;
  /** sms */
  "sms"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** A bounded ascending user page. Cursors are opaque positions, never access grants. */
export interface BankUsersResponse {
  /** items */
  "items"?: (BankUserResponse)[] | null;
  /** previousCursor */
  "previousCursor"?: string | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** scanLimitReached */
  "scanLimitReached"?: boolean;
}

/** Explicit desired operation, never a toggle that could reverse itself on retry. */
export interface BookingCommand {
  /** action */
  "action"?: string | null;
}

/** Current Log5 event. Local timestamps have no UTC offset; weekly positions have no absolute date. */
export interface BookingResponse {
  /** kid */
  "kid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** userKid */
  "userKid"?: string | null;
  /** startLocal */
  "startLocal"?: string | null;
  /** endLocal */
  "endLocal"?: string | null;
  /** weeklyMinute */
  "weeklyMinute"?: number | null;
  /** durationMinutes */
  "durationMinutes"?: number;
  /** recordedAtUtc */
  "recordedAtUtc"?: string;
  /** cancelled */
  "cancelled"?: boolean;
  /** synced */
  "synced"?: boolean;
  /** source */
  "source"?: string | null;
  /** userName */
  "userName"?: string | null;
  /** userNumber */
  "userNumber"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** canCancel */
  "canCancel"?: boolean;
  /** canRestore */
  "canRestore"?: boolean;
  /** API-computed unit icon identity, ready for the image URL. */
  "unitIconKid"?: string | null;
}

/** A canonical authorized unit identity with its localized name. */
export interface BookingRuleUnit {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
}

/** Canonical scope identifiers and localized labels for a unit filter. */
export interface BookingUnitResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** name */
  "name"?: string | null;
}

/** A bounded page; dates apply to ordinary reservation starts, while weekly entries are always included. */
export interface BookingsResponse {
  /** items */
  "items"?: (BookingResponse)[] | null;
  /** units */
  "units"?: (BookingUnitResponse)[] | null;
  /** from */
  "from"?: string;
  /** through */
  "through"?: string;
  /** offset */
  "offset"?: number;
  /** limit */
  "limit"?: number;
  /** hasMore */
  "hasMore"?: boolean;
}

/** Availability and effective capture permission for one exact authorized resource. */
export interface CameraAvailabilityResponse {
  /** hasCaptures */
  "hasCaptures"?: boolean;
  /** isDegraded */
  "isDegraded"?: boolean;
  /** canCapture */
  "canCapture"?: boolean;
}

/** One authorized capture; all object identifiers are canonical KIDs or opaque API tokens. */
export interface CameraCaptureItem {
  /** id */
  "id"?: string | null;
  /** captureId */
  "captureId"?: string | null;
  /** resourceKid */
  "resourceKid"?: string | null;
  /** ownerKid */
  "ownerKid"?: string | null;
  /** fileName */
  "fileName"?: string | null;
  /** kind */
  "kind"?: string | null;
  /** capturedAtUtc */
  "capturedAtUtc"?: string;
  /** hasPreview */
  "hasPreview"?: boolean;
  /** hasMotion */
  "hasMotion"?: boolean;
  /** hasPlayback */
  "hasPlayback"?: boolean;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
}

/** One bounded page. A degraded page may omit captures from an unavailable region; refresh from the beginning after recovery. */
export interface CameraCapturePage {
  /** items */
  "items"?: (CameraCaptureItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** isDegraded */
  "isDegraded"?: boolean;
}

/** The unchanged signed ticket returned by PrepareCameraCapture. */
export interface CameraConfirmationRequest {
  /** uploadToken */
  "uploadToken"?: string | null;
}

/** Only Confirmed=true acknowledges durable publication. ProcessingPercent is a weighted completed-stage estimate, not elapsed time; null means unknown and 100 requires confirmation. ErrorCode may report a transient processing failure. */
export interface CameraConfirmationResponse {
  /** confirmed */
  "confirmed"?: boolean;
  /** errorCode */
  "errorCode"?: string | null;
  /** processingPercent */
  "processingPercent"?: number | null;
}

/** Immutable input for recorded photo, video or a paired Live Photo; tenant and owner are never client parameters. */
export interface CameraPrepareRequest {
  /** resourceKid */
  "resourceKid"?: string | null;
  /** kind */
  "kind"?: string | null;
  /** originalFileName */
  "originalFileName"?: string | null;
  /** originalNameAvailable */
  "originalNameAvailable"?: boolean;
  /** capturedAtUtc */
  "capturedAtUtc"?: string;
  /** mediaLength */
  "mediaLength"?: bigint;
  /** mediaSha256 */
  "mediaSha256"?: string | null;
  /** Available device observations with source, time and units; use an empty object when unavailable. Never include API credentials. */
  "sensorData"?: unknown;
  /** motionLength */
  "motionLength"?: bigint | null;
  /** motionSha256 */
  "motionSha256"?: string | null;
}

/** Opaque signed ticket; retry with this exact token and unchanged original bytes. */
export interface CameraPrepareResponse {
  /** uploadToken */
  "uploadToken"?: string | null;
}

/** Display metadata for the exact authorized camera resource, without parent or child data. */
export interface CameraResourceResponse {
  /** Canonical, site-bound bank, location or unit identity. */
  "resourceKid"?: string | null;
  /** Resource display name; unit localization placeholders are resolved. */
  "name"?: string | null;
  /** API-computed icon identity including the resource number; use unchanged in icon URLs. */
  "iconKid"?: string | null;
  /** True for locations and units; false for banks. Advisory only. */
  "requiresProximityCheck"?: boolean;
  /** Nullable location latitude in decimal degrees, inherited by units. */
  "latitude"?: number | null;
  /** Nullable location longitude in decimal degrees, inherited by units. */
  "longitude"?: number | null;
}

/** A complete media set exists in at least one region; the second copy continues independently. */
export interface CameraSaveResponse {
  /** captureId */
  "captureId"?: string | null;
  /** resourceKid */
  "resourceKid"?: string | null;
}

/** One bank schedule or location processing row. Processing is null for a bank-wide row. */
export interface ChecklistItem {
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** period */
  "period"?: number;
  /** isLatest */
  "isLatest"?: boolean;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** hardware */
  "hardware"?: string | null;
  /** periodDateUtc */
  "periodDateUtc"?: string | null;
  /** nextSettlementUtc */
  "nextSettlementUtc"?: string | null;
  /** lastRunUtc */
  "lastRunUtc"?: string | null;
  /** updatedAtUtc */
  "updatedAtUtc"?: string | null;
  /** hidden */
  "hidden"?: boolean;
  /** onChecklist */
  "onChecklist"?: boolean;
  /** scheduleStatus */
  "scheduleStatus"?: string | null;
  /** processing */
  "processing"?: ChecklistProcessing;
}

/** A bounded checklist page; only read operations are supported. */
export interface ChecklistPage {
  /** items */
  "items"?: (ChecklistItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** readAtUtc */
  "readAtUtc"?: string;
}

/** The four independently stored processing states; no financial amounts. */
export interface ChecklistProcessing {
  /** invoice */
  "invoice"?: ChecklistStatus;
  /** soapInvoice */
  "soapInvoice"?: ChecklistStatus;
  /** soapCredit */
  "soapCredit"?: ChecklistStatus;
  /** easyPay */
  "easyPay"?: ChecklistStatus;
}

/** Stored code and enum-derived state; null state means unknown, never success. */
export interface ChecklistStatus {
  /** code */
  "code"?: number | null;
  /** state */
  "state"?: string | null;
}

/** Site database access indicator, never a manager permission or a guarantee for a business operation. */
export interface DatabaseAccessResponse {
  /** True: Log7 read/append privilege check succeeded. False: read succeeds but the write connection is absent, denies access or is read-only. Null: status could not be determined. Checks shared Log7 and bank-zero Log7 history only; bank grants, triggers and transactions may differ. */
  "canWrite"?: boolean | null;
  /** When this cached check was started. Known results are cached for ten minutes; unknown results for one minute. */
  "checkedAtUtc"?: string;
}

/** The complete number of rows matching the authorized export selection. */
export interface DirectoryExportCountResponse {
  /** count */
  "count"?: bigint;
}

/** Finite numeric interpretation alongside original text; calculated values have no original text. */
export interface DocumentCell {
  /** value */
  "value"?: number | null;
  /** text */
  "text"?: string | null;
  /** isCalculated */
  "isCalculated"?: boolean;
}

/** Stable enum column metadata; kind is state or setting. */
export interface DocumentColumn {
  /** kind */
  "kind"?: string | null;
  /** name */
  "name"?: string | null;
  /** localization */
  "localization"?: string | null;
  /** color */
  "color"?: string | null;
  /** onlyNumericValues */
  "onlyNumericValues"?: boolean;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** An existing same-unit document identified by its canonical KID and latest tagged Cycle timestamp. */
export interface DocumentNeighbor {
  /** kid */
  "kid"?: string | null;
  /** lastActivityUtc */
  "lastActivityUtc"?: string;
}

/** Previous (higher numeric Doc ID) and next (lower numeric Doc ID) documents. Null means no document exists in that direction. */
export interface DocumentNeighbors {
  /** previous */
  "previous"?: DocumentNeighbor;
  /** next */
  "next"?: DocumentNeighbor;
}

/** Only columns with data are returned, with values indexed by column position. A missing cell is null; a stored null is a cell with null text/value. */
export interface DocumentTable {
  /** cycleKid */
  "cycleKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** finished */
  "finished"?: boolean;
  /** fromMs2000 */
  "fromMs2000"?: bigint;
  /** toMs2000 */
  "toMs2000"?: bigint;
  /** columns */
  "columns"?: (DocumentColumn)[] | null;
  /** rows */
  "rows"?: (DocumentTableRow)[] | null;
}

/** One exact MS2000 timestamp with cells in column order. */
export interface DocumentTableRow {
  /** ms2000 */
  "ms2000"?: bigint;
  /** cells */
  "cells"?: (DocumentCell)[] | null;
}

/** Visible unit filter choice. */
export interface DocumentUnitOption {
  /** Canonical unit KID. */
  "kid"?: string | null;
  /** Canonical location KID. */
  "locationKid"?: string | null;
  /** Current unit name. */
  "name"?: string | null;
  /** Decoded unit type, when known. */
  "unitType"?: number | null;
}

/** Previous UTC day's total; Bytes is an unsigned decimal string to preserve uint64 precision. */
export interface HostingBandwidth {
  /** dateUtc */
  "dateUtc"?: string;
  /** bytes */
  "bytes"?: string | null;
  /** errorCode */
  "errorCode"?: string | null;
}

/** A bounded snapshot of shared application runtime output, for designated operators only. */
export interface HostingLogsResponse {
  /** beta or production. */
  "environment"?: string | null;
  /** portal-api, equipment-api or portal-web. */
  "application"?: string | null;
  /** Time of the provider snapshot, not the event timestamp. */
  "fetchedAtUtc"?: string;
  /** At most 100 plain-text lines; untrusted output, never HTML. */
  "lines"?: (string)[] | null;
  /** True when the local byte/line bound removed content. */
  "truncated"?: boolean;
}

/** A metric in percent or count, kept separate by component and instance; failures have no series. */
export interface HostingMetric {
  /** name */
  "name"?: string | null;
  /** unit */
  "unit"?: string | null;
  /** series */
  "series"?: (HostingSeries)[] | null;
  /** errorCode */
  "errorCode"?: string | null;
}

/** One authorized app/cluster hosting snapshot; never a customer's individual consumption. */
export interface HostingMetricsResponse {
  /** environment */
  "environment"?: string | null;
  /** application */
  "application"?: string | null;
  /** fromUtc */
  "fromUtc"?: string;
  /** toUtc */
  "toUtc"?: string;
  /** fetchedAtUtc */
  "fetchedAtUtc"?: string;
  /** refreshAfterSeconds */
  "refreshAfterSeconds"?: number;
  /** metrics */
  "metrics"?: (HostingMetric)[] | null;
  /** bandwidth */
  "bandwidth"?: HostingBandwidth;
}

/** A UTC measurement; null means a gap or a non-finite provider sample, never zero. */
export interface HostingPoint {
  /** timestampUtc */
  "timestampUtc"?: string;
  /** value */
  "value"?: number | null;
}

/** Provider component and instance labels are display text, never resource grants. */
export interface HostingSeries {
  /** component */
  "component"?: string | null;
  /** instance */
  "instance"?: string | null;
  /** points */
  "points"?: (HostingPoint)[] | null;
}

/** Authorized installer details and display hints for icon editing. Hints never authorize writes. */
export interface InstallerDetailsResponse {
  /** installer */
  "installer"?: InstallerDirectoryItem;
  /** canEditIcon */
  "canEditIcon"?: boolean;
  /** iconRevision */
  "iconRevision"?: string | null;
  /** availableIcons */
  "availableIcons"?: (string)[] | null;
}

/** Installer metadata from the site's Log7 with BankId=TenantId. Kid is canonical with type Installer; clients can derive the display UserId from it. Missing Enabled is null. DeletedAt and LastActiveAt are UTC; LastActiveAt is the Alive krumb's MS2000, not its Text. Passwords are never returned. */
export interface InstallerDirectoryItem {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** email */
  "email"?: string | null;
  /** locations */
  "locations"?: (InstallerLocationResponse)[] | null;
  /** tags */
  "tags"?: (InstallerTagResponse)[] | null;
  /** deleted */
  "deleted"?: boolean;
  /** deletedAt */
  "deletedAt"?: string | null;
  /** enabled */
  "enabled"?: boolean | null;
  /** lastActiveAt */
  "lastActiveAt"?: string | null;
  /** User activation code, only when explicitly requested with Installer Create permission. */
  "activationCode"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** One installer page. Continue until NextCursor is null, even if Items is empty. */
export interface InstallerDirectoryResponse {
  /** items */
  "items"?: (InstallerDirectoryItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
}

/** Desired exact Person icon and the opaque revision from GetInstaller. */
export interface InstallerIconRequest {
  /** icon */
  "icon": string | null;
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Authoritative committed icon; update UI only after a complete successful response. */
export interface InstallerIconResponse {
  /** kid */
  "kid"?: string | null;
  /** iconRevision */
  "iconRevision"?: string | null;
  /** availableIcons */
  "availableIcons"?: (string)[] | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** Stored location association in the installer's tenant bank, with Access/NoAccess state. Metadata only, never an authorization grant for the caller. Names are not looked up. */
export interface InstallerLocationResponse {
  /** kid */
  "kid"?: string | null;
  /** state */
  "state"?: string | null;
}

/** Stored tag association, including locked/deleted/history states; state is the eTagState name. */
export interface InstallerTagResponse {
  /** kid */
  "kid"?: string | null;
  /** state */
  "state"?: string | null;
}

/** One server card; errors contain no transport details. */
export interface LiveLogCard {
  /** Fixed server selector. */
  "server"?: string | null;
  /** Null on success; otherwise live-logs-not-configured or live-logs-unavailable. */
  "errorCode"?: string | null;
  /** Newest events first; at most 100. */
  "events"?: (LiveLogEvent)[] | null;
}

/** One sanitized event from the bounded process-local buffer. */
export interface LiveLogEvent {
  /** UTC event time. */
  "timestamp"?: string;
  /** Logging severity. */
  "level"?: string | null;
  /** Static message template, not arbitrary state. */
  "message"?: string | null;
  /** Logger category. */
  "category"?: string | null;
  /** Optional HTTP result. */
  "statusCode"?: number | null;
  /** Optional server processing time. */
  "elapsedMilliseconds"?: bigint | null;
  /** Authorized diagnostic bank identifier. */
  "bankId"?: number | null;
  /** Authorized requested resident identifiers. */
  "userIds"?: (number)[] | null;
  /** Correlation identifier. */
  "traceId"?: string | null;
  /** Optional approved chat question text, at most 2000 characters. */
  "question"?: string | null;
  /** Sanitized structured values for message-template placeholders. */
  "fields"?: Record<string, unknown> | null;
}

/** Authorized current-tenant snapshot for three server cards. */
export interface LiveLogsResponse {
  /** Canonical tenant KID. */
  "tenantKid"?: string | null;
  /** UTC snapshot time. */
  "fetchedAtUtc"?: string;
  /** Minimum polling interval. */
  "refreshAfterSeconds"?: number;
  /** Portal API, Equipment API and Portal Web. */
  "servers"?: (LiveLogCard)[] | null;
}

/** DayOfWeek is 0=Sunday through 6=Saturday; times are relative to this day's midnight. */
export interface LocationBookingCalendarDayResponse {
  /** dayOfWeek */
  "dayOfWeek"?: number;
  /** slots */
  "slots"?: (LocationBookingCalendarSlotResponse)[] | null;
  /** date */
  "date"?: string;
}

/** Units with the same valid stored calendar identity and effective dated schedule; status is Configured. */
export interface LocationBookingCalendarGroup {
  /** units */
  "units"?: (LocationBookingCalendarUnit)[] | null;
  /** status */
  "status"?: string | null;
  /** days */
  "days"?: (LocationBookingCalendarDayResponse)[] | null;
}

/** Local wall-clock minutes; Type is 0=reservation period, 1=chance period, 2=closed, 3=unknown. */
export interface LocationBookingCalendarSlotResponse {
  /** startMinute */
  "startMinute"?: number;
  /** durationMinutes */
  "durationMinutes"?: number;
  /** type */
  "type"?: number;
}

/** Authorized canonical unit KID and localized plain-text name. */
export interface LocationBookingCalendarUnit {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
}

/** The authorized location's effective dated calendars; no occupancy or booking rights. */
export interface LocationBookingCalendarsResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** groups */
  "groups"?: (LocationBookingCalendarGroup)[] | null;
  /** timeZone */
  "timeZone"?: string | null;
  /** from */
  "from"?: string;
  /** days */
  "days"?: number;
}

/** Stable code, localized plain text and whether the row needs attention. Never HTML. */
export interface LocationBookingRule {
  /** code */
  "code"?: string | null;
  /** text */
  "text"?: string | null;
  /** warning */
  "warning"?: boolean;
  /** Optional ordered plain-text parts. Concatenate text without separators to reproduce Text; clients may emphasize values. Fall back to Text when parts are absent or empty. Never markup. */
  "parts"?: (LocationBookingRulePart)[] | null;
}

/** Localized heading/help, authorized units and rules for a compact display section. */
export interface LocationBookingRuleGroup {
  /** name */
  "name"?: string | null;
  /** units */
  "units"?: (BookingRuleUnit)[] | null;
  /** rules */
  "rules"?: (LocationBookingRule)[] | null;
  /** common */
  "common"?: boolean;
  /** Optional localized explanation of how the section applies to its units. */
  "help"?: string | null;
}

/** Plain text and a semantic value flag; presentation is the client's responsibility. */
export interface LocationBookingRulePart {
  /** text */
  "text"?: string | null;
  /** isValue */
  "isValue"?: boolean;
}

/** Authorized configured booking rules, observed at calculatedAt. Not a booking availability decision. */
export interface LocationBookingRulesResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** calculatedAt */
  "calculatedAt"?: string;
  /** groups */
  "groups"?: (LocationBookingRuleGroup)[] | null;
}

/** Exact number of locations matching the authorized, filtered directory at count time. */
export interface LocationCountResponse {
  /** count */
  "count"?: bigint;
}

/** Bank and location identifiers are canonical KIDs. Activation codes are null without the required Create permission and scope. */
export interface LocationDirectoryItem {
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** name */
  "name"?: string | null;
  /** vismaCustNo */
  "vismaCustNo"?: string | null;
  /** bankActivationCode */
  "bankActivationCode"?: string | null;
  /** locationActivationCode */
  "locationActivationCode"?: string | null;
  /** enabled */
  "enabled"?: boolean;
  /** deleted */
  "deleted"?: boolean | null;
  /** deletedAt */
  "deletedAt"?: string | null;
  /** address */
  "address"?: string | null;
  /** zip */
  "zip"?: string | null;
  /** longitude */
  "longitude"?: number | null;
  /** latitude */
  "latitude"?: number | null;
  /** teltonikaSms */
  "teltonikaSms"?: string | null;
  /** alternativeBankName */
  "alternativeBankName"?: string | null;
  /** mask */
  "mask"?: string | null;
  /** timeZone */
  "timeZone"?: string | null;
  /** online */
  "online"?: boolean | null;
  /** lastContactAt */
  "lastContactAt"?: string | null;
  /** vismaCrAcNo */
  "vismaCrAcNo"?: string | null;
  /** vismaInvoiceVersion */
  "vismaInvoiceVersion"?: string | null;
  /** vismaOrdre */
  "vismaOrdre"?: string | null;
  /** vismaPNTurnover */
  "vismaPNTurnover"?: string | null;
  /** vismaPNSettlement */
  "vismaPNSettlement"?: string | null;
  /** vismaSettlement */
  "vismaSettlement"?: string | null;
  /** vismaVAT */
  "vismaVAT"?: string | null;
  /** vismaServiceKey */
  "vismaServiceKey"?: string | null;
  /** vismaStart */
  "vismaStart"?: string | null;
  /** vismaNote */
  "vismaNote"?: string | null;
  /** hiddenNote */
  "hiddenNote"?: string | null;
  /** vismaGuaranteeMonth */
  "vismaGuaranteeMonth"?: string | null;
  /** vismaGuaranteeUnder */
  "vismaGuaranteeUnder"?: string | null;
  /** vismaGuarantee */
  "vismaGuarantee"?: string | null;
  /** vismaGuaranteeCustomer */
  "vismaGuaranteeCustomer"?: string | null;
  /** vismaGuaranteeOver */
  "vismaGuaranteeOver"?: string | null;
  /** gift */
  "gift"?: string | null;
  /** giftBegin */
  "giftBegin"?: string | null;
  /** giftEnd */
  "giftEnd"?: string | null;
  /** giftSplit */
  "giftSplit"?: string | null;
  /** giftPN */
  "giftPN"?: string | null;
  /** soapEnd */
  "soapEnd"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "bankIconKid"?: string | null;
}

/** One authorized location page. Continue with NextCursor until null. */
export interface LocationDirectoryResponse {
  /** items */
  "items"?: (LocationDirectoryItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** hasAllBanksAccess */
  "hasAllBanksAccess"?: boolean;
  /** fields */
  "fields"?: (string)[] | null;
}

/** Null offline means empty or incomplete status, never a confirmed online location. */
export interface LocationIconResponse {
  /** kid */
  "kid"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** offline */
  "offline"?: boolean | null;
  /** status */
  "status"?: number;
}

/** Bounded lazy location icon lookup with independently authorized results. */
export interface LocationIconsResponse {
  /** items */
  "items"?: (LocationIconResponse)[] | null;
}

/** A location's authorized schedules, calculated at an instant in its local time zone. */
export interface LocationOpeningHoursResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** timeZone */
  "timeZone"?: string | null;
  /** calculatedAt */
  "calculatedAt"?: string;
  /** groups */
  "groups"?: (OpeningHoursGroup)[] | null;
}

/** Unit KID, local epoch start minute, absolute duration, UTC event revision and cancellation state. */
export interface LocationReservationHistoryItem {
  /** unitKid */
  "unitKid"?: string | null;
  /** startMinute */
  "startMinute"?: number;
  /** durationMinutes */
  "durationMinutes"?: number;
  /** revision */
  "revision"?: bigint;
  /** cancelled */
  "cancelled"?: boolean;
  /** userNumber */
  "userNumber"?: string | null;
  /** userName */
  "userName"?: string | null;
  /** userKid */
  "userKid"?: string | null;
}

/** Bank reservation history with resident display metadata. */
export interface LocationReservationHistoryResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** from */
  "from"?: string;
  /** days */
  "days"?: number;
  /** items */
  "items"?: (LocationReservationHistoryItem)[] | null;
}

/** Unit KID, local epoch/weekly start minute and positive duration. No slot rounding. */
export interface LocationReservationResponse {
  /** unitKid */
  "unitKid"?: string | null;
  /** startMinute */
  "startMinute"?: number;
  /** durationMinutes */
  "durationMinutes"?: number;
  /** userNumber */
  "userNumber"?: string | null;
  /** userName */
  "userName"?: string | null;
  /** userKid */
  "userKid"?: string | null;
}

/** Current active reservations, independent of calendar configuration, with resident display metadata. */
export interface LocationReservationsResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** from */
  "from"?: string;
  /** days */
  "days"?: number;
  /** items */
  "items"?: (LocationReservationResponse)[] | null;
}

/** An authorized location and its visible unit list. */
export interface LocationUnitsResponse {
  /** location */
  "location"?: BankLocationResponse;
  /** items */
  "items"?: (UnitOverviewResponse)[] | null;
}

/** Open-Meteo model conditions. Times are UTC; units are explicit in measurement names. */
export interface LocationWeatherCurrent {
  /** observedAtUtc */
  "observedAtUtc"?: string;
  /** retrievedAtUtc */
  "retrievedAtUtc"?: string;
  /** temperatureCelsius */
  "temperatureCelsius"?: number;
  /** apparentTemperatureCelsius */
  "apparentTemperatureCelsius"?: number | null;
  /** windSpeedMetresPerSecond */
  "windSpeedMetresPerSecond"?: number | null;
  /** precipitationMillimetres */
  "precipitationMillimetres"?: number | null;
  /** relativeHumidityPercent */
  "relativeHumidityPercent"?: number | null;
  /** weatherCode */
  "weatherCode"?: number | null;
  /** isDay */
  "isDay"?: boolean | null;
}

/** Weather for one authorized location. Null measurements mean unknown, never zero. */
export interface LocationWeatherResponse {
  /** locationKid */
  "locationKid"?: string | null;
  /** status */
  "status"?: string | null;
  /** address */
  "address"?: string | null;
  /** zip */
  "zip"?: string | null;
  /** positionSource */
  "positionSource"?: string | null;
  /** Current conditions, or null unless status is Available. */
  "current"?: LocationWeatherCurrent | null;
}

/** The canonical KID of the newly activated empty administrator. */
export interface ManagerCreationResponse {
  /** kid */
  "kid"?: string | null;
}

/** Read-only metadata from current bank-zero Log7 settings. Describes the listed manager, never grants the caller permissions. No credentials are returned. */
export interface ManagerDirectoryItem {
  /** Canonical manager KID belonging to the API site, bank zero. */
  "kid"?: string | null;
  /** Decoded display name; empty when absent. */
  "name"?: string | null;
  /** Decoded eSetting.Email; empty when absent. */
  "email"?: string | null;
  /** Recognized grants on this site; omitted stored tenants are resolved. An identifier never grants access. */
  "resourceGrants"?: (ManagerResourceGrantResponse)[] | null;
  /** Recognized eTab grants in AttributeMetaSortOrder, then numeric ID order. These are page grants, not effective operation permissions. */
  "tabs"?: (ManagerTabResponse)[] | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
  /** Optional Gravatar image URL when Email is valid; preferred over the stored icon. Uses SHA256, 96px, G rating and d=404; fall back to IconKid on image failure. Browser requests disclose the email hash and client IP to Gravatar. */
  "gravatarUrl"?: string | null;
  /** Decoded eSetting.Organisation, empty when absent. */
  "organisation"?: string | null;
  /** True for Enabled=1, false for 0, null for absent or invalid settings. This field alone does not establish account usability. */
  "enabled"?: boolean | null;
  /** Whether eSetting.Deleted contains a positive deletion timestamp. Deleted rows require the caller's retention allowance. */
  "deleted"?: boolean;
  /** Deletion time in UTC, or null for a non-deleted manager. */
  "deletedAt"?: string | null;
  /** Last recorded activity in UTC, from the current eSetting.Alive Log7 row's MS2000 (milliseconds since 2000-01-01 UTC), not Text. Null when absent, nonpositive or outside the supported date range. Reading the directory does not update activity. */
  "lastActiveAt"?: string | null;
  /** The listed manager's six independent Permission*2 masks, including Installer, with the same semantics as GetCurrentManager. Missing/empty values default to Read; malformed values grant nothing. Combine with account state, Tabs and resource grants. */
  "operationPermissions"?: (ManagerOperationPermissionResponse)[] | null;
  /** The listed manager's RetentionDays: days of visibility after deletion for otherwise authorized records. Missing values default to 10; invalid or negative values become zero. Explicit zero is preserved. Does not alter the caller's retention or schedule deletion. */
  "retentionDays"?: number;
  /** Whether this record belongs to the caller. Own permission edits require the sole active tenant-wide manager exception. */
  "isCurrentManager"?: boolean;
  /** Caller has Managers Write and this is another administrator or the caller is the sole active tenant-wide manager. Display hint only: every write reauthorizes from current Log7. */
  "canEditPermissions"?: boolean;
  /** Whether the caller may edit this manager's Tabs, under the same policy as permission editing. A display hint only. */
  "canEditTabs"?: boolean;
  /** Whether the caller may change Name, Organisation, Enabled, Deleted, RetentionDays, Icon and Email. Same fresh authorization and own-card exception as permission editing. */
  "canEditProfile"?: boolean;
  /** Opaque revision of all seven profile settings; send unchanged to SetManagerProfileField. */
  "profileRevision"?: string | null;
  /** Opaque concurrency revision of the complete stored Tabs value; copy unchanged to SetManagerTab. */
  "tabsRevision"?: string | null;
  /** Opaque revision of the complete stored Kids setting; send unchanged to SetManagerKid. */
  "kidsRevision"?: string | null;
  /** Whether the caller may edit resource grants. Uses the same policy and own-card exception as other manager changes. */
  "canEditKids"?: boolean;
  /** GetManager only: every known eTab except None/Length, numeric aliases deduplicated, ordered by metadata then ID. These are choices, not grants or a list of implemented portal pages. */
  "availableTabs"?: (ManagerTabResponse)[] | null;
  /** GetManager only: unique eIcon names with eIconSubject.Person metadata, in numeric enum order. The current display icon is prepended if outside this catalog; legacy values are display-only, not new assignments. */
  "availableIcons"?: (string)[] | null;
}

/** One authorized page in the requested order. Follow NextCursor even when Items is empty. */
export interface ManagerDirectoryResponse {
  /** At most pageSize visible manager records. Disabled accounts are included; deleted accounts follow requester retention. */
  "items"?: (ManagerDirectoryItem)[] | null;
  /** Opaque continuation bound to caller, site, page size, filter, sort and direction, or null when finished. Never decode it. */
  "nextCursor"?: string | null;
}

/** Another visible administrator sharing the source email; KID is canonical and tenant-bound. */
export interface ManagerEmailMatch {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** API-computed icon identity used when Gravatar is missing or unavailable. */
  "iconKid"?: string | null;
  /** Preferred optional Gravatar URL, with the same semantics as GetManager. */
  "gravatarUrl"?: string | null;
}

/** Requests a recovery email on this API's tenant. Never log the body. */
export interface ManagerForgotPasswordRequest {
  /** The manager's existing login address, not the temporary delivery override. */
  "email": string;
  /** Email language: en (default), da or es. */
  "language"?: string | null;
}

/** Confirms the profile version shown when sending an invitation; the caller cannot override the recipient or link host. */
export interface ManagerInvitationRequest {
  /** The profileRevision returned by GetManager or the last confirmed profile save. */
  "expectedRevision": string;
  /** Email language: en (default), da or es. */
  "language"?: string | null;
}

/** An invitation was committed to the asynchronous mail queue; it does not confirm delivery. */
export interface ManagerInvitationResponse {
  /** code */
  "code"?: string | null;
}

/** Assign or remove a canonical tenant, bank or location grant. */
export interface ManagerKidChangeRequest {
  /** Canonical KID on this site. Tenant means all banks; Bank means its entire bank; Location means only that location. */
  "resourceKid": string | null;
  /** Required: true adds access; false removes this exact scope. */
  "enabled"?: boolean | null;
  /** Required kidsRevision from GetManager or the latest acknowledged SetManagerKid response. */
  "expectedRevision": string | null;
}

/** Authoritative site grants and next revision; CanEditKids=false means lock the entire editor. */
export interface ManagerKidChangeResponse {
  /** resourceGrants */
  "resourceGrants"?: (ManagerResourceGrantResponse)[] | null;
  /** kidsRevision */
  "kidsRevision"?: string | null;
  /** canEditKids */
  "canEditKids"?: boolean;
}

/** A known account-state reason returned only after verifying the manager's password. */
export interface ManagerLoginErrorResponse {
  /** The disabled, deleted, or account-settings reason; never stored values or credentials. */
  "code"?: string | null;
}

/** Exactly one manager credential pair submitted over HTTPS. Never log this body. */
export interface ManagerLoginRequest {
  /** Manager email for password login. */
  "email"?: string | null;
  /** Original manager password. */
  "password"?: string | null;
  /** Manager login username from Kid.ToUserId (tenant.0-userId), or canonical bank-zero manager KID, on this API's tenant. */
  "kid"?: string | null;
  /** Original case-sensitive API key, never its hash. */
  "apiKey"?: string | null;
}

/** A resource category's independent ePermission2 flags. */
export interface ManagerOperationPermissionResponse {
  /** Managers, Bank, Location, Unit, User, Installer, Service, Tabs or Kids. Match by resource name, not array position. */
  "resource"?: string | null;
  /** Enum text (possibly numeric for combinations), or null for invalid values. Use flags and capability booleans; missing values become Read. */
  "level"?: string | null;
  /** Whether reading is permitted at this operation level. */
  "canRead"?: boolean;
  /** Whether modification is permitted at this operation level. */
  "canWrite"?: boolean;
  /** Whether creation is permitted at this operation level. */
  "canCreate"?: boolean;
  /** Numeric bitmask: Read=1, Write=2, Create=4, Delete=8, RenameExtrenatId=16, Rename=32. None=0; null is invalid. */
  "flags"?: number | null;
  /** Whether Delete is explicitly granted. */
  "canDelete"?: boolean;
  /** Whether RenameExtrenatId is explicitly granted. */
  "canRenameExternalId"?: boolean;
  /** Whether Rename is explicitly granted. */
  "canRename"?: boolean;
}

/** A language-independent recovery result; never identifies a matching account. */
export interface ManagerPasswordResetResponse {
  /** code */
  "code"?: string | null;
}

/** Change one independent operation bit using the last displayed flags for concurrency. */
export interface ManagerPermissionChangeRequest {
  /** Exactly one ePermission2 bit (1, 2, 4, 8, 16 or 32), required. */
  "flag"?: number | null;
  /** The desired state of that bit, required. */
  "enabled"?: boolean | null;
  /** Required, including explicit null for an invalid stored mask. Read from GetManager. */
  "expectedFlags": number | null;
}

/** Apply a server-defined role to the complete permission matrix. */
export interface ManagerPermissionRoleRequest {
  /** accounting, caretaker, operator, technical-support, tenant-installer, tenant-accounting or combine; case-sensitive, required. */
  "role": string | null;
  /** Exactly Managers, Installer, Service, Bank, Location, Unit, User, Tabs and Kids with last displayed flags. Explicit null represents an invalid stored mask. */
  "expectedFlags": Record<string, number | null> | null;
  /** Required for accounting and combine: tabsRevision from GetManager or the last acknowledged edit. */
  "expectedTabsRevision"?: string | null;
  /** Required for combine: kidsRevision from GetManager or the last acknowledged edit. */
  "expectedKidsRevision"?: string | null;
}

/** The acknowledged preset and complete persisted permission matrix. */
export interface ManagerPermissionRoleResponse {
  /** The applied preset identity. */
  "role"?: string | null;
  /** All nine authoritative permission categories. */
  "operationPermissions"?: (ManagerOperationPermissionResponse)[] | null;
  /** False when applying the role to yourself removes the required Managers permissions. */
  "canEditPermissions"?: boolean;
  /** Complete recognized selected tabs after the atomic role assignment. */
  "tabs"?: (ManagerTabResponse)[] | null;
  /** Revision for the next tab or role edit. */
  "tabsRevision"?: string | null;
  /** False when the change removes your required Managers access. */
  "canEditTabs"?: boolean;
  /** Authoritative resource grants after the role assignment. */
  "resourceGrants"?: (ManagerResourceGrantResponse)[] | null;
  /** Revision for the next resource-grant edit. */
  "kidsRevision"?: string | null;
  /** Whether the caller retains permission to edit resource grants. */
  "canEditKids"?: boolean;
}

/** One desired profile value plus the profile revision last shown to the caller. */
export interface ManagerProfileChangeRequest {
  /** Name/Organisation: string, maximum 200 characters, no controls. Enabled/Deleted: boolean. RetentionDays: integer 0 through 2147483647. Icon: exact eIcon name with eIconSubject.Person metadata. Email: one nonempty address, maximum 254 characters, no whitespace or controls. */
  "value": unknown;
  /** Required opaque profileRevision returned by GetManager or the previous successful edit. */
  "expectedRevision": string | null;
}

/** Authoritative profile after a confirmed save. A false CanEditProfile locks all editor controls. */
export interface ManagerProfileChangeResponse {
  /** The changed field's stable eSetting name. */
  "field": string | null;
  /** Saved display name. */
  "name": string | null;
  /** Saved organisation. */
  "organisation": string | null;
  /** Saved login email address. Changing it does not send an invitation or change the password. */
  "email": string | null;
  /** Saved icon identifier. New assignments accept only eIcon names with eIconSubject.Person metadata. */
  "iconKid": string | null;
  /** Optional Gravatar fallback; same semantics as GetManager. Refresh after Email or Icon changes. */
  "gravatarUrl"?: string | null;
  /** Person icon choices; the current display icon is first when it is outside that catalog. */
  "availableIcons"?: (string)[] | null;
  /** Saved Enabled state; null for an unchanged absent/invalid value. */
  "enabled"?: boolean | null;
  /** True when the saved deletion timestamp is positive. */
  "deleted"?: boolean;
  /** Exact stored deletion value: 0 or milliseconds since 2000-01-01 UTC. Not a Unix timestamp or boolean. */
  "deletedMs2000"?: bigint;
  /** Deletion time in UTC, null when DeletedMs2000 is zero. */
  "deletedAt"?: string | null;
  /** Saved visibility window for deleted records. */
  "retentionDays"?: number;
  /** Revision for the next profile edit. */
  "profileRevision": string | null;
  /** False after disabling/deleting yourself, or when deletion hides the target under caller retention. */
  "canEditProfile"?: boolean;
}

/** The authenticated manager's current display values and permission summary for this site. */
export interface ManagerProfileResponse {
  /** The manager ID. Treat it as an opaque, case-sensitive string: store and send it unchanged; do not decode or construct it. An ID does not grant access. */
  "kid"?: string | null;
  /** The manager's display name. */
  "name"?: string | null;
  /** Permitted eTab IDs, not flags. An empty array means no Tabs; it does not prevent login. */
  "tabs"?: (number)[] | null;
  /** Whether at least one bank/location grant applies on this site. */
  "hasBankAccess"?: boolean;
  /** Exact approved display ID for a read-only Wallboard session, resolved from its device record. Null for ordinary managers. */
  "wallboardDisplayId"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
  /** databaseAccess */
  "databaseAccess"?: DatabaseAccessResponse;
  /** Navigation labels from Log24 for explicitly scoped banks (including parents of granted locations). Requires Tabs and Bank Read. Empty for tenant-wide access. These labels do not grant bank-wide access; use resourceGrants. Names/icons are cached for one minute. */
  "navigationBanks"?: (BankNavigationResponse)[] | null;
  /** Optional organisation display text. Empty when absent; never an access grant. */
  "organisation"?: string | null;
  /** Optional API-computed Gravatar URL from the current manager's email. Prefer over IconKid; fall back on image failure. Uses SHA256, 96px, G rating and d=404. Direct browser requests disclose the email hash and client IP to Gravatar. */
  "gravatarUrl"?: string | null;
  /** Days after deletion that an otherwise authorized bank, location, unit, user or reservation remains visible. Zero hides deleted objects; missing settings default to 10 days; invalid settings default to zero. Does not grant access or schedule physical deletion. */
  "retentionDays"?: number;
  /** themeMode */
  "themeMode"?: EThemeMode;
  /** Preferred icon set: g or line. Missing or unsupported stored values return line; an explicit g is preserved. This grants no permissions. */
  "iconSet"?: string | null;
  /** Personal eLanguage identity; null follows browser/tenant policy. Danish is zero. */
  "language"?: number | null;
  /** Allowlisted short-date pattern; empty follows the language. */
  "dateFormat"?: string | null;
  /** Number-format culture; empty follows the language. Does not change currency. */
  "numberFormat"?: string | null;
  /** Personal table/list vertical spacing factor: 0.75, 1, 1.25, 1.5, 1.75 or 2. Missing/invalid values use 1. */
  "lineSpacing"?: number;
  /** Maximum workspace banks; null means unlimited. This display preference grants no access. */
  "portalMaxOpenBanks"?: number | null;
  /** Names and IDs from the shared eTab enum, limited to the manager's recognized grants. */
  "tabDetails"?: (ManagerTabResponse)[] | null;
  /** Decoded bank/location scopes belonging only to this site. Empty means no bank/location access. */
  "resourceGrants"?: (ManagerResourceGrantResponse)[] | null;
  /** Independent operation permissions for Managers, Bank, Location, Unit, User, Installer, Service, Tabs and Kids; missing stored values default to Read. */
  "operationPermissions"?: (ManagerOperationPermissionResponse)[] | null;
}

/** Redeems the emailed token. Never log this body or return its contents. */
export interface ManagerResetPasswordRequest {
  /** The opaque token from the email link, submitted unchanged. */
  "token": string;
  /** 12–128 printable ASCII characters; no leading/trailing spaces. Uses the existing login hash. */
  "password": string;
  /** A second entry of the new password, matching Password exactly. */
  "confirmPassword": string;
}

/** A site-bound bank/location scope for the access overview. */
export interface ManagerResourceGrantResponse {
  /** The canonical tenant, bank, or location KID, with omitted stored tenants resolved to the API site. */
  "kid"?: string | null;
  /** Tenant means all banks/locations on this site; Bank means all locations in that bank; Location means only that location. No names or business records are fetched. */
  "scope"?: string | null;
}

/** A short-lived opaque API token; no refresh token is issued. */
export interface ManagerSessionResponse {
  /** Opaque token for Authorization: Bearer {accessToken}. Do not decode it as a JWT or put it in a URL. */
  "accessToken"?: string | null;
  /** Lifetime in seconds. */
  "expiresIn"?: bigint;
  /** The Authorization header scheme. */
  "tokenType"?: string | null;
}

/** Single-use mailbox proof for the pending manager. */
export interface ManagerSignUpConfirmation {
  /** Protected single-use mailbox proof. */
  "token"?: string | null;
}

/** Required self-registration profile with no permission selectors. */
export interface ManagerSignUpRequest {
  /** Mailbox to verify. */
  "email"?: string | null;
  /** Manager name. */
  "name"?: string | null;
  /** Manager organisation. */
  "organisation"?: string | null;
  /** Password chosen at registration. */
  "password"?: string | null;
  /** Matching password confirmation. */
  "confirmPassword"?: string | null;
  /** Optional email language: exactly lowercase en, da or es. Omitted/null uses English; empty or other values are invalid. */
  "language"?: string | null;
}

/** Desired state of one numeric eTab grant, using the last returned Tabs revision. */
export interface ManagerTabChangeRequest {
  /** Required boolean; true assigns the tab and false removes it. */
  "enabled"?: boolean | null;
  /** Required opaque tabsRevision from GetManager or the latest SetManagerTab response. */
  "expectedRevision": string | null;
}

/** The acknowledged tab selection and concurrency state. */
export interface ManagerTabChangeResponse {
  /** Complete recognized selected tabs, sorted by metadata then numeric ID. */
  "tabs"?: (ManagerTabResponse)[] | null;
  /** Opaque revision for the next edit, including preserved unknown numbers. */
  "tabsRevision"?: string | null;
  /** False if removing your own Managers1 grant removes edit access. */
  "canEditTabs"?: boolean;
  /** False if the same change removes your permission-editing access. */
  "canEditPermissions"?: boolean;
}

/** A permitted page's identity in the shared eTab enum. */
export interface ManagerTabResponse {
  /** The persisted eTab number. */
  "id"?: number;
  /** The shared enum member name. */
  "name"?: string | null;
  /** API-computed icon identity based on eTab AttributeMetaIcon, empty when absent or none. Calendar includes today's day in Text. */
  "iconKid"?: string | null;
}

/** Sets the caller's own appearance preference; no manager or tenant override is accepted. */
export interface ManagerThemeRequest {
  /** themeMode */
  "themeMode": EThemeMode;
}

/** The manager's successfully stored appearance preference. */
export interface ManagerThemeResponse {
  /** themeMode */
  "themeMode"?: EThemeMode;
}

/** Authorized display identity and great-circle distance in metres, without the caller's position. */
export interface NearestLocationItem {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** distanceMeters */
  "distanceMeters"?: number;
}

/** Current own settings, stable revision and safe operation outcome; no inherited address. */
export interface ObjectAddressResponse {
  /** kid */
  "kid"?: string | null;
  /** address */
  "address"?: string | null;
  /** zip */
  "zip"?: string | null;
  /** latitude */
  "latitude"?: bigint | null;
  /** longitude */
  "longitude"?: bigint | null;
  /** autoLatitudeLongitude */
  "autoLatitudeLongitude"?: bigint | null;
  /** revision */
  "revision"?: string | null;
  /** outcome */
  "outcome"?: string | null;
  /** Display hint from the current snapshot; every mutation independently reauthorizes. */
  "canWrite"?: boolean;
}

/** Revision for a deliberate coordinate lookup. */
export interface ObjectAddressRevisionRequest {
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Units sharing the same effective weekly plan and upcoming exceptions. */
export interface OpeningHoursGroup {
  /** units */
  "units"?: (OpeningHoursUnit)[] | null;
  /** weekly */
  "weekly"?: (OpeningHoursLine)[] | null;
  /** exceptions */
  "exceptions"?: (OpeningHoursLine)[] | null;
  /** isOpenNow */
  "isOpenNow"?: boolean | null;
  /** nextChange */
  "nextChange"?: string | null;
}

/** Open, Closed, AllDay or Unknown; times are local HH:mm, with an explicit overnight flag. */
export interface OpeningHoursLine {
  /** label */
  "label"?: string | null;
  /** status */
  "status"?: string | null;
  /** opens */
  "opens"?: string | null;
  /** closes */
  "closes"?: string | null;
  /** closesNextDay */
  "closesNextDay"?: boolean;
  /** daysOfWeek */
  "daysOfWeek"?: (number)[] | null;
  /** date */
  "date"?: string | null;
}

/** An authorized unit identity and localized display name. */
export interface OpeningHoursUnit {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
}

/** Authorized machine, setting audit and revision. Status is null for an unknown nonzero stored code. */
export interface OutOfOrderItem {
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** unitType */
  "unitType"?: number;
  /** outOfOrder */
  "outOfOrder"?: number;
  /** status */
  "status"?: string | null;
  /** statusLabel */
  "statusLabel"?: string | null;
  /** timestampUtc */
  "timestampUtc"?: string;
  /** changedBy */
  "changedBy"?: UnitSettingEditorResponse;
  /** revision */
  "revision"?: string | null;
  /** canRestore */
  "canRestore"?: boolean;
}

/** Current out-of-order settings and an opaque next-page cursor. */
export interface OutOfOrderPage {
  /** items */
  "items"?: (OutOfOrderItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** refreshAfterSeconds */
  "refreshAfterSeconds"?: number;
}

/** Revision from the list; the action always writes Enabled (0). */
export interface OutOfOrderRestoreRequest {
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Confirmed storage result; Sync zero is pending device synchronization, not physical acknowledgement. */
export interface OutOfOrderRestoreResponse {
  /** kid */
  "kid"?: string | null;
  /** outOfOrder */
  "outOfOrder"?: number;
  /** status */
  "status"?: string | null;
  /** timestampUtc */
  "timestampUtc"?: string;
  /** revision */
  "revision"?: string | null;
  /** sync */
  "sync"?: number | null;
}

/** Authorized count and red badge icon; each operation documents its cache age and precision. */
export interface PeopleDirectoryCount {
  /** count */
  "count"?: bigint;
  /** iconKid */
  "iconKid"?: string | null;
}

/** Stable success/error code, containing no secrets. */
export interface PersonalAccountResult {
  /** code */
  "code"?: string | null;
}

/** Generate a replacement against the last acknowledged API-key revision. */
export interface PersonalApiKeyRequest {
  /** revision */
  "revision": string | null;
}

/** One-time plaintext key returned only after the hash was committed. Never log this response. */
export interface PersonalApiKeyResponse {
  /** apiKey */
  "apiKey"?: string | null;
  /** details */
  "details"?: PersonalManagerApiKey;
}

/** The single-use proof from the new mailbox. */
export interface PersonalEmailConfirmation {
  /** token */
  "token": string | null;
}

/** New address and reauthentication, without a caller-selected manager or return URL. */
export interface PersonalEmailRequest {
  /** email */
  "email": string | null;
  /** currentPassword */
  "currentPassword": string | null;
  /** language */
  "language"?: string | null;
}

/** Own API-key status; never contains the hash or plaintext key. */
export interface PersonalManagerApiKey {
  /** hasApiKey */
  "hasApiKey"?: boolean;
  /** revision */
  "revision"?: string | null;
}

/** Personal preferences; no credentials, administrative grants or internal verification proofs. */
export interface PersonalManagerProfile {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** organisation */
  "organisation"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** email */
  "email"?: string | null;
  /** emailVerified */
  "emailVerified"?: boolean;
  /** themeMode */
  "themeMode"?: EThemeMode;
  /** revision */
  "revision"?: string | null;
  /** availableIcons */
  "availableIcons"?: (string)[] | null;
  /** retentionDays */
  "retentionDays"?: number;
  /** iconSet */
  "iconSet"?: string | null;
  /** language */
  "language"?: number | null;
  /** dateFormat */
  "dateFormat"?: string | null;
  /** numberFormat */
  "numberFormat"?: string | null;
  /** lineSpacing */
  "lineSpacing"?: number;
  /** portalMaxOpenBanks */
  "portalMaxOpenBanks"?: number | null;
}

/** A stable numeric tab identity and its enum-derived name. */
export interface PersonalManagerTab {
  /** id */
  "id"?: number;
  /** name */
  "name"?: string | null;
}

/** Own tab selection and the finite enum catalog. CanEdit requires an explicit site-wide KID grant. */
export interface PersonalManagerTabs {
  /** kid */
  "kid"?: string | null;
  /** tabs */
  "tabs"?: (PersonalManagerTab)[] | null;
  /** availableTabs */
  "availableTabs"?: (PersonalManagerTab)[] | null;
  /** revision */
  "revision"?: string | null;
  /** canEdit */
  "canEdit"?: boolean;
}

/** Reauthentication and matching new password entries. */
export interface PersonalPasswordRequest {
  /** currentPassword */
  "currentPassword": string | null;
  /** password */
  "password": string | null;
  /** confirmPassword */
  "confirmPassword": string | null;
  /** language */
  "language"?: string | null;
}

/** One personal preference with the last acknowledged profile revision. */
export interface PersonalProfileRequest {
  /** revision */
  "revision": string | null;
  /** value */
  "value": unknown;
}

/** One own-tab toggle; the authenticated session is the sole target. */
export interface PersonalTabRequest {
  /** revision */
  "revision": string | null;
  /** enabled */
  "enabled": boolean;
}

/** Add a display to the authenticated manager's own layout list; grants no device or resource access. */
export interface PersonalWallboardRequest {
  /** displayId */
  "displayId": string | null;
  /** targetDisplayId */
  "targetDisplayId"?: string | null;
}

/** Own layout collection and opaque optimistic concurrency revision. */
export interface PersonalWallboardsResponse {
  /** wallboards */
  "wallboards"?: (Wallboard)[] | null;
  /** revision */
  "revision"?: string | null;
  /** storageUsedCharacters */
  "storageUsedCharacters"?: number;
  /** storageLimitCharacters */
  "storageLimitCharacters"?: number;
  /** portalWallboard */
  "portalWallboard"?: Wallboard;
  /** portalStorageUsedCharacters */
  "portalStorageUsedCharacters"?: number;
  /** portalStorageLimitCharacters */
  "portalStorageLimitCharacters"?: number;
}

/** ProblemDetails */
export interface ProblemDetails {
  /** type */
  "type"?: string | null;
  /** title */
  "title"?: string | null;
  /** status */
  "status"?: number | null;
  /** detail */
  "detail"?: string | null;
  /** instance */
  "instance"?: string | null;
}

/** RedeemWallboardPairing */
export interface RedeemWallboardPairing {
  /** deviceCode */
  "deviceCode"?: string | null;
}

/** ResumeWallboardSession */
export interface ResumeWallboardSession {
  /** challenge */
  "challenge"?: string | null;
  /** signature */
  "signature"?: string | null;
}

/** Replaces own layouts only when the current revision matches; no automatic retries. */
export interface SavePersonalWallboardsRequest {
  /** revision */
  "revision"?: string | null;
  /** wallboards */
  "wallboards": unknown;
  /** portalWallboard */
  "portalWallboard"?: unknown;
}

/** Mixed-result shape; kind is an enum-derived type. Kid identifies the result; optional BankKid identifies a resident's parent bank. */
export interface SearchResult {
  /** kid */
  "kid"?: string | null;
  /** kind */
  "kind"?: string | null;
  /** name */
  "name"?: string | null;
  /** zip */
  "zip"?: string | null;
  /** matchedSetting */
  "matchedSetting"?: string | null;
  /** matchedValue */
  "matchedValue"?: string | null;
  /** isContext */
  "isContext"?: boolean;
  /** number */
  "number"?: string | null;
  /** Canonical parent bank KID for a resident result. This identity grants no bank access; names require authorized context results. */
  "bankKid"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** A bounded provider result; merge by canonical Kid. */
export interface SearchResults {
  /** items */
  "items"?: (SearchResult)[] | null;
  /** hasMore */
  "hasMore"?: boolean;
}

/** Rotate the service key only if the profile still matches the revision last read. */
export interface ServiceApiKeyRequest {
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** ApiKey is returned only by the successful generation response. Do not log or persist this response. Details contains the committed hash and next profile revision, never another copy of the plaintext key. */
export interface ServiceApiKeyResponse {
  /** apiKey */
  "apiKey"?: string | null;
  /** details */
  "details"?: ServiceDetailsResponse;
}

/** ApiKeyHash is the hash stored in eSetting.ApiKeyHash (or an existing legacy Password-only service record) and is included only for callers with Service Write. The published JSON names are preserved; this is never a plaintext API key. CanEdit is only a display hint; every mutation independently reauthorizes. */
export interface ServiceDetailsResponse {
  /** service */
  "service"?: ServiceDirectoryItem;
  /** hasApiKeyHash */
  "hasApiKeyHash"?: boolean;
  /** apiKeyHash */
  "apiKeyHash"?: string | null;
  /** canEdit */
  "canEdit"?: boolean;
  /** profileRevision */
  "profileRevision"?: string | null;
  /** availableIcons */
  "availableIcons"?: (string)[] | null;
}

/** Canonical bank-zero, manager-shaped KID, eUserId.ToString() identity and tenant-specific Name/Icon. */
export interface ServiceDirectoryItem {
  /** kid */
  "kid"?: string | null;
  /** identity */
  "identity"?: string | null;
  /** name */
  "name"?: string | null;
  /** Exact enum setting for the icon picker and Icon writes; use IconKid for images. */
  "iconName"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** The finite catalog of concrete service enum identities; never contains key hashes. NextCursor is always null. */
export interface ServiceDirectoryResponse {
  /** items */
  "items"?: (ServiceDirectoryItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
}

/** Exact Name or Icon value plus the revision returned by GetService. Credentials cannot be edited manually. */
export interface ServiceProfileRequest {
  /** value */
  "value": string | null;
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** One recognized coordinate provenance value and the current object revision. */
export interface SetObjectCoordinateProvenanceRequest {
  /** value */
  "value": number;
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Manual coordinates in integer millionths of degrees. */
export interface SetObjectCoordinatesRequest {
  /** latitude */
  "latitude": bigint;
  /** longitude */
  "longitude": bigint;
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Reconciled totals and supported formats for a closed settlement period. */
export interface SettlementDetailResponse {
  /** Canonical bank KID. */
  "kid"?: string | null;
  /** Period number; zero is provisional. */
  "period"?: number;
  /** Number of source entries before export exclusions. */
  "sourceEntries"?: number;
  /** Number after export exclusions. */
  "includedEntries"?: number;
  /** Totals separated by export group and currency. */
  "groups"?: (SettlementGroupResponse)[] | null;
  /** Supported case-sensitive format identifiers. */
  "formats"?: (string)[] | null;
}

/** One export group in one currency; amounts keep their database sign. */
export interface SettlementGroupResponse {
  /** Stable export group identifier. */
  "group"?: string | null;
  /** Currency code. */
  "currency"?: string | null;
  /** Included entry count. */
  "entries"?: number;
  /** Signed sum in minor units. */
  "amountMinor"?: bigint;
}

/** Bank settlement metadata, independent of display language. */
export interface SettlementHistoryResponse {
  /** Canonical bank KID. */
  "kid"?: string | null;
  /** Next scheduled close in UTC; null when unknown. */
  "nextSettlement"?: string | null;
  /** Closed period metadata, newest first. */
  "periods"?: (SettlementPeriodResponse)[] | null;
  /** Pass as beforePeriod for older rows; null at the end. */
  "nextBeforePeriod"?: number | null;
}

/** Historical metadata from LogA; missing values are null. */
export interface SettlementPeriodResponse {
  /** Settlement period number; zero is never returned as a closed period. */
  "period"?: number;
  /** Period end in UTC. */
  "settlementDate"?: string | null;
  /** Recorded execution time in UTC. */
  "settlementRun"?: string | null;
  /** First recorded transaction time in UTC. */
  "firstTransaction"?: string | null;
  /** Last recorded transaction time in UTC. */
  "lastTransaction"?: string | null;
  /** Signed stored total in minor units, with no implied currency or export filtering. */
  "amountMinor"?: bigint | null;
  /** Stored transaction count. */
  "transactionCount"?: bigint | null;
}

/** StartWallboardPairing */
export interface StartWallboardPairing {
  /** displayId */
  "displayId"?: string | null;
  /** publicKey */
  "publicKey"?: string | null;
}

/** One alert with canonical object KIDs and a UTC last-contact or out-of-order timestamp. */
export interface TenantStatusItem {
  /** kind */
  "kind"?: string | null;
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** computerName */
  "computerName"?: string | null;
  /** bankType */
  "bankType"?: string | null;
  /** unitType */
  "unitType"?: number | null;
  /** errorId */
  "errorId"?: number | null;
  /** timestampUtc */
  "timestampUtc"?: string;
  /** iconKid */
  "iconKid"?: string | null;
  /** API-computed bank icon; use unchanged in the selected icon set's image URL. */
  "bankIconKid"?: string | null;
  /** API-computed location icon including its location number in Kid.Text. */
  "locationIconKid"?: string | null;
}

/** One lazy-loaded page from a bounded, authorized status snapshot. */
export interface TenantStatusPageResponse {
  /** status */
  "status"?: TenantStatusResponse;
  /** offset */
  "offset"?: number;
  /** totalCount */
  "totalCount"?: number;
  /** previousCursor */
  "previousCursor"?: string | null;
  /** nextCursor */
  "nextCursor"?: string | null;
}

/** A bounded operational snapshot; failed sources are explicit, never reported as healthy. */
export interface TenantStatusResponse {
  /** measuredAtUtc */
  "measuredAtUtc"?: string;
  /** refreshAfterSeconds */
  "refreshAfterSeconds"?: number;
  /** sources */
  "sources"?: (TenantStatusSourceResult)[] | null;
  /** items */
  "items"?: (TenantStatusItem)[] | null;
}

/** Outcome of one independently executed lookup. HasMore means the per-source limit was reached. */
export interface TenantStatusSourceResult {
  /** kind */
  "kind"?: string | null;
  /** count */
  "count"?: number;
  /** hasMore */
  "hasMore"?: boolean;
  /** errorCode */
  "errorCode"?: string | null;
}

/** One nondefault, nonzero data property returned by the installed Flex KID parser. */
export interface ToolKidField {
  /** Exact Kid property name, independent of display language. */
  "name"?: string | null;
  /** Exact invariant numeric value or decoded text; numbers remain strings to avoid JavaScript precision loss. */
  "value"?: string | null;
  /** The actual enum ToString() name, or null when the enum value has no name. */
  "enumName"?: string | null;
  /** Exact enum numeric value as a string; null for properties that are not enums. */
  "enumNumber"?: string | null;
  /** Zero-based original list position for Settings and Icons, otherwise null. */
  "index"?: number | null;
}

/** Input to the KID inspection tool. Parsing never resolves resources or grants access. */
export interface ToolKidInspectionRequest {
  /** A Flex KID in a representation accepted by the installed Kid parser, up to 2048 characters. */
  "kid"?: string | null;
}

/** Parsed KID data only, without database lookups, inferred scope, or derived display identities. */
export interface ToolKidInspectionResponse {
  /** The installed parser's ToString() output. */
  "canonicalKid"?: string | null;
  /** Nondefault, nonzero properties, with all nonzero Settings and Icons preserved in their original order. */
  "fields"?: (ToolKidField)[] | null;
  /** True when the installed parser reserialized the input differently, including ignored input or whitespace. */
  "normalized"?: boolean;
}

/** One possible offset for a local time repeated at the end of daylight saving time. */
export interface ToolTimeOffsetChoice {
  /** offset */
  "offset"?: string | null;
  /** utc */
  "utc"?: string | null;
}

/** Pure conversion input. Format is ms2000, mi2000, ss2000, utc or local; all numbers travel as strings. */
export interface ToolTimeRequest {
  /** format */
  "format"?: string | null;
  /** value */
  "value"?: string | null;
  /** timeZone */
  "timeZone"?: string | null;
  /** offset */
  "offset"?: string | null;
}

/** A validation outcome, or one instant expressed in all supported reversible formats. */
export interface ToolTimeResponse {
  /** success */
  "success"?: boolean;
  /** error */
  "error"?: string | null;
  /** result */
  "result"?: ToolTimeResult;
  /** offsetChoices */
  "offsetChoices"?: (ToolTimeOffsetChoice)[] | null;
}

/** MS2000 preserves input milliseconds. Date input follows Kombine.Flex.Time's two-millisecond truncation; DateInputRounded reports any lost ticks. MI2000 and SS2000 are null outside their reversible Int32 range. MillisecondRemainder is the part lost by SS2000; SecondRemainder is the seconds lost by MI2000. Local is an offset-free ISO wall time in the explicitly supplied IANA TimeZone; Offset identifies the instant. */
export interface ToolTimeResult {
  /** ms2000 */
  "ms2000"?: string | null;
  /** mi2000 */
  "mi2000"?: string | null;
  /** ss2000 */
  "ss2000"?: string | null;
  /** utc */
  "utc"?: string | null;
  /** local */
  "local"?: string | null;
  /** timeZone */
  "timeZone"?: string | null;
  /** offset */
  "offset"?: string | null;
  /** dateInputRounded */
  "dateInputRounded"?: boolean;
  /** millisecondRemainder */
  "millisecondRemainder"?: string | null;
  /** secondRemainder */
  "secondRemainder"?: string | null;
}

/** Authorized unit with the declared groups for its resolved type. No setting/state values or write permissions are returned. */
export interface UnitDetailsResponse {
  /** location */
  "location"?: BankLocationResponse;
  /** unit */
  "unit"?: UnitOverviewResponse;
  /** descriptorAvailable */
  "descriptorAvailable"?: boolean;
  /** settingGroups */
  "settingGroups"?: (string)[] | null;
  /** stateGroups */
  "stateGroups"?: (string)[] | null;
}

/** Unit and parent identities, display names/icons, activation/deletion state and requested unit columns. */
export interface UnitDirectoryItem {
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** name */
  "name"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** bankIconKid */
  "bankIconKid"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** locationIconKid */
  "locationIconKid"?: string | null;
  /** enabled */
  "enabled"?: boolean;
  /** deleted */
  "deleted"?: boolean | null;
  /** deletedAt */
  "deletedAt"?: string | null;
  /** unitType */
  "unitType"?: string | null;
  /** washDocId */
  "washDocId"?: string | null;
  /** outOfOrder */
  "outOfOrder"?: string | null;
  /** latitude */
  "latitude"?: number | null;
  /** longitude */
  "longitude"?: number | null;
  /** Last stored eState.ErrorUnit JSON text; null unless selected, empty when absent. May describe a historical fault. */
  "errorUnit"?: string | null;
  /** Stored AutoOutOfOrder JSON when autoOutOfOrderOnly is true; otherwise null. */
  "autoOutOfOrder"?: string | null;
  /** Requested terminal eState.VersionMinor as decoded text; null unless selected, empty when absent. */
  "versionMinor"?: string | null;
  /** Requested terminal eState.BootReason as decoded text; null unless selected, empty when absent. */
  "bootReason"?: string | null;
  /** Requested terminal eSetting.Booted as decoded text; null unless selected, empty when absent. */
  "booted"?: string | null;
  /** Requested terminal eState.Firmware as decoded text; null unless selected, empty when absent. */
  "firmware"?: string | null;
  /** Requested terminal eState.StorageCardSerialNumber as decoded text; null unless selected, empty when absent. */
  "storageCardSerialNumber"?: string | null;
  /** Requested terminal eState.Page as decoded text; null unless selected, empty when absent. */
  "page"?: string | null;
  /** Requested terminal eState.BackLight as decoded text; null unless selected, empty when absent. */
  "backLight"?: string | null;
  /** terminal */
  "terminal"?: UnitTerminalResponse;
  /** progress */
  "progress"?: UnitProgressResponse;
}

/** A scoped Units1 or Terminals1 page. Identifiers are canonical KIDs; map coordinates belong to the parent location. */
export interface UnitDirectoryResponse {
  /** items */
  "items"?: (UnitDirectoryItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** hasAllBanksAccess */
  "hasAllBanksAccess"?: boolean;
  /** fields */
  "fields"?: (string)[] | null;
}

/** Distinct document count and effective inclusive UTC history bounds for the exact authorized unit. */
export interface UnitDocumentCount {
  /** count */
  "count"?: bigint;
  /** from */
  "from"?: string;
  /** through */
  "through"?: string;
}

/** One bounded, sorted document page for the exact authorized unit. */
export interface UnitDocumentPage {
  /** Document identities and authorized unit display metadata. */
  "items"?: (BankDocumentItem)[] | null;
  /** Effective inclusive UTC search start. */
  "from"?: string;
  /** Effective inclusive UTC search end. */
  "through"?: string;
  /** Effective sort field. */
  "sort"?: string | null;
  /** Effective sort direction. */
  "direction"?: string | null;
  /** Effective offset. */
  "offset"?: number;
  /** Effective page size. */
  "limit"?: number;
  /** Another page existed when this query ran. */
  "hasMore"?: boolean;
}

/** One authorized error event. Null description/code/count means that the stored payload does not provide it. */
export interface UnitErrorItem {
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** unitType */
  "unitType"?: number | null;
  /** timestampUtc */
  "timestampUtc"?: string;
  /** severity */
  "severity"?: string | null;
  /** level */
  "level"?: string | null;
  /** code */
  "code"?: number | null;
  /** count */
  "count"?: number | null;
  /** description */
  "description"?: string | null;
  /** payloadFormat */
  "payloadFormat"?: string | null;
  /** acknowledged */
  "acknowledged"?: boolean;
  /** revision */
  "revision"?: string | null;
  /** canAcknowledge */
  "canAcknowledge"?: boolean;
}

/** A keyset page with a fixed UTC time window and optional opaque continuation. */
export interface UnitErrorPage {
  /** items */
  "items"?: (UnitErrorItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** fromUtc */
  "fromUtc"?: string;
  /** untilUtc */
  "untilUtc"?: string;
}

/** Stored current-unit value, or an explicit absence/scope/redaction status. MS2000 is the source krumb timestamp. */
export interface UnitGroupFieldResponse {
  /** name */
  "name"?: string | null;
  /** valueType */
  "valueType"?: string | null;
  /** scope */
  "scope"?: string | null;
  /** valueStatus */
  "valueStatus"?: string | null;
  /** value */
  "value"?: string | null;
  /** ms2000 */
  "ms2000"?: bigint | null;
  /** canEdit */
  "canEdit"?: boolean;
  /** revision */
  "revision"?: string | null;
  /** required */
  "required"?: boolean;
  /** minimum */
  "minimum"?: number | null;
  /** maximum */
  "maximum"?: number | null;
  /** options */
  "options"?: (UnitSettingOption)[] | null;
  /** sync */
  "sync"?: number | null;
  /** changedBy */
  "changedBy"?: UnitSettingEditorResponse;
  /** canReadHistory */
  "canReadHistory"?: boolean;
  /** hasHistory */
  "hasHistory"?: boolean;
  /** valueFormat */
  "valueFormat"?: string | null;
  /** pattern */
  "pattern"?: string | null;
}

/** The authorized unit and one catalog-defined group, with read-only stored values. */
export interface UnitGroupResponse {
  /** location */
  "location"?: BankLocationResponse;
  /** unit */
  "unit"?: UnitOverviewResponse;
  /** kind */
  "kind"?: string | null;
  /** group */
  "group"?: string | null;
  /** items */
  "items"?: (UnitGroupFieldResponse)[] | null;
}

/** Status 200 carries an icon; missing Alive is unknown, never an offline error. */
export interface UnitIconResponse {
  /** kid */
  "kid"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** offline */
  "offline"?: boolean | null;
  /** status */
  "status"?: number;
}

/** Bounded lazy icon lookup, with independent errors for inaccessible units. */
export interface UnitIconsResponse {
  /** items */
  "items"?: (UnitIconResponse)[] | null;
}

/** Unit name and validated eIcon name, identified only by its canonical KID. */
export interface UnitOverviewResponse {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** cycle */
  "cycle"?: string | null;
  /** cycleText */
  "cycleText"?: string | null;
  /** unitType */
  "unitType"?: number | null;
  /** unitTypeName */
  "unitTypeName"?: string | null;
  /** unitTypeSource */
  "unitTypeSource"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
  /** progress */
  "progress"?: UnitProgressResponse;
  /** terminal */
  "terminal"?: UnitTerminalResponse;
}

/** API-calculated progress. Percent and remaining time are estimates, not hardware completion signals. */
export interface UnitProgressResponse {
  /** status */
  "status"?: string | null;
  /** percent */
  "percent"?: number | null;
  /** remainingSeconds */
  "remainingSeconds"?: number | null;
  /** calculatedAtUtc */
  "calculatedAtUtc"?: string;
}

/** Display-only audit identity; does not grant directory/account access. UserId zero has no editor; unknown nonzero identities have no KID. */
export interface UnitSettingEditorResponse {
  /** kid */
  "kid"?: string | null;
  /** kind */
  "kind"?: string | null;
  /** name */
  "name"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** The stored value, exact source timestamp, acknowledgement flag and editor display identity. */
export interface UnitSettingHistoryItem {
  /** value */
  "value"?: string | null;
  /** ms2000 */
  "ms2000"?: bigint;
  /** sync */
  "sync"?: number | null;
  /** changedBy */
  "changedBy"?: UnitSettingEditorResponse;
}

/** A page of setting changes, newest first; an exclusive timestamp continues to older rows. */
export interface UnitSettingHistoryResponse {
  /** unitKid */
  "unitKid"?: string | null;
  /** group */
  "group"?: string | null;
  /** setting */
  "setting"?: string | null;
  /** items */
  "items"?: (UnitSettingHistoryItem)[] | null;
  /** nextBeforeMs2000 */
  "nextBeforeMs2000"?: bigint | null;
  /** valueFormat */
  "valueFormat"?: string | null;
}

/** A selectable persisted value and its localized catalog label. */
export interface UnitSettingOption {
  /** value */
  "value"?: string | null;
  /** label */
  "label"?: string | null;
}

/** Invariant setting text with the revision obtained from GetUnitGroup. */
export interface UnitSettingRequest {
  /** value */
  "value": string | null;
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Confirmed stored setting and a new revision for subsequent edits. */
export interface UnitSettingResponse {
  /** unitKid */
  "unitKid"?: string | null;
  /** group */
  "group"?: string | null;
  /** setting */
  "setting"?: string | null;
  /** value */
  "value"?: string | null;
  /** ms2000 */
  "ms2000"?: bigint;
  /** revision */
  "revision"?: string | null;
  /** sync */
  "sync"?: number | null;
  /** changedBy */
  "changedBy"?: UnitSettingEditorResponse;
}

/** Visible authorized main terminal identified by a canonical unit KID; no extra access is granted. */
export interface UnitTerminalResponse {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** API-computed terminal icon identity, including its controller number. */
  "iconKid"?: string | null;
}

/** One readable enum field; numeric IDs remain stable. */
export interface UnitTimelineField {
  /** kind */
  "kind"?: string | null;
  /** id */
  "id"?: number;
  /** name */
  "name"?: string | null;
}

/** Authorized context and capabilities; a capability never replaces endpoint authorization. */
export interface UnitTimelineFields {
  /** unitKid */
  "unitKid"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** unitType */
  "unitType"?: number | null;
  /** sources */
  "sources"?: (string)[] | null;
  /** fields */
  "fields"?: (UnitTimelineField)[] | null;
  /** canReadTextDiagnostics */
  "canReadTextDiagnostics"?: boolean;
  /** canReadDocuments */
  "canReadDocuments"?: boolean;
}

/** One log row; eventKey is a unit-local source/time key, not a resource grant or object KID. */
export interface UnitTimelineItem {
  /** eventKey */
  "eventKey"?: string | null;
  /** source */
  "source"?: string | null;
  /** ms2000 */
  "ms2000"?: string | null;
  /** timestampUtc */
  "timestampUtc"?: string;
  /** sync */
  "sync"?: number | null;
  /** field */
  "field"?: string | null;
  /** amount */
  "amount"?: string | null;
  /** currency */
  "currency"?: string | null;
  /** text */
  "text"?: string | null;
  /** contentStatus */
  "contentStatus"?: string | null;
  /** period */
  "period"?: number;
  /** userKid */
  "userKid"?: string | null;
  /** documentKid */
  "documentKid"?: string | null;
  /** auxiliaryValue */
  "auxiliaryValue"?: string | null;
}

/** Chronological page over an inclusive/exclusive UTC range. */
export interface UnitTimelinePage {
  /** context */
  "context"?: UnitTimelineFields;
  /** fromUtc */
  "fromUtc"?: string;
  /** untilUtc */
  "untilUtc"?: string;
  /** items */
  "items"?: (UnitTimelineItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
}

/** Both address components and the last observed revision are required. */
export interface UpdateObjectAddressRequest {
  /** address */
  "address": string | null;
  /** zip */
  "zip": string | null;
  /** expectedRevision */
  "expectedRevision": string | null;
}

/** Activation credential for an active resident; returned only to bank-wide User Create managers. */
export interface UserActivationResponse {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** number */
  "number"?: string | null;
  /** activationCode */
  "activationCode"?: string | null;
  /** Opaque QR payload in the existing FlexORM/FlexCipherLongs format. Empty when the tenant has no activation URL. Render the QR image in the client. */
  "qrCodeDataV1"?: string | null;
  /** Version 2: the same three values, a random 30-bit noise value, and a 30-bit checksum (0–1073741823), (((bankCode * 31 + userCode) * 31 + seconds) * 31 + noise) modulo 1073741824. Decode five values with FlexCipherLongs. Empty when the tenant has no activation URL. */
  "qrCodeDataV2"?: string | null;
}

/** Canonical eUserAttribute name and value; -1 means no numeric value. */
export interface UserAttributeInput {
  /** attribute */
  "attribute"?: string | null;
  /** value */
  "value"?: bigint;
}

/** An eUserAttribute identifier and stored value; negative values mean no numeric value. */
export interface UserAttributeResponse {
  /** attribute */
  "attribute"?: string | null;
  /** value */
  "value"?: bigint;
}

/** Signed balances in minor currency units (øre for DKK). Missing/hidden residents have status not-found and null balances. */
export interface UserBalanceItem {
  /** Canonical resident KID. */
  "kid"?: string | null;
  /** ok or not-found; hidden and missing residents are indistinguishable. */
  "status"?: string | null;
  /** Current signed balance, including discount and settlement correction. */
  "currentBalanceMinor"?: bigint | null;
  /** Latest positive period's sum, or the provisional period's corrected balance. Null when absent. */
  "previousBalanceMinor"?: bigint | null;
  /** Resident's latest positive period, or bank's highest Log1 period plus one for a provisional period. Null when absent. */
  "previousPeriod"?: number | null;
  /** True only for a computed, unpersisted period caused by delayed settlement. False when absent. */
  "previousPeriodIsProvisional"?: boolean;
  /** Latest Log1 posting time across all periods and entry types, as UTC milliseconds since 2000-01-01. Zero when no postings exist; null for not-found. */
  "latestPostingMs2000"?: bigint | null;
  /** Active card/SEPA subscription using the authorized bank's Orders state (Flags and CR2000 positive, ActionCode OK/AUTHORIZE). Null for not-found. */
  "hasActiveSubscription"?: boolean | null;
  /** Separate balances by normalized Log1 currency; empty for no postings/discount or not-found. Prefer these to the legacy cross-currency scalar fields. */
  "balances"?: (UserCurrencyBalanceItem)[] | null;
}

/** One to fifty canonical resident KIDs from the bank in the route. Duplicates are returned once. */
export interface UserBalancesRequest {
  /** One to fifty canonical resident KIDs. */
  "userKids": (string)[];
}

/** Results in requested order, without duplicate KIDs; no results are silently truncated. */
export interface UserBalancesResponse {
  /** items */
  "items"?: (UserBalanceItem)[] | null;
}

/** One bounded resident command. Revision is required for existing residents; KIDs must belong to the site and bank. */
export interface UserCommandRequest {
  /** action */
  "action"?: string | null;
  /** revision */
  "revision"?: string | null;
  /** name */
  "name"?: string | null;
  /** number */
  "number"?: string | null;
  /** deleteAtUtc */
  "deleteAtUtc"?: string | null;
  /** tagKid */
  "tagKid"?: string | null;
  /** state */
  "state"?: string | null;
  /** locationKid */
  "locationKid"?: string | null;
  /** attributes */
  "attributes"?: (UserAttributeInput)[] | null;
  /** icon */
  "icon"?: string | null;
}

/** Signed legacy minor units per currency, with no conversion. Null Currency means no stored currency code. Discount applies to DKK only. */
export interface UserCurrencyBalanceItem {
  /** currency */
  "currency"?: string | null;
  /** currentBalanceMinor */
  "currentBalanceMinor"?: bigint;
  /** previousBalanceMinor */
  "previousBalanceMinor"?: bigint | null;
  /** previousPeriod */
  "previousPeriod"?: number | null;
  /** previousPeriodIsProvisional */
  "previousPeriodIsProvisional"?: boolean;
}

/** Resident and parent bank identities with display metadata only. */
export interface UserDirectoryItem {
  /** kid */
  "kid"?: string | null;
  /** bankKid */
  "bankKid"?: string | null;
  /** name */
  "name"?: string | null;
  /** number */
  "number"?: string | null;
  /** iconKid */
  "iconKid"?: string | null;
  /** deletedAt */
  "deletedAt"?: string | null;
}

/** Authorized resident page. A short page may still have a continuation. */
export interface UserDirectoryResponse {
  /** items */
  "items"?: (UserDirectoryItem)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** scanLimitReached */
  "scanLimitReached"?: boolean;
}

/** A sensitive resident login URL. Never log, persist, prefetch or share it. ExpiresAtUtc is the legacy admission deadline, not the duration of the resulting eVaskeri session. */
export interface UserEvaskeriSession {
  /** kid */
  "kid"?: string | null;
  /** url */
  "url"?: string | null;
  /** expiresAtUtc */
  "expiresAtUtc"?: string;
}

/** A location KID, Access/NoAccess state and eIcon name (default house), cached up to 60 seconds. Location-scoped managers see only their locations. */
export interface UserLocationResponse {
  /** kid */
  "kid"?: string | null;
  /** state */
  "state"?: string | null;
  /** name */
  "name"?: string | null;
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
}

/** Non-reserving number suggestion. Number is empty when no configured candidate is available. */
export interface UserNumberSuggestionResponse {
  /** bankKid */
  "bankKid"?: string | null;
  /** number */
  "number"?: string | null;
}

/** One local day/location/type/period/currency group. Amounts are signed minor units. */
export interface UserReceipt {
  /** key */
  "key"?: string | null;
  /** date */
  "date"?: string;
  /** locationKid */
  "locationKid"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** period */
  "period"?: number;
  /** provisional */
  "provisional"?: boolean;
  /** kind */
  "kind"?: string | null;
  /** currency */
  "currency"?: string | null;
  /** totalMinor */
  "totalMinor"?: bigint;
  /** vatMinor */
  "vatMinor"?: bigint | null;
  /** balanceAfterMinor */
  "balanceAfterMinor"?: bigint;
  /** lines */
  "lines"?: (UserReceiptLine)[] | null;
}

/** One decoded document; calculated adjustments have no transaction KID. */
export interface UserReceiptLine {
  /** kid */
  "kid"?: string | null;
  /** occurredAt */
  "occurredAt"?: string;
  /** unitKid */
  "unitKid"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** texts */
  "texts"?: (string)[] | null;
  /** amountMinor */
  "amountMinor"?: bigint;
  /** calculated */
  "calculated"?: boolean;
}

/** A complete page of resident receipts. Offsets count receipts, never posting lines. */
export interface UserReceiptsResponse {
  /** userKid */
  "userKid"?: string | null;
  /** revision */
  "revision"?: string | null;
  /** items */
  "items"?: (UserReceipt)[] | null;
  /** nextOffset */
  "nextOffset"?: number | null;
  /** periodCount */
  "periodCount"?: number;
}

/** Canonical location or tag KID with its current state. */
export interface UserScopeState {
  /** kid */
  "kid"?: string | null;
  /** state */
  "state"?: string | null;
}

/** A tag KID and eTagState name. */
export interface UserTagResponse {
  /** kid */
  "kid"?: string | null;
  /** state */
  "state"?: string | null;
}

/** Authoritative resident details and revision, with permitted operation levels and asynchronous backend synchronization. */
export interface UserWorkspaceResponse {
  /** kid */
  "kid"?: string | null;
  /** revision */
  "revision"?: string | null;
  /** name */
  "name"?: string | null;
  /** number */
  "number"?: string | null;
  /** deletedAtUtc */
  "deletedAtUtc"?: string | null;
  /** deleteAtUtc */
  "deleteAtUtc"?: string | null;
  /** locations */
  "locations"?: (UserScopeState)[] | null;
  /** tags */
  "tags"?: (UserScopeState)[] | null;
  /** attributes */
  "attributes"?: (UserAttributeInput)[] | null;
  /** canWrite */
  "canWrite"?: boolean;
  /** canCreate */
  "canCreate"?: boolean;
  /** synchronization */
  "synchronization"?: string | null;
  /** canDelete */
  "canDelete"?: boolean;
  /** canRenameExternalId */
  "canRenameExternalId"?: boolean;
  /** canRename */
  "canRename"?: boolean;
  /** Current display icon. New assignments must use the Person catalog. */
  "iconKid"?: string | null;
  /** All Person icons, with a current non-Person icon prepended for display only. */
  "availableIcons"?: (string)[] | null;
  /** Display hint: User Write and an active resident. Commands always reauthorize. */
  "canEditIcon"?: boolean;
}

/** ValidationProblemDetails */
export interface ValidationProblemDetails {
  /** type */
  "type"?: string | null;
  /** title */
  "title"?: string | null;
  /** status */
  "status"?: number | null;
  /** detail */
  "detail"?: string | null;
  /** instance */
  "instance"?: string | null;
  /** errors */
  "errors"?: Record<string, (string)[]> | null;
}

/** Wallboard */
export interface Wallboard {
  /** i */
  "i"?: (string)[] | null;
  /** n */
  "n"?: string | null;
  /** a */
  "a"?: number;
  /** c */
  "c"?: (EColor)[] | null;
  /** s */
  "s"?: (WallboardPage)[] | null;
}

/** WallboardDeviceChallenge */
export interface WallboardDeviceChallenge {
  /** challenge */
  "challenge"?: string | null;
  /** message */
  "message"?: string | null;
  /** expiresIn */
  "expiresIn"?: number;
}

/** WallboardDeviceInfo */
export interface WallboardDeviceInfo {
  /** deviceId */
  "deviceId"?: string | null;
  /** displayId */
  "displayId"?: string | null;
  /** createdAt */
  "createdAt"?: string;
  /** location */
  "location"?: WallboardScanLocation;
}

/** One display's selected orientation; null means no configured layout. */
export interface WallboardDisplayResponse {
  /** layout */
  "layout"?: Wallboard;
  /** revision */
  "revision"?: string | null;
}

/** WallboardPage */
export interface WallboardPage {
  /** n */
  "n"?: string | null;
  /** d */
  "d"?: number;
  /** s */
  "s"?: (WallboardWidget)[] | null;
}

/** WallboardPairingInfo */
export interface WallboardPairingInfo {
  /** pairingId */
  "pairingId"?: string | null;
  /** displayId */
  "displayId"?: string | null;
  /** expiresAt */
  "expiresAt"?: string;
  /** approved */
  "approved"?: boolean;
}

/** WallboardPairingStarted */
export interface WallboardPairingStarted {
  /** pairingId */
  "pairingId"?: string | null;
  /** deviceCode */
  "deviceCode"?: string | null;
  /** displayId */
  "displayId"?: string | null;
  /** expiresAt */
  "expiresAt"?: string;
  /** intervalSeconds */
  "intervalSeconds"?: number;
}

/** WallboardPairingToken */
export interface WallboardPairingToken {
  /** status */
  "status"?: string | null;
  /** accessToken */
  "accessToken"?: string | null;
  /** expiresIn */
  "expiresIn"?: bigint | null;
  /** displayId */
  "displayId"?: string | null;
}

/** WallboardScanLocation */
export interface WallboardScanLocation {
  /** latitude */
  "latitude"?: number;
  /** longitude */
  "longitude"?: number;
  /** accuracyMeters */
  "accuracyMeters"?: number;
  /** capturedAt */
  "capturedAt"?: string;
}

/** WallboardWidget */
export interface WallboardWidget {
  /** t */
  "t"?: EWidgetType;
  /** k */
  "k"?: string | null;
  /** r */
  "r"?: (number)[] | null;
}

/** Actual SoapInfo event. Missing duration/amounts remain null; quantity is never inferred from duration. */
export interface WashDocChartDosing {
  /** ms2000 */
  "ms2000"?: bigint;
  /** name */
  "name"?: string | null;
  /** durationMs */
  "durationMs"?: bigint | null;
  /** volumeMl */
  "volumeMl"?: number | null;
  /** massGrams */
  "massGrams"?: number | null;
  /** process */
  "process"?: string | null;
  /** step */
  "step"?: string | null;
}

/** A stored Cycle, Process, CycleSub or Error transition. Process retains the legacy eProcess byte, independently of newer cycle enums. Stable name/value and localization key are independent of the display label. */
export interface WashDocChartEvent {
  /** ms2000 */
  "ms2000"?: bigint;
  /** kind */
  "kind"?: string | null;
  /** name */
  "name"?: string | null;
  /** value */
  "value"?: number | null;
  /** label */
  "label"?: string | null;
  /** localization */
  "localization"?: string | null;
  /** isCalculated */
  "isCalculated"?: boolean;
}

/** One stored timestamp. Null values break curves. Edge samples anchor drawing but are outside the visible window. */
export interface WashDocChartPoint {
  /** ms2000 */
  "ms2000"?: bigint;
  /** value */
  "value"?: number | null;
  /** isCalculated */
  "isCalculated"?: boolean;
  /** isEdge */
  "isEdge"?: boolean;
  /** unit */
  "unit"?: string | null;
}

/** Renderer-independent WashDoc measurements. All times are UTC milliseconds since 2000-01-01. */
export interface WashDocChartResponse {
  /** cycleKid */
  "cycleKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** finished */
  "finished"?: boolean;
  /** fromMs2000 */
  "fromMs2000"?: bigint;
  /** toMs2000 */
  "toMs2000"?: bigint;
  /** startedMs2000 */
  "startedMs2000"?: bigint | null;
  /** endedMs2000 */
  "endedMs2000"?: bigint | null;
  /** series */
  "series"?: (WashDocChartSeries)[] | null;
  /** events */
  "events"?: (WashDocChartEvent)[] | null;
  /** signals */
  "signals"?: (WashDocChartSignal)[] | null;
  /** dosing */
  "dosing"?: (WashDocChartDosing)[] | null;
  /** presentation */
  "presentation"?: WashDocPresentation;
}

/** A sparse measurement or target series. Unit is null when not known or not uniform. Raw values are not visual band coordinates. */
export interface WashDocChartSeries {
  /** kind */
  "kind"?: string | null;
  /** name */
  "name"?: string | null;
  /** label */
  "label"?: string | null;
  /** localization */
  "localization"?: string | null;
  /** group */
  "group"?: string | null;
  /** role */
  "role"?: string | null;
  /** unit */
  "unit"?: string | null;
  /** step */
  "step"?: boolean;
  /** points */
  "points"?: (WashDocChartPoint)[] | null;
}

/** Actual InOutletHeat changes interpreted by the trusted machine profile. Null means unknown or inapplicable, never off. Holds until next stored change. */
export interface WashDocChartSignal {
  /** ms2000 */
  "ms2000"?: bigint;
  /** flags */
  "flags"?: number | null;
  /** heat */
  "heat"?: boolean | null;
  /** inlet */
  "inlet"?: boolean | null;
  /** outlet */
  "outlet"?: boolean | null;
  /** isCalculated */
  "isCalculated"?: boolean;
  /** Alliance dryer airflow switch. Null for other protocols or unknown input. */
  "airflow"?: boolean | null;
}

/** Server-selected presentation for the original, decoded UnitType. Group order is a preference, not a measurement filter. */
export interface WashDocPresentation {
  /** unitType */
  "unitType"?: number | null;
  /** kind */
  "kind"?: string | null;
  /** groupOrder */
  "groupOrder"?: (string)[] | null;
}

/** Wire values: [0, 16777216, 19803451, 49342943, 66515692, 83886079, 301717822, 586316818, 872109863, 1148802545, 1430742526, 1717269026, 1735697169, 2246665236, 2573393397, 2663948613, 2699079935, 2714280648, 2733703167, 2749942179, 2751462864, 2768224459, 2769641661, 2787281698, 2818346668, 2830712137, 2834349618, 2844424541, 2866338008, 2917435280, 2995767495, 3079273262, 3161949195, 3251336146, 3336873398, 3414481233, 3504172543, 3519070400, 3556759296, 3570237234, 3584940262, 3585341471, 3602906880, 3665568446, 3743790278, 3839692917, 4009820159, 4059490203, 4076199087, 4093564881, 4107256821, 4123120887, 4140555679, 4160732928, 4164306255, 4194303984, 4198924980, 4215333072, 4235231376, 4260754908, 4274834687, 4282924082]. */
export type EColor = number;

/** Wire values: [0, 1, 2]. */
export type EThemeMode = number;

/** Wire values: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38]. */
export type EWidgetType = number;

/** Public tenant-wide count; does not expose or grant access to any individual account. */
export interface ActiveUsersResponse {
  /** The configured site's tenant KID. */
  "tenantKid"?: string | null;
  /** Distinct qualifying bank/user pairs, including a genuine zero when no pairs match. */
  "count"?: bigint;
  /** The fixed 100-day lookback. */
  "lookbackDays"?: number;
  /** Exclusive UTC lower bound used for Log7.MS2000. */
  "sinceUtc"?: string;
  /** UTC time used for this cached count; it may be up to 5 minutes old. */
  "measuredAtUtc"?: string;
}

/** Describes public service availability without exposing database or customer data. */
export interface ApiStatusResponse {
  /** The public service name. */
  "service"?: string | null;
  /** The service availability. */
  "status"?: string | null;
  /** The API contract version. */
  "apiVersion"?: string | null;
}

/** Public presentation for the shared chart, without business data or credentials. */
export interface CycleChartPresentationResponse {
  /** Culture selected by Accept-Language. */
  "language"?: string | null;
  /** Localized graph labels, help and status messages from the portal resources. */
  "messages"?: Record<string, string> | null;
  /** Stable enum identifiers for grouped controls. */
  "stateNames"?: Record<string, string> | null;
}

/** Opaque image identity: eIcon name for an icon alone, otherwise canonical Kid.ToString(). */
export interface IconPresentationResponse {
  /** iconKid */
  "iconKid"?: string | null;
}

/** Minimal public site-tenant machine display, without resident or payment fields. */
export interface LiveMachineResponse {
  /** unitKid */
  "unitKid"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** startedAtUtc */
  "startedAtUtc"?: string;
  /** doneAtUtc */
  "doneAtUtc"?: string | null;
  /** temperature */
  "temperature"?: number | null;
}

/** Public thumbnail URL and relative portal destination; no original or sensor metadata. */
export interface PublicCameraPhoto {
  /** thumbnailUrl */
  "thumbnailUrl"?: string | null;
  /** workspacePath */
  "workspacePath"?: string | null;
}

/** Explicitly public, minimal WashDoc presentation. GraphSvg is text-free first-party SVG, not a raw measurement table. */
export interface PublicCycleWidgetResponse {
  /** cycleKid */
  "cycleKid"?: string | null;
  /** unitKid */
  "unitKid"?: string | null;
  /** unitName */
  "unitName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** startedAtUtc */
  "startedAtUtc"?: string;
  /** endedAtUtc */
  "endedAtUtc"?: string | null;
  /** finished */
  "finished"?: boolean;
  /** graphSvg */
  "graphSvg"?: string | null;
  /** refreshAfterSeconds */
  "refreshAfterSeconds"?: number;
  /** cycleKidText */
  "cycleKidText"?: string | null;
}

/** Public identity, display names and error code; no raw state payload. */
export interface PublicMachineError {
  /** kid */
  "kid"?: string | null;
  /** name */
  "name"?: string | null;
  /** bankName */
  "bankName"?: string | null;
  /** locationName */
  "locationName"?: string | null;
  /** errorId */
  "errorId"?: string | null;
}

/** Public machine-error page, with a protected next-page cursor and refresh interval. */
export interface PublicMachineErrorsPage {
  /** items */
  "items"?: (PublicMachineError)[] | null;
  /** nextCursor */
  "nextCursor"?: string | null;
  /** refreshAfterSeconds */
  "refreshAfterSeconds"?: number;
}

/** Minimal public unit display and expected timing. */
export interface PublicScopedProgressItem {
  /** Canonical site-bound unit identity. */
  "unitKid"?: string | null;
  /** Localized unit name. */
  "unitName"?: string | null;
  /** Localized location name. */
  "locationName"?: string | null;
  /** Expected start or null for unknown timing. */
  "startedAtUtc"?: string | null;
  /** Expected end or null for unknown timing. */
  "doneAtUtc"?: string | null;
  /** progress */
  "progress"?: UnitProgressResponse;
}

/** A bounded page of public progress for the exact site-bound scope. */
export interface PublicScopedProgressResponse {
  /** Requested canonical KID. */
  "scopeKid"?: string | null;
  /** Unit, Location or Bank enum name. */
  "scopeKind"?: string | null;
  /** UTC calculation time. */
  "calculatedAtUtc"?: string;
  /** Recommended refresh interval. */
  "refreshAfterSeconds"?: number;
  /** Public units in numeric identity order. */
  "items"?: (PublicScopedProgressItem)[] | null;
  /** Opaque next-page cursor, or null after the last page. */
  "nextCursor"?: string | null;
}

/** Public presentation selected by this API site's trusted tenant. */
export interface PublicWidgetPresentationResponse {
  /** Resolved supported culture for labels, names and number formatting. */
  "language"?: string | null;
  /** Hyphen-separated RGB hex palette for the API's circle SVGs. */
  "colors"?: string | null;
  /** RGB hex background inside the progress circle. */
  "background"?: string | null;
  /** Trusted HTTPS portal origin for the public purchase map, or null when unavailable. */
  "webBase"?: string | null;
  /** Existing localized portal text keys used by the widgets; contains no account data. */
  "labels"?: Record<string, string> | null;
  /** Public browser Maps key, restricted by HTTP referrer at Google; never a server credential. Null when maps are not configured. */
  "googleMapsBrowserKey"?: string | null;
  /** Public tenant branding icon. Local assets use the configured tenant Web origin; null if that origin is unavailable. */
  "brandIconUrl"?: string | null;
  /** Public validated CSS custom properties for this tenant's light presentation. */
  "brandLightTokens"?: Record<string, string> | null;
  /** Public validated CSS custom properties for this tenant's dark presentation. */
  "brandDarkTokens"?: Record<string, string> | null;
}

/** Purchase count and total for one currency; no currency conversion is performed. */
export interface PurchaseCurrencySnapshot {
  /** Stored currency code; null represents purchases with no currency code. */
  "currency"?: string | null;
  /** Number of matching purchase rows for this currency. */
  "count"?: bigint;
  /** Positive total in major currency units (negated stored Amount divided by 100). */
  "amount"?: number;
}

/** Total revenue at a coordinate across all retained purchases, independent of the coin limit. */
export interface PurchaseHeatmapPoint {
  /** latitude */
  "latitude"?: number;
  /** longitude */
  "longitude"?: number;
  /** amount */
  "amount"?: number;
}

/** Canonical transaction KID and UTC display time (original MS2000 without an offset). Amount is positive major units; currencies are not converted. */
export interface PurchaseMapPoint {
  /** kid */
  "kid"?: string | null;
  /** latitude */
  "latitude"?: number;
  /** longitude */
  "longitude"?: number;
  /** timestampUtc */
  "timestampUtc"?: string;
  /** amount */
  "amount"?: number;
}

/** A bounded, public display sample, not a complete transaction ledger. */
export interface PurchaseMapSnapshot {
  /** measuredAtUtc */
  "measuredAtUtc"?: string;
  /** refreshAfterSeconds */
  "refreshAfterSeconds"?: number;
  /** items */
  "items"?: (PurchaseMapPoint)[] | null;
  /** Complete retained purchase revenue grouped by coordinates; never limited by the animated coin count. */
  "heatmap"?: (PurchaseHeatmapPoint)[] | null;
}

/** Public purchase aggregate in Log1Hour, cached for up to one minute. */
export interface PurchasesResponse {
  /** Configured site tenant. */
  "tenantKid"?: string | null;
  /** Number of matching purchase rows. */
  "count"?: bigint;
  /** Nominal one-hour window maintained by the database. */
  "lookbackHours"?: number;
  /** Nominal window start; actual rows depend on Log1Hour cleanup. */
  "sinceUtc"?: string;
  /** UTC measurement time. */
  "measuredAtUtc"?: string;
  /** One count and amount per stored currency; empty for no matches. No currency conversion. */
  "currencies"?: (PurchaseCurrencySnapshot)[] | null;
}

/** Public count of reservations that have not ended. */
export interface ReservationsStatisticsResponse {
  /** Configured site's canonical tenant KID. */
  "tenantKid"?: string | null;
  /** Qualifying reservations; zero only for a successful empty count. */
  "count"?: bigint;
  /** UTC instant used for the strict reservation-end comparison. */
  "measuredAtUtc"?: string;
  /** Recommended polling interval, 60 seconds. */
  "refreshAfterSeconds"?: number;
}

/** Public count of currently running machines. */
export interface RunningMachinesResponse {
  /** Configured site's canonical tenant KID. */
  "tenantKid"?: string | null;
  /** Distinct qualifying machines; zero only for a successful empty count. */
  "count"?: bigint;
  /** UTC instant used for both strict time comparisons. */
  "measuredAtUtc"?: string;
  /** Recommended polling interval, 15 seconds. */
  "refreshAfterSeconds"?: number;
}

export interface GetBankAccountOptions {
  from?: string;
  through?: string;
  timeZone?: string;
  period?: number;
  locationKid?: string;
  locationKids?: (string)[];
  unitKid?: string;
  userKid?: string;
  kind?: string;
  includeZero?: boolean;
  includeBookings?: boolean;
  includeMonthly?: boolean;
  offset?: number;
  limit?: number;
}

export interface GetBankAccountRevisionOptions {
  from?: string;
  through?: string;
  timeZone?: string;
  period?: number;
  locationKid?: string;
  locationKids?: (string)[];
  unitKid?: string;
  userKid?: string;
  kind?: string;
  includeZero?: boolean;
  includeBookings?: boolean;
  includeMonthly?: boolean;
  offset?: number;
  limit?: number;
}

export interface GetBankExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  bankType?: string;
}

export interface GetBanksOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  bankType?: string;
}

export interface GetBankDocumentsOptions {
  locationKid?: string;
  locationKids?: (string)[];
  date?: string;
  search?: string;
  unitKids?: (string)[];
  sort?: string;
  direction?: string;
  unitKid?: string;
  from?: string;
  through?: string;
  offset?: number;
  limit?: number;
}

export interface GetBankDocumentsCountOptions {
  locationKid?: string;
  locationKids?: (string)[];
  date?: string;
  search?: string;
  unitKids?: (string)[];
  sort?: string;
  direction?: string;
  unitKid?: string;
  from?: string;
  through?: string;
  offset?: number;
  limit?: number;
}

export interface GetLocationDocumentsOptions {
  date?: string;
  search?: string;
  unitKids?: (string)[];
  sort?: string;
  direction?: string;
  unitKid?: string;
  from?: string;
  through?: string;
  offset?: number;
  limit?: number;
}

export interface GetLocationDocumentsCountOptions {
  date?: string;
  search?: string;
  unitKids?: (string)[];
  sort?: string;
  direction?: string;
  unitKid?: string;
  from?: string;
  through?: string;
  offset?: number;
  limit?: number;
}

export interface GetBankIconsOptions {
  kid?: (string)[];
}

export interface SearchBanksOptions {
  q?: string;
}

export interface SearchBankActivationOptions {
  q?: string;
}

export interface GetBankUserExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  locationKid?: string;
  deleted?: string;
  locationKids?: (string)[];
}

export interface GetBankUsersOptions {
  pageSize?: number;
  cursor?: string;
  sort?: string;
  direction?: string;
  filter?: string;
  userKid?: string;
  locationKid?: string;
  deleted?: string;
  locationKids?: (string)[];
}

export interface GetBankBookingsOptions {
  from?: string;
  through?: string;
  locationKid?: string;
  unitKid?: string;
  userKid?: string;
  status?: string;
  search?: string;
  offset?: number;
  limit?: number;
  locationKids?: (string)[];
}

export interface GetCameraNearestLocationOptions {
  latitude?: number;
  longitude?: number;
  accuracyMeters?: number;
}

export interface GetCameraResourceOptions {
  resourceKid?: string;
}

export interface GetCameraAvailabilityOptions {
  resourceKid?: string;
}

export interface SaveCameraCaptureOptions {
  background?: boolean;
}

export interface GetCameraCapturesOptions {
  resourceKid?: string;
  cursor?: string;
}

export interface GetCameraCaptureContentOptions {
  part?: string;
  range?: string;
}

export interface GetChecklistOptions {
  scopeKid?: string;
  includeResolved?: boolean;
  pageSize?: number;
  cursor?: string;
}

export interface ExportBankAccountOptions {
  from?: string;
  through?: string;
  timeZone?: string;
  period?: number;
  locationKid?: string;
  locationKids?: (string)[];
  unitKid?: string;
  userKid?: string;
  kind?: string;
  includeZero?: boolean;
  includeBookings?: boolean;
  includeMonthly?: boolean;
  offset?: number;
  limit?: number;
  format?: string;
}

export interface ExportBankUsersOptions {
  filter?: string;
  locationKid?: string;
  deleted?: string;
  sort?: string;
  direction?: string;
  locationKids?: (string)[];
}

export interface DownloadBankSettlementOptions {
  format?: string;
}

export interface DownloadUnitDocumentCsvOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface DownloadUnitDocumentXlsOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetBankErrorsOptions {
  days?: number;
  level?: string;
  includeAcknowledged?: boolean;
  pageSize?: number;
  cursor?: string;
}

export interface GetHostingLogsOptions {
  environment?: string;
  application?: string;
}

export interface GetHostingMetricsOptions {
  environment?: string;
  application?: string;
  hours?: number;
}

export interface GetInstallerExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  includeActivationCode?: boolean;
}

export interface GetInstallersOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  includeActivationCode?: boolean;
}

export interface GetActiveLocationCountOptions {
  bankKid?: string;
}

export interface GetLocationsOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  includeCoordinates?: boolean;
  bankKid?: string;
}

export interface GetLocationCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  bankKid?: string;
}

export interface SearchLocationsOptions {
  q?: string;
}

export interface SearchLocationActivationOptions {
  q?: string;
}

export interface GetLocationBookingCalendarsOptions {
  acceptLanguage?: string;
  from?: string;
  days?: number;
}

export interface GetLocationBookingRulesOptions {
  acceptLanguage?: string;
}

export interface GetControllerOverviewOptions {
  acceptLanguage?: string;
}

export interface GetControllerGroupOptions {
  acceptLanguage?: string;
}

export interface GetLocationUnitsOptions {
  acceptLanguage?: string;
}

export interface GetUnitOverviewOptions {
  acceptLanguage?: string;
}

export interface GetUnitGroupOptions {
  acceptLanguage?: string;
}

export interface GetUnitSettingHistoryOptions {
  beforeMs2000?: bigint;
  limit?: number;
}

export interface GetUnitIconsOptions {
  kid?: (string)[];
}

export interface GetLocationIconsOptions {
  kid?: (string)[];
}

export interface GetLocationOpeningHoursOptions {
  acceptLanguage?: string;
}

export interface GetLocationReservationHistoryOptions {
  from?: string;
  days?: number;
  acceptLanguage?: string;
}

export interface GetLocationReservationsOptions {
  from?: string;
  days?: number;
  acceptLanguage?: string;
}

export interface GetManagersOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
}

export interface GetManagerExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
}

export interface LoginManagerOptions {
  xPortalLoginClientIp?: string;
}

export interface GetCurrentManagerOptions {
  refresh?: boolean;
}

export interface GetNearestLocationsOptions {
  latitude?: number;
  longitude?: number;
}

export interface GetMyManagerWallboardDisplayOptions {
  portrait?: boolean;
  after?: string;
}

export interface GetServiceExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
}

export interface GetServicesOptions {
  filter?: string;
  sort?: string;
  direction?: string;
}

export interface GetBankSettlementsOptions {
  beforePeriod?: number;
}

export interface GetTenantStatusOptions {
  limit?: number;
}

export interface GetTenantStatusPageOptions {
  pageSize?: number;
  cursor?: string;
  offset?: number;
  anchor?: string;
}

export interface GetUnitTimelineOptions {
  fromUtc?: string;
  untilUtc?: string;
  sources?: string;
  field?: string;
  pageSize?: number;
  cursor?: string;
}

export interface GetUnitDocumentsOptions {
  sort?: string;
  direction?: string;
  offset?: number;
  limit?: number;
  search?: string;
  date?: string;
}

export interface GetUnitDocumentsCountOptions {
  search?: string;
  date?: string;
}

export interface GetUnitDocumentTableOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetUnitDocumentHtmlOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetUnitDocumentSvgOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
  width?: number;
}

export interface GetUnitDocumentSvg2Options {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetUnitDocumentGraphOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetUnitDocumentPngOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetUnitDocumentIconOptions {
  states?: string;
  settings?: string;
  historicalMeasurements?: boolean;
}

export interface GetOutOfOrderUnitsOptions {
  pageSize?: number;
  cursor?: string;
}

export interface GetUnitExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  locationKid?: string;
  terminalKid?: string;
  runningOnly?: boolean;
  autoOutOfOrderOnly?: boolean;
}

export interface GetTerminalExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  locationKid?: string;
  terminalKid?: string;
  runningOnly?: boolean;
}

export interface GetUnitsOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  includeCoordinates?: boolean;
  locationKid?: string;
  terminalKid?: string;
  runningOnly?: boolean;
  autoOutOfOrderOnly?: boolean;
}

export interface GetTerminalsOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
  includeCoordinates?: boolean;
  locationKid?: string;
  terminalKid?: string;
  runningOnly?: boolean;
}

export interface GetBankNextUserNumberOptions {
  userNumber?: string;
}

export interface GetUserExportCountOptions {
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
}

export interface GetUsersOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
}

export interface GetUserReceiptsOptions {
  offset?: number;
  revision?: string;
}

export interface SearchUsersOptions {
  q?: string;
  kidOnly?: boolean;
}

export interface SearchUserSmsOptions {
  q?: string;
}

export interface SearchUserActivationOptions {
  q?: string;
}

export interface FindWallboardPairingsOptions {
  displayId?: string;
}

export interface GetIconPresentationOptions {
  iconKid?: string;
  text?: string;
  count?: bigint;
  color?: number;
  useCalendarText?: boolean;
}

export interface GetPublicMachineErrorsOptions {
  pageSize?: number;
  cursor?: string;
}

export interface GetPublicCycleWidgetOptions {
  cycleKid?: string;
  unitKid?: string;
}

export interface GetPublicDisp73Options {
  limit?: number;
}

export interface GetPublicScopedUnitProgressOptions {
  pageSize?: number;
  cursor?: string;
}

