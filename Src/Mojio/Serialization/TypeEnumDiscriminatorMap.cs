using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio.Serialization
{

    public partial class TypeEnumDiscriminatorMap
    {
        static partial void BuildMap();

        static TypeEnumDiscriminatorMap()
        {
            Maps = new Dictionary<Type, TypeEnumDiscriminatorMap>();

            Map<ObserverToken, Transport>(o => o.Transport)
                .Contains<PubnubObserverToken>(Transport.Pubnub);

            Map<Observer, ObserverType>(o => o.ObserverType)
               .Contains<Observer>(ObserverType.Generic)
               .Contains<EventObserver>(ObserverType.Event)
               .Contains<ScriptObserver>(ObserverType.Script);

            Map<GuidEntity, EntityType>(e => e.Type)
                .Contains<Token>(EntityType.Token)
                .Contains<Vehicle>(EntityType.Vehicle)
                .Contains<Storage>(EntityType.Storage)
                .Contains<Product>(EntityType.Product)
                .Contains<DTC>(EntityType.DTC)
                .Contains<Trip>(EntityType.Trip)
                .Contains<Invoice>(EntityType.Invoice)
                .Contains<User>(EntityType.User)
                .Contains<Log>(EntityType.Log)
                .Contains<Observer>(EntityType.Observer)
                .Contains<Subscription>(EntityType.Subscription)
                .Contains<Event>(EntityType.Event)
                .Contains<Mojio>(EntityType.Mojio)
                .Contains<App>(EntityType.App);

            // The following allows a partial file to continue
            // building the map

            BuildMap();
            /*Map<Event, EventType>(e => e.EventType)
                .Contains<AccelerationEvent>(EventType.Acceleration)
                .Contains<AccelerometerEvent>(EventType.Accelerometer);*/

        }
    }

}
