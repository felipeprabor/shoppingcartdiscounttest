using TestShoppingCartDiscount.Domain;
using TestShoppingCartDiscount.Domain.DiscountRules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace TestShoppingCartDiscount.UnitTests
{
    [TestClass]
    public class ShoppingCartTests
    {
        private Product _productA;
        private Product _productB;
        private Product _productC;
        private ShoppingCart _cart;

        private void BuildInitialScenario()
        {
            _productA = new Product("A", 20);
            _productB = new Product("B", 4);
            _productC = new Product("C", 2);

            _productA.DiscountRuleEnum = DiscountRulesEnumeration.BuyOneGetOneFree.EnumValue;
            _productB.DiscountRuleEnum = DiscountRulesEnumeration.BuyThreeFor10Euro.EnumValue;

            _cart = new ShoppingCart();
            var itemA = new ShoppingCartItem() { Id = 1 };
            itemA.SetProduct(_productA);            
            _cart.AddNewItem(itemA);

            var itemB = new ShoppingCartItem() { Id = 2 };
            itemB.SetProduct(_productB);
            _cart.AddNewItem(itemB);

            var itemC = new ShoppingCartItem() { Id = 3 };
            itemC.SetProduct(_productC);
            _cart.AddNewItem(itemC);
        }

        [TestMethod]
        public void AddThreeProductsToCartNoDiscountApplied()
        {
            BuildInitialScenario();
            
            Assert.AreEqual(20, _cart.Items.FirstOrDefault(x => x.Id == 1).Price);
            Assert.AreEqual(4, _cart.Items.FirstOrDefault(x => x.Id == 2).Price);
            Assert.AreEqual(2, _cart.Items.FirstOrDefault(x => x.Id == 3).Price);

            Assert.AreEqual(26, _cart.Total);
        }

        [TestMethod]
        public void Should_apply_discount_product_A_and_B()
        {
            BuildInitialScenario();
            
            var itemA = _cart.Items.FirstOrDefault(x => x.Id == 1);
            _cart.ChangeQuantityItem(itemA, 2);

            var itemB = _cart.Items.FirstOrDefault(x => x.Id == 2);
            _cart.ChangeQuantityItem(itemB, 3);

            var itemC = _cart.Items.FirstOrDefault(x => x.Id == 3);
            _cart.ChangeQuantityItem(itemC, 5);
            
            Assert.AreEqual(20, itemA.Price);
            Assert.AreEqual(10, itemB.Price);
            Assert.AreEqual(10, itemC.Price);

            Assert.AreEqual(40, _cart.Total);
        }

        [TestMethod]
        public void Should_apply_discount_product_A_and_B_and_new_discount_Product_C()
        {
            BuildInitialScenario();

            _productC.DiscountRuleEnum = DiscountRulesEnumeration.DiscountRuleEnum.DiscountOf10Percent;

            var itemA = _cart.Items.FirstOrDefault(x => x.Id == 1);
            _cart.ChangeQuantityItem(itemA, 2);

            var itemB = _cart.Items.FirstOrDefault(x => x.Id == 2);
            _cart.ChangeQuantityItem(itemB, 3);

            var itemC = _cart.Items.FirstOrDefault(x => x.Id == 3);
            _cart.ChangeQuantityItem(itemC, 5);

            Assert.AreEqual(20, itemA.Price);
            Assert.AreEqual(10, itemB.Price);
            Assert.AreEqual(9, itemC.Price);

            Assert.AreEqual(39, _cart.Total);
        }
    }
}
