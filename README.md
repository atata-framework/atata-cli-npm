# Atata.Cli.Npm

[![NuGet](http://img.shields.io/nuget/v/Atata.Cli.Npm.svg?style=flat)](https://www.nuget.org/packages/Atata.Cli.Npm/)
[![GitHub release](https://img.shields.io/github/release/atata-framework/atata-cli-npm.svg)](https://github.com/atata-framework/atata-cli-npm/releases)
[![Build status](https://dev.azure.com/atata-framework/atata-cli-npm/_apis/build/status/atata-cli-npm-ci?branchName=main)](https://dev.azure.com/atata-framework/atata-cli-npm/_build/latest?definitionId=44&branchName=main)
[![Slack](https://img.shields.io/badge/join-Slack-green.svg?colorB=4EB898)](https://join.slack.com/t/atata-framework/shared_invite/zt-5j3lyln7-WD1ZtMDzXBhPm0yXLDBzbA)
[![Atata docs](https://img.shields.io/badge/docs-Atata_Framework-orange.svg)](https://atata.io)
[![X](https://img.shields.io/badge/follow-@AtataFramework-blue.svg)](https://x.com/AtataFramework)

**Atata.Cli.Npm** is a C#/.NET library that provides an API for [npm](https://www.npmjs.com/).

*The package targets .NET 8.0 and .NET Framework 4.6.2.*

## Features

- Checks whether npm is installed.
- Checks whether package is installed.
- Gets installed package version.
- Installs package.
- Uninstalls package.

## Installation

Install [`Atata.Cli.Npm`](https://www.nuget.org/packages/Atata.Cli.Npm/) NuGet package.

- Package Manager:
  ```
  Install-Package Atata.Cli.Npm
  ```

- .NET CLI:
  ```
  dotnet add package Atata.Cli.Npm
  ```

## Usage

The main class is `NpmCli` located in `Atata.Cli.Npm` namespace.

There is also `GlobalNpmPackageCli<TCli>`, which can be used as a base class of specific npm package CLI.

### Check npm is installed

```cs
bool isNpmInstalled = new NpmCli()
    .IsItInstalled();
```

### Ensure npm is installed

```cs
new NpmCli()
    .EnsureItIsInstalled();
```

If npm isn't installed, throws `NpmNotFoundException`.

### Install package into directory

```cs
NpmCli.InDirectory("some/dir")
    .Install("npm-package-name-1")
    .Install("npm-package-name-2", "1.2.3");
```

### Install package globally

```cs
new NpmCli()
    .Install("html-validate", global: true);
```

### Install package if missing

```cs
NpmCli.InBaseDirectory()
    .InstallIfMissing("html-validate", global: true);
```

### Check package is installed

```cs
bool isPackageInstalled = new NpmCli()
    .IsInstalled("html-validate", global: true);
```

### Check specific package version is installed

```cs
bool isPackageVersionInstalled = new NpmCli()
    .IsInstalled("html-validate", "5.0.0", global: true);
```

### Get installed package version

```cs
string? packageVersion = new NpmCli()
    .GetInstalledVersion("html-validate", global: true);
```

### Uninstall package

```cs
new NpmCli()
    .Uninstall("html-validate", global: true);
```

## Community

- Slack: [https://atata-framework.slack.com](https://join.slack.com/t/atata-framework/shared_invite/zt-5j3lyln7-WD1ZtMDzXBhPm0yXLDBzbA)
- X: https://x.com/AtataFramework
- Stack Overflow: https://stackoverflow.com/questions/tagged/atata

## Feedback

Any feedback, issues and feature requests are welcome.

If you faced an issue please report it to [Atata.Cli.Npm Issues](https://github.com/atata-framework/atata-cli-npm/issues),
[ask a question on Stack Overflow](https://stackoverflow.com/questions/ask?tags=atata+csharp) using [atata](https://stackoverflow.com/questions/tagged/atata) tag
or use another [Atata Contact](https://atata.io/contact/) way.

## Contact author

Contact me, Yevhenii Shunevych, if you need help with test automation using the Atata Framework.
You can [hire me for test automation development or consulting](https://atata.io/consulting/) if you are looking for a high-quality, maintainable automation solution for your project.

- LinkedIn: https://www.linkedin.com/in/yevgeniy-shunevych
- Email: yevgeniy.shunevych@gmail.com
- Consulting: https://atata.io/consulting/

## Sponsorship

Many thanks to the sponsors that regularly support the development of Atata Framework through donations:

- **[Lombiq Technologies](https://lombiq.com/)**

If Atata Framework is useful to you or your company, consider supporting the framework development with a [donation](https://atata.io/donate/).

## Contributing

Check out [Contributing Guidelines](CONTRIBUTING.md) for details.

## SemVer

Atata Framework follows [Semantic Versioning 2.0](https://semver.org/).
Thus backward compatibility is followed and updates within the same major version
(e.g. from 1.3 to 1.4) should not require code changes.

## License

Atata is an open source software, licensed under the Apache License 2.0.
See [LICENSE](LICENSE) for details.
