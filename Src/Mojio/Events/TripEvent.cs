using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// trip event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class TripEvent : Event
    {
        /// <summary>
        /// trip id
        /// </summary>
        public Guid? TripId { get; set; }
    }

    /// <summary>
    /// trip end event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class TripEndEvent : TripStatusEvent
    {
        public TripEndEvent()
        {
            EventType = Events.EventType.TripEnd;
        }

        /// <summary>
        /// end trigger
        /// </summary>
        public Guid? EndTrigger { get; set; }
    }

    /// <summary>
    /// trip start event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class TripStartEvent : TripStatusEvent
    {
        public TripStartEvent()
        {
            EventType = Events.EventType.TripStart;
        }

        /// <summary>
        /// start trigger
        /// </summary>
        public Guid StartTrigger { get; set; }
    }

    /// <summary>
    /// trip status event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class TripStatusEvent : TripEvent
    {
        public TripStatusEvent()
        {
            EventType = Events.EventType.TripStatus;
        }

        /// <summary>
        /// location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// heading degrees
        /// </summary>
        public float Heading { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// fuel
        /// </summary>
        public float Fuel { get; set; }

        /// <summary>
        /// max speed
        /// </summary>
        public float MaxSpeed { get; set; }

        /// <summary>
        /// average speed
        /// </summary>
        public float AverageSpeed { get; set; }

        /// <summary>
        /// moving time
        /// </summary>
        public float MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        public float IdleTime { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public float StopTime { get; set; }

        /// <summary>
        /// odometer
        /// </summary>
        public float Odometer { get; set; }
    }
}
