using System.Collections.Generic;

namespace Sales.Data.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItem>();
        }
        
        public int Id { get; set; }

        public ICollection<ShoppingCartItem> Items { get; set; }
    }
}
