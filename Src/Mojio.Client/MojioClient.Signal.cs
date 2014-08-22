using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Mojio.Events;
using Mojio.Serialization;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        private TypeEnumDiscriminatorMap<EntityType> _map;
        public TypeEnumDiscriminatorMap<EntityType> EntityDiscriminatorMap
        {
            get
            {
                _map = _map ?? (TypeEnumDiscriminatorMap<EntityType>)TypeEnumDiscriminatorMap.GetMap(typeof(GuidEntity));
                return _map;
            }
        }

        public event MojioObserveHandler ObserveHandler;

        public delegate void MojioObserveHandler(GuidEntity entity);

        public delegate void MojioEventHandler (Event evt);

        public event MojioEventHandler EventHandler;

        public delegate void MojioTripHandler (Trip trip);

        public event MojioTripHandler TripHandler;

        public delegate void MojioErrorHandler (string error);

        public event MojioErrorHandler ErrorHandler;

        private HubConnection _hubConnection;
        private IHubProxy _mojioProxy;

        HubConnection HubConnection {
            get {
                if (_hubConnection == null)
                {
                    _hubConnection = new HubConnection(RestClient.BaseUrl, true);

                    //var s = new RSJsonSerializer();
                    //_hubConnection.JsonSerializer = s.Serializer;
                }

                return _hubConnection;
            }
        }

        public IHubProxy Hub {
            get {
                if (_mojioProxy == null) {
                    _mojioProxy = HubConnection.CreateHubProxy ("hub");

                    // Register callback events
                    _mojioProxy.On<Event> ("event", m => {
                        if (EventHandler != null)
                            EventHandler ((Event) m);
                    });
                    _mojioProxy.On<Trip> ("trip", m => {
                        if (TripHandler != null)
                            TripHandler (m);
                    });
                    _mojioProxy.On<String> ("error", m => {
                        if (ErrorHandler != null)
                            ErrorHandler (m);
                    });

                    HubConnection.Error += (e) =>
                    {
                        //Console.WriteLine("ERROR: {0}", e);
                    };
                }

                return _mojioProxy;
            }
        }

        public IHubProxy ObserverHub
        {
            get
            {
                if (_mojioProxy == null)
                {
                    _mojioProxy = HubConnection.CreateHubProxy("ObserverHub");

                    // Register callback events
                    _mojioProxy.On<GuidEntity>("UpdateEntity", m =>
                    {
                        if (ObserveHandler != null)
                            ObserveHandler(m);
                    });
                    _mojioProxy.On<String>("Error", m =>
                    {
                        if (ErrorHandler != null)
                            ErrorHandler(m);
                    });

                    HubConnection.Error += (e) =>
                    {
                        //Console.WriteLine("ERROR: {0}", e);
                    };
                }

                return _mojioProxy;
            }
        }

        public Task Observe(Observer observer)
        {
            return Observe(observer.Id);
        }

        /// <summary>
        /// Subscribe to new signalR events for a set of entities.
        /// </summary>
        /// <typeparam name="T">Entity Type (Mojio,User,Trip)</typeparam>
        /// <param name="id">Entity IDs</param>
        /// <param name="events">Event types to receive</param>
        /// <returns></returns>
        public async Task Observe(Guid id)
        {
            if (HubConnection.State != ConnectionState.Connected && ObserverHub != null)
                await HubConnection.Start();

            await ObserverHub.Invoke("Subscribe", id);
        }

        public Task Unobserve(Observer observer)
        {
            return Unobserve(observer.Id);
        }

        /// <summary>
        /// Subscribe to new signalR events for a set of entities.
        /// </summary>
        /// <typeparam name="T">Entity Type (Mojio,User,Trip)</typeparam>
        /// <param name="id">Entity IDs</param>
        /// <param name="events">Event types to receive</param>
        /// <returns></returns>
        public async Task Unobserve(Guid id)
        {
            if (HubConnection.State != ConnectionState.Connected && ObserverHub != null)
                await HubConnection.Start();

            await ObserverHub.Invoke("Unsubscribe", id);
        }

        /// <summary>
        /// Subscribe to new signalR events for a particular entity.
        /// </summary>
        /// <typeparam name="T">Entity Type (Mojio,User,Trip)</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="events">Event types to receive</param>
        /// <returns></returns>
        public Task Subscribe<T> (Guid id, EventType[] events)
        {
            return Subscribe<T> (new [] { id }, events);
        }

        /// <summary>
        /// Subscribe to new signalR events for a set of entities.
        /// </summary>
        /// <typeparam name="T">Entity Type (Mojio,User,Trip)</typeparam>
        /// <param name="id">Entity IDs</param>
        /// <param name="events">Event types to receive</param>
        /// <returns></returns>
        public async Task Subscribe<T> (Guid[] id, EventType[] events)
        {
            if (HubConnection.State != ConnectionState.Connected && Hub != null)
                await HubConnection.Start ();

            await Hub.Invoke("Subscribe", Token.Id, EntityDiscriminatorMap.Find(typeof(T)), id, events);
        }

        /// <summary>
        /// Unsubscribe from signalR events for a particular entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public bool Unsubscribe<T> (Guid id, EventType[] events)
        {
            return Unsubscribe<T> (new [] { id }, events);
        }

        /// <summary>
        /// Unsubscribe from signalR events for a set of entities.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity IDs</param>
        /// <param name="events">Event Types</param>
        /// <returns></returns>
        public bool Unsubscribe<T> (Guid[] id, EventType[] events)
        {
            Hub.Invoke("Unsubscribe", /*Token.Id,*/EntityDiscriminatorMap.Find(typeof(T)), id, events);
            return true;
        }

        /// <summary>
        /// Close signalR connection.
        /// </summary>
        public void Close ()
        {
            HubConnection.Stop ();
        }
    }
}
