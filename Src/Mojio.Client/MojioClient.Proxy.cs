using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    partial class MojioClient
    {
        /// <summary>
        /// Gets the proxy servers for this Mojio device.
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public IList<ServerAddress> GetProxyServers(Guid mojioId)
        {
            var response = AvoidAsyncDeadlock(() => GetProxyServersAsync(mojioId)).Result;
            return response.Data;
        }

        /// <summary>
        /// Gets the proxy servers for this Mojio device (asynchronous).
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse<List<ServerAddress>>> GetProxyServersAsync(Guid mojioId)
        {
            var controller = Map[typeof(Mojio)];
            var request = GetRequest(Request(controller, mojioId, "proxy"), Method.GET);

            return RequestAsync<List<ServerAddress>>(request);
        }

        /// <summary>
        /// Adds a proxy server to this Mojio device.
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool AddProxyServer(Guid mojioId, ServerAddress address)
        {
            var response = AvoidAsyncDeadlock(() => AddProxyServerAsync(mojioId, address)).Result;
            return response.Data;
        }

        /// <summary>
        /// Adds a proxy server to this Mojio device.
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <param name="address">The address.</param>
        /// <param name="port">The port.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool AddProxyServer(Guid mojioId, string address, int port)
        {
            var response = AvoidAsyncDeadlock(() => AddProxyServerAsync(mojioId, address, port)).Result;
            return response.Data;
        }

        /// <summary>
        /// Adds a proxy server to this Mojio device.
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <param name="address">The address.</param>
        /// <param name="port">The port.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> AddProxyServerAsync(Guid mojioId, string address, int port)
        {
            return AddProxyServerAsync(mojioId, new ServerAddress(address, port));
        }

        /// <summary>
        /// Adds a proxy server to this Mojio device (asynchronous).
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <param name="address">The address.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> AddProxyServerAsync(Guid mojioId, ServerAddress address)
        {
            var controller = Map[typeof(Mojio)];
            var request = GetRequest(Request(controller, mojioId, "proxy"), Method.PUT);
            request.AddBody(address);

            return RequestAsync<bool>(request);
        }

        /// <summary>
        /// Sets the proxy servers of this Mojio device.
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <param name="servers">The servers.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SetProxyServer(Guid mojioId, IList<ServerAddress> servers)
        {
            var response = AvoidAsyncDeadlock(() => SetProxyServerAsync(mojioId, servers)).Result;
            return response.Data;
        }

        /// <summary>
        /// Sets the proxy servers of this Mojio device (asynchronous).
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <param name="servers">The servers.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> SetProxyServerAsync(Guid mojioId, IList<ServerAddress> servers)
        {
            var controller = Map[typeof(Mojio)];
            var request = GetRequest(Request(controller, mojioId, "proxy"), Method.POST);
            request.AddBody(servers);

            return RequestAsync<bool>(request);
        }

        /// <summary>
        /// Clears the proxy servers of this Mojio device
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool ClearProxyServers(Guid mojioId)
        {
            var response = AvoidAsyncDeadlock(() => ClearProxyServersAsync(mojioId)).Result;
            return response.Data;
        }

        /// <summary>
        /// Clears the proxy servers of this Mojio device (asynchronous).
        /// </summary>
        /// <param name="mojioId">The mojio identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> ClearProxyServersAsync(Guid mojioId)
        {
            var controller = Map[typeof(Mojio)];
            var request = GetRequest(Request(controller, mojioId, "proxy"), Method.DELETE);

            return RequestAsync<bool>(request);
        }
    }
}
