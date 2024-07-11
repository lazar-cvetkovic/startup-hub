using Common.Domain;
using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations.Load
{
    internal class LoadStartupPitchSO : SystemOperationBase
    {
        public StartupPitch Result { get; private set; }
        private Dictionary<string, int> _startupPitchIds;

        public LoadStartupPitchSO(Dictionary<string, int> startupPitchIds)
        {
            _startupPitchIds = startupPitchIds;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupPitch();
            Result = _broker.FindById(prototype, _startupPitchIds) as StartupPitch;
        }
    }
}
