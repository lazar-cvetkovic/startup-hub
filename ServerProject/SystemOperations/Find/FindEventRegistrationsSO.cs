using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class FindEventRegistrationsSO : SystemOperationBase
    {
        public List<StartupEventRegistration> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupEventRegistration();
            var entities = _broker.GetAll(prototype);

            Result = entities.OfType<StartupEventRegistration>().ToList();
        }
    }
}
