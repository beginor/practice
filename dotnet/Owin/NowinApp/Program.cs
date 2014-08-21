using System;
using Nowin;
using Microsoft.Owin.Builder;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NowinApp {

    class Program {

        public static void Main(string[] args) {
            var appBuilder = new AppBuilder();
            Nowin.OwinServerFactory.Initialize(appBuilder.Properties);

            var startup = new WebApiOwin.Startup();
            startup.Configuration(appBuilder);

            var builder = new ServerBuilder();
            builder.SetAddress(System.Net.IPAddress.Parse("127.0.0.1")).SetPort(8888)
                   .SetOwinApp(appBuilder.Build())
                   .SetOwinCapabilities((IDictionary<string, object>)appBuilder.Properties[OwinKeys.ServerCapabilitiesKey]);
            //Console.WriteLine("Hello World!");
            using (var server = builder.Build()) {

                Task.Run(() => server.Start());

                Console.WriteLine("Listening 127.0.0.1:8888");
                Console.ReadLine();
            }
        }
    }
}
