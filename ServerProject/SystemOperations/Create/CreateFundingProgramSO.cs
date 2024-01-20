using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class CreateFundingProgramSO : SystemOperationBase
    {
        private FundingProgram _fundingProgram;

        public CreateFundingProgramSO(FundingProgram fundingProgram)
        {
            _fundingProgram = fundingProgram;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Insert(_fundingProgram);
        }
    }
}
