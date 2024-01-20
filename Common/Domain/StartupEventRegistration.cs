using Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class StartupEventRegistration
    {
        public int UserId { get; set; }
        public int EventId { get; set; }
        public RegistrationStatus Status { get; set; }
        public DateTime DateOfRegistration { get; set; }
    }
}
