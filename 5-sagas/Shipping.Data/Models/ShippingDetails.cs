namespace Shipping.Data.Models
{
    public class ShippingDetails
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal Cost { get; set; }

        public bool FreeShippingEligible { get; set; }
    }
}
