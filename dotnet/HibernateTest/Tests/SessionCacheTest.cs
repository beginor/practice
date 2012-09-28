using System;
using System.Linq;
using HibernateTest.Models;
using NHibernate.Linq;
using NUnit.Framework;
using NHibernate;
using NHibernate.Cfg;

namespace HibernateTest.Tests {

	[TestFixture]
	public class SessionCacheTest {

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
		public void TestQueryCategories() {
			using (var session = this._sessionFactory.OpenSession()) {
				var categories = session.Query<Category>().ToList();
				Assert.Greater(categories.Count, 0);
			}
		}

		[Test]
		public void TestSessionCache() {
			using (var session = this._sessionFactory.OpenSession()) {
				Console.WriteLine("First get category 1");
				var cat = session.Get<Category>(1);
				Console.WriteLine("{0}, {1}", cat.CategoryID, cat.CategoryName);
				Console.WriteLine("second get category 1");
				cat = session.Get<Category>(1);
				Console.WriteLine("{0}, {1}", cat.CategoryID, cat.CategoryName);
			}
		}

		[Test]
		public void TestSessionGet() {
			using (var session = this._sessionFactory.OpenSession()) {
				Console.WriteLine("Before Get Category");
				var cat = session.Get<Category>(1);
				Console.WriteLine("After Get Category");
			}
		}

		[Test]
		public void TestSessionLoad() {
			using (var session = this._sessionFactory.OpenSession()) {
				Console.WriteLine("Before Load Category");
				var cat = session.Load<Category>(1);
				Console.WriteLine("After Load Category");
				Console.WriteLine("{0}, {1}", cat.CategoryID, cat.CategoryName);
			}
		}

		[Test]
		public void TestSessionLambdaQuery() {
			using (var session = this._sessionFactory.OpenSession()) {
				(from c in session.Query<Category>()
				 where c.CategoryID == 1
				 select c).First();

				(from c in session.Query<Category>()
				 where c.CategoryID == 1
				 select c).First();
				var cat = session.Get<Category>(1);
			}
		}

		[Test]
		public void TestStatelessSession() {
			using (var session = this._sessionFactory.OpenStatelessSession()) {
				Console.WriteLine("First get category 1");
				var cat = session.Get<Category>(1);
				Console.WriteLine("{0}, {1}", cat.CategoryID, cat.CategoryName);
				Console.WriteLine("second get category 1");
				cat = session.Get<Category>(1);
				Console.WriteLine("{0}, {1}", cat.CategoryID, cat.CategoryName);
			}
		}
	}
}
