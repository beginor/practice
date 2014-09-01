using System;
using Owin;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Owin03_Middleware {

    using AppFunc = Func<IDictionary<string, object>, Task>;

    public class Startup {

        public void Configuration(IAppBuilder appBuilder) {

            appBuilder.Run(async context => {
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync("Hello, world!");
            });
        }
    }
}

