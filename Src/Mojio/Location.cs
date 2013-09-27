using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class Location
    {
        /// <summary>
        /// latitude coordinate
        /// </summary>
        public float Lat { get; set; }

        /// <summary>
        /// longitiude coordinate
        /// </summary>
        public float Lng { get; set; }

        /// <summary>
        /// Geospatial coordinates. Used by MongoDB.
        /// Axis order: Longitude, Latitude
        /// </summary>
        [JsonIgnore]
        public float[] Coordinates
        {
            get
            {
                return new float[] { Lng, Lat };
            }
            set
            {
                Lng = value[0];
                Lat = value[1];
            }
        }

        public bool IsEmpty()
        {
            return Lat == 0.0F && Lng == 0.0F;
        }

        public override string ToString()
        {
            return string.Format("Lat: {0}, Lng: {1}", Lat, Lng);
        }
    }
}
