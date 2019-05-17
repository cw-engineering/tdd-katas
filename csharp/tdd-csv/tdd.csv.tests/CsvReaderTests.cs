using System;
using System.IO;
using NUnit.Framework;
using Shouldly;
using tdd.csv;

namespace tdd.csv.tests
{
    [TestFixture]
    public class CsvReaderTests
    {

        [Test]
        public void Constructor_throws_when_TextWriterIsNull()
        {
            TextReader textReader = null;
            Action action = () => new CsvReader(textReader);
            Should.Throw<ArgumentNullException>(action);
        }

        [Test]
        public void Constructor_does_NOT_throws_when_TextWriterIsNotNull()
        {
            TextReader textReader = new StringReader("");
            Action action = () => new CsvReader(textReader);
            Should.NotThrow(action);
        }

        [Test]
        public void ReadNext_ReturnsNullThirdRecord_WhenOnlyTwoRecordsPresent()
        {
            TextReader textReader = new StringReader("aaa \n aaa");
            CsvReader csvReader = new CsvReader(textReader);
            csvReader.ReadNext();
            csvReader.ReadNext();
            string[] record = csvReader.ReadNext();
            record.ShouldBe(null);

        }

        [Test]
        public void ReadNext_ValidRecordForFirstLine_WhenOneRecordIsPresent()
        {
            TextReader textReader = new StringReader("aaa");
            CsvReader csvReader = new CsvReader(textReader);
            string [] result = csvReader.ReadNext();
            string [] expected = {"aaa"};
            result.ShouldBe(expected);
        }
        [Test]
        public void ReadNext_ReturnsRecordsInCorrectOrderForTwoRecords()
        {
            TextReader textReader = new StringReader("aaa\nbbb");
            var csvReader = new CsvReader(textReader);
            csvReader.ReadNext();
            string[] result = csvReader.ReadNext();
            string[] expected = { "bbb" };
            result.ShouldBe(expected);
        }

        [Test]
        public void ReadNext_ShouldReturnAnEmptyStringOnNewLineEnding()
        {
            TextReader textReader = new StringReader("aaa\n");
            var csvReader = new CsvReader(textReader);
            csvReader.ReadNext();
            string[] result = csvReader.ReadNext();
            string[] expected = { "" };
            result.ShouldBe(expected);
        }

        [Test]
        public void ReadNext_ShouldReturnSeparatedItems_WhenValueSeparatedByCommas()
        {
            TextReader textReader = new StringReader("aaa,bbb,ccc");
            var csvReader = new CsvReader(textReader);
            string[] result = csvReader.ReadNext();
            string[] expected = { "aaa", "bbb", "ccc" };
            result.ShouldBe(expected);
        }

        [Test]
        public void ReadNext_Should_NOT_Remove_Spaces()
        {
            TextReader textReader = new StringReader("aaa , bbb,cc c");
            var csvReader = new CsvReader(textReader);
            string[] result = csvReader.ReadNext();
            string[] expected = { "aaa ", " bbb", "cc c" };
            result.ShouldBe(expected);
        }

        [Test]
        public void ReadNext_Should_Retain_Empty_Strings()
        {
            TextReader textReader = new StringReader(",a,,");
            var csvReader = new CsvReader(textReader);
            string[] result = csvReader.ReadNext();
            string[] expected = { "", "a", "", ""};
            result.ShouldBe(expected);
        }

        [Test]
        public void ReadNext_Should_Remove_Qualifier()
        {
            TextReader textReader = new StringReader("\"zzz\",\"yyy\"");
            var csvReader = new CsvReader(textReader);
            string[] result = csvReader.ReadNext();
            string[] expected = { "zzz", "yyy" };
            result.ShouldBe(expected);
        }
    }
}
