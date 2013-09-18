using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    // TODO: Deprecated
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
    /// trip status event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class TripStatusEvent : Event, ITripEvent, IGPSEvent
    {
        public TripStatusEvent()
        {
            EventType = Events.EventType.TripStatus;
        }

        /// <summary>
        /// trip id
        /// </summary>
        public Guid? TripId { get; set; }

        /// <summary>
        /// location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// heading degrees
        /// </summary>
        public short Heading { get; set; }

        /// <summary>
        /// distance
        /// </summary>
        public float Distance { get; set; }

        /// <summary>
        /// fuel
        /// </summary>
        public float Fuel { get; set; }

        /// <summary>
        /// Current speed
        /// </summary>
        public float Speed { get; set; }

        /// <summary>
        /// max speed
        /// </summary>
        public float MaxSpeed { get; set; }

        /// <summary>
        /// average speed
        /// </summary>
        public float Altitude { get; set; }

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
