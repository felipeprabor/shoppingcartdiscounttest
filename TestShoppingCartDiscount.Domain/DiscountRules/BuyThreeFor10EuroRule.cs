using TestShoppingCartDiscount.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestShoppingCartDiscount.Domain.DiscountRules
{
    public class BuyThreeFor10EuroRule : IDiscountRule
    {
        public decimal CalculateDiscount(decimal unitPrice, int quantity)
        {
            int countThree = quantity / 3; 
            int mod = quantity % 3;
            decimal finalPrice = 0;
            if(countThree > 0)
            {
                finalPrice = countThree * 10;
            }
            finalPrice += mod * unitPrice;

            return finalPrice;
        }
    }
}
