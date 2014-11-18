using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mojio.Events;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class SmoothEventObserver : SmoothObserverBase
    {
        public SmoothEventObserver(double interpolationRate = 1.0)
            : base(ObserverType.SmoothEvent, typeof(Event), null, interpolationRate)
        {
        }

        public SmoothEventObserver(Guid vehicleId, double interpolationRate = 1.0)
            : base(ObserverType.SmoothEvent,
                    typeof(Event),  // trips == true means observe trips for a vehicle
                    typeof(Vehicle),
                    interpolationRate)
        {       
            ParentId = vehicleId;
        }
    }
}
