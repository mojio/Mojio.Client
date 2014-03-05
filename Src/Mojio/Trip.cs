using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    /// <summary>
    /// Trip
    /// </summary>
    public partial class Trip : GuidEntity
    {
        /// <summary>
        /// mojio id
        /// </summary>
        /// <value>
        /// The mojio identifier.
        /// </value>
        public string MojioId { get; set; }

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
        public float? MaxSpeed { get; set; }

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
        public float? FuelLevel { get; set; }

        /// <summary>
        /// fuel efficiency (liters per 100km)
        /// </summary>
        /// <value>
        /// The fuel efficiency.
        /// </value>
        public float? FuelEfficiency { get; set; }

        /// <summary>
        /// distance travelled
        /// </summary>
        /// <value>
        /// The distance.
        /// </value>
        public float? Distance { get; set; }

        /// <summary>
        /// time moving
        /// </summary>
        /// <value>
        /// The moving time.
        /// </value>
        public float? MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        /// <value>
        /// The idle time.
        /// </value>
        public float? IdleTime { get; set; }

        /// <summary>
        /// time stopped
        /// </summary>
        /// <value>
        /// The stop time.
        /// </value>
        public float? StopTime { get; set; }

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
        /// Last Known Address.
        /// </summary>
        /// <value>
        /// The last known address.
        /// </value>
        public Address LastKnownAddress { get; set; }

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
        public float? StartMilage { get; set; }

        /// <summary>
        /// Milage where the trip ended
        /// </summary>
        /// <value>
        /// The end milage.
        /// </value>
        public float? EndMilage { get; set; }
    }
}
