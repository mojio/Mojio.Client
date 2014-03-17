using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    /// <summary>
    /// Location
    /// </summary>
    public class Location : ICloneable
    {
        /// <summary>
        /// latitude coordinate
        /// </summary>
         public double Lat { get; set; }

        /// <summary>
        /// longitiude coordinate
        /// </summary>
        public double Lng { get; set; }

        /// <summary>
        /// Was the data obtained from a locked gps reading.
        /// </summary>
        public bool FromLockedGPS { get; set; }

        /// <summary>
        /// possible error area of the lat lon data.  0 is undiluted.
        /// </summary>
        public double Dilution { get; set; }

        /// <summary>
        /// Geospatial coordinates. Used by MongoDB.
        /// Axis order: Longitude, Latitude
        /// </summary>
        [JsonIgnore]
        public double[] Coordinates
        {
            get
            {
                if (!IsValid)
                {
                    return null;
                }

                return new double[] { Lng, Lat };
            }
            set
            {
                Lng = value[0];
                Lat = value[1];
            }
        }

        /// <summary>
        /// Gets a value indicating whether [is valid].
        /// </summary>
        /// <value><c>true</c> if [is valid]; otherwise, <c>false</c>.</value>
        public bool IsValid
        {
            get
            {
                // f#@$!ing floating numbers.
                return !(Lat == double.NaN || Lng == double.NaN);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        public Location()
        {
            Lat = double.NaN;
            Lng = double.NaN;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return string.Format("Lat: {0}, Lng: {1}", Lat, Lng);
        }
        
        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
