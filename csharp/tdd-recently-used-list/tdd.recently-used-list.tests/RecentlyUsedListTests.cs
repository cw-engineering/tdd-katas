using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace tdd.recently_used_list.tests
{
    [TestFixture]
    public class RecentlyUsedListTests
    {
        [Test]
        public void ImplementsIRecentlyUsedInterface()
        {
            var list = new RecentlyUsedList<int>();

            var iList = list as IRecentlyUsedList<int>;

            iList.ShouldNotBeNull();
        }

        [Test]
        public void ListReturnsFirstAddedItem()
        {
            var list = new RecentlyUsedList<int>();
            list.Add("a", 1);

            list.First().value.ShouldBe(1);
        }

        [Test]
        public void ListReturnsLastItemEntered()
        {
            var list = new RecentlyUsedList<int>();
            list.Add("a", 1);
            list.Add("b", 2);

            list.First().value.ShouldBe(2);
        }

        [Test]
        public void ListCountMethodShouldReturnOneWhenTwoDuplicatesAdded()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);
            list.Add("A", 1);

            list.Count().ShouldBe(1);
        }

        [Test]
        public void ListCountPropertyShouldReturnNumberOfItemsInList()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);
            list.Add("b", 1);

            list.Count.ShouldBe(2);
        }

        [Test]
        public void ListReturnsCaseSensitiveDuplicateFirst()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);
            list.Add("A", 1);

            list.First().id.ShouldBe("A");
        }

        [Test]
        public void ListShouldThrowAnExceptionWhenIdIsNull()
        {
            var list = new RecentlyUsedList<int>();

            Should.Throw<ArgumentException>(() => list.Add(null, 1));
        }

        [Test]
        public void ListShouldThrowAnExceptionWhenIdIsEmpty()
        {
            var list = new RecentlyUsedList<int>();

            Should.Throw<ArgumentException>(() => list.Add("", 1));
        }

        [Test]
        public void ListShouldNotHoldMoreItemsThenCapacity()
        {
            var list = new RecentlyUsedList<int>(capacity: 1);

            list.Add("a", 1);
            list.Add("A", 1);

            list.Count.ShouldBe(1);
        }

        [Test]
        public void ListShouldNotAddMoreThanSetCapacity()
        {
            var list = new RecentlyUsedList<int>(capacity: 1);

            list.Add("a", 1);
            list.Add("b", 1);

            list.Count().ShouldBe(1);
        }

        [Test]
        public void ListShouldNotAddMoreThanSetCapacity2()
        {
            var list = new RecentlyUsedList<int>(capacity: 2);

            list.Add("a", 1);
            list.Add("b", 1);
            list.Add("c", 1);
            list.Add("d", 1);

            list.Count().ShouldBe(2);
        }

        [Test]
        public void ListAsIEnumerableCanEnumerate()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);

            ((IEnumerable)list).GetEnumerator().ShouldNotBeNull();
        }

        [Test]
        public void Index0ShouldReturnLastAddedItem()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);
            list.Add("b", 1);

            list[0].ShouldBe(("b", 1));
        }

        [Test]
        public void Index1ShouldReturnSecondLastAddedItem()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);
            list.Add("b", 1);
            list.Add("c", 1);

            list[1].ShouldBe(("b", 1));
        }

        [Test]
        public void InvalidIndexShouldThrowException()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1);
            list.Add("b", 1);
            list.Add("c", 1);

            Action action = () =>
            {
                var x = list[-1];
            };

            action.ShouldThrow<IndexOutOfRangeException>();
        }

        [Test]
        public void ListCapacityReturnsDefinedCapacity()
        {
            var list = new RecentlyUsedList<int>(500);

            list.Capacity.ShouldBe(500);

        }

        [Test]
        public void ListCapacityReturnsOtherDefinedCapacity()
        {
            var list = new RecentlyUsedList<int>(235);

            list.Capacity.ShouldBe(235);
        }

        [Test]
        public void CanAddExpirationDateToItemInList()
        {
            var list = new RecentlyUsedList<int>();

            Action action = () =>
            {
                list.Add("a", 1, TimeSpan.FromSeconds(1));
            };

            action.ShouldNotThrow();
        }

        [Test]
        public void ListReturnsItemAddedUsingExpirationPeriodMethod()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("a", 1, TimeSpan.FromSeconds(1));

            list.First().ShouldBe(("a", 1));
        }

        [Test]
        public void ListReturns0CountWhenSingleItemExpires()
        {
            var list = new RecentlyUsedList<int>();
            Random rnd = new Random();
            int myTimeSeed = rnd.Next(50, 100);

            list.Add("a", 1, TimeSpan.FromMilliseconds(myTimeSeed));
            System.Threading.Thread.Sleep(200);

            list.Count.ShouldBe(0);
        }

        [Test]
        public void ListReturnsItemWithExpirationPeriod()
        {
            var list = new RecentlyUsedList<int>();
            Random rnd = new Random();
            int myTimeSeed = rnd.Next(50, 100);

            list.Add("a", 1, TimeSpan.FromMilliseconds(myTimeSeed));
            System.Threading.Thread.Sleep(200);

            list.Count().ShouldBe(0);
        }
    }
}
