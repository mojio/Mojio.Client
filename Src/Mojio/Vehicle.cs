using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Observable]
    public partial class Vehicle : GuidEntity, IOwner, IViewers
    {
        public override EntityType Type {
            get { return EntityType.Vehicle; }
        }

        /// <summary>
        /// Owner ID
        /// </summary>
        [Observable (typeof(User))]
        [Parent (typeof(User))]

        public Guid? OwnerId { get; set; }

        /// <summary>
        /// Gets or sets the mojio identifier.
        /// </summary>
        /// <value>
        /// The mojio identifier.
        /// </value>
        [Observable (typeof(Mojio))]
        public Guid? MojioId { get; set; }

        [DefaultSort]
        /// <summary>
        /// Vehicle name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Vehicle Identification Number
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// License plate
        /// </summary>
        /// <value>The license plate.</value>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Optional is ignition on?
        /// </summary>
        public bool? IgnitionOn { get; set; }

        /// <summary>
        /// Most recent trip event
        /// </summary>
        public Guid? LastTripEvent { get; set; }

        /// <summary>
        /// Last location time
        /// </summary>
        public DateTime? LastLocationTime { get; set; }

        /// <summary>
        /// Last known location
        /// </summary>
        public Location LastLocation { get; set; }

        /// <summary>
        /// Last known speed
        /// </summary>
        public double LastSpeed { get; set; }

        /// <summary>
        /// Last known fuel level
        /// </summary>
        public double? FuelLevel { get; set; }

        /// <summary>
        /// Last known acceleration/deceleration
        /// </summary>
        public double? LastAcceleration { get; set; }

        /// <summary>Last Accelerometer Value 
        /// </summary>
        public Accelerometer LastAccelerometer { get; set; }

        /// <summary>
        /// Last known Altitude
        /// </summary>
        public double? LastAltitude { get; set; }

        /// <summary>
        /// Last known Battery Voltage
        /// </summary>
        public double? LastBatteryVoltage { get; set; }

        /// <summary>
        /// Last known Distance
        /// </summary>
        public double? LastDistance { get; set; }

        /// <summary>
        /// Last known Heading
        /// </summary>
        public double? LastHeading { get; set; }

        /// <summary>
        /// Last known Odometer
        /// </summary>
        public double? LastOdometer { get; set; }

        /// <summary>
        /// Last known RPM
        /// </summary>
        public double? LastRpm { get; set; }

        /// 
        public double LastFuelEfficiency { get; set; }

        /// <summary>
        /// Current trip ID
        /// </summary>
        public Guid? CurrentTrip { get; set; }

        /// <summary>
        /// Current trip ID
        /// </summary>
        public Guid? LastTrip { get; set; }

        /// <summary>
        /// Most recent communication time
        /// </summary>
        public DateTime? LastContactTime { get; set; }

        /// <summary>
        /// Malfunction Indicator Lamp (Check Engine Light)
        /// </summary>
        public bool? MilStatus { get; set; }

        public DTCStatus DiagnosticCodes { get; set; }

        /// <summary>
        /// Public boolean flag to indicate DTC faults have been detected
        /// </summary>
        public bool FaultsDetected { get; set; }

        /// <summary>
        /// Last several known times, set by the chunking observers
        /// </summary>
        private List<DateTime?> _lastLocationTimes;
        public List<DateTime?> LastLocationTimes
        {
            get
            {
                if (_lastLocationTimes == null)
                    _lastLocationTimes = new List<DateTime?>();
                return this._lastLocationTimes;
            }
            set
            {
                this._lastLocationTimes = value;
            }
        }

        /// <summary>
        /// Last several known locations, set by the chunking observers
        /// </summary>
        private List<Location> _lastLocations;

        public List<Location> LastLocations
        {
            get
            {
                if (_lastLocations == null)
                    _lastLocations = new List<Location>();
                return this._lastLocations;
            }
            set
            {
                this._lastLocations = value;
            }
        }

        /// <summary>
        /// Last several known speeds, set by the chunking observers
        /// </summary>
        private List<double> _lastSpeeds;

        public List<double> LastSpeeds
        {
            get
            {
                if (_lastSpeeds == null)
                    _lastSpeeds = new List<double>();
                return this._lastSpeeds;
            }
            set
            {
                this._lastSpeeds = value;
            }
        }
        /// <summary>
        /// Last several known headings, set by the chunking observers
        /// </summary>
        private List<double> _lastHeading;

        public List<double> LastHeadings
        {
            get
            {
                if (_lastHeading == null)
                    _lastHeading = new List<double>();
                return this._lastHeading;
            }
            set
            {
                this._lastHeading = value;
            }
        }
        /// <summary>
        /// Last several known altitudes, set by the chunking observers
        /// </summary>
        private List<double> _lastAltitudes;

        public List<double> LastAltitudes
        {
            get
            {
                if (_lastAltitudes == null)
                    _lastAltitudes = new List<double>();
                return this._lastAltitudes;
            }
            set
            {
                this._lastAltitudes = value;
            }
        } 
        // TODO: Maybe Viewers should be in private?
        /// <summary>
        /// List of viewer IDs
        /// </summary>
        public Guid[] Viewers { get; set; }

        public object Clone()
        {
            Vehicle clone = this.MemberwiseClone() as Vehicle;
            if (clone.LastLocation!=null)
                clone.LastLocation = this.LastLocation.Clone() as Location;
            if (clone.LastAccelerometer != null)
                clone.LastAccelerometer = this.LastAccelerometer.Clone() as Accelerometer;
            if (clone.DiagnosticCodes != null)
                clone.DiagnosticCodes = this.DiagnosticCodes.Clone() as DTCStatus;
            return clone;
        }
    }
}
