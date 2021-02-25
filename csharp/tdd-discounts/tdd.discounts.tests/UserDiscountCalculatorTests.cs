using System;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Tests
{
    [TestFixture]
    public class UserDiscountCalculatorTests
    {
        [Test]
        public void CalculateDiscount_ReturnsOriginalPrice_WhenUserNotRegistered()
        {
            var originalPrice = 100;
            var calculator = new UserDiscountCalculator();

            var result = calculator.CalculateDiscount(originalPrice, user: null);
            
            result.ShouldBe(originalPrice);
        }
    }
}
