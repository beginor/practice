using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;
using HttpWebApp.Models;

namespace HttpWebApp.Controllers {

	public class CategoryTestController : ApiController {
		
		private static readonly List<Category> Data = new List<Category> {
			new Category {
				CategoryID = 1,
				CategoryName = "Cat 1",
				Description = "Cat 1 Desc"
			},
			new Category {
				CategoryID = 2,
				CategoryName = "Cat 2",
				Description = "Cat 2 Desc"
			}, 
			new Category {
				CategoryID = 3,
				CategoryName = "Cat 3",
				Description = "Cat 3 Desc"
			}
		};

		public IQueryable<Category> GetAllCategories() {
			return Data.AsQueryable();
		}

		public Category GetCategoryById(int id) {
			var category = Data.FirstOrDefault(c => c.CategoryID == id);
			if (category == null) {
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
			}
			return category;
		}

		public HttpResponseMessage PostCategory(Category category) {
			var categoryId = Data.Max(c => c.CategoryID) + 1;
			category.CategoryID = categoryId;
			Data.Add(category);

			var message = new HttpResponseMessage(HttpStatusCode.Created) {
				Content = new ObjectContent<Category>(category, new JsonMediaTypeFormatter())
			};
			var url = Url.Route(null, new {
				id = categoryId
			});
			message.Headers.Location = new Uri(url, UriKind.Relative);
			return message;
		}

		public HttpResponseMessage PutCategory(int id, Category category) {
			var cat = Data.FirstOrDefault(c => c.CategoryID == id);
			if (cat == null) {
				throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
			}
			cat.CategoryName = category.CategoryName;
			cat.Description = category.Description + " (update at " + DateTime.Now + ")";
			return new HttpResponseMessage(HttpStatusCode.OK);
		}

		public HttpResponseMessage DeleteCategory(int id) {
			Data.RemoveAll(c => c.CategoryID == id);
			return new HttpResponseMessage(HttpStatusCode.NoContent);
		}
	}
}