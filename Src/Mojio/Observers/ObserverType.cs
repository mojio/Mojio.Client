using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public enum ObserverType
    {
        Generic = 0,
        Script = 1, // not implemented
        Event = 2, // not implemented
        GeoFence = 3,
        Conditional = 4,
        Speed = 5,
        RPM = 6,
        Acceleration = 7,
        Accelerometer = 8, 
        Battery = 9, 
        Fuel = 10,
        MIleage = 11, 
        Odometer = 12,
        Altitude = 13,
        Heading = 14
    }


}
