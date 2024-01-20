using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class FindStartupEventsSO : SystemOperationBase
    {
        public List<StartupEvent> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupEvent();
            var entities = _broker.GetAll(prototype);

            Result = entities.OfType<StartupEvent>().ToList();
        }
    }
}
