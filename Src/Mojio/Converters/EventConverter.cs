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
    public class EventConverter : Converter<Event>
    {
        /// <summary>Creates the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="jsonObject">The json object.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        protected override Event Create (Type objectType, JObject jsonObject, JsonSerializer serializer)
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
            case EventType.Speed:
                return new SpeedEvent();
            case EventType.Park:
                return new ParkEvent();
            case EventType.Mileage:
                return new MileageEvent();
            case EventType.HeadingChange:
                return new HeadingChangeEvent();
            case EventType.Acceleration:
                return new AccelerationEvent();
            case EventType.Deceleration:
                return new DecelerationEvent();
            case EventType.Accelerometer:
                return new AccelerometerEvent();
            case EventType.LowFuel:
                return new FuelEvent();
            case EventType.RPM:
                return new RPMEvent();
            case EventType.MovementStart:
            case EventType.MovementStop:
                return new MovementEvent();
            case EventType.HeartBeat:
                return new HeartBeatEvent();
            case EventType.DeviceDiagnostic:
                return new DeviceDiagnosticEvent();
            default:
                return new Event ();
            }
        }
    }
}