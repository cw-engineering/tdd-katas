namespace Tdd.Tests;

[TestFixture]
public class RecentlyUsedListTests
{
    [Test]
    public void Add_WhenFirstItemAdded_ReturnsTheAddedItemId()
    {
        var list = new RecentlyUsedList<int>();

        list.Add("someId", 123);

        list[0].Id.ShouldBe("someId");
    }
}
