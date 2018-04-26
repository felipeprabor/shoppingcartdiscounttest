using TestShoppingCartDiscount.Domain;
using TestShoppingCartDiscount.Domain.DiscountRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestShoppingCartDiscount.UnitTests
{
    [TestClass]
    public class DiscountRulesTest
    {
        [TestMethod]
        public void BuyOneGetOneFree_should_not_apply_the_discount()
        {
            decimal unitPrice = 20;
            int quantity = 1;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyOneGetOneFree);

            Assert.AreEqual("Buy 1 Get 1 Free", DiscountRulesEnumeration.BuyOneGetOneFree.DisplayName);
            Assert.AreEqual(20, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void BuyOneGetOneFree_should_apply_discount()
        {
            decimal unitPrice = 20;
            int quantity = 2;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyOneGetOneFree);

            Assert.AreEqual("Buy 1 Get 1 Free", DiscountRulesEnumeration.BuyOneGetOneFree.DisplayName);
            Assert.AreEqual(20, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void BuyOneGetOneFree_should_apply_discount_once()
        {
            decimal unitPrice = 20;
            int quantity = 3;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyOneGetOneFree);

            Assert.AreEqual("Buy 1 Get 1 Free", DiscountRulesEnumeration.BuyOneGetOneFree.DisplayName);
            Assert.AreEqual(40, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void BuyOneGetOneFree_should_apply_discount_twice()
        {
            decimal unitPrice = 20;
            int quantity = 4;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyOneGetOneFree);

            Assert.AreEqual("Buy 1 Get 1 Free", DiscountRulesEnumeration.BuyOneGetOneFree.DisplayName);
            Assert.AreEqual(40, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void BuyOneGetOneFree_should_apply_discount_three_times()
        {
            decimal unitPrice = 20;
            int quantity = 6;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyOneGetOneFree);

            Assert.AreEqual("Buy 1 Get 1 Free", DiscountRulesEnumeration.BuyOneGetOneFree.DisplayName);
            Assert.AreEqual(60, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void BuyThreeFor10Euro_should_not_apply_discount()
        {
            decimal unitPrice = 4;
            int quantity = 2;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyThreeFor10Euro);
            Assert.AreEqual("3 for 10 Euro", DiscountRulesEnumeration.BuyThreeFor10Euro.DisplayName);
            Assert.AreEqual(8, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void BuyThreeFor10Euro_should_apply_discount_once()
        {
            decimal unitPrice = 4;
            int quantity = 3;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyThreeFor10Euro);
            Assert.AreEqual("3 for 10 Euro", DiscountRulesEnumeration.BuyThreeFor10Euro.DisplayName);
            Assert.AreEqual(10, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }
        [TestMethod]
        public void BuyThreeFor10Euro_should_apply_discount_twice()
        {
            decimal unitPrice = 4;
            int quantity = 8;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.BuyThreeFor10Euro);
            Assert.AreEqual("3 for 10 Euro", DiscountRulesEnumeration.BuyThreeFor10Euro.DisplayName);
            Assert.AreEqual(28, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }

        [TestMethod]
        public void DiscountOf10Percent()
        {
            decimal unitPrice = 20;
            int quantity = 1;
            var rules = DiscountRulesEnumeration.FromEnum(DiscountRulesEnumeration.DiscountRuleEnum.DiscountOf10Percent);
            Assert.AreEqual("10% off", DiscountRulesEnumeration.DiscountOf10Percent.DisplayName);
            Assert.AreEqual(18, rules.DiscountRule.CalculateDiscount(unitPrice, quantity));
        }
    }
}
