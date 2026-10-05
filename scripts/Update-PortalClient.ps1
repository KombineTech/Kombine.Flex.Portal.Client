#Requires -Version 7.0
<# .SYNOPSIS Regenerates the standalone client from the checked-in public OpenAPI snapshot.
.DESCRIPTION Optionally refreshes the snapshot from a tenant API. No credentials, databases, or business operations are used.
#>
param([Uri] $ApiBaseUrl)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$project = Join-Path $root 'Kombine.Flex.Portal.Client'
$snapshot = Join-Path $project 'OpenApi/portal.openapi.json'
if ($ApiBaseUrl) {
    if (!$ApiBaseUrl.IsAbsoluteUri -or $ApiBaseUrl.Scheme -ne 'https' -or $ApiBaseUrl.UserInfo -or $ApiBaseUrl.Query -or $ApiBaseUrl.Fragment) { throw 'Use an HTTPS API base URL without credentials, query, or fragment.' }
    $sources = @('swagger/v1/swagger.json', 'swagger/public/swagger.json')
    $documents = @($sources | ForEach-Object { Invoke-RestMethod ([Uri]::new($ApiBaseUrl, $_)) -MaximumRedirection 0 })
    $merged = $documents[0] | ConvertTo-Json -Depth 100 | ConvertFrom-Json -AsHashtable
    foreach ($document in $documents | Select-Object -Skip 1) {
        $next = $document | ConvertTo-Json -Depth 100 | ConvertFrom-Json -AsHashtable
        foreach ($path in $next.paths.Keys) {
            if ($merged.paths.Contains($path)) { throw "Duplicate API path: $path" }
            $merged.paths[$path] = $next.paths[$path]
        }
        foreach ($section in $next.components.Keys) {
            if (!$merged.components.Contains($section)) { $merged.components[$section] = [ordered]@{} }
            foreach ($name in $next.components[$section].Keys) {
                $value = $next.components[$section][$name]
                if ($merged.components[$section].Contains($name) -and ($merged.components[$section][$name] | ConvertTo-Json -Depth 100 -Compress) -ne ($value | ConvertTo-Json -Depth 100 -Compress)) { throw "Conflicting schema: $name" }
                $merged.components[$section][$name] = $value
            }
        }
    }
    $merged.Remove('servers') | Out-Null
    $merged.info.title = 'Kombine Flex Portal public and manager integrations'
    $merged['x-source-documents'] = $sources
    [IO.File]::WriteAllText($snapshot, ($merged | ConvertTo-Json -Depth 100) + "`n", [Text.UTF8Encoding]::new($false))
}
$tools = Join-Path $root 'artifacts/client-tools'
if (!(Test-Path (Join-Path $tools 'nswag.exe'))) {
    dotnet tool install NSwag.ConsoleCore --version 14.7.1 --tool-path $tools --configfile (Join-Path $root 'NuGet.Client.Config')
    if ($LASTEXITCODE) { throw 'NSwag installation failed.' }
}
Push-Location $root
try {
    & (Join-Path $tools 'nswag.exe') run (Join-Path $project 'client.nswag')
    if ($LASTEXITCODE) { throw 'Client generation failed.' }
} finally { Pop-Location }
$generatedSource = Join-Path $project 'Generated/PortalApiClient.g.cs'
$generatedText = [IO.File]::ReadAllText($generatedSource)
$generatedText = $generatedText.Replace('client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)', 'SendRequestAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken)')
$generatedText = [Text.RegularExpressions.Regex]::Replace($generatedText, '(?m)[ \t]+(?=\r?$)', '')
[IO.File]::WriteAllText($generatedSource, $generatedText, [Text.UTF8Encoding]::new($false))
$contract = Get-Content $snapshot -Raw | ConvertFrom-Json -AsHashtable
$rows = foreach ($path in $contract.paths.Keys) {
    foreach ($method in $contract.paths[$path].Keys) {
        $operation = $contract.paths[$path][$method]
        if ($operation.operationId) { '| `' + $operation.operationId + 'Async` | ' + $method.ToUpperInvariant() + ' | `' + $path + '` |' }
    }
}
$markdown = "# Client operations`n`nGenerated from the checked-in public integration contract. All business rules are enforced by the API.`n`n| Method | HTTP | Path |`n| --- | --- | --- |`n" + (($rows | Sort-Object) -join "`n") + "`n"
[IO.File]::WriteAllText((Join-Path $project 'OPERATIONS.md'), $markdown, [Text.UTF8Encoding]::new($false))
Write-Host "Generated $($rows.Count) public operations. NSwag is a development tool, not a package dependency."
