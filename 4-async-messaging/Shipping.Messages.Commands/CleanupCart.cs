namespace Shipping.Messages.Commands
{
    public class CleanupCart
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}
