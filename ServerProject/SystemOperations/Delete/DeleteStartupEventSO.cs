using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class DeleteStartupEventSO : SystemOperationBase
    {
        private StartupEvent _startupEvent;

        public DeleteStartupEventSO(StartupEvent startupEvent)
        {
            _startupEvent = startupEvent;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Delete(_startupEvent);
        }
    }
}
