namespace Sales.Messages.Commands
{
    public class CleanupCart
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
        public string RequestId { get; set; }
    }
}
