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
    }

    /// <summary>
    /// event
    /// </summary>
    [JsonConverter(typeof(DiscriminatorConverter<Event>))]
    public partial class Event : GuidEntity, IEvent
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

        /// <summary>
        /// Accelerometer
        /// </summary>
        public Accelerometer Accelerometer { get; set; }

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
        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public static bool operator ==(Event a, Event b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }
            return a.EventType == b.EventType;
        }
        public static bool operator !=(Event a, Event b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return true;
            }
            return a.EventType != b.EventType;
        }

        public override bool Equals(System.Object obj)
        {
            // If parameter cannot be cast to Event return false:
            Event p = obj as Event;
            if ((object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return base.Equals(obj);
        }

        public bool Equals(Event p)
        {
            // Return true if the fields match:
            return base.Equals(p);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Event a, EventType eventType)
        {
            if (System.Object.ReferenceEquals(a.EventType, eventType))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a.EventType == null) || ((object)eventType == null))
            {
                return false;
            } 
            return a.EventType == eventType;
        }

        public static bool operator !=(Event a, EventType eventType)
        {
            if (System.Object.ReferenceEquals(a.EventType, eventType))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if (((object)a.EventType == null) || ((object)eventType == null))
            {
                return true;
            }
            return a.EventType != eventType;
        }
    }
}
