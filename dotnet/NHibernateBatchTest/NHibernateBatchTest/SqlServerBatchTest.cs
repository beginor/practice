using System;
using System.Linq;
using NHibernate;
using NHibernate.AdoNet;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernateBatchTest.Data;
using NUnit.Framework;
using Environment = NHibernate.Cfg.Environment;
using System.Diagnostics;

namespace NHibernateBatchTest {

    [TestFixture]
    public class SqlServerBatchTest {

        private ISessionFactory sessionFactory;

        private Random random;

        private const int InsertCount = 10000;

        [TestFixtureSetUp]
        public void FixtureSetUp() {
            var cfg = new Configuration();
            cfg.SetProperty(Environment.ConnectionString, "Data Source=db-dev4.gdepb.gov.cn;Initial Catalog=Test;User ID=udev;Password=devdev");
            cfg.SetProperty(Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
            cfg.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.SqlClientDriver");
            cfg.SetProperty(Environment.Dialect, "NHibernate.Dialect.MsSql2008Dialect");
            cfg.SetProperty(Environment.UseSecondLevelCache, "false");
            cfg.SetProperty(Environment.UseQueryCache, "false");
            cfg.SetProperty(Environment.GenerateStatistics, "false");
            cfg.SetProperty(Environment.CommandTimeout, "500");
            cfg.SetProperty(Environment.BatchSize, "0");
            //cfg.SetProperty(Environment.BatchStrategy, typeof(SqlClientBatchingBatcherFactory).AssemblyQualifiedName);
            cfg.AddAssembly(typeof(SqlServerBatchTest).Assembly);

            sessionFactory = cfg.BuildSessionFactory();

            random = new Random();
        }

        [Test]
        public void Test_0_CanQuery() {
            try {
                using (var session = sessionFactory.OpenSession()) {
                    var dataCount = session.Query<TestData>().Count();
                    Assert.True(dataCount >= 0);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        [Test]
        public void Test_1_BlockInsertWithSession() {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            using (var session = sessionFactory.OpenSession()) {
                for (int i = 0; i < InsertCount; i++) {
                    var data = new TestData {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Test Data " + i,
                        Data1 = random.Next(),
                        Data2 = random.Next(),
                        Data3 = random.NextDouble(),
                        UpdateTime = DateTime.Now
                    };
                    session.Save(data);
                }
                session.Flush();
                session.Clear();
            }
            watch.Stop();
            Console.WriteLine("SqlServerBatchTest Test_1_BlockInsertWithSession: " + watch.Elapsed);
        }

        [Test, Ignore]
        public void Test_2_BlockInsertWithStatelessSession() {
            using (var session = sessionFactory.OpenStatelessSession()) {
                session.SetBatchSize(1);
                for (int i = 0; i < InsertCount; i++) {
                    var data = new TestData {
                        Id = Guid.NewGuid().ToString(),
                        Name = "Test Data " + i,
                        Data1 = random.Next(),
                        Data2 = random.Next(),
                        Data3 = random.NextDouble(),
                        UpdateTime = DateTime.Now
                    };
                    session.Insert(data);
                }
            }
        }

    }
}