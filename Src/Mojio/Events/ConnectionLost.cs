using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// Connection Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class ConnectionLost : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectionLost"/> class.
        /// </summary>
        public ConnectionLost()
        {
            EventType = Events.EventType.ConnectionLost;
        }
    }
}
