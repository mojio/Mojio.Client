using Mojio.Events;
using Mojio;
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
                .Contains<Observer>(EntityType.Observer)
                .Contains<Subscription>(EntityType.Subscription)
                .Contains<Event>(EntityType.Event)
                .Contains<Mojio>(EntityType.Mojio)
                .Contains<App>(EntityType.App)
                .Contains<Access>(EntityType.Access)
                .Contains<SimCard>(EntityType.SimCard)
                ;

            // The following allows a partial file to continue
            // building the map
            Map<Event, EventType>(e => e.EventType)
                .Contains<TripEvent>(EventType.TripEvent)
                    // Trip events
                    .Contains<TripEvent>(EventType.Acceleration)
                    .Contains<TripEvent>(EventType.LowBattery)
                    .Contains<TripEvent>(EventType.ConnectionLost)
                    .Contains<TripEvent>(EventType.Deceleration)
                    .Contains<TripEvent>(EventType.FenceEntered)
                    .Contains<TripEvent>(EventType.FenceExited)
                    .Contains<TripEvent>(EventType.LowFuel)
                    .Contains<TripEvent>(EventType.HeadingChange)
                    .Contains<TripEvent>(EventType.IgnitionOn)
                    .Contains<TripEvent>(EventType.IgnitionOff)
                    .Contains<TripEvent>(EventType.Mileage)
                    .Contains<TripEvent>(EventType.MovementStart)
                    .Contains<TripEvent>(EventType.MovementStop)
                    .Contains<TripEvent>(EventType.RPM)
                    .Contains<TripEvent>(EventType.Speed)
                    .Contains<TripEvent>(EventType.TowStart)
                    .Contains<TripEvent>(EventType.TowStop)
                .Contains<TripStatusEvent>(EventType.TripStatus)
                .Contains<HardEvent>(EventType.HardAcceleration)
                .Contains<HardEvent>(EventType.HardBrake)
                .Contains<HardEvent>(EventType.HardRight)
                .Contains<HardEvent>(EventType.HardLeft)
                .Contains<DiagnosticEvent>(EventType.Diagnostic)
                .Contains<OffStatusEvent>(EventType.OffStatus)
                .Contains<HeartBeatEvent>(EventType.HeartBeat)
                .MapUnmappedTo(typeof(Event));

            BuildMap();
            /*Map<Event, EventType>(e => e.EventType)
                .Contains<AccelerationEvent>(EventType.Acceleration)
                .Contains<AccelerometerEvent>(EventType.Accelerometer);*/

        }
    }

}
