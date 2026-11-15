<p align="center">
  <img width="200" alt="NosCore" src="icon.png"/>
</p>

<h1 align="center">NosCore.Injector</h1>

<p align="center">
  <a href="https://github.com/NosCoreIO/NosCore.Injector/actions/workflows/dotnet.yml"><img alt="Build" src="https://github.com/NosCoreIO/NosCore.Injector/actions/workflows/dotnet.yml/badge.svg?branch=master"/></a>
  <a href="https://discord.gg/Eu3ETSw"><img alt="Discord" src="https://img.shields.io/badge/Discord-join-5865F2?style=flat-square&logo=discord&logoColor=white"/></a>
  <a href="LICENSE"><img alt="MIT License" src="https://img.shields.io/badge/license-MIT-blue?style=flat-square"/></a>
</p>

Watches for NosTale client processes and injects a DLL, such as a packet logger, into each new one. For capturing
packets, [NosCore.DeveloperTools](https://github.com/NosCoreIO/NosCore.DeveloperTools) is the maintained tool; this
injector is kept for DLLs that only need loading.

## Configuration

[configuration/injector.yml](configuration/injector.yml):

```yaml
Language: en
ExecutableName: noscore-dev
PacketLoggerDllPath: C:\Program Files (x86)\Nostale\fr-FR\NLogger.dll
```

These are example values: set `ExecutableName` to your client's process name, without `.exe`, and
`PacketLoggerDllPath` to the DLL you want loaded. The injector checks for new processes every second, and ejects the
DLL from every client it injected when it stops.

## Building

```bash
dotnet build
dotnet build/net11.0/NosCore.Injector.dll
```

## Contributing

Questions, ideas and pull requests are welcome; most of the discussion happens on [Discord](https://discord.gg/Eu3ETSw).
It targets Windows only, since it works on the NosTale client's process. Any editor that handles .NET 11 works.
In Visual Studio, [Roslynator](https://github.com/dotnet/roslynator) and
[ReSharper](https://www.jetbrains.com/resharper/) help keep to the code style.

## Supporting NosCore

NosCore is a spare-time open source project. Sponsoring buys time spent on the emulator and the packages around it,
and gives the **Supporter** role on Discord.

<p>
  <a href="https://github.com/sponsors/0Lucifer0"><img alt="Sponsor on GitHub" src="https://img.shields.io/badge/GitHub-sponsor-EA4AAA?style=for-the-badge&logo=githubsponsors&logoColor=white"/></a>
  <a href="https://ko-fi.com/A3562BQV"><img alt="Support on Ko-fi" src="https://img.shields.io/badge/Ko--fi-support-FF5E5B?style=for-the-badge&logo=kofi&logoColor=white"/></a>
  <a href="https://www.patreon.com/bePatron?u=6503887"><img alt="Become a patron" src="https://img.shields.io/badge/Patreon-become_a_patron-F96854?style=for-the-badge&logo=patreon&logoColor=white"/></a>
</p>

Thanks to [Navicat](https://www.navicat.com) for supporting the project.

<a href="https://www.navicat.com"><img height="60" alt="Navicat" src="https://user-images.githubusercontent.com/35202750/207230064-dcf23adc-9e96-4481-9a53-cd212f5bd60e.png"/></a>

## Legal

NosCore is an independent, unofficial project for educational use. It is not affiliated with, authorized, maintained,
sponsored or endorsed by Gameforge or any of its affiliates; NosTale is a trademark of Gameforge. Using it may be
against the terms of service of NosTale servers.

Released under the [MIT License](LICENSE).
