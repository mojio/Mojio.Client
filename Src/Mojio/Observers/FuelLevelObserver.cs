using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class FuelLevelObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Fuel Low Required
        /// </summary>
        public double FuelLow { get; set; }

        /// <summary>
        /// Fuel High Optional
        /// </summary>
        public double? FuelHigh { get; set; }

        public FuelLevelObserver()
            : base(ObserverType.FuelLevel, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="fuelLow">Lower bound for the fuel, any fuel above this threshold fires an observation event</param>
        /// <param name="fuelHigh">Optional Upper bound, any fuel below this threshold and above LowFuel, fires an observe event</param>
        /// </summary>
        public FuelLevelObserver(Guid vehicleId, double fuelLow = 80.0, double? fuelHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.FuelLevel,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            SubjectId = vehicleId;
            SetCondition(fuelLow, fuelHigh);
        }
        /// <summary>
        /// <param name="fuelLow">Lower bound for the fuel, any fuel above this threshold fires an observation event</param>
        /// <param name="fuelHigh">Optional Upper bound, any fuel below this threshold and above LowFuel, fires an observe event</param>
        /// </summary>
        public FuelLevelObserver(Guid vehicleId, bool events = false, double fuelLow = 80.0, double? fuelHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.FuelLevel,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            if (events)
                ParentId = vehicleId;
            else
                SubjectId = vehicleId;

            SetCondition(fuelLow, fuelHigh);
        }

        public void SetCondition(double fuelLow, double? fuelHigh = null)
        {
            FuelLow = fuelLow;
            FuelHigh = fuelHigh;
        }
    }
}
