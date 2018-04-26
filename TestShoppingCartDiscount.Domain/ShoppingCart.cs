using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestShoppingCartDiscount.Domain
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Items = new List<ShoppingCartItem>();
        }
        public long Id { get; set; }
        public List<ShoppingCartItem> Items { get; protected set; }

        public decimal Total { get; set; }
        public void AddNewItem(ShoppingCartItem item)
        {
            Items.Add(item);
            UpdateTotal();
        }

        public void ChangeQuantityItem(ShoppingCartItem item, int quantity)
        {
            Items.FirstOrDefault(x => x.Id == item.Id).ChangeQuantity(quantity);
            UpdateTotal();
        }

        private void UpdateTotal()
        {
            Total = Items.Sum(x => x.Price);
        }
    }
}
