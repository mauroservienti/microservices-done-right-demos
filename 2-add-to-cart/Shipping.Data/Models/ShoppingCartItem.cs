namespace Shipping.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; }

        public int ProductId { get; set; }

        public decimal ShippingCost { get; set; }
        public bool FreeShippingEligible { get; set; }
    }
}
