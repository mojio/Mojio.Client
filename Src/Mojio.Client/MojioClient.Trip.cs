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
        /// <summary>
        /// Merges two trips into one.
        /// </summary>
        /// <param name="intoTrip">The into trip.</param>
        /// <param name="fromTrip">From trip.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Trip MergeTrips (Trip intoTrip, Trip fromTrip)
        {
#pragma warning disable 0618
            return MergeTrips(intoTrip.Id, fromTrip.Id);
#pragma warning restore 0618
        }

        /// <summary>
        /// Merges two trips into one.
        /// </summary>
        /// <param name="intoId">The into identifier.</param>
        /// <param name="fromId">From identifier.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Trip MergeTrips (Guid intoId, Guid fromId)
        {
            var response = AvoidAsyncDeadlock(() => MergeTripsAsync(intoId, fromId)).Result;
            return response.Data;
        }
        
        /// <summary>
        /// Merges two trips into one.
        /// </summary>
        /// <param name="intoId">The into identifier.</param>
        /// <param name="fromId">From identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse<Trip>> MergeTripsAsync(Guid intoId, Guid fromId)
        {
            string action = Map[typeof(Trip)];
            var request = GetRequest(Request(action, intoId, "trip"), Method.POST);
            request.AddBody(fromId);

            return RequestAsync<Trip>(request);
        }

        /// <summary>
        /// Get the events associated with a trip.
        /// </summary>
        /// <param name="id">Trip</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Event> TripEvents (Guid id, int page = 1)
        {
#pragma warning disable 0618
            return GetBy<Event, Trip> (id, page);
#pragma warning restore 0618
        }

        /// <summary>
        /// Get the events associated with a trip.
        /// </summary>
        /// <param name="id">Trip</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<Event>>> TripEventsAsync(Guid id, int page = 1)
        {
            return GetByAsync<Event, Trip>(id, page);
        }
    }
}
