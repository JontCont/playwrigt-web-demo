using Dapr;
using Microsoft.AspNetCore.Mvc;
using PlaywrightWebDemo.Shared.Events;

namespace PlaywrightWebDemo.NotificationApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ILogger<NotificationController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// 訂閱 Dapr Pub/Sub Topic: "orders"
    /// 當 order-api 發布 OrderCreatedEvent 時，Dapr Sidecar 會自動呼叫此端點
    /// </summary>
    [Topic("pubsub", "orders")]
    [HttpPost("order-created")]
    public IActionResult HandleOrderCreated([FromBody] OrderCreatedEvent orderEvent)
    {
        _logger.LogInformation(
            "📧 收到訂單通知！OrderId: {OrderId}, Product: {Product}, Qty: {Qty}, Email: {Email}",
            orderEvent.OrderId, orderEvent.ProductName, orderEvent.Quantity, orderEvent.CustomerEmail);

        _logger.LogInformation(
            "🔔 模擬發送通知郵件給 {Email}... 訂單 {OrderId} 已確認",
            orderEvent.CustomerEmail, orderEvent.OrderId);

        // 在真實場景中，這裡可以：
        // - 發送 Email 通知
        // - 發送推播通知
        // - 更新通知紀錄到資料庫
        // - 觸發其他下游工作流程

        return Ok();
    }

    /// <summary>
    /// 快速測試端點
    /// </summary>
    [HttpGet("test")]
    public IActionResult Test()
    {
        _logger.LogInformation("🧪 notification-api 測試端點被呼叫");
        return Ok(new { service = "notification-api", status = "running", timestamp = DateTime.UtcNow });
    }
}
