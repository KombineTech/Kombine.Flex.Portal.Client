#Requires -Version 7.0
param([Uri] $StatusUrl)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$builder = Join-Path $env:WINDIR 'Microsoft.NET/Framework/v4.0.30319/MSBuild.exe'
if (!(Test-Path $builder)) { throw 'Install the .NET Framework 4.x / Visual Studio 2012 build tools before running these checks.' }
# Reference assemblies are developer build inputs only. They are not project/package dependencies.
$installedRoot = Join-Path ${env:ProgramFiles(x86)} 'Reference Assemblies/Microsoft/Framework'
$referenceRoot = $installedRoot
if (!(Test-Path (Join-Path $referenceRoot '.NETFramework/v4.5/mscorlib.dll'))) {
    $referenceDirectory = Join-Path $root 'artifacts/client-tools/net45-reference-assemblies.1.0.3'
    $referenceRoot = Join-Path $referenceDirectory 'build'
    if (!(Test-Path (Join-Path $referenceRoot '.NETFramework/v4.5/mscorlib.dll'))) {
        $null = New-Item -ItemType Directory -Force (Split-Path $referenceDirectory)
        $package = "$referenceDirectory.nupkg"
        Invoke-WebRequest 'https://api.nuget.org/v3-flatcontainer/microsoft.netframework.referenceassemblies.net45/1.0.3/microsoft.netframework.referenceassemblies.net45.1.0.3.nupkg' -OutFile $package
        [IO.Compression.ZipFile]::ExtractToDirectory($package, $referenceDirectory)
    }
}
Push-Location $root
try {
    & $builder Kombine.Flex.Portal.Client.2012.sln /p:Configuration=Release ('/p:TargetFrameworkRootPath=' + $referenceRoot + [IO.Path]::DirectorySeparatorChar) /nologo /v:minimal
    if ($LASTEXITCODE) { throw '.NET Framework 4.5 build failed.' }
    $test = Join-Path $root 'tests/Kombine.Flex.Portal.Client.Net45.Tests/bin/Release/Kombine.Flex.Portal.Client.Net45.Tests.exe'
    & $test
    if ($LASTEXITCODE) { throw 'CLR 4 runtime checks failed.' }
    if ($StatusUrl) {
        & $test --status $StatusUrl.AbsoluteUri
        if ($LASTEXITCODE) { throw '.NET Framework HTTPS status check failed.' }
    }
    $output = Join-Path $root 'artifacts/packages/Kombine.Flex.Portal.Client.Net45.0.4.1.zip'
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
        $project = Join-Path $root 'Kombine.Flex.Portal.Client.Net45'
        foreach ($extension in @('dll', 'xml')) {
            Add-PackageFile (Join-Path $project "bin/Release/Kombine.Flex.Portal.Client.Net45.$extension") "Kombine.Flex.Portal.Client.Net45.$extension"
        }
        foreach ($file in @('README.md', 'README.da.md', 'README.es.md', 'OPERATIONS.md')) { Add-PackageFile (Join-Path $project $file) $file }
        Add-PackageFile (Join-Path $root 'Kombine.Flex.Portal.Client.2012.sln') 'Source/Kombine.Flex.Portal.Client.2012.sln'
        foreach ($relative in @('Kombine.Flex.Portal.Client.Net45', 'tests/Kombine.Flex.Portal.Client.Net45.Tests')) {
            $directory = Join-Path $root $relative
            Get-ChildItem $directory -Recurse -File | Where-Object { $_.FullName -notmatch '[\\/](bin|obj)[\\/]' -and $_.Extension -notin @('.user', '.suo') } | ForEach-Object {
                $entry = [IO.Path]::GetRelativePath($root, $_.FullName)
                Add-PackageFile $_.FullName "Source/$entry"
            }
        }
    } finally { $archive.Dispose(); $stream.Dispose() }
    Write-Host "Created DLL/source package: $output"
} finally { Pop-Location }
