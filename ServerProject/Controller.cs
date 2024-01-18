using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject
{
    internal class Controller
    {
        private static Controller _instance = null;
        private static readonly object _lock = new object();

        public static Controller Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance = _instance ?? new Controller();
                    return _instance;
                }
            }
        }

        private Broker _broker;

        private Controller() => _broker = new Broker();


    }
}
