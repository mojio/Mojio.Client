using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class RPMObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Rpm Low Required
        /// </summary>
        public double RpmLow { get; set; }

        /// <summary>
        /// Rpm High Optional
        /// </summary>
        public double? RpmHigh { get; set; }

        public RPMObserver()
            : base(ObserverType.Rpm, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="rpmLow">Lower bound for the rpm, any rpm above this threshold fires an observation event</param>
        /// <param name="rpmHigh">Optional Upper bound, any rpm below this threshold and above LowRpm, fires an observe event</param>
        /// </summary>
        public RPMObserver(Guid vehicleId, double rpmLow = 80.0, double? rpmHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Rpm,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(rpmLow, rpmHigh);
        }
        /// <summary>
        /// <param name="rpmLow">Lower bound for the rpm, any rpm above this threshold fires an observation event</param>
        /// <param name="rpmHigh">Optional Upper bound, any rpm below this threshold and above LowRpm, fires an observe event</param>
        /// </summary>
        public RPMObserver(Guid vehicleId, bool events = false, double rpmLow = 80.0, double? rpmHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Rpm,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(rpmLow, rpmHigh);
        }

        public void SetCondition(double rpmLow, double? rpmHigh = null)
        {
            RpmLow = rpmLow;
            RpmHigh = rpmHigh;
        }
    }
}
