using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]   
    public partial class EventObserver : ConditionalObserverBase
    {
        public EventObserver()
            : base(ObserverType.Event, ObserverTiming.edge)
        {

        }

        public EventType[] EventTypes { get; set; }
    }
}
