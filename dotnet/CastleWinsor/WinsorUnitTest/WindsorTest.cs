using Castle.Windsor;
using Castle.Windsor.Installer;
using NUnit.Framework;

namespace WinsorUnitTest {

    [TestFixture]
    public class WindsorTest<T> {

        protected IWindsorContainer Container { get; private set; } = null;

        public T Target => Container.Resolve<T>();

        [TestFixtureSetUp]
        public void SetUp() {
            var container = new WindsorContainer();
            var xmlInstaller = Configuration.FromXmlFile("windsor.xml");
            container.Install(xmlInstaller);
            Container = container;
        }

        [TestFixtureTearDown]
        public void TearDown() {
            Container.Dispose();
        }

    }
}
