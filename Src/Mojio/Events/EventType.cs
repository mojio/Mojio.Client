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
        /// diagnostic event (device or server)
        /// </summary>
        Log = 1,

        /// <summary>
        /// information
        /// </summary>
        Information = 100,

        /// <summary>
        /// mojio on (device)
        /// </summary>
        MojioOn,

        /// <summary>
        /// mojio idle (device)
        /// </summary>
        MojioIdle,

        /// <summary>
        /// mojio awake (device)
        /// </summary>
        MojioWake,

        /// <summary>
        /// ignition on (device)
        /// </summary>
        IgnitionOn,

        /// <summary>
        /// ignition off (device)
        /// </summary>
        IgnitionOff,

        /// <summary>
        /// GPS update (device)
        /// </summary>
        TripEvent = 1005,

        /// <summary>
        /// fence enter (device)
        /// </summary>
        FenceEntered,

        /// <summary>
        /// fence exit (device)
        /// </summary>
        FenceExited,

        /// <summary>
        /// trip end (device)
        /// </summary>
        TripEnd,

        /// <summary>
        /// trip start (device)
        /// </summary>
        TripStart,

        /// <summary>
        /// trip status (device)
        /// </summary>
        TripStatus,

        /// <summary>
        /// warning
        /// </summary>
        Warning = 30000,

        /// <summary>
        /// malfunction indicator light warning (device)
        /// </summary>
        MILWarning,

        /// <summary>
        /// connection lost (server)
        /// </summary>
        ConnectionLost = 40000,

        /// <summary>
        /// alert
        /// </summary>
        Alert = 100000,

        /// <summary>
        /// accident (device)
        /// </summary>
        Accident,

        /// <summary>
        /// tow (device)
        /// </summary>
        Tow,

        /// <summary>
        /// hard acceleration (device)
        /// </summary>
        HardAcceleration,

        /// <summary>
        /// hard brake (device)
        /// </summary>
        HardBrake,

        /// <summary>
        /// hard right (device)
        /// </summary>
        HardRight,

        /// <summary>
        /// hard left (device)
        /// </summary>
        HardLeft,
        
        /// <summary>
        /// device-defined excessive speed (device)
        /// </summary>
        Speed
    }
}
