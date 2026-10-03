using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace Kombine.Flex.Portal.Client.Compact20
{
    [AttributeUsage(AttributeTargets.Property)]
    internal sealed class JsonFieldAttribute : Attribute
    {
        internal readonly string Name;
        public JsonFieldAttribute(string name) { Name = name; }
    }

    // JSON primitives only. Never activates a type supplied by a server or deserializes executable metadata.
    internal static class PortalJson
    {
        internal static object Parse(string text) { return new Parser(text).Read(); }
        internal static object Deserialize(string text, Type type) { return ConvertValue(Parse(text), type); }
        internal static string Serialize(object value)
        {
            StringBuilder output = new StringBuilder();
            Write(output, value, 0);
            return output.ToString();
        }

        private static object ConvertValue(object value, Type type)
        {
            Type nullable = Nullable.GetUnderlyingType(type);
            if (value == null)
            {
                if (type.IsValueType && nullable == null) throw InvalidJson();
                return null;
            }
            if (nullable != null) type = nullable;
            if (type == typeof(object)) return value;
            if (type == typeof(string)) { if (!(value is string)) throw InvalidJson(); return value; }
            if (type == typeof(bool)) { if (!(value is bool)) throw InvalidJson(); return value; }
            if (type == typeof(int) || type == typeof(long) || type == typeof(double))
            {
                if (!(value is long) && !(value is decimal) && !(value is double)) throw InvalidJson();
                try
                {
                    if (type == typeof(double)) return Convert.ToDouble(value, CultureInfo.InvariantCulture);
                    // An integer field must contain an integer token. Never round a fractional/exponent
                    // token through Decimal/Double, including tiny fractions beyond Decimal precision.
                    if (!(value is long)) throw InvalidJson();
                    if (type == typeof(int)) return checked((int)(long)value);
                    return (long)value;
                }
                catch (OverflowException) { throw InvalidJson(); }
            }
            if (type.IsArray)
            {
                IList list = value as IList;
                if (list == null) throw InvalidJson();
                Type itemType = type.GetElementType();
                Array array = Array.CreateInstance(itemType, list.Count);
                for (int i = 0; i < list.Count; i++) array.SetValue(ConvertValue(list[i], itemType), i);
                return array;
            }
            IDictionary<string, object> fields = value as IDictionary<string, object>;
            if (fields == null) throw InvalidJson();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                IDictionary dictionary = (IDictionary)Activator.CreateInstance(type);
                Type itemType = type.GetGenericArguments()[1];
                foreach (KeyValuePair<string, object> pair in fields) dictionary.Add(pair.Key, ConvertValue(pair.Value, itemType));
                return dictionary;
            }
            if (type.Assembly != typeof(PortalJson).Assembly) throw InvalidJson();
            object result = Activator.CreateInstance(type);
            foreach (PropertyInfo property in type.GetProperties())
            {
                JsonFieldAttribute field = Attribute.GetCustomAttribute(property, typeof(JsonFieldAttribute)) as JsonFieldAttribute;
                object child;
                if (field != null && fields.TryGetValue(field.Name, out child)) property.SetValue(result, ConvertValue(child, property.PropertyType), null);
            }
            return result;
        }

        private static void Write(StringBuilder output, object value, int depth)
        {
            if (depth > 64) throw InvalidJson();
            if (value == null) { output.Append("null"); return; }
            string text = value as string;
            if (text != null) { WriteString(output, text); return; }
            if (value is bool) { output.Append((bool)value ? "true" : "false"); return; }
            Type type = value.GetType();
            if (type.IsEnum) { output.Append(Convert.ToInt64(value, CultureInfo.InvariantCulture).ToString(CultureInfo.InvariantCulture)); return; }
            if (value is double || value is float)
            {
                double number = Convert.ToDouble(value, CultureInfo.InvariantCulture);
                if (Double.IsNaN(number) || Double.IsInfinity(number)) throw InvalidJson();
                output.Append(number.ToString("R", CultureInfo.InvariantCulture)); return;
            }
            if (value is byte || value is sbyte || value is short || value is ushort || value is int || value is uint || value is long || value is ulong || value is decimal)
            { output.Append(Convert.ToString(value, CultureInfo.InvariantCulture)); return; }
            IDictionary dictionary = value as IDictionary;
            if (dictionary != null)
            {
                output.Append('{'); bool first = true;
                foreach (DictionaryEntry pair in dictionary)
                {
                    if (!(pair.Key is string)) throw InvalidJson();
                    if (!first) output.Append(','); first = false;
                    WriteString(output, (string)pair.Key); output.Append(':'); Write(output, pair.Value, depth + 1);
                }
                output.Append('}'); return;
            }
            IEnumerable list = value as IEnumerable;
            if (list != null)
            {
                output.Append('['); bool first = true;
                foreach (object item in list) { if (!first) output.Append(','); first = false; Write(output, item, depth + 1); }
                output.Append(']'); return;
            }
            if (type.Assembly != typeof(PortalJson).Assembly) throw new ArgumentException("Use generated API models or JSON primitives.", "value");
            output.Append('{'); bool initial = true;
            foreach (PropertyInfo property in type.GetProperties())
            {
                JsonFieldAttribute field = Attribute.GetCustomAttribute(property, typeof(JsonFieldAttribute)) as JsonFieldAttribute;
                if (field == null) continue;
                if (!initial) output.Append(','); initial = false;
                WriteString(output, field.Name); output.Append(':'); Write(output, property.GetValue(value, null), depth + 1);
            }
            output.Append('}');
        }

        private static void WriteString(StringBuilder output, string value)
        {
            ValidateUnicode(value);
            output.Append('"');
            foreach (char c in value)
            {
                if (c == '"' || c == '\\') { output.Append('\\'); output.Append(c); }
                else if (c < 32) { output.Append("\\u"); output.Append(((int)c).ToString("x4", CultureInfo.InvariantCulture)); }
                else output.Append(c);
            }
            output.Append('"');
        }

        private static void ValidateUnicode(string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '\ud800' && text[i] <= '\udbff')
                { if (++i >= text.Length || text[i] < '\udc00' || text[i] > '\udfff') throw InvalidJson(); }
                else if (text[i] >= '\udc00' && text[i] <= '\udfff') throw InvalidJson();
            }
        }

        private static FormatException InvalidJson() { return new FormatException("Invalid JSON value, type, number or nesting depth."); }

        private sealed class Parser
        {
            private readonly string _text;
            private int _offset;
            internal Parser(string text) { if (text == null) throw new ArgumentNullException("text"); _text = text; }
            internal object Read()
            {
                if (_text.Length > 0 && _text[0] == '\ufeff') _offset++;
                object result = Value(0); Space();
                if (_offset != _text.Length) throw InvalidJson();
                return result;
            }
            private void Space() { while (_offset < _text.Length && (_text[_offset] == ' ' || _text[_offset] == '\r' || _text[_offset] == '\n' || _text[_offset] == '\t')) _offset++; }
            private bool Take(char c) { if (_offset < _text.Length && _text[_offset] == c) { _offset++; return true; } return false; }
            private object Value(int depth)
            {
                if (depth > 64) throw InvalidJson();
                Space(); if (_offset >= _text.Length) throw InvalidJson();
                char c = _text[_offset];
                if (c == '"') return Text();
                if (Take('{'))
                {
                    Dictionary<string, object> result = new Dictionary<string, object>(StringComparer.Ordinal);
                    Space(); if (Take('}')) return result;
                    do
                    {
                        Space(); string key = Text(); Space(); if (!Take(':') || result.ContainsKey(key)) throw InvalidJson();
                        result.Add(key, Value(depth + 1)); Space(); if (Take('}')) return result;
                    } while (Take(','));
                    throw InvalidJson();
                }
                if (Take('['))
                {
                    List<object> items = new List<object>(); Space(); if (Take(']')) return items;
                    do { items.Add(Value(depth + 1)); Space(); if (Take(']')) return items; } while (Take(','));
                    throw InvalidJson();
                }
                if (c == 't') { Literal("true"); return true; }
                if (c == 'f') { Literal("false"); return false; }
                if (c == 'n') { Literal("null"); return null; }
                return Number();
            }
            private void Literal(string value)
            {
                if (_offset + value.Length > _text.Length || String.CompareOrdinal(_text, _offset, value, 0, value.Length) != 0) throw InvalidJson();
                _offset += value.Length;
            }
            private string Text()
            {
                if (!Take('"')) throw InvalidJson(); StringBuilder result = new StringBuilder();
                while (_offset < _text.Length)
                {
                    char c = _text[_offset++];
                    if (c == '"') { string text = result.ToString(); ValidateUnicode(text); return text; }
                    if (c < 32) throw InvalidJson();
                    if (c == '\\')
                    {
                        if (_offset >= _text.Length) throw InvalidJson();
                        c = _text[_offset++];
                        switch (c)
                        {
                            case '"': case '\\': case '/': result.Append(c); break;
                            case 'b': result.Append('\b'); break;
                            case 'f': result.Append('\f'); break;
                            case 'n': result.Append('\n'); break;
                            case 'r': result.Append('\r'); break;
                            case 't': result.Append('\t'); break;
                            case 'u':
                                if (_offset + 4 > _text.Length) throw InvalidJson();
                                int scalar = 0;
                                for (int i = 0; i < 4; i++)
                                {
                                    char hex = _text[_offset + i];
                                    int digit = hex >= '0' && hex <= '9' ? hex - '0' : hex >= 'a' && hex <= 'f' ? hex - 'a' + 10 : hex >= 'A' && hex <= 'F' ? hex - 'A' + 10 : -1;
                                    if (digit < 0) throw InvalidJson();
                                    scalar = scalar * 16 + digit;
                                }
                                result.Append((char)scalar); _offset += 4; break;
                            default: throw InvalidJson();
                        }
                    }
                    else result.Append(c);
                }
                throw InvalidJson();
            }
            private bool Digit() { return _offset < _text.Length && _text[_offset] >= '0' && _text[_offset] <= '9'; }
            private object Number()
            {
                int start = _offset; Take('-');
                if (!Digit()) throw InvalidJson();
                if (!Take('0')) while (Digit()) _offset++;
                if (Take('.')) { if (!Digit()) throw InvalidJson(); while (Digit()) _offset++; }
                if (Take('e') || Take('E'))
                { if (!Take('+')) Take('-'); if (!Digit()) throw InvalidJson(); while (Digit()) _offset++; }
                string token = _text.Substring(start, _offset - start);
                if (token.IndexOf('.') < 0 && token.IndexOf('e') < 0 && token.IndexOf('E') < 0)
                {
                    try { return Int64.Parse(token, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture); }
                    catch (OverflowException) { }
                }
                try { return Decimal.Parse(token, NumberStyles.Float, CultureInfo.InvariantCulture); }
                catch (OverflowException) { }
                try
                {
                    double number = Double.Parse(token, NumberStyles.Float, CultureInfo.InvariantCulture);
                    if (Double.IsInfinity(number) || Double.IsNaN(number)) throw InvalidJson();
                    return number;
                }
                catch (OverflowException) { throw InvalidJson(); }
            }
        }
    }
}
