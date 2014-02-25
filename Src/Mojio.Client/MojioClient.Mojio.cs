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
        public Results<Event> MojioEvents(string id,int page = 1)
        {
            return GetBy<Event, Device>(id, page);
        }

        /// <summary>
        /// Get a collection of trips associated with a mojio device.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <returns></returns>
        public Results<Trip> MojioTrips(string id, int page = 1)
        {
            return GetBy<Trip, Device>(id, page);
        }

        public bool SetDeviceImage(string id, byte[] data, string mimetype, out HttpStatusCode code, out string message)
        {
            var result = SetDeviceImageAsync(id, data, mimetype).Result;
            code = result.StatusCode;
            message = result.Content;
            return result.Data;
        }

        public Task<MojioResponse<bool>> SetDeviceImageAsync(string id, byte[] data, string mimetype)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Device id is required");

            string action = Map[typeof(Device)];
            var request = GetRequest(Request(action, id, "image"), Method.POST);
            request.AddBody(data);

            return RequestAsync<bool>(request);
        }

        public bool DeleteDeviceImage(string id, out HttpStatusCode code, out string message)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Device id is required");

            string action = Map[typeof(Device)];
            var request = GetRequest(Request(action, id, "image"), Method.DELETE);

            var response = RestClient.Execute<bool>(request);
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        public byte[] GetDeviceImage(string id, ImageSize size = ImageSize.Small)
        {
            var task = GetDeviceImageAsync(id, size);
            return task.Result; // Will block
        }

        public Task<byte[]> GetDeviceImageAsync(string id, ImageSize size = ImageSize.Small)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Device id is required");

            string action = Map[typeof(Device)];
            var request = GetRequest(Request(action, id, "image"), Method.GET);
            request.AddParameter("size", size);

            var tcs = new TaskCompletionSource<byte[]>();
            try
            {
                RestClient.ExecuteAsync(request, response =>
                    {
                        if (response.StatusCode == HttpStatusCode.OK)
                            tcs.SetResult(response.RawBytes);
                        else
                            tcs.SetResult(null);
                    });
            }
            catch(Exception ex)
            {
                tcs.SetException(ex);
            }
            return tcs.Task;
        }
    }
}