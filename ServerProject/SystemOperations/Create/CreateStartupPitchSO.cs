using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations.Create
{
    internal class CreateStartupPitchSO : SystemOperationBase
    {
        private StartupPitch _startupPitch;

        public CreateStartupPitchSO(StartupPitch startupEvent)
        {
            _startupPitch = startupEvent;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Insert(_startupPitch);
        }
    }
}
