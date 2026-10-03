#Requires -Version 7.0
param([string] $Configuration = 'Release')
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
dotnet test (Join-Path $root 'tests/Kombine.Flex.Portal.Client.Tests') -c $Configuration --nologo
if ($LASTEXITCODE) { throw 'Client tests failed.' }
