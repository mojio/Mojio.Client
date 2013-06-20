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
        public Trip MergeTrips(Trip intoTrip, Trip fromTrip)
        {
            return MergeTrips(intoTrip.Id, fromTrip.Id);
        }

        public Trip MergeTrips( Guid intoId, Guid fromId )
        {
            string action = Map[typeof(Trip)];
            var request = GetRequest(Request(action,intoId,"merge"), Method.PUT);
            request.AddBody(fromId);

            var response = RestClient.Execute<Trip>(request);
            return response.Data;
        }

        /// <summary>
        /// Get the events associated with a trip.
        /// </summary>
        /// <param name="id">Trip</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<Event> TripEvents(Guid id, int page = 1 )
        {
            return GetBy<Event, User>(id, page);
        }
    }
}
