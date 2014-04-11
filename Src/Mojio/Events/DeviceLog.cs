using System.Collections.Generic;
using Mojio.Converters;
using Newtonsoft.Json;
using System;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDeviceLog
    {
        /// <summary>
        /// IMEI
        /// </summary>
        string Imei { get; set; }

        /// <summary>
        /// mojio Id
        /// </summary>
        Guid MojioId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        Guid? OwnerId { get; set; }

        /// <summary>
        /// event timestamp
        /// </summary>
        DateTime Timestamp { get; set; }

        /// <summary>
        /// vehicle Id
        /// </summary>
        Guid VehicleId { get; set; }
    }

    /// <summary>
    /// device log
    /// </summary>
    public partial class DeviceLog : GuidEntity, IDeviceLog, IOwner, ICloneable
    {
        public DeviceLog()
        {
        }

        /// <summary>
        /// IMEI
        /// </summary>
        public string Imei { get; set; }

        /// <summary>
        /// mojio Id
        /// </summary>
        [Observable(typeof(Mojio))]
        public Guid MojioId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        [Observable(typeof(User))]
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// timestamp
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// vehicle Id
        /// </summary>
        [Observable(typeof(Vehicle))]
        public Guid VehicleId { get; set; }

        public Mojio Mojio { get; set; }
        public byte[] PacketBytes { get; set; }
        public string PacketString { get; set; }
        public Dictionary<string, Object> Tcu { get; set; }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
