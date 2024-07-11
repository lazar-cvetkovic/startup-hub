using Common.Domain;
using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations.Save
{
    internal class SaveStartupPitchSO : SystemOperationBase
    {
        private StartupPitch _startupPitch;

        public SaveStartupPitchSO(StartupPitch startupPitch)
        {
            _startupPitch = startupPitch;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Update(_startupPitch);
        }
    }
}
