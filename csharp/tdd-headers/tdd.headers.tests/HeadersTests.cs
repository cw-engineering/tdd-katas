using System;
using NUnit.Framework;
using Shouldly;

namespace tdd.headers.tests
{
    public class HeadersTests
    {
        [Test]
        [TestCase("text/html")]
        [TestCase("application/json")]
        public void IndexerGet_returnsSetValues(string value)
        {
            var headers = new Headers();
            headers["Accept"] = value;
            var acceptHeader = headers["Accept"];
            acceptHeader.ShouldBe(value);
        }

        [Test]
        public void IndexerGet_ReturnsNull_WhenHeadersAreNotSet()
        {
            var headers = new Headers();

            headers["Accept"].ShouldBe(null);
        }

        [Test]
        public void IndexerGet_ReturnsValue_WhenOtherKeysAreSet()
        {
            var headers = new Headers();

            headers["Accept"] = "application/json";
            headers["SomethingElse"] = "something";

            headers["Accept"].ShouldBe("application/json");
        }

        [Test]
        public void Indexer_ClearsHeader_WhenNullPassed()
        {
            var headers = new Headers();
            headers["ETag"] = "1234";
            headers["ETag"] = null;

            headers["ETag"].ShouldBeNull();
        }

        [Test]
        public void Indexer_ReturnsValue_WhenFieldIsCaseInsensitive()
        {
            var headers = new Headers();
            headers["ETag"] = "headerValue";

            headers["eTag"].ShouldBe("headerValue");
        }

        [Test]
        public void Indexer_ClearingHeaderIsCaseInsensitive()
        {
            var headers = new Headers();
            headers["ETag"] = "headerValue";
            headers["eTag"] = null;

            headers["ETag"].ShouldBe(null);
        }

        [Test]
        public void Indexer_KeyCannotBeNull()
        {
            var headers = new Headers();

            Should.Throw<ArgumentNullException>(() => headers[null] = "headerValue");
        }

        [Test]
        [TestCase(arguments: new object[] { "a", "b" })]
        [TestCase(arguments: new object[] { "a" })]
        public void Indexer_PropertyCount_ReturnsCorrectNumber(object[] keys)
        {
            var headers = new Headers();
            foreach (var k in keys)
            {
                var key = (string)k;
                headers[key] = key;
            }

            headers.Count.ShouldBe(keys.Length);
        }

        [Test]
        public void Add_AddsNewHeader()
        {
            var headers = new Headers();

            headers.Add("Ondrej", "Fix it");

            headers.Count.ShouldBe(1);
        }

        [Test]
        public void Add_AddedHeaderIsAvailableViaIndexer()
        {
            var headers = new Headers();

            headers.Add("X-Option", "32");

            headers["X-Option"].ShouldBe("32");
        }

        [Test]
        public void Add_AddedHeader_CannotBeNull()
        {
            var headers = new Headers();

            Action action = () => headers.Add(null, "32");

            Should.Throw<ArgumentNullException>(action);

        }

        [Test]
        public void Add_AddedValue_CannotBeNull()
        {
            var headers = new Headers();

            Action action = () => headers.Add("X-Header", null);

            Should.Throw<ArgumentNullException>(action);

        }
    }
}