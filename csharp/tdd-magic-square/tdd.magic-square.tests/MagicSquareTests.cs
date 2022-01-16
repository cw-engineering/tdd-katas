namespace Tdd.Tests;

[TestFixture]
public class MagicSquareTests
{
    [Test]
    public void IsValid_ThrowsException_WhenInputNull()
    {
        Should.Throw<ArgumentNullException>(() => MagicSquare.IsValid(null));
    }
}
