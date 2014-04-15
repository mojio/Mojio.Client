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
    public class SubscriptionConverter : Converter<Subscription>
    {
        /// <summary>Creates the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="jsonObject">The json object.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        protected override Subscription Create (Type objectType, JObject jsonObject, JsonSerializer serializer)
        {
            // default type
            EventType eventType = EventType.Information;
            if (jsonObject ["Event"] != null)
            if (!Enum.TryParse<EventType> (jsonObject ["Event"].ToString (), true, out eventType)) {
                // TODO: log parsing error here.
                eventType = EventType.Information;
            }

            switch (eventType) {
            case EventType.HardAcceleration:
            case EventType.HardBrake:
            case EventType.HardLeft:
            case EventType.HardRight:
                return new HardSubscription ();
            case EventType.Speed:
                return new SpeedSubscription ();
            case EventType.LowFuel:
                return new LowFuelSubscription ();
            default:
                return new Subscription ();
            }
        }
    }
}