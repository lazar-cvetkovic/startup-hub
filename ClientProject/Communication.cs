using Common.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientProject
{
    internal class Communication
    {
        private static Communication _instance;
        public static Communication Instance
        {
            get
            {
                _instance = _instance ?? new Communication();
                return _instance;
            }
        }

        private Socket _socket;
        private Sender _sender;
        private Receiver _receiver;

        private Communication() { }

        public void Connect()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect("127.0.0.1", 9999);

            _sender = new Sender(_socket);
            _receiver = new Receiver(_socket);
        }

    }
}
