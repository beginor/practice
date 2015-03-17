using System;
using NUnit.Framework;
using System.Collections.Generic;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.Mapping.ByCode;
using NhCfgEnv = NHibernate.Cfg.Environment;
using System.Linq;

namespace ManyToManyUpdate {

    [TestFixture]
    public class UnitTest {

        [Test]
        public void TestConfig() {
            var config = BuildSessionFactory();
            var sessionFactory = config.BuildSessionFactory();
            Assert.IsNotNull(sessionFactory);
        }

        [Test]
        public void TestSave() {
            var config = BuildSessionFactory();
            var sessionFactory = config.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession()) {

                var user1 = new User { Name = "User 1" };
                session.Save(user1);
                //session.Flush();

                var user2 = new User { Name = "User 2" };
                session.Save(user2);
                //session.Flush();

                var role1 = new Role { Name = "Role 1" };
                session.Save(role1);
                var role2 = new Role { Name = "Role 2" };
                session.Save(role2);

                user1.Roles.Add(role1);
                user1.Roles.Add(role2);
                session.Update(user1);

                user2.Roles.Add(role1);
                user2.Roles.Add(role2);
                session.Update(user2);

                session.Flush();
            }
        }

        [Test]
        public void TestUpdate() {
            var config = BuildSessionFactory();
            var sessionFactory = config.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession()) {
                var user = session.Query<User>().First();

                var role5 = session.Get<Role>(5);

                user.Roles.Remove(role5);

                var role2 = session.Get<Role>(2);
                user.Roles.Add(role2);

                var roleCount = session.Query<Role>().Count();
                var role = new Role { Name = "Role " + (roleCount + 1) };
                session.Save(role);

                user.Roles.Add(role);
                session.Update(user);

                session.Update(user);
                session.Flush();
            }
        }

        [Test]
        public void TestDelete() {
            var config = BuildSessionFactory();
            var sessionFactory = config.BuildSessionFactory();

            using (var session = sessionFactory.OpenSession()) {
                var user = session.Query<User>().First();
                user.Roles.Remove(user.Roles.First());
                session.Update(user);
                session.Flush();
            }
        }

        static Configuration BuildSessionFactory() {
            var config = new Configuration();
            config.SetProperties(CreateSessionFactoryDefaultProperties());
            config.SetProperty(NhCfgEnv.ConnectionString, "Data Source=db-dev4.gdepb.gov.cn;Initial Catalog=Test;Persist Security Info=True;User ID=udev;Password=devdev");
            var mapper = new ConventionModelMapper();
            mapper.AddMapping(new UserMapping());
            mapper.AddMapping(new RoleMapping());
            var mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            config.AddMapping(mapping);
            return config;
        }

        private static IDictionary<string, string> CreateSessionFactoryDefaultProperties() {
            var defaultProperties = new Dictionary<string, string> {
                { NhCfgEnv.ConnectionString, string.Empty },
                { NhCfgEnv.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider" },
                { NhCfgEnv.ConnectionDriver, "NHibernate.Driver.SqlClientDriver" },
                { NhCfgEnv.Dialect, "NHibernate.Dialect.MsSql2005Dialect" },
                { NhCfgEnv.ProxyFactoryFactoryClass, "NHibernate.Bytecode.DefaultProxyFactoryFactory, NHibernate" },
                { NhCfgEnv.FormatSql, bool.TrueString },
                { NhCfgEnv.ShowSql, bool.TrueString },
                { NhCfgEnv.BatchSize, "0" }
            };
            return defaultProperties;
        }
    }
}

