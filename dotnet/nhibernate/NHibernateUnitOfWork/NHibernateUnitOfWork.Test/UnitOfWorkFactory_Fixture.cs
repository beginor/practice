using System;
using NHibernate;
using NUnit.Framework;

namespace NHibernateUnitOfWork.Test {

    [TestFixture]
    public class UnitOfWorkFactory_Fixture {

        private IUnitOfWorkFactory _factory;

        [SetUp]
        public void SetupContext() {
            _factory = (IUnitOfWorkFactory)Activator.CreateInstance(typeof(UnitOfWorkFactory), true);
        }

        [Test]
        public void Can_create_unit_of_work() {
            IUnitOfWork implementor = _factory.Create();
            Assert.IsNotNull(implementor);
            Assert.IsNotNull(_factory.CurrentSession);
            Assert.AreEqual(FlushMode.Commit, _factory.CurrentSession.FlushMode);
        }

        [Test]
        public void Can_configure_NHibernate() {
            var configuration = _factory.Configuration;
            Assert.IsNotNull(configuration);
            Assert.AreEqual("NHibernate.Connection.DriverConnectionProvider",
                            configuration.Properties["connection.provider"]);
            Assert.AreEqual("NHibernate.Dialect.MsSql2005Dialect",
                            configuration.Properties["dialect"]);
            Assert.AreEqual("NHibernate.Driver.SqlClientDriver",
                            configuration.Properties["connection.driver_class"]);
            Assert.AreEqual("Server=db-dev4.gdepb.gov.cn;Database=Test;User Id=udev;Password=devdev;",
                            configuration.Properties["connection.connection_string"]);
        }

        [Test]
        public void Can_create_and_access_session_factory() {
            var sessionFactory = _factory.SessionFactory;
            Assert.IsNotNull(sessionFactory);
        }

        [Test]
        public void Accessing_CurrentSession_when_no_session_open_throws() {
            try {
                var session = _factory.CurrentSession;
            }
            catch (InvalidOperationException) { }
        }

    }
}