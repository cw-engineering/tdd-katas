using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class AsyncQueueTests
    {
        [Test]
        public void AsyncQueue_ImplementsIAsyncQueue()
        {
            var queue = new AsyncQueue<short>();

            queue.ShouldBeOfType<IAsyncQueue<short>>();
        }
    }
}
