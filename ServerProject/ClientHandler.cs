using Common.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject
{
    internal class ClientHandler
    {
        private Sender _sender;
        private Receiver _receiver;
        private Socket _socket;

        public ClientHandler(Socket socket)
        {
            _socket = socket;
            _sender = new Sender(socket);
            _receiver = new Receiver(socket);
        }

        public void HandleRequest()
        {
            while (true)
            {
                var request = (Request)_receiver.Receive();
                Response response = ProcessRequest(request);
                _sender.Send(response);
            }
        }

        private Response ProcessRequest(Request request)
        {
            var response = new Response();

            try
            {
                switch (request.Operation)
                {
                    
                }
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                Debug.WriteLine(ex.Message);
            }

            return response;
        }
    }
}
