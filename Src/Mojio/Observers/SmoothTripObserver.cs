using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class SmoothTripObserver : SmoothObserverBase
    {
        public SmoothTripObserver()
            : base(ObserverType.SmoothTrip, typeof(Trip), null, 1.0)
        {
        }       
        public SmoothTripObserver(double interpolationRate = 1.0)
            : base(ObserverType.SmoothTrip, typeof(Trip), null, interpolationRate)
        {
        }

        public SmoothTripObserver(Guid vehicleId, double interpolationRate = 1.0)
            : base(ObserverType.SmoothTrip,
                    typeof(Trip),  // trips == true means observe trips for a vehicle
                    typeof(Vehicle),
                    interpolationRate)
        {
            ParentId = vehicleId;
        }
    }
}
