using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class Trip : GuidEntity
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
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// maximum speed
        /// </summary>
        public float? MaxSpeed { get; set; }

        /// <summary>
        /// average speed
        /// </summary>
        public float? AverageSpeed
        {
            get
            {
                if( Distance != null && MovingTime != null && MovingTime > 0)
                    return Distance / MovingTime * 3.6F;    // m/s => km/h
                return null;
            }
        }

        /// <summary>
        /// fuel consumed
        /// </summary>
        public float? Fuel { get; set; }

        /// <summary>
        /// distance travelled
        /// </summary>
        public float? Distance { get; set; }

        /// <summary>
        /// idle percentage
        /// </summary>
        public float? IdlePercent { get { return IdleTime / (MovingTime+IdleTime+StopTime); } }

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
    }
}
