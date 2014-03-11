using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class SpeedEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedEvent"/> class.
        /// </summary>
        public SpeedEvent()
        {
            EventType = Events.EventType.Speed;
        }
    }
}
