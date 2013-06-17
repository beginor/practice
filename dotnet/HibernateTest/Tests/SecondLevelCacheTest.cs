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
	public void TestGetEntity() {
		using (var session = this._sessionFactory.OpenSession()) {
			session.Get<Category>(1);
		}
		using (var session = this._sessionFactory.OpenSession()) {
			session.Get<Category>(1);
		}
	}

	[Test]
	public void TestHqlQuery() {
		using (var session = this._sessionFactory.OpenSession()) {
			var query = session.CreateQuery("from Category")
				.SetCacheMode(CacheMode.Normal)
				.SetCacheRegion("AllCategories")
				.SetCacheable(true);
			query.List<Category>();
		}
		using (var session = this._sessionFactory.OpenSession()) {
			var query = session.CreateQuery("from Category")
				.SetCacheMode(CacheMode.Normal)
				.SetCacheRegion("AllCategories")
				.SetCacheable(true);
			query.List<Category>();
		}
	}

	[Test]
	public void TestLinqQuery() {
		using (var session = this._sessionFactory.OpenSession()) {
			var query = session.Query<Category>()
				.Cacheable()
				.CacheMode(CacheMode.Normal)
				.CacheRegion("AllCategories");
			var result = query.ToList();
		}
		using (var session = this._sessionFactory.OpenSession()) {
			var query = session.Query<Category>()
				.Cacheable()
				.CacheMode(CacheMode.Normal)
				.CacheRegion("AllCategories");
			var result = query.ToList();
		}
	}

	[Test]
	public void TestQueryOver() {
		using (var session = this._sessionFactory.OpenSession()) {
			var query = session.QueryOver<Category>()
				.Cacheable()
				.CacheMode(CacheMode.Normal)
				.CacheRegion("AllCategories");
			query.List();
		}
		using (var session = this._sessionFactory.OpenSession()) {
			var query = session.QueryOver<Category>()
				.Cacheable()
				.CacheMode(CacheMode.Normal)
				.CacheRegion("AllCategories");
			query.List();
		}
	}
	}
}
