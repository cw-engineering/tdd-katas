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

    }
}
