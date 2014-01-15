using System.Web.Mvc;
using System.Linq;

namespace MvcTest.Controllers {

    public class HomeController : Controller {

        public string Message {
            get;
            set;
        }

        public NorthwindContext Database {
            get;
            set;
        }

        public ActionResult Index() {
            ViewBag.Title = "Home Page";
            ViewBag.Message = Message;
            return View();
        }

        [Route("~/home/test")]
        public ActionResult AttrRouteTest() {
            return this.Content("Hello, returned by action attribute routing.");
        }

        [Route("~/home/cat")]
        public ActionResult Categories() {
            var data = Database.Categories.ToList();
            return this.View(data);
        }
    }
}