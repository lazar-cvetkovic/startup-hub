using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class Sender
    {
        private NetworkStream _stream;
        private BinaryFormatter _formatter;
        private Socket _socket;

        public Sender(Socket socket)
        {
            _socket = socket;
            _stream = new NetworkStream(socket);
            _formatter = new BinaryFormatter();
        }

        public void Send(object argument)
        {
            try
            {
                _formatter.Serialize(_stream, argument);
            }
            catch
            {
                Console.WriteLine("Caught an exception in Sender");
            }
        }

    }
}
