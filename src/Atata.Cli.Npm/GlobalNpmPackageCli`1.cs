namespace Atata.Cli.Npm;

/// <summary>
/// Represents the base class of specific npm package CLI.
/// </summary>
/// <typeparam name="TCli">The type of the specific CLI class that inherits <see cref="GlobalNpmPackageCli{TCli}"/>.</typeparam>
public abstract class GlobalNpmPackageCli<TCli> : ProgramCli<TCli>
    where TCli : GlobalNpmPackageCli<TCli>, new()
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GlobalNpmPackageCli{TCli}"/> class.
    /// </summary>
    /// <param name="packageName">Name of the package.</param>
    protected GlobalNpmPackageCli(string packageName)
        : base(packageName, true) =>
        PackageName = packageName;

    /// <summary>
    /// Gets the name of the npm package.
    /// </summary>
    public string PackageName { get; }

    /// <summary>
    /// Determines the installed version of the package and if this version is not equal to the specified version installs the needed one.
    /// </summary>
    /// <param name="version">The version.</param>
    /// <returns>The same instance.</returns>
    public TCli RequireVersion(string version)
    {
        Guard.ThrowIfNullOrWhitespace(version);

        string? installedVersion = GetInstalledVersion();

        if (installedVersion != version)
            Install(version);

        return (TCli)this;
    }

    /// <summary>
    /// Installs the specified package version.
    /// By default, the latest version installs if <paramref name="version"/> parameter is <see langword="null"/>.
    /// </summary>
    /// <param name="version">The version.</param>
    /// <returns>The same instance.</returns>
    public TCli Install(string? version = null)
    {
        CreateNpmCli()
            .Install(PackageName, version, global: true);

        return (TCli)this;
    }

    /// <summary>
    /// Gets the installed package version.
    /// </summary>
    /// <returns>The version string or <see langword="null"/>.</returns>
    public virtual string? GetInstalledVersion() =>
        CreateNpmCli()
            .GetInstalledVersion(PackageName, global: true);

    /// <summary>
    /// Creates the instance of <see cref="NpmCli"/> with the same <see cref="ProgramCli.WorkingDirectory"/> property value.
    /// </summary>
    /// <returns>The <see cref="NpmCli"/> instance.</returns>
    protected NpmCli CreateNpmCli() =>
        NpmCli.InDirectory(WorkingDirectory);
}
