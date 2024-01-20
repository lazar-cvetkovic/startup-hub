using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class LoadStartupEventSO : SystemOperationBase
    {
        public StartupEvent Result { get; private set; }
        private Dictionary<string, int> _startupEventIds;

        public LoadStartupEventSO(Dictionary<string, int> startupEventIds)
        {
            _startupEventIds = startupEventIds;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupEvent();
            Result = _broker.FindById(prototype, _startupEventIds) as StartupEvent;
        }
    }
}
