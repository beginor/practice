using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HttpWebApp.Models;

namespace HttpWebApp.Controllers {

	public class CategoriesController : HibernateApiController<NorthwindContext> {

		public CategoriesController(NorthwindContext context) : base(context) {
		}

		public IQueryable<Category> GetAllCategories() {
			return this.HibernateContext.Categories;
		}

		public Category Get(int id) {
			if (id <= 0) {
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.BadRequest));
			}
			var category = this.HibernateContext.Categories.FirstOrDefault(c => c.CategoryID == id);
			if (category == null) {
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
			}
			return category;
		}
	}

}