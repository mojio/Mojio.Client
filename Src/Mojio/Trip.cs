using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public partial class Trip : GuidEntity
    {
        /// <summary>
        /// mojio id
        /// </summary>
        public string MojioId { get; set; }

        /// <summary>
        /// start timestamp
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// end timestamp
        /// </summary>
        public DateTime? LastUpdatedTime { get; set; }

        /// <summary>
        /// end timestamp
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// maximum speed
        /// </summary>
        public float? MaxSpeed { get; set; }

        /// <summary>
        /// maximum rpm
        /// </summary>
        public int? MaxRPM { get; set; }

        /// <summary>
        /// fuel consumed
        /// </summary>
        public float? Fuel { get; set; }

        /// <summary>
        /// distance travelled
        /// </summary>
        public float? Distance { get; set; }

        /// <summary>
        /// time moving
        /// </summary>
        public float? MovingTime { get; set; }

        /// <summary>
        /// idle time
        /// </summary>
        public float? IdleTime { get; set; }

        /// <summary>
        /// time stopped
        /// </summary>
        public float? StopTime { get; set; }

        /// <summary>
        /// start location
        /// </summary>
        public Location StartLocation { get; set; }

        /// <summary>
        /// end location
        /// </summary>
        public Location EndLocation { get; set; }

        /// <summary>
        /// Address where the trip started
        /// </summary>
        public Address StartAddress { get; set; }

        /// <summary>
        /// Address where the trip ended
        /// </summary>
        public Address EndAddress { get; set; }

        /// <summary>
        /// Forcefully Ended the trip
        /// </summary>
        public bool? ForcefullyEnded { get; set; }
    }
}
