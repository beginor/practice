using System.Web.Mvc;

namespace LearningRazor.Controllers {

	public class TestController : Controller {
		
		public ActionResult Index() {
			return this.View();
		}
	}
}