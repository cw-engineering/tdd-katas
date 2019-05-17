using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace tdd.asyncqueue.tests
{
    [TestFixture]
    public class AsyncQueueTests
    {
        [Test]
        public void EnqueueIncrementsCountByOne()
        {
            var queue = new AsyncQueue<short>();

            queue.Enqueue(1234);

            queue.Count.ShouldBe(1);
        }

        [Test]
        public void EnqueueWithTwoElementsIncrementsCountTwice()
        {
            var queue = new AsyncQueue<short>();

            queue.Enqueue(1234);
            queue.Enqueue(5678);

            queue.Count.ShouldBe(2);
        }

        [Test]
        public async Task Enqueueanddequeuesetscountbackto0Async()
        {
            var queue = new AsyncQueue<short>();

            queue.Enqueue(1234);
            await queue.DequeueAsync();

            queue.Count.ShouldBe(0);
        }

        [Test]
        public async Task ShouldReturnSameElementWhenQueueGotOneElement()
        {
            var queue = new AsyncQueue<int>();

            var itemIn = 1234;
                queue.Enqueue(itemIn);
            var item = await queue.DequeueAsync();

            item.ShouldBe(itemIn);
        }

        [Test]
        public async Task ShouldReturnFirstElementWhenTwoElementsAreAdded()
        {
            var queue = new AsyncQueue<int>();

            queue.Enqueue(1234);
            queue.Enqueue(5678);
            var item = await queue.DequeueAsync();

            item.ShouldBe(1234);
        }

        [Test]
        public async Task DequeueShouldReturnSecondElementWhenCalledTwice()
        {
            var queue = new AsyncQueue<int>();

            queue.Enqueue(1234);
            queue.Enqueue(5678);
            await queue.DequeueAsync();
            var item = await queue.DequeueAsync();

            item.ShouldBe(5678);
        }

        [Test]
        public async Task ShouldLetEnumerateWhileBeingModified()
        {
            var queue = new AsyncQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);

            Action action = () =>
            {
                foreach (var item in queue)
                {
                    queue.Enqueue(3);
                }
            };

            action.ShouldNotThrow();
        }

        [Test]
        public async Task ShouldBeInOrderFromTheLastAdded()
        {
            var queue = new AsyncQueue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            int firstItem = 0;
            foreach( var item in queue)
            {
                firstItem = item;
                break;
            }
            firstItem.ShouldBe(2);
        }

        [Test]
        public void ShouldEnumerateObjects()
        {
            var queue = new AsyncQueue<char>();
            queue.Enqueue('a');
            queue.Enqueue('b');

            Action action = () => ((IEnumerable)queue).GetEnumerator();

            action.ShouldNotThrow();
        }

        [Test]
        public void ShouldNotReturnNull()
        {
            var queue = new AsyncQueue<char>();

            ((IEnumerable)queue).GetEnumerator().ShouldNotBeNull();
        }

        [Test]
        public void ShouldReturnCorrectElementsForEnumerator()
        {
            var queue = new AsyncQueue<char>();
            queue.Enqueue('A');

            var enumerator = ((IEnumerable)queue).GetEnumerator();

            enumerator.MoveNext();
            enumerator.Current.ShouldBe('A');
        }

        [Test]
        public void ShouldReturnCorrectMultipleElementsForEnumerator()
        {
            var queue = new AsyncQueue<char>();
            queue.Enqueue('B');
            queue.Enqueue('C');
            var enumerator = ((IEnumerable)queue).GetEnumerator();

            enumerator.MoveNext();

            enumerator.Current.ShouldBe('C');
        }
        [Test]
        public void ShouldNotReturnCompletedTaskWhenThereIsNothingInTheQUEUE()
        {
            var queue = new AsyncQueue<char>();

            var task = queue.DequeueAsync();
            task.IsCompleted.ShouldBeFalse();
        }
        [Test]
        public async Task ShouldNotReturnCompletedTaskWhenThereIsNoItemInTheQUEUE()
        {
            var queue = new AsyncQueue<char>();

            var task = queue.DequeueAsync();
            await Task.Delay(2000);

            queue.Enqueue('B');

            task.Result.ShouldBe('B');
        }

        [Test]
        public async Task ShouldCancelWaitingWhenThereIsCancellationToken()
        {
            var queue = new AsyncQueue<int>();
            var cancellationToken = new CancellationTokenSource(1000);

            var task = queue.DequeueAsync(cancellationToken.Token);
            await Task.Delay(1500);

            task.IsCanceled.ShouldBeTrue();

        }

        [Test]
        public async Task ShouldCancelWaitingWhenThereIsCancellationTokenWithoutDelay()
        {
            var queue = new AsyncQueue<int>();
            var cancellationToken = new CancellationTokenSource(1000);

            var task = queue.DequeueAsync(cancellationToken.Token);

            await Task.Delay(1500);

            task.IsCanceled.ShouldBeTrue();

        }

        [Test]
        public async Task BothTasksShouldReturnSameValue()
        {
            var queue = new AsyncQueue<int>();
            var task1 = queue.DequeueAsync();
            var task2 = queue.DequeueAsync();

            queue.Enqueue(1);
            await Task.WhenAny(task1, task2);

            task1.IsCompleted.ShouldNotBe(task2.IsCompleted);
        }

    }
}
