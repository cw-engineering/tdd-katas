using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    public class HeadersTests
    {
        [Test]
        public void IndexerGet_ReturnsValueSetThroughIndexerSet()
        {
            var headers = new Headers();
            headers["Accept"] = "test";

            var acceptHeader = headers["Accept"];
            acceptHeader.ShouldBe("test");
        }
    }
}