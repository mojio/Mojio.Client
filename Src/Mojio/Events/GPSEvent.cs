using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    public interface IGPSEvent
    {
        /// <summary>
        /// location
        /// </summary>
        Location Location { get; set; }

        /// <summary>
        /// heading
        /// </summary>
        short Heading { get; set; }

        /// <summary>
        /// altitude
        /// </summary>
        float Altitude { get; set; }
    }

    // TODO: DEPRECATED.  Being replaced by all TripStatusEvent
    /// <summary>
    /// GPS event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class GPSEvent : Event,ITripEvent,IGPSEvent
    {
        public GPSEvent()
        {
            EventType = EventType.GPS;
            Location = new Location();
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
        /// heading
        /// </summary>
        public short Heading { get; set; }

        /// <summary>
        /// altitude
        /// </summary>
        public float Altitude { get; set; }
    }

    /// <summary>
    /// Fence Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class FenceEvent : Event,ITripEvent
    {
        /// <summary>
        /// Trip ID
        /// </summary>
        public Guid? TripId { get; set; }
    }
}
