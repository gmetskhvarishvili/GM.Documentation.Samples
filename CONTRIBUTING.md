# Contributing to GM.Documentation Samples

This repository is a **usage sample** for the [`GM.Documentation`](https://www.nuget.org/packages/GM.Documentation)
package. It is not published to NuGet — there is no versioning or release workflow here. The goal is
to keep the sample building, tested, and easy to follow.

## Prerequisites

- **.NET 10 SDK**

```bash
dotnet build -c Release
dotnet test  -c Release
```

## Branch & PR flow

1. Branch off `master`: `git switch -c fix/swagger-assets`
2. Open a PR into `master`. CI (`build` + tests) must pass.
3. Keep changes focused and the README in sync with what the sample does.

## Guidelines

- The API references **only** `GM.Documentation` (Swashbuckle/OpenAPI come transitively) — keep it
  that way so the sample shows the minimal dependency footprint.
- Documentation is configured in `appsettings.json` under `SwaggerDocOptions`; prefer configuration
  over code when demonstrating a feature.
- Add or update an integration test in `tests/GM.Documentation.Sample.Tests` when you change endpoint
  behaviour.
- Bump the `GM.Documentation` package version when a new release adds something the sample should show.

## Where releases happen

Package versioning, tags, changelog and nuget.org publishing live in the library repository
([`GM.Documentation`](https://github.com/gmetskhvarishvili/GM.Documentation)), driven by Conventional
Commits. Nothing is published from this samples repo.

## Code style

Enforced by [`.editorconfig`](.editorconfig). Run `dotnet format` before pushing if unsure.
