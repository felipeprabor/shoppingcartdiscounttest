using TestShoppingCartDiscount.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestShoppingCartDiscount.Domain.DiscountRules
{
    public class DiscountOf20PercentRule : IDiscountRule
    {
        private decimal percent = 20;
        public decimal CalculateDiscount(decimal unitPrice, int quantity)
        {
            return Math.Round((unitPrice * quantity) * (1 - (percent / 100)), 2);
        }
    }
}
