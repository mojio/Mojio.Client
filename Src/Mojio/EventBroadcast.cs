using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mojio.Events;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public class EventBroadcast
    {
        /// <summary>
        /// event id
        /// </summary>
        public Guid EventId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        public EventType EventType { get; set; }
    }
}
