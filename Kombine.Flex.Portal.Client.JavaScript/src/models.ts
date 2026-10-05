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

/** Number of accessible locations with Enabled=1 and Deleted=0, independent of search and paging. */
export interface ActiveLocationCountResponse {
  /** count */
  "count"?: bigint;
  /** Ready-to-render Banks2 icon with Count in Kid.Count. */
  "iconKid"?: string | null;
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

/** Site database access indicator, never a manager permission or a guarantee for a business operation. */
export interface DatabaseAccessResponse {
  /** True: Log7 read/append privilege check succeeded. False: read succeeds but the write connection is absent, denies access or is read-only. Null: status could not be determined. Checks shared Log7 and bank-zero Log7 history only; bank grants, triggers and transactions may differ. */
  "canWrite"?: boolean | null;
  /** When this cached check was started. Known results are cached for ten minutes; unknown results for one minute. */
  "checkedAtUtc"?: string;
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

/** Values are indexed by column position. A missing cell is null; a stored null is a cell with null text/value. */
export interface DocumentTable {
  /** documentKid */
  "documentKid"?: string | null;
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

/** Installer metadata from the site's Log7 with BankId=TenantId. Kid is canonical with type Installer; clients can derive the display UserId from it. Missing Enabled is null. DeletedAt and LastActiveAt are UTC; LastActiveAt is the Alive krumb's MS2000, not its Text. No credentials are returned. */
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

/** An authorized location and its visible unit list. */
export interface LocationUnitsResponse {
  /** location */
  "location"?: BankLocationResponse;
  /** items */
  "items"?: (UnitOverviewResponse)[] | null;
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
  /** The listed manager's RetentionDays: days of visibility after deletion for otherwise authorized records. Missing, invalid or negative values become zero. Does not alter the caller's retention or schedule deletion. */
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

/** Credentials submitted over HTTPS; never log request bodies for this endpoint. */
export interface ManagerLoginRequest {
  /** The manager's email address. */
  "email": string;
  /** The original password, normalized only by the documented legacy verifier. */
  "password": string;
}

/** A resource category's independent ePermission2 flags. */
export interface ManagerOperationPermissionResponse {
  /** Managers, Bank, Location, Unit, User, Installer or Service. Match by resource name, not array position. */
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
  /** accounting, caretaker or operator; case-sensitive, required. */
  "role": string | null;
  /** Exactly Managers, Installer, Service, Bank, Location, Unit and User with last displayed flags. Explicit null represents an invalid stored mask. */
  "expectedFlags": Record<string, number | null> | null;
  /** Required for accounting: tabsRevision from GetManager or the last acknowledged edit. Other roles keep tabs unchanged. */
  "expectedTabsRevision"?: string | null;
}

/** The acknowledged preset and complete persisted permission matrix. */
export interface ManagerPermissionRoleResponse {
  /** The applied preset identity. */
  "role"?: string | null;
  /** All seven authoritative permission categories. */
  "operationPermissions"?: (ManagerOperationPermissionResponse)[] | null;
  /** False when applying the role to yourself removes the required Managers permissions. */
  "canEditPermissions"?: boolean;
  /** Complete recognized selected tabs after the atomic role assignment. */
  "tabs"?: (ManagerTabResponse)[] | null;
  /** Revision for the next tab or role edit. */
  "tabsRevision"?: string | null;
  /** False when the change removes your required Managers access. */
  "canEditTabs"?: boolean;
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
  /** API-computed icon identity; use unchanged in the icon image URL. */
  "iconKid"?: string | null;
  /** databaseAccess */
  "databaseAccess"?: DatabaseAccessResponse;
  /** Navigation labels from Log24 for explicitly scoped banks (including parents of granted locations). Requires Tabs and Bank Read. Empty for tenant-wide access. These labels do not grant bank-wide access; use resourceGrants. Names/icons are cached for one minute. */
  "navigationBanks"?: (BankNavigationResponse)[] | null;
  /** Optional organisation display text. Empty when absent; never an access grant. */
  "organisation"?: string | null;
  /** Days after deletion that an otherwise authorized bank, location, unit, user or reservation remains visible. Zero hides deleted objects; missing or invalid settings default to zero. Does not grant access or schedule physical deletion. */
  "retentionDays"?: number;
  /** themeMode */
  "themeMode"?: EThemeMode;
  /** Preferred icon set: g or line. Missing or unsupported stored values return g; this grants no permissions. */
  "iconSet"?: string | null;
  /** Names and IDs from the shared eTab enum, limited to the manager's recognized grants. */
  "tabDetails"?: (ManagerTabResponse)[] | null;
  /** Decoded bank/location scopes belonging only to this site. Empty means no bank/location access. */
  "resourceGrants"?: (ManagerResourceGrantResponse)[] | null;
  /** Independent operation permissions for Managers, Bank, Location, Unit, User, Installer and Service; missing stored values default to Read. */
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

/** Stable success/error code, containing no secrets. */
export interface PersonalAccountResult {
  /** code */
  "code"?: string | null;
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

/** Mixed-result shape; kind is an enum-derived type and Kid is the sole object identifier. */
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

/** ApiKeyHash is the hash stored in eSetting.Password and is included only for callers with Service Write. The published JSON names are preserved; this is never a plaintext API key. CanEdit is only a display hint; every mutation independently reauthorizes. */
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
}

/** The authorized unit and one descriptor-defined group, with read-only stored values. */
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
}

/** A selectable persisted value and its localized descriptor label. */
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

/** Wire values: [0, 1, 2]. */
export type EThemeMode = number;

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

/** Opaque image identity: eIcon name for an icon alone, otherwise canonical Kid.ToString(). */
export interface IconPresentationResponse {
  /** iconKid */
  "iconKid"?: string | null;
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
  /** Positive purchase total in major currency units; zero for no matches. */
  "amount"?: number;
  /** MAX(Currency), or null for no matches. No currency conversion. */
  "currency"?: string | null;
}

export interface GetBankAccountOptions {
  from?: string;
  through?: string;
  timeZone?: string;
  period?: number;
  locationKid?: string;
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
  unitKid?: string;
  userKid?: string;
  kind?: string;
  includeZero?: boolean;
  includeBookings?: boolean;
  includeMonthly?: boolean;
  offset?: number;
  limit?: number;
}

export interface GetBankDocumentsOptions {
  locationKid?: string;
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

export interface GetBankUsersOptions {
  pageSize?: number;
  cursor?: string;
  sort?: string;
  direction?: string;
  filter?: string;
  userKid?: string;
  locationKid?: string;
  deleted?: string;
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
}

export interface ExportBankAccountOptions {
  from?: string;
  through?: string;
  timeZone?: string;
  period?: number;
  locationKid?: string;
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
}

export interface DownloadBankSettlementOptions {
  format?: string;
}

export interface DownloadUnitDocumentCsvOptions {
  states?: string;
  settings?: string;
}

export interface DownloadUnitDocumentXlsOptions {
  states?: string;
  settings?: string;
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

export interface GetInstallersOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
}

export interface GetLocationsOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
  enabledOnly?: boolean;
  fields?: string;
}

export interface SearchLocationsOptions {
  q?: string;
}

export interface SearchLocationActivationOptions {
  q?: string;
}

export interface GetLocationBookingRulesOptions {
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

export interface GetManagersOptions {
  pageSize?: number;
  cursor?: string;
  filter?: string;
  sort?: string;
  direction?: string;
}

export interface LoginManagerOptions {
  xPortalLoginClientIp?: string;
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

export interface GetUnitDocumentTableOptions {
  states?: string;
  settings?: string;
}

export interface GetUnitDocumentHtmlOptions {
  states?: string;
  settings?: string;
}

export interface GetUnitDocumentSvgOptions {
  states?: string;
  settings?: string;
  width?: number;
}

export interface GetBankNextUserNumberOptions {
  userNumber?: string;
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

export interface GetIconPresentationOptions {
  iconKid?: string;
  text?: string;
  count?: bigint;
  color?: number;
}

export interface GetPublicDisp73Options {
  limit?: number;
}

