using TestShoppingCartDiscount.Domain.DiscountRules;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestShoppingCartDiscount.Domain
{
    public class ShoppingCartItem
    {
        public long Id { get; set; }
        public int Quantity { get; protected set; }
        public decimal Price { get; protected set; }
        public long ProductId { get; set; }
        public Product Product { get; protected set; }

        public void SetProduct(Product product)
        {
            Product = product;
            Price = Product.Price;
            Quantity = 1;
        }

        internal void ChangeQuantity(int quantity)
        {
            Quantity = quantity;

            if (Product.DiscountRuleEnum.HasValue)
            {
                Price = DiscountRulesEnumeration.FromEnum(Product.DiscountRuleEnum.Value).DiscountRule.CalculateDiscount(Product.Price, Quantity);
            }
            else
            {
                Price = Product.Price * quantity;
            }
        }

    }
}
