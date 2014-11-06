using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class AccelerationObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Acceleration Low Required
        /// </summary>
        public double AccelerationLow { get; set; }

        /// <summary>
        /// Acceleration High Optional
        /// </summary>
        public double? AccelerationHigh { get; set; }

        public AccelerationObserver()
            : base(ObserverType.Acceleration, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="accelerationLow">Lower bound for the acceleration, any acceleration above this threshold fires an observation event</param>
        /// <param name="accelerationHigh">Optional Upper bound, any acceleration below this threshold and above LowAcceleration, fires an observe event</param>
        /// </summary>
        public AccelerationObserver(Guid vehicleId, double accelerationLow = 80.0, double? accelerationHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Acceleration,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            SubjectId = vehicleId;
            SetCondition(accelerationLow, accelerationHigh);
        }
        /// <summary>
        /// <param name="accelerationLow">Lower bound for the acceleration, any acceleration above this threshold fires an observation event</param>
        /// <param name="accelerationHigh">Optional Upper bound, any acceleration below this threshold and above LowAcceleration, fires an observe event</param>
        /// </summary>
        public AccelerationObserver(Guid vehicleId, bool events = false, double accelerationLow = 80.0, double? accelerationHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Acceleration,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            if (events)
                ParentId = vehicleId;
            else
                SubjectId = vehicleId;

            SetCondition(accelerationLow, accelerationHigh);
        }

        public void SetCondition(double accelerationLow, double? accelerationHigh = null)
        {
            AccelerationLow = accelerationLow;
            AccelerationHigh = accelerationHigh;
        }
    }
}
