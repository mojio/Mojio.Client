using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]   
    public partial class EventObserver : ConditionalObserverBase
    {
        public EventType[] EventTypes { get; set; }

        public EventObserver()
            : base(ObserverType.Event, typeof(Vehicle), null, ObserverTiming.edge)
        {
            EventTypes = new[] { EventType.TripStatus, EventType.IgnitionOff, EventType.IgnitionOn };
        }

        public EventObserver(Guid vehicleId, EventType[] eventTypes, ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Event,  typeof(Event), typeof(Vehicle), timing)
        {
            ParentId = vehicleId;
            EventTypes = eventTypes;
        }
    }
}
