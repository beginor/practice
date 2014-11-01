using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Builder;
using Nowin;

namespace OwinApiHost {

    class Program {
        
        static void Main(string[] args) {
            var appBuilder = new AppBuilder();
            Nowin.OwinServerFactory.Initialize(appBuilder.Properties);

            var startup = new Startup();
            startup.Configuration(appBuilder);

            var builder = new ServerBuilder();
            const string ip = "127.0.0.1";
            const int port = 8888;
            builder.SetAddress(System.Net.IPAddress.Parse(ip)).SetPort(port)
                .SetOwinApp(appBuilder.Build())
                .SetOwinCapabilities((IDictionary<string, object>)appBuilder.Properties[OwinKeys.ServerCapabilitiesKey]);

            using (var server = builder.Build()) {

                Task.Run(() => server.Start());

                var baseAddress = "http://" + ip + ":" + port + "/";
                Console.WriteLine("Nowin server listening {0}, press ENTER to exit.", baseAddress);

                Console.ReadLine();
            }
        }
    }
}
