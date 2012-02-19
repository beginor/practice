using System.Linq;
using GDEIC.AppFx.Hibernate;
using NHibernate;
using NHibernate.Linq;

namespace HttpWebApp.Models {

	public class NorthwindContext : HibernateContext {

		public NorthwindContext(string connectionString) : base(connectionString) {
		}

		public NorthwindContext(string connectionString, string[] assemblies) : base(connectionString, assemblies) {
		}

		public NorthwindContext(ISessionFactory factory) : base(factory) {
		}

		public IQueryable<Category> Categories {
			get {
				return this.Session.Query<Category>();
			}
		}

		public IQueryable<Product> Products {
			get {
				return this.Session.Query<Product>();
			}
		}
	}
}