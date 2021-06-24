using System.Text;

namespace Atata.Cli.Npm
{
    /// <summary>
    /// Represents the CLI of "npm" program.
    /// </summary>
    public class NpmCli : ProgramCli<NpmCli>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NpmCli"/> class.
        /// </summary>
        public NpmCli()
            : base("npm", true)
        {
        }

        /// <summary>
        /// Ensures NPM is installed.
        /// If it isn't, throws <see cref="CliCommandException"/>.
        /// </summary>
        /// <returns>The same instance.</returns>
        /// <exception cref="CliCommandException">NPM is not found. Ensure that Node.js and NPM are installed.</exception>
        public NpmCli EnsureItIsInstalled()
        {
            if (!IsItInstalled())
                throw new CliCommandException("NPM is not found. Ensure that Node.js and NPM are installed.");

            return this;
        }

        /// <summary>
        /// Determines whether NPM is installed.
        /// </summary>
        /// <returns>
        /// <see langword="true"/> if it is installed; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsItInstalled() =>
            string.IsNullOrEmpty(ExecuteRaw("-v").Error);

        /// <summary>
        /// Determines whether the specified package is installed.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="version">The version.</param>
        /// <param name="global">Is package global.</param>
        /// <returns>
        /// <see langword="true"/> if the specified package is installed; otherwise, <see langword="false"/>.
        /// </returns>
        public bool IsInstalled(string packageName, string version = null, bool global = false)
        {
            packageName.CheckNotNullOrWhitespace(packageName);

            StringBuilder commandText = new StringBuilder("ls");

            AddInstallationParameters(commandText, packageName, version, global);

            commandText.Append(" --depth=0");

            return Execute(commandText.ToString()).ExitCode == 0;
        }

        /// <summary>
        /// Installs the specified package.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="version">The version.</param>
        /// <param name="global">Is package global.</param>
        /// <returns>The same instance.</returns>
        public NpmCli Install(string packageName, string version = null, bool global = false)
        {
            packageName.CheckNotNullOrWhitespace(packageName);

            StringBuilder commandText = new StringBuilder("install");

            AddInstallationParameters(commandText, packageName, version, global);

            Execute(commandText.ToString());

            return this;
        }

        /// <summary>
        /// Determines whether the specified package is installed.
        /// If it isn't, installs the package.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="version">The version.</param>
        /// <param name="global">Is package global.</param>
        /// <returns>The same instance.</returns>
        public NpmCli InstallIfMissing(string packageName, string version = null, bool global = false)
        {
            if (!IsInstalled(packageName, version, global))
                Install(packageName, version, global);

            return this;
        }

        /// <summary>
        /// Uninstalls the specified package.
        /// </summary>
        /// <param name="packageName">Name of the package.</param>
        /// <param name="version">The version.</param>
        /// <param name="global">Is package global.</param>
        /// <returns>The same instance.</returns>
        public NpmCli Uninstall(string packageName, string version = null, bool global = false)
        {
            packageName.CheckNotNullOrWhitespace(packageName);

            StringBuilder commandText = new StringBuilder("uninstall");

            AddInstallationParameters(commandText, packageName, version, global);

            Execute(commandText.ToString());

            return this;
        }

        private static void AddInstallationParameters(StringBuilder commandText, string packageName, string version, bool global)
        {
            if (global)
                commandText.Append(" -g");

            commandText.Append($" {packageName}");

            if (!string.IsNullOrWhiteSpace(version))
                commandText.Append($"@{version}");
        }
    }
}
