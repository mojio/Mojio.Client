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
    public class SpeedEvent : TripEvent
    {        
        /// <summary>
        /// trip id
        /// </summary>
        public Guid? TripId { get; set; }

        /// <summary>
        /// current speed
        /// </summary>
        public float Speed { get; set; }
    }
}
