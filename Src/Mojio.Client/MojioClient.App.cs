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
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public Guid SecretKey(App app)
        {
            // TODO: make this restricted and remove from public client
            return SecretKey(app.Id);
        }
        
        /// <summary>
        /// Get an applicaitons Privaet Key.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <returns></returns>
        public Guid SecretKey(Guid appId)
        {
            // TODO: make this restricted and remove from public client
            string action = Map[typeof(App)];
            var request = GetRequest(Request(action, appId, "secret"), Method.GET);

            var response = RestClient.Execute<Guid>(request);
            return response.Data;
        }

        /// <summary>
        /// Get collection of users who can view an application.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <returns></returns>
        public Results<User> AppViewers(Guid appId, int page = 1 )
        {
            return GetBy<User, App>(appId, page);
        }

        /// <summary>
        /// Get collection of administrators for an application.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <returns></returns>
        public Results<User> AppOwners(Guid appId, int page = 1)
        {
            return GetBy<User, App>(appId, page, "admins");
        }
    }
}
