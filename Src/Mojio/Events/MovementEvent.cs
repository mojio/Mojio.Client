using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// Movement Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class MovementEvent : TripEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MovementEvent"/> class.
        /// </summary>
        public MovementEvent()
        {
            EventType = Events.EventType.MovementStop;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MovementEvent"/> class.
        /// </summary>
        /// <param name="isStart">if set to <c>true</c> [is on].</param>
        public MovementEvent(bool isStart)
        {
            EventType = isStart ? EventType.MovementStart : EventType.MovementStop;
        }
    }
}
