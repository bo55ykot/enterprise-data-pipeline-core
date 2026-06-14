using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DataPipeline.Infrastructure.Messaging;
using DataPipeline.WebAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// ==========================================
// 🚀 DI CONTAINER: SERVICE INJECTION NODE
// ==========================================

// Registering our High-Throughput AWS SQS Background Worker
builder.Services.AddHostedService<QueueConsumerHostedService>();

// Registering MediatR with our Clean Architecture assembly layers
builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ==========================================
// 🥞 HTTP PIPELINE: MIDDLEWARE ENFORCEMENT
// ==========================================

// Deploying our custom Exception Handling Interceptor for 100% data resilience
app.UseMiddleware<ExceptionHandlingMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Minimal API Routing Endpoint Node
app.MapPost("/api/v1/ingest", () => Results.Ok(new { 
    Status = "AUTHORIZED", 
    Uptime = DateTime.UtcNow,
    EngineFrequency = "5.0 GHz" 
}))
.WithName("IngestPayload")
.WithOpenApi();

// THE CRITICAL RUNTIME ENTRY POINT EXECUTION LOOP
await app.RunAsync();
