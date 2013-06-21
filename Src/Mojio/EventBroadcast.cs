using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mojio.Events;

namespace Mojio
{
    public class EventBroadcast
    {
        public Guid EventId { get; set; }
        public EventType EventType { get; set; }
    }
}
