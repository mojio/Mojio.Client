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
    public class IgnitionEvent : TripEvent
    {
    }
}
