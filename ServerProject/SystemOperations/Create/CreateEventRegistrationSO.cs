using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class CreateEventRegistrationSO : SystemOperationBase
    {
        private FullRegistration _eventRegistration;

        public CreateEventRegistrationSO(FullRegistration eventRegistration)
        {
            _eventRegistration = eventRegistration;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Insert(_eventRegistration.Registration);

            foreach (var question in _eventRegistration.Questions)
            {
                _broker.Insert(question);
            }
        }
    }
}
