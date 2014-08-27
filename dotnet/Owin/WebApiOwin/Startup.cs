using System;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace WebApiOwin {

    public class Startup {

        public void Configuration(IAppBuilder appBuilder) {
            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            appBuilder.UseWebApi(config);
        }
    }
}
