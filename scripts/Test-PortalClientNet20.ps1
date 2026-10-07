#Requires -Version 7.0
param([Uri] $StatusUrl)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$builder = Join-Path $env:WINDIR 'Microsoft.NET/Framework/v3.5/MSBuild.exe'
if (!(Test-Path $builder)) { throw 'Install the .NET Framework 3.5 Windows component / Visual Studio 2008 build tools before running the legacy tests.' }
Push-Location $root
try {
    & $builder Kombine.Flex.Portal.Client.2008.sln /p:Configuration=Release /nologo /v:minimal
    if ($LASTEXITCODE) { throw 'VS2008/.NET 2.0 build failed.' }
    $test = Join-Path $root 'tests/Kombine.Flex.Portal.Client.Net20.Tests/bin/Release/Kombine.Flex.Portal.Client.Net20.Tests.exe'
    & $test
    if ($LASTEXITCODE) { throw '.NET 2.0 runtime checks failed.' }
    if ($StatusUrl) {
        & $test --status $StatusUrl.AbsoluteUri
        if ($LASTEXITCODE) { throw 'Legacy HTTPS status check failed.' }
    }
    $output = Join-Path $root 'artifacts/packages/Kombine.Flex.Portal.Client.Net20.0.4.4.zip'
    $null = New-Item -ItemType Directory -Force (Split-Path $output)
    # Build the ZIP directly from known files: no cleanup/deletion of another staging tree.
    Add-Type -AssemblyName System.IO.Compression
    $stream = [IO.File]::Open($output, [IO.FileMode]::Create)
    $archive = [IO.Compression.ZipArchive]::new($stream, [IO.Compression.ZipArchiveMode]::Create)
    try {
        function Add-PackageFile([string] $file, [string] $entry) {
            $item = $archive.CreateEntry($entry.Replace('\', '/'), [IO.Compression.CompressionLevel]::Optimal)
            $source = [IO.File]::OpenRead($file)
            $destination = $item.Open()
            try { $source.CopyTo($destination) } finally { $destination.Dispose(); $source.Dispose() }
        }
        $project = Join-Path $root 'Kombine.Flex.Portal.Client.Net20'
        foreach ($extension in @('dll', 'xml')) {
            Add-PackageFile (Join-Path $project "bin/Release/Kombine.Flex.Portal.Client.Net20.$extension") "Kombine.Flex.Portal.Client.Net20.$extension"
        }
        foreach ($file in @('README.md', 'README.da.md', 'README.es.md', 'OPERATIONS.md')) { Add-PackageFile (Join-Path $project $file) $file }
        Add-PackageFile (Join-Path $root 'Kombine.Flex.Portal.Client.2008.sln') 'Source/Kombine.Flex.Portal.Client.2008.sln'
        Add-PackageFile (Join-Path $root 'Shared/LegacyPortalSession.cs') 'Source/Shared/LegacyPortalSession.cs'
        Add-PackageFile (Join-Path $root 'tests/Shared/SessionChecks.cs') 'Source/tests/Shared/SessionChecks.cs'
        foreach ($relative in @('Kombine.Flex.Portal.Client.Net20', 'tests/Kombine.Flex.Portal.Client.Net20.Tests')) {
            $directory = Join-Path $root $relative
            Get-ChildItem $directory -Recurse -File | Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' -and $_.Extension -notin @('.user', '.suo') } | ForEach-Object {
                $entry = [IO.Path]::GetRelativePath($root, $_.FullName)
                Add-PackageFile $_.FullName "Source/$entry"
            }
        }
    } finally { $archive.Dispose(); $stream.Dispose() }
    Write-Host "Created DLL/source package: $output"
} finally { Pop-Location }
