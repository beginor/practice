//using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcTest {

	public class Global : System.Web.HttpApplication {

		protected void Application_Start() {
			AreaRegistration.RegisterAllAreas();
			//RegisterApiRoutes(GlobalConfiguration.Configuration);
			//GlobalConfiguration.Configure(RegisterApiRoutes);
			RegisterGlobalFilters(GlobalFilters.Filters);
			RegisterRoutes(RouteTable.Routes);
		}

		private static void RegisterGlobalFilters(GlobalFilterCollection filters) {
			filters.Add(new HandleErrorAttribute());
		}
/*
		private static void RegisterApiRoutes(HttpConfiguration config) {
			// Web API configuration and services
			//config.DependencyResolver = 
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				 name: "DefaultApi",
				 routeTemplate: "api/{controller}/{id}",
				 defaults: new { id = RouteParameter.Optional }
			);
		}
*/
		private static void RegisterRoutes(RouteCollection routes) {
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			
			routes.MapMvcAttributeRoutes();

			routes.MapRoute(
				 name: "Default",
				 url: "{controller}/{action}/{id}",
				 defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
			);

            DependencyResolver.SetResolver(new UnityDependencyResolver());
		}
	}
}