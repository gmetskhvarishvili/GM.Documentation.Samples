using Asp.Versioning;
using GM.Documentation;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.ReportApiVersions = true;
        options.ApiVersionReader = new UrlSegmentApiVersionReader();
    })
    .AddMvc()
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

builder.Services.AddGMDocumentation(
    builder.Configuration,
    "SwaggerDocOptions");

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseGMDocumentation();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

// Liveness must not depend on downstream dependencies, so it runs no checks; readiness runs
// every registered health check (none here yet). See engineering baseline §11.
app.MapHealthChecks("/health/live", new HealthCheckOptions { Predicate = _ => false });
app.MapHealthChecks("/health/ready");

await app.RunAsync();

// Exposed so the integration test project can bootstrap the app via WebApplicationFactory.
public partial class Program
{
    // Only used as a WebApplicationFactory<Program> marker; never instantiated directly.
    protected Program() { }
}
