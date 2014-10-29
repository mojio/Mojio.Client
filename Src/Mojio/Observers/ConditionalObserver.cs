using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Observers
{
    [CollectionNameAttribute("Observer")]
    class ConditionalObserver: ConditionalObserverBase
    {
		/// <summary>
		/// First threshold used in the conditional, required.
		/// </summary>
        public double Threshold1 { get; set; }

        /// <summary>
        /// Second threshold used in the conditional, optional.
        /// </summary>
        public double Threshold2 { get; set; }

        /// <summary>
        /// Second threshold used in the conditional, optional.
        /// </summary>
        public double Threshold2 { get; set; }

		/// <summary>
		/// When true, this is an exit fence, if false, this is an entry fence.
        /// If null, this is both an exit and entry fence
		/// </summary>
        public bool? ConditionValue { get; set; }

		public ConditionalObserver()
            : base(ObserverType.GeoFence, typeof(Vehicle))
        {

        }

        public ConditionalObserver(Guid vehicleId, Location location, double radiusInKm)
            : this()
        {
            SubjectId = vehicleId;
            Location = location;
            Radius = radiusInKm;
        }
    }
}
