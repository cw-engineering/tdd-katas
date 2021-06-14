using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Tdd
{
    public class FileParserException : Exception, IXmlSerializable
    {
        public FileLocation Location { get; }

        public FileParserException(string message, FileLocation location) : base()
        {

        }

        protected FileParserException(SerializationInfo info, StreamingContext context) : base()
        {

        }

        public FileParserException()
        {

        }

        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }

        public void ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
