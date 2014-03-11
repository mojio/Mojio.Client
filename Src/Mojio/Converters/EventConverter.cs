using Mojio.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using System;

namespace Mojio.Converters
{
    /// <summary>
    /// 
    /// </summary>
    public class EventConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert (Type objectType)
        {
            return typeof(Event).IsAssignableFrom (objectType);
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson (JsonReader reader, Type objectType,
                                        object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var jsonObject = JObject.Load (reader);
            var target = Create (objectType, jsonObject, serializer);
            serializer.Populate (jsonObject.CreateReader (), target);
            return target;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON.
        /// </summary>
        /// <value>
        /// <c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.
        /// </value>
        public override bool CanWrite {
            get {
                return false;
            }
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException ();
        }

        /// <summary>Creates the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="jsonObject">The json object.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        protected Event Create (Type objectType, JObject jsonObject, JsonSerializer serializer)
        {
            // default type
            EventType eventType = EventType.Information;

            if (jsonObject ["EventType"] != null)
            if (!Enum.TryParse<EventType> (jsonObject ["EventType"].ToString (), true, out eventType)) {
                // TODO: log parsing error here.
                eventType = EventType.Information;
            }

            switch (eventType) {
            case EventType.MojioIdle:
            case EventType.MojioWake:
            case EventType.MojioOn:
            case EventType.MojioOff:
                return new PowerEvent ();
            //case EventType.TripStart:
            //    return new TripStartEvent ();
            //case EventType.TripEnd:
            //    return new TripEndEvent ();
            case EventType.TripStatus:
                return new TripStatusEvent ();
            case EventType.IgnitionOn:
            case EventType.IgnitionOff:
                return new IgnitionEvent ();
            case EventType.FenceEntered:
                return new FenceEvent(false);

            case EventType.FenceExited:
                return new FenceEvent (true);
            case EventType.HardAcceleration:
            case EventType.HardBrake:
            case EventType.HardLeft:
            case EventType.HardRight:
                return new HardEvent (eventType);
            case EventType.Accident:
            case EventType.TripEvent:
                return new TripEvent ();
            case EventType.Diagnostic:
                return new DiagnosticEvent ();
            case EventType.TowStart:
            case EventType.TowStop:
                return new TowEvent();
            case EventType.LowBattery:
                return new BatteryEvent();
            default:
                return new Event ();
            }
        }
    }
}