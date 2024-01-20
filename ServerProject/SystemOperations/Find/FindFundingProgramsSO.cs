using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class FindFundingProgramsSO : SystemOperationBase
    {
        public List<FundingProgram> Result { get; private set; }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new FundingProgram();
            var entities = _broker.GetAll(prototype);

            Result = entities.OfType<FundingProgram>().ToList();
        }
    }
}
