using System.Net.Http;
using System.Web.Http;
using HttpWebApp.Models;

namespace HttpWebApp.Controllers {

	public class CategoryTestController : ApiController {
		
		private static Category[] _data = new [] {
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

		public HttpResponseMessage<Category[]> GetAllCategories() {
			return new HttpResponseMessage<Category[]>(_data);
		}
	}
}