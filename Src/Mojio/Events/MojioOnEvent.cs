using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class MojioOnEvent : Event
    {
        public MojioOnEvent()
        {
            EventType = EventType.MojioOn;
        }
    }
}
