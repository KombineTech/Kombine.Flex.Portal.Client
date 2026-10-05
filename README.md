# Kombine.Flex.Portal.Client
Official client libraries for the Kombine Flex Portal API: C# and VB.NET (.NET, .NET Standard, .NET Framework and .NET Compact Framework), JavaScript/TypeScript, Python and PHP. Includes typed models, authentication, documentation and integration examples.

| Client | Documentation |
| --- | --- |
| .NET Standard 2.0, .NET 8 and .NET 10 | [English](Kombine.Flex.Portal.Client/README.md) · [Dansk](Kombine.Flex.Portal.Client/README.da.md) · [Español](Kombine.Flex.Portal.Client/README.es.md) |
| .NET Framework 2.0 / 3.5 | [Guide](Kombine.Flex.Portal.Client.Net20/README.md) |
| .NET Framework 4.5 | [Guide](Kombine.Flex.Portal.Client.Net45/README.md) |
| .NET Compact Framework 2.0 | [Guide](Kombine.Flex.Portal.Client.Compact20/README.md) |
| JavaScript / TypeScript | [Guide](Kombine.Flex.Portal.Client.JavaScript/README.md) |
| Python | [Guide](Kombine.Flex.Portal.Client.Python/README.md) |
| PHP | [Guide](Kombine.Flex.Portal.Client.Php/README.md) |

Each client directory includes Danish and Spanish README alternatives. C# and
VB.NET use the same .NET library. No private Kombine packages or server checkout
are required. Portal applications and Equipment SDKs are maintained separately.

## Build and test

Install the .NET SDK selected by `global.json`, then run
`pwsh -NoProfile -File scripts/Test-PortalClients.ps1` on Windows with .NET 8/9/10
runtimes installed. This tests .NET Framework 4.7.2/4.8 and .NET 8/9/10.
On other platforms, select `-f net10.0` with `dotnet test` instead.

For Python 3.11+, run `python -m unittest discover -s tests -v` from
`Kombine.Flex.Portal.Client.Python` with `PYTHONPATH=src`.
For Node 22+ and pnpm, run `pnpm install --frozen-lockfile --ignore-scripts`
and `pnpm test` from `Kombine.Flex.Portal.Client.JavaScript`.
For PHP 8.2+ with curl and Python, run `python scripts/Test-PhpClients.py`.
All tests use synthetic data; no tenant account or database is needed.

Legacy solutions (`.2008.sln`, `.2012.sln`, `.Compact2008.sln`) require their
original Windows/Visual Studio build tools. Compact Framework runtime validation
on a device is separate from the desktop-hosted checks.

## Generation and releases

The checked-in OpenAPI snapshots make builds independent of a running API.
`scripts/Update-PortalClient.ps1` regenerates the modern .NET client and can
refresh its snapshot using `-ApiBaseUrl https://api.example.invalid/`.
`scripts/Generate-PortalClientNet20.py` generates legacy .NET sources; use
`--net45` or `--compact` for those variants.
`scripts/Generate-PortalScriptClients.py` and `scripts/Generate-PhpClients.py`
generate script clients; both accept `--check`. PHP has its own snapshot in
`Kombine.Flex.Portal.Client.Php/OpenApi`.

The .NET NuGet client is published automatically when a push to `main` increases
`Version` in `Kombine.Flex.Portal.Client/Kombine.Flex.Portal.Client.csproj`.
Use a stable `major.minor.patch` version, for example `0.4.1` → `0.4.1`.
All client checks and independent package-consumer tests must pass first.
Commits with the same version, pull requests, branches and tags never publish.
Decreasing the version fails validation. An existing version is accepted only
when its contents match exactly (excluding NuGet's added signature).

Publication is independent of Portal deployment. Existing downloadable archives
remain served by the API; update its pinned SDK revision, archives and manifests
during server release preparation. No other package variants are auto-published.
Increment every changed package version before packaging, including documentation
changes. The migration corrects the PHP operation inventory's snapshot checksum;
its next package therefore needs a version newer than 0.4.1.

### One-time nuget.org setup

Configure [Trusted Publishing](https://learn.microsoft.com/en-us/nuget/nuget-org/trusted-publishing)
using the NuGet account authorized to publish this package:

- Repository owner: `KombineTech`
- Repository: `Kombine.Flex.Portal.Client`
- Workflow file: `clients.yml`
- Environment: leave empty (this workflow does not use a GitHub environment)
- Package pattern: exactly `Kombine.Flex.Portal.Client`, allowing new packages/versions
- Set the GitHub repository variable `NUGET_USER` to the account's NuGet profile
  name, not its email address. No long-lived API key is stored in GitHub.

The existing `0.4.1` version is not released merely by enabling this workflow.
Merge a version increase into `main` when ready to release. If authorization,
upload or NuGet validation fails, fix the cause and rerun the original failed
workflow. Its original before/after commits and version are retained; do not bump
the version just to retry the same package. The workflow retains the tested
`.nupkg` artifact and verifies the public package after upload.

See the [API integration guide](https://api.team.kombine.technology/docs) and
[API changelog](https://api.team.kombine.technology/docs#changelog) for released
contracts, permissions and migration notes.
