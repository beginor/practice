using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace LearningMvc.Controllers {

	public class HomeController : Controller {

		public ActionResult Index() {
			return this.Content("<h2>Hello,world!</h2>");
		}

		public ActionResult Test() {
			return this.View();
		}
	}
}