using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class SaveStartupEventSO : SystemOperationBase
    {
        private StartupEvent _startupEvent;

        public SaveStartupEventSO(StartupEvent startupEvent)
        {
            _startupEvent = startupEvent;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Update(_startupEvent);
        }
    }
}
