using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
	[CollectionNameAttribute("Observer")]
    public partial class GeoFenceObserver : ConditionalObserver
    {
		/// <summary>
		/// Centerpoint of GeoFence
		/// </summary>
        public Location Location { get; set; }

		/// <summary>
		/// Radius of the fence in kilometers
		/// </summary>
        public double Radius { get; set; }

		/// <summary>
		/// When true, this is an exit fence, if false, this is an entry fence.
        /// If null, this is both an exit and entry fence
		/// </summary>
        public bool? ExitFence { get; set; }

		public GeoFenceObserver()
            : base(ObserverType.GeoFence, typeof(Vehicle))
        {

        }

        public GeoFenceObserver(Guid vehicleId, Location location, double radiusInKm)
            : this()
        {
            SubjectId = vehicleId;
            Location = location;
            Radius = radiusInKm;
        }
    }
}
