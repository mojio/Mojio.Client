using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Xirgo Specific Enums for now...  
    /// For different devices, use a switch/case statement to map values to enums...
    /// </summary>
    public enum GpsState
    {
        NotLocked = 0,
        Locked = 1,
        LostComm = 2,
        PwrSaveMode = 3,
    }

    ///// <summary>
    ///// Xirgo Specific Cellular Registration State.
    ///// For different devices, use a switch/case statement to map values to enums...
    ///// </summary>
    //public enum RegistrationState
    //{
    //    UnRegistered = 0,
    //    Home = 1,
    //    Search = 2,
    //    Denied = 3,
    //    Unknown = 4,
    //    Roaming = 5
    //}

    public class MojioReport : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.MojioReport; }
        }

        public string PacketString { get; set; }
        public string Imei { get; set; }
        public string Email { get; set; }
        public string VehicleName { get; set; }
        public string OpCode { get; set; }
        public string SequenceNumber { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public double? Speed { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Altitude { get; set; }
        public double? Acceleration { get; set; }
        public double? Deceleration { get; set; }
        public int? RPM { get; set; }
        public double? Heading { get; set; }
        public string VIN { get; set; }
        public int? NumSattelites { get; set; }
        public double? HDOP { get; set; }
        public double? BatteryVoltage { get; set; }
        public double? FuelLevel { get; set; }
        public double? MileageSinceAlert { get; set; }
        public double? FuelConsumption { get; set; }
        public double? GSMStrength { get; set; }
        public double? GPSLostTime { get; set; }

        public GpsState? _gpsState = new GpsState();
        public GpsState? GPSState
        {
            get { return _gpsState; }

            set { _gpsState = value; }
        }

        public double? AccelerometerX { get; set; }
        public double? AccelerometerY { get; set; }
        public double? AccelerometerZ { get; set; }
        public int? NumDtc { get; set; }
        public bool? MilStatus { get; set; }
        public bool? Ignition { get; set; }
        public string GeoFence { get; set; }
        public string[] DTC { get; set; }
        public string TcuPacificTime { get; set; }
        public string ServerPacificTime { get; set; }
        public string SequenceReport { get; set; }
        public DateTime TcuTimestamp { get; set; }
        public DateTime ServerTimestamp { get; protected set; }
        public DateTime IgnitionOnPacificTime { get; set; }
        public TimeSpan MessageTimespan { get; set; }

        public Dictionary<string, Object> AsDictionary()
        {
            var dict = new Dictionary<string, Object>();

            try
            {
                // use introspection to write out the fields.
                PropertyInfo[] fields = this.GetType().GetProperties();
                foreach (PropertyInfo field in fields)
                {
                    var value = field.GetValue(this, null);
                    dict[field.Name] = value != null ? value : "";
                }
                return dict;
            }
            catch (Exception ex)
            {
                //Log.Create(ex).Submit();
            }
            return dict;
        }
    }
}
