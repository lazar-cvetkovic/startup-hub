using Common.Domain;
using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace ServerProject.SystemOperations.Load
{
    internal class LoadStartupPitchSO : SystemOperationBase
    {
        public StartupPitch Result { get; private set; }
        private Dictionary<string, object> _columnAndValue;

        public LoadStartupPitchSO(Dictionary<string, object> columnAndValue)
        {
            _columnAndValue = columnAndValue;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new StartupPitch();
            var resultEntity = _broker.FindByColumns(prototype, _columnAndValue);

            Result = resultEntity as StartupPitch;
        }
    }
}
