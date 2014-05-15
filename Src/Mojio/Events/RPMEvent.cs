using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// RPM Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class RPMEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RPMEvent"/> class.
        /// </summary>
        public RPMEvent()
        {
            EventType = Events.EventType.RPM;
        }
    }
}