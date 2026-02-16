namespace PlaywrightWebDemo.Shared.Events;

public class OrderCreatedEvent
{
    public string OrderId { get; set; } = string.Empty;
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
