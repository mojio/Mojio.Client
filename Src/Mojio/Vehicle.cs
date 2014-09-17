using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Observable]
    public partial class Vehicle : GuidEntity, IOwner, IViewers
    {
        public override EntityType Type {
            get { return EntityType.Vehicle; }
        }

        /// <summary>
        /// Owner ID
        /// </summary>
        [Observable (typeof(User))]
        [Parent (typeof(User))]

        public Guid? OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the mojio identifier.
        /// </summary>
        /// <value>
        /// The mojio identifier.
        /// </value>
        [Observable (typeof(Mojio))]
        public Guid? MojioId { get; set; }

        [DefaultSort]
        /// <summary>
        /// Vehicle name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Vehicle Identification Number
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// License plate
        /// </summary>
        /// <value>The license plate.</value>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Optional is ignition on?
        /// </summary>
        public bool? IgnitionOn { get; set; }

        /// <summary>
        /// Most recent trip event
        /// </summary>
        public Guid? LastTripEvent { get; set; }

        /// <summary>
        /// Last location time
        /// </summary>
        public DateTime? LastLocationTime { get; set; }

        /// <summary>
        /// Last known location
        /// </summary>
        public Location LastLocation { get; set; }

        /// <summary>
        /// Last known speed
        /// </summary>
        public double LastSpeed { get; set; }

        /// <summary>
        /// Last known fuel level
        /// </summary>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// Last mileage
        /// </summary>
        public double LastFuelEfficiency { get; set; }

        /// <summary>
        /// Current trip ID
        /// </summary>
        public Guid? CurrentTrip { get; set; }

        /// <summary>
        /// Current trip ID
        /// </summary>
        public Guid? LastTrip { get; set; }

        /// <summary>
        /// Most recent communication time
        /// </summary>
        public DateTime? LastContactTime { get; set; }

        /// <summary>
        /// Malfunction Indicator Lamp (Check Engine Light)
        /// </summary>
        public bool? MilStatus { get; set; }

        /// <summary>
        /// Public boolean flag to indicate DTC faults have been detected
        /// </summary>
        public bool FaultsDetected { get; set; }

        // TODO: Maybe Viewers should be in private?
        /// <summary>
        /// List of viewer IDs
        /// </summary>
        public Guid[] Viewers { get; set; }
    }
}
