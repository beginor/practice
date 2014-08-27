using System;
using Owin;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using System.Net.Http;

namespace WebApiOwin {

    class Program {

        public static void Main(string[] args) {
            var baseAddress = "http://localhost:9000/";
            using (WebApp.Start<Startup>(baseAddress)) {
                // Create HttpCient and make a request to api/values 
                HttpClient client = new HttpClient(); 

                var response = client.GetAsync(baseAddress + "api/values").Result; 

                Console.WriteLine(response); 
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);

                Console.ReadLine();
            }
        }
    }

}
