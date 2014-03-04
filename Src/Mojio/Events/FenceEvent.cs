using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class FenceEvent : TripEvent
    {
    }
}
