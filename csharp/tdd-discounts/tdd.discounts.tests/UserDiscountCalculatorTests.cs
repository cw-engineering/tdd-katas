using System;
using NUnit.Framework;
using Shouldly;

namespace tdd.discounts.tests
{
    [TestFixture]
    public class UserDiscountCalculatorTests
    {
        [Test]
        public void WhenUserIsNotRegistered_NoDiscount()
        {
            var originalPrice = 100;
            var calculator = new UserDiscountCalculator();

            calculator.CalculateDiscount(originalPrice).ShouldBe(100);
        }
        [Test]
        public void IfPotatoAccount_NoDiscount()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Potato };
            var calculator = new UserDiscountCalculator();

            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(100);
        }

        [Test]
        public void IfBronzeAccount_Discount_2_percent()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Bronze };
            var calculator = new UserDiscountCalculator();

            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(98);
        }

        [Test]
        public void IfSilverAccount_Discount_FourPercent()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Silver };
            var calculator = new UserDiscountCalculator();

            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(96);
        }

        [Test]
        public void IfGoldAccount_Discount_7_Percent()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Gold };
            var calculator = new UserDiscountCalculator();

            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(93);
        }

        [Test]
        public void IfUserIsRegisteredFor2Years_Apply2Percent()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Potato, YearsRegistered = 2 };

            var calculator = new UserDiscountCalculator();
            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(98);
        }

        [Test]
        public void IfBronzeUserIsRegisteredFor5Years_Apply7PercentDiscount()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Bronze, YearsRegistered = 5 };

            var calculator = new UserDiscountCalculator();
            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(93);
        }


        [Test]
        public void IfGoldUserIsRegisteredFor6Years_Apply12PercentDiscount()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Gold, YearsRegistered = 6 };

            var calculator = new UserDiscountCalculator();
            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(88);
        }

        [Test]
        public void IfSilverUserIsRegisteredFor3Years_Apply7PercentDiscount()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Silver, YearsRegistered = 3 };

            var calculator = new UserDiscountCalculator();
            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(93);
        }

        [Test]
        public void IfPotatoUserIsRegisteredFor6Years_No_Discount()
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Potato, YearsRegistered = 6 };

            var calculator = new UserDiscountCalculator();
            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(95);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void IfBronzeUserRegisteredForNYearsUpTo5_ApplyBronzeAndNYearDiscount(int nYears)
        {
            var originalPrice = 100;
            var testUser = new User { AccountType = AccountType.Bronze, YearsRegistered = nYears };
            var expectedPrice = 98 - nYears;

            var calculator = new UserDiscountCalculator();
            calculator.CalculateDiscount(originalPrice, testUser).ShouldBe(expectedPrice);
        }

    }
}
