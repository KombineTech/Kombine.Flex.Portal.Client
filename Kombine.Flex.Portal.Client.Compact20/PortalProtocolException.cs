using System.IO;

namespace Kombine.Flex.Portal.Client.Compact20
{
    /// <summary>Invalid/oversized API payload. Compact Framework has no System.IO.InvalidDataException.</summary>
    public sealed class PortalProtocolException : IOException
    {
        internal PortalProtocolException(string message) : base(message) { }
    }
}
