using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    /// <summary>
    /// Trip
    /// </summary>
    [Observable]
    public partial class Trip : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.Trip; }
        }

        /// <summary>
        /// mojio id
        /// </summary>
        /// <value>
        /// The mojio identifier.
        /// </value>
        [Observable(typeof(Mojio))]
        public Guid MojioId { get; set; }

        /// <summary>
        /// vehicle id
        /// </summary>
        /// <value>
        /// The vehicle identifier.
        /// </value>
        [Observable(typeof(Vehicle))]
        [Parent(typeof(Vehicle))]
        public Guid VehicleId { get; set; }

        [DefaultSort]
        /// <summary>
        /// start timestamp
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// end timestamp
        /// </summary>
        /// <value>
        /// The last updated time.
        /// </value>
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// end timestamp
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// maximum speed
        /// </summary>
        /// <value>
        /// The maximum speed.
        /// </value>
        public double? MaxSpeed { get; set; }

        /// <summary>
        /// maximum acceleration
        /// </summary>
        /// <value>
        /// The maximum acceleration.
        /// </value>
        public double? MaxAcceleration { get; set; }

        /// <summary>
        /// maximum acceleration
        /// </summary>
        /// <value>
        /// The maximum acceleration.
        /// </value>
        public double? MaxDeceleration { get; set; }

        /// <summary>
        /// maximum rpm
        /// </summary>
        /// <value>
        /// The maximum RPM.
        /// </value>
        public int? MaxRPM { get; set; }

        /// <summary>
        /// fuel level (percent 0 - 100)
        /// </summary>
        /// <value>
        /// The fuel level.
        /// </value>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// fuel efficiency (liters per 100km)
        /// </summary>
        /// <value>
        /// The fuel efficiency.
        /// </value>
        public double? FuelEfficiency { get; set; }

        /// <summary>
        /// distance travelled
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public double? Distance { get; set; }

        /// <summary>
        /// time moving
        /// </summary>
        /// <value>
        /// The moving time.
        /// </value>
        public double? MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        /// <value>
        /// The idle time.
        /// </value>
        public double? IdleTime { get; set; }

        /// <summary>
        /// time stopped
        /// </summary>
        /// <value>
        /// The stop time.
        /// </value>
        public double? StopTime { get; set; }

        /// <summary>
        /// start location
        /// </summary>
        /// <value>
        /// The start location.
        /// </value>
        public Location StartLocation { get; set; }

        /// <summary>
        /// last known location
        /// </summary>
        /// <value>
        /// The last known location.
        /// </value>
        public Location LastKnownLocation { get; set; }

        /// <summary>
        /// end location
        /// </summary>
        /// <value>
        /// The end location.
        /// </value>
        public Location EndLocation { get; set; }

        /// <summary>
        /// Address where the trip started
        /// </summary>
        /// <value>
        /// The start address.
        /// </value>
        public Address StartAddress { get; set; }

        /// <summary>
        /// Address where the trip ended
        /// </summary>
        /// <value>
        /// The end address.
        /// </value>
        public Address EndAddress { get; set; }

        /// <summary>
        /// Forcefully Ended the trip
        /// </summary>
        /// <value>
        /// The forcefully ended.
        /// </value>
        public bool? ForcefullyEnded { get; set; }

        /// <summary>
        /// Address where the trip started
        /// </summary>
        /// <value>
        /// The start milage.
        /// </value>
        public double? StartMilage { get; set; }

        /// <summary>
        /// Milage where the trip ended
        /// </summary>
        /// <value>
        /// The end milage.
        /// </value>
        public double? EndMilage { get; set; }
    }
}
