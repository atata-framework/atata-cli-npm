using NUnit.Framework;

namespace Atata.Cli.Npm.IntegrationTests
{
    [TestFixture]
    public class NpmCliTests
    {
        private Subject<NpmCli> _sut;

        [SetUp]
        public void SetUpTest()
        {
            _sut = new NpmCli().ToSutSubject();
        }

        [Test]
        public void IsItInstalled_True()
        {
            _sut.ResultOf(x => x.IsItInstalled())
                .Should.BeTrue();
        }

        [Test]
        public void IsInstalledGlobally_True()
        {
            _sut.ResultOf(x => x.IsInstalled("npm", null, true))
                .Should.BeTrue();
        }

        [Test]
        public void IsInstalledGlobally_False()
        {
            _sut.ResultOf(x => x.IsInstalled("notexistingpackagename", null, true))
                .Should.BeFalse();
        }

        [Test]
        public void Install_True()
        {
            string packageName = "lodash";

            EnsureNotInstalledGlobally(packageName);

            _sut.Act(x => x.Install(packageName, null, true));

            _sut.ResultOf(x => x.IsInstalled(packageName, null, true))
                .Should.BeTrue();
        }

        [Test]
        public void Install_False()
        {
            string packageName = "notexistingpackagename";

            var exception = Assert.Throws<CliCommandException>(() =>
                _sut.Act(x => x.Install(packageName, null, true)));

            exception.ToResultSubject()
                .ValueOf(x => x.Message).Should.Contain(packageName);
        }

        private void EnsureNotInstalledGlobally(string packageName)
        {
            if (_sut.ResultOf(x => x.IsInstalled(packageName, null, true)))
            {
                _sut.Act(x => x.Uninstall(packageName, null, true));

                Assert.That(
                    () => !_sut.ResultOf(x => x.IsInstalled(packageName, null, true)),
                    $"Failed to uninstall {packageName} package.");
            }
        }
    }
}
