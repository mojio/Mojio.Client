using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// HeartBeat Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class HeartBeatEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeartBeatEvent"/> class.
        /// </summary>
        public HeartBeatEvent()
        {
            EventType = Events.EventType.HeartBeat;
        }

        /// <summary>
        /// VIN
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Main Firmware version
        /// </summary>
        public string MainFirmware { get; set; }

        /// <summary>
        /// OBD Firmware version
        /// </summary>
        public string OBDFirmware { get; set; }

        /// <summary>
        /// Profile configuration name
        /// </summary>
        public string ProfileName { get; set; }

    }
}
