using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using HttpWebApp.Models;

namespace HttpWebApp.Controllers {

	public class ProductsController : HibernateApiController<NorthwindContext> {

		public ProductsController(NorthwindContext context)
			: base(context) {
		}

		public IQueryable<Product> GetAllProducts() {
			return this.HibernateContext.Products;
		}

		public Product GetProductById(int id) {
			var product = this.HibernateContext.Products.FirstOrDefault(p => p.ProductID == id);
			if (product == null) {
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			return product;
		}

		public HttpResponseMessage<Product> PostProduct(Product product) {
			this.HibernateContext.Session.Save(product);
			var result = new HttpResponseMessage<Product>(product, HttpStatusCode.Created);
			var location = Url.Route(null, new {
				id = product.ProductID
			});
			result.Headers.Location = new Uri(location);
			return result;
		}

		public HttpResponseMessage PutProduct(int id, Product product) {
			if (!this.HibernateContext.Products.Any(p => p.ProductID == id)) {
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			product.ProductID = id;
			this.HibernateContext.Update(product);
			return new HttpResponseMessage(HttpStatusCode.OK);
		}

		public HttpResponseMessage DeleteProduct(int id) {
			var product = this.HibernateContext.Products.FirstOrDefault(p => p.ProductID == id);
			this.HibernateContext.Delete(product);
			return new HttpResponseMessage(HttpStatusCode.NoContent);
		}
	}
}