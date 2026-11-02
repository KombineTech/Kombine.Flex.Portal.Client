#Requires -Version 7.0
[CmdletBinding()]
param([string]$DartCommand = 'dart', [string]$NodeCommand = 'node')
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$project = Join-Path $root 'Kombine.Flex.Portal.Client.Dart'
Push-Location $project
try {
    & $DartCommand pub get
    if ($LASTEXITCODE) { throw 'Dart restore failed.' }
    & $DartCommand analyze
    if ($LASTEXITCODE) { throw 'Dart analysis failed.' }
    & $DartCommand test
    if ($LASTEXITCODE) { throw 'Dart tests failed.' }
    $output = Join-Path $root 'artifacts/dart'
    New-Item -ItemType Directory -Force $output | Out-Null
    $javascript = Join-Path $output 'portal-smoke.js'
    & $DartCommand compile js example/browser_smoke.dart -o $javascript
    if ($LASTEXITCODE) { throw 'Dart JavaScript compilation failed.' }
    & $NodeCommand -e 'global.self=globalThis;require(process.argv[1])' $javascript
    if ($LASTEXITCODE) { throw 'Dart JavaScript precision check failed.' }
} finally { Pop-Location }
