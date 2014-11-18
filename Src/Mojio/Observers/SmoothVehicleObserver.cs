using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mojio.Events;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class SmoothVehicleObserver : SmoothObserverBase
    {
        public SmoothVehicleObserver(double interpolationRate=1.0)
            : base(ObserverType.SmoothVehicle, typeof(Vehicle), null, interpolationRate)
        {
        }

        public SmoothVehicleObserver(Guid vehicleId, double interpolationRate = 1.0)
            : base(ObserverType.SmoothVehicle, 
                    typeof(Vehicle), 
                    null, 
                    interpolationRate)
        {
            SubjectId = vehicleId;
        }
    }
}
