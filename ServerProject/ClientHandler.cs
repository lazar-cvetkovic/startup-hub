using Common.Communication;
using Common.Domain;
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
                response.Result = ExecuteRequest(request);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
                Debug.WriteLine(ex.Message);
            }

            return response;
        }

        private object ExecuteRequest(Request request)
        {
            switch (request.Operation)
            {
                case Operation.Login:
                    return null;

                case Operation.CreateEvent:
                    Controller.Instance.CreateStartupEvent((StartupEvent)request.Argument);
                    return null;
                    
                case Operation.CreateFunding:
                    Controller.Instance.CreateFundingProgram((FundingProgram)request.Argument);
                    return null;

                case Operation.CreateRegistration:
                    Controller.Instance.CreateEventRegistration((StartupEventRegistration)request.Argument);
                    return null;

                case Operation.CreateUser:
                    Controller.Instance.CreateUser((User)request.Argument);
                    return null;

                case Operation.DeleteEvent:
                    Controller.Instance.DeleteStartupEvent((StartupEvent)request.Argument);
                    return null;

                case Operation.FindEvents:
                    return Controller.Instance.FindStartupEvents();

                case Operation.FindFundings:
                    return Controller.Instance.FindFundingPrograms();

                case Operation.FindRegistrations:
                    return Controller.Instance.FindEventRegistrations();

                case Operation.LoadEvent:
                    return Controller.Instance.LoadStartupEvent((Dictionary<string, int>)request.Argument);

                case Operation.LoadFunding:
                    return Controller.Instance.LoadFundingProgram((Dictionary<string, int>)request.Argument);

                case Operation.LoadRegistration:
                    return Controller.Instance.LoadEventRegistration((Dictionary<string, int>)request.Argument);

                case Operation.LoadEventsCollection:
                    return Controller.Instance.LoadStartupEventsCollection();

                case Operation.SaveEvent:
                    Controller.Instance.SaveStartupEvent((StartupEvent)request.Argument);
                    return null;

                case Operation.SaveFunding:
                    Controller.Instance.SaveFundingProgram((FundingProgram)request.Argument);
                    return null;

                case Operation.SaveRegistration:
                    Controller.Instance.SaveEventRegistration((StartupEventRegistration)request.Argument);
                    return null;

                case Operation.SaveUser:
                    Controller.Instance.SaveUser((User)request.Argument);
                    return null;

                default:
                    return null;
            }
        }

        public void StopClientSocket() => _socket.Close();
    }
}
