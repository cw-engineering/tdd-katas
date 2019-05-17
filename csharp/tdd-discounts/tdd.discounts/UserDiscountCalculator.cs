using System;
using System.Collections.Generic;

namespace tdd.discounts
{
    public class UserDiscountCalculator
    {
        private readonly IDictionary<AccountType, decimal> _accountTypeDiscounts = new Dictionary<AccountType, decimal>
        {
            {AccountType.Potato, 0},
            {AccountType.Bronze, 2},
            {AccountType.Silver, 4},
            {AccountType.Gold, 7}
        };


        public decimal CalculateDiscount(decimal originalPrice, User user = null)
        {
            var accountTypeDiscount = user != null ? _accountTypeDiscounts[user.AccountType] : 0;
            var yearlyDiscount = Math.Max(0, Math.Min(5, user?.YearsRegistered ?? 0));

            var totalDiscount = accountTypeDiscount + yearlyDiscount;

            return originalPrice * (100.0m - totalDiscount) / 100.0m;
        }
    }
}
