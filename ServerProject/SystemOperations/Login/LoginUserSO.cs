using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerProject.SystemOperations
{
    internal class LoginUserSO : SystemOperationBase
    {
        public User Result { get; private set; }

        private string _email;
        private string _password;

        public LoginUserSO(User user)
        {
            _email = user?.Email;
            _password = user?.Password;
        }

        protected override void ExecuteConcreteOperation()
        {
            var prototype = new User();

            var criteria = new Dictionary<string, object>
            {
                {"Email", _email},
                {"Password", _password}
            };

            var resultEntity = _broker.FindByColumns(prototype, criteria);

            Result = resultEntity as User;
        }
    }
}
