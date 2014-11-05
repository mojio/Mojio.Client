using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class DistanceObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Distance Low Required
        /// </summary>
        public double DistanceLow { get; set; }

        /// <summary>
        /// Distance High Optional
        /// </summary>
        public double? DistanceHigh { get; set; }

        public DistanceObserver()
            : base(ObserverType.Distance, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="distanceLow">Lower bound for the distance, any distance above this threshold fires an observation event</param>
        /// <param name="distanceHigh">Optional Upper bound, any distance below this threshold and above LowDistance, fires an observe event</param>
        /// </summary>
        public DistanceObserver(Guid vehicleId, double distanceLow = 80.0, double? distanceHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Distance,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(distanceLow, distanceHigh);
        }
        /// <summary>
        /// <param name="distanceLow">Lower bound for the distance, any distance above this threshold fires an observation event</param>
        /// <param name="distanceHigh">Optional Upper bound, any distance below this threshold and above LowDistance, fires an observe event</param>
        /// </summary>
        public DistanceObserver(Guid vehicleId, bool events = false, double distanceLow = 80.0, double? distanceHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Distance,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(distanceLow, distanceHigh);
        }

        public void SetCondition(double distanceLow, double? distanceHigh = null)
        {
            DistanceLow = distanceLow;
            DistanceHigh = distanceHigh;
        }
    }
}
