using System.Text.Json.Serialization;
using Backend.Api;
using Backend.Shared;
using Backend.Shared.Api;
using DotNetEnv;
using Npgsql;
using Scalar.AspNetCore;

Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);
var config  = builder.Configuration;

var connStr = new NpgsqlConnectionStringBuilder {
    Host     = config.GetValue<string?>("DB_HOST")     ?? throw new Exception("DB_HOST not set"),
    Port     = config.GetValue<int?>("DB_PORT")        ?? throw new Exception("DB_PORT not set"),
    Database = config.GetValue<string?>("DB_NAME")     ?? throw new Exception("DB_NAME not set"),
    Username = config.GetValue<string?>("DB_USER")     ?? throw new Exception("DB_USER not set"),
    Password = config.GetValue<string?>("DB_PASSWORD") ?? throw new Exception("DB_PASSWORD not set")
}.ConnectionString;

builder.Services.ConfigureHttpJsonOptions(o => { o.SerializerOptions.NumberHandling = JsonNumberHandling.Strict; });
builder.Services.AddOpenApi();
builder.Services.AddProblemDetails();

builder.Services.AddSharedServices();

builder.Services.AddBackend(connStr);

var app = builder.Build();

app.MapOpenApi();

app.MapScalarApiReference(o => {
    o.SortTagsAlphabetically();
    o.WithTheme(ScalarTheme.DeepSpace);
});

app.MapBackend();

app.MapGet("/api/health", () => Results.Ok(new { Ok = true }))
    .WithName("CheckHealth")
    .WithSummary("Check API Health")
    .WithDescription("Endpoint for API health check, CI, and ...")
    .WithTags(ApiTags.Misc);

app.Run();
