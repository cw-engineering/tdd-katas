namespace Tdd.Tests;

[TestFixture]
public class LinePositionTests
{
    [Test]
    public void LinePosition_IsStruct()
    {
        typeof(LinePosition).IsValueType.ShouldBeTrue();
    }
}