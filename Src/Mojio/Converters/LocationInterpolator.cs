using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Converters
{
    class LocationInterpolator
    {
        public static List<Location> Interpolate(Location previous, Location now, double resolution)
        // resolution is the number of sample points between the two locations plus the two endpoints.
        {
            var locations = new List<Location>();
            // save on some calculating, just return the given points if two or less points are requested
            if (resolution <= 1)
            {
                locations.Add(now);
                return locations;
            }
            // something stupid to start out, just interpolate linearly along each axis.
            for (int i = 1; i <= resolution; i++)
            {
                Location location = new Location();

                location.Lat = now.Lat * ((double)i / resolution) + previous.Lat * (((double)resolution - (double)i) / resolution);
                location.Lng = now.Lng * ((double)i / resolution) + previous.Lng * (((double)resolution - (double)i) / resolution);

                locations.Add(location);
            }
            return locations;
        }
    }
}
