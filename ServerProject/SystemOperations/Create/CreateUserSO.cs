using Common.Domain;
using DatabaseBroker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations.Create
{
    internal class CreateUserSO : SystemOperationBase
    {
        private User _user;

        public CreateUserSO(User user)
        {
            _user = user;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Insert(_user);
        }
    }
}
