using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.Seq(Environment.GetEnvironmentVariable("SEQ_URL") ?? "http://localhost:5341")
    .Enrich.WithProperty("ServiceName", "order-api")
    .CreateLogger();

try
{
    Log.Information("🚀 order-api 啟動中...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog();

    // Dapr
    builder.Services.AddDaprClient();
    builder.Services.AddControllers().AddDapr();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });

    var app = builder.Build();

    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseCors("AllowAll");

    // Dapr Pub/Sub 需要的中間件
    app.UseCloudEvents();
    app.MapSubscribeHandler(); // Dapr 會呼叫 /dapr/subscribe 取得訂閱清單

    app.MapControllers();

    app.MapGet("/ping", () => "pong from order-api");

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "❌ order-api 啟動失敗");
}
finally
{
    Log.CloseAndFlush();
}
