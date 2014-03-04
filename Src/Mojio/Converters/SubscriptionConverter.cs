using Mojio.Events;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Utilities;
using System;

namespace Mojio.Converters
{
    public class SubscriptionConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Subscription).IsAssignableFrom(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType,
          object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject, serializer);
            serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        protected Subscription Create(Type objectType, JObject jsonObject, JsonSerializer serializer)
        {
            // default type
            EventType eventType = EventType.Information;

            if (jsonObject["Event"] != null)
                if (!Enum.TryParse<EventType>(jsonObject["Event"].ToString(), true, out eventType))
                {
                    // TODO: log parsing error here.
                    eventType = EventType.Information;
                }

            switch (eventType)
            {
                case EventType.HardAcceleration:
                case EventType.HardBrake:
                case EventType.HardLeft:
                case EventType.HardRight:
                    return new HardSubscription();
                case EventType.Speed:
                    return new SpeedSubscription();

                default:
                    return new Subscription();
            }
        }
    }
}