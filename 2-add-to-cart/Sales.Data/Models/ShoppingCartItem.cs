namespace Sales.Data.Models
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public decimal ProductPrice { get; set; }
        public string RequestId { get; set; }
        public int Quantity { get; set; }
    }
}
