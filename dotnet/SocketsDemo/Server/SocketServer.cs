using System;
using System.Net;
using System.Net.Sockets;

namespace Server {

    public class SocketServer : IDisposable {

        Socket socket;

        readonly IPAddress ip;
        readonly int port;

        public IPAddress Ip {
            get { return ip; }
        }

        public int Port {
            get { return port; }
        }

        public bool Runing { get; private set; }

        public SocketServer(IPAddress ip, int port) {
            this.ip = ip;
            this.port = port;
        }

        public void Dispose() {
            Dispose(true);
        }

        protected void Dispose(bool disposing) {
            if (disposing) {
                if (Runing) {
                    Stop();
                }
            }
        }

        public void Start() {
            if (Runing) {
                throw new InvalidOperationException("Is already runing!");
            }
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var endPoint = new IPEndPoint(Ip, Port);
            socket.Bind(endPoint);
            socket.Listen(10);

            socket.BeginAccept()

            Runing = true;
        }

        void OnAccept(object sender, )

        void OnAccept(object sender, SocketAsyncEventArgs e) {
            var receiveEventArgs = new SocketAsyncEventArgs();
            receiveEventArgs.SetBuffer(new byte[1024], 0, 1024);
            receiveEventArgs.Completed += OnReceive;
            e.AcceptSocket.ReceiveAsync(receiveEventArgs);
            if (Runing && socket.Connected) {
                socket.AcceptAsync(e);
            }
        }

        void OnReceive(object sender, SocketAsyncEventArgs e) {
            var buff = e.Buffer;
            Console.Write(System.Text.Encoding.UTF8.GetString(buff));
        }

        public void Stop() {
            if (socket != null) {
                if (socket.Connected) {
                    socket.Disconnect(false);
                }
                socket.Dispose();
            }
            Runing = false;
        }
    }
}

