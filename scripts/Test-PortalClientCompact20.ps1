#Requires -Version 7.0
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$builder = Join-Path $env:WINDIR 'Microsoft.NET/Framework/v3.5/MSBuild.exe'
$targets = Join-Path $env:WINDIR 'Microsoft.NET/Framework/v3.5/Microsoft.CompactFramework.CSharp.targets'
if (!(Test-Path $builder) -or !(Test-Path $targets)) { throw 'Install Visual Studio 2008 Smart Device tools and the .NET Compact Framework 2.0 SDK.' }
Push-Location $root
try {
    & $builder Kombine.Flex.Portal.Client.Compact2008.sln /p:Configuration=Release /nologo /v:minimal
    if ($LASTEXITCODE) { throw 'Compact Framework solution build failed.' }
    & './tests/Kombine.Flex.Portal.Client.Compact20.Tests/bin/Desktop/Release/Kombine.Flex.Portal.Client.Compact20.Tests.exe'
    if ($LASTEXITCODE) { throw 'Desktop-hosted Compact client checks failed.' }

    $output = Join-Path $root 'artifacts/packages/Kombine.Flex.Portal.Client.Compact20.0.4.4.zip'
    $null = New-Item -ItemType Directory -Force (Split-Path $output)
    $stream = [IO.File]::Open($output, [IO.FileMode]::Create)
    $archive = [IO.Compression.ZipArchive]::new($stream, [IO.Compression.ZipArchiveMode]::Create)
    try {
        function Add-PackageFile([string] $file, [string] $entry) {
            $item = $archive.CreateEntry($entry.Replace('\', '/'), [IO.Compression.CompressionLevel]::Optimal)
            $source = [IO.File]::OpenRead($file)
            $destination = $item.Open()
            try { $source.CopyTo($destination) } finally { $destination.Dispose(); $source.Dispose() }
        }
        $project = Join-Path $root 'Kombine.Flex.Portal.Client.Compact20'
        foreach ($extension in @('dll', 'xml')) {
            Add-PackageFile (Join-Path $project "bin/Release/Kombine.Flex.Portal.Client.Compact20.$extension") "Kombine.Flex.Portal.Client.Compact20.$extension"
        }
        foreach ($file in @('README.md', 'README.da.md', 'README.es.md', 'OPERATIONS.md')) { Add-PackageFile (Join-Path $project $file) $file }
        $device = Join-Path $root 'tests/Kombine.Flex.Portal.Client.Compact20.Tests/bin/Device/Release'
        foreach ($file in @('Kombine.Flex.Portal.Client.Compact20.Tests.exe', 'Kombine.Flex.Portal.Client.Compact20.dll', 'ContractCases.tsv')) {
            Add-PackageFile (Join-Path $device $file) "DeviceTests/$file"
        }
        Add-PackageFile (Join-Path $root 'Kombine.Flex.Portal.Client.Compact2008.sln') 'Source/Kombine.Flex.Portal.Client.Compact2008.sln'
        Add-PackageFile (Join-Path $root 'Shared/LegacyPortalSession.cs') 'Source/Shared/LegacyPortalSession.cs'
        Add-PackageFile (Join-Path $root 'tests/Shared/SessionChecks.cs') 'Source/tests/Shared/SessionChecks.cs'
        foreach ($relative in @('Kombine.Flex.Portal.Client.Compact20', 'tests/Kombine.Flex.Portal.Client.Compact20.Tests')) {
            Get-ChildItem (Join-Path $root $relative) -Recurse -File | Where-Object {
                $_.FullName -notmatch '[\\/](bin|obj)[\\/]' -and $_.Extension -notin @('.user', '.suo')
            } | ForEach-Object {
                Add-PackageFile $_.FullName ('Source/' + [IO.Path]::GetRelativePath($root, $_.FullName))
            }
        }
    } finally { $archive.Dispose(); $stream.Dispose() }
    Write-Host "Created Compact Framework DLL/source/device-test package: $output"
    Write-Host 'Device/emulator runtime and HTTPS have not been tested by this script.'
} finally { Pop-Location }
