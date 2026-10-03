#Requires -Version 7.0
param(
    [string] $PythonCommand = 'python',
    [string] $PackageManager = 'pnpm'
)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$output = Join-Path $root 'artifacts/packages'
$null = New-Item -ItemType Directory -Force $output
Push-Location $root
try {
    & $PythonCommand scripts/Generate-PortalScriptClients.py --check
    if ($LASTEXITCODE) { throw 'Generated Python/TypeScript clients are out of date.' }
    Push-Location (Join-Path $root 'Kombine.Flex.Portal.Client.Python')
    $originalPythonPath = $env:PYTHONPATH
    try {
        $env:PYTHONPATH = Join-Path (Get-Location) 'src'
        & $PythonCommand -m unittest discover -s tests -v
        if ($LASTEXITCODE) { throw 'Python client tests failed.' }
        # setuptools and wheel are developer tools only; neither is a runtime dependency.
        & $PythonCommand -c 'import sys; from setuptools.build_meta import build_wheel, build_sdist; destination = sys.argv[1]; build_wheel(destination); build_sdist(destination)' $output
        if ($LASTEXITCODE) { throw 'Python package build failed. Install setuptools and wheel in the build environment.' }
    } finally {
        $env:PYTHONPATH = $originalPythonPath
        Pop-Location
    }
    Push-Location (Join-Path $root 'Kombine.Flex.Portal.Client.JavaScript')
    try {
        & $PackageManager install --frozen-lockfile --ignore-scripts
        if ($LASTEXITCODE) { throw 'TypeScript build dependency restore failed.' }
        & $PackageManager test
        if ($LASTEXITCODE) { throw 'JavaScript/TypeScript client checks failed.' }
        & $PackageManager pack --pack-destination $output
        if ($LASTEXITCODE) { throw 'JavaScript package build failed.' }
    } finally { Pop-Location }
    Write-Host "Python wheel/sdist and npm tarball are ready in $output. Nothing was published."
} finally { Pop-Location }
