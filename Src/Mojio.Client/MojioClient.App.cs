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
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Guid SecretKey(App app, bool sandboxed = true)
        {
            return SecretKey(app.Id, sandboxed);
        }

        /// <summary>
        /// Get an application's Private Key.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="sandboxed">if set to <c>true</c> [sandboxed].</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Guid SecretKey (Guid appId, bool sandboxed = true)
        {
            var response = AvoidAsyncDeadlock(() => SecretKeyAsync(appId, sandboxed)).Result;
            return response.Data;
        }

        /// <summary>
        /// Get an application's Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <param name="sandboxed">if set to <c>true</c> [sandboxed].</param>
        /// <returns></returns>
        public Task<MojioResponse<Guid>> SecretKeyAsync(App app, bool sandboxed = true)
        {
            return SecretKeyAsync(app.Id, sandboxed);
        }

        /// <summary>
        /// Get an application's Private Key.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="sandboxed">if set to <c>true</c> [sandboxed].</param>
        /// <returns></returns>
        public Task<MojioResponse<Guid>> SecretKeyAsync(Guid appId, bool sandboxed = true)
        {
            string action = Map[typeof(App)];
            var request = GetRequest(Request(action, appId, "secret"), Method.GET);

            request.AddParameter("sandboxed", sandboxed);

            return RequestAsync<Guid>(request);
        }
    }
}
