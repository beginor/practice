using System;
using System.Net;
using System.Net.Sockets;

namespace Server {

    class MainClass {

        const string Ip = "127.0.0.1";
        const int Port = 8888;

        public static void Main(string[] args) {
            var server = new SocketServer(IPAddress.Parse(Ip), Port);
            server.Start();

            var input = string.Empty;
            while (input.ToLower() != "q") {
                Console.WriteLine("Enter 'Q' or 'q' to exit.");
                input = Console.ReadLine().ToLower();
            }
            server.Stop();
            server.Dispose();
        }

    }
}
