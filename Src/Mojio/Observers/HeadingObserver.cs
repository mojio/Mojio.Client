using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class HeadingObserver : ConditionalObserverBase
    {
        /// <summary>
        /// Heading Low Required
        /// </summary>
        public double HeadingLow { get; set; }

        /// <summary>
        /// Heading High Optional
        /// </summary>
        public double? HeadingHigh { get; set; }

        public HeadingObserver()
            : base(ObserverType.Heading, typeof(Vehicle), null, ObserverTiming.edge)
        {
        }

        /// <summary>
        /// <param name="headingLow">Lower bound for the heading, any heading above this threshold fires an observation event</param>
        /// <param name="headingHigh">Optional Upper bound, any heading below this threshold and above LowHeading, fires an observe event</param>
        /// </summary>
        public HeadingObserver(Guid vehicleId, double headingLow = 80.0, double? headingHigh = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Heading,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            SubjectId = vehicleId;
            SetCondition(headingLow, headingHigh);
        }
        /// <summary>
        /// <param name="headingLow">Lower bound for the heading, any heading above this threshold fires an observation event</param>
        /// <param name="headingHigh">Optional Upper bound, any heading below this threshold and above LowHeading, fires an observe event</param>
        /// </summary>
        public HeadingObserver(Guid vehicleId, bool events = false, double headingLow = 80.0, double? headingHigh = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Heading,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            if (events)
                ParentId = vehicleId;
            else
                SubjectId = vehicleId;

            SetCondition(headingLow, headingHigh);
        }

        public void SetCondition(double headingLow, double? headingHigh = null)
        {
            HeadingLow = headingLow;
            HeadingHigh = headingHigh;
        }
    }
}
