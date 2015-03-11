using Mojio.Events;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        /// <summary>
        /// Gets the Mojio's current sim card.
        /// </summary>
        /// <param name="id">Mojio ID.</param>
        /// <returns></returns>
        public Task<MojioResponse<SimCard>> GetMojioSimCardAsync(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("Mojio Id is required");

            string controller = Map[typeof(Mojio)];
            string action = Map[typeof(SimCard)];
            var request = GetRequest(Request(controller, id, action), HttpMethod.Get);

            return RequestAsync<SimCard>(request);
        }

        /// <summary>
        /// Get a collection of events associated with a Mojio.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Event> MojioEvents (Guid id, int page = 1)
        {
            return GetBy<Event, Mojio> (id, page);
        }

        /// <summary>
        /// Get a collection of trips associated with a Mojio.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Trip> MojioTrips (Guid id, int page = 1)
        {
            return GetBy<Trip, Mojio> (id, page);
        }

        /// <summary>
        /// Sets the vehicle image.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="data">The image data.</param>
        /// <param name="mimetype">The mimetype.</param>
        /// <param name="code">The response code.</param>
        /// <param name="message">The response message.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SetVehicleImage (Guid id, byte[] data, string mimetype, out HttpStatusCode code, out string message)
        {
            var result = AvoidAsyncDeadlock(() => SetVehicleImageAsync(id, data, mimetype)).Result;
            code = result.StatusCode;
            message = result.Content;
            return result.Data;
        }

        /// <summary>
        /// Sets the vehicle image asynchronous.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="data">The image data.</param>
        /// <param name="mimetype">The mimetype.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> SetVehicleImageAsync (Guid id, byte[] data, string mimetype)
        {
            if (id == Guid.Empty)
                throw new ArgumentException ("Vehicle Id is required");

            string action = Map [typeof(Vehicle)];
            var request = GetRequest(Request(action, id, "image"), HttpMethod.Post);
            request.AddBody (data);

            return RequestAsync<bool> (request);
        }

        /// <summary>
        /// Deletes the vehicle image.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="code">The response code.</param>
        /// <param name="message">The response message.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool DeleteVehicleImage (Guid id, out HttpStatusCode code, out string message)
        {
            var response = AvoidAsyncDeadlock(() => DeleteVehicleImageAsync(id)).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        /// <summary>
        /// Deletes the vehicle image asynchronously.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">Vehicle Id is required</exception>
        public Task<MojioResponse<bool>> DeleteVehicleImageAsync(Guid id) {
            if (id == Guid.Empty)
                throw new ArgumentException ("Vehicle Id is required");

            string action = Map [typeof(Vehicle)];
            var request = GetRequest(Request(action, id, "image"), HttpMethod.Delete);

            return RequestAsync<bool> (request);
        }

        /// <summary>
        /// Gets the vehicle image.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="size">The image size.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public byte[] GetVehicleImage (Guid id, ImageSize size = ImageSize.Small)
        {
            var task = AvoidAsyncDeadlock(() => GetVehicleImageAsync(id, size));
            return task.Result; // Will block
        }

        /// <summary>
        /// Gets the vehicle image asynchronously.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="size">The image size.</param>
        /// <returns></returns>
        public Task<byte[]> GetVehicleImageAsync (Guid id, ImageSize size = ImageSize.Small)
        {
            if (id == Guid.Empty)
                throw new ArgumentException ("Vehicle ID is required");

            string action = Map [typeof(Vehicle)];
            var request = GetRequest(Request(action, id, "image"), HttpMethod.Get);
            request.AddParameter ("size", size);

            return RestClient.Execute(request).ContinueWith(t =>
            {
                var response = t.Result;

                if (response.StatusCode == HttpStatusCode.OK)
                    return response.RawBytes;
                else
                    return null;
            });
        }

        /// <summary>
        /// Gets the vehicle details asynchronously.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <param name="size">The image size.</param>
        /// <returns></returns>
        public async Task<MojioResponse<VehicleDetails>> GetVehicleDetailsAsync(Guid id)
        {

            if (id == Guid.Empty)
                throw new ArgumentException("Vehicle ID is required");

            string controller = Map[typeof(Vehicle)];
            string action ="details";
            var request = GetRequest(Request(controller, id, action), HttpMethod.Get);

            var response = await RequestAsync<VehicleDetails>(request);

            return response;

        }
    }
}

