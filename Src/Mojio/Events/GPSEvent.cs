using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class GPSEvent : TripEvent
    {
        public GPSEvent()
        {
            EventType = EventType.GPS;
            Location = new Location();
        }

        public Location Location { get; set; }

        public float? Heading { get; set; }
        public float? Speed { get; set; }
    }
}
