using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Xirgo Specific Cellular Registration State.
    /// For different devices, use a switch/case statement to map values to enums...
    /// </summary>
    public enum RegistrationState
    {
        UnRegistered = 0,
        Home = 1,
        Search = 2,
        Denied = 3,
        Unknown = 4,
        Roaming = 5
    }
}
