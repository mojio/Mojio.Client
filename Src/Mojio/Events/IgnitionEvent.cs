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
        public IgnitionEvent()
        {
            EventType = Events.EventType.IgnitionOff;
        }

        public IgnitionEvent(bool isOn)
        {
            EventType = isOn ? EventType.IgnitionOn : EventType.IgnitionOff;
        }
    }
}
