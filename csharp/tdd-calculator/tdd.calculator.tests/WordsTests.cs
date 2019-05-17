using NUnit.Framework;
using Shouldly;

namespace tdd.calculator.tests
{
    [TestFixture]
    public class WordsTests
    {
        [Test]
        public void Count_WhenInputNull_ReturnsZero()
        {
            var result = Words.Count(null);
            result.ShouldBe(0);
        }

        [Test]
        public void Count_WhenInputWhitespaces_ShouldReturnZero()
        {
            var result = Words.Count("   \r\n  \n\t");
            result.ShouldBe(0);
        }

        [Test]
        public void Count_SingleWord_ReturnsOne()
        {
            var result = Words.Count("Hello");
            result.ShouldBe(1);
        }

        [Test]
        public void Count_TwoWordsSeparatedBySpace_ReturnTwo()
        {
            var result = Words.Count("Hello world");
            result.ShouldBe(2);
        }

        [Test]
        public void Count_SingleWordSurroundedBySpaces_ReturnsOne()
        {
            var result = Words.Count("  \nHello  \r ");
            result.ShouldBe(1);
        }

        [Test]
        public void Count_ThreeWordsSeparatedByAnyNumberOfWhitespaces_ReturnThree()
        {
            var result = Words.Count("Hello  crazy \n  world");
            result.ShouldBe(3);
        }

        [Test]
        public void Count_UniqueWords_ReturnsCountOfUniqueWords()
        {
            var result = Words.Count("Hello world in world");
            result.ShouldBe(3);
        }

        [Test]
        public void Count_ShouldBeCaseInSensitive()
        {
            var result = Words.Count("Hello world hello");
            result.ShouldBe(2);
        }

        [Test]
        public void Count_ShouldIgnoreTrailingPeriod()
        {
            var result = Words.Count("Hello world hello.");
            result.ShouldBe(2);
        }

        [Test]
        public void Count_ShouldIgnoreCommasAndDashes()
        {
            var result = Words.Count("Hello, world - hello.");
            result.ShouldBe(2);
        }
    }
}
