using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class SaveUserSO : SystemOperationBase
    {
        private User _user;

        public SaveUserSO(User user)
        {
            _user = user;
        }

        protected override void ExecuteConcreteOperation()
        {
            _broker.Update(_user);
        }
    }
}
