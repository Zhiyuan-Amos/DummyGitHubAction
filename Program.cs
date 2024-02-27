using Cocona;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

var builder = CoconaApp.CreateBuilder();
builder.Services.AddLogging();
builder.Configuration
    .AddEnvironmentVariables()
    .Build();

var app = builder.Build();
app.AddCommand((string inlineVariable,
    [FromService] IConfiguration configuration,
    ILogger<Program> logger) =>
{
    var configurationVariable = configuration["ConfigurationVariable"]!;
    logger.LogInformation("Inline Variable: {InlineVariable}", inlineVariable);
    logger.LogInformation("Configuration Variable: {ConfigurationVariable}", configurationVariable);
});
app.Run();
