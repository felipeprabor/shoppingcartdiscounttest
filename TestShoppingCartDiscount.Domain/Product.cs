using TestShoppingCartDiscount.Domain.DiscountRules;
using System;

namespace TestShoppingCartDiscount.Domain
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public long Id { get; set; }
        public string Name { get; protected set; }
        public decimal Price { get; protected set; }
        public DiscountRulesEnumeration.DiscountRuleEnum? DiscountRuleEnum { get; set; }
        
    }
}
