using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class DecelerationEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecelerationEvent"/> class.
        /// </summary>
        public DecelerationEvent()
        {
            EventType = Events.EventType.Deceleration;
        }
    }
}
