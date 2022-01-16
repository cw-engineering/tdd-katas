namespace Tdd.Tests;

[TestFixture]
public class WordsTests
{
    [Test]
    public void Count_WhenSentenceIsNull_ShouldReturnZero()
    {
        var result = Words.Count(null);

        result.ShouldBe(0);
    }
}
