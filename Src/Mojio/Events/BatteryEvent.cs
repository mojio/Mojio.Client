using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// Battery event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class BatteryEvent : TripEvent
    {
        public BatteryEvent()
        {
            EventType = EventType.LowBattery;
        }

    }
}
