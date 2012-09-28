using System;
using System.Linq;
using HibernateTest.Models;
using NHibernate.Linq;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;

namespace HibernateTest.Tests {

	[TestFixture]
	public class SecondLevelCacheTest {

		private ISessionFactory _sessionFactory;

		[TestFixtureSetUp]
		public void SetUp() {
			if (this._sessionFactory == null) {
				var cfg = new Configuration();
				cfg.Configure();
				this._sessionFactory = cfg.BuildSessionFactory();
			}
		}

		[Test]
		public void TestConfig() {
			Assert.IsNotNull(this._sessionFactory);
		}

		[Test]
		public void TestLambdaQuery() {
			
		}
	}
}
