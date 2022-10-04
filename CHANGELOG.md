# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [2.2.0] - 2022-10-04

### Changed

- Upgrade Atata.Cli package to v2.2.0.

## [2.1.0] - 2022-07-21

### Changed

- Update `NpmCli.IsItInstalled` method to check `ExitCode`.
- Upgrade Atata.Cli package to v2.1.0.
- Update `NpmCli.IsInstalled` and `NpmCli.GetInstalledVersion` methods to handle CLI command result safely.

## [2.0.0] - 2022-05-10

### Changed

- Upgrade Atata.Cli package to v2.0.0.

## [1.4.0] - 2022-03-25

### Changed

- Upgrade Atata.Cli package to v1.4.0.

## [1.3.0] - 2021-07-23

### Added

- Add `NpmNotFoundException` that is thrown by `NpmCli.EnsureItIsInstalled` method.

### Changed

- Upgrade Atata.Cli package to v1.3.0.

## [1.2.0] - 2021-07-21

### Changed

- Upgrade Atata.Cli package to v1.2.0.

## [1.1.0] - 2021-07-13

### Added

- Add method to `NpmCli`:
  ```cs
  public string GetInstalledVersion(string packageName, bool global = false);
  ```
- Add abstract `GlobalNpmPackageCli<TCli>` class with the following members:
  ```cs
  public string PackageName { get; }

  public TCli RequireVersion(string version);

  public TCli Install(string version = null);

  public virtual string GetInstalledVersion();
  ```

## [1.0.0] - 2021-06-25

Initial version release.