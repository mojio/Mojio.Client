using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio.Serialization
{

    public partial class TypeEnumDiscriminatorMap
    {   
        static TypeEnumDiscriminatorMap()
        {
            Maps = new Dictionary<Type, TypeEnumDiscriminatorMap>();

            Map<ObserverToken, Transport>(o => o.Transport)
                .Contains<PubnubObserverToken>(Transport.Pubnub);

            Map<Observer, ObserverType>(o => o.Type)
               .Contains<Observer>(ObserverType.Generic)
               .Contains<EventObserver>(ObserverType.Event)
               .Contains<ScriptObserver>(ObserverType.Script);

            
            /*Map<Event, EventType>(e => e.EventType)
                .Contains<AccelerationEvent>(EventType.Acceleration)
                .Contains<AccelerometerEvent>(EventType.Accelerometer);*/
        }
    }

}
