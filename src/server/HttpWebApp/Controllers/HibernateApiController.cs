using System.Web.Http;
using GDEIC.AppFx.Hibernate;

namespace HttpWebApp.Controllers {

	public abstract class HibernateApiController<T> : ApiController where T : HibernateContext {

		public T HibernateContext {
			get;
			private set;
		}

		protected HibernateApiController(T hibernateContext) {
			this.HibernateContext = hibernateContext;
		}

		protected override void Dispose(bool disposing) {
			this.HibernateContext.DisposeSession();
			base.Dispose(disposing);
		}

	}

}