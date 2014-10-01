using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class IdleEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParkEvent"/> class.
        /// </summary>
        public IdleEvent()
            : base(EventType.IdleEvent)
        {
        }
    }
}
