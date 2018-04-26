using System;
using System.Collections.Generic;
using System.Text;

namespace TestShoppingCartDiscount.Domain.Rules
{
    public interface IDiscountRule
    {
        decimal CalculateDiscount(decimal unitPrice, int quantity);
    }
}
