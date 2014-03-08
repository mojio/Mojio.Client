using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// battery event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class BatteryEvent : Event
    {
        public float Voltage;
        public BatteryEvent()
        {
            EventType = EventType.LowBattery;
        }

        public BatteryEvent(float voltage)
        {
            EventType = EventType.LowBattery;
            Voltage = voltage;
        }

    }
}
