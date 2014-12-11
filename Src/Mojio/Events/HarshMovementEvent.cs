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
    class HarshMovementEvent
    {
        EventType = Events.EventType.HarshMovement;
    }
}
