namespace Shipping.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public bool FreeShippingEligible { get; set; }
        public string RequestId { get; set; }
        public decimal ItemShippingCost { get; set; }
    }
}
