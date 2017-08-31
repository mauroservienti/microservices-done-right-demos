using System.Collections.Generic;

namespace Sales.ViewModelComposition.Events
{
    public class ShoppingCartItemsLoaded
    {
        public long CartId { get; set; }
        public IDictionary<dynamic, dynamic> CartItemsViewModel { get; set; }
    }
}
