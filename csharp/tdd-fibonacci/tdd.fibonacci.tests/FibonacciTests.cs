using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class FibonacciTests
    {
        [Test]
        public void GetFibonacci_ReturnsZero_WhenValueIsZero()
        {
            ulong result = Fibonacci.GetFibonacci(0);

            result.ShouldBe((ulong)0);
        }
    }
}
