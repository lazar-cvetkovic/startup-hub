using Common.Communication;
using Common.Domain;
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

        private const string ServerDownMessage = "Connection failed. Server is down at the moment.";

        private Socket _socket;
        private Sender _sender;
        private Receiver _receiver;
        private bool _isConnectedToServer;

        public bool IsConnectedToServer => _isConnectedToServer;

        private Communication() { }

        internal (bool isSuccessful, string errorMessage) Connect()
        {
            try
            {
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.Connect("127.0.0.1", 9999);

                _sender = new Sender(_socket);
                _receiver = new Receiver(_socket);

                _isConnectedToServer = true;
                return (true, null);
            }
            catch (Exception)
            {
                _isConnectedToServer = false;
                return (false, ServerDownMessage);
            }
        }

        internal Response SendServerRequest(object argument, Operation operation)
        {
            try
            {
                if (!_isConnectedToServer)
                {
                    var connectionResponse = Connect();
                    if (!connectionResponse.isSuccessful)
                    {
                        return new Response { Exception = new Exception(ServerDownMessage) };
                    }

                    _isConnectedToServer = true;
                }

                var request = new Request
                {
                    Argument = argument,
                    Operation = operation
                };

                _sender.Send(request);
                return (Response)_receiver.Receive();
            }
            catch (Exception)
            {
                return new Response { Exception = new Exception(ServerDownMessage) };
            }
        }

        internal Response Login(User argument) => SendServerRequest(argument, Operation.Login);

        internal Response CreateEventRegistration(StartupEventRegistration argument) => SendServerRequest(argument, Operation.CreateRegistration);
        internal Response CreateFundingProgram(FundingProgram argument) => SendServerRequest(argument, Operation.CreateFunding);
        internal Response CreateStartupEvent(StartupEvent argument) => SendServerRequest(argument, Operation.CreateEvent);
        internal Response CreateUser(User argument) => SendServerRequest(argument, Operation.CreateUser);

        internal Response DeleteStartupEvent(StartupEvent argument) => SendServerRequest(argument, Operation.DeleteEvent);

        internal Response FindEventRegistrations() => SendServerRequest(null, Operation.FindRegistrations);
        internal Response FindFundingPrograms() => SendServerRequest(null, Operation.FindFundings);
        internal Response FindStartupEvents() => SendServerRequest(null, Operation.FindEvents);

        internal Response LoadEventRegistration(Dictionary<string, int> argument) => SendServerRequest(argument, Operation.LoadRegistration);
        internal Response LoadFundingProgram(Dictionary<string, int> argument) => SendServerRequest(argument, Operation.LoadFunding);
        internal Response LoadStartupEvent(Dictionary<string, int> argument) => SendServerRequest(argument, Operation.LoadEvent);
        internal Response LoadStartupEventsCollection() => SendServerRequest(null, Operation.LoadEventsCollection);

        internal Response SaveEventRegistration(StartupEventRegistration argument) => SendServerRequest(argument, Operation.SaveRegistration);
        internal Response SaveFundingProgram(FundingProgram argument) => SendServerRequest(argument, Operation.SaveFunding);
        internal Response SaveStartupEvent(StartupEvent argument) => SendServerRequest(argument, Operation.SaveEvent);
        internal Response SaveUser(User argument) => SendServerRequest(argument, Operation.SaveUser);
    }
}
