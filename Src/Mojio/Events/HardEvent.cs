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
    public class HardEvent : TripEvent
    {
        /// <summary>
        /// force
        /// </summary>
        public float Force { get; set; }
    }
}
