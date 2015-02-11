using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public partial class VehicleDetails : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.VehicleDetails; }
        }

        public string VIN { get; set; }
        public DateTimeOffset Timestamp { get; set; }
        public string Market { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Trim { get; set; }
        public string VehicleType { get; set; }
        public string BodyType { get; set; }
        public string BodySubtype { get; set; }
        public string OEMBodyStyle { get; set; }
        public string Doors { get; set; }
        public string OEMDoors { get; set; }
        public string ModelNumber { get; set; }
        public string PackageCode { get; set; }
        public string DriveType { get; set; }
        public string BrakeSystem { get; set; }
        public string RestraintType { get; set; }
        public string CountryOfManufacture { get; set; }
        public string Plant { get; set; }
        public Engine InstalledEngine { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public List<Warranty> Warranties { get; set; }

        public class Warranty
        {
        }

        public class Engine
        {
        }

        public class Transmission
        {
        }
        
    }
}
