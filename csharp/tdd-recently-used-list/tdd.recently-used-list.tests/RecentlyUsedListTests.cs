using System;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Collections.Tests
{
    [TestFixture]
    public class RecentlyUsedListTests
    {
        [Test]
        public void Add_WhenFirstItemAdded_ShouldReturnTheAddedItemId()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);

            list[0].Id.ShouldBe("someId");
        }

        [Test]
        public void Add_WhenFirstItemAdded_ShouldReturnTheAddedItemValue()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("someId", 123);

            list[0].Value.ShouldBe(123);
        }

        [TestCase("someId", "someId")]
        [TestCase("someId", "SOMEiD")]
        public void Add_TwoItemsSameId_ShouldReturnOneItem(string id1, string id2)
        {
            var list = new RecentlyUsedList<int>();

            list.Add(id1, 123);
            list.Add(id2, 456);

            list.Count.ShouldBe(1);
        }

        [TestCase(5)]
        [TestCase(3)]
        public void SetCapacity_WhenSet_ShouldAllowTheListToHoldNoMoreThanSetValue(int capacity)
        {
            var list = new RecentlyUsedList<int>(capacity: capacity);

            list.Capacity.ShouldBe(capacity);
        }

        [Test]
        public void Count_WhenCapacityOne_ShouldNotAllowMoreThanOneItem()
        {
            var list = new RecentlyUsedList<int>(capacity: 1);
            list.Add("someId1", 123);
            list.Add("someId2", 456);

            list.Count.ShouldBe(1);
        }

        [Test]
        public void Count_WhenCapacityTwo_ShouldNotAllowMoreThanTwoItems()
        {
            var list = new RecentlyUsedList<int>(capacity: 2);
            list.Add("someId1", 123);
            list.Add("someId2", 456);
            list.Add("someId3", 789);

            list.Count.ShouldBe(2);
        }

        [Test]
        public void Add_WhenIDNull_ShouldThrowException()
        {
            var list = new RecentlyUsedList<int>();

            Action action = () =>
            {
                list.Add(null, 123);
            };

            action.ShouldThrow<ArgumentNullException>();
        }

        [Test]
        public void Add_WhenIDIsEmpty_ShouldThrowException()
        {
            var list = new RecentlyUsedList<int>();

            Action action = () =>
            {
                list.Add("", 123);
            };

            action.ShouldThrow<ArgumentOutOfRangeException>();
        }

        [Test]
        public void Add_LastAddedItem_ShouldBeFirst()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("firstId", 123);
            list.Add("secondId", 456);

            list[0].Id.ShouldBe("secondId");
            list[0].Value.ShouldBe(456);
        }

        [Test]
        public void Add_TwoItemsSameId_ShouldReturnLastItem()
        {
            var list = new RecentlyUsedList<int>();

            list.Add("id", 123);
            list.Add("id", 456);

            list[0].Value.ShouldBe(456);
        }
    }
}
