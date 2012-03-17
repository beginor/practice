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
			using (var trans = this.HibernateContext.Session.BeginTransaction()) {
				this.HibernateContext.Session.Update(product);
				trans.Commit();
			}
			var result = new HttpResponseMessage<Product>(product, HttpStatusCode.Created);
			var location = Url.Route(null, new {
				id = product.ProductID
			});
			result.Headers.Location = new Uri(location);
			return result;
		}

		public HttpResponseMessage PutProduct(int id, Product product) {
			using (var trans = this.HibernateContext.Session.BeginTransaction()) {
				product.ProductID = id;
				this.HibernateContext.Session.Save(product);
				trans.Commit();
			}
			return new HttpResponseMessage(HttpStatusCode.OK);
		}

		public HttpResponseMessage DeleteProduct(int id) {
			var product = this.HibernateContext.Products.FirstOrDefault(p => p.ProductID == id);
			if (product == null) {
				throw new HttpResponseException(HttpStatusCode.NotFound);
			}
			var trans = this.HibernateContext.Session.BeginTransaction();
			this.HibernateContext.Session.Delete(product);
			trans.Commit();
			return new HttpResponseMessage(HttpStatusCode.NoContent);
		}
	}
}