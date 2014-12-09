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
        /// Mojio id
        /// </summary>
        /// <value>
        /// The mojio identifier.
        /// </value>
        [Observable(typeof(Mojio))]
        public Guid MojioId { get; set; }

        /// <summary>
        /// Vehicle id
        /// </summary>
        /// <value>
        /// The vehicle identifier.
        /// </value>
        [Observable(typeof(Vehicle))]
        [Parent(typeof(Vehicle))]
        public Guid VehicleId { get; set; }

        [DefaultSort]
        /// <summary>
        /// Start timestamp
        /// </summary>
        /// <value>
        /// The start time.
        /// </value>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// End timestamp
        /// </summary>
        /// <value>
        /// The last updated time.
        /// </value>
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// End timestamp
        /// </summary>
        /// <value>
        /// The end time.
        /// </value>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Maximum speed
        /// </summary>
        /// <value>
        /// The maximum speed.
        /// </value>
        public double? MaxSpeed { get; set; }

        /// <summary>
        /// Maximum acceleration
        /// </summary>
        /// <value>
        /// The maximum acceleration.
        /// </value>
        public double? MaxAcceleration { get; set; }

        /// <summary>
        /// Maximum acceleration
        /// </summary>
        /// <value>
        /// The maximum acceleration.
        /// </value>
        public double? MaxDeceleration { get; set; }

        /// <summary>
        /// Maximum rpm
        /// </summary>
        /// <value>
        /// The maximum RPM.
        /// </value>
        public int? MaxRPM { get; set; }

        /// <summary>
        /// Fuel level (percent 0 - 100)
        /// </summary>
        /// <value>
        /// The fuel level.
        /// </value>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// Fuel efficiency (liters per 100km)
        /// </summary>
        /// <value>
        /// The fuel efficiency.
        /// </value>
        public double? FuelEfficiency { get; set; }

        /// <summary>
        /// Distance travelled
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public double? Distance { get; set; }

        /// <summary>
        /// Time moving
        /// </summary>
        /// <value>
        /// The moving time.
        /// </value>
        //public double? MovingTime { get; set; }

        /// <summary>
        /// Idle time
        /// </summary>
        /// <value>
        /// The idle time.
        /// </value>
        //public double? IdleTime { get; set; }

        /// <summary>
        /// Time stopped
        /// </summary>
        /// <value>
        /// The stop time.
        /// </value>
        //public double? StopTime { get; set; }

        /// <summary>
        /// Start location
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
        /// ESnd location
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
        /// Virtual odometer at trip start
        /// </summary>
        /// <value>
        /// The start virtual odometer.
        /// </value>
        public double? StartMilage { get; set; }

        /// <summary>
        /// Virtual odometer at trip end
        /// </summary>
        /// <value>
        /// The end virtual odometer.
        /// </value>
        public double? EndMilage { get; set; }

        /// <summary>
        /// Real odometer at trip start
        /// </summary>
        /// <value>
        /// The start real odometer.
        /// </value>
        public double? StartOdometer { get; set; }

        public object Clone()
        {
            Trip clone = this.MemberwiseClone() as Trip;
            if (clone.StartLocation != null)
                clone.StartLocation = this.StartLocation.Clone() as Location;
            if (clone.LastKnownLocation != null)
                clone.LastKnownLocation = this.LastKnownLocation.Clone() as Location;
            if (clone.EndLocation != null)
                clone.EndLocation = this.EndLocation.Clone() as Location;
            if (clone.StartAddress != null)
                clone.StartAddress = this.StartAddress.Clone() as Address;
            if (clone.EndAddress != null)
                clone.EndAddress = this.EndAddress.Clone() as Address; 
            return clone;
        }
    }
}
