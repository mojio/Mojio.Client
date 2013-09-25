using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class PowerEvent : Event
    {
        public PowerEvent()
            : this(EventType.MojioOn)
        {
        }

        public PowerEvent(EventType type)
        {
            if (type != Events.EventType.MojioOn ||
                type != Events.EventType.MojioIdle ||
                type != Events.EventType.MojioWake)
                throw new ArgumentException("Invalid Power event type " + type);
            EventType = type;
        }
    }
}
