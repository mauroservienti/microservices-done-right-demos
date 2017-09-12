namespace Sales.Messages.Events
{
    public interface CartGotStale
    {
        int CartId { get; set; }
    }
}
