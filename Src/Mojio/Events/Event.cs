using Mojio.Converters;
using Mojio.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEvent
    {
        
        /// <summary>
        /// mojio Id
        /// </summary>
        Guid MojioId { get; set; }

        /// <summary>
        /// vehicle Id
        /// </summary>
        Guid VehicleId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        Guid? OwnerId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        EventType EventType { get; set; }

        /// <summary>
        /// event timestamp
        /// </summary>
        DateTime Time { get; set; }

        /// <summary>
        /// location
        /// </summary>
        Location Location { get; set; }

        /// <summary>
        /// accelerometer
        /// </summary>
        Accelerometer Accelerometer { get; set; }
    }

    /// <summary>
    /// event
    /// </summary>
    [JsonConverter(typeof(DiscriminatorConverter<Event>))]
    public partial class Event : GuidEntity, IEvent, IOwner
    {
        public override EntityType Type
        {
            get { return EntityType.Event; }
        }
        public Event()
        {
        }

        public Event(EventType type)
        {
            EventType = type;
        }

        /// <summary>
        /// mojio Id
        /// </summary>
        [Observable(typeof(Mojio))]
        public Guid MojioId { get; set; }

        /// <summary>
        /// vehicle Id
        /// </summary>
        [Observable(typeof(Vehicle))]
        [Parent(typeof(Vehicle))]
        public Guid VehicleId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        [Observable(typeof(User))]
        [Parent(typeof(User))]
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        public EventType EventType { get; set; }

        [DefaultSort]
        /// <summary>
        /// event timestamp
        /// </summary>
        public DateTime Time { get; set; }

        /// <summary>
        /// location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// location
        /// </summary>
        public Accelerometer Accelerometer { get; set; }

        /// <summary>
        /// TimeIsApproximate
        /// </summary>
        public bool? TimeIsApprox { get; set; }

        /// <summary>
        /// Battery Voltage
        /// </summary>
        public double? BatteryVoltage { get; set; }

        /// <summary>
        /// Connection Lost
        /// </summary>
        public bool? ConnectionLost { get; set; }

        //TODO:: add GSM and GPS status to events.
        ///// <summary>
        ///// GSM Strength
        ///// </summary>
        //public double? GSMStrength { get; set; }

        ///// <summary>
        ///// GPS Connection
        ///// </summary>
        //public double? GPSConnection { get; set; }

        ///// <summary>
        ///// GPS Lost Time
        ///// </summary>
        //public double? GPSLostTime { get; set; }

        ///// <summary>
        ///// GPS State
        ///// </summary>
        //public GpsState? GpsState { get; set; }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone ()
        {
            return this.MemberwiseClone ();
        }
    }
}
