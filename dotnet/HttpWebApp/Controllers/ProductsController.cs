using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using HttpWebApp.Models;
using Newtonsoft.Json;

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
				var msg = new HttpResponseMessage(HttpStatusCode.NotFound);
				throw new HttpResponseException(msg);
			}
			return product;
		}

		public HttpResponseMessage PostProduct(Product product) {
			this.HibernateContext.Session.Save(product);
			var result = new HttpResponseMessage(HttpStatusCode.Created);
			var formatter = new JsonMediaTypeFormatter {
				SerializerSettings = {
					Formatting = Formatting.Indented
				}
			};
			result.Content = new ObjectContent<Product>(product, formatter, formatter.SupportedMediaTypes.First().MediaType);
			var location = Url.Route(null, new {
				id = product.ProductID
			});
			result.Headers.Location = new Uri(location);
			return result;
		}

		public HttpResponseMessage PutProduct(int id, Product product) {
			if (this.HibernateContext.Products.All(p => p.ProductID != id)) {
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
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