using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
