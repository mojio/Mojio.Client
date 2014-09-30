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
        /// for server-side diagnostics
        /// </summary>
        Log = 1,

        /// <summary>
        /// for device communication session.
        /// </summary>
        Message = 2,

        /// <summary>
        /// information
        /// </summary>
        Information = 100,

        /// <summary>
        /// mojio on (device)
        /// </summary>
        MojioOn = 101,

        /// <summary>
        /// mojio idle (device)
        /// </summary>
        MojioIdle = 102,

        /// <summary>
        /// mojio awake (device)
        /// </summary>
        MojioWake = 103,

        /// <summary>
        /// ignition on (device)
        /// </summary>
        IgnitionOn = 104,

        /// <summary>
        /// ignition off (device)
        /// </summary>
        IgnitionOff = 105,

        /// <summary>
        /// mojio off (device)
        /// </summary>
        MojioOff = 106,

        /// <summary>
        /// low battery (device)
        /// </summary>
        LowBattery = 107,

        /// <summary>
        /// GPS update (device)
        /// </summary>
        TripEvent = 1005,

        /// <summary>
        /// fence enter (device)
        /// </summary>
        FenceEntered = 1006,

        /// <summary>
        /// fence exit (device)
        /// </summary>
        FenceExited = 1007,

        /// <summary>
        /// trip status (device)
        /// </summary>
        TripStatus = 1010,

        /// <summary>
        /// warning
        /// </summary>
        Warning = 30000,

        /// <summary>
        /// malfunction indicator light warning (device)
        /// </summary>
        MILWarning = 30001,

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
        Accident = 100001,

        /// <summary>
        /// tow start (device)
        /// </summary>
        TowStart = 100002,

        /// <summary>
        /// tow stop (device)
        /// </summary>
        TowStop = 100003,

        /// <summary>
        /// hard acceleration (device)
        /// </summary>
        HardAcceleration = 100004,

        /// <summary>
        /// hard brake (device)
        /// </summary>
        HardBrake = 100005,

        /// <summary>
        /// hard right (device)
        /// </summary>
        HardRight = 100006,

        /// <summary>
        /// hard left (device)
        /// </summary>
        HardLeft = 100007,
        
        /// <summary>
        /// device-defined excessive speed (device)
        /// </summary>
        Speed = 100008,

        /// <summary>
        /// device-defined diagnostics event
        /// </summary>
        Diagnostic = 100009,

        /// <summary>
        /// trip status (device)
        /// </summary>
        OffStatus = 100010,

        /// <summary>
        /// park
        /// </summary>
        Park = 100011,

        /// <summary>
        /// acceleromter
        /// </summary>
        Accelerometer = 100012,

        /// <summary>
        /// acceleration
        /// </summary>
        Acceleration = 100013,

        /// <summary>
        /// deceleration
        /// </summary>
        Deceleration = 100014,

        /// <summary>
        /// HeadingChange
        /// </summary>
        HeadingChange = 100015,

        /// <summary>
        /// Mileage
        /// </summary>
        Mileage = 100016,

        /// <summary>
        /// LowFuel
        /// </summary>
        LowFuel = 100017,

        /// <summary>
        /// RPM
        /// </summary>
        RPM = 100018,

        /// <summary>
        /// Movement Start
        /// </summary>
        MovementStart = 100019,

        /// <summary>
        /// Movement Stop
        /// </summary>
        MovementStop = 100020,

        /// <summary>
        /// HeartBeat
        /// </summary>
        HeartBeat = 100021,

        /// <summary>
        /// Device Diagnostic Data
        /// </summary>
        DeviceDiagnostic = 100022,

        /// <summary>
        /// Vehicle Idle Event
        /// </summary>
        IdleEvent = 100023,

        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = -1


    }
}
