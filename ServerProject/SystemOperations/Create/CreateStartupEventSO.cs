using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class CreateStartupEventSO : SystemOperationBase
    {
        private StartupEvent _startupEvent;

        public CreateStartupEventSO(StartupEvent startupEvent)
        {
            _startupEvent = startupEvent;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Insert(_startupEvent);
        }
    }
}
