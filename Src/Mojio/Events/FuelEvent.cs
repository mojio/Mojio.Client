using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// Fuel Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class FuelEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuelEvent"/> class.
        /// </summary>
        public FuelEvent()
        {
            EventType = Events.EventType.LowFuel;
        }
    }
}

