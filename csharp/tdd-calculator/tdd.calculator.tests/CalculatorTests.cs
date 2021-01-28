using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Add_ReturnsZero_WhenInputIsNull()
        {
            const string numbers = null;

            var result = Calculator.Add(numbers);

            result.ShouldBe(0);
        }
    }
}
