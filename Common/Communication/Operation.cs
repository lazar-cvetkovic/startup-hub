using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    public enum Operation
    {
        Login = 0,
        CreateEvent = 1,
        CreateFunding = 2,
        CreateRegistration = 3,
        DeleteEvent = 4,
        FindEvents = 5,
        FindFundings = 6,
        FindRegistrations = 7,
        LoadEvent = 8,
        LoadFunding = 9,
        LoadRegistration = 10,
        LoadEventsCollection = 11,
        SaveEvent = 12,
        SaveFunding = 13,
        SaveRegistration = 14,
        SaveUser = 15,
        Register = 16
    }
}
