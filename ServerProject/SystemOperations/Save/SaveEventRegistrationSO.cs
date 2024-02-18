using Common.Domain;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class SaveEventRegistrationSO : SystemOperationBase
    {
        private FullRegistration _startupEventRegistration;

        public SaveEventRegistrationSO(FullRegistration startupEventRegistration)
        {
            _startupEventRegistration = startupEventRegistration;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Update(_startupEventRegistration.Registration);

            foreach (var question in _startupEventRegistration.Questions)
            {
                _broker.Update(question);
            }
        }
    }
}
