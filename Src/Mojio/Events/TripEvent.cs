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
    public class TripEndEvent : TripStatusEvent
    {
        public TripEndEvent()
        {
            EventType = Events.EventType.TripEnd;
        }

        public Guid? EndTrigger { get; set; }
    }

    [CollectionNameAttribute(typeof(Event))]
    public class TripStartEvent : TripStatusEvent
    {
        public TripStartEvent()
        {
            EventType = Events.EventType.TripStart;
        }

        public Guid StartTrigger { get; set; }
    }

    [CollectionNameAttribute(typeof(Event))]
    public class TripStatusEvent : TripEvent
    {
        public TripStatusEvent()
        {
            EventType = Events.EventType.TripStatus;
        }

        public Location Location { get; set; }
        public float Heading { get; set; }

        public float Distance { get; set; }
        public float Fuel { get; set; }

        public float MaxSpeed { get; set; }
        public float AverageSpeed { get; set; }

        public float MovingTime { get; set; }
        public float IdleTime { get; set; }
        public float StartTime { get; set; }
        public float StopTime { get; set; }

        public float Odometer { get; set; }
    }
}
