using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class VehicleUpdateRequest : IVehicleUpdateRequest
    {
        public string Name { get; set; }

        public string LicensePlate { get; set; }

        public int? Odometer { get; set; }

        public string VIN { get; set; }
    }
}
