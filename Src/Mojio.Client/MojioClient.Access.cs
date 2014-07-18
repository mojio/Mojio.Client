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
        /// Get access record for entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Access GetAccess(GuidEntity entity)
        {
            var task = AvoidAsyncDeadlock(() => GetAccessAsync(entity));
            var response = task.Result;

            return response.Data;
        }

        /// <summary>
        /// Get user access permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Permissions GetUserAccess(GuidEntity entity, Guid userId)
        {
#pragma warning disable 0618
            var access = GetAccess(entity);
#pragma warning restore 0618
            var query = from u in access.Users
                        where u.UserId.Equals(userId)
                        select u.Permissions;

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Get user or groups access permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public Task<MojioResponse<Access>> GetAccessAsync(GuidEntity entity)
        {
            string controller = Map[typeof(Access)];
            var request = GetRequest(Request(controller, entity.Type, entity.Id), Method.GET);

            return RequestAsync<Access>(request);
        }

        /// <summary>
        /// Get current users permission of entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Permissions MyAccess(GuidEntity entity)
        {
            var task = AvoidAsyncDeadlock(() => GetAccessAsync(entity));
            var response = task.Result;

            var access = response.Data;
            if (access.Users == null)
                return Permissions.None;

#pragma warning disable 0618
            var query = from u in access.Users
                        where u.UserId.Equals(CurrentUser.Id)
                        select u.Permissions;
#pragma warning restore 0618

            return query.FirstOrDefault();
        }

        /// <summary>
        /// Grant user access to entity with given permissions. (Appends permissions)
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="flags">The permission flags.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool GrantUserAccess(GuidEntity entity, Guid userId, Permissions flags = Permissions.View)
        {
            var task = AvoidAsyncDeadlock(() => GrantUserAccessAsync(entity, userId, flags));
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Grant user access to entity with given permissions. (Appends permissions)
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="flags">The permission flags.</param>
        /// <returns></returns>
        public Task<MojioResponse> GrantUserAccessAsync(GuidEntity entity, Guid userId, Permissions flags = Permissions.View)
        {
            string action = Map[typeof(Access)];
            var request = GetRequest(Request(action, entity.Type, entity.Id, "users"), Method.PUT);

            var access = new UserAccess()
            {
                UserId = userId,
                Permissions = flags
            };

            request.AddBody(access);

            return RequestAsync(request);
        }

        /// <summary>
        /// Set user access to entity with given permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="flags">The permission flags.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SetUserAccess(GuidEntity entity, Guid userId, Permissions flags = Permissions.View)
        {
            var task = AvoidAsyncDeadlock(() => SetUserAccessAsync(entity, userId, flags));
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Set user access to entity with given permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="flags">The permission flags.</param>
        /// <returns></returns>
        public Task<MojioResponse> SetUserAccessAsync(GuidEntity entity, Guid userId, Permissions flags = Permissions.View)
        {
            string action = Map[typeof(Access)];
            var request = GetRequest(Request(action, entity.Type, entity.Id, "users"), Method.POST);
            var access = new UserAccess()
            {
                UserId = userId,
                Permissions = flags
            };

            request.AddBody(access);

            return RequestAsync(request);
        }

        /// <summary>
        /// Revoke user access to entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool RevokeUserAccess(GuidEntity entity, Guid groupId)
        {
            var task = AvoidAsyncDeadlock(() => RevokeUserAccessAsync(entity, groupId));
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Revoke user access to entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse> RevokeUserAccessAsync(GuidEntity entity, Guid groupId)
        {
            string action = Map[typeof(Access)];
            var request = GetRequest(Request(action, entity.Type, entity.Id, "users"), Method.DELETE);
            request.AddParameter("userId", groupId);

            return RequestAsync(request);
        }
    }
}
