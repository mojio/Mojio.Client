using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class OdometerObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Odometer Low Required
        /// </summary>
        public double OdometerLow { get; set; }

        /// <summary>
        /// Odometer High Optional
        /// </summary>
        public double? OdometerHigh { get; set; }

        public OdometerObserver()
            : base(ObserverType.Odometer, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="odometerLow">Lower bound for the odometer, any odometer above this threshold fires an observation event</param>
        /// <param name="odometerHigh">Optional Upper bound, any odometer below this threshold and above LowOdometer, fires an observe event</param>
        /// </summary>
        public OdometerObserver(Guid vehicleId, double odometerLow = 80.0, double? odometerHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Odometer,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(odometerLow, odometerHigh);
        }
        /// <summary>
        /// <param name="odometerLow">Lower bound for the odometer, any odometer above this threshold fires an observation event</param>
        /// <param name="odometerHigh">Optional Upper bound, any odometer below this threshold and above LowOdometer, fires an observe event</param>
        /// </summary>
        public OdometerObserver(Guid vehicleId, bool events = false, double odometerLow = 80.0, double? odometerHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Odometer,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(odometerLow, odometerHigh);
        }

        public void SetCondition(double odometerLow, double? odometerHigh = null)
        {
            OdometerLow = odometerLow;
            OdometerHigh = odometerHigh;
        }
    }
}
