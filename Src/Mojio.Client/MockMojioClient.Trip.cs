using Mojio.Events;
//using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MockMojioClient
    {
        #region Public Part
        public Trip MergeTrips(Trip intoTrip, Trip fromTrip)
        {
            return MergeTrips(intoTrip.Id, fromTrip.Id);
        }

        public Trip MergeTrips(Guid intoId, Guid fromId)
        {
            return Merge(intoId, fromId);
        }
        public Results<Event> TripEvents(Guid id, int page = 1)
        {
            return GetBy<Event, Trip>(id, page);

            //var trip = from e in Trip
            //           where e.Id.Equals(tripId1)
            //           select new Trip { Id = e.Id };

            //var collection = TripEvent.AsQueryable();

            //var query = from e in collection
            //            where e.TripId.Equals(trip)
            //            select e;

            //return Pagenate<Event>(query.AsQueryable(), PageSize, Math.Max(0, (page - 1)) * PageSize);
            // return GetBy<Event, Trip>(id, page);
        }
        #endregion

        #region Private Part
        private Trip Merge(Guid id, Guid trip)
        {
            return MergeMany(id, new Guid[] { trip });
        }
        private Trip MergeMany(Guid id, Guid[] trips)
        {
            var dbTrip = (from e in Trip
                         where e.Id.Equals(id)
                         select e).ToList().FirstOrDefault();


           

            foreach (Guid mergeId in trips)
            {
                var trip = (from e in Trip
                           where e.Id.Equals(mergeId)
                            select e).ToList().FirstOrDefault();

                IntMerge(dbTrip, trip);
            }

            return dbTrip;
        }
        private bool IntMerge(Trip intoTrip, Trip fromTrip)
        {
            // Already merged.
            if (intoTrip.Id == fromTrip.Id)
                return false;

            // Must be the same mojio device!
            if (fromTrip.MojioId != intoTrip.MojioId)
                return false;

            if (fromTrip.MaxSpeed > intoTrip.MaxSpeed)
                intoTrip.MaxSpeed = fromTrip.MaxSpeed;

            if (fromTrip.StartTime < intoTrip.StartTime)
            {
                intoTrip.StartTime = fromTrip.StartTime;
                intoTrip.StartLocation = fromTrip.StartLocation;
            }

            if (fromTrip.EndTime > intoTrip.EndTime)
            {
                intoTrip.EndTime = fromTrip.EndTime;
                intoTrip.EndLocation = fromTrip.EndLocation;
            }

            // TODO: Calculate Average Speed and Idle Percent.
            intoTrip.Distance += fromTrip.Distance;

            return true;
        }

        /// <summary>
        /// Get the events associated with a trip.
        /// </summary>
        /// <param name="id">Trip</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        #endregion


    }
} 