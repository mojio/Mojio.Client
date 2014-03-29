using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Converters
{
    public class ObserverConverter : Converter<Observer>
    {
        protected override Observer Create(Type objectType, Newtonsoft.Json.Linq.JObject jsonObject, JsonSerializer serializer)
        {
            // default type
            ObserverType observerType = ObserverType.Generic;
            if (jsonObject["Type"] != null)
                if (!Enum.TryParse<ObserverType>(jsonObject["Type"].ToString(), true, out observerType))
                    throw new ArgumentException("Unknown observer type: " + observerType);

            switch (observerType)
	        {
                case ObserverType.Script:
                    return new ScriptObserver();
                case ObserverType.Event:
                    return new EventObserver();
                default:
                case ObserverType.Generic:
                    return new Observer();
            }
        }
    }
}
