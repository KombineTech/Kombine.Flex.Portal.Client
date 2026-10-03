# Public Portal API clients

This repository contains only the public Portal API SDKs, their public OpenAPI
snapshots, documentation, generators and synthetic tests. Do not add server code,
Equipment clients, credentials, deployment configuration or private repository history.

Keep C# and VB.NET examples in English, Danish and Spanish. Preserve framework
compatibility, stable operation IDs and UserBalance compatibility. Tests use synthetic
loopback HTTP fixtures; never use tenant databases or real credentials.

Release preparation is coordinated with the Portal server beta release. Increment
the version of every changed package before building it. Never replace an existing
package version with different contents. Public visibility does not authorize
publishing packages to registries. Production promotes the exact reviewed beta
NuGet archive through the private Portal repository's release process.
