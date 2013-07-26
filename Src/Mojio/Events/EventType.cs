using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// event type
    /// </summary>
    public enum EventType
    {
        /// <summary>
        /// information
        /// </summary>
        Information = 100,

        /// <summary>
        /// mojio on
        /// </summary>
        MojioOn,

        /// <summary>
        /// mojio idle
        /// </summary>
        MojioIdle,

        /// <summary>
        /// mojio awake
        /// </summary>
        MojioWake,

        /// <summary>
        /// ignition on
        /// </summary>
        IgnitionOn,

        /// <summary>
        /// ignition off
        /// </summary>
        IgnitionOff,

        /// <summary>
        /// GPS
        /// </summary>
        GPS = 1005,

        /// <summary>
        /// fence entered
        /// </summary>
        FenceEntered,

        /// <summary>
        /// fence exited
        /// </summary>
        FenceExited,

        /// <summary>
        /// trip end
        /// </summary>
        TripEnd,

        /// <summary>
        /// trip start
        /// </summary>
        TripStart,

        /// <summary>
        /// trip status
        /// </summary>
        TripStatus,

        /// <summary>
        /// warning
        /// </summary>
        Warning = 30000,

        /// <summary>
        /// MIL warning
        /// </summary>
        MILWarning,

        /// <summary>
        /// connection lost
        /// </summary>
        ConnectionLost = 40000,

        /// <summary>
        /// alert
        /// </summary>
        Alert = 100000,

        /// <summary>
        /// accident
        /// </summary>
        Accident,

        /// <summary>
        /// tow
        /// </summary>
        Tow,

        /// <summary>
        /// hard acceleration
        /// </summary>
        HardAcceleration,

        /// <summary>
        /// hard brake
        /// </summary>
        HardBrake,

        /// <summary>
        /// hard right
        /// </summary>
        HardRight,

        /// <summary>
        /// hard left
        /// </summary>
        HardLeft,
        
        /// <summary>
        /// speed
        /// </summary>
        Speed
    }
}
