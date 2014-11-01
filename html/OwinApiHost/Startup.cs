using System;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Owin;
using Owin;
using OwinApiHost.Middlewares;

[assembly: OwinStartup(typeof(OwinApiHost.Startup))]

namespace OwinApiHost {

    public class Startup {

        public void Configuration(IAppBuilder app) {

            app.Use<LogOwinMiddleware>();

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
                );
            app.UseWebApi(config);
        }
    }
}
