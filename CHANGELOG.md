# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## Unreleased

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