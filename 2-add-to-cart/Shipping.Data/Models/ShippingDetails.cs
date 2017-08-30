namespace Shipping.Data.Models
{
    public class ShippingDetails
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Price{ get; set; }

        public bool EligibleForFreeShipping { get; set; }
    }
}
