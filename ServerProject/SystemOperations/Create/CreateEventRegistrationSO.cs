using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class CreateEventRegistrationSO : SystemOperationBase
    {
        private StartupEventRegistration _eventRegistration;

        public CreateEventRegistrationSO(StartupEventRegistration eventRegistration)
        {
            _eventRegistration = eventRegistration;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Insert(_eventRegistration);
        }
    }
}
