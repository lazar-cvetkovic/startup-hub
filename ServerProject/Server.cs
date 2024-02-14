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
using Common.Helpers;

namespace ServerProject
{
    public class Server
    {
        private List<ClientHandler> _clientHandlers;
        private Socket _socket;
        private FrmServer _serverForm;
        private bool _isServerRunning;

        public Server()
        {
            _clientHandlers = new List<ClientHandler>();
        }

        public void Start(FrmServer serverForm)
        {
            _serverForm = serverForm;
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            var endPoint = new IPEndPoint(IPAddress.Parse(ConfigurationManager.AppSettings["ip"]), 
                                          int.Parse(ConfigurationManager.AppSettings["port"]));

            _socket.Bind(endPoint);
            _socket.Listen(5);
            _isServerRunning = true;

            var thread = new Thread(AcceptClient);
            thread.Start();
        }

        internal void AcceptClient()
        {
            try
            {
                while (_isServerRunning)
                {
                    var clientSocket = _socket.Accept();
                    var handler = new ClientHandler(clientSocket, this);
                    _clientHandlers.Add(handler);
                    _serverForm.AddClientToTable(handler);

                    var clientThread = new Thread(handler.HandleRequest);
                    clientThread.Start();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        internal void RemoveClient(ClientHandler client)
        {
            _clientHandlers.Remove(client);
            _serverForm.RemoveClientInTable(client);
        }

        internal bool IsClientAlreadyLoggedIn(int id) => _clientHandlers.Any(c => c.Id == id);

        internal void Stop()
        {
            try
            {
                _socket.Close();
                _isServerRunning = false;

                _clientHandlers.ForEach(c => c.StopClientSocket());
                _clientHandlers.Clear();
            }
            catch (Exception e)
            {
                HelperMethods.ShowErrorMessage(e.Message);
            }
        }
    }

}
