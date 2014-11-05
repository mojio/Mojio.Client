using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class BatteryVoltageObserver : ConditionalObserverBase
    {
        /// <summary>
        /// BatteryVoltage Low Required
        /// </summary>
        public double BatteryVoltageLow { get; set; }

        /// <summary>
        /// BatteryVoltage High Optional
        /// </summary>
        public double? BatteryVoltageHigh { get; set; }

        public BatteryVoltageObserver()
            : base(ObserverType.BatteryVoltage, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="batteryVoltageLow">Lower bound for the batteryVoltage, any batteryVoltage above this threshold fires an observation event</param>
        /// <param name="batteryVoltageHigh">Optional Upper bound, any batteryVoltage below this threshold and above LowBatteryVoltage, fires an observe event</param>
        /// </summary>
        public BatteryVoltageObserver(Guid vehicleId, double batteryVoltageLow = 80.0, double? batteryVoltageHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.BatteryVoltage,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(batteryVoltageLow, batteryVoltageHigh);
        }
        /// <summary>
        /// <param name="batteryVoltageLow">Lower bound for the batteryVoltage, any batteryVoltage above this threshold fires an observation event</param>
        /// <param name="batteryVoltageHigh">Optional Upper bound, any batteryVoltage below this threshold and above LowBatteryVoltage, fires an observe event</param>
        /// </summary>
        public BatteryVoltageObserver(Guid vehicleId, bool events = false, double batteryVoltageLow = 80.0, double? batteryVoltageHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.BatteryVoltage,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(batteryVoltageLow, batteryVoltageHigh);
        }

        public void SetCondition(double batteryVoltageLow, double? batteryVoltageHigh = null)
        {
            BatteryVoltageLow = batteryVoltageLow;
            BatteryVoltageHigh = batteryVoltageHigh;
        }
    }
}
