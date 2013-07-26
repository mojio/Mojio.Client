using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// GPS event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class GPSEvent : TripEvent
    {
        public GPSEvent()
        {
            EventType = EventType.GPS;
            Location = new Location();
        }

        /// <summary>
        /// location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// heading
        /// </summary>
        public float? Heading { get; set; }

        /// <summary>
        /// speed
        /// </summary>
        public float? Speed { get; set; }
    }
}
