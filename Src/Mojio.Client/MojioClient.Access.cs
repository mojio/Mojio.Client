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
        /// Get user or groups access permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The user or group identifier.</param>
        /// <returns></returns>
        public Permissions GetAccess(GuidEntity entity, Guid groupId)
        {
            var task = GetAccessAsync(entity, groupId);
            var response = task.Result;

            return response.Data;
        }

        /// <summary>
        /// Get user or groups access permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The user or group identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse<Permissions>> GetAccessAsync(GuidEntity entity, Guid groupId)
        {
            string action = Map[entity.GetType()];
            var request = GetRequest(Request(action, entity.Id, "access"), Method.GET);

            request.AddParameter("groupId", groupId);

            return RequestAsync<Permissions>(request);
        }

        /// <summary>
        /// Get current users permission of entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public Permissions MyAccess(GuidEntity entity)
        {
            var task = MyAccessAsync(entity);
            var response = task.Result;

            return response.Data;
        }

        /// <summary>
        /// Get current users permission of entity
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public Task<MojioResponse<Permissions>> MyAccessAsync(GuidEntity entity)
        {
            string action = Map[entity.GetType()];
            var request = GetRequest(Request(action, entity.Id, "access"), Method.GET);

            request.AddParameter("groupId", CurrentUser.Id);

            return RequestAsync<Permissions>(request);
        }


        /// <summary>
        /// Grant user or group access to entity with given permissions. (Appends permissions)
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <param name="flags">The permission flags.</param>
        /// <returns></returns>
        public bool GrantAccess(GuidEntity entity, Guid groupId, Permissions flags = Permissions.View)
        {
            var task = GrantAccessAsync(entity, groupId, flags);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Grant user or group access to entity with given permissions. (Appends permissions)
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <param name="flags">The permission flags.</param>
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
        /// Set user or group access to entity with given permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <param name="flags">The permission flags.</param>
        /// <returns></returns>
        public bool SetAccess(GuidEntity entity, Guid groupId, Permissions flags = Permissions.View)
        {
            var task = GrantAccessAsync(entity, groupId, flags);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Set user or group access to entity with given permissions.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <param name="flags">The permission flags.</param>
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
        /// Revoke user or group access to entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <returns></returns>
        public bool RevokeAccess(GuidEntity entity, Guid groupId)
        {
            var task = RevokeAccessAsync(entity, groupId);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Revoke user or group access to entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="groupId">The group or user identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse> RevokeAccessAsync(GuidEntity entity, Guid groupId)
        {
            string action = Map[entity.GetType()];
            var request = GetRequest(Request(action, entity.Id, "access"), Method.DELETE);
            request.AddParameter("groupId", groupId);

            return RequestAsync(request);
        }

        /// <summary>
        /// Add a user to an access group
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> AddUserAsync(Group group, Guid userId)
        {
            string action = Map[typeof(Group)];
            var request = GetRequest(Request(action, group.Id, "users"), Method.POST);

            request.AddBody(userId);

            return RequestAsync<bool>(request);
        }

        /// <summary>
        /// Add a user to an access group
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool AddUser(Group group, Guid userId)
        {
            var task = AddUserAsync(group, userId);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Remove a user from an access group
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> RemoveUserAsync(Group group, Guid userId)
        {
            string action = Map[typeof(Group)];
            var request = GetRequest(Request(action, group.Id, "users"), Method.DELETE);

            request.AddParameter("userId", userId);

            return RequestAsync<bool>(request);
        }

        /// <summary>
        /// Remove a user from an access group
        /// </summary>
        /// <param name="group">The group.</param>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public bool RemoveUser(Group group, Guid userId)
        {
            var task = RemoveUserAsync(group, userId);
            var response = task.Result;

            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Get users in group
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<AccessGroupUser>>> GetUsersAsync(Group group)
        {
            string action = Map[typeof(Group)];
            var request = GetRequest(Request(action, group.Id, "users"), Method.GET);

            return RequestAsync<Results<AccessGroupUser>>(request);
        }

        /// <summary>
        /// Get users in group
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns></returns>
        public Results<AccessGroupUser> GetUsers(Group group)
        {
            var task = GetUsersAsync(group);
            var response = task.Result;

            return response.Data;
        }
    }
}
