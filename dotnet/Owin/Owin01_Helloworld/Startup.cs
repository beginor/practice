using System;
using Owin;
using Microsoft.Owin;
using Microsoft.Owin.Hosting;
using System.Threading.Tasks;

namespace Owin01_Helloworld {

    public class Startup {

        public void Configuration(IAppBuilder appBuilder) {
            appBuilder.Run(HandleRequest);
        }

        Task HandleRequest(IOwinContext context) {
            context.Response.ContentType = "text/plain";
            return context.Response.WriteAsync("Hello, world!");
        }
    }
}

