﻿using Mojio.Events;
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
        /// <summary>
        /// Get a collection of events associated with a mojio device.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <returns></returns>
        public Results<Event> MojioEvents(string id, int page = 1)
        {
            //return GetBy<Event, Device>(id, page);
            return EventsResult;
        }

        /// <summary>
        /// Get a collection of trips associated with a mojio device.
        /// </summary>
        /// <param name="id">Mojio ID</param>
        /// <returns></returns>
        public Results<Trip> MojioTrips(string id, int page = 1)
        {
            //return GetBy<Trip, Device>(id, page);
            
            return TripsResult;
        }

        public bool SetDeviceImage(string id, byte[] data, string mimetype, out HttpStatusCode code, out string message)
        {
            //if (string.IsNullOrEmpty(id))
            //    throw new ArgumentException("Device id is required");

            //string action = Map[typeof(Device)];
            //var request = GetRequest(Request(action, id, "image"), Method.POST);
            //request.AddBody(data);

            //var response = RestClient.Execute<bool>(request);
            //code = response.StatusCode;
            //message = response.Content;

            //return response.Data;
            code = HttpStatusCode.OK;
            message = "";
            return true;
            
        }

        public bool DeleteDeviceImage(string id, out HttpStatusCode code, out string message)
        {
            //if (string.IsNullOrEmpty(id))
            //    throw new ArgumentException("Device id is required");

            //string action = Map[typeof(Device)];
            //var request = GetRequest(Request(action, id, "image"), Method.DELETE);

            //var response = RestClient.Execute<bool>(request);
            //code = response.StatusCode;
            //message = response.Content;

            //return response.Data;
            code = HttpStatusCode.OK;
            message = "";
            return true;
        }

        public byte[] GetDeviceImage(string id, ImageSize size = ImageSize.Small)
        {
            if (string.IsNullOrEmpty(id))
                throw new ArgumentException("Device id is required");

            var assembly = GetType().Assembly;
            var stream = assembly.GetManifestResourceStream("Mojio.Client.MockMojioResources.MojioUserImg.Baby.jpg");
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, (int)stream.Length);

            return buffer;
        }
    }
}