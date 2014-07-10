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
        /// Get a collection of events associated with a mojio device.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <returns></returns>
        public Results<Event> MojioEvents (Guid id, int page = 1)
        {
            return GetBy<Event, Mojio> (id, page);
        }

        /// <summary>
        /// Get a collection of trips associated with a mojio device.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <returns></returns>
        public Results<Trip> MojioTrips (Guid id, int page = 1)
        {
            return GetBy<Trip, Mojio> (id, page);
        }

        public bool SetVehicleImage (Guid id, byte[] data, string mimetype, out HttpStatusCode code, out string message)
        {
            var result = SetVehicleImageAsync (id, data, mimetype).Result;
            code = result.StatusCode;
            message = result.Content;
            return result.Data;
        }

        public Task<MojioResponse<bool>> SetVehicleImageAsync (Guid id, byte[] data, string mimetype)
        {
            if (id == Guid.Empty)
                throw new ArgumentException ("Vehicle Id is required");

            string action = Map [typeof(Vehicle)];
            var request = GetRequest (Request (action, id, "image"), Method.POST);
            request.AddBody (data);

            return RequestAsync<bool> (request);
        }

        public bool DeleteVehicleImage (Guid id, out HttpStatusCode code, out string message)
        {
            if (id == Guid.Empty)
                throw new ArgumentException ("Vehicle Id is required");

            string action = Map [typeof(Vehicle)];
            var request = GetRequest (Request (action, id, "image"), Method.DELETE);

            var response = RestClient.ExecuteAsync<bool> (request).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        public byte[] GetVehicleImage (Guid id, ImageSize size = ImageSize.Small)
        {
            var task = GetVehicleImageAsync (id, size);
            return task.Result; // Will block
        }

        public Task<byte[]> GetVehicleImageAsync (Guid id, ImageSize size = ImageSize.Small)
        {
            if (id == Guid.Empty)
                throw new ArgumentException ("Vehicle ID is required");

            string action = Map [typeof(Vehicle)];
            var request = GetRequest (Request (action, id, "image"), Method.GET);
            request.AddParameter ("size", size);

            var tcs = new TaskCompletionSource<byte[]> ();
            try {
                RestClient.ExecuteAsync (request).ContinueWith(t => {
                    var response = t.Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                        tcs.SetResult (response.RawBytes);
                    else
                        tcs.SetResult (null);
                });
            } catch (Exception ex) {
                tcs.SetException (ex);
            }
            return tcs.Task;
        }
    }
}