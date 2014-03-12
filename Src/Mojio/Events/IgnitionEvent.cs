using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// ignition event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class IgnitionEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IgnitionEvent"/> class.
        /// </summary>
        public IgnitionEvent()
        {
            EventType = Events.EventType.IgnitionOff;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IgnitionEvent"/> class.
        /// </summary>
        /// <param name="isOn">if set to <c>true</c> [is on].</param>
        public IgnitionEvent(bool isOn)
        {
            EventType = isOn ? EventType.IgnitionOn : EventType.IgnitionOff;
        }
    }
}
