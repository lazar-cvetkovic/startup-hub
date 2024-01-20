using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class SaveEventRegistrationSO : SystemOperationBase
    {
        private StartupEventRegistration _startupEventRegistration;

        public SaveEventRegistrationSO(StartupEventRegistration startupEventRegistration)
        {
            _startupEventRegistration = startupEventRegistration;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Update(_startupEventRegistration);
        }
    }
}
