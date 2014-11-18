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
            if (resolution <= 2)
            {
                locations.Add(previous);
                locations.Add(now);
                return locations;
            }
            // something stupid to start out, just interpolate linearly along each axis.
            for (int i = 0; i <= resolution; i++)
            {
                if (i == 0)
                    locations.Add(previous);
                else if (i == resolution)
                    locations.Add(now);
                else
                {
                    Location location = new Location();
                    location.Lat = previous.Lat + ((now.Lat + previous.Lat) * (double)i) / resolution;
                    location.Lng = previous.Lng + ((now.Lng + previous.Lng) * (double)i) / resolution;
                    locations.Add(location);
                }
            }
            return locations;
        }
    }
}
