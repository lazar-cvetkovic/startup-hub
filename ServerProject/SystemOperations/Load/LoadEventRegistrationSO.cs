using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class LoadEventRegistrationSO : SystemOperationBase
    {
        public StartupEventRegistration Result { get; private set; }
        private Dictionary<string, int> _eventRegistrationIds;

        public LoadEventRegistrationSO(Dictionary<string, int> eventRegistrationIds)
        {
            _eventRegistrationIds = eventRegistrationIds;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupEventRegistration();
            Result = _broker.FindById(prototype, _eventRegistrationIds) as StartupEventRegistration;
        }
    }
}
