using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class PowerEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PowerEvent"/> class.
        /// </summary>
        public PowerEvent()
            : this(EventType.MojioOn)
        {
            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PowerEvent"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <exception cref="System.ArgumentException">Invalid Power event type  + type</exception>
        public PowerEvent(EventType type) : base (type)
        {
            if (type != Events.EventType.MojioOn &&
                type != Events.EventType.MojioIdle &&
                type != Events.EventType.MojioWake && 
                type != Events.EventType.MojioOff) 
                throw new ArgumentException("Invalid Power event type " + type);
        }
    }
}
