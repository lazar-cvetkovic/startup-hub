using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class LoadFundingProgramSO : SystemOperationBase
    {
        public FundingProgram Result { get; private set; }
        private Dictionary<string, int> _fundingProgramIds;

        public LoadFundingProgramSO(Dictionary<string, int> fundingProgramIds)
        {
            _fundingProgramIds = fundingProgramIds;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new FundingProgram();
            Result = _broker.FindById(prototype, _fundingProgramIds) as FundingProgram;
        }
    }
}
