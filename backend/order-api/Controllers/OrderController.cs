using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using PlaywrightWebDemo.Shared.Events;

namespace PlaywrightWebDemo.OrderApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly DaprClient _daprClient;
    private readonly ILogger<OrderController> _logger;

    private const string PubSubName = "pubsub";
    private const string TopicName = "orders";

    public OrderController(DaprClient daprClient, ILogger<OrderController> logger)
    {
        _daprClient = daprClient;
        _logger = logger;
    }

    /// <summary>
    /// 建立訂單並發布事件到 Dapr Pub/Sub Topic
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        var orderEvent = new OrderCreatedEvent
        {
            OrderId = Guid.NewGuid().ToString("N")[..8],
            ProductName = request.ProductName,
            Quantity = request.Quantity,
            CustomerEmail = request.CustomerEmail,
            CreatedAt = DateTime.UtcNow
        };

        _logger.LogInformation(
            "📦 發布訂單事件 → Topic: {Topic}, OrderId: {OrderId}, Product: {Product}, Qty: {Qty}",
            TopicName, orderEvent.OrderId, orderEvent.ProductName, orderEvent.Quantity);

        // 透過 Dapr Sidecar 發布到 Redis Pub/Sub
        await _daprClient.PublishEventAsync(PubSubName, TopicName, orderEvent);

        _logger.LogInformation("✅ 訂單事件已成功發布！OrderId: {OrderId}", orderEvent.OrderId);

        return Ok(new
        {
            message = "訂單已建立，事件已發布",
            orderId = orderEvent.OrderId,
            topic = TopicName,
            publishedAt = orderEvent.CreatedAt
        });
    }

    /// <summary>
    /// 快速測試端點
    /// </summary>
    [HttpGet("test")]
    public IActionResult Test()
    {
        _logger.LogInformation("🧪 order-api 測試端點被呼叫");
        return Ok(new { service = "order-api", status = "running", timestamp = DateTime.UtcNow });
    }
}

public class CreateOrderRequest
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public string CustomerEmail { get; set; } = string.Empty;
}
