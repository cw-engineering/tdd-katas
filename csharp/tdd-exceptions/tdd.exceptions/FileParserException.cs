#pragma warning disable S3925

using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace tdd.exceptions
{
    [Serializable]
    public class FileParserException : Exception, IXmlSerializable
    {
        private const string LineKey = "Line";
        private const string ColumnKey = "Column";
        private const string OffsetKey = "Offset";

        public FileLocation Location { get; }

        public FileParserException(string message, FileLocation location) : base(message)
        {
            Location = location;
            Data[LineKey] = location.Line;
            Data[ColumnKey] = location.Column;
            Data[OffsetKey] = location.Offset;
        }

        protected FileParserException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            Location = new FileLocation
            {
                Line = Data[LineKey] as long? ?? 0,
                Column = Data[ColumnKey] as long? ?? 0,
                Offset = Data[OffsetKey] as long? ?? 0
            };
        }

        public FileParserException()
        {

        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {

        }

        public void WriteXml(XmlWriter writer)
        {

        }
    }
}
