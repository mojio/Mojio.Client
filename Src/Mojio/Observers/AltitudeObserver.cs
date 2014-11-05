using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class AltitudeObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Altitude Low Required
        /// </summary>
        public double AltitudeLow { get; set; }

        /// <summary>
        /// Altitude High Optional
        /// </summary>
        public double? AltitudeHigh { get; set; }

        public AltitudeObserver()
            : base(ObserverType.Altitude, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="altitudeLow">Lower bound for the altitude, any altitude above this threshold fires an observation event</param>
        /// <param name="altitudeHigh">Optional Upper bound, any altitude below this threshold and above LowAltitude, fires an observe event</param>
        /// </summary>
        public AltitudeObserver(Guid vehicleId, double altitudeLow = 80.0, double? altitudeHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Altitude,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(altitudeLow, altitudeHigh);
        }
        /// <summary>
        /// <param name="altitudeLow">Lower bound for the altitude, any altitude above this threshold fires an observation event</param>
        /// <param name="altitudeHigh">Optional Upper bound, any altitude below this threshold and above LowAltitude, fires an observe event</param>
        /// </summary>
        public AltitudeObserver(Guid vehicleId, bool events = false, double altitudeLow = 80.0, double? altitudeHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Altitude,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            ParentId = vehicleId;
            SetCondition(altitudeLow, altitudeHigh);
        }

        public void SetCondition(double altitudeLow, double? altitudeHigh = null)
        {
            AltitudeLow = altitudeLow;
            AltitudeHigh = altitudeHigh;
        }
    }
}
