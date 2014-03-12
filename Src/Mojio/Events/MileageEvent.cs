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
    public class MileageEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MileageEvent"/> class.
        /// </summary>
        public MileageEvent()
        {
            EventType = Events.EventType.Mileage;
        }
    }
}
