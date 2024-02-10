using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace ServerProject
{
    public class Server
    {
        private static Server _instance = null;
        private static readonly object _lock = new object();

        public static Server Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance = _instance ?? new Server();
                    return _instance;
                }
            }
        }

        Socket _socket;

        private Server()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), 
                                          int.Parse(ConfigurationManager.AppSettings["port"]));

            _socket.Bind(endPoint);
            _socket.Listen(5);

            var thread = new Thread(AcceptClient);
            thread.Start();
        }

        public void AcceptClient()
        {
            try
            {
                while (true)
                {
                    var clientSocket = _socket.Accept();
                    var handler = new ClientHandler(clientSocket);

                    var clientThread = new Thread(handler.HandleRequest);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }


        public void Stop()
        {
            _socket.Close();
        }

    }

}
