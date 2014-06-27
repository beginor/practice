using System;
using System.Security.Policy;
using System.Net;
using System.IO;
using System.Globalization;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace IgnoreSslCert {

    class MainClass {

        const string SslServer = "https://app-inter.gdepb.gov.cn/go";

        public static void Main(string[] args) {
            //ConnectWithHttpWebRequest();
            ConnectWithHttpClient();
            Console.ReadKey();
        }

        public static async void ConnectWithHttpWebRequest() {
            try {
                HttpWebRequest request = WebRequest.CreateHttp(SslServer);
                request.Method = "GET";

                request.ServerCertificateValidationCallback = (sender, cert, chain, error) => {
                    Console.WriteLine("Cert from [{0}] is invalid, ignore it.", cert.Issuer);
                    Console.WriteLine();
                    return true;
                };

                var response = await request.GetResponseAsync();
                var stream = response.GetResponseStream();

                using (var reader = new StreamReader(stream)) {
                    var content = await reader.ReadToEndAsync();
                    Console.WriteLine(content);
                }

                response.Close();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public static async void ConnectWithHttpClient() {
            try {
                var handler = new WebRequestHandler {
                    ServerCertificateValidationCallback = (sender, cert, chain, error) => {
                        Console.WriteLine("Cert from [{0}] is invalid, ignore it.", cert.Issuer);
                        Console.WriteLine();
                        return true;
                    }
                };
                var httpClient = new HttpClient(handler);
                var request = new HttpRequestMessage(HttpMethod.Get, SslServer);
                var response = await httpClient.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                response.Dispose();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

    }
}
