using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// trip status event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripEvent : Event
    {
        public TripEvent ()
        {
            EventType = Events.EventType.TripEvent;
        }

        public Guid? TripId { get; set; }

        /// <summary>
        /// altitude
        /// </summary>
        public float? Altitude { get; set; }

        /// <summary>
        /// heading degrees
        /// </summary>
        public short? Heading { get; set; }

        public bool? TimeIsApprox { get; set; }
        // This property is not saved
        [JsonIgnore]
        public bool? ForceTripEnd { get; set; }
    }

    /// <summary>
    /// trip status event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripStatusEvent : TripEvent
    {
        public TripStatusEvent ()
        {
            EventType = Events.EventType.TripStatus;
        }

        /// <summary>
        /// distance
        /// </summary>
        public float? Distance { get; set; }

        /// <summary>
        /// fuel level (percent 0 - 100)
        /// </summary>
        public float? FuelLevel { get; set; }

        /// <summary>
        /// fuel efficiency (liters per 100km)
        /// </summary>
        public float? FuelEfficiency { get; set; }

        /// <summary>
        /// Current speed
        /// </summary>
        public float? Speed { get; set; }

        /// <summary>
        /// max speed
        /// </summary>
        public float? MaxSpeed { get; set; }

        /// <summary>
        /// average speed
        /// </summary>
        public float? AverageSpeed { get; set; }

        /// <summary>
        /// moving time
        /// </summary>
        public float? MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        public float? IdleTime { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public float? StopTime { get; set; }

        /// <summary>
        /// RPM
        /// </summary>
        public int? RPM { get; set; }

        /// <summary>
        /// Max RPM
        /// </summary>
        public int? MaxRPM { get; set; }

        /// <summary>
        /// stop time
        /// </summary>
        public float? Odometer { get; set; }
    }

    /// <summary>
    /// trip end event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripEndEvent : TripStatusEvent
    {
        public TripEndEvent ()
        {
            EventType = Events.EventType.TripEnd;
        }
    }

    /// <summary>
    /// trip start event
    /// </summary>
    [CollectionNameAttribute (typeof(Event))]
    public class TripStartEvent : TripStatusEvent
    {
        public TripStartEvent ()
        {
            EventType = Events.EventType.TripStart;
        }
    }
}
