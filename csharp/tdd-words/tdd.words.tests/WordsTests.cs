using System;
using NUnit.Framework;
using Shouldly;

namespace tdd.words.tests
{
    [TestFixture]
    public class WordsTests
    {
        [Test]
        public void Count_WhenSentenceIsNull_ShouldReturnZero()
        {
            var result = Words.Count(null);

            result.ShouldBe(0);
        }

        [Test]
        public void Count_WhenSentenceIsWhitespaces_ShouldReturnZero()
        {
            var result = Words.Count(" ");

            result.ShouldBe(0);
        }

        [Test]
        public void Count_WhenSentenceContainsSingleWord_ShouldReturn1()
        {
            //arrange
            var input = "asd";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(1);
        }

        [Test]
        public void Count_WhenSentenceContainsTwoWords_ShouldReturnTwo()
        {
            //arrange
            var input = "hello world";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(2);
        }

        [Test]
        public void Count_WhenSentenceContainsOneWordSurroundedBySpaces_ShouldReturn()
        {
            //arrange
            var input = " world ";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(1);
        }

        [Test]
        public void Count_WhenSentenceContainsAnyNumberWhitespaces_ShouldUseThemAsSeparator()
        {
            //arrange
            var input = "Hello\n   \r\nworld";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(2);
        }

        [Test]
        public void Count_WhenSentenceContainsRepeatedWords_ShouldCountOnlyDistinctWords()
        {
            //arrange
            var input = "Hello\n   \r\nworld \n\n world world";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(2);
        }

        [Test]
        public void Count_WhenSentenceContainsRepeatedWords_ShouldCountOnlyDistinctWordsCaseInsesnitively()
        {
            //arrange
            var input = "Hello\n   \r\nworld \n\n World world";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(2);
        }

        [Test]
        public void Count_WhenSentenceContainsPunctuation_ShouldIgnore()
        {
            //arrange
            var input = "Hello - . , & world";

            //act
            var result = Words.Count(input);

            //assert
            result.ShouldBe(2);
        }

        [Test]
        [TestCase("Blah")]
        public void Count_ShouldIgnoreAccents()
        {
            var input = "Allô? Allo est la fin.";

            var result = Words.Count(input);

            result.ShouldBe(4);
        }
    }
}
