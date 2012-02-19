using System;
using System.IO;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using GDEIC.AppFx.Unity;
using log4net.Config;

namespace HttpWebApp {

	public class ApiApplication : System.Web.HttpApplication {

		public static readonly log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

		public static IObjectContainer ObjectContainer {
			get;
			private set;
		}

		protected void Application_Start(object sender, EventArgs e) {
			this.InitLog();
			this.RegisterObjectContainer();
			this.RegisterApiRoutes(RouteTable.Routes);
		}

		protected virtual void RegisterObjectContainer() {
			IObjectContainerFactory factory = new ObjectContainerFactory();
			var container = factory.CreateContainer(Server.MapPath("~/unity.config"));
			GlobalConfiguration.Configuration.ServiceResolver.SetResolver(new UnityDependencyResolver(container));
		}

		protected virtual void RegisterApiRoutes(RouteCollection routes) {
			// routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

			routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new {
					id = RouteParameter.Optional
				}
			);
		}

		protected virtual void InitLog() {
			XmlConfigurator.ConfigureAndWatch(new FileInfo(HttpContext.Current.Server.MapPath("~/log.config")));
		}
	}
}