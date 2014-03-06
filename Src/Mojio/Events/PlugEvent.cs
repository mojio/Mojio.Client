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
    public class PlugEvent : Event
    {
        public PlugEvent()
        {
            EventType = EventType.PlugIn;
        }

        public PlugEvent(bool isPlugin)
        {
            if (isPlugin)
                EventType = EventType.PlugIn;
            else
                EventType = EventType.Unplug;
        }
    }
}
