﻿using System;
using System.Linq;
using NHibernate;
using NHibernate.AdoNet;
using NHibernate.Cfg;
using NHibernate.Linq;
using NHibernate.MySQLBatcher;
using NHibernateBatchTest.Data;
using NUnit.Framework;
using Environment = NHibernate.Cfg.Environment;

namespace NHibernateBatchTest {

    [TestFixture]
    public class MySqlBatchTest {

        private ISessionFactory sessionFactory;

        private Random random;

        private const int InsertCount = 10000;

        [TestFixtureSetUp]
        public void FixtureSetUp() {
            var cfg = new Configuration();
            cfg.SetProperty(Environment.ConnectionString, "Server=127.0.0.1;Database=test_db;Uid=root;Pwd=root;");
            cfg.SetProperty(Environment.ConnectionProvider, "NHibernate.Connection.DriverConnectionProvider");
            cfg.SetProperty(Environment.ConnectionDriver, "NHibernate.Driver.MySqlDataDriver");
            cfg.SetProperty(Environment.Dialect, "NHibernate.Dialect.MySQL5Dialect");
            cfg.SetProperty(Environment.UseSecondLevelCache, "false");
            cfg.SetProperty(Environment.UseQueryCache, "false");
            cfg.SetProperty(Environment.GenerateStatistics, "false");
            cfg.SetProperty(Environment.CommandTimeout, "500");
            cfg.SetProperty(Environment.BatchSize, "10");
            cfg.SetProperty(Environment.BatchStrategy, typeof(MySqlClientBatchingBatcherFactory).AssemblyQualifiedName);
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
        }

        [Test]
        public void Test_2_BlockInsertWithStatelessSession() {
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
        }

    }
}