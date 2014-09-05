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
               .Contains<ScriptObserver>(ObserverType.Script)
               .Contains<GeoFenceObserver>(ObserverType.GeoFence);

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
                .Contains<App>(EntityType.App)
                .Contains<Access>(EntityType.Access)
                .Contains<SimCard>(EntityType.SimCard)
                .Contains<MojioReport>(EntityType.MojioReport)
                ;

            // The following allows a partial file to continue
            // building the map
            Map<Event, EventType>(e => e.EventType)
                .Contains<TripEvent>(EventType.TripEvent)
                .Contains<PowerEvent>(EventType.MojioOn)
                .Contains<PowerEvent>(EventType.MojioIdle)
                .Contains<PowerEvent>(EventType.MojioWake)
                .Contains<PowerEvent>(EventType.MojioOff)
                .Contains<IgnitionEvent>(EventType.IgnitionOn)
                .Contains<IgnitionEvent>(EventType.IgnitionOff)
                .Contains<BatteryEvent>(EventType.LowBattery)
                .Contains<FenceEvent>(EventType.FenceEntered)
                .Contains<FenceEvent>(EventType.FenceExited)
                .Contains<TripStatusEvent>(EventType.TripStatus)
                .Contains<ConnectionLost>(EventType.ConnectionLost)
                .Contains<TripEvent>(EventType.Accident)
                .Contains<Event>(EventType.MILWarning)
                .Contains<TowEvent>(EventType.TowStart)
                .Contains<TowEvent>(EventType.TowStop)
                .Contains<HardEvent>(EventType.HardAcceleration)
                .Contains<HardEvent>(EventType.HardBrake)
                .Contains<HardEvent>(EventType.HardRight)
                .Contains<HardEvent>(EventType.HardLeft)
                .Contains<SpeedEvent>(EventType.Speed)
                .Contains<DiagnosticEvent>(EventType.Diagnostic)
                .Contains<OffStatusEvent>(EventType.OffStatus)
                .Contains<ParkEvent>(EventType.Park)
                .Contains<AccelerometerEvent>(EventType.Accelerometer)
                .Contains<AccelerationEvent>(EventType.Acceleration)
                .Contains<DecelerationEvent>(EventType.Deceleration)
                .Contains<HeadingChangeEvent>(EventType.HeadingChange)
                .Contains<MileageEvent>(EventType.Mileage)
                .Contains<FuelEvent>(EventType.LowFuel)
                .Contains<MovementEvent>(EventType.MovementStart)
                .Contains<MovementEvent>(EventType.MovementStop)
                .Contains<HeartBeatEvent>(EventType.HeartBeat)
                .Contains<DeviceDiagnosticEvent>(EventType.DeviceDiagnostic)
                .Contains<RPMEvent>(EventType.RPM);
                           
            BuildMap();
            /*Map<Event, EventType>(e => e.EventType)
                .Contains<AccelerationEvent>(EventType.Acceleration)
                .Contains<AccelerometerEvent>(EventType.Accelerometer);*/

        }
    }

}
