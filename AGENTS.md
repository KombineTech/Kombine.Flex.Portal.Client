# Public Portal API clients

This repository contains only the public Portal API SDKs, their public OpenAPI
snapshots, documentation, generators and synthetic tests. Do not add server code,
Equipment clients, credentials, deployment configuration or private repository history.

Keep C# and VB.NET examples in English, Danish and Spanish. Preserve framework
compatibility, stable operation IDs and UserBalance compatibility. Tests use synthetic
loopback HTTP fixtures; never use tenant databases or real credentials.

Jens explicitly requested automatic NuGet publication on 2026-10-03: a push to
main that increases the .NET client's Version publishes Kombine.Flex.Portal.Client
to nuget.org after tests and package-consumer checks pass. Same-version commits
do not publish. The clients.yml workflow owns publication through Trusted Publishing;
Portal server deployments no longer publish NuGet. Never overwrite a version with
different contents, and do not publish any other package variant to a registry.
Increment every changed package version before building it. Coordinate API changes
and the server's pinned SDK revision/download archives during beta preparation.
