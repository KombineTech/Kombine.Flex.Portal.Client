#Requires -Version 7.0
<# .SYNOPSIS Tests the actual local NuGet package in an independent consumer on Framework 4.7.2/4.8 and .NET 8/9/10. #>
param(
    [string] $Configuration = 'Release',
    [string] $WorkRoot = [IO.Path]::GetTempPath(),
    [string] $PackageDirectory = (Join-Path (Split-Path $PSScriptRoot -Parent) 'artifacts/packages')
)
$ErrorActionPreference = 'Stop'
if (!$IsWindows) { throw 'The Framework compatibility tests require Windows.' }
$root = Split-Path $PSScriptRoot -Parent
$clientProject = Join-Path $root 'Kombine.Flex.Portal.Client/Kombine.Flex.Portal.Client.csproj'
$version = ([xml](Get-Content $clientProject -Raw)).Project.PropertyGroup.Version
$packagePath = Join-Path $PackageDirectory "Kombine.Flex.Portal.Client.$version.nupkg"
if (!(Test-Path -LiteralPath $packagePath)) { throw 'Pack the client before running package-consumer tests.' }

$archive = [IO.Compression.ZipFile]::OpenRead($packagePath)
try {
    foreach ($target in @('netstandard2.0', 'net8.0', 'net10.0')) {
        foreach ($extension in @('dll', 'xml')) {
            if (!$archive.GetEntry("lib/$target/Kombine.Flex.Portal.Client.$extension")) { throw "Missing $target $extension asset." }
        }
    }
    $reader = [IO.StreamReader]::new($archive.GetEntry('Kombine.Flex.Portal.Client.nuspec').Open())
    try { $manifest = [xml]$reader.ReadToEnd() } finally { $reader.Dispose() }
    $groups = @($manifest.SelectNodes("//*[local-name()='dependencies']/*[local-name()='group']"))
    if ($groups.Count -ne 3) { throw 'Unexpected package target groups.' }
    foreach ($group in $groups) {
        $dependencies = @($group.SelectNodes("*[local-name()='dependency']"))
        if ($group.targetFramework -eq '.NETStandard2.0') {
            if ($dependencies.Count -ne 1 -or $dependencies[0].id -ne 'System.Text.Json') { throw 'The Standard target should depend only on Microsoft JSON.' }
        } elseif ($dependencies.Count -ne 0) { throw 'Modern targets must remain free of package dependencies.' }
    }
} finally { $archive.Dispose() }

# A fresh package cache ensures a previous package with the same unpublished version cannot hide a packaging defect.
# Keep paths short enough for Framework tooling and deeply nested reference-assembly packages.
$work = Join-Path $WorkRoot ('pc-' + [Guid]::NewGuid().ToString('N').Substring(0, 8))
$consumer = Join-Path $work 'consumer'
$null = New-Item -ItemType Directory -Path $consumer -Force
$testSource = Join-Path $root 'tests/Kombine.Flex.Portal.Client.Tests'
$project = [xml](Get-Content (Join-Path $testSource 'Kombine.Flex.Portal.Client.Tests.csproj') -Raw)
foreach ($reference in @($project.SelectNodes('//ProjectReference'))) { $null = $reference.ParentNode.RemoveChild($reference) }
foreach ($item in @($project.SelectNodes('//None'))) { $null = $item.ParentNode.RemoveChild($item) }
$items = $project.CreateElement('ItemGroup')
$package = $project.CreateElement('PackageReference')
$package.SetAttribute('Include', 'Kombine.Flex.Portal.Client')
$package.SetAttribute('Version', $version)
$null = $items.AppendChild($package)
$contract = $project.CreateElement('None')
$contract.SetAttribute('Include', 'portal.openapi.json')
$contract.SetAttribute('CopyToOutputDirectory', 'PreserveNewest')
$null = $items.AppendChild($contract)
$null = $project.Project.AppendChild($items)
$configPath = Join-Path $consumer 'NuGet.Config'
$project.Project.PropertyGroup.RestoreConfigFile = $configPath
$project.Save((Join-Path $consumer 'PackageConsumer.csproj'))
Copy-Item -Path (Join-Path $testSource '*.cs') -Destination $consumer
Copy-Item -LiteralPath (Join-Path $root 'Kombine.Flex.Portal.Client/OpenApi/portal.openapi.json') -Destination $consumer
$feed = [System.Security.SecurityElement]::Escape((Split-Path $packagePath -Parent))
@"
<?xml version="1.0" encoding="utf-8"?>
<configuration><packageSources><clear /><add key="local-client" value="$feed" /><add key="nuget.org" value="https://api.nuget.org/v3/index.json" /></packageSources><packageSourceMapping><clear /><packageSource key="local-client"><package pattern="Kombine.Flex.Portal.Client" /></packageSource><packageSource key="nuget.org"><package pattern="*" /></packageSource></packageSourceMapping></configuration>
"@ | Set-Content -LiteralPath $configPath -Encoding utf8
dotnet test (Join-Path $consumer 'PackageConsumer.csproj') -c $Configuration --nologo ('-p:RestorePackagesPath=' + (Join-Path $work 'packages'))
if ($LASTEXITCODE) { throw 'Independent NuGet consumer checks failed.' }
Write-Host 'Package assets, dependencies and all client tests passed from an independent NuGet consumer.'
