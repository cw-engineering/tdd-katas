using NUnit.Framework;
using Shouldly;

namespace Tdd.Collections.Tests
{
    [TestFixture]
    public class RecentlyUsedListTests
    {
        [Test]
        public void RecentlyUsedList_ImplementsIRecentlyUsedListInterface()
        {
            var list = new RecentlyUsedList<int>();

            var iList = list as IRecentlyUsedList<int>;

            iList.ShouldNotBeNull();
        }

        [Test]
        public void Add_WhenCalledOnce_ShouldReturnAddedItem()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);

            list[0].Value.ShouldBe(123);
        }

        [Test]       
        public void Add_WhenCalledTwiceWithDifferentValues_ShouldContainTwoItems()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);
            list.Add("secondId", 123);

            list.Count.ShouldBe(2);
        }

        [Test]
        public void Add_WhenCalledThreeTimesWithDifferentValues_ShouldContainThreeItems()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);
            list.Add("secondId", 123);
            list.Add("threeId", 123);

            list.Count.ShouldBe(3);
        }

        [Test]
        public void Add_WhenCalledTwiceWithSameValues_ShouldOnlyAddOne()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);
            list.Add("someId", 123);

            list.Count.ShouldBe(1);
        }

        [Test]
        public void Add_WhenCalledTwiceWithTheSameId_ShoudContainSecondItem()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);
            list.Add("someId", 124);

            list[0].ShouldBe(("someId", 124));
        }

        [Test]
        public void Add_WhenItemAdded_ShouldReturnItFirst()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);
            list.Add("someId2", 124);

            list[0].ShouldBe(("someId2", 124));
        }
    }
}
