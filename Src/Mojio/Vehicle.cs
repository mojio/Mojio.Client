using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public partial class Vehicle : GuidEntity, IOwner, IViewers
    {
        /// <summary>
        /// owner id
        /// </summary>
        [Display(Name = "Owner")]
        public Guid? OwnerId { get; set; }

        // TODO: should this be MojioId?
        public Guid? DeviceId { get; set; }

        /// <summary>
        /// vehicle name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// license plate
        /// </summary>
        /// <value>The license plate.</value>
        public string LicensePlate { get; set; }

        /// <summary>
        /// optional is ignition on?
        /// </summary>
        public bool? IgnitionOn { get; set; }

        /// <summary>
        /// most recent trip event
        /// </summary>
        public Guid? LastTripEvent { get; set; }

        /// <summary>
        /// Last location time
        /// </summary>
        public DateTime? LastLocationTime { get; set; }

        /// <summary>
        /// last known location
        /// </summary>
        public Location LastLocation { get; set; }

        /// <summary>
        /// last known speed
        /// </summary>
        public double LastSpeed { get; set; }

        /// <summary>
        /// last known fuel level
        /// </summary>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// last mileage
        /// </summary>
        public double LastFuelEfficiency { get; set; }

        /// <summary>
        /// current trip id
        /// </summary>
        public Guid? CurrentTrip { get; set; }

        /// <summary>
        /// current trip id
        /// </summary>
        public Guid? LastTrip { get; set; }

        /// <summary>
        /// most recent communication time
        /// </summary>
        public DateTime LastContactTime { get; set; }

        /// <summary>
        /// Malfunction Indicator Lamp (Check Engine Light)
        /// </summary>
        public bool? MilStatus { get; set; }

        /// <summary>
        /// public boolean flag to indicate DTC faults have been detected
        /// </summary>
        public bool FaultsDetected { get; set; }

        // TODO: Maybe Viewers should be in private?
        /// <summary>
        /// list of viewer ids
        /// </summary>
        public Guid[] Viewers { get; set; }
    }
}
