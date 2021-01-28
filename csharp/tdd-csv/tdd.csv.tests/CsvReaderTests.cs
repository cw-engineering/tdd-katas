using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class CsvReaderTests
    {

        [Test]
        public void Constructor_Throws_WhenTextWriterNull()
        {
            TextReader textReader = null;

            Action action = () => new CsvReader(textReader);

            action.ShouldThrow<ArgumentNullException>()
              .ParamName.ShouldBe("textReader");
        }
    }
}
