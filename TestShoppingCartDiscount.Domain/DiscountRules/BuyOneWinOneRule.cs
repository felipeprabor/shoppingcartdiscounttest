using TestShoppingCartDiscount.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestShoppingCartDiscount.Domain.DiscountRules
{
    public class BuyOneWinOneRule : IDiscountRule
    {
        public decimal CalculateDiscount(decimal unitPrice, int quantity)
        {
            decimal finalPrice = 0;
            for (int i = 1; i <= quantity; i++)
            {
                if (i % 2 > 0)
                    finalPrice += unitPrice;
            }

            return finalPrice;
        }
    }
}
