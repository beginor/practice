using System;
using System.Linq;
using NHibernate;
using NHibernate.AdoNet;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.MySQLBatcher;
using NHibernateBatchTest.Data;
using NUnit.Framework;
using Environment = NHibernate.Cfg.Environment;
using System.Diagnostics;

namespace NHibernateBatchTest {

    [TestFixture]
    public class MySqlBatchTest {

        private ISessionFactory sessionFactory;

        private Random random;

        private const int InsertCount = 10000;

        [TestFixtureSetUp]
        public void FixtureSetUp() {
            var cfg = new Configuration();
            cfg.SetProperty(Environment.ConnectionString, "Server=172.21.24.15;Database=test_db;Uid=udev;Pwd=devdev;");
            cfg.SetProperty(Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
            cfg.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.MySqlDataDriver");
            cfg.SetProperty(Environment.Dialect, "NHibernate.Dialect.MySQL5Dialect");
            cfg.SetProperty(Environment.UseSecondLevelCache, "false");
            cfg.SetProperty(Environment.UseQueryCache, "false");
            cfg.SetProperty(Environment.GenerateStatistics, "false");
            cfg.SetProperty(Environment.CommandTimeout, "500");
            cfg.SetProperty(Environment.BatchSize, "0");
            //cfg.SetProperty(Environment.BatchStrategy, typeof(MySqlClientBatchingBatcherFactory).AssemblyQualifiedName);
            cfg.AddAssembly(typeof(MySqlBatchTest).Assembly);

            sessionFactory = cfg.BuildSessionFactory();

            random = new Random();
        }

        [Test]
        public void Test_0_CanQuery() {
            using (var session = sessionFactory.OpenSession()) {
                var dataCount = session.Query<TestData>().Count();
                Assert.True(dataCount >= 0);
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
            Console.WriteLine("MySqlBatchTest Test_1_BlockInsertWithSession: " + watch.Elapsed);
        }

        [Test, Ignore]
        public void Test_2_BlockInsertWithStatelessSession() {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            using (var session = sessionFactory.OpenStatelessSession()) {
                //session.SetBatchSize(1000);
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
            watch.Stop();
            Console.WriteLine("MySqlBatchTest Test_2_BlockInsertWithStatelessSession: " + watch.Elapsed);
        }

    }
}