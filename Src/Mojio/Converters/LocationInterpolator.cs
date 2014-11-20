using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Converters
{
    class Interpolator
    {
        public static double InterpolateValue(double v0, double v1, double index, double resolution)
        {
            return v1 * (index / resolution) + v0 * ((resolution - index) / resolution);
        }

        public static DateTime InterpolateDateTime(DateTime date0, DateTime date1, double index, double resolution)
        {
            // convert to julian and back for the calculation...
            double v0 = date0.Ticks;
            double v1 = date1.Ticks;
            double between = v1 * (index / resolution) + v0 * ((resolution - index) / resolution);
            return new DateTime((long)between); 
        }
        public static List<Location> InterpolateLocation(Location previous, Location now, double resolution)
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
                location.Lat = InterpolateValue(previous.Lat, now.Lat, (double)i , resolution);
                location.Lng = InterpolateValue(previous.Lng, now.Lng, (double)i, resolution);

                locations.Add(location);
            }
            return locations;
        }
        public static List<DateTime> InterpolateTime(DateTime previous, DateTime now, double resolution)
        // resolution is the number of sample points between the two locations plus the two endpoints.
        {
            var times = new List<DateTime>();
            // save on some calculating, just return the given points if two or less points are requested
            if (resolution <= 1)
            {
                times.Add(now);
                return times;
            }
            // something stupid to start out, just interpolate linearly along each axis.
            for (int i = 1; i <= resolution; i++)
            {
                times.Add(InterpolateDateTime(previous, now, (double)i, resolution));
            }
            return times;
        }
    }
}
