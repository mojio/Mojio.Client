using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    partial class MojioClient
    {
        /// <summary>
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public bool GrantAccess(GuidEntity entity, Guid groupId, Permissions flags = Permissions.View)
        {
            var task = GrantAccessAsync(entity, groupId, flags);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public Task<MojioResponse> GrantAccessAsync(GuidEntity entity, Guid groupId, Permissions flags = Permissions.View)
        {
            string action = Map[entity.GetType()];
            var request = GetRequest(Request(action, entity.Id, "access"), Method.PUT);

            var access = new Access()
            {
                GroupId = groupId,
                Permissions = flags
            };

            request.AddBody(access);

            return RequestAsync(request);
        }
        /// <summary>
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public bool SetAccess(GuidEntity entity, Guid groupId, Permissions flags = Permissions.View)
        {
            var task = GrantAccessAsync(entity, groupId, flags);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public Task<MojioResponse> SetAccessAsync(GuidEntity entity, Guid groupId, Permissions flags = Permissions.View)
        {
            string action = Map[entity.GetType()];
            var request = GetRequest(Request(action, entity.Id, "access"), Method.POST);
            var access = new Access()
            {
                GroupId = groupId,
                Permissions = flags
            };

            request.AddBody(access);

            return RequestAsync(request);
        }

        /// <summary>
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public bool RevokeAccess(GuidEntity entity, Guid groupId)
        {
            var task = RevokeAccessAsync(entity, groupId);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Get an applications Private Key.
        /// </summary>
        /// <param name="app">Application Entity</param>
        /// <returns></returns>
        public Task<MojioResponse> RevokeAccessAsync(GuidEntity entity, Guid groupId)
        {
            string action = Map[entity.GetType()];
            var request = GetRequest(Request(action, entity.Id, "access"), Method.DELETE);
            request.AddParameter("groupId", groupId);

            return RequestAsync(request);
        }
    }
}
