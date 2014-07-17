using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        /// <summary>
        /// Get an application's Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public Guid SecretKey (App app, bool sandboxed = true)
        {
            return SecretKey (app.Id, sandboxed);
        }

        /// <summary>
        /// Get an application's Private Key.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <returns></returns>
        public Guid SecretKey (Guid appId, bool sandboxed = true)
        {
            string action = Map [typeof(App)];
            var request = GetRequest (Request (action, appId, "secret"), Method.GET);

            request.AddParameter("sandboxed", sandboxed);

            var response = RestClient.ExecuteAsync<Guid> (request).Result;
            return response.Data;
        }
    }
}
