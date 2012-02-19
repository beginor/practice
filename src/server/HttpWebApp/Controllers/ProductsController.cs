using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using HttpWebApp.Models;

namespace HttpWebApp.Controllers {

	public class ProductsController : HibernateApiController<NorthwindContext> {

		public ProductsController(NorthwindContext context) : base(context) {
		}

		public IQueryable<Product> GetAll() {
			return this.HibernateContext.Products;
		}

		public HttpResponseMessage<Product> GetById(int id) {
			var product = this.HibernateContext.Products.FirstOrDefault(p => p.ProductID == id);
			
			var formatters = new MediaTypeFormatter[] {
				new XmlMediaTypeFormatter(), 
				new JsonMediaTypeFormatter()
			};

			if (product == null) {
				throw new HttpResponseException("not  found your id.", HttpStatusCode.NotFound);
			}
			
			return new HttpResponseMessage<Product>(product, formatters);
		}

		public HttpResponseMessage<Product> Post(int id, Product product) {
			throw new HttpResponseException("Not implemented", HttpStatusCode.NotImplemented);
		}
	}
}