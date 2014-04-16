using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// tow event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class TowEvent : TripEvent
    {
        public TowEvent()
        {
            EventType = EventType.TowStart;
        }

        public TowEvent(bool isTowStart)
        {
            if (isTowStart)
                EventType = EventType.TowStart;
            else
                EventType = EventType.TowStop;
        }
    }
}
