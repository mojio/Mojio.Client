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
        /// <summary>
        /// Save storage value.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetStored(BaseEntity entity, string key, object value)
        {
            Storage = new Storage
            {
                EntityId=entity.IdToString,
                Key=key,
                Value=value               
            };
            return SetStored(entity.GetType(), entity.IdToString, key, value);
        }

        /// <summary>
        /// Save storage value.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool SetStored(Type type, string id, string key, object value)
        {            
            return true;
        }

        public string GetStored(BaseEntity entity, string key)
        {
            return GetStored(entity.GetType(), entity.IdToString, key);
        }

        public T GetStored<T>(BaseEntity entity, string key)
             where T : new()
        {
            return GetStored<T>(entity.GetType(), entity.IdToString, key);
        }

        public string GetStored(Type type, string id, string key)
        {
            if (Storage == null)
                return null;
            else
            return Storage.Value.ToString();
        }

        public T GetStored<T>(Type type, string id, string key)
            where T : new()
        {
            //string action = Map[type];
            //var request = GetRequest(Request(action, id, "store", key), Method.GET);

            //var response = RestClient.Execute<T>(request);
            //return response.Data;
            return default(T);
        }

        public bool DeleteStored(BaseEntity entity, string key)
        {
            return DeleteStored(entity.GetType(), entity.IdToString, key);
        }

        public bool DeleteStored(Type type, string id, string key)
        {
            //string action = Map[type];
            //var request = GetRequest(Request(action, id, "store", key), Method.DELETE);

            //var response = RestClient.Execute(request);
            //return response.StatusCode == HttpStatusCode.OK;
            return true;
        }
    }
}