using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    public enum EventType
    {
        Information = 1000,
        MojioOn,
        IgnitionOn,
        IgnitionOff,
        GPS,
        FenceEntered,
        FenceExited,
        TripEnd,

        Warning = 30000,
        MILWarning,

        Alert = 100000,
        Accident,
        Tow,
    }
}
