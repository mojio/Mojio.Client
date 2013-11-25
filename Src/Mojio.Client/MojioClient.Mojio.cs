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

        //public Results<MMY> GetAllMakes(string id)
        public Make GetAllMakes()
        {
              string action = Map[typeof(User)];
            var request = GetRequest(Request(action, null, "mmy"), Method.GET);

            //var response = RestClient.Execute<Results<MMY>>(request);
            var response = RestClient.Execute<Make>(request);
            return response.Data;
        }
        //public  Results<MMY> GetModels(string id,string make)
        public Model GetModels(string make)
        {
             string action = Map[typeof(User)];
            var request = GetRequest(Request(action, null, "mmy"), Method.GET);
            request.AddParameter("make", make);

            //var response = RestClient.Execute<Results<MMY>>(request);
            var response = RestClient.Execute<Model>(request);
            return response.Data;
        }
        //public Results<MMY> GetYears(string id, string make, string model)
        public Model GetYears(string model)
        {
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, null, "mmy"), Method.GET);
             request.AddParameter("model", model);

            //var response = RestClient.Execute<Results<MMY>>(request);
            var response = RestClient.Execute<Model>(request);
            return response.Data;
        }
        public bool AddMMY(Make[] listMMY)
        {           
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, null, "mmy"), Method.POST);
            request.AddBody(listMMY);

            var response = RestClient.Execute<bool>(request);
            
            return response.Data;
        }

    }
}