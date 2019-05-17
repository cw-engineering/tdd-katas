using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace tdd.exceptions.tests
{
    [TestFixture]
    public class FileParserExceptionTest
    {
        [Test]
        public void Ctor_SetsMessage()
        {
            var ex = new FileParserException("hello!", new FileLocation());

            ex.Message.ShouldBe("hello!");
        }

        [Test]
        public void Ctor_SetsLocation()
        {
            var testLocation = new FileLocation {Column = 1, Line = 2, Offset = 3};
            var ex = new FileParserException("x", testLocation);

            ex.Location.ShouldBe(testLocation);
        }

        [Test]
        public void SerializesToJson()
        {
            var ex = new FileParserException("World", new FileLocation { Line = 334, Offset = 888 });

            var json = JsonConvert.SerializeObject(ex, Formatting.Indented);

            var dex = JsonConvert.DeserializeObject<FileParserException>(json);

            $"{dex.Message}[{dex.Location.Line},{dex.Location.Offset}]".ShouldBe("World[334,888]");
        }

        [Test]
        public void SerializesToBinary_NoException()
        {
            var ex = new FileParserException("World", new FileLocation { Line = 334, Offset = 888 });

            var serializationStream = new MemoryStream();

            Action action = () => new BinaryFormatter().Serialize(serializationStream, ex);
            Should.NotThrow(action);
        }

        [Test]
        public void DeserializeJson_KeepsCorrectLine()
        {
            var ex = new FileParserException("World", new FileLocation { Line = 334, Offset = 888 });

            var json = JsonConvert.SerializeObject(ex, Formatting.Indented);

            var dex = JsonConvert.DeserializeObject<FileParserException>(json);

            dex.Location.Line.ShouldBe(334);
        }
        [Test]
        public void DeserializeJson_KeepsCorrectColumn()
        {
            var ex = new FileParserException("World", new FileLocation { Column = 1});

            var json = JsonConvert.SerializeObject(ex, Formatting.Indented);

            var dex = JsonConvert.DeserializeObject<FileParserException>(json);

            dex.Location.Column.ShouldBe(1);
        }

        [Test]
        public void DeserializeJson_KeepsCorrectOffset()
        {
            var ex = new FileParserException("World", new FileLocation { Offset = long.MaxValue });

            var json = JsonConvert.SerializeObject(ex, Formatting.Indented);

            var dex = JsonConvert.DeserializeObject<FileParserException>(json);

            dex.Location.Offset.ShouldBe(long.MaxValue);
        }

        [Test]
        public void SerializesToXML_NoException()
        {
            var ex = new FileParserException("World", new FileLocation { Line = 334, Offset = 888 });

            var serializationStream = new MemoryStream();

            Action action = () => new XmlSerializer(typeof(FileParserException)).Serialize(serializationStream, ex);
            Should.NotThrow(action);
        }
    }
}
