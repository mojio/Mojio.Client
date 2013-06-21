using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class TripEvent : Event
    {
        public Guid? TripId { get; set; }
    }

    [CollectionNameAttribute(typeof(Event))]
    public class TripEndEvent : TripEvent
    {
        public TripEndEvent()
        {
            EventType = Events.EventType.TripEnd;
        }

        public bool InProgress { get; set; }
        public float Distance { get; set; }
        public Guid? PreviousTrip { get; set; }
        public Guid StartTrigger { get; set; }
        public Guid? EndTrigger { get; set; }
        public DateTime? StartTime { get; set; }
    }
}
