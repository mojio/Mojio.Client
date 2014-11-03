using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class SpeedObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Speed Low Required
        /// </summary>
        public double SpeedLow { get; set; }

        /// <summary>
        /// Speed High Optional
        /// </summary>
        public double? SpeedHigh { get; set; }

        public SpeedObserver()
            : base(ObserverType.Speed, typeof(Vehicle), null, ObserverTiming.edge)
        {

        }

        public SpeedObserver(ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Speed, typeof(Vehicle), null, timing)
        {

        }

        /// <summary>
        /// SpeedLow LessThan Value [LessThan SpeedHigh]  []=>optional
        /// <param name="type"></param>
        /// <param name="subject"></param>
        /// <param name="parent"></param>
        /// <param name="speedLow">Lower bound for the speed, any speed above this threshold fires an observation event</param>
        /// <param name="speedHigh">Optional Upper bound, any speed below this threshold and above LowSpeed, fires an observe event</param>
        /// </summary>
        public SpeedObserver(double? speedLow = 80.0, double? speedHigh = null, ObserverTiming timing = ObserverTiming.edge)
            : this(timing)
        {
            SetCondition(speedLow.GetValueOrDefault(), speedHigh);
        }

        /// <summary>
        /// SpeedLow LessThan Value [LessThan SpeedHigh]  []=>optional
        /// <param name="type"></param>
        /// <param name="subject"></param>
        /// <param name="parent"></param>
        /// <param name="speedLow">Lower bound for the speed, any speed above this threshold fires an observation event</param>
        /// <param name="speedHigh">Optional Upper bound, any speed below this threshold and above LowSpeed, fires an observe event</param>
        /// </summary>
        public SpeedObserver(Guid vehicleId, double speedLow = 80.0, double? speedHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Speed, typeof(Vehicle), null, timing)
        {
            ParentId = vehicleId;
            SetCondition(speedLow, speedHigh);
        }

        public void SetCondition(double speedLow, double? speedHigh = null)
        {
            SpeedLow = speedLow;
            SpeedHigh = speedHigh;
        }

    }
}
