using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class FileParserExceptionTest
    {
        [Test]
        public void Constructor_SetsMessage()
        {
            var ex = new FileParserException("hello!", new FileLocation());

            ex.Message.ShouldBe("hello!");
        }
    }
}
