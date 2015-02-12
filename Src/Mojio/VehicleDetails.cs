﻿using System;
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
        public Transmission DefaultTransmission { get; set; }
        public String FuelTankSize { get; set; }
        public List<Engine> Engines { get; set; }
        public List<Transmission> Transmissions { get; set; }
        public List<Warranty> Warranties { get; set; }

        public class Warranty
        {
            public string Name { get; set; }
            public string Type { get; set; }
            public string Months { get; set; }
            public string Miles { get; set; }
        }

        public class Engine
        {

            public string Name { get; set; }
            public string Brand { get; set; }
            public string MarketingName { get; set; }
            public string EngineId { get; set; }
            public string Availability { get; set; }
            public string Aspiration { get; set; }
            public string BlockType { get; set; }
            public string Bore { get; set; }
            public string CamType { get; set; }
            public string Compression { get; set; }
            public string Cylinders { get; set; }
            public string Displacement { get; set; }
            public string FuelInduction { get; set; }
            public string FuelQuality { get; set; }
            public string FuelType { get; set; }
            public string Msrp { get; set; }
            public string InvoicePrice { get; set; }
            public string MaxHp { get; set; }
            public string MaxHpAt { get; set; }
            public string MaxPayload { get; set; }
            public string MaxTorque { get; set; }
            public string MaxTorqueAt { get; set; }
            public string OilCapacity { get; set; }
            public string OrderCode { get; set; }
            public string Redline { get; set; }
            public string Stroke { get; set; }
            public string ValveTiming { get; set; }
            public string Valves { get; set; }
        }

        public class Transmission
        {
            public string Name { get; set; }
            public string Brand { get; set; }
            public string MarketingName { get; set; }
            public string TransmissionId { get; set; }
            public string Availability { get; set; }
            public string Type { get; set; }
            public string DetailType { get; set; }
            public string Gears { get; set; }
            public string Msrp { get; set; }
            public string InvoicePrice { get; set; }
            public string OrderCode { get; set; }
        }
        
    }
}
