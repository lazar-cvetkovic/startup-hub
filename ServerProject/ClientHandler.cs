using Common.Communication;
using Common.Domain;
using Common.Helpers;
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
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        private Sender _sender;
        private Receiver _receiver;
        private Socket _socket;
        private Server _server;

        public ClientHandler(Socket socket, Server server)
        {
            _socket = socket;
            _sender = new Sender(socket);
            _receiver = new Receiver(socket);
            _server = server;
            Name = "Pending client";
            Email = "/";
        }

        public void HandleRequest()
        {
            while (true)
            {
                try
                {
                    var request = (Request)_receiver.Receive();
                    Response response = ProcessRequest(request);
                    _sender.Send(response);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    _server?.RemoveClient(this);
                    break;
                }
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
            try
            {
                if (request == null)
                {
                    return null;
                }

                switch (request.Operation)
                {
                    case Operation.Login:
                        return HandleLogin(request);

                    case Operation.CreateEvent:
                        Controller.Instance.CreateStartupEvent((StartupEvent)request.Argument);
                        return null;

                    case Operation.CreateFunding:
                        Controller.Instance.CreateFundingProgram((FundingProgram)request.Argument);
                        return null;

                    case Operation.CreateRegistration:
                        Controller.Instance.CreateEventRegistration((FullRegistration)request.Argument);
                        return null;

                    case Operation.CreateUser:
                        Controller.Instance.CreateUser((User)request.Argument);
                        return null;

                    case Operation.CreatePitch:
                        Controller.Instance.CreateStartupPitch((StartupPitch)request.Argument);
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

                    case Operation.FindPitches:
                        return Controller.Instance.FindStartupPitches();

                    case Operation.LoadEvent:
                        return Controller.Instance.LoadStartupEvent((Dictionary<string, int>)request.Argument);

                    case Operation.LoadFunding:
                        return Controller.Instance.LoadFundingProgram((Dictionary<string, int>)request.Argument);

                    case Operation.LoadRegistration:
                        return Controller.Instance.LoadEventRegistration((Dictionary<string, int>)request.Argument);

                    case Operation.LoadStartupEventQuestions:
                        return Controller.Instance.LoadStartupEventQuestions((Dictionary<string, int>)request.Argument);

                    case Operation.LoadPitch:
                        return Controller.Instance.LoadStartupPitch((Dictionary<string, object>)request.Argument); ;

                    case Operation.SaveEvent:
                        Controller.Instance.SaveStartupEvent((StartupEvent)request.Argument);
                        return null;

                    case Operation.SaveFunding:
                        Controller.Instance.SaveFundingProgram((FundingProgram)request.Argument);
                        return null;

                    case Operation.SaveRegistration:
                        Controller.Instance.SaveEventRegistration((FullRegistration)request.Argument);
                        return null;

                    case Operation.SaveUser:
                        Controller.Instance.SaveUser((User)request.Argument);
                        return null;

                    case Operation.SavePitch:
                        Controller.Instance.SaveStartupPitch((StartupPitch)request.Argument);
                        return null;

                    default:
                        return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private User HandleLogin(Request request)
        {
            var user = Controller.Instance.Login((User)request.Argument);

            if (user != null && _server.IsClientAlreadyLoggedIn(user.Id))
            {
                throw new Exception("User is already logged in.");
            }
            else if(user != null)
            {
                Id = user.Id;
                Name = user.Name;
                Email = user.Email;
            }

            return user;
        }

        public void StopClientSocket() => _socket.Close();
    }
}
