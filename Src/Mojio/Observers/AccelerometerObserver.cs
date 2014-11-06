using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class AccelerometerObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Accelerometer Low Required
        /// </summary>
        public Accelerometer AccelerometerLow { get; set; }

        /// <summary>
        /// Accelerometer High Optional
        /// </summary>
        public Accelerometer AccelerometerHigh { get; set; }

        public AccelerometerObserver()
            : base(ObserverType.Accelerometer, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="accelerometerLow">Lower bound for the accelerometer, any accelerometer above this threshold fires an observation event</param>
        /// <param name="accelerometerHigh">Optional Upper bound, any accelerometer below this threshold and above LowAccelerometer, fires an observe event</param>
        /// </summary>
        public AccelerometerObserver(Guid vehicleId, Accelerometer accelerometerLow = null, Accelerometer accelerometerHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Accelerometer,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            if (accelerometerLow == null)
                accelerometerLow = new Accelerometer { X = 2.0, Y = 2.0, Z = 2.0 };
            ParentId = vehicleId;
            SetCondition(accelerometerLow, accelerometerHigh);
        }
        /// <summary>
        /// <param name="accelerometerLow">Lower bound for the accelerometer, any accelerometer above this threshold fires an observation event</param>
        /// <param name="accelerometerHigh">Optional Upper bound, any accelerometer below this threshold and above LowAccelerometer, fires an observe event</param>
        /// </summary>
        public AccelerometerObserver(Guid vehicleId, bool events = false, Accelerometer accelerometerLow = null, Accelerometer accelerometerHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Accelerometer,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            if (accelerometerLow == null)
                accelerometerLow = new Accelerometer { X = 2.0, Y = 2.0, Z = 2.0 };
            ParentId = vehicleId;
            SetCondition(accelerometerLow, accelerometerHigh);
        }

        public void SetCondition(Accelerometer accelerometerLow, Accelerometer accelerometerHigh = null)
        {
            AccelerometerLow = accelerometerLow;
            AccelerometerHigh = accelerometerHigh;
        }
    }
}
