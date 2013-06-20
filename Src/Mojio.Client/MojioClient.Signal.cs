using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
using Mojio.Events;
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
        public delegate void MojioEventHandler(Event evt);
        public event MojioEventHandler EventHandler;

        public delegate void MojioTripHandler(Trip trip);
        public event MojioTripHandler TripHandler;

        public delegate void MojioErrorHandler(string error);
        public event MojioErrorHandler ErrorHandler;

        private HubConnection _hubConnection;
        private IHubProxy _mojioProxy;

        HubConnection HubConnection
        {
            get
            {
                if (_hubConnection == null)
                    _hubConnection = new HubConnection( RestClient.BaseUrl );

                return _hubConnection;
            }
        }

        public IHubProxy Hub
        {
            get
            {
                if (_mojioProxy == null)
                {
                    _mojioProxy = HubConnection.CreateHubProxy("hub");

                    // Register callback events
                    _mojioProxy.On<Event>("event", m => { if (EventHandler != null) EventHandler(m); });
                    _mojioProxy.On<Trip>("trip", m => { if (TripHandler != null) TripHandler(m); });
                    _mojioProxy.On<String>("error", m => { if (ErrorHandler != null) ErrorHandler(m); });
                }

                return _mojioProxy;
            }
        }

        /// <summary>
        /// Subscribe to new signalR events for a particular entity.
        /// </summary>
        /// <typeparam name="T">Entity Type (Mojio,User,Trip)</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="events">Event types to receive</param>
        /// <returns></returns>
        public Task Subscribe<T>( string id, EventType[] events)
        {
            return Subscribe<T>(new string[] { id }, events);
        }

        /// <summary>
        /// Subscribe to new signalR events for a set of entities.
        /// </summary>
        /// <typeparam name="T">Entity Type (Mojio,User,Trip)</typeparam>
        /// <param name="id">Entity IDs</param>
        /// <param name="events">Event types to receive</param>
        /// <returns></returns>
        public Task Subscribe<T>(string[] id, EventType[] events)
        {
            if (HubConnection.State != ConnectionState.Connected && Hub != null)
                HubConnection.Start().Wait();

            return Hub.Invoke("Subscribe", Token.Id, typeof(T).Name, id, events);
        }

        /// <summary>
        /// Unsubscribe from signalR events for a particular entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="events"></param>
        /// <returns></returns>
        public bool Unsubscribe<T>(string id, EventType[] events)
        {
            return Unsubscribe<T>(new string[] { id }, events);
        }

        /// <summary>
        /// Unsubscribe from signalR events for a set of entities.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity IDs</param>
        /// <param name="events">Event Types</param>
        /// <returns></returns>
        public bool Unsubscribe<T>(string[] id, EventType[] events)
        {
            Hub.Invoke("Unsubscribe", /*Token.Id,*/ typeof(T).Name, id, events);
            return true;
        }

        /// <summary>
        /// Close signalR connection.
        /// </summary>
        public void Close()
        {
            HubConnection.Stop();
        }
    }
}
