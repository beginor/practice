using System;
using Owin;

namespace Owin03_Middleware {

    public class Startup {

        public void Configuration(IAppBuilder appBuilder) {
            appBuilder.Use((async delegate(Microsoft.Owin.IOwinContext arg1, Func<System.Threading.Tasks.Task> arg2) {

            }));
        }
    }
}

