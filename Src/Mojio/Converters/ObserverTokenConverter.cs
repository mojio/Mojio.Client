using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Converters
{
    public class ObserverTokenConverter : Converter<ObserverToken>
    {
        protected override ObserverToken Create(Type objectType, Newtonsoft.Json.Linq.JObject jsonObject, JsonSerializer serializer)
        {
            // default type
            Transport transport = Transport.Pubnub;
            if (jsonObject["Tranport"] == null ||
                !Enum.TryParse<Transport>(jsonObject["Tranport"].ToString(), true, out transport))
                throw new ArgumentException("Unknown observer type: " + transport);

            switch (transport)
            {
                case Transport.SignalR:
                case Transport.ApplePush:
                case Transport.AndroidPush:
                case Transport.HttpPost:
                    return null;
                default:
                case Transport.Pubnub:
                    return new PubnubObserverToken();
            }
        }
    }
}
