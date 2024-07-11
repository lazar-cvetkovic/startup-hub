using Common.Domain;
using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations.Find
{
    internal class FindStartupPitchesSO : SystemOperationBase
    {
        public List<StartupPitch> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupPitch();
            var entities = _broker.GetAll(prototype);

            Result = entities.OfType<StartupPitch>().ToList();
        }
    }
}
