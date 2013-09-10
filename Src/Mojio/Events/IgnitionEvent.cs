using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// ignition event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class IgnitionEvent : Event, ITripEvent
    {
        public enum IgnitionStatus {
            Off,
            On
        }

        /// <summary>
        /// trip id
        /// </summary>
        public Guid? TripId { get; set; }

        public IgnitionStatus Status { 
            get {
                return EventType.IgnitionOn == EventType ? IgnitionStatus.On : IgnitionStatus.Off;
            }
            set {
                EventType = (value == IgnitionStatus.On) ?
                    EventType.IgnitionOn :
                    EventType.IgnitionOff;
            }
        }
    }
}
