using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// Sleep Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class SleepEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SleepEvent"/> class.
        /// </summary>
        public SleepEvent()
        {
            EventType = Events.EventType.PreSleepWarning;
        }
    }
}
