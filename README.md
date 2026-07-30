<p align="center">
  <img src="icon.png" alt="GM.Documentation Samples" width="140" height="140" />
</p>

# GM.Documentation Samples

[![CI](https://github.com/gmetskhvarishvili/GM.Documentation.Samples/actions/workflows/ci.yml/badge.svg)](https://github.com/gmetskhvarishvili/GM.Documentation.Samples/actions/workflows/ci.yml)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

A runnable ASP.NET Core Web API that shows how to use **[GM.Documentation](https://www.nuget.org/packages/GM.Documentation)**
to get a fully configured, versioned Swagger UI from configuration — API versioning, OAuth2 security,
required headers, XML comments, and custom CSS/JS — with just `AddGMDocumentation` + `UseGMDocumentation`.
Targets `net10.0`.

## What it demonstrates

- **API versioning** — a `v1` and a `v2` weather controller, each surfaced as its own Swagger document.
- **Configuration-driven docs** — title, contact, license, OAuth2 flows and required headers all come
  from `appsettings.json` under `SwaggerDocOptions`.
- **XML comments** — controller/model summaries flow into the OpenAPI schema.
- **Custom UI** — `Assets/swagger.css` and `Assets/swagger.js` restyle the Swagger UI.

## Wiring

```csharp
builder.Services.AddApiVersioning(/* ... */).AddApiExplorer(/* ... */);
builder.Services.AddGMDocumentation(builder.Configuration, "SwaggerDocOptions");

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseGMDocumentation();
}
```

Only `GM.Documentation` is referenced; Swashbuckle and Microsoft.OpenApi flow in transitively.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- The [`GM.Documentation`](https://www.nuget.org/packages/GM.Documentation) package (restored automatically).

## Running

```bash
dotnet run --project GM.Documentation.Sample.API
```

Open the app root (`/`) — `UseGMDocumentation` redirects it to the Swagger UI, with a version
selector for **v1** and **v2**.

### Endpoints

| Method | Route | Version | Result |
| --- | --- | --- | --- |
| `GET` | `/api/v1.0/Sample` | 1.0 | 5-day weather forecast |
| `GET` | `/api/v2.0/Sample` | 2.0 | 5-day weather forecast |

## Testing

```bash
dotnet test
```

The suite boots the API in-memory with `WebApplicationFactory` and verifies both versioned endpoints
respond, exercising API versioning + routing end-to-end.

## License

MIT — see [LICENSE](LICENSE).
