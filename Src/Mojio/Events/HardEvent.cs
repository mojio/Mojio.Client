using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// hard event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class HardEvent : TripEvent
    {
        // TODO: Should we inclue GPS data?  ex: IGPSEvent

        /// <summary>
        /// force
        /// </summary>
        public double Force { get; set; }

        public HardEvent()
        {

        }
        public HardEvent(EventType type) : base(type)
        {
        }
    }
}
