using Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    [Serializable]
    public class FullRegistration
    {
        public StartupEventRegistration Registration { get; set; }
        public List<RegisteredQuestion> Questions { get; set; }

        public FullRegistration(StartupEventRegistration registration, List<RegisteredQuestion> questions)
        {
            Registration = registration;
            Questions = questions;
        }
    }
}
