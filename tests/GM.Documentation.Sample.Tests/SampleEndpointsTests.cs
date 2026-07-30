using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace GM.Documentation.Sample.Tests;

/// <summary>
/// Boots the API in-memory and verifies each versioned endpoint responds, exercising
/// API versioning + routing end-to-end. Runs in Production so the Development-only Swagger UI
/// (which serves static assets from disk) is skipped — the docs pipeline is covered in the
/// GM.Documentation library tests.
/// </summary>
public class SampleEndpointsTests(WebApplicationFactory<Program> factory)
    : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly System.Net.Http.HttpClient _client =
        factory.WithWebHostBuilder(builder => builder.UseEnvironment("Production")).CreateClient();

    [Theory]
    [InlineData("/api/v1.0/Sample")]
    [InlineData("/api/v2.0/Sample")]
    public async Task Versioned_endpoint_returns_a_forecast_array(string url)
    {
        var response = await _client.GetAsync(url);

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        using var doc = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        Assert.Equal(JsonValueKind.Array, doc.RootElement.ValueKind);
        Assert.Equal(5, doc.RootElement.GetArrayLength());
    }
}
