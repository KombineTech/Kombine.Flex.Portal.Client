using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Kombine.Flex.Portal.Client.Net20
{
    /// <summary>Multipart body. Streams remain caller-owned; rewind them before a deliberate retry.</summary>
    public sealed class PortalMultipart
    {
        private readonly string _boundary = "kombine-" + Guid.NewGuid().ToString("N");
        private readonly List<Part> _parts = new List<Part>();
        private readonly Dictionary<string, bool> _names = new Dictionary<string, bool>();
        private sealed class Part { internal byte[] Header; internal byte[] Text; internal Stream Stream; internal long Start; internal long Length; }
        /// <summary>Add one UTF-8 text field, such as uploadToken.</summary>
        public void AddField(string name, string value)
        {
            Validate(name); if (value == null) throw new ArgumentNullException("value");
            byte[] bytes = new UTF8Encoding(false, true).GetBytes(value);
            if (bytes.Length > 512 * 1024) throw new ArgumentException("Multipart text field is too large.");
            Part part = new Part(); part.Text = bytes; part.Length = bytes.Length;
            Add(name, null, part);
        }
        /// <summary>Add a seekable binary stream from its current position; does not close it.</summary>
        public void AddFile(string name, string fileName, Stream stream)
        {
            Validate(name); Validate(fileName);
            if (stream == null || !stream.CanRead || !stream.CanSeek) throw new ArgumentException("A readable seekable stream is required.");
            Part part = new Part(); part.Stream = stream; part.Start = stream.Position; part.Length = stream.Length - part.Start;
            if (part.Length < 0) throw new ArgumentException("Invalid stream position.");
            Add(name, fileName, part);
        }
        private static void Validate(string value)
        {
            if (String.IsNullOrEmpty(value) || value.Length > 1024) throw new ArgumentException("Invalid multipart name.");
            foreach (char c in value) if (Char.IsControl(c) || c == '"' || c == '\\') throw new ArgumentException("Invalid multipart name.");
        }
        private void Add(string name, string fileName, Part part)
        {
            if (_names.ContainsKey(name)) throw new ArgumentException("Duplicate multipart field.");
            string header = "--" + _boundary + "\r\nContent-Disposition: form-data; name=\"" + name + "\"";
            if (fileName != null) header += "; filename=\"" + fileName + "\"\r\nContent-Type: application/octet-stream";
            part.Header = Encoding.UTF8.GetBytes(header + "\r\n\r\n");
            _parts.Add(part); _names.Add(name, true);
        }
        internal string ContentType { get { return "multipart/form-data; boundary=" + _boundary; } }
        private byte[] End { get { return Encoding.ASCII.GetBytes("--" + _boundary + "--\r\n"); } }
        internal long Length
        {
            get
            {
                long length = End.Length;
                foreach (Part part in _parts) length = checked(length + part.Header.Length + part.Length + 2);
                if (length > 140 * 1024 * 1024) throw new ArgumentException("Multipart upload is too large.");
                return length;
            }
        }
        internal void WriteTo(Stream destination)
        {
            byte[] buffer = new byte[65536];
            foreach (Part part in _parts)
            {
                destination.Write(part.Header, 0, part.Header.Length);
                if (part.Stream == null) destination.Write(part.Text, 0, part.Text.Length);
                else
                {
                    if (part.Stream.Position != part.Start) throw new InvalidOperationException("Upload stream position changed; create a new multipart body after rewinding.");
                    long remaining = part.Length;
                    while (remaining > 0)
                    {
                        int count = part.Stream.Read(buffer, 0, (int)Math.Min(remaining, buffer.Length));
                        if (count == 0) throw new IOException("Upload stream ended before its declared length.");
                        destination.Write(buffer, 0, count); remaining -= count;
                    }
                }
                destination.WriteByte(13); destination.WriteByte(10);
            }
            byte[] end = End; destination.Write(end, 0, end.Length);
        }
    }
}
