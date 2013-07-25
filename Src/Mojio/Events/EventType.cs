using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    public enum EventType
    {
        Information = 100,
        MojioOn,
        MojioIdle,
        MojioWake,
        IgnitionOn,
        IgnitionOff,

        GPS = 1005,
        FenceEntered,
        FenceExited,
        TripEnd,
        TripStart,
        TripStatus,

        Warning = 30000,
        MILWarning,

        ConnectionLost = 40000,

        Alert = 100000,
        Accident,
        Tow,
        HardAcceleration,
        HardBreak,
        HardRight,
        HardLeft,
        Speed
    }
}
