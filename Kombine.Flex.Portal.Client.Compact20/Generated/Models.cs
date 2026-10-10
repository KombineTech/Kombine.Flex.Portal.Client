// Generated from the public OpenAPI snapshot. Regenerate with scripts/Generate-PortalClientNet20.py --compact.
using System;
using System.Collections.Generic;

namespace Kombine.Flex.Portal.Client.Compact20
{
    /// <summary>A receipt assembled from this page's authorized lines. Further pages can contain more lines with the same key.</summary>
    public sealed class AccountDocumentResponse
    {
        /// <summary>key</summary>
        [JsonField("key")]
        public string Key { get { return _Key; } set { _Key = value; } }
        private string _Key;

        /// <summary>docId</summary>
        [JsonField("docId")]
        public int? DocId { get { return _DocId; } set { _DocId = value; } }
        private int? _DocId;

        /// <summary>lines</summary>
        [JsonField("lines")]
        public AccountEntryResponse[] Lines { get { return _Lines; } set { _Lines = value; } }
        private AccountEntryResponse[] _Lines;

        /// <summary>totals</summary>
        [JsonField("totals")]
        public AccountTotal[] Totals { get { return _Totals; } set { _Totals = value; } }
        private AccountTotal[] _Totals;

    }

    /// <summary>One posting, with its original sign/currency and an independently authorized reversal capability.</summary>
    public sealed class AccountEntryResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>userKid</summary>
        [JsonField("userKid")]
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>recordedAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("recordedAtUtc")]
        public string RecordedAtUtc { get { return _RecordedAtUtc; } set { _RecordedAtUtc = value; } }
        private string _RecordedAtUtc;

        /// <summary>amountMinor</summary>
        [JsonField("amountMinor")]
        public long? AmountMinor { get { return _AmountMinor; } set { _AmountMinor = value; } }
        private long? _AmountMinor;

        /// <summary>currency</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

        /// <summary>description</summary>
        [JsonField("description")]
        public string Description { get { return _Description; } set { _Description = value; } }
        private string _Description;

        /// <summary>transactionType</summary>
        [JsonField("transactionType")]
        public string TransactionType { get { return _TransactionType; } set { _TransactionType = value; } }
        private string _TransactionType;

        /// <summary>period</summary>
        [JsonField("period")]
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>reversed</summary>
        [JsonField("reversed")]
        public bool? Reversed { get { return _Reversed; } set { _Reversed = value; } }
        private bool? _Reversed;

        /// <summary>reversalOfKid</summary>
        [JsonField("reversalOfKid")]
        public string ReversalOfKid { get { return _ReversalOfKid; } set { _ReversalOfKid = value; } }
        private string _ReversalOfKid;

        /// <summary>userName</summary>
        [JsonField("userName")]
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        private string _UserName;

        /// <summary>userNumber</summary>
        [JsonField("userNumber")]
        public string UserNumber { get { return _UserNumber; } set { _UserNumber = value; } }
        private string _UserNumber;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>unitName</summary>
        [JsonField("unitName")]
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        private string _UnitName;

        /// <summary>canReverse</summary>
        [JsonField("canReverse")]
        public bool? CanReverse { get { return _CanReverse; } set { _CanReverse = value; } }
        private bool? _CanReverse;

        /// <summary>API-computed unit icon identity, ready for the image URL.</summary>
        [JsonField("unitIconKid")]
        public string UnitIconKid { get { return _UnitIconKid; } set { _UnitIconKid = value; } }
        private string _UnitIconKid;

        /// <summary>Opaque bank-scoped receipt key, shared by lines belonging to the same document.</summary>
        [JsonField("documentKey")]
        public string DocumentKey { get { return _DocumentKey; } set { _DocumentKey = value; } }
        private string _DocumentKey;

        /// <summary>Positive decoded DocId; null for standalone, malformed or payment-managed lines.</summary>
        [JsonField("documentId")]
        public int? DocumentId { get { return _DocumentId; } set { _DocumentId = value; } }
        private int? _DocumentId;

        /// <summary>Identity and free text were masked by the effective retention settings.</summary>
        [JsonField("isAnonymized")]
        public bool? IsAnonymized { get { return _IsAnonymized; } set { _IsAnonymized = value; } }
        private bool? _IsAnonymized;

        /// <summary>Credit, ReserveRefund or Managed for payment-managed lines; empty otherwise. No payment IDs.</summary>
        [JsonField("paymentKind")]
        public string PaymentKind { get { return _PaymentKind; } set { _PaymentKind = value; } }
        private string _PaymentKind;

    }

    /// <summary>Most frequent authorized currency and the ready-to-render Forbrug icon.</summary>
    public sealed class AccountIconResponse
    {
        /// <summary>currency</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Filtered postings, full-selection totals and server-resolved query defaults. No computed resident balance is implied.</summary>
    public sealed class AccountResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public AccountEntryResponse[] Items { get { return _Items; } set { _Items = value; } }
        private AccountEntryResponse[] _Items;

        /// <summary>units</summary>
        [JsonField("units")]
        public AccountUnitResponse[] Units { get { return _Units; } set { _Units = value; } }
        private AccountUnitResponse[] _Units;

        /// <summary>periods</summary>
        [JsonField("periods")]
        public int[] Periods { get { return _Periods; } set { _Periods = value; } }
        private int[] _Periods;

        /// <summary>totals</summary>
        [JsonField("totals")]
        public AccountTotal[] Totals { get { return _Totals; } set { _Totals = value; } }
        private AccountTotal[] _Totals;

        /// <summary>from ISO 8601 text, sent unchanged.</summary>
        [JsonField("from")]
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>through ISO 8601 text, sent unchanged.</summary>
        [JsonField("through")]
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>timeZone</summary>
        [JsonField("timeZone")]
        public string TimeZone { get { return _TimeZone; } set { _TimeZone = value; } }
        private string _TimeZone;

        /// <summary>period</summary>
        [JsonField("period")]
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>offset</summary>
        [JsonField("offset")]
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>limit</summary>
        [JsonField("limit")]
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

        /// <summary>hasMore</summary>
        [JsonField("hasMore")]
        public bool? HasMore { get { return _HasMore; } set { _HasMore = value; } }
        private bool? _HasMore;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>FlexOrm-style receipt grouping of this page. Items/offset/limit remain posting-based.</summary>
        [JsonField("documents")]
        public AccountDocumentResponse[] Documents { get { return _Documents; } set { _Documents = value; } }
        private AccountDocumentResponse[] _Documents;

    }

    /// <summary>Opaque revision of the filtered posting set; not an insertion time, cursor or access grant.</summary>
    public sealed class AccountRevisionResponse
    {
        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

    }

    /// <summary>AccountTotal</summary>
    public sealed class AccountTotal
    {
        /// <summary>currency</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

        /// <summary>entries</summary>
        [JsonField("entries")]
        public long? Entries { get { return _Entries; } set { _Entries = value; } }
        private long? _Entries;

        /// <summary>amountMinor</summary>
        [JsonField("amountMinor")]
        public long? AmountMinor { get { return _AmountMinor; } set { _AmountMinor = value; } }
        private long? _AmountMinor;

    }

    /// <summary>Scoped choices for the location and machine filters.</summary>
    public sealed class AccountUnitResponse
    {
        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

    }

    /// <summary>Accessible bank count for Enabled=1 and Deleted=0.</summary>
    public sealed class ActiveBankCountResponse
    {
        /// <summary>count</summary>
        [JsonField("count")]
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>Tab icon containing the authorized count.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Number of accessible locations with Enabled=1 and Deleted=0, independent of search and paging.</summary>
    public sealed class ActiveLocationCountResponse
    {
        /// <summary>count</summary>
        [JsonField("count")]
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>Ready-to-render Locations1 icon with Count in Kid.Count.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Accessible active units or terminals, independent of search and paging, with a ready-to-render navigation icon.</summary>
    public sealed class ActiveUnitCountResponse
    {
        /// <summary>count</summary>
        [JsonField("count")]
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>A portal link derived from an authorized API result, never from generated HTML.</summary>
    public sealed class AssistantLink
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>path</summary>
        [JsonField("path")]
        public string Path { get { return _Path; } set { _Path = value; } }
        private string _Path;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>bankKid</summary>
        [JsonField("bankKid")]
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>A prior visible message. History is untrusted context, never authorization or evidence.</summary>
    public sealed class AssistantMessage
    {
        /// <summary>role</summary>
        [JsonField("role")]
        public string Role { get { return _Role; } set { _Role = value; } }
        private string _Role;

        /// <summary>content</summary>
        [JsonField("content")]
        public string Content { get { return _Content; } set { _Content = value; } }
        private string _Content;

    }

    /// <summary>A bounded question with optional visible conversation history; no tenant selector.</summary>
    public sealed class AssistantRequest
    {
        /// <summary>The required question, between 1 and 2000 characters.</summary>
        [JsonField("question")]
        public string Question { get { return _Question; } set { _Question = value; } }
        private string _Question;

        /// <summary>Optional prior visible messages; always treated as untrusted context.</summary>
        [JsonField("history")]
        public AssistantMessage[] History { get { return _History; } set { _History = value; } }
        private AssistantMessage[] _History;

    }

    /// <summary>Plain text answer, executed operation IDs and server-verified object links.</summary>
    public sealed class AssistantResponse
    {
        /// <summary>answer</summary>
        [JsonField("answer")]
        public string Answer { get { return _Answer; } set { _Answer = value; } }
        private string _Answer;

        /// <summary>operations</summary>
        [JsonField("operations")]
        public string[] Operations { get { return _Operations; } set { _Operations = value; } }
        private string[] _Operations;

        /// <summary>links</summary>
        [JsonField("links")]
        public AssistantLink[] Links { get { return _Links; } set { _Links = value; } }
        private AssistantLink[] _Links;

    }

    /// <summary>Canonical bank identity, display metadata and stored state.</summary>
    public sealed class BankDirectoryItem
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>enabled</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>deleted</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>deletedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>Requested bank-level settings; null when scope does not authorize their disclosure. bankActivationCode additionally requires whole-tenant access and Bank Create.</summary>
        [JsonField("fields")]
        public Dictionary<string, string> Fields { get { return _Fields; } set { _Fields = value; } }
        private Dictionary<string, string> _Fields;

    }

    /// <summary>A bounded bank page and optional protected continuation.</summary>
    public sealed class BankDirectoryResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public BankDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private BankDirectoryItem[] _Items;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

        /// <summary>Selected optional field keys. Keep the same selection when following the cursor.</summary>
        [JsonField("fields")]
        public string[] Fields { get { return _Fields; } set { _Fields = value; } }
        private string[] _Fields;

        /// <summary>Whether this caller may display, search and sort bank activation codes.</summary>
        [JsonField("canReadBankActivationCode")]
        public bool? CanReadBankActivationCode { get { return _CanReadBankActivationCode; } set { _CanReadBankActivationCode = value; } }
        private bool? _CanReadBankActivationCode;

    }

    /// <summary>One document identity with authorized display metadata and the latest matching Cycle time.</summary>
    public sealed class BankDocumentItem
    {
        /// <summary>Canonical document KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Canonical location KID.</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>Canonical unit KID.</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>Current location name.</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>Current unit name.</summary>
        [JsonField("unitName")]
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        private string _UnitName;

        /// <summary>Decoded unit type, when known.</summary>
        [JsonField("unitType")]
        public int? UnitType { get { return _UnitType; } set { _UnitType = value; } }
        private int? _UnitType;

        /// <summary>Latest Cycle timestamp within the requested interval, in UTC. ISO 8601 text, sent unchanged.</summary>
        [JsonField("lastActivityUtc")]
        public string LastActivityUtc { get { return _LastActivityUtc; } set { _LastActivityUtc = value; } }
        private string _LastActivityUtc;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("unitIconKid")]
        public string UnitIconKid { get { return _UnitIconKid; } set { _UnitIconKid = value; } }
        private string _UnitIconKid;

    }

    /// <summary>One bounded result page and authorized filter choices.</summary>
    public sealed class BankDocumentPage
    {
        /// <summary>Documents in descending activity order.</summary>
        [JsonField("items")]
        public BankDocumentItem[] Items { get { return _Items; } set { _Items = value; } }
        private BankDocumentItem[] _Items;

        /// <summary>Visible, authorized locations in the bank.</summary>
        [JsonField("locations")]
        public BankLocationResponse[] Locations { get { return _Locations; } set { _Locations = value; } }
        private BankLocationResponse[] _Locations;

        /// <summary>Visible units within the selected location scope.</summary>
        [JsonField("units")]
        public DocumentUnitOption[] Units { get { return _Units; } set { _Units = value; } }
        private DocumentUnitOption[] _Units;

        /// <summary>Effective inclusive search start. ISO 8601 text, sent unchanged.</summary>
        [JsonField("from")]
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>Effective inclusive search end. ISO 8601 text, sent unchanged.</summary>
        [JsonField("through")]
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>Effective offset.</summary>
        [JsonField("offset")]
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>Effective page size.</summary>
        [JsonField("limit")]
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

        /// <summary>Another page existed when this query ran.</summary>
        [JsonField("hasMore")]
        public bool? HasMore { get { return _HasMore; } set { _HasMore = value; } }
        private bool? _HasMore;

    }

    /// <summary>Null offline means empty/incomplete status, never confirmed online.</summary>
    public sealed class BankIconResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>offline</summary>
        [JsonField("offline")]
        public bool? Offline { get { return _Offline; } set { _Offline = value; } }
        private bool? _Offline;

        /// <summary>status</summary>
        [JsonField("status")]
        public int? Status { get { return _Status; } set { _Status = value; } }
        private int? _Status;

    }

    /// <summary>Bounded, independently authorized bank icon results.</summary>
    public sealed class BankIconsResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public BankIconResponse[] Items { get { return _Items; } set { _Items = value; } }
        private BankIconResponse[] _Items;

    }

    /// <summary>Location display metadata; KID is its sole object identifier.</summary>
    public sealed class BankLocationResponse
    {
        /// <summary>Canonical site-bound location KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Location name, possibly empty.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Bank overview location metadata with the same status fields as GetLocations.</summary>
    public sealed class BankLocationStatusResponse
    {
        /// <summary>Canonical site-bound location KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Location name, possibly empty.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>True only when the stored Enabled value is exactly 1.</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>True for a positive Deleted MS2000 value; null for malformed values (visible only with a site-wide grant).</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>UTC deletion timestamp, or null for zero or an unrepresentable value. ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Display metadata only, not a bank detail record or permission.</summary>
    public sealed class BankNavigationResponse
    {
        /// <summary>Canonical bank KID in this site's tenant.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Bank eSetting.Name, empty when absent.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Current user settings. Missing Deleted means not deleted; Icon is an eIcon name, default user. Email and Sms are decoded from Log7 eSetting.Email and eSetting.SMS, empty when absent. Sms is the stored phone number, not a delivery operation.</summary>
    public sealed class BankUserResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

        /// <summary>deletedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>locations</summary>
        [JsonField("locations")]
        public UserLocationResponse[] Locations { get { return _Locations; } set { _Locations = value; } }
        private UserLocationResponse[] _Locations;

        /// <summary>tags</summary>
        [JsonField("tags")]
        public UserTagResponse[] Tags { get { return _Tags; } set { _Tags = value; } }
        private UserTagResponse[] _Tags;

        /// <summary>attributes</summary>
        [JsonField("attributes")]
        public UserAttributeResponse[] Attributes { get { return _Attributes; } set { _Attributes = value; } }
        private UserAttributeResponse[] _Attributes;

        /// <summary>email</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>sms</summary>
        [JsonField("sms")]
        public string Sms { get { return _Sms; } set { _Sms = value; } }
        private string _Sms;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>A bounded ascending user page. Cursors are opaque positions, never access grants.</summary>
    public sealed class BankUsersResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public BankUserResponse[] Items { get { return _Items; } set { _Items = value; } }
        private BankUserResponse[] _Items;

        /// <summary>previousCursor</summary>
        [JsonField("previousCursor")]
        public string PreviousCursor { get { return _PreviousCursor; } set { _PreviousCursor = value; } }
        private string _PreviousCursor;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

        /// <summary>scanLimitReached</summary>
        [JsonField("scanLimitReached")]
        public bool? ScanLimitReached { get { return _ScanLimitReached; } set { _ScanLimitReached = value; } }
        private bool? _ScanLimitReached;

    }

    /// <summary>Explicit desired operation, never a toggle that could reverse itself on retry.</summary>
    public sealed class BookingCommand
    {
        /// <summary>action</summary>
        [JsonField("action")]
        public string Action { get { return _Action; } set { _Action = value; } }
        private string _Action;

    }

    /// <summary>Current Log5 event. Local timestamps have no UTC offset; weekly positions have no absolute date.</summary>
    public sealed class BookingResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>userKid</summary>
        [JsonField("userKid")]
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>startLocal</summary>
        [JsonField("startLocal")]
        public string StartLocal { get { return _StartLocal; } set { _StartLocal = value; } }
        private string _StartLocal;

        /// <summary>endLocal</summary>
        [JsonField("endLocal")]
        public string EndLocal { get { return _EndLocal; } set { _EndLocal = value; } }
        private string _EndLocal;

        /// <summary>weeklyMinute</summary>
        [JsonField("weeklyMinute")]
        public int? WeeklyMinute { get { return _WeeklyMinute; } set { _WeeklyMinute = value; } }
        private int? _WeeklyMinute;

        /// <summary>durationMinutes</summary>
        [JsonField("durationMinutes")]
        public int? DurationMinutes { get { return _DurationMinutes; } set { _DurationMinutes = value; } }
        private int? _DurationMinutes;

        /// <summary>recordedAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("recordedAtUtc")]
        public string RecordedAtUtc { get { return _RecordedAtUtc; } set { _RecordedAtUtc = value; } }
        private string _RecordedAtUtc;

        /// <summary>cancelled</summary>
        [JsonField("cancelled")]
        public bool? Cancelled { get { return _Cancelled; } set { _Cancelled = value; } }
        private bool? _Cancelled;

        /// <summary>synced</summary>
        [JsonField("synced")]
        public bool? Synced { get { return _Synced; } set { _Synced = value; } }
        private bool? _Synced;

        /// <summary>source</summary>
        [JsonField("source")]
        public string Source { get { return _Source; } set { _Source = value; } }
        private string _Source;

        /// <summary>userName</summary>
        [JsonField("userName")]
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        private string _UserName;

        /// <summary>userNumber</summary>
        [JsonField("userNumber")]
        public string UserNumber { get { return _UserNumber; } set { _UserNumber = value; } }
        private string _UserNumber;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>unitName</summary>
        [JsonField("unitName")]
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        private string _UnitName;

        /// <summary>canCancel</summary>
        [JsonField("canCancel")]
        public bool? CanCancel { get { return _CanCancel; } set { _CanCancel = value; } }
        private bool? _CanCancel;

        /// <summary>canRestore</summary>
        [JsonField("canRestore")]
        public bool? CanRestore { get { return _CanRestore; } set { _CanRestore = value; } }
        private bool? _CanRestore;

        /// <summary>API-computed unit icon identity, ready for the image URL.</summary>
        [JsonField("unitIconKid")]
        public string UnitIconKid { get { return _UnitIconKid; } set { _UnitIconKid = value; } }
        private string _UnitIconKid;

    }

    /// <summary>A canonical authorized unit identity with its localized name.</summary>
    public sealed class BookingRuleUnit
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

    }

    /// <summary>Canonical scope identifiers and localized labels for a unit filter.</summary>
    public sealed class BookingUnitResponse
    {
        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

    }

    /// <summary>A bounded page; dates apply to ordinary reservation starts, while weekly entries are always included.</summary>
    public sealed class BookingsResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public BookingResponse[] Items { get { return _Items; } set { _Items = value; } }
        private BookingResponse[] _Items;

        /// <summary>units</summary>
        [JsonField("units")]
        public BookingUnitResponse[] Units { get { return _Units; } set { _Units = value; } }
        private BookingUnitResponse[] _Units;

        /// <summary>from ISO 8601 text, sent unchanged.</summary>
        [JsonField("from")]
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>through ISO 8601 text, sent unchanged.</summary>
        [JsonField("through")]
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>offset</summary>
        [JsonField("offset")]
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>limit</summary>
        [JsonField("limit")]
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

        /// <summary>hasMore</summary>
        [JsonField("hasMore")]
        public bool? HasMore { get { return _HasMore; } set { _HasMore = value; } }
        private bool? _HasMore;

    }

    /// <summary>Site database access indicator, never a manager permission or a guarantee for a business operation.</summary>
    public sealed class DatabaseAccessResponse
    {
        /// <summary>True: Log7 read/append privilege check succeeded. False: read succeeds but the write connection is absent, denies access or is read-only. Null: status could not be determined. Checks shared Log7 and bank-zero Log7 history only; bank grants, triggers and transactions may differ.</summary>
        [JsonField("canWrite")]
        public bool? CanWrite { get { return _CanWrite; } set { _CanWrite = value; } }
        private bool? _CanWrite;

        /// <summary>When this cached check was started. Known results are cached for ten minutes; unknown results for one minute. ISO 8601 text, sent unchanged.</summary>
        [JsonField("checkedAtUtc")]
        public string CheckedAtUtc { get { return _CheckedAtUtc; } set { _CheckedAtUtc = value; } }
        private string _CheckedAtUtc;

    }

    /// <summary>Finite numeric interpretation alongside original text; calculated values have no original text.</summary>
    public sealed class DocumentCell
    {
        /// <summary>value</summary>
        [JsonField("value")]
        public double? Value { get { return _Value; } set { _Value = value; } }
        private double? _Value;

        /// <summary>text</summary>
        [JsonField("text")]
        public string Text { get { return _Text; } set { _Text = value; } }
        private string _Text;

        /// <summary>isCalculated</summary>
        [JsonField("isCalculated")]
        public bool? IsCalculated { get { return _IsCalculated; } set { _IsCalculated = value; } }
        private bool? _IsCalculated;

    }

    /// <summary>Stable enum column metadata; kind is state or setting.</summary>
    public sealed class DocumentColumn
    {
        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>localization</summary>
        [JsonField("localization")]
        public string Localization { get { return _Localization; } set { _Localization = value; } }
        private string _Localization;

        /// <summary>color</summary>
        [JsonField("color")]
        public string Color { get { return _Color; } set { _Color = value; } }
        private string _Color;

        /// <summary>onlyNumericValues</summary>
        [JsonField("onlyNumericValues")]
        public bool? OnlyNumericValues { get { return _OnlyNumericValues; } set { _OnlyNumericValues = value; } }
        private bool? _OnlyNumericValues;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Values are indexed by column position. A missing cell is null; a stored null is a cell with null text/value.</summary>
    public sealed class DocumentTable
    {
        /// <summary>documentKid</summary>
        [JsonField("documentKid")]
        public string DocumentKid { get { return _DocumentKid; } set { _DocumentKid = value; } }
        private string _DocumentKid;

        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>unitName</summary>
        [JsonField("unitName")]
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        private string _UnitName;

        /// <summary>finished</summary>
        [JsonField("finished")]
        public bool? Finished { get { return _Finished; } set { _Finished = value; } }
        private bool? _Finished;

        /// <summary>fromMs2000</summary>
        [JsonField("fromMs2000")]
        public long? FromMs2000 { get { return _FromMs2000; } set { _FromMs2000 = value; } }
        private long? _FromMs2000;

        /// <summary>toMs2000</summary>
        [JsonField("toMs2000")]
        public long? ToMs2000 { get { return _ToMs2000; } set { _ToMs2000 = value; } }
        private long? _ToMs2000;

        /// <summary>columns</summary>
        [JsonField("columns")]
        public DocumentColumn[] Columns { get { return _Columns; } set { _Columns = value; } }
        private DocumentColumn[] _Columns;

        /// <summary>rows</summary>
        [JsonField("rows")]
        public DocumentTableRow[] Rows { get { return _Rows; } set { _Rows = value; } }
        private DocumentTableRow[] _Rows;

    }

    /// <summary>One exact MS2000 timestamp with cells in column order.</summary>
    public sealed class DocumentTableRow
    {
        /// <summary>ms2000</summary>
        [JsonField("ms2000")]
        public long? Ms2000 { get { return _Ms2000; } set { _Ms2000 = value; } }
        private long? _Ms2000;

        /// <summary>cells</summary>
        [JsonField("cells")]
        public DocumentCell[] Cells { get { return _Cells; } set { _Cells = value; } }
        private DocumentCell[] _Cells;

    }

    /// <summary>Visible unit filter choice.</summary>
    public sealed class DocumentUnitOption
    {
        /// <summary>Canonical unit KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Canonical location KID.</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>Current unit name.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>Decoded unit type, when known.</summary>
        [JsonField("unitType")]
        public int? UnitType { get { return _UnitType; } set { _UnitType = value; } }
        private int? _UnitType;

    }

    /// <summary>Previous UTC day's total; Bytes is an unsigned decimal string to preserve uint64 precision.</summary>
    public sealed class HostingBandwidth
    {
        /// <summary>dateUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("dateUtc")]
        public string DateUtc { get { return _DateUtc; } set { _DateUtc = value; } }
        private string _DateUtc;

        /// <summary>bytes</summary>
        [JsonField("bytes")]
        public string Bytes { get { return _Bytes; } set { _Bytes = value; } }
        private string _Bytes;

        /// <summary>errorCode</summary>
        [JsonField("errorCode")]
        public string ErrorCode { get { return _ErrorCode; } set { _ErrorCode = value; } }
        private string _ErrorCode;

    }

    /// <summary>A bounded snapshot of shared application runtime output, for designated operators only.</summary>
    public sealed class HostingLogsResponse
    {
        /// <summary>beta or production.</summary>
        [JsonField("environment")]
        public string Environment { get { return _Environment; } set { _Environment = value; } }
        private string _Environment;

        /// <summary>portal-api, equipment-api or portal-web.</summary>
        [JsonField("application")]
        public string Application { get { return _Application; } set { _Application = value; } }
        private string _Application;

        /// <summary>Time of the provider snapshot, not the event timestamp. ISO 8601 text, sent unchanged.</summary>
        [JsonField("fetchedAtUtc")]
        public string FetchedAtUtc { get { return _FetchedAtUtc; } set { _FetchedAtUtc = value; } }
        private string _FetchedAtUtc;

        /// <summary>At most 100 plain-text lines; untrusted output, never HTML.</summary>
        [JsonField("lines")]
        public string[] Lines { get { return _Lines; } set { _Lines = value; } }
        private string[] _Lines;

        /// <summary>True when the local byte/line bound removed content.</summary>
        [JsonField("truncated")]
        public bool? Truncated { get { return _Truncated; } set { _Truncated = value; } }
        private bool? _Truncated;

    }

    /// <summary>A metric in percent or count, kept separate by component and instance; failures have no series.</summary>
    public sealed class HostingMetric
    {
        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>unit</summary>
        [JsonField("unit")]
        public string Unit { get { return _Unit; } set { _Unit = value; } }
        private string _Unit;

        /// <summary>series</summary>
        [JsonField("series")]
        public HostingSeries[] Series { get { return _Series; } set { _Series = value; } }
        private HostingSeries[] _Series;

        /// <summary>errorCode</summary>
        [JsonField("errorCode")]
        public string ErrorCode { get { return _ErrorCode; } set { _ErrorCode = value; } }
        private string _ErrorCode;

    }

    /// <summary>One authorized app/cluster hosting snapshot; never a customer's individual consumption.</summary>
    public sealed class HostingMetricsResponse
    {
        /// <summary>environment</summary>
        [JsonField("environment")]
        public string Environment { get { return _Environment; } set { _Environment = value; } }
        private string _Environment;

        /// <summary>application</summary>
        [JsonField("application")]
        public string Application { get { return _Application; } set { _Application = value; } }
        private string _Application;

        /// <summary>fromUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("fromUtc")]
        public string FromUtc { get { return _FromUtc; } set { _FromUtc = value; } }
        private string _FromUtc;

        /// <summary>toUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("toUtc")]
        public string ToUtc { get { return _ToUtc; } set { _ToUtc = value; } }
        private string _ToUtc;

        /// <summary>fetchedAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("fetchedAtUtc")]
        public string FetchedAtUtc { get { return _FetchedAtUtc; } set { _FetchedAtUtc = value; } }
        private string _FetchedAtUtc;

        /// <summary>refreshAfterSeconds</summary>
        [JsonField("refreshAfterSeconds")]
        public int? RefreshAfterSeconds { get { return _RefreshAfterSeconds; } set { _RefreshAfterSeconds = value; } }
        private int? _RefreshAfterSeconds;

        /// <summary>metrics</summary>
        [JsonField("metrics")]
        public HostingMetric[] Metrics { get { return _Metrics; } set { _Metrics = value; } }
        private HostingMetric[] _Metrics;

        /// <summary>bandwidth</summary>
        [JsonField("bandwidth")]
        public HostingBandwidth Bandwidth { get { return _Bandwidth; } set { _Bandwidth = value; } }
        private HostingBandwidth _Bandwidth;

    }

    /// <summary>A UTC measurement; null means a gap or a non-finite provider sample, never zero.</summary>
    public sealed class HostingPoint
    {
        /// <summary>timestampUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("timestampUtc")]
        public string TimestampUtc { get { return _TimestampUtc; } set { _TimestampUtc = value; } }
        private string _TimestampUtc;

        /// <summary>value</summary>
        [JsonField("value")]
        public double? Value { get { return _Value; } set { _Value = value; } }
        private double? _Value;

    }

    /// <summary>Provider component and instance labels are display text, never resource grants.</summary>
    public sealed class HostingSeries
    {
        /// <summary>component</summary>
        [JsonField("component")]
        public string Component { get { return _Component; } set { _Component = value; } }
        private string _Component;

        /// <summary>instance</summary>
        [JsonField("instance")]
        public string Instance { get { return _Instance; } set { _Instance = value; } }
        private string _Instance;

        /// <summary>points</summary>
        [JsonField("points")]
        public HostingPoint[] Points { get { return _Points; } set { _Points = value; } }
        private HostingPoint[] _Points;

    }

    /// <summary>Authorized installer details and display hints for icon editing. Hints never authorize writes.</summary>
    public sealed class InstallerDetailsResponse
    {
        /// <summary>installer</summary>
        [JsonField("installer")]
        public InstallerDirectoryItem Installer { get { return _Installer; } set { _Installer = value; } }
        private InstallerDirectoryItem _Installer;

        /// <summary>canEditIcon</summary>
        [JsonField("canEditIcon")]
        public bool? CanEditIcon { get { return _CanEditIcon; } set { _CanEditIcon = value; } }
        private bool? _CanEditIcon;

        /// <summary>iconRevision</summary>
        [JsonField("iconRevision")]
        public string IconRevision { get { return _IconRevision; } set { _IconRevision = value; } }
        private string _IconRevision;

        /// <summary>availableIcons</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

    }

    /// <summary>Installer metadata from the site's Log7 with BankId=TenantId. Kid is canonical with type Installer; clients can derive the display UserId from it. Missing Enabled is null. DeletedAt and LastActiveAt are UTC; LastActiveAt is the Alive krumb's MS2000, not its Text. Passwords are never returned.</summary>
    public sealed class InstallerDirectoryItem
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>email</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>locations</summary>
        [JsonField("locations")]
        public InstallerLocationResponse[] Locations { get { return _Locations; } set { _Locations = value; } }
        private InstallerLocationResponse[] _Locations;

        /// <summary>tags</summary>
        [JsonField("tags")]
        public InstallerTagResponse[] Tags { get { return _Tags; } set { _Tags = value; } }
        private InstallerTagResponse[] _Tags;

        /// <summary>deleted</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>deletedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>enabled</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>lastActiveAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("lastActiveAt")]
        public string LastActiveAt { get { return _LastActiveAt; } set { _LastActiveAt = value; } }
        private string _LastActiveAt;

        /// <summary>User activation code, only when explicitly requested with Installer Create permission.</summary>
        [JsonField("activationCode")]
        public string ActivationCode { get { return _ActivationCode; } set { _ActivationCode = value; } }
        private string _ActivationCode;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>One installer page. Continue until NextCursor is null, even if Items is empty.</summary>
    public sealed class InstallerDirectoryResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public InstallerDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private InstallerDirectoryItem[] _Items;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

    }

    /// <summary>Desired exact Person icon and the opaque revision from GetInstaller.</summary>
    public sealed class InstallerIconRequest
    {
        /// <summary>icon</summary>
        [JsonField("icon")]
        public string Icon { get { return _Icon; } set { _Icon = value; } }
        private string _Icon;

        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Authoritative committed icon; update UI only after a complete successful response.</summary>
    public sealed class InstallerIconResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>iconRevision</summary>
        [JsonField("iconRevision")]
        public string IconRevision { get { return _IconRevision; } set { _IconRevision = value; } }
        private string _IconRevision;

        /// <summary>availableIcons</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Stored location association in the installer's tenant bank, with Access/NoAccess state. Metadata only, never an authorization grant for the caller. Names are not looked up.</summary>
    public sealed class InstallerLocationResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>state</summary>
        [JsonField("state")]
        public string State { get { return _State; } set { _State = value; } }
        private string _State;

    }

    /// <summary>Stored tag association, including locked/deleted/history states; state is the eTagState name.</summary>
    public sealed class InstallerTagResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>state</summary>
        [JsonField("state")]
        public string State { get { return _State; } set { _State = value; } }
        private string _State;

    }

    /// <summary>One server card; errors contain no transport details.</summary>
    public sealed class LiveLogCard
    {
        /// <summary>Fixed server selector.</summary>
        [JsonField("server")]
        public string Server { get { return _Server; } set { _Server = value; } }
        private string _Server;

        /// <summary>Null on success; otherwise live-logs-not-configured or live-logs-unavailable.</summary>
        [JsonField("errorCode")]
        public string ErrorCode { get { return _ErrorCode; } set { _ErrorCode = value; } }
        private string _ErrorCode;

        /// <summary>Newest events first; at most 100.</summary>
        [JsonField("events")]
        public LiveLogEvent[] Events { get { return _Events; } set { _Events = value; } }
        private LiveLogEvent[] _Events;

    }

    /// <summary>One sanitized event from the bounded process-local buffer.</summary>
    public sealed class LiveLogEvent
    {
        /// <summary>UTC event time. ISO 8601 text, sent unchanged.</summary>
        [JsonField("timestamp")]
        public string Timestamp { get { return _Timestamp; } set { _Timestamp = value; } }
        private string _Timestamp;

        /// <summary>Logging severity.</summary>
        [JsonField("level")]
        public string Level { get { return _Level; } set { _Level = value; } }
        private string _Level;

        /// <summary>Static message template, not arbitrary state.</summary>
        [JsonField("message")]
        public string Message { get { return _Message; } set { _Message = value; } }
        private string _Message;

        /// <summary>Logger category.</summary>
        [JsonField("category")]
        public string Category { get { return _Category; } set { _Category = value; } }
        private string _Category;

        /// <summary>Optional HTTP result.</summary>
        [JsonField("statusCode")]
        public int? StatusCode { get { return _StatusCode; } set { _StatusCode = value; } }
        private int? _StatusCode;

        /// <summary>Optional server processing time.</summary>
        [JsonField("elapsedMilliseconds")]
        public long? ElapsedMilliseconds { get { return _ElapsedMilliseconds; } set { _ElapsedMilliseconds = value; } }
        private long? _ElapsedMilliseconds;

        /// <summary>Authorized diagnostic bank identifier.</summary>
        [JsonField("bankId")]
        public int? BankId { get { return _BankId; } set { _BankId = value; } }
        private int? _BankId;

        /// <summary>Authorized requested resident identifiers.</summary>
        [JsonField("userIds")]
        public int[] UserIds { get { return _UserIds; } set { _UserIds = value; } }
        private int[] _UserIds;

        /// <summary>Correlation identifier.</summary>
        [JsonField("traceId")]
        public string TraceId { get { return _TraceId; } set { _TraceId = value; } }
        private string _TraceId;

        /// <summary>Optional approved chat question text, at most 2000 characters.</summary>
        [JsonField("question")]
        public string Question { get { return _Question; } set { _Question = value; } }
        private string _Question;

        /// <summary>Sanitized structured values for message-template placeholders.</summary>
        [JsonField("fields")]
        public Dictionary<string, object> Fields { get { return _Fields; } set { _Fields = value; } }
        private Dictionary<string, object> _Fields;

    }

    /// <summary>Authorized current-tenant snapshot for three server cards.</summary>
    public sealed class LiveLogsResponse
    {
        /// <summary>Canonical tenant KID.</summary>
        [JsonField("tenantKid")]
        public string TenantKid { get { return _TenantKid; } set { _TenantKid = value; } }
        private string _TenantKid;

        /// <summary>UTC snapshot time. ISO 8601 text, sent unchanged.</summary>
        [JsonField("fetchedAtUtc")]
        public string FetchedAtUtc { get { return _FetchedAtUtc; } set { _FetchedAtUtc = value; } }
        private string _FetchedAtUtc;

        /// <summary>Minimum polling interval.</summary>
        [JsonField("refreshAfterSeconds")]
        public int? RefreshAfterSeconds { get { return _RefreshAfterSeconds; } set { _RefreshAfterSeconds = value; } }
        private int? _RefreshAfterSeconds;

        /// <summary>Portal API, Equipment API and Portal Web.</summary>
        [JsonField("servers")]
        public LiveLogCard[] Servers { get { return _Servers; } set { _Servers = value; } }
        private LiveLogCard[] _Servers;

    }

    /// <summary>Stable code, localized plain text and whether the row needs attention. Never HTML.</summary>
    public sealed class LocationBookingRule
    {
        /// <summary>code</summary>
        [JsonField("code")]
        public string Code { get { return _Code; } set { _Code = value; } }
        private string _Code;

        /// <summary>text</summary>
        [JsonField("text")]
        public string Text { get { return _Text; } set { _Text = value; } }
        private string _Text;

        /// <summary>warning</summary>
        [JsonField("warning")]
        public bool? Warning { get { return _Warning; } set { _Warning = value; } }
        private bool? _Warning;

        /// <summary>Optional ordered plain-text parts. Concatenate text without separators to reproduce Text; clients may emphasize values. Fall back to Text when parts are absent or empty. Never markup.</summary>
        [JsonField("parts")]
        public LocationBookingRulePart[] Parts { get { return _Parts; } set { _Parts = value; } }
        private LocationBookingRulePart[] _Parts;

    }

    /// <summary>Localized heading/help, authorized units and rules for a compact display section.</summary>
    public sealed class LocationBookingRuleGroup
    {
        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>units</summary>
        [JsonField("units")]
        public BookingRuleUnit[] Units { get { return _Units; } set { _Units = value; } }
        private BookingRuleUnit[] _Units;

        /// <summary>rules</summary>
        [JsonField("rules")]
        public LocationBookingRule[] Rules { get { return _Rules; } set { _Rules = value; } }
        private LocationBookingRule[] _Rules;

        /// <summary>common</summary>
        [JsonField("common")]
        public bool? Common { get { return _Common; } set { _Common = value; } }
        private bool? _Common;

        /// <summary>Optional localized explanation of how the section applies to its units.</summary>
        [JsonField("help")]
        public string Help { get { return _Help; } set { _Help = value; } }
        private string _Help;

    }

    /// <summary>Plain text and a semantic value flag; presentation is the client's responsibility.</summary>
    public sealed class LocationBookingRulePart
    {
        /// <summary>text</summary>
        [JsonField("text")]
        public string Text { get { return _Text; } set { _Text = value; } }
        private string _Text;

        /// <summary>isValue</summary>
        [JsonField("isValue")]
        public bool? IsValue { get { return _IsValue; } set { _IsValue = value; } }
        private bool? _IsValue;

    }

    /// <summary>Authorized configured booking rules, observed at calculatedAt. Not a booking availability decision.</summary>
    public sealed class LocationBookingRulesResponse
    {
        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>calculatedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("calculatedAt")]
        public string CalculatedAt { get { return _CalculatedAt; } set { _CalculatedAt = value; } }
        private string _CalculatedAt;

        /// <summary>groups</summary>
        [JsonField("groups")]
        public LocationBookingRuleGroup[] Groups { get { return _Groups; } set { _Groups = value; } }
        private LocationBookingRuleGroup[] _Groups;

    }

    /// <summary>Bank and location identifiers are canonical KIDs. Activation codes are null without the required Create permission and scope.</summary>
    public sealed class LocationDirectoryItem
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>bankKid</summary>
        [JsonField("bankKid")]
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

        /// <summary>bankName</summary>
        [JsonField("bankName")]
        public string BankName { get { return _BankName; } set { _BankName = value; } }
        private string _BankName;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>vismaCustNo</summary>
        [JsonField("vismaCustNo")]
        public string VismaCustNo { get { return _VismaCustNo; } set { _VismaCustNo = value; } }
        private string _VismaCustNo;

        /// <summary>bankActivationCode</summary>
        [JsonField("bankActivationCode")]
        public string BankActivationCode { get { return _BankActivationCode; } set { _BankActivationCode = value; } }
        private string _BankActivationCode;

        /// <summary>locationActivationCode</summary>
        [JsonField("locationActivationCode")]
        public string LocationActivationCode { get { return _LocationActivationCode; } set { _LocationActivationCode = value; } }
        private string _LocationActivationCode;

        /// <summary>enabled</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>deleted</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>deletedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>address</summary>
        [JsonField("address")]
        public string Address { get { return _Address; } set { _Address = value; } }
        private string _Address;

        /// <summary>zip</summary>
        [JsonField("zip")]
        public string Zip { get { return _Zip; } set { _Zip = value; } }
        private string _Zip;

        /// <summary>longitude</summary>
        [JsonField("longitude")]
        public double? Longitude { get { return _Longitude; } set { _Longitude = value; } }
        private double? _Longitude;

        /// <summary>latitude</summary>
        [JsonField("latitude")]
        public double? Latitude { get { return _Latitude; } set { _Latitude = value; } }
        private double? _Latitude;

        /// <summary>teltonikaSms</summary>
        [JsonField("teltonikaSms")]
        public string TeltonikaSms { get { return _TeltonikaSms; } set { _TeltonikaSms = value; } }
        private string _TeltonikaSms;

        /// <summary>alternativeBankName</summary>
        [JsonField("alternativeBankName")]
        public string AlternativeBankName { get { return _AlternativeBankName; } set { _AlternativeBankName = value; } }
        private string _AlternativeBankName;

        /// <summary>mask</summary>
        [JsonField("mask")]
        public string Mask { get { return _Mask; } set { _Mask = value; } }
        private string _Mask;

        /// <summary>timeZone</summary>
        [JsonField("timeZone")]
        public string TimeZone { get { return _TimeZone; } set { _TimeZone = value; } }
        private string _TimeZone;

        /// <summary>online</summary>
        [JsonField("online")]
        public bool? Online { get { return _Online; } set { _Online = value; } }
        private bool? _Online;

        /// <summary>lastContactAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("lastContactAt")]
        public string LastContactAt { get { return _LastContactAt; } set { _LastContactAt = value; } }
        private string _LastContactAt;

        /// <summary>vismaCrAcNo</summary>
        [JsonField("vismaCrAcNo")]
        public string VismaCrAcNo { get { return _VismaCrAcNo; } set { _VismaCrAcNo = value; } }
        private string _VismaCrAcNo;

        /// <summary>vismaInvoiceVersion</summary>
        [JsonField("vismaInvoiceVersion")]
        public string VismaInvoiceVersion { get { return _VismaInvoiceVersion; } set { _VismaInvoiceVersion = value; } }
        private string _VismaInvoiceVersion;

        /// <summary>vismaOrdre</summary>
        [JsonField("vismaOrdre")]
        public string VismaOrdre { get { return _VismaOrdre; } set { _VismaOrdre = value; } }
        private string _VismaOrdre;

        /// <summary>vismaPNTurnover</summary>
        [JsonField("vismaPNTurnover")]
        public string VismaPNTurnover { get { return _VismaPNTurnover; } set { _VismaPNTurnover = value; } }
        private string _VismaPNTurnover;

        /// <summary>vismaPNSettlement</summary>
        [JsonField("vismaPNSettlement")]
        public string VismaPNSettlement { get { return _VismaPNSettlement; } set { _VismaPNSettlement = value; } }
        private string _VismaPNSettlement;

        /// <summary>vismaSettlement</summary>
        [JsonField("vismaSettlement")]
        public string VismaSettlement { get { return _VismaSettlement; } set { _VismaSettlement = value; } }
        private string _VismaSettlement;

        /// <summary>vismaVAT</summary>
        [JsonField("vismaVAT")]
        public string VismaVAT { get { return _VismaVAT; } set { _VismaVAT = value; } }
        private string _VismaVAT;

        /// <summary>vismaServiceKey</summary>
        [JsonField("vismaServiceKey")]
        public string VismaServiceKey { get { return _VismaServiceKey; } set { _VismaServiceKey = value; } }
        private string _VismaServiceKey;

        /// <summary>vismaStart</summary>
        [JsonField("vismaStart")]
        public string VismaStart { get { return _VismaStart; } set { _VismaStart = value; } }
        private string _VismaStart;

        /// <summary>vismaNote</summary>
        [JsonField("vismaNote")]
        public string VismaNote { get { return _VismaNote; } set { _VismaNote = value; } }
        private string _VismaNote;

        /// <summary>hiddenNote</summary>
        [JsonField("hiddenNote")]
        public string HiddenNote { get { return _HiddenNote; } set { _HiddenNote = value; } }
        private string _HiddenNote;

        /// <summary>vismaGuaranteeMonth</summary>
        [JsonField("vismaGuaranteeMonth")]
        public string VismaGuaranteeMonth { get { return _VismaGuaranteeMonth; } set { _VismaGuaranteeMonth = value; } }
        private string _VismaGuaranteeMonth;

        /// <summary>vismaGuaranteeUnder</summary>
        [JsonField("vismaGuaranteeUnder")]
        public string VismaGuaranteeUnder { get { return _VismaGuaranteeUnder; } set { _VismaGuaranteeUnder = value; } }
        private string _VismaGuaranteeUnder;

        /// <summary>vismaGuarantee</summary>
        [JsonField("vismaGuarantee")]
        public string VismaGuarantee { get { return _VismaGuarantee; } set { _VismaGuarantee = value; } }
        private string _VismaGuarantee;

        /// <summary>vismaGuaranteeCustomer</summary>
        [JsonField("vismaGuaranteeCustomer")]
        public string VismaGuaranteeCustomer { get { return _VismaGuaranteeCustomer; } set { _VismaGuaranteeCustomer = value; } }
        private string _VismaGuaranteeCustomer;

        /// <summary>vismaGuaranteeOver</summary>
        [JsonField("vismaGuaranteeOver")]
        public string VismaGuaranteeOver { get { return _VismaGuaranteeOver; } set { _VismaGuaranteeOver = value; } }
        private string _VismaGuaranteeOver;

        /// <summary>gift</summary>
        [JsonField("gift")]
        public string Gift { get { return _Gift; } set { _Gift = value; } }
        private string _Gift;

        /// <summary>giftBegin</summary>
        [JsonField("giftBegin")]
        public string GiftBegin { get { return _GiftBegin; } set { _GiftBegin = value; } }
        private string _GiftBegin;

        /// <summary>giftEnd</summary>
        [JsonField("giftEnd")]
        public string GiftEnd { get { return _GiftEnd; } set { _GiftEnd = value; } }
        private string _GiftEnd;

        /// <summary>giftSplit</summary>
        [JsonField("giftSplit")]
        public string GiftSplit { get { return _GiftSplit; } set { _GiftSplit = value; } }
        private string _GiftSplit;

        /// <summary>giftPN</summary>
        [JsonField("giftPN")]
        public string GiftPN { get { return _GiftPN; } set { _GiftPN = value; } }
        private string _GiftPN;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("bankIconKid")]
        public string BankIconKid { get { return _BankIconKid; } set { _BankIconKid = value; } }
        private string _BankIconKid;

    }

    /// <summary>One authorized location page. Continue with NextCursor until null.</summary>
    public sealed class LocationDirectoryResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public LocationDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private LocationDirectoryItem[] _Items;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

        /// <summary>hasAllBanksAccess</summary>
        [JsonField("hasAllBanksAccess")]
        public bool? HasAllBanksAccess { get { return _HasAllBanksAccess; } set { _HasAllBanksAccess = value; } }
        private bool? _HasAllBanksAccess;

        /// <summary>fields</summary>
        [JsonField("fields")]
        public string[] Fields { get { return _Fields; } set { _Fields = value; } }
        private string[] _Fields;

    }

    /// <summary>Null offline means empty or incomplete status, never a confirmed online location.</summary>
    public sealed class LocationIconResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>offline</summary>
        [JsonField("offline")]
        public bool? Offline { get { return _Offline; } set { _Offline = value; } }
        private bool? _Offline;

        /// <summary>status</summary>
        [JsonField("status")]
        public int? Status { get { return _Status; } set { _Status = value; } }
        private int? _Status;

    }

    /// <summary>Bounded lazy location icon lookup with independently authorized results.</summary>
    public sealed class LocationIconsResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public LocationIconResponse[] Items { get { return _Items; } set { _Items = value; } }
        private LocationIconResponse[] _Items;

    }

    /// <summary>A location's authorized schedules, calculated at an instant in its local time zone.</summary>
    public sealed class LocationOpeningHoursResponse
    {
        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>timeZone</summary>
        [JsonField("timeZone")]
        public string TimeZone { get { return _TimeZone; } set { _TimeZone = value; } }
        private string _TimeZone;

        /// <summary>calculatedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("calculatedAt")]
        public string CalculatedAt { get { return _CalculatedAt; } set { _CalculatedAt = value; } }
        private string _CalculatedAt;

        /// <summary>groups</summary>
        [JsonField("groups")]
        public OpeningHoursGroup[] Groups { get { return _Groups; } set { _Groups = value; } }
        private OpeningHoursGroup[] _Groups;

    }

    /// <summary>An authorized location and its visible unit list.</summary>
    public sealed class LocationUnitsResponse
    {
        /// <summary>location</summary>
        [JsonField("location")]
        public BankLocationResponse Location { get { return _Location; } set { _Location = value; } }
        private BankLocationResponse _Location;

        /// <summary>items</summary>
        [JsonField("items")]
        public UnitOverviewResponse[] Items { get { return _Items; } set { _Items = value; } }
        private UnitOverviewResponse[] _Items;

    }

    /// <summary>The canonical KID of the newly activated empty administrator.</summary>
    public sealed class ManagerCreationResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

    }

    /// <summary>Read-only metadata from current bank-zero Log7 settings. Describes the listed manager, never grants the caller permissions. No credentials are returned.</summary>
    public sealed class ManagerDirectoryItem
    {
        /// <summary>Canonical manager KID belonging to the API site, bank zero.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Decoded display name; empty when absent.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>Decoded eSetting.Email; empty when absent.</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>Recognized grants on this site; omitted stored tenants are resolved. An identifier never grants access.</summary>
        [JsonField("resourceGrants")]
        public ManagerResourceGrantResponse[] ResourceGrants { get { return _ResourceGrants; } set { _ResourceGrants = value; } }
        private ManagerResourceGrantResponse[] _ResourceGrants;

        /// <summary>Recognized eTab grants in AttributeMetaSortOrder, then numeric ID order. These are page grants, not effective operation permissions.</summary>
        [JsonField("tabs")]
        public ManagerTabResponse[] Tabs { get { return _Tabs; } set { _Tabs = value; } }
        private ManagerTabResponse[] _Tabs;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>Optional Gravatar image URL when Email is valid; preferred over the stored icon. Uses SHA256, 96px, G rating and d=404; fall back to IconKid on image failure. Browser requests disclose the email hash and client IP to Gravatar.</summary>
        [JsonField("gravatarUrl")]
        public string GravatarUrl { get { return _GravatarUrl; } set { _GravatarUrl = value; } }
        private string _GravatarUrl;

        /// <summary>Decoded eSetting.Organisation, empty when absent.</summary>
        [JsonField("organisation")]
        public string Organisation { get { return _Organisation; } set { _Organisation = value; } }
        private string _Organisation;

        /// <summary>True for Enabled=1, false for 0, null for absent or invalid settings. This field alone does not establish account usability.</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>Whether eSetting.Deleted contains a positive deletion timestamp. Deleted rows require the caller's retention allowance.</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>Deletion time in UTC, or null for a non-deleted manager. ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>Last recorded activity in UTC, from the current eSetting.Alive Log7 row's MS2000 (milliseconds since 2000-01-01 UTC), not Text. Null when absent, nonpositive or outside the supported date range. Reading the directory does not update activity. ISO 8601 text, sent unchanged.</summary>
        [JsonField("lastActiveAt")]
        public string LastActiveAt { get { return _LastActiveAt; } set { _LastActiveAt = value; } }
        private string _LastActiveAt;

        /// <summary>The listed manager's six independent Permission*2 masks, including Installer, with the same semantics as GetCurrentManager. Missing/empty values default to Read; malformed values grant nothing. Combine with account state, Tabs and resource grants.</summary>
        [JsonField("operationPermissions")]
        public ManagerOperationPermissionResponse[] OperationPermissions { get { return _OperationPermissions; } set { _OperationPermissions = value; } }
        private ManagerOperationPermissionResponse[] _OperationPermissions;

        /// <summary>The listed manager's RetentionDays: days of visibility after deletion for otherwise authorized records. Missing values default to 10; invalid or negative values become zero. Explicit zero is preserved. Does not alter the caller's retention or schedule deletion.</summary>
        [JsonField("retentionDays")]
        public int? RetentionDays { get { return _RetentionDays; } set { _RetentionDays = value; } }
        private int? _RetentionDays;

        /// <summary>Whether this record belongs to the caller. Own permission edits require the sole active tenant-wide manager exception.</summary>
        [JsonField("isCurrentManager")]
        public bool? IsCurrentManager { get { return _IsCurrentManager; } set { _IsCurrentManager = value; } }
        private bool? _IsCurrentManager;

        /// <summary>Caller has Managers Write and this is another administrator or the caller is the sole active tenant-wide manager. Display hint only: every write reauthorizes from current Log7.</summary>
        [JsonField("canEditPermissions")]
        public bool? CanEditPermissions { get { return _CanEditPermissions; } set { _CanEditPermissions = value; } }
        private bool? _CanEditPermissions;

        /// <summary>Whether the caller may edit this manager's Tabs, under the same policy as permission editing. A display hint only.</summary>
        [JsonField("canEditTabs")]
        public bool? CanEditTabs { get { return _CanEditTabs; } set { _CanEditTabs = value; } }
        private bool? _CanEditTabs;

        /// <summary>Whether the caller may change Name, Organisation, Enabled, Deleted, RetentionDays, Icon and Email. Same fresh authorization and own-card exception as permission editing.</summary>
        [JsonField("canEditProfile")]
        public bool? CanEditProfile { get { return _CanEditProfile; } set { _CanEditProfile = value; } }
        private bool? _CanEditProfile;

        /// <summary>Opaque revision of all seven profile settings; send unchanged to SetManagerProfileField.</summary>
        [JsonField("profileRevision")]
        public string ProfileRevision { get { return _ProfileRevision; } set { _ProfileRevision = value; } }
        private string _ProfileRevision;

        /// <summary>Opaque concurrency revision of the complete stored Tabs value; copy unchanged to SetManagerTab.</summary>
        [JsonField("tabsRevision")]
        public string TabsRevision { get { return _TabsRevision; } set { _TabsRevision = value; } }
        private string _TabsRevision;

        /// <summary>Opaque revision of the complete stored Kids setting; send unchanged to SetManagerKid.</summary>
        [JsonField("kidsRevision")]
        public string KidsRevision { get { return _KidsRevision; } set { _KidsRevision = value; } }
        private string _KidsRevision;

        /// <summary>Whether the caller may edit resource grants. Uses the same policy and own-card exception as other manager changes.</summary>
        [JsonField("canEditKids")]
        public bool? CanEditKids { get { return _CanEditKids; } set { _CanEditKids = value; } }
        private bool? _CanEditKids;

        /// <summary>GetManager only: every known eTab except None/Length, numeric aliases deduplicated, ordered by metadata then ID. These are choices, not grants or a list of implemented portal pages.</summary>
        [JsonField("availableTabs")]
        public ManagerTabResponse[] AvailableTabs { get { return _AvailableTabs; } set { _AvailableTabs = value; } }
        private ManagerTabResponse[] _AvailableTabs;

        /// <summary>GetManager only: unique eIcon names with eIconSubject.Person metadata, in numeric enum order. The current display icon is prepended if outside this catalog; legacy values are display-only, not new assignments.</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

    }

    /// <summary>One authorized page in the requested order. Follow NextCursor even when Items is empty.</summary>
    public sealed class ManagerDirectoryResponse
    {
        /// <summary>At most pageSize visible manager records. Disabled accounts are included; deleted accounts follow requester retention.</summary>
        [JsonField("items")]
        public ManagerDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private ManagerDirectoryItem[] _Items;

        /// <summary>Opaque continuation bound to caller, site, page size, filter, sort and direction, or null when finished. Never decode it.</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

    }

    /// <summary>Another visible administrator sharing the source email; KID is canonical and tenant-bound.</summary>
    public sealed class ManagerEmailMatch
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed icon identity used when Gravatar is missing or unavailable.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>Preferred optional Gravatar URL, with the same semantics as GetManager.</summary>
        [JsonField("gravatarUrl")]
        public string GravatarUrl { get { return _GravatarUrl; } set { _GravatarUrl = value; } }
        private string _GravatarUrl;

    }

    /// <summary>Requests a recovery email on this API's tenant. Never log the body.</summary>
    public sealed class ManagerForgotPasswordRequest
    {
        /// <summary>The manager's existing login address, not the temporary delivery override.</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>Email language: en (default), da or es.</summary>
        [JsonField("language")]
        public string Language { get { return _Language; } set { _Language = value; } }
        private string _Language;

    }

    /// <summary>Confirms the profile version shown when sending an invitation; the caller cannot override the recipient or link host.</summary>
    public sealed class ManagerInvitationRequest
    {
        /// <summary>The profileRevision returned by GetManager or the last confirmed profile save.</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

        /// <summary>Email language: en (default), da or es.</summary>
        [JsonField("language")]
        public string Language { get { return _Language; } set { _Language = value; } }
        private string _Language;

    }

    /// <summary>An invitation was committed to the asynchronous mail queue; it does not confirm delivery.</summary>
    public sealed class ManagerInvitationResponse
    {
        /// <summary>code</summary>
        [JsonField("code")]
        public string Code { get { return _Code; } set { _Code = value; } }
        private string _Code;

    }

    /// <summary>Assign or remove a canonical tenant, bank or location grant.</summary>
    public sealed class ManagerKidChangeRequest
    {
        /// <summary>Canonical KID on this site. Tenant means all banks; Bank means its entire bank; Location means only that location.</summary>
        [JsonField("resourceKid")]
        public string ResourceKid { get { return _ResourceKid; } set { _ResourceKid = value; } }
        private string _ResourceKid;

        /// <summary>Required: true adds access; false removes this exact scope.</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>Required kidsRevision from GetManager or the latest acknowledged SetManagerKid response.</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Authoritative site grants and next revision; CanEditKids=false means lock the entire editor.</summary>
    public sealed class ManagerKidChangeResponse
    {
        /// <summary>resourceGrants</summary>
        [JsonField("resourceGrants")]
        public ManagerResourceGrantResponse[] ResourceGrants { get { return _ResourceGrants; } set { _ResourceGrants = value; } }
        private ManagerResourceGrantResponse[] _ResourceGrants;

        /// <summary>kidsRevision</summary>
        [JsonField("kidsRevision")]
        public string KidsRevision { get { return _KidsRevision; } set { _KidsRevision = value; } }
        private string _KidsRevision;

        /// <summary>canEditKids</summary>
        [JsonField("canEditKids")]
        public bool? CanEditKids { get { return _CanEditKids; } set { _CanEditKids = value; } }
        private bool? _CanEditKids;

    }

    /// <summary>A known account-state reason returned only after verifying the manager's password.</summary>
    public sealed class ManagerLoginErrorResponse
    {
        /// <summary>The disabled, deleted, or account-settings reason; never stored values or credentials.</summary>
        [JsonField("code")]
        public string Code { get { return _Code; } set { _Code = value; } }
        private string _Code;

    }

    /// <summary>Credentials submitted over HTTPS; never log request bodies for this endpoint.</summary>
    public sealed class ManagerLoginRequest
    {
        /// <summary>The manager's email address.</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>The original password, normalized only by the documented legacy verifier.</summary>
        [JsonField("password")]
        public string Password { get { return _Password; } set { _Password = value; } }
        private string _Password;

    }

    /// <summary>A resource category's independent ePermission2 flags.</summary>
    public sealed class ManagerOperationPermissionResponse
    {
        /// <summary>Managers, Bank, Location, Unit, User, Installer, Service, Tabs or Kids. Match by resource name, not array position.</summary>
        [JsonField("resource")]
        public string Resource { get { return _Resource; } set { _Resource = value; } }
        private string _Resource;

        /// <summary>Enum text (possibly numeric for combinations), or null for invalid values. Use flags and capability booleans; missing values become Read.</summary>
        [JsonField("level")]
        public string Level { get { return _Level; } set { _Level = value; } }
        private string _Level;

        /// <summary>Whether reading is permitted at this operation level.</summary>
        [JsonField("canRead")]
        public bool? CanRead { get { return _CanRead; } set { _CanRead = value; } }
        private bool? _CanRead;

        /// <summary>Whether modification is permitted at this operation level.</summary>
        [JsonField("canWrite")]
        public bool? CanWrite { get { return _CanWrite; } set { _CanWrite = value; } }
        private bool? _CanWrite;

        /// <summary>Whether creation is permitted at this operation level.</summary>
        [JsonField("canCreate")]
        public bool? CanCreate { get { return _CanCreate; } set { _CanCreate = value; } }
        private bool? _CanCreate;

        /// <summary>Numeric bitmask: Read=1, Write=2, Create=4, Delete=8, RenameExtrenatId=16, Rename=32. None=0; null is invalid.</summary>
        [JsonField("flags")]
        public int? Flags { get { return _Flags; } set { _Flags = value; } }
        private int? _Flags;

        /// <summary>Whether Delete is explicitly granted.</summary>
        [JsonField("canDelete")]
        public bool? CanDelete { get { return _CanDelete; } set { _CanDelete = value; } }
        private bool? _CanDelete;

        /// <summary>Whether RenameExtrenatId is explicitly granted.</summary>
        [JsonField("canRenameExternalId")]
        public bool? CanRenameExternalId { get { return _CanRenameExternalId; } set { _CanRenameExternalId = value; } }
        private bool? _CanRenameExternalId;

        /// <summary>Whether Rename is explicitly granted.</summary>
        [JsonField("canRename")]
        public bool? CanRename { get { return _CanRename; } set { _CanRename = value; } }
        private bool? _CanRename;

    }

    /// <summary>A language-independent recovery result; never identifies a matching account.</summary>
    public sealed class ManagerPasswordResetResponse
    {
        /// <summary>code</summary>
        [JsonField("code")]
        public string Code { get { return _Code; } set { _Code = value; } }
        private string _Code;

    }

    /// <summary>Change one independent operation bit using the last displayed flags for concurrency.</summary>
    public sealed class ManagerPermissionChangeRequest
    {
        /// <summary>Exactly one ePermission2 bit (1, 2, 4, 8, 16 or 32), required.</summary>
        [JsonField("flag")]
        public int? Flag { get { return _Flag; } set { _Flag = value; } }
        private int? _Flag;

        /// <summary>The desired state of that bit, required.</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>Required, including explicit null for an invalid stored mask. Read from GetManager.</summary>
        [JsonField("expectedFlags")]
        public int? ExpectedFlags { get { return _ExpectedFlags; } set { _ExpectedFlags = value; } }
        private int? _ExpectedFlags;

    }

    /// <summary>Apply a server-defined role to the complete permission matrix.</summary>
    public sealed class ManagerPermissionRoleRequest
    {
        /// <summary>accounting, caretaker, operator, technical-support, tenant-accounting or combine; case-sensitive, required.</summary>
        [JsonField("role")]
        public string Role { get { return _Role; } set { _Role = value; } }
        private string _Role;

        /// <summary>Exactly Managers, Installer, Service, Bank, Location, Unit, User, Tabs and Kids with last displayed flags. Explicit null represents an invalid stored mask.</summary>
        [JsonField("expectedFlags")]
        public Dictionary<string, int> ExpectedFlags { get { return _ExpectedFlags; } set { _ExpectedFlags = value; } }
        private Dictionary<string, int> _ExpectedFlags;

        /// <summary>Required for accounting and combine: tabsRevision from GetManager or the last acknowledged edit.</summary>
        [JsonField("expectedTabsRevision")]
        public string ExpectedTabsRevision { get { return _ExpectedTabsRevision; } set { _ExpectedTabsRevision = value; } }
        private string _ExpectedTabsRevision;

        /// <summary>Required for combine: kidsRevision from GetManager or the last acknowledged edit.</summary>
        [JsonField("expectedKidsRevision")]
        public string ExpectedKidsRevision { get { return _ExpectedKidsRevision; } set { _ExpectedKidsRevision = value; } }
        private string _ExpectedKidsRevision;

    }

    /// <summary>The acknowledged preset and complete persisted permission matrix.</summary>
    public sealed class ManagerPermissionRoleResponse
    {
        /// <summary>The applied preset identity.</summary>
        [JsonField("role")]
        public string Role { get { return _Role; } set { _Role = value; } }
        private string _Role;

        /// <summary>All nine authoritative permission categories.</summary>
        [JsonField("operationPermissions")]
        public ManagerOperationPermissionResponse[] OperationPermissions { get { return _OperationPermissions; } set { _OperationPermissions = value; } }
        private ManagerOperationPermissionResponse[] _OperationPermissions;

        /// <summary>False when applying the role to yourself removes the required Managers permissions.</summary>
        [JsonField("canEditPermissions")]
        public bool? CanEditPermissions { get { return _CanEditPermissions; } set { _CanEditPermissions = value; } }
        private bool? _CanEditPermissions;

        /// <summary>Complete recognized selected tabs after the atomic role assignment.</summary>
        [JsonField("tabs")]
        public ManagerTabResponse[] Tabs { get { return _Tabs; } set { _Tabs = value; } }
        private ManagerTabResponse[] _Tabs;

        /// <summary>Revision for the next tab or role edit.</summary>
        [JsonField("tabsRevision")]
        public string TabsRevision { get { return _TabsRevision; } set { _TabsRevision = value; } }
        private string _TabsRevision;

        /// <summary>False when the change removes your required Managers access.</summary>
        [JsonField("canEditTabs")]
        public bool? CanEditTabs { get { return _CanEditTabs; } set { _CanEditTabs = value; } }
        private bool? _CanEditTabs;

        /// <summary>Authoritative resource grants after the role assignment.</summary>
        [JsonField("resourceGrants")]
        public ManagerResourceGrantResponse[] ResourceGrants { get { return _ResourceGrants; } set { _ResourceGrants = value; } }
        private ManagerResourceGrantResponse[] _ResourceGrants;

        /// <summary>Revision for the next resource-grant edit.</summary>
        [JsonField("kidsRevision")]
        public string KidsRevision { get { return _KidsRevision; } set { _KidsRevision = value; } }
        private string _KidsRevision;

        /// <summary>Whether the caller retains permission to edit resource grants.</summary>
        [JsonField("canEditKids")]
        public bool? CanEditKids { get { return _CanEditKids; } set { _CanEditKids = value; } }
        private bool? _CanEditKids;

    }

    /// <summary>One desired profile value plus the profile revision last shown to the caller.</summary>
    public sealed class ManagerProfileChangeRequest
    {
        /// <summary>Name/Organisation: string, maximum 200 characters, no controls. Enabled/Deleted: boolean. RetentionDays: integer 0 through 2147483647. Icon: exact eIcon name with eIconSubject.Person metadata. Email: one nonempty address, maximum 254 characters, no whitespace or controls.</summary>
        [JsonField("value")]
        public object Value { get { return _Value; } set { _Value = value; } }
        private object _Value;

        /// <summary>Required opaque profileRevision returned by GetManager or the previous successful edit.</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Authoritative profile after a confirmed save. A false CanEditProfile locks all editor controls.</summary>
    public sealed class ManagerProfileChangeResponse
    {
        /// <summary>The changed field's stable eSetting name.</summary>
        [JsonField("field")]
        public string Field { get { return _Field; } set { _Field = value; } }
        private string _Field;

        /// <summary>Saved display name.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>Saved organisation.</summary>
        [JsonField("organisation")]
        public string Organisation { get { return _Organisation; } set { _Organisation = value; } }
        private string _Organisation;

        /// <summary>Saved login email address. Changing it does not send an invitation or change the password.</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>Saved icon identifier. New assignments accept only eIcon names with eIconSubject.Person metadata.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>Optional Gravatar fallback; same semantics as GetManager. Refresh after Email or Icon changes.</summary>
        [JsonField("gravatarUrl")]
        public string GravatarUrl { get { return _GravatarUrl; } set { _GravatarUrl = value; } }
        private string _GravatarUrl;

        /// <summary>Person icon choices; the current display icon is first when it is outside that catalog.</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

        /// <summary>Saved Enabled state; null for an unchanged absent/invalid value.</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>True when the saved deletion timestamp is positive.</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>Exact stored deletion value: 0 or milliseconds since 2000-01-01 UTC. Not a Unix timestamp or boolean.</summary>
        [JsonField("deletedMs2000")]
        public long? DeletedMs2000 { get { return _DeletedMs2000; } set { _DeletedMs2000 = value; } }
        private long? _DeletedMs2000;

        /// <summary>Deletion time in UTC, null when DeletedMs2000 is zero. ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>Saved visibility window for deleted records.</summary>
        [JsonField("retentionDays")]
        public int? RetentionDays { get { return _RetentionDays; } set { _RetentionDays = value; } }
        private int? _RetentionDays;

        /// <summary>Revision for the next profile edit.</summary>
        [JsonField("profileRevision")]
        public string ProfileRevision { get { return _ProfileRevision; } set { _ProfileRevision = value; } }
        private string _ProfileRevision;

        /// <summary>False after disabling/deleting yourself, or when deletion hides the target under caller retention.</summary>
        [JsonField("canEditProfile")]
        public bool? CanEditProfile { get { return _CanEditProfile; } set { _CanEditProfile = value; } }
        private bool? _CanEditProfile;

    }

    /// <summary>The authenticated manager's current display values and permission summary for this site.</summary>
    public sealed class ManagerProfileResponse
    {
        /// <summary>The manager ID. Treat it as an opaque, case-sensitive string: store and send it unchanged; do not decode or construct it. An ID does not grant access.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>The manager's display name.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>Permitted eTab IDs, not flags. An empty array means no Tabs; it does not prevent login.</summary>
        [JsonField("tabs")]
        public int[] Tabs { get { return _Tabs; } set { _Tabs = value; } }
        private int[] _Tabs;

        /// <summary>Whether at least one bank/location grant applies on this site.</summary>
        [JsonField("hasBankAccess")]
        public bool? HasBankAccess { get { return _HasBankAccess; } set { _HasBankAccess = value; } }
        private bool? _HasBankAccess;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>databaseAccess</summary>
        [JsonField("databaseAccess")]
        public DatabaseAccessResponse DatabaseAccess { get { return _DatabaseAccess; } set { _DatabaseAccess = value; } }
        private DatabaseAccessResponse _DatabaseAccess;

        /// <summary>Navigation labels from Log24 for explicitly scoped banks (including parents of granted locations). Requires Tabs and Bank Read. Empty for tenant-wide access. These labels do not grant bank-wide access; use resourceGrants. Names/icons are cached for one minute.</summary>
        [JsonField("navigationBanks")]
        public BankNavigationResponse[] NavigationBanks { get { return _NavigationBanks; } set { _NavigationBanks = value; } }
        private BankNavigationResponse[] _NavigationBanks;

        /// <summary>Optional organisation display text. Empty when absent; never an access grant.</summary>
        [JsonField("organisation")]
        public string Organisation { get { return _Organisation; } set { _Organisation = value; } }
        private string _Organisation;

        /// <summary>Optional API-computed Gravatar URL from the current manager's email. Prefer over IconKid; fall back on image failure. Uses SHA256, 96px, G rating and d=404. Direct browser requests disclose the email hash and client IP to Gravatar.</summary>
        [JsonField("gravatarUrl")]
        public string GravatarUrl { get { return _GravatarUrl; } set { _GravatarUrl = value; } }
        private string _GravatarUrl;

        /// <summary>Days after deletion that an otherwise authorized bank, location, unit, user or reservation remains visible. Zero hides deleted objects; missing settings default to 10 days; invalid settings default to zero. Does not grant access or schedule physical deletion.</summary>
        [JsonField("retentionDays")]
        public int? RetentionDays { get { return _RetentionDays; } set { _RetentionDays = value; } }
        private int? _RetentionDays;

        /// <summary>themeMode</summary>
        [JsonField("themeMode")]
        public int? ThemeMode { get { return _ThemeMode; } set { _ThemeMode = value; } }
        private int? _ThemeMode;

        /// <summary>Preferred icon set: g or line. Missing or unsupported stored values return line; an explicit g is preserved. This grants no permissions.</summary>
        [JsonField("iconSet")]
        public string IconSet { get { return _IconSet; } set { _IconSet = value; } }
        private string _IconSet;

        /// <summary>Names and IDs from the shared eTab enum, limited to the manager's recognized grants.</summary>
        [JsonField("tabDetails")]
        public ManagerTabResponse[] TabDetails { get { return _TabDetails; } set { _TabDetails = value; } }
        private ManagerTabResponse[] _TabDetails;

        /// <summary>Decoded bank/location scopes belonging only to this site. Empty means no bank/location access.</summary>
        [JsonField("resourceGrants")]
        public ManagerResourceGrantResponse[] ResourceGrants { get { return _ResourceGrants; } set { _ResourceGrants = value; } }
        private ManagerResourceGrantResponse[] _ResourceGrants;

        /// <summary>Independent operation permissions for Managers, Bank, Location, Unit, User, Installer, Service, Tabs and Kids; missing stored values default to Read.</summary>
        [JsonField("operationPermissions")]
        public ManagerOperationPermissionResponse[] OperationPermissions { get { return _OperationPermissions; } set { _OperationPermissions = value; } }
        private ManagerOperationPermissionResponse[] _OperationPermissions;

    }

    /// <summary>Redeems the emailed token. Never log this body or return its contents.</summary>
    public sealed class ManagerResetPasswordRequest
    {
        /// <summary>The opaque token from the email link, submitted unchanged.</summary>
        [JsonField("token")]
        public string Token { get { return _Token; } set { _Token = value; } }
        private string _Token;

        /// <summary>12–128 printable ASCII characters; no leading/trailing spaces. Uses the existing login hash.</summary>
        [JsonField("password")]
        public string Password { get { return _Password; } set { _Password = value; } }
        private string _Password;

        /// <summary>A second entry of the new password, matching Password exactly.</summary>
        [JsonField("confirmPassword")]
        public string ConfirmPassword { get { return _ConfirmPassword; } set { _ConfirmPassword = value; } }
        private string _ConfirmPassword;

    }

    /// <summary>A site-bound bank/location scope for the access overview.</summary>
    public sealed class ManagerResourceGrantResponse
    {
        /// <summary>The canonical tenant, bank, or location KID, with omitted stored tenants resolved to the API site.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Tenant means all banks/locations on this site; Bank means all locations in that bank; Location means only that location. No names or business records are fetched.</summary>
        [JsonField("scope")]
        public string Scope { get { return _Scope; } set { _Scope = value; } }
        private string _Scope;

    }

    /// <summary>A short-lived opaque API token; no refresh token is issued.</summary>
    public sealed class ManagerSessionResponse
    {
        /// <summary>Opaque token for Authorization: Bearer {accessToken}. Do not decode it as a JWT or put it in a URL.</summary>
        [JsonField("accessToken")]
        public string AccessToken { get { return _AccessToken; } set { _AccessToken = value; } }
        private string _AccessToken;

        /// <summary>Lifetime in seconds.</summary>
        [JsonField("expiresIn")]
        public long? ExpiresIn { get { return _ExpiresIn; } set { _ExpiresIn = value; } }
        private long? _ExpiresIn;

        /// <summary>The Authorization header scheme.</summary>
        [JsonField("tokenType")]
        public string TokenType { get { return _TokenType; } set { _TokenType = value; } }
        private string _TokenType;

    }

    /// <summary>Desired state of one numeric eTab grant, using the last returned Tabs revision.</summary>
    public sealed class ManagerTabChangeRequest
    {
        /// <summary>Required boolean; true assigns the tab and false removes it.</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>Required opaque tabsRevision from GetManager or the latest SetManagerTab response.</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>The acknowledged tab selection and concurrency state.</summary>
    public sealed class ManagerTabChangeResponse
    {
        /// <summary>Complete recognized selected tabs, sorted by metadata then numeric ID.</summary>
        [JsonField("tabs")]
        public ManagerTabResponse[] Tabs { get { return _Tabs; } set { _Tabs = value; } }
        private ManagerTabResponse[] _Tabs;

        /// <summary>Opaque revision for the next edit, including preserved unknown numbers.</summary>
        [JsonField("tabsRevision")]
        public string TabsRevision { get { return _TabsRevision; } set { _TabsRevision = value; } }
        private string _TabsRevision;

        /// <summary>False if removing your own Managers1 grant removes edit access.</summary>
        [JsonField("canEditTabs")]
        public bool? CanEditTabs { get { return _CanEditTabs; } set { _CanEditTabs = value; } }
        private bool? _CanEditTabs;

        /// <summary>False if the same change removes your permission-editing access.</summary>
        [JsonField("canEditPermissions")]
        public bool? CanEditPermissions { get { return _CanEditPermissions; } set { _CanEditPermissions = value; } }
        private bool? _CanEditPermissions;

    }

    /// <summary>A permitted page's identity in the shared eTab enum.</summary>
    public sealed class ManagerTabResponse
    {
        /// <summary>The persisted eTab number.</summary>
        [JsonField("id")]
        public int? Id { get { return _Id; } set { _Id = value; } }
        private int? _Id;

        /// <summary>The shared enum member name.</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed icon identity based on eTab AttributeMetaIcon, empty when absent or none. Calendar includes today's day in Text.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Sets the caller's own appearance preference; no manager or tenant override is accepted.</summary>
    public sealed class ManagerThemeRequest
    {
        /// <summary>themeMode</summary>
        [JsonField("themeMode")]
        public int? ThemeMode { get { return _ThemeMode; } set { _ThemeMode = value; } }
        private int? _ThemeMode;

    }

    /// <summary>The manager's successfully stored appearance preference.</summary>
    public sealed class ManagerThemeResponse
    {
        /// <summary>themeMode</summary>
        [JsonField("themeMode")]
        public int? ThemeMode { get { return _ThemeMode; } set { _ThemeMode = value; } }
        private int? _ThemeMode;

    }

    /// <summary>Current own settings, stable revision and safe operation outcome; no inherited address.</summary>
    public sealed class ObjectAddressResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>address</summary>
        [JsonField("address")]
        public string Address { get { return _Address; } set { _Address = value; } }
        private string _Address;

        /// <summary>zip</summary>
        [JsonField("zip")]
        public string Zip { get { return _Zip; } set { _Zip = value; } }
        private string _Zip;

        /// <summary>latitude</summary>
        [JsonField("latitude")]
        public long? Latitude { get { return _Latitude; } set { _Latitude = value; } }
        private long? _Latitude;

        /// <summary>longitude</summary>
        [JsonField("longitude")]
        public long? Longitude { get { return _Longitude; } set { _Longitude = value; } }
        private long? _Longitude;

        /// <summary>autoLatitudeLongitude</summary>
        [JsonField("autoLatitudeLongitude")]
        public long? AutoLatitudeLongitude { get { return _AutoLatitudeLongitude; } set { _AutoLatitudeLongitude = value; } }
        private long? _AutoLatitudeLongitude;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>outcome</summary>
        [JsonField("outcome")]
        public string Outcome { get { return _Outcome; } set { _Outcome = value; } }
        private string _Outcome;

        /// <summary>Display hint from the current snapshot; every mutation independently reauthorizes.</summary>
        [JsonField("canWrite")]
        public bool? CanWrite { get { return _CanWrite; } set { _CanWrite = value; } }
        private bool? _CanWrite;

    }

    /// <summary>Revision for a deliberate coordinate lookup.</summary>
    public sealed class ObjectAddressRevisionRequest
    {
        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Units sharing the same effective weekly plan and upcoming exceptions.</summary>
    public sealed class OpeningHoursGroup
    {
        /// <summary>units</summary>
        [JsonField("units")]
        public OpeningHoursUnit[] Units { get { return _Units; } set { _Units = value; } }
        private OpeningHoursUnit[] _Units;

        /// <summary>weekly</summary>
        [JsonField("weekly")]
        public OpeningHoursLine[] Weekly { get { return _Weekly; } set { _Weekly = value; } }
        private OpeningHoursLine[] _Weekly;

        /// <summary>exceptions</summary>
        [JsonField("exceptions")]
        public OpeningHoursLine[] Exceptions { get { return _Exceptions; } set { _Exceptions = value; } }
        private OpeningHoursLine[] _Exceptions;

        /// <summary>isOpenNow</summary>
        [JsonField("isOpenNow")]
        public bool? IsOpenNow { get { return _IsOpenNow; } set { _IsOpenNow = value; } }
        private bool? _IsOpenNow;

        /// <summary>nextChange ISO 8601 text, sent unchanged.</summary>
        [JsonField("nextChange")]
        public string NextChange { get { return _NextChange; } set { _NextChange = value; } }
        private string _NextChange;

    }

    /// <summary>Open, Closed, AllDay or Unknown; times are local HH:mm, with an explicit overnight flag.</summary>
    public sealed class OpeningHoursLine
    {
        /// <summary>label</summary>
        [JsonField("label")]
        public string Label { get { return _Label; } set { _Label = value; } }
        private string _Label;

        /// <summary>status</summary>
        [JsonField("status")]
        public string Status { get { return _Status; } set { _Status = value; } }
        private string _Status;

        /// <summary>opens</summary>
        [JsonField("opens")]
        public string Opens { get { return _Opens; } set { _Opens = value; } }
        private string _Opens;

        /// <summary>closes</summary>
        [JsonField("closes")]
        public string Closes { get { return _Closes; } set { _Closes = value; } }
        private string _Closes;

        /// <summary>closesNextDay</summary>
        [JsonField("closesNextDay")]
        public bool? ClosesNextDay { get { return _ClosesNextDay; } set { _ClosesNextDay = value; } }
        private bool? _ClosesNextDay;

        /// <summary>daysOfWeek</summary>
        [JsonField("daysOfWeek")]
        public int[] DaysOfWeek { get { return _DaysOfWeek; } set { _DaysOfWeek = value; } }
        private int[] _DaysOfWeek;

        /// <summary>date ISO 8601 text, sent unchanged.</summary>
        [JsonField("date")]
        public string Date { get { return _Date; } set { _Date = value; } }
        private string _Date;

    }

    /// <summary>An authorized unit identity and localized display name.</summary>
    public sealed class OpeningHoursUnit
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

    }

    /// <summary>Authorized count and red badge icon; each operation documents its cache age and precision.</summary>
    public sealed class PeopleDirectoryCount
    {
        /// <summary>count</summary>
        [JsonField("count")]
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Stable success/error code, containing no secrets.</summary>
    public sealed class PersonalAccountResult
    {
        /// <summary>code</summary>
        [JsonField("code")]
        public string Code { get { return _Code; } set { _Code = value; } }
        private string _Code;

    }

    /// <summary>The single-use proof from the new mailbox.</summary>
    public sealed class PersonalEmailConfirmation
    {
        /// <summary>token</summary>
        [JsonField("token")]
        public string Token { get { return _Token; } set { _Token = value; } }
        private string _Token;

    }

    /// <summary>New address and reauthentication, without a caller-selected manager or return URL.</summary>
    public sealed class PersonalEmailRequest
    {
        /// <summary>email</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>currentPassword</summary>
        [JsonField("currentPassword")]
        public string CurrentPassword { get { return _CurrentPassword; } set { _CurrentPassword = value; } }
        private string _CurrentPassword;

        /// <summary>language</summary>
        [JsonField("language")]
        public string Language { get { return _Language; } set { _Language = value; } }
        private string _Language;

    }

    /// <summary>Personal preferences; no credentials, administrative grants or internal verification proofs.</summary>
    public sealed class PersonalManagerProfile
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>organisation</summary>
        [JsonField("organisation")]
        public string Organisation { get { return _Organisation; } set { _Organisation = value; } }
        private string _Organisation;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>email</summary>
        [JsonField("email")]
        public string Email { get { return _Email; } set { _Email = value; } }
        private string _Email;

        /// <summary>emailVerified</summary>
        [JsonField("emailVerified")]
        public bool? EmailVerified { get { return _EmailVerified; } set { _EmailVerified = value; } }
        private bool? _EmailVerified;

        /// <summary>themeMode</summary>
        [JsonField("themeMode")]
        public int? ThemeMode { get { return _ThemeMode; } set { _ThemeMode = value; } }
        private int? _ThemeMode;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>availableIcons</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

        /// <summary>retentionDays</summary>
        [JsonField("retentionDays")]
        public int? RetentionDays { get { return _RetentionDays; } set { _RetentionDays = value; } }
        private int? _RetentionDays;

        /// <summary>iconSet</summary>
        [JsonField("iconSet")]
        public string IconSet { get { return _IconSet; } set { _IconSet = value; } }
        private string _IconSet;

    }

    /// <summary>A stable numeric tab identity and its enum-derived name.</summary>
    public sealed class PersonalManagerTab
    {
        /// <summary>id</summary>
        [JsonField("id")]
        public int? Id { get { return _Id; } set { _Id = value; } }
        private int? _Id;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

    }

    /// <summary>Own tab selection and the finite enum catalog. CanEdit requires an explicit site-wide KID grant.</summary>
    public sealed class PersonalManagerTabs
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>tabs</summary>
        [JsonField("tabs")]
        public PersonalManagerTab[] Tabs { get { return _Tabs; } set { _Tabs = value; } }
        private PersonalManagerTab[] _Tabs;

        /// <summary>availableTabs</summary>
        [JsonField("availableTabs")]
        public PersonalManagerTab[] AvailableTabs { get { return _AvailableTabs; } set { _AvailableTabs = value; } }
        private PersonalManagerTab[] _AvailableTabs;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>canEdit</summary>
        [JsonField("canEdit")]
        public bool? CanEdit { get { return _CanEdit; } set { _CanEdit = value; } }
        private bool? _CanEdit;

    }

    /// <summary>Reauthentication and matching new password entries.</summary>
    public sealed class PersonalPasswordRequest
    {
        /// <summary>currentPassword</summary>
        [JsonField("currentPassword")]
        public string CurrentPassword { get { return _CurrentPassword; } set { _CurrentPassword = value; } }
        private string _CurrentPassword;

        /// <summary>password</summary>
        [JsonField("password")]
        public string Password { get { return _Password; } set { _Password = value; } }
        private string _Password;

        /// <summary>confirmPassword</summary>
        [JsonField("confirmPassword")]
        public string ConfirmPassword { get { return _ConfirmPassword; } set { _ConfirmPassword = value; } }
        private string _ConfirmPassword;

        /// <summary>language</summary>
        [JsonField("language")]
        public string Language { get { return _Language; } set { _Language = value; } }
        private string _Language;

    }

    /// <summary>One personal preference with the last acknowledged profile revision.</summary>
    public sealed class PersonalProfileRequest
    {
        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>value</summary>
        [JsonField("value")]
        public object Value { get { return _Value; } set { _Value = value; } }
        private object _Value;

    }

    /// <summary>One own-tab toggle; the authenticated session is the sole target.</summary>
    public sealed class PersonalTabRequest
    {
        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>enabled</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

    }

    /// <summary>ProblemDetails</summary>
    public sealed class ProblemDetails
    {
        /// <summary>type</summary>
        [JsonField("type")]
        public string Type { get { return _Type; } set { _Type = value; } }
        private string _Type;

        /// <summary>title</summary>
        [JsonField("title")]
        public string Title { get { return _Title; } set { _Title = value; } }
        private string _Title;

        /// <summary>status</summary>
        [JsonField("status")]
        public int? Status { get { return _Status; } set { _Status = value; } }
        private int? _Status;

        /// <summary>detail</summary>
        [JsonField("detail")]
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        private string _Detail;

        /// <summary>instance</summary>
        [JsonField("instance")]
        public string Instance { get { return _Instance; } set { _Instance = value; } }
        private string _Instance;

    }

    /// <summary>Mixed-result shape; kind is an enum-derived type and Kid is the sole object identifier.</summary>
    public sealed class SearchResult
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>zip</summary>
        [JsonField("zip")]
        public string Zip { get { return _Zip; } set { _Zip = value; } }
        private string _Zip;

        /// <summary>matchedSetting</summary>
        [JsonField("matchedSetting")]
        public string MatchedSetting { get { return _MatchedSetting; } set { _MatchedSetting = value; } }
        private string _MatchedSetting;

        /// <summary>matchedValue</summary>
        [JsonField("matchedValue")]
        public string MatchedValue { get { return _MatchedValue; } set { _MatchedValue = value; } }
        private string _MatchedValue;

        /// <summary>isContext</summary>
        [JsonField("isContext")]
        public bool? IsContext { get { return _IsContext; } set { _IsContext = value; } }
        private bool? _IsContext;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>A bounded provider result; merge by canonical Kid.</summary>
    public sealed class SearchResults
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public SearchResult[] Items { get { return _Items; } set { _Items = value; } }
        private SearchResult[] _Items;

        /// <summary>hasMore</summary>
        [JsonField("hasMore")]
        public bool? HasMore { get { return _HasMore; } set { _HasMore = value; } }
        private bool? _HasMore;

    }

    /// <summary>Rotate the service key only if the profile still matches the revision last read.</summary>
    public sealed class ServiceApiKeyRequest
    {
        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>ApiKey is returned only by the successful generation response. Do not log or persist this response. Details contains the committed hash and next profile revision, never another copy of the plaintext key.</summary>
    public sealed class ServiceApiKeyResponse
    {
        /// <summary>apiKey</summary>
        [JsonField("apiKey")]
        public string ApiKey { get { return _ApiKey; } set { _ApiKey = value; } }
        private string _ApiKey;

        /// <summary>details</summary>
        [JsonField("details")]
        public ServiceDetailsResponse Details { get { return _Details; } set { _Details = value; } }
        private ServiceDetailsResponse _Details;

    }

    /// <summary>ApiKeyHash is the hash stored in eSetting.Password and is included only for callers with Service Write. The published JSON names are preserved; this is never a plaintext API key. CanEdit is only a display hint; every mutation independently reauthorizes.</summary>
    public sealed class ServiceDetailsResponse
    {
        /// <summary>service</summary>
        [JsonField("service")]
        public ServiceDirectoryItem Service { get { return _Service; } set { _Service = value; } }
        private ServiceDirectoryItem _Service;

        /// <summary>hasApiKeyHash</summary>
        [JsonField("hasApiKeyHash")]
        public bool? HasApiKeyHash { get { return _HasApiKeyHash; } set { _HasApiKeyHash = value; } }
        private bool? _HasApiKeyHash;

        /// <summary>apiKeyHash</summary>
        [JsonField("apiKeyHash")]
        public string ApiKeyHash { get { return _ApiKeyHash; } set { _ApiKeyHash = value; } }
        private string _ApiKeyHash;

        /// <summary>canEdit</summary>
        [JsonField("canEdit")]
        public bool? CanEdit { get { return _CanEdit; } set { _CanEdit = value; } }
        private bool? _CanEdit;

        /// <summary>profileRevision</summary>
        [JsonField("profileRevision")]
        public string ProfileRevision { get { return _ProfileRevision; } set { _ProfileRevision = value; } }
        private string _ProfileRevision;

        /// <summary>availableIcons</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

    }

    /// <summary>Canonical bank-zero, manager-shaped KID, eUserId.ToString() identity and tenant-specific Name/Icon.</summary>
    public sealed class ServiceDirectoryItem
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>identity</summary>
        [JsonField("identity")]
        public string Identity { get { return _Identity; } set { _Identity = value; } }
        private string _Identity;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>Exact enum setting for the icon picker and Icon writes; use IconKid for images.</summary>
        [JsonField("iconName")]
        public string IconName { get { return _IconName; } set { _IconName = value; } }
        private string _IconName;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>The finite catalog of concrete service enum identities; never contains key hashes. NextCursor is always null.</summary>
    public sealed class ServiceDirectoryResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public ServiceDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private ServiceDirectoryItem[] _Items;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

    }

    /// <summary>Exact Name or Icon value plus the revision returned by GetService. Credentials cannot be edited manually.</summary>
    public sealed class ServiceProfileRequest
    {
        /// <summary>value</summary>
        [JsonField("value")]
        public string Value { get { return _Value; } set { _Value = value; } }
        private string _Value;

        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>One recognized coordinate provenance value and the current object revision.</summary>
    public sealed class SetObjectCoordinateProvenanceRequest
    {
        /// <summary>value</summary>
        [JsonField("value")]
        public int? Value { get { return _Value; } set { _Value = value; } }
        private int? _Value;

        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Manual coordinates in integer millionths of degrees.</summary>
    public sealed class SetObjectCoordinatesRequest
    {
        /// <summary>latitude</summary>
        [JsonField("latitude")]
        public long? Latitude { get { return _Latitude; } set { _Latitude = value; } }
        private long? _Latitude;

        /// <summary>longitude</summary>
        [JsonField("longitude")]
        public long? Longitude { get { return _Longitude; } set { _Longitude = value; } }
        private long? _Longitude;

        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Reconciled totals and supported formats for a closed settlement period.</summary>
    public sealed class SettlementDetailResponse
    {
        /// <summary>Canonical bank KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Period number; zero is provisional.</summary>
        [JsonField("period")]
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>Number of source entries before export exclusions.</summary>
        [JsonField("sourceEntries")]
        public int? SourceEntries { get { return _SourceEntries; } set { _SourceEntries = value; } }
        private int? _SourceEntries;

        /// <summary>Number after export exclusions.</summary>
        [JsonField("includedEntries")]
        public int? IncludedEntries { get { return _IncludedEntries; } set { _IncludedEntries = value; } }
        private int? _IncludedEntries;

        /// <summary>Totals separated by export group and currency.</summary>
        [JsonField("groups")]
        public SettlementGroupResponse[] Groups { get { return _Groups; } set { _Groups = value; } }
        private SettlementGroupResponse[] _Groups;

        /// <summary>Supported case-sensitive format identifiers.</summary>
        [JsonField("formats")]
        public string[] Formats { get { return _Formats; } set { _Formats = value; } }
        private string[] _Formats;

    }

    /// <summary>One export group in one currency; amounts keep their database sign.</summary>
    public sealed class SettlementGroupResponse
    {
        /// <summary>Stable export group identifier.</summary>
        [JsonField("group")]
        public string Group { get { return _Group; } set { _Group = value; } }
        private string _Group;

        /// <summary>Currency code.</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

        /// <summary>Included entry count.</summary>
        [JsonField("entries")]
        public int? Entries { get { return _Entries; } set { _Entries = value; } }
        private int? _Entries;

        /// <summary>Signed sum in minor units.</summary>
        [JsonField("amountMinor")]
        public long? AmountMinor { get { return _AmountMinor; } set { _AmountMinor = value; } }
        private long? _AmountMinor;

    }

    /// <summary>Bank settlement metadata, independent of display language.</summary>
    public sealed class SettlementHistoryResponse
    {
        /// <summary>Canonical bank KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>Next scheduled close in UTC; null when unknown. ISO 8601 text, sent unchanged.</summary>
        [JsonField("nextSettlement")]
        public string NextSettlement { get { return _NextSettlement; } set { _NextSettlement = value; } }
        private string _NextSettlement;

        /// <summary>Closed period metadata, newest first.</summary>
        [JsonField("periods")]
        public SettlementPeriodResponse[] Periods { get { return _Periods; } set { _Periods = value; } }
        private SettlementPeriodResponse[] _Periods;

        /// <summary>Pass as beforePeriod for older rows; null at the end.</summary>
        [JsonField("nextBeforePeriod")]
        public int? NextBeforePeriod { get { return _NextBeforePeriod; } set { _NextBeforePeriod = value; } }
        private int? _NextBeforePeriod;

    }

    /// <summary>Historical metadata from LogA; missing values are null.</summary>
    public sealed class SettlementPeriodResponse
    {
        /// <summary>Settlement period number; zero is never returned as a closed period.</summary>
        [JsonField("period")]
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>Period end in UTC. ISO 8601 text, sent unchanged.</summary>
        [JsonField("settlementDate")]
        public string SettlementDate { get { return _SettlementDate; } set { _SettlementDate = value; } }
        private string _SettlementDate;

        /// <summary>Recorded execution time in UTC. ISO 8601 text, sent unchanged.</summary>
        [JsonField("settlementRun")]
        public string SettlementRun { get { return _SettlementRun; } set { _SettlementRun = value; } }
        private string _SettlementRun;

        /// <summary>First recorded transaction time in UTC. ISO 8601 text, sent unchanged.</summary>
        [JsonField("firstTransaction")]
        public string FirstTransaction { get { return _FirstTransaction; } set { _FirstTransaction = value; } }
        private string _FirstTransaction;

        /// <summary>Last recorded transaction time in UTC. ISO 8601 text, sent unchanged.</summary>
        [JsonField("lastTransaction")]
        public string LastTransaction { get { return _LastTransaction; } set { _LastTransaction = value; } }
        private string _LastTransaction;

        /// <summary>Signed stored total in minor units, with no implied currency or export filtering.</summary>
        [JsonField("amountMinor")]
        public long? AmountMinor { get { return _AmountMinor; } set { _AmountMinor = value; } }
        private long? _AmountMinor;

        /// <summary>Stored transaction count.</summary>
        [JsonField("transactionCount")]
        public long? TransactionCount { get { return _TransactionCount; } set { _TransactionCount = value; } }
        private long? _TransactionCount;

    }

    /// <summary>One alert with canonical object KIDs and a UTC last-contact or out-of-order timestamp.</summary>
    public sealed class TenantStatusItem
    {
        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>bankKid</summary>
        [JsonField("bankKid")]
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>bankName</summary>
        [JsonField("bankName")]
        public string BankName { get { return _BankName; } set { _BankName = value; } }
        private string _BankName;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>unitName</summary>
        [JsonField("unitName")]
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        private string _UnitName;

        /// <summary>computerName</summary>
        [JsonField("computerName")]
        public string ComputerName { get { return _ComputerName; } set { _ComputerName = value; } }
        private string _ComputerName;

        /// <summary>bankType</summary>
        [JsonField("bankType")]
        public string BankType { get { return _BankType; } set { _BankType = value; } }
        private string _BankType;

        /// <summary>unitType</summary>
        [JsonField("unitType")]
        public int? UnitType { get { return _UnitType; } set { _UnitType = value; } }
        private int? _UnitType;

        /// <summary>errorId</summary>
        [JsonField("errorId")]
        public int? ErrorId { get { return _ErrorId; } set { _ErrorId = value; } }
        private int? _ErrorId;

        /// <summary>timestampUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("timestampUtc")]
        public string TimestampUtc { get { return _TimestampUtc; } set { _TimestampUtc = value; } }
        private string _TimestampUtc;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>API-computed bank icon; use unchanged in the selected icon set's image URL.</summary>
        [JsonField("bankIconKid")]
        public string BankIconKid { get { return _BankIconKid; } set { _BankIconKid = value; } }
        private string _BankIconKid;

        /// <summary>API-computed location icon including its location number in Kid.Text.</summary>
        [JsonField("locationIconKid")]
        public string LocationIconKid { get { return _LocationIconKid; } set { _LocationIconKid = value; } }
        private string _LocationIconKid;

    }

    /// <summary>One lazy-loaded page from a bounded, authorized status snapshot.</summary>
    public sealed class TenantStatusPageResponse
    {
        /// <summary>status</summary>
        [JsonField("status")]
        public TenantStatusResponse Status { get { return _Status; } set { _Status = value; } }
        private TenantStatusResponse _Status;

        /// <summary>offset</summary>
        [JsonField("offset")]
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>totalCount</summary>
        [JsonField("totalCount")]
        public int? TotalCount { get { return _TotalCount; } set { _TotalCount = value; } }
        private int? _TotalCount;

        /// <summary>previousCursor</summary>
        [JsonField("previousCursor")]
        public string PreviousCursor { get { return _PreviousCursor; } set { _PreviousCursor = value; } }
        private string _PreviousCursor;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

    }

    /// <summary>A bounded operational snapshot; failed sources are explicit, never reported as healthy.</summary>
    public sealed class TenantStatusResponse
    {
        /// <summary>measuredAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("measuredAtUtc")]
        public string MeasuredAtUtc { get { return _MeasuredAtUtc; } set { _MeasuredAtUtc = value; } }
        private string _MeasuredAtUtc;

        /// <summary>refreshAfterSeconds</summary>
        [JsonField("refreshAfterSeconds")]
        public int? RefreshAfterSeconds { get { return _RefreshAfterSeconds; } set { _RefreshAfterSeconds = value; } }
        private int? _RefreshAfterSeconds;

        /// <summary>sources</summary>
        [JsonField("sources")]
        public TenantStatusSourceResult[] Sources { get { return _Sources; } set { _Sources = value; } }
        private TenantStatusSourceResult[] _Sources;

        /// <summary>items</summary>
        [JsonField("items")]
        public TenantStatusItem[] Items { get { return _Items; } set { _Items = value; } }
        private TenantStatusItem[] _Items;

    }

    /// <summary>Outcome of one independently executed lookup. HasMore means the per-source limit was reached.</summary>
    public sealed class TenantStatusSourceResult
    {
        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>count</summary>
        [JsonField("count")]
        public int? Count { get { return _Count; } set { _Count = value; } }
        private int? _Count;

        /// <summary>hasMore</summary>
        [JsonField("hasMore")]
        public bool? HasMore { get { return _HasMore; } set { _HasMore = value; } }
        private bool? _HasMore;

        /// <summary>errorCode</summary>
        [JsonField("errorCode")]
        public string ErrorCode { get { return _ErrorCode; } set { _ErrorCode = value; } }
        private string _ErrorCode;

    }

    /// <summary>Authorized unit with the declared groups for its resolved type. No setting/state values or write permissions are returned.</summary>
    public sealed class UnitDetailsResponse
    {
        /// <summary>location</summary>
        [JsonField("location")]
        public BankLocationResponse Location { get { return _Location; } set { _Location = value; } }
        private BankLocationResponse _Location;

        /// <summary>unit</summary>
        [JsonField("unit")]
        public UnitOverviewResponse Unit { get { return _Unit; } set { _Unit = value; } }
        private UnitOverviewResponse _Unit;

        /// <summary>descriptorAvailable</summary>
        [JsonField("descriptorAvailable")]
        public bool? DescriptorAvailable { get { return _DescriptorAvailable; } set { _DescriptorAvailable = value; } }
        private bool? _DescriptorAvailable;

        /// <summary>settingGroups</summary>
        [JsonField("settingGroups")]
        public string[] SettingGroups { get { return _SettingGroups; } set { _SettingGroups = value; } }
        private string[] _SettingGroups;

        /// <summary>stateGroups</summary>
        [JsonField("stateGroups")]
        public string[] StateGroups { get { return _StateGroups; } set { _StateGroups = value; } }
        private string[] _StateGroups;

    }

    /// <summary>Unit and parent identities, display names/icons, activation/deletion state and requested unit columns.</summary>
    public sealed class UnitDirectoryItem
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>bankKid</summary>
        [JsonField("bankKid")]
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>bankName</summary>
        [JsonField("bankName")]
        public string BankName { get { return _BankName; } set { _BankName = value; } }
        private string _BankName;

        /// <summary>bankIconKid</summary>
        [JsonField("bankIconKid")]
        public string BankIconKid { get { return _BankIconKid; } set { _BankIconKid = value; } }
        private string _BankIconKid;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>locationIconKid</summary>
        [JsonField("locationIconKid")]
        public string LocationIconKid { get { return _LocationIconKid; } set { _LocationIconKid = value; } }
        private string _LocationIconKid;

        /// <summary>enabled</summary>
        [JsonField("enabled")]
        public bool? Enabled { get { return _Enabled; } set { _Enabled = value; } }
        private bool? _Enabled;

        /// <summary>deleted</summary>
        [JsonField("deleted")]
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private bool? _Deleted;

        /// <summary>deletedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

        /// <summary>unitType</summary>
        [JsonField("unitType")]
        public string UnitType { get { return _UnitType; } set { _UnitType = value; } }
        private string _UnitType;

        /// <summary>washDocId</summary>
        [JsonField("washDocId")]
        public string WashDocId { get { return _WashDocId; } set { _WashDocId = value; } }
        private string _WashDocId;

        /// <summary>outOfOrder</summary>
        [JsonField("outOfOrder")]
        public string OutOfOrder { get { return _OutOfOrder; } set { _OutOfOrder = value; } }
        private string _OutOfOrder;

        /// <summary>latitude</summary>
        [JsonField("latitude")]
        public double? Latitude { get { return _Latitude; } set { _Latitude = value; } }
        private double? _Latitude;

        /// <summary>longitude</summary>
        [JsonField("longitude")]
        public double? Longitude { get { return _Longitude; } set { _Longitude = value; } }
        private double? _Longitude;

        /// <summary>Requested terminal eState.VersionMinor as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("versionMinor")]
        public string VersionMinor { get { return _VersionMinor; } set { _VersionMinor = value; } }
        private string _VersionMinor;

        /// <summary>Requested terminal eState.BootReason as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("bootReason")]
        public string BootReason { get { return _BootReason; } set { _BootReason = value; } }
        private string _BootReason;

        /// <summary>Requested terminal eSetting.Booted as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("booted")]
        public string Booted { get { return _Booted; } set { _Booted = value; } }
        private string _Booted;

        /// <summary>Requested terminal eState.Firmware as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("firmware")]
        public string Firmware { get { return _Firmware; } set { _Firmware = value; } }
        private string _Firmware;

        /// <summary>Requested terminal eState.StorageCardSerialNumber as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("storageCardSerialNumber")]
        public string StorageCardSerialNumber { get { return _StorageCardSerialNumber; } set { _StorageCardSerialNumber = value; } }
        private string _StorageCardSerialNumber;

        /// <summary>Requested terminal eState.Page as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("page")]
        public string Page { get { return _Page; } set { _Page = value; } }
        private string _Page;

        /// <summary>Requested terminal eState.BackLight as decoded text; null unless selected, empty when absent.</summary>
        [JsonField("backLight")]
        public string BackLight { get { return _BackLight; } set { _BackLight = value; } }
        private string _BackLight;

        /// <summary>terminal</summary>
        [JsonField("terminal")]
        public UnitTerminalResponse Terminal { get { return _Terminal; } set { _Terminal = value; } }
        private UnitTerminalResponse _Terminal;

    }

    /// <summary>A scoped Units1 or Terminals1 page. Identifiers are canonical KIDs; map coordinates belong to the parent location.</summary>
    public sealed class UnitDirectoryResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public UnitDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private UnitDirectoryItem[] _Items;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

        /// <summary>hasAllBanksAccess</summary>
        [JsonField("hasAllBanksAccess")]
        public bool? HasAllBanksAccess { get { return _HasAllBanksAccess; } set { _HasAllBanksAccess = value; } }
        private bool? _HasAllBanksAccess;

        /// <summary>fields</summary>
        [JsonField("fields")]
        public string[] Fields { get { return _Fields; } set { _Fields = value; } }
        private string[] _Fields;

    }

    /// <summary>Stored current-unit value, or an explicit absence/scope/redaction status. MS2000 is the source krumb timestamp.</summary>
    public sealed class UnitGroupFieldResponse
    {
        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>valueType</summary>
        [JsonField("valueType")]
        public string ValueType { get { return _ValueType; } set { _ValueType = value; } }
        private string _ValueType;

        /// <summary>scope</summary>
        [JsonField("scope")]
        public string Scope { get { return _Scope; } set { _Scope = value; } }
        private string _Scope;

        /// <summary>valueStatus</summary>
        [JsonField("valueStatus")]
        public string ValueStatus { get { return _ValueStatus; } set { _ValueStatus = value; } }
        private string _ValueStatus;

        /// <summary>value</summary>
        [JsonField("value")]
        public string Value { get { return _Value; } set { _Value = value; } }
        private string _Value;

        /// <summary>ms2000</summary>
        [JsonField("ms2000")]
        public long? Ms2000 { get { return _Ms2000; } set { _Ms2000 = value; } }
        private long? _Ms2000;

        /// <summary>canEdit</summary>
        [JsonField("canEdit")]
        public bool? CanEdit { get { return _CanEdit; } set { _CanEdit = value; } }
        private bool? _CanEdit;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>required</summary>
        [JsonField("required")]
        public bool? Required { get { return _Required; } set { _Required = value; } }
        private bool? _Required;

        /// <summary>minimum</summary>
        [JsonField("minimum")]
        public int? Minimum { get { return _Minimum; } set { _Minimum = value; } }
        private int? _Minimum;

        /// <summary>maximum</summary>
        [JsonField("maximum")]
        public int? Maximum { get { return _Maximum; } set { _Maximum = value; } }
        private int? _Maximum;

        /// <summary>options</summary>
        [JsonField("options")]
        public UnitSettingOption[] Options { get { return _Options; } set { _Options = value; } }
        private UnitSettingOption[] _Options;

        /// <summary>sync</summary>
        [JsonField("sync")]
        public int? Sync { get { return _Sync; } set { _Sync = value; } }
        private int? _Sync;

        /// <summary>changedBy</summary>
        [JsonField("changedBy")]
        public UnitSettingEditorResponse ChangedBy { get { return _ChangedBy; } set { _ChangedBy = value; } }
        private UnitSettingEditorResponse _ChangedBy;

        /// <summary>canReadHistory</summary>
        [JsonField("canReadHistory")]
        public bool? CanReadHistory { get { return _CanReadHistory; } set { _CanReadHistory = value; } }
        private bool? _CanReadHistory;

        /// <summary>hasHistory</summary>
        [JsonField("hasHistory")]
        public bool? HasHistory { get { return _HasHistory; } set { _HasHistory = value; } }
        private bool? _HasHistory;

    }

    /// <summary>The authorized unit and one descriptor-defined group, with read-only stored values.</summary>
    public sealed class UnitGroupResponse
    {
        /// <summary>location</summary>
        [JsonField("location")]
        public BankLocationResponse Location { get { return _Location; } set { _Location = value; } }
        private BankLocationResponse _Location;

        /// <summary>unit</summary>
        [JsonField("unit")]
        public UnitOverviewResponse Unit { get { return _Unit; } set { _Unit = value; } }
        private UnitOverviewResponse _Unit;

        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>group</summary>
        [JsonField("group")]
        public string Group { get { return _Group; } set { _Group = value; } }
        private string _Group;

        /// <summary>items</summary>
        [JsonField("items")]
        public UnitGroupFieldResponse[] Items { get { return _Items; } set { _Items = value; } }
        private UnitGroupFieldResponse[] _Items;

    }

    /// <summary>Status 200 carries an icon; missing Alive is unknown, never an offline error.</summary>
    public sealed class UnitIconResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>offline</summary>
        [JsonField("offline")]
        public bool? Offline { get { return _Offline; } set { _Offline = value; } }
        private bool? _Offline;

        /// <summary>status</summary>
        [JsonField("status")]
        public int? Status { get { return _Status; } set { _Status = value; } }
        private int? _Status;

    }

    /// <summary>Bounded lazy icon lookup, with independent errors for inaccessible units.</summary>
    public sealed class UnitIconsResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public UnitIconResponse[] Items { get { return _Items; } set { _Items = value; } }
        private UnitIconResponse[] _Items;

    }

    /// <summary>Unit name and validated eIcon name, identified only by its canonical KID.</summary>
    public sealed class UnitOverviewResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>cycle</summary>
        [JsonField("cycle")]
        public string Cycle { get { return _Cycle; } set { _Cycle = value; } }
        private string _Cycle;

        /// <summary>cycleText</summary>
        [JsonField("cycleText")]
        public string CycleText { get { return _CycleText; } set { _CycleText = value; } }
        private string _CycleText;

        /// <summary>unitType</summary>
        [JsonField("unitType")]
        public int? UnitType { get { return _UnitType; } set { _UnitType = value; } }
        private int? _UnitType;

        /// <summary>unitTypeName</summary>
        [JsonField("unitTypeName")]
        public string UnitTypeName { get { return _UnitTypeName; } set { _UnitTypeName = value; } }
        private string _UnitTypeName;

        /// <summary>unitTypeSource</summary>
        [JsonField("unitTypeSource")]
        public string UnitTypeSource { get { return _UnitTypeSource; } set { _UnitTypeSource = value; } }
        private string _UnitTypeSource;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>progress</summary>
        [JsonField("progress")]
        public UnitProgressResponse Progress { get { return _Progress; } set { _Progress = value; } }
        private UnitProgressResponse _Progress;

        /// <summary>terminal</summary>
        [JsonField("terminal")]
        public UnitTerminalResponse Terminal { get { return _Terminal; } set { _Terminal = value; } }
        private UnitTerminalResponse _Terminal;

    }

    /// <summary>API-calculated progress. Percent and remaining time are estimates, not hardware completion signals.</summary>
    public sealed class UnitProgressResponse
    {
        /// <summary>status</summary>
        [JsonField("status")]
        public string Status { get { return _Status; } set { _Status = value; } }
        private string _Status;

        /// <summary>percent</summary>
        [JsonField("percent")]
        public int? Percent { get { return _Percent; } set { _Percent = value; } }
        private int? _Percent;

        /// <summary>remainingSeconds</summary>
        [JsonField("remainingSeconds")]
        public int? RemainingSeconds { get { return _RemainingSeconds; } set { _RemainingSeconds = value; } }
        private int? _RemainingSeconds;

        /// <summary>calculatedAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("calculatedAtUtc")]
        public string CalculatedAtUtc { get { return _CalculatedAtUtc; } set { _CalculatedAtUtc = value; } }
        private string _CalculatedAtUtc;

    }

    /// <summary>Display-only audit identity; does not grant directory/account access. UserId zero has no editor; unknown nonzero identities have no KID.</summary>
    public sealed class UnitSettingEditorResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>The stored value, exact source timestamp, acknowledgement flag and editor display identity.</summary>
    public sealed class UnitSettingHistoryItem
    {
        /// <summary>value</summary>
        [JsonField("value")]
        public string Value { get { return _Value; } set { _Value = value; } }
        private string _Value;

        /// <summary>ms2000</summary>
        [JsonField("ms2000")]
        public long? Ms2000 { get { return _Ms2000; } set { _Ms2000 = value; } }
        private long? _Ms2000;

        /// <summary>sync</summary>
        [JsonField("sync")]
        public int? Sync { get { return _Sync; } set { _Sync = value; } }
        private int? _Sync;

        /// <summary>changedBy</summary>
        [JsonField("changedBy")]
        public UnitSettingEditorResponse ChangedBy { get { return _ChangedBy; } set { _ChangedBy = value; } }
        private UnitSettingEditorResponse _ChangedBy;

    }

    /// <summary>A page of setting changes, newest first; an exclusive timestamp continues to older rows.</summary>
    public sealed class UnitSettingHistoryResponse
    {
        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>group</summary>
        [JsonField("group")]
        public string Group { get { return _Group; } set { _Group = value; } }
        private string _Group;

        /// <summary>setting</summary>
        [JsonField("setting")]
        public string Setting { get { return _Setting; } set { _Setting = value; } }
        private string _Setting;

        /// <summary>items</summary>
        [JsonField("items")]
        public UnitSettingHistoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private UnitSettingHistoryItem[] _Items;

        /// <summary>nextBeforeMs2000</summary>
        [JsonField("nextBeforeMs2000")]
        public long? NextBeforeMs2000 { get { return _NextBeforeMs2000; } set { _NextBeforeMs2000 = value; } }
        private long? _NextBeforeMs2000;

    }

    /// <summary>A selectable persisted value and its localized descriptor label.</summary>
    public sealed class UnitSettingOption
    {
        /// <summary>value</summary>
        [JsonField("value")]
        public string Value { get { return _Value; } set { _Value = value; } }
        private string _Value;

        /// <summary>label</summary>
        [JsonField("label")]
        public string Label { get { return _Label; } set { _Label = value; } }
        private string _Label;

    }

    /// <summary>Invariant setting text with the revision obtained from GetUnitGroup.</summary>
    public sealed class UnitSettingRequest
    {
        /// <summary>value</summary>
        [JsonField("value")]
        public string Value { get { return _Value; } set { _Value = value; } }
        private string _Value;

        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Confirmed stored setting and a new revision for subsequent edits.</summary>
    public sealed class UnitSettingResponse
    {
        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>group</summary>
        [JsonField("group")]
        public string Group { get { return _Group; } set { _Group = value; } }
        private string _Group;

        /// <summary>setting</summary>
        [JsonField("setting")]
        public string Setting { get { return _Setting; } set { _Setting = value; } }
        private string _Setting;

        /// <summary>value</summary>
        [JsonField("value")]
        public string Value { get { return _Value; } set { _Value = value; } }
        private string _Value;

        /// <summary>ms2000</summary>
        [JsonField("ms2000")]
        public long? Ms2000 { get { return _Ms2000; } set { _Ms2000 = value; } }
        private long? _Ms2000;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>sync</summary>
        [JsonField("sync")]
        public int? Sync { get { return _Sync; } set { _Sync = value; } }
        private int? _Sync;

        /// <summary>changedBy</summary>
        [JsonField("changedBy")]
        public UnitSettingEditorResponse ChangedBy { get { return _ChangedBy; } set { _ChangedBy = value; } }
        private UnitSettingEditorResponse _ChangedBy;

    }

    /// <summary>Visible authorized main terminal identified by a canonical unit KID; no extra access is granted.</summary>
    public sealed class UnitTerminalResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed main-unit icon identity, including its unit number.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Both address components and the last observed revision are required.</summary>
    public sealed class UpdateObjectAddressRequest
    {
        /// <summary>address</summary>
        [JsonField("address")]
        public string Address { get { return _Address; } set { _Address = value; } }
        private string _Address;

        /// <summary>zip</summary>
        [JsonField("zip")]
        public string Zip { get { return _Zip; } set { _Zip = value; } }
        private string _Zip;

        /// <summary>expectedRevision</summary>
        [JsonField("expectedRevision")]
        public string ExpectedRevision { get { return _ExpectedRevision; } set { _ExpectedRevision = value; } }
        private string _ExpectedRevision;

    }

    /// <summary>Activation credential for an active resident; returned only to bank-wide User Create managers.</summary>
    public sealed class UserActivationResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

        /// <summary>activationCode</summary>
        [JsonField("activationCode")]
        public string ActivationCode { get { return _ActivationCode; } set { _ActivationCode = value; } }
        private string _ActivationCode;

        /// <summary>Opaque QR payload in the existing FlexORM/FlexCipherLongs format. Empty when the tenant has no activation URL. Render the QR image in the client.</summary>
        [JsonField("qrCodeDataV1")]
        public string QrCodeDataV1 { get { return _QrCodeDataV1; } set { _QrCodeDataV1 = value; } }
        private string _QrCodeDataV1;

        /// <summary>Version 2: the same three values, a random 30-bit noise value, and a 30-bit checksum (0–1073741823), (((bankCode * 31 + userCode) * 31 + seconds) * 31 + noise) modulo 1073741824. Decode five values with FlexCipherLongs. Empty when the tenant has no activation URL.</summary>
        [JsonField("qrCodeDataV2")]
        public string QrCodeDataV2 { get { return _QrCodeDataV2; } set { _QrCodeDataV2 = value; } }
        private string _QrCodeDataV2;

    }

    /// <summary>Canonical eUserAttribute name and value; -1 means no numeric value.</summary>
    public sealed class UserAttributeInput
    {
        /// <summary>attribute</summary>
        [JsonField("attribute")]
        public string Attribute { get { return _Attribute; } set { _Attribute = value; } }
        private string _Attribute;

        /// <summary>value</summary>
        [JsonField("value")]
        public long? Value { get { return _Value; } set { _Value = value; } }
        private long? _Value;

    }

    /// <summary>An eUserAttribute identifier and stored value; negative values mean no numeric value.</summary>
    public sealed class UserAttributeResponse
    {
        /// <summary>attribute</summary>
        [JsonField("attribute")]
        public string Attribute { get { return _Attribute; } set { _Attribute = value; } }
        private string _Attribute;

        /// <summary>value</summary>
        [JsonField("value")]
        public long? Value { get { return _Value; } set { _Value = value; } }
        private long? _Value;

    }

    /// <summary>Signed balances in minor currency units (øre for DKK). Missing/hidden residents have status not-found and null balances.</summary>
    public sealed class UserBalanceItem
    {
        /// <summary>Canonical resident KID.</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>ok or not-found; hidden and missing residents are indistinguishable.</summary>
        [JsonField("status")]
        public string Status { get { return _Status; } set { _Status = value; } }
        private string _Status;

        /// <summary>Current signed balance, including discount and settlement correction.</summary>
        [JsonField("currentBalanceMinor")]
        public long? CurrentBalanceMinor { get { return _CurrentBalanceMinor; } set { _CurrentBalanceMinor = value; } }
        private long? _CurrentBalanceMinor;

        /// <summary>Latest positive period's sum, or the provisional period's corrected balance. Null when absent.</summary>
        [JsonField("previousBalanceMinor")]
        public long? PreviousBalanceMinor { get { return _PreviousBalanceMinor; } set { _PreviousBalanceMinor = value; } }
        private long? _PreviousBalanceMinor;

        /// <summary>Resident's latest positive period, or bank's highest Log1 period plus one for a provisional period. Null when absent.</summary>
        [JsonField("previousPeriod")]
        public int? PreviousPeriod { get { return _PreviousPeriod; } set { _PreviousPeriod = value; } }
        private int? _PreviousPeriod;

        /// <summary>True only for a computed, unpersisted period caused by delayed settlement. False when absent.</summary>
        [JsonField("previousPeriodIsProvisional")]
        public bool? PreviousPeriodIsProvisional { get { return _PreviousPeriodIsProvisional; } set { _PreviousPeriodIsProvisional = value; } }
        private bool? _PreviousPeriodIsProvisional;

        /// <summary>Latest Log1 posting time across all periods and entry types, as UTC milliseconds since 2000-01-01. Zero when no postings exist; null for not-found.</summary>
        [JsonField("latestPostingMs2000")]
        public long? LatestPostingMs2000 { get { return _LatestPostingMs2000; } set { _LatestPostingMs2000 = value; } }
        private long? _LatestPostingMs2000;

        /// <summary>Active card/SEPA subscription using the authorized bank's Orders state (Flags and CR2000 positive, ActionCode OK/AUTHORIZE). Null for not-found.</summary>
        [JsonField("hasActiveSubscription")]
        public bool? HasActiveSubscription { get { return _HasActiveSubscription; } set { _HasActiveSubscription = value; } }
        private bool? _HasActiveSubscription;

        /// <summary>Separate balances by normalized Log1 currency; empty for no postings/discount or not-found. Prefer these to the legacy cross-currency scalar fields.</summary>
        [JsonField("balances")]
        public UserCurrencyBalanceItem[] Balances { get { return _Balances; } set { _Balances = value; } }
        private UserCurrencyBalanceItem[] _Balances;

    }

    /// <summary>One to fifty canonical resident KIDs from the bank in the route. Duplicates are returned once.</summary>
    public sealed class UserBalancesRequest
    {
        /// <summary>One to fifty canonical resident KIDs.</summary>
        [JsonField("userKids")]
        public string[] UserKids { get { return _UserKids; } set { _UserKids = value; } }
        private string[] _UserKids;

    }

    /// <summary>Results in requested order, without duplicate KIDs; no results are silently truncated.</summary>
    public sealed class UserBalancesResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public UserBalanceItem[] Items { get { return _Items; } set { _Items = value; } }
        private UserBalanceItem[] _Items;

    }

    /// <summary>One bounded resident command. Revision is required for existing residents; KIDs must belong to the site and bank.</summary>
    public sealed class UserCommandRequest
    {
        /// <summary>action</summary>
        [JsonField("action")]
        public string Action { get { return _Action; } set { _Action = value; } }
        private string _Action;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

        /// <summary>deleteAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("deleteAtUtc")]
        public string DeleteAtUtc { get { return _DeleteAtUtc; } set { _DeleteAtUtc = value; } }
        private string _DeleteAtUtc;

        /// <summary>tagKid</summary>
        [JsonField("tagKid")]
        public string TagKid { get { return _TagKid; } set { _TagKid = value; } }
        private string _TagKid;

        /// <summary>state</summary>
        [JsonField("state")]
        public string State { get { return _State; } set { _State = value; } }
        private string _State;

        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>attributes</summary>
        [JsonField("attributes")]
        public UserAttributeInput[] Attributes { get { return _Attributes; } set { _Attributes = value; } }
        private UserAttributeInput[] _Attributes;

        /// <summary>icon</summary>
        [JsonField("icon")]
        public string Icon { get { return _Icon; } set { _Icon = value; } }
        private string _Icon;

    }

    /// <summary>Signed legacy minor units per currency, with no conversion. Null Currency means no stored currency code. Discount applies to DKK only.</summary>
    public sealed class UserCurrencyBalanceItem
    {
        /// <summary>currency</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

        /// <summary>currentBalanceMinor</summary>
        [JsonField("currentBalanceMinor")]
        public long? CurrentBalanceMinor { get { return _CurrentBalanceMinor; } set { _CurrentBalanceMinor = value; } }
        private long? _CurrentBalanceMinor;

        /// <summary>previousBalanceMinor</summary>
        [JsonField("previousBalanceMinor")]
        public long? PreviousBalanceMinor { get { return _PreviousBalanceMinor; } set { _PreviousBalanceMinor = value; } }
        private long? _PreviousBalanceMinor;

        /// <summary>previousPeriod</summary>
        [JsonField("previousPeriod")]
        public int? PreviousPeriod { get { return _PreviousPeriod; } set { _PreviousPeriod = value; } }
        private int? _PreviousPeriod;

        /// <summary>previousPeriodIsProvisional</summary>
        [JsonField("previousPeriodIsProvisional")]
        public bool? PreviousPeriodIsProvisional { get { return _PreviousPeriodIsProvisional; } set { _PreviousPeriodIsProvisional = value; } }
        private bool? _PreviousPeriodIsProvisional;

    }

    /// <summary>Resident and parent bank identities with display metadata only.</summary>
    public sealed class UserDirectoryItem
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>bankKid</summary>
        [JsonField("bankKid")]
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>deletedAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAt")]
        public string DeletedAt { get { return _DeletedAt; } set { _DeletedAt = value; } }
        private string _DeletedAt;

    }

    /// <summary>Authorized resident page. A short page may still have a continuation.</summary>
    public sealed class UserDirectoryResponse
    {
        /// <summary>items</summary>
        [JsonField("items")]
        public UserDirectoryItem[] Items { get { return _Items; } set { _Items = value; } }
        private UserDirectoryItem[] _Items;

        /// <summary>nextCursor</summary>
        [JsonField("nextCursor")]
        public string NextCursor { get { return _NextCursor; } set { _NextCursor = value; } }
        private string _NextCursor;

        /// <summary>scanLimitReached</summary>
        [JsonField("scanLimitReached")]
        public bool? ScanLimitReached { get { return _ScanLimitReached; } set { _ScanLimitReached = value; } }
        private bool? _ScanLimitReached;

    }

    /// <summary>A location KID, Access/NoAccess state and eIcon name (default house), cached up to 60 seconds. Location-scoped managers see only their locations.</summary>
    public sealed class UserLocationResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>state</summary>
        [JsonField("state")]
        public string State { get { return _State; } set { _State = value; } }
        private string _State;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>API-computed icon identity; use unchanged in the icon image URL.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Non-reserving number suggestion. Number is empty when no configured candidate is available.</summary>
    public sealed class UserNumberSuggestionResponse
    {
        /// <summary>bankKid</summary>
        [JsonField("bankKid")]
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

    }

    /// <summary>One local day/location/type/period/currency group. Amounts are signed minor units.</summary>
    public sealed class UserReceipt
    {
        /// <summary>key</summary>
        [JsonField("key")]
        public string Key { get { return _Key; } set { _Key = value; } }
        private string _Key;

        /// <summary>date ISO 8601 text, sent unchanged.</summary>
        [JsonField("date")]
        public string Date { get { return _Date; } set { _Date = value; } }
        private string _Date;

        /// <summary>locationKid</summary>
        [JsonField("locationKid")]
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>locationName</summary>
        [JsonField("locationName")]
        public string LocationName { get { return _LocationName; } set { _LocationName = value; } }
        private string _LocationName;

        /// <summary>period</summary>
        [JsonField("period")]
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>provisional</summary>
        [JsonField("provisional")]
        public bool? Provisional { get { return _Provisional; } set { _Provisional = value; } }
        private bool? _Provisional;

        /// <summary>kind</summary>
        [JsonField("kind")]
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>currency</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

        /// <summary>totalMinor</summary>
        [JsonField("totalMinor")]
        public long? TotalMinor { get { return _TotalMinor; } set { _TotalMinor = value; } }
        private long? _TotalMinor;

        /// <summary>vatMinor</summary>
        [JsonField("vatMinor")]
        public long? VatMinor { get { return _VatMinor; } set { _VatMinor = value; } }
        private long? _VatMinor;

        /// <summary>balanceAfterMinor</summary>
        [JsonField("balanceAfterMinor")]
        public long? BalanceAfterMinor { get { return _BalanceAfterMinor; } set { _BalanceAfterMinor = value; } }
        private long? _BalanceAfterMinor;

        /// <summary>lines</summary>
        [JsonField("lines")]
        public UserReceiptLine[] Lines { get { return _Lines; } set { _Lines = value; } }
        private UserReceiptLine[] _Lines;

    }

    /// <summary>One decoded document; calculated adjustments have no transaction KID.</summary>
    public sealed class UserReceiptLine
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>occurredAt ISO 8601 text, sent unchanged.</summary>
        [JsonField("occurredAt")]
        public string OccurredAt { get { return _OccurredAt; } set { _OccurredAt = value; } }
        private string _OccurredAt;

        /// <summary>unitKid</summary>
        [JsonField("unitKid")]
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>unitName</summary>
        [JsonField("unitName")]
        public string UnitName { get { return _UnitName; } set { _UnitName = value; } }
        private string _UnitName;

        /// <summary>texts</summary>
        [JsonField("texts")]
        public string[] Texts { get { return _Texts; } set { _Texts = value; } }
        private string[] _Texts;

        /// <summary>amountMinor</summary>
        [JsonField("amountMinor")]
        public long? AmountMinor { get { return _AmountMinor; } set { _AmountMinor = value; } }
        private long? _AmountMinor;

        /// <summary>calculated</summary>
        [JsonField("calculated")]
        public bool? Calculated { get { return _Calculated; } set { _Calculated = value; } }
        private bool? _Calculated;

    }

    /// <summary>A complete page of resident receipts. Offsets count receipts, never posting lines.</summary>
    public sealed class UserReceiptsResponse
    {
        /// <summary>userKid</summary>
        [JsonField("userKid")]
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>items</summary>
        [JsonField("items")]
        public UserReceipt[] Items { get { return _Items; } set { _Items = value; } }
        private UserReceipt[] _Items;

        /// <summary>nextOffset</summary>
        [JsonField("nextOffset")]
        public int? NextOffset { get { return _NextOffset; } set { _NextOffset = value; } }
        private int? _NextOffset;

        /// <summary>periodCount</summary>
        [JsonField("periodCount")]
        public int? PeriodCount { get { return _PeriodCount; } set { _PeriodCount = value; } }
        private int? _PeriodCount;

    }

    /// <summary>Canonical location or tag KID with its current state.</summary>
    public sealed class UserScopeState
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>state</summary>
        [JsonField("state")]
        public string State { get { return _State; } set { _State = value; } }
        private string _State;

    }

    /// <summary>A tag KID and eTagState name.</summary>
    public sealed class UserTagResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>state</summary>
        [JsonField("state")]
        public string State { get { return _State; } set { _State = value; } }
        private string _State;

    }

    /// <summary>Authoritative resident details and revision, with permitted operation levels and asynchronous backend synchronization.</summary>
    public sealed class UserWorkspaceResponse
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>revision</summary>
        [JsonField("revision")]
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

        /// <summary>name</summary>
        [JsonField("name")]
        public string Name { get { return _Name; } set { _Name = value; } }
        private string _Name;

        /// <summary>number</summary>
        [JsonField("number")]
        public string Number { get { return _Number; } set { _Number = value; } }
        private string _Number;

        /// <summary>deletedAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("deletedAtUtc")]
        public string DeletedAtUtc { get { return _DeletedAtUtc; } set { _DeletedAtUtc = value; } }
        private string _DeletedAtUtc;

        /// <summary>deleteAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("deleteAtUtc")]
        public string DeleteAtUtc { get { return _DeleteAtUtc; } set { _DeleteAtUtc = value; } }
        private string _DeleteAtUtc;

        /// <summary>locations</summary>
        [JsonField("locations")]
        public UserScopeState[] Locations { get { return _Locations; } set { _Locations = value; } }
        private UserScopeState[] _Locations;

        /// <summary>tags</summary>
        [JsonField("tags")]
        public UserScopeState[] Tags { get { return _Tags; } set { _Tags = value; } }
        private UserScopeState[] _Tags;

        /// <summary>attributes</summary>
        [JsonField("attributes")]
        public UserAttributeInput[] Attributes { get { return _Attributes; } set { _Attributes = value; } }
        private UserAttributeInput[] _Attributes;

        /// <summary>canWrite</summary>
        [JsonField("canWrite")]
        public bool? CanWrite { get { return _CanWrite; } set { _CanWrite = value; } }
        private bool? _CanWrite;

        /// <summary>canCreate</summary>
        [JsonField("canCreate")]
        public bool? CanCreate { get { return _CanCreate; } set { _CanCreate = value; } }
        private bool? _CanCreate;

        /// <summary>synchronization</summary>
        [JsonField("synchronization")]
        public string Synchronization { get { return _Synchronization; } set { _Synchronization = value; } }
        private string _Synchronization;

        /// <summary>canDelete</summary>
        [JsonField("canDelete")]
        public bool? CanDelete { get { return _CanDelete; } set { _CanDelete = value; } }
        private bool? _CanDelete;

        /// <summary>canRenameExternalId</summary>
        [JsonField("canRenameExternalId")]
        public bool? CanRenameExternalId { get { return _CanRenameExternalId; } set { _CanRenameExternalId = value; } }
        private bool? _CanRenameExternalId;

        /// <summary>canRename</summary>
        [JsonField("canRename")]
        public bool? CanRename { get { return _CanRename; } set { _CanRename = value; } }
        private bool? _CanRename;

        /// <summary>Current display icon. New assignments must use the Person catalog.</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>All Person icons, with a current non-Person icon prepended for display only.</summary>
        [JsonField("availableIcons")]
        public string[] AvailableIcons { get { return _AvailableIcons; } set { _AvailableIcons = value; } }
        private string[] _AvailableIcons;

        /// <summary>Display hint: User Write and an active resident. Commands always reauthorize.</summary>
        [JsonField("canEditIcon")]
        public bool? CanEditIcon { get { return _CanEditIcon; } set { _CanEditIcon = value; } }
        private bool? _CanEditIcon;

    }

    /// <summary>ValidationProblemDetails</summary>
    public sealed class ValidationProblemDetails
    {
        /// <summary>type</summary>
        [JsonField("type")]
        public string Type { get { return _Type; } set { _Type = value; } }
        private string _Type;

        /// <summary>title</summary>
        [JsonField("title")]
        public string Title { get { return _Title; } set { _Title = value; } }
        private string _Title;

        /// <summary>status</summary>
        [JsonField("status")]
        public int? Status { get { return _Status; } set { _Status = value; } }
        private int? _Status;

        /// <summary>detail</summary>
        [JsonField("detail")]
        public string Detail { get { return _Detail; } set { _Detail = value; } }
        private string _Detail;

        /// <summary>instance</summary>
        [JsonField("instance")]
        public string Instance { get { return _Instance; } set { _Instance = value; } }
        private string _Instance;

        /// <summary>errors</summary>
        [JsonField("errors")]
        public Dictionary<string, string[]> Errors { get { return _Errors; } set { _Errors = value; } }
        private Dictionary<string, string[]> _Errors;

    }

    /// <summary>Public tenant-wide count; does not expose or grant access to any individual account.</summary>
    public sealed class ActiveUsersResponse
    {
        /// <summary>The configured site's tenant KID.</summary>
        [JsonField("tenantKid")]
        public string TenantKid { get { return _TenantKid; } set { _TenantKid = value; } }
        private string _TenantKid;

        /// <summary>Distinct qualifying bank/user pairs, including a genuine zero when no pairs match.</summary>
        [JsonField("count")]
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>The fixed 100-day lookback.</summary>
        [JsonField("lookbackDays")]
        public int? LookbackDays { get { return _LookbackDays; } set { _LookbackDays = value; } }
        private int? _LookbackDays;

        /// <summary>Exclusive UTC lower bound used for Log7.MS2000. ISO 8601 text, sent unchanged.</summary>
        [JsonField("sinceUtc")]
        public string SinceUtc { get { return _SinceUtc; } set { _SinceUtc = value; } }
        private string _SinceUtc;

        /// <summary>UTC time used for this cached count; it may be up to 5 minutes old. ISO 8601 text, sent unchanged.</summary>
        [JsonField("measuredAtUtc")]
        public string MeasuredAtUtc { get { return _MeasuredAtUtc; } set { _MeasuredAtUtc = value; } }
        private string _MeasuredAtUtc;

    }

    /// <summary>Describes public service availability without exposing database or customer data.</summary>
    public sealed class ApiStatusResponse
    {
        /// <summary>The public service name.</summary>
        [JsonField("service")]
        public string Service { get { return _Service; } set { _Service = value; } }
        private string _Service;

        /// <summary>The service availability.</summary>
        [JsonField("status")]
        public string Status { get { return _Status; } set { _Status = value; } }
        private string _Status;

        /// <summary>The API contract version.</summary>
        [JsonField("apiVersion")]
        public string ApiVersion { get { return _ApiVersion; } set { _ApiVersion = value; } }
        private string _ApiVersion;

    }

    /// <summary>Opaque image identity: eIcon name for an icon alone, otherwise canonical Kid.ToString().</summary>
    public sealed class IconPresentationResponse
    {
        /// <summary>iconKid</summary>
        [JsonField("iconKid")]
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

    }

    /// <summary>Total revenue at a coordinate across all retained purchases, independent of the coin limit.</summary>
    public sealed class PurchaseHeatmapPoint
    {
        /// <summary>latitude</summary>
        [JsonField("latitude")]
        public double? Latitude { get { return _Latitude; } set { _Latitude = value; } }
        private double? _Latitude;

        /// <summary>longitude</summary>
        [JsonField("longitude")]
        public double? Longitude { get { return _Longitude; } set { _Longitude = value; } }
        private double? _Longitude;

        /// <summary>amount</summary>
        [JsonField("amount")]
        public double? Amount { get { return _Amount; } set { _Amount = value; } }
        private double? _Amount;

    }

    /// <summary>Canonical transaction KID and UTC display time (original MS2000 without an offset). Amount is positive major units; currencies are not converted.</summary>
    public sealed class PurchaseMapPoint
    {
        /// <summary>kid</summary>
        [JsonField("kid")]
        public string Kid { get { return _Kid; } set { _Kid = value; } }
        private string _Kid;

        /// <summary>latitude</summary>
        [JsonField("latitude")]
        public double? Latitude { get { return _Latitude; } set { _Latitude = value; } }
        private double? _Latitude;

        /// <summary>longitude</summary>
        [JsonField("longitude")]
        public double? Longitude { get { return _Longitude; } set { _Longitude = value; } }
        private double? _Longitude;

        /// <summary>timestampUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("timestampUtc")]
        public string TimestampUtc { get { return _TimestampUtc; } set { _TimestampUtc = value; } }
        private string _TimestampUtc;

        /// <summary>amount</summary>
        [JsonField("amount")]
        public double? Amount { get { return _Amount; } set { _Amount = value; } }
        private double? _Amount;

    }

    /// <summary>A bounded, public display sample, not a complete transaction ledger.</summary>
    public sealed class PurchaseMapSnapshot
    {
        /// <summary>measuredAtUtc ISO 8601 text, sent unchanged.</summary>
        [JsonField("measuredAtUtc")]
        public string MeasuredAtUtc { get { return _MeasuredAtUtc; } set { _MeasuredAtUtc = value; } }
        private string _MeasuredAtUtc;

        /// <summary>refreshAfterSeconds</summary>
        [JsonField("refreshAfterSeconds")]
        public int? RefreshAfterSeconds { get { return _RefreshAfterSeconds; } set { _RefreshAfterSeconds = value; } }
        private int? _RefreshAfterSeconds;

        /// <summary>items</summary>
        [JsonField("items")]
        public PurchaseMapPoint[] Items { get { return _Items; } set { _Items = value; } }
        private PurchaseMapPoint[] _Items;

        /// <summary>Complete retained purchase revenue grouped by coordinates; never limited by the animated coin count.</summary>
        [JsonField("heatmap")]
        public PurchaseHeatmapPoint[] Heatmap { get { return _Heatmap; } set { _Heatmap = value; } }
        private PurchaseHeatmapPoint[] _Heatmap;

    }

    /// <summary>Public purchase aggregate in Log1Hour, cached for up to one minute.</summary>
    public sealed class PurchasesResponse
    {
        /// <summary>Configured site tenant.</summary>
        [JsonField("tenantKid")]
        public string TenantKid { get { return _TenantKid; } set { _TenantKid = value; } }
        private string _TenantKid;

        /// <summary>Number of matching purchase rows.</summary>
        [JsonField("count")]
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>Nominal one-hour window maintained by the database.</summary>
        [JsonField("lookbackHours")]
        public int? LookbackHours { get { return _LookbackHours; } set { _LookbackHours = value; } }
        private int? _LookbackHours;

        /// <summary>Nominal window start; actual rows depend on Log1Hour cleanup. ISO 8601 text, sent unchanged.</summary>
        [JsonField("sinceUtc")]
        public string SinceUtc { get { return _SinceUtc; } set { _SinceUtc = value; } }
        private string _SinceUtc;

        /// <summary>UTC measurement time. ISO 8601 text, sent unchanged.</summary>
        [JsonField("measuredAtUtc")]
        public string MeasuredAtUtc { get { return _MeasuredAtUtc; } set { _MeasuredAtUtc = value; } }
        private string _MeasuredAtUtc;

        /// <summary>Positive purchase total in major currency units; zero for no matches.</summary>
        [JsonField("amount")]
        public double? Amount { get { return _Amount; } set { _Amount = value; } }
        private double? _Amount;

        /// <summary>MAX(Currency), or null for no matches. No currency conversion.</summary>
        [JsonField("currency")]
        public string Currency { get { return _Currency; } set { _Currency = value; } }
        private string _Currency;

    }

    /// <summary>Optional query/header parameters for GetBankAccount. Null values use API defaults.</summary>
    public sealed class GetBankAccountOptions
    {
        /// <summary>First inclusive date in TimeZone; defaults to today. ISO 8601 text, sent unchanged.</summary>
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>Last inclusive date in TimeZone; defaults to today. ISO 8601 text, sent unchanged.</summary>
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>IANA/OS time zone for date filters; defaults to Europe/Copenhagen.</summary>
        public string TimeZone { get { return _TimeZone; } set { _TimeZone = value; } }
        private string _TimeZone;

        /// <summary>Settlement period; zero is current. When supplied, replaces the date interval.</summary>
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>Optional canonical location KID in this bank.</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>Optional canonical unit KID in this bank.</summary>
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>Optional canonical resident KID in this bank.</summary>
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>all, debit (negative) or credit (positive).</summary>
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>Include zero postings (default true).</summary>
        public bool? IncludeZero { get { return _IncludeZero; } set { _IncludeZero = value; } }
        private bool? _IncludeZero;

        /// <summary>Include Booking entries (default true).</summary>
        public bool? IncludeBookings { get { return _IncludeBookings; } set { _IncludeBookings = value; } }
        private bool? _IncludeBookings;

        /// <summary>Include Month entries (default true).</summary>
        public bool? IncludeMonthly { get { return _IncludeMonthly; } set { _IncludeMonthly = value; } }
        private bool? _IncludeMonthly;

        /// <summary>Zero-based row offset, at most 100000.</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>Page size 1..200, default 50.</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

    /// <summary>Optional query/header parameters for GetBankAccountRevision. Null values use API defaults.</summary>
    public sealed class GetBankAccountRevisionOptions
    {
        /// <summary>First inclusive date in TimeZone; defaults to today. ISO 8601 text, sent unchanged.</summary>
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>Last inclusive date in TimeZone; defaults to today. ISO 8601 text, sent unchanged.</summary>
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>IANA/OS time zone for date filters; defaults to Europe/Copenhagen.</summary>
        public string TimeZone { get { return _TimeZone; } set { _TimeZone = value; } }
        private string _TimeZone;

        /// <summary>Settlement period; zero is current. When supplied, replaces the date interval.</summary>
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>Optional canonical location KID in this bank.</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>Optional canonical unit KID in this bank.</summary>
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>Optional canonical resident KID in this bank.</summary>
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>all, debit (negative) or credit (positive).</summary>
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>Include zero postings (default true).</summary>
        public bool? IncludeZero { get { return _IncludeZero; } set { _IncludeZero = value; } }
        private bool? _IncludeZero;

        /// <summary>Include Booking entries (default true).</summary>
        public bool? IncludeBookings { get { return _IncludeBookings; } set { _IncludeBookings = value; } }
        private bool? _IncludeBookings;

        /// <summary>Include Month entries (default true).</summary>
        public bool? IncludeMonthly { get { return _IncludeMonthly; } set { _IncludeMonthly = value; } }
        private bool? _IncludeMonthly;

        /// <summary>Zero-based row offset, at most 100000.</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>Page size 1..200, default 50.</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

    /// <summary>Optional query/header parameters for GetBanks. Null values use API defaults.</summary>
    public sealed class GetBanksOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>enabledOnly</summary>
        public bool? EnabledOnly { get { return _EnabledOnly; } set { _EnabledOnly = value; } }
        private bool? _EnabledOnly;

        /// <summary>fields</summary>
        public string Fields { get { return _Fields; } set { _Fields = value; } }
        private string _Fields;

        /// <summary>bankType</summary>
        public string BankType { get { return _BankType; } set { _BankType = value; } }
        private string _BankType;

    }

    /// <summary>Optional query/header parameters for GetBankDocuments. Null values use API defaults.</summary>
    public sealed class GetBankDocumentsOptions
    {
        /// <summary>Canonical location KID in this bank.</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>Canonical unit KID in this bank; also restricts the location.</summary>
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>Inclusive ISO 8601 start with an explicit UTC offset; defaults to 24 hours before through.</summary>
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>Inclusive ISO 8601 end with an explicit UTC offset; defaults to now.</summary>
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>Zero-based offset, up to 100000.</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>Page size, 1–100; defaults to 25.</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

    /// <summary>Optional query/header parameters for GetBankIcons. Null values use API defaults.</summary>
    public sealed class GetBankIconsOptions
    {
        /// <summary>kid</summary>
        public string[] Kid { get { return _Kid; } set { _Kid = value; } }
        private string[] _Kid;

    }

    /// <summary>Optional query/header parameters for SearchBanks. Null values use API defaults.</summary>
    public sealed class SearchBanksOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

    }

    /// <summary>Optional query/header parameters for SearchBankActivation. Null values use API defaults.</summary>
    public sealed class SearchBankActivationOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

    }

    /// <summary>Optional query/header parameters for GetBankUsers. Null values use API defaults.</summary>
    public sealed class GetBankUsersOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>userKid</summary>
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>locationKid</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>deleted</summary>
        public string Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private string _Deleted;

    }

    /// <summary>Optional query/header parameters for GetBankBookings. Null values use API defaults.</summary>
    public sealed class GetBankBookingsOptions
    {
        /// <summary>from ISO 8601 text, sent unchanged.</summary>
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>through ISO 8601 text, sent unchanged.</summary>
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>locationKid</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>unitKid</summary>
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>userKid</summary>
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>status</summary>
        public string Status { get { return _Status; } set { _Status = value; } }
        private string _Status;

        /// <summary>search</summary>
        public string Search { get { return _Search; } set { _Search = value; } }
        private string _Search;

        /// <summary>offset</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>limit</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

    /// <summary>Optional query/header parameters for ExportBankAccount. Null values use API defaults.</summary>
    public sealed class ExportBankAccountOptions
    {
        /// <summary>First inclusive date in TimeZone; defaults to today. ISO 8601 text, sent unchanged.</summary>
        public string From { get { return _From; } set { _From = value; } }
        private string _From;

        /// <summary>Last inclusive date in TimeZone; defaults to today. ISO 8601 text, sent unchanged.</summary>
        public string Through { get { return _Through; } set { _Through = value; } }
        private string _Through;

        /// <summary>IANA/OS time zone for date filters; defaults to Europe/Copenhagen.</summary>
        public string TimeZone { get { return _TimeZone; } set { _TimeZone = value; } }
        private string _TimeZone;

        /// <summary>Settlement period; zero is current. When supplied, replaces the date interval.</summary>
        public int? Period { get { return _Period; } set { _Period = value; } }
        private int? _Period;

        /// <summary>Optional canonical location KID in this bank.</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>Optional canonical unit KID in this bank.</summary>
        public string UnitKid { get { return _UnitKid; } set { _UnitKid = value; } }
        private string _UnitKid;

        /// <summary>Optional canonical resident KID in this bank.</summary>
        public string UserKid { get { return _UserKid; } set { _UserKid = value; } }
        private string _UserKid;

        /// <summary>all, debit (negative) or credit (positive).</summary>
        public string Kind { get { return _Kind; } set { _Kind = value; } }
        private string _Kind;

        /// <summary>Include zero postings (default true).</summary>
        public bool? IncludeZero { get { return _IncludeZero; } set { _IncludeZero = value; } }
        private bool? _IncludeZero;

        /// <summary>Include Booking entries (default true).</summary>
        public bool? IncludeBookings { get { return _IncludeBookings; } set { _IncludeBookings = value; } }
        private bool? _IncludeBookings;

        /// <summary>Include Month entries (default true).</summary>
        public bool? IncludeMonthly { get { return _IncludeMonthly; } set { _IncludeMonthly = value; } }
        private bool? _IncludeMonthly;

        /// <summary>Zero-based row offset, at most 100000.</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>Page size 1..200, default 50.</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

        /// <summary>format</summary>
        public string Format { get { return _Format; } set { _Format = value; } }
        private string _Format;

    }

    /// <summary>Optional query/header parameters for ExportBankUsers. Null values use API defaults.</summary>
    public sealed class ExportBankUsersOptions
    {
        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>locationKid</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>deleted</summary>
        public string Deleted { get { return _Deleted; } set { _Deleted = value; } }
        private string _Deleted;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

    }

    /// <summary>Optional query/header parameters for DownloadBankSettlement. Null values use API defaults.</summary>
    public sealed class DownloadBankSettlementOptions
    {
        /// <summary>format</summary>
        public string Format { get { return _Format; } set { _Format = value; } }
        private string _Format;

    }

    /// <summary>Optional query/header parameters for DownloadUnitDocumentCsv. Null values use API defaults.</summary>
    public sealed class DownloadUnitDocumentCsvOptions
    {
        /// <summary>Exact comma-separated eState names; omit for permitted states or empty for none.</summary>
        public string States { get { return _States; } set { _States = value; } }
        private string _States;

        /// <summary>Exact comma-separated eSetting names; omit for permitted settings or empty for none.</summary>
        public string Settings { get { return _Settings; } set { _Settings = value; } }
        private string _Settings;

    }

    /// <summary>Optional query/header parameters for DownloadUnitDocumentXls. Null values use API defaults.</summary>
    public sealed class DownloadUnitDocumentXlsOptions
    {
        /// <summary>Exact comma-separated eState names; omit for permitted states or empty for none.</summary>
        public string States { get { return _States; } set { _States = value; } }
        private string _States;

        /// <summary>Exact comma-separated eSetting names; omit for permitted settings or empty for none.</summary>
        public string Settings { get { return _Settings; } set { _Settings = value; } }
        private string _Settings;

    }

    /// <summary>Optional query/header parameters for GetHostingLogs. Null values use API defaults.</summary>
    public sealed class GetHostingLogsOptions
    {
        /// <summary>environment</summary>
        public string Environment { get { return _Environment; } set { _Environment = value; } }
        private string _Environment;

        /// <summary>application</summary>
        public string Application { get { return _Application; } set { _Application = value; } }
        private string _Application;

    }

    /// <summary>Optional query/header parameters for GetHostingMetrics. Null values use API defaults.</summary>
    public sealed class GetHostingMetricsOptions
    {
        /// <summary>environment</summary>
        public string Environment { get { return _Environment; } set { _Environment = value; } }
        private string _Environment;

        /// <summary>application</summary>
        public string Application { get { return _Application; } set { _Application = value; } }
        private string _Application;

        /// <summary>hours</summary>
        public int? Hours { get { return _Hours; } set { _Hours = value; } }
        private int? _Hours;

    }

    /// <summary>Optional query/header parameters for GetInstallers. Null values use API defaults.</summary>
    public sealed class GetInstallersOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>includeActivationCode</summary>
        public bool? IncludeActivationCode { get { return _IncludeActivationCode; } set { _IncludeActivationCode = value; } }
        private bool? _IncludeActivationCode;

    }

    /// <summary>Optional query/header parameters for GetActiveLocationCount. Null values use API defaults.</summary>
    public sealed class GetActiveLocationCountOptions
    {
        /// <summary>bankKid</summary>
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

    }

    /// <summary>Optional query/header parameters for GetLocations. Null values use API defaults.</summary>
    public sealed class GetLocationsOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>enabledOnly</summary>
        public bool? EnabledOnly { get { return _EnabledOnly; } set { _EnabledOnly = value; } }
        private bool? _EnabledOnly;

        /// <summary>fields</summary>
        public string Fields { get { return _Fields; } set { _Fields = value; } }
        private string _Fields;

        /// <summary>includeCoordinates</summary>
        public bool? IncludeCoordinates { get { return _IncludeCoordinates; } set { _IncludeCoordinates = value; } }
        private bool? _IncludeCoordinates;

        /// <summary>bankKid</summary>
        public string BankKid { get { return _BankKid; } set { _BankKid = value; } }
        private string _BankKid;

    }

    /// <summary>Optional query/header parameters for SearchLocations. Null values use API defaults.</summary>
    public sealed class SearchLocationsOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

    }

    /// <summary>Optional query/header parameters for SearchLocationActivation. Null values use API defaults.</summary>
    public sealed class SearchLocationActivationOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

    }

    /// <summary>Optional query/header parameters for GetLocationBookingRules. Null values use API defaults.</summary>
    public sealed class GetLocationBookingRulesOptions
    {
        /// <summary>Accept-Language</summary>
        public string AcceptLanguage { get { return _AcceptLanguage; } set { _AcceptLanguage = value; } }
        private string _AcceptLanguage;

    }

    /// <summary>Optional query/header parameters for GetLocationUnits. Null values use API defaults.</summary>
    public sealed class GetLocationUnitsOptions
    {
        /// <summary>Accept-Language</summary>
        public string AcceptLanguage { get { return _AcceptLanguage; } set { _AcceptLanguage = value; } }
        private string _AcceptLanguage;

    }

    /// <summary>Optional query/header parameters for GetUnitOverview. Null values use API defaults.</summary>
    public sealed class GetUnitOverviewOptions
    {
        /// <summary>Accept-Language</summary>
        public string AcceptLanguage { get { return _AcceptLanguage; } set { _AcceptLanguage = value; } }
        private string _AcceptLanguage;

    }

    /// <summary>Optional query/header parameters for GetUnitGroup. Null values use API defaults.</summary>
    public sealed class GetUnitGroupOptions
    {
        /// <summary>Accept-Language</summary>
        public string AcceptLanguage { get { return _AcceptLanguage; } set { _AcceptLanguage = value; } }
        private string _AcceptLanguage;

    }

    /// <summary>Optional query/header parameters for GetUnitSettingHistory. Null values use API defaults.</summary>
    public sealed class GetUnitSettingHistoryOptions
    {
        /// <summary>beforeMs2000</summary>
        public long? BeforeMs2000 { get { return _BeforeMs2000; } set { _BeforeMs2000 = value; } }
        private long? _BeforeMs2000;

        /// <summary>limit</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

    /// <summary>Optional query/header parameters for GetUnitIcons. Null values use API defaults.</summary>
    public sealed class GetUnitIconsOptions
    {
        /// <summary>kid</summary>
        public string[] Kid { get { return _Kid; } set { _Kid = value; } }
        private string[] _Kid;

    }

    /// <summary>Optional query/header parameters for GetLocationIcons. Null values use API defaults.</summary>
    public sealed class GetLocationIconsOptions
    {
        /// <summary>kid</summary>
        public string[] Kid { get { return _Kid; } set { _Kid = value; } }
        private string[] _Kid;

    }

    /// <summary>Optional query/header parameters for GetLocationOpeningHours. Null values use API defaults.</summary>
    public sealed class GetLocationOpeningHoursOptions
    {
        /// <summary>Accept-Language</summary>
        public string AcceptLanguage { get { return _AcceptLanguage; } set { _AcceptLanguage = value; } }
        private string _AcceptLanguage;

    }

    /// <summary>Optional query/header parameters for GetManagers. Null values use API defaults.</summary>
    public sealed class GetManagersOptions
    {
        /// <summary>Candidate batch size, 1–100, default 50. Keep unchanged while following a cursor.</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>Opaque continuation returned by the previous request, scoped to this site and caller.</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>Optional name/email substring, at most 128 characters, trimmed. Empty lists all permitted managers.</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>identity (default), name, email, organisation, kids, deleted, enabled or lastActive. Applied before pagination.</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>asc (default) or desc. Identity breaks ties in the same direction.</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

    }

    /// <summary>Optional query/header parameters for LoginManager. Null values use API defaults.</summary>
    public sealed class LoginManagerOptions
    {
        /// <summary>Optional IPv4/IPv6 address observed by a server-side portal for its browser client. Logged only as caller-reported metadata on failed logins, alongside the API-observed IP. Invalid/multiple values are ignored. Never changes authentication, tenant scope, local-login checks or rate limits.</summary>
        public string XPortalLoginClientIP { get { return _XPortalLoginClientIP; } set { _XPortalLoginClientIP = value; } }
        private string _XPortalLoginClientIP;

    }

    /// <summary>Optional query/header parameters for GetServices. Null values use API defaults.</summary>
    public sealed class GetServicesOptions
    {
        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

    }

    /// <summary>Optional query/header parameters for GetBankSettlements. Null values use API defaults.</summary>
    public sealed class GetBankSettlementsOptions
    {
        /// <summary>beforePeriod</summary>
        public int? BeforePeriod { get { return _BeforePeriod; } set { _BeforePeriod = value; } }
        private int? _BeforePeriod;

    }

    /// <summary>Optional query/header parameters for GetTenantStatus. Null values use API defaults.</summary>
    public sealed class GetTenantStatusOptions
    {
        /// <summary>limit</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

    /// <summary>Optional query/header parameters for GetTenantStatusPage. Null values use API defaults.</summary>
    public sealed class GetTenantStatusPageOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>offset</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>anchor</summary>
        public string Anchor { get { return _Anchor; } set { _Anchor = value; } }
        private string _Anchor;

    }

    /// <summary>Optional query/header parameters for GetUnitDocumentTable. Null values use API defaults.</summary>
    public sealed class GetUnitDocumentTableOptions
    {
        /// <summary>Exact comma-separated eState names; omit for permitted states or empty for none.</summary>
        public string States { get { return _States; } set { _States = value; } }
        private string _States;

        /// <summary>Exact comma-separated eSetting names; omit for permitted settings or empty for none.</summary>
        public string Settings { get { return _Settings; } set { _Settings = value; } }
        private string _Settings;

    }

    /// <summary>Optional query/header parameters for GetUnitDocumentHtml. Null values use API defaults.</summary>
    public sealed class GetUnitDocumentHtmlOptions
    {
        /// <summary>Exact comma-separated eState names; omit for permitted states or empty for none.</summary>
        public string States { get { return _States; } set { _States = value; } }
        private string _States;

        /// <summary>Exact comma-separated eSetting names; omit for permitted settings or empty for none.</summary>
        public string Settings { get { return _Settings; } set { _Settings = value; } }
        private string _Settings;

    }

    /// <summary>Optional query/header parameters for GetUnitDocumentSvg. Null values use API defaults.</summary>
    public sealed class GetUnitDocumentSvgOptions
    {
        /// <summary>Exact comma-separated eState names; omit for permitted states or empty for none.</summary>
        public string States { get { return _States; } set { _States = value; } }
        private string _States;

        /// <summary>Exact comma-separated eSetting names; omit for permitted settings or empty for none.</summary>
        public string Settings { get { return _Settings; } set { _Settings = value; } }
        private string _Settings;

        /// <summary>width</summary>
        public int? Width { get { return _Width; } set { _Width = value; } }
        private int? _Width;

    }

    /// <summary>Optional query/header parameters for GetUnits. Null values use API defaults.</summary>
    public sealed class GetUnitsOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>enabledOnly</summary>
        public bool? EnabledOnly { get { return _EnabledOnly; } set { _EnabledOnly = value; } }
        private bool? _EnabledOnly;

        /// <summary>fields</summary>
        public string Fields { get { return _Fields; } set { _Fields = value; } }
        private string _Fields;

        /// <summary>includeCoordinates</summary>
        public bool? IncludeCoordinates { get { return _IncludeCoordinates; } set { _IncludeCoordinates = value; } }
        private bool? _IncludeCoordinates;

        /// <summary>locationKid</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>terminalKid</summary>
        public string TerminalKid { get { return _TerminalKid; } set { _TerminalKid = value; } }
        private string _TerminalKid;

    }

    /// <summary>Optional query/header parameters for GetTerminals. Null values use API defaults.</summary>
    public sealed class GetTerminalsOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>enabledOnly</summary>
        public bool? EnabledOnly { get { return _EnabledOnly; } set { _EnabledOnly = value; } }
        private bool? _EnabledOnly;

        /// <summary>fields</summary>
        public string Fields { get { return _Fields; } set { _Fields = value; } }
        private string _Fields;

        /// <summary>includeCoordinates</summary>
        public bool? IncludeCoordinates { get { return _IncludeCoordinates; } set { _IncludeCoordinates = value; } }
        private bool? _IncludeCoordinates;

        /// <summary>locationKid</summary>
        public string LocationKid { get { return _LocationKid; } set { _LocationKid = value; } }
        private string _LocationKid;

        /// <summary>terminalKid</summary>
        public string TerminalKid { get { return _TerminalKid; } set { _TerminalKid = value; } }
        private string _TerminalKid;

    }

    /// <summary>Optional query/header parameters for GetBankNextUserNumber. Null values use API defaults.</summary>
    public sealed class GetBankNextUserNumberOptions
    {
        /// <summary>userNumber</summary>
        public string UserNumber { get { return _UserNumber; } set { _UserNumber = value; } }
        private string _UserNumber;

    }

    /// <summary>Optional query/header parameters for GetUsers. Null values use API defaults.</summary>
    public sealed class GetUsersOptions
    {
        /// <summary>pageSize</summary>
        public int? PageSize { get { return _PageSize; } set { _PageSize = value; } }
        private int? _PageSize;

        /// <summary>cursor</summary>
        public string Cursor { get { return _Cursor; } set { _Cursor = value; } }
        private string _Cursor;

        /// <summary>filter</summary>
        public string Filter { get { return _Filter; } set { _Filter = value; } }
        private string _Filter;

        /// <summary>sort</summary>
        public string Sort { get { return _Sort; } set { _Sort = value; } }
        private string _Sort;

        /// <summary>direction</summary>
        public string Direction { get { return _Direction; } set { _Direction = value; } }
        private string _Direction;

        /// <summary>enabledOnly</summary>
        public bool? EnabledOnly { get { return _EnabledOnly; } set { _EnabledOnly = value; } }
        private bool? _EnabledOnly;

    }

    /// <summary>Optional query/header parameters for GetUserReceipts. Null values use API defaults.</summary>
    public sealed class GetUserReceiptsOptions
    {
        /// <summary>offset</summary>
        public int? Offset { get { return _Offset; } set { _Offset = value; } }
        private int? _Offset;

        /// <summary>revision</summary>
        public string Revision { get { return _Revision; } set { _Revision = value; } }
        private string _Revision;

    }

    /// <summary>Optional query/header parameters for SearchUsers. Null values use API defaults.</summary>
    public sealed class SearchUsersOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

        /// <summary>kidOnly</summary>
        public bool? KidOnly { get { return _KidOnly; } set { _KidOnly = value; } }
        private bool? _KidOnly;

    }

    /// <summary>Optional query/header parameters for SearchUserSms. Null values use API defaults.</summary>
    public sealed class SearchUserSmsOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

    }

    /// <summary>Optional query/header parameters for SearchUserActivation. Null values use API defaults.</summary>
    public sealed class SearchUserActivationOptions
    {
        /// <summary>q</summary>
        public string Q { get { return _Q; } set { _Q = value; } }
        private string _Q;

    }

    /// <summary>Optional query/header parameters for GetIconPresentation. Null values use API defaults.</summary>
    public sealed class GetIconPresentationOptions
    {
        /// <summary>iconKid</summary>
        public string IconKid { get { return _IconKid; } set { _IconKid = value; } }
        private string _IconKid;

        /// <summary>text</summary>
        public string Text { get { return _Text; } set { _Text = value; } }
        private string _Text;

        /// <summary>count</summary>
        public long? Count { get { return _Count; } set { _Count = value; } }
        private long? _Count;

        /// <summary>color</summary>
        public int? Color { get { return _Color; } set { _Color = value; } }
        private int? _Color;

    }

    /// <summary>Optional query/header parameters for GetPublicDisp73. Null values use API defaults.</summary>
    public sealed class GetPublicDisp73Options
    {
        /// <summary>limit</summary>
        public int? Limit { get { return _Limit; } set { _Limit = value; } }
        private int? _Limit;

    }

}
