using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using TestShoppingCartDiscount.Domain.Rules;
using TestShoppingCartDiscount.Framework;

namespace TestShoppingCartDiscount.Domain.DiscountRules
{
    /// <summary>
    /// To create a new promotion should create a new Enum with a new static property with a new construction and a new file to implement the Rule to apply the discount.
    /// Example: New discount of 20%.
    /// 1) Add a new enum : Discount20Percent = 4
    /// 2) Static property with a constructor with the details of the new promotion
    /// public static DiscountRulesEnumeration DiscountOf20Percent = new DiscountRulesEnumeration(DiscountRuleEnum.DiscountOf20Percent, "20% off", typeof(DiscountOf20PercentRule));
    /// 3) Create a new class "DiscountOf20PercentRule" implementing the IDiscountRule.
    /// </summary>
    public class DiscountRulesEnumeration : Enumeration<DiscountRulesEnumeration>
    {
        public enum DiscountRuleEnum
        {
            BuyOneGetOneFree = 1,
            BuyThreeFor10Euro = 2,
            DiscountOf10Percent = 3
        }
        public static DiscountRulesEnumeration BuyOneGetOneFree = new DiscountRulesEnumeration(DiscountRuleEnum.BuyOneGetOneFree, "Buy 1 Get 1 Free", typeof(BuyOneWinOneRule));
        public static DiscountRulesEnumeration BuyThreeFor10Euro = new DiscountRulesEnumeration(DiscountRuleEnum.BuyThreeFor10Euro, "3 for 10 Euro", typeof(BuyThreeFor10EuroRule));
        public static DiscountRulesEnumeration DiscountOf10Percent = new DiscountRulesEnumeration(DiscountRuleEnum.DiscountOf10Percent, "10% off", typeof(DiscountOf10PercentRule));

        public DiscountRuleEnum EnumValue { get; }

        public IDiscountRule DiscountRule { get; } 

        public DiscountRulesEnumeration(DiscountRuleEnum value, string displayName, Type type) : base((int)value, displayName)
        {
            EnumValue = value;
            DiscountRule = (IDiscountRule)Activator.CreateInstance(type);
        }

        public static DiscountRulesEnumeration FromEnum(DiscountRuleEnum @enum)
        {
            return FromValue((int)@enum);
        }
    }
}
