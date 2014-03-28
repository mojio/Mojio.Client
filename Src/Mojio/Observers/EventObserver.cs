using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]   
    public partial class EventObserver : ConditionalObserver
    {
        public EventObserver()
            : base(ObserverType.Event)
        {

        }

        public EventType[] EventTypes { get; set; }
    }
}
