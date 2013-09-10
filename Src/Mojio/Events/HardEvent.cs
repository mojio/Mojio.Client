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
    public class HardEvent : Event, ITripEvent
    {
        // TODO: Should we inclue GPS data?  ex: IGPSEvent

        /// <summary>
        /// trip id
        /// </summary>
        public Guid? TripId { get; set; }

        /// <summary>
        /// force
        /// </summary>
        public float Force { get; set; }
    }
}
