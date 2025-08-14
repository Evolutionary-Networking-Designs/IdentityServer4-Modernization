# Security Vulnerability Found
IdentityServer4 contains a known Open Redirect vulnerability (CVE-2024-39694) that we do not intend to address in IdentityServer4. Please see [the security advisory](https://github.com/IdentityServer/IdentityServer4/security/advisories/GHSA-55p7-v223-x366) for more details and consider upgrading to [Duende.IdentityServer](www.duendesoftware.com) to receive updates.

# Important update

## 2025-08-14

This project is a fork of the original IdentityServer4 codebase work has begun on supporting .NET 8.0 with a goal of supporting .NET 10 upon release as a LTS.
Evolutionary Networking Designs (END) believes in maintaining an OIDC compatible SSO in C# to be valuable to the community as a whole.
It is this organizations goal to continue the development under the Apache 2.0 license.

## About IdentityServer4
[<img align="right" width="100px" src="https://dotnetfoundation.org/img/logo_big.svg" />](https://dotnetfoundation.org/projects?searchquery=IdentityServer&type=project)

IdentityServer is a free, open source [OpenID Connect](http://openid.net/connect/) and [OAuth 2.0](https://tools.ietf.org/html/rfc6749) framework for ASP.NET Core.
Originally Founded by [Dominick Baier](https://twitter.com/leastprivilege) and [Brock Allen](https://twitter.com/brocklallen), it is now maintained by Evolutionary Networking Designs (END). 
IdentityServer4 incorporates all the protocol implementations and extensibility points needed to integrate token-based authentication, single-sign-on and API access control in your applications.
The original codebase for IdentityServer4 was officially [certified](https://openid.net/certification/) by the [OpenID Foundation](https://openid.net) and thus spec-compliant and interoperable.
It is the goal of this project to recertify once the migration is completed.
It is licensed under [Apache 2](https://opensource.org/licenses/Apache-2.0) (an OSI approved license).

## Branch structure
Active development happens on the main branch. This always contains the latest version. Each (pre-) release is tagged with the corresponding version. The [aspnetcore1](https://github.com/IdentityServer/IdentityServer4/tree/aspnetcore1) and [aspnetcore2](https://github.com/IdentityServer/IdentityServer4/tree/aspnetcore2) branches contain the latest versions of the older ASP.NET Core based versions.

## How to build

* [Install](https://www.microsoft.com/net/download/core#/current) the latest .NET 8.0 SDK
* Install Git
* Clone this repo
* Run `build.sh` in the root of the cloned repo

## Documentation

## 2025-08-14

Updated documentation is currently being worked on

## Bug reports and feature requests
Please use the [issue tracker](https://github.com/IdentityServer/IdentityServer4/issues) for that. 

You can see a list of our current sponsors [here](https://github.com/IdentityServer/IdentityServer4/blob/main/SPONSORS.md) - and for companies we have some nice advertisement options as well.

## Acknowledgements
IdentityServer4 is built using the following great open source projects and free services:

* [ASP.NET Core](https://github.com/dotnet/aspnetcore)
* [Bullseye](https://github.com/adamralph/bullseye)
* [SimpleExec](https://github.com/adamralph/simple-exec)
* [MinVer](https://github.com/adamralph/minver)
* [Json.Net](http://www.newtonsoft.com/json)
* [XUnit](https://xunit.github.io/)
* [Fluent Assertions](http://www.fluentassertions.com/)
* [GitReleaseManager](https://github.com/GitTools/GitReleaseManager)

..and last but not least a big thanks to all our [contributors](https://github.com/Evolutionary-Networking-Designs/IdentityServer4-Modernization/graphs/contributors)!
