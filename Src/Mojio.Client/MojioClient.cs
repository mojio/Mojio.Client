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
        public const string Sandbox = "http://sandbox.developer.moj.io/v1";
        public const string Live = "https://developer.moj.io/v1";

        public int PageSize { get; set; }
        public int SessionTime { get; set; }

        RestClient RestClient;
        public Token Token;

        static Dictionary<Type, string> Map = new Dictionary<Type, string>();
        static MojioClient()
        {
            Map.Add(typeof(App), "apps");
            Map.Add(typeof(User), "users");
            Map.Add(typeof(Device), "mojios");
            Map.Add(typeof(Event), "events");
                Map.Add(typeof(GPSEvent), "events");
                Map.Add(typeof(TripEndEvent), "events");
                Map.Add(typeof(IgnitionEvent), "events");
                Map.Add(typeof(TripEvent), "events");
                Map.Add(typeof(TripStatusEvent), "events");
                Map.Add(typeof(HardEvent), "events");

            Map.Add(typeof(Trip), "trips");
            Map.Add(typeof(Product), "products");

            Map.Add(typeof(Invoice), "orders");
        }

        /// <summary>
        /// Begin a new session using the App ID and secretKey.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="Url">API endpoint URL</param>
        public MojioClient(Guid appId, Guid secretKey, string Url = Live)
            : this(Url)
        {
            Begin(appId, secretKey);
        }

        /// <summary>
        /// Attempt to begin a connection using the tokenID.
        /// Begin a new session using the appId and secret key if token has expired.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="tokenId">Session Token</param>
        /// <param name="Url">API endpoint URL</param>
        public MojioClient(Guid appId, Guid secretKey, Guid? tokenId, string Url = "http://api.moj.io/v1")
            : this(Url)
        {
            Begin(appId, secretKey, tokenId);
        }

        /// <summary>
        /// Authenticate a new session token with a specific user attached.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="userOrEmail">User's name or email</param>
        /// <param name="passsword">User's password.</param>
        /// <param name="Url">API endpoint URL</param>
        public MojioClient(Guid appId, Guid secretKey, string userOrEmail, string password, string Url = "http://api.moj.io/v1")
            : this(Url)
        {
            Begin(appId, secretKey, userOrEmail, password);
        }

        /// <summary>
        /// Initiate a new MojioClient.  No session token has been created yet.
        /// Client must call Begin, or supply set a valid Token.
        /// </summary>
        /// <param name="Url">API endpoint URL</param>
        public MojioClient(string Url = "http://api.moj.io/v1")
        {
            PageSize = 10;
            SessionTime = 24 * 60;

            RestClient = new RestClient(Url);
            RestClient.AddHandler("application/json", new RSJsonSerializer());
        }

        /// <summary>
        /// Build request URL string from controller/id/action/key
        /// </summary>
        /// <param name="controller">Controller name.</param>
        /// <param name="id">Object ID</param>
        /// <param name="action">Action Name</param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string Request(string controller, object id = null, string action = null, string key = null)
        {
            if( key != null )
                // Key currently only used for storage
                return string.Format("{0}/{1}/{2}/{3}", controller, id, action, key);
            if (id != null && action != null)
                return string.Format("{0}/{1}/{2}", controller, id, action);
            else if (id != null)
                return string.Format("{0}/{1}", controller, id);
            else if (action != null)
                return string.Format("{0}/{1}", controller, action);       
            
            return controller;
        }

        /// <summary>
        /// Attempt to begin a connection using the tokenID.
        /// Begin a new session using the appId and secret key if token has expired.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="tokenId">Session Token</param>
        /// <returns></returns>
        public bool Begin(Guid appId, Guid secretKey, Guid? tokenId )
        {
            if (tokenId != null)
            {
                var request = new RestRequest(Request("login", tokenId.Value), Method.GET);
                var response = RestClient.Execute<Token>(request);
                if (response.StatusCode == HttpStatusCode.OK && response.Data.AppId == appId)
                {
                    Token = response.Data;
                    return true;
                }
            }
            return Begin(appId,secretKey);
        }

        /// <summary>
        /// Begin a new session using the appId and secret key.
        /// This session will not include an attached user.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <returns></returns>
        public bool Begin(Guid appId, Guid secretKey)
        {
            var request = new RestRequest(Request("login", appId, "begin"), Method.GET);
            request.AddParameter("secretKey", secretKey);
            var response = RestClient.Execute<Token>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Token = response.Data;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Begin a new API session using the AppID and Secret Key, aswell as attach a mojio user.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="userOrEmail">User's name or email</param>
        /// <param name="password">User's password</param>
        /// <returns></returns>
        public bool Begin(Guid appId, Guid secretKey, string userOrEmail, string password)
        {
            var request = new RestRequest(Request("login", appId, "begin"), Method.GET);
            request.AddParameter("secretKey", secretKey);
            request.AddParameter("userOrEmail", userOrEmail);
            request.AddParameter("password", password);
            var response = RestClient.Execute<Token>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Token = response.Data;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Authenticate a user and update the current session token.
        /// </summary>
        /// <param name="userOrEmail"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool SetUser(string userOrEmail, string password)
        {
            if (Token == null)
                return false; // Can only "Login" if already authenticated app.

            var request = GetRequest(Request("login", userOrEmail, "setuser"), Method.GET);

            //request.AddParameter("userOrEmail", userOrEmail);
            request.AddParameter("password", password);
            request.AddParameter("minutes", SessionTime);

            var response = RestClient.Execute<Token>(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Token = response.Data;
                ResetCurrentUser();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Unset authenticated user.
        /// </summary>
        /// <returns></returns>
        public bool ClearUser()
        {
            if (Token == null)
                return false; // Can only "Login" if already authenticated app.

            var request = GetRequest(Request("login", Token.Id, "logout"), Method.GET);

            var response = RestClient.Execute<Token>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Token = response.Data;
                ResetCurrentUser();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Extend token expiry date.
        /// </summary>
        /// <param name="minutes">Exipry time in minutes</param>
        /// <returns></returns>
        public bool ExtendSession(int minutes)
        {
            if (Token == null)
                return false; // Can only "Extend" if already authenticated app.

            var request = GetRequest(Request("login", Token.Id, "extend"), Method.GET);
            request.AddParameter("minutes",minutes);

            var response = RestClient.Execute<Token>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Token = response.Data;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Generate basic request.  Adds the session token to header if exists.
        /// </summary>
        /// <param name="resource">Resource URL</param>
        /// <param name="method">Request method</param>
        /// <returns></returns>
        public RestRequest GetRequest(string resource, Method method)
        {
            var request = new RestRequest(resource, method);
            request.RequestFormat = DataFormat.Json;
            request.JsonSerializer = new RSJsonSerializer();

            if (Token != null)
                request.AddHeader(Headers.MojioAPITokenHeader, Token.Id.ToString());
            return request;
        }

        /// <summary>
        /// Create a new entity through API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to create</param>
        /// <returns></returns>
        public T Create<T>(T entity)
            where T : new()
        {
            if (typeof(T) == typeof(User))
            {
                // Cannot create user with this generic method
                throw new ArgumentException("Cannot create user with generic method Create. Use RegisterUser instead.");
            }

            string action = Map[typeof(T)];
            var request = GetRequest(Request(action), Method.POST);

            request.AddBody(entity);

            var response = RestClient.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Delete an entity through the API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to delete</param>
        /// <returns></returns>
        public bool Delete<T>(T entity)
            where T : BaseEntity
        {
            return Delete<T>(entity.IdToString);
        }

        /// <summary>
        /// Delete an entity by Entity ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <returns></returns>
        public bool Delete<T>(object id)
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action, id), Method.DELETE);
            var response = RestClient.Execute(request);
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }

        /// <summary>
        /// Update/save an entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Updated Entity</param>
        /// <returns></returns>
        public T Update<T>(T entity )
            where T : BaseEntity, new()
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action,entity.IdToString), Method.PUT);
            request.AddBody(entity);

            var response = RestClient.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Get an entity by ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <returns></returns>
        public T Get<T>(object id)
            where T : new()
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action, id), Method.GET);
            var response = RestClient.Execute<T>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a collection of M entities associated to a particular entity.
        /// </summary>
        /// <typeparam name="M">Entity type to fetch</typeparam>
        /// <typeparam name="T">Entity type to search by</typeparam>
        /// <param name="entity">Entity to search by</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<M> GetBy<M, T>(T entity, int page = 1)
            where T : BaseEntity, new()
        {
            return GetBy<M, T>(entity.IdToString, page);
        }

        /// <summary>
        /// Get a collection of M entities associated to a particular entity.
        /// </summary>
        /// <typeparam name="M">Entity type to fetch</typeparam>
        /// <typeparam name="T">Entity type to search by</typeparam>
        /// <param name="id">Id of entity to search by</param>
        /// <param name="action">Specific action name to call</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<M> GetBy<M,T>(object id , int page = 1, string action = null)
            where T : new()
        {
            string controller = Map[typeof(T)];

            if( action == null )
                action = Map[typeof(M)];

            var request = GetRequest(Request(controller, id, action), Method.GET);

            request.AddParameter("page", page);
            request.AddParameter("pageSize", PageSize);

            var response = RestClient.Execute<Results<M>>(request);
            return response.Data;
        }

        /// <summary>
        /// Get a collection of entities available to the current session.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="page">Page</param>
        /// <returns></returns>
        public Results<T> Get<T>(int page = 1)
            where T : new()
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action), Method.GET);

            request.AddParameter("page", page);
            request.AddParameter("pageSize", PageSize);

            var response = RestClient.Execute<Results<T>>(request);
            return response.Data;
        }

        /// <summary>
        /// Add an administrator to entity.  Currently only apps can have administrators.
        /// </summary>
        /// <typeparam name="T">Entity type (Only App supported)</typeparam>
        /// <param name="entity">Entity to add an admin to</param>
        /// <param name="userId">Admin User ID</param>
        /// <returns></returns>
        public bool AddAdmin<T>(T entity, Guid userId)
            where T : BaseEntity
        {
            return AddAdmin<T>(entity.IdToString, userId);
        }

        /// <summary>
        /// Add an administrator to entity.  Currently only apps can have administrators.
        /// </summary>
        /// <typeparam name="T">Entity type (Only App supported)</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="userId">Admin User ID</param>
        /// <returns></returns>
        public bool AddAdmin<T>(object id, Guid userId)
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action,id,"admin"), Method.POST);
            request.AddBody(userId);

            var response = RestClient.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Remove an administrator from an entity.  Currently only Apps supports administrators.
        /// </summary>
        /// <typeparam name="T">Entity type (Only App supported)</typeparam>
        /// <param name="entity">Entity to remove admin from</param>
        /// <param name="userId">Administrator's User ID</param>
        /// <returns></returns>
        public bool RemoveAdmin<T>(T entity, Guid userId)
            where T : BaseEntity
        {
            return RemoveAdmin<T>(entity.IdToString, userId);
        }

        /// <summary>
        /// Remove an administrator from an entity.  Currently only Apps supports administrators.
        /// </summary>
        /// <typeparam name="T">Entity type (Only App supported)</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="userId">Administrator's User ID</param>
        /// <returns></returns>
        public bool RemoveAdmin<T>(object id, Guid userId)
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action, id, "admin"), Method.DELETE);
            request.AddParameter("userId",userId);

            var response = RestClient.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Add a viewer to an entity.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="userId">Viewer's User ID</param>
        /// <returns></returns>
        public bool AddViewer<T>(T entity, Guid userId)
            where T : BaseEntity
        {
            return AddViewer<T>(entity.IdToString, userId);
        }

        /// <summary>
        /// Add a viewer to an entity.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="userId">Viewer's User ID</param>
        /// <returns></returns>
        public bool AddViewer<T>(object id, Guid userId)
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action, id, "viewer"), Method.POST);
            request.AddBody(userId);

            var response = RestClient.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        /// <summary>
        /// Remove a viewer from an entity.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="entity">Entity</param>
        /// <param name="userId">Viewer's User ID</param>
        /// <returns></returns>
        public bool RemoveViewer<T>(T entity, Guid userId)
            where T : BaseEntity
        {
            return RemoveViewer<T>(entity.IdToString, userId);
        }

        /// <summary>
        /// Remove a viewer from an entity.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="userId">Viewer's User ID</param>
        /// <returns></returns>
        public bool RemoveViewer<T>(object id, Guid userId)
        {
            string action = Map[typeof(T)];
            var request = GetRequest(Request(action, id, "viewer"), Method.DELETE);
            request.AddParameter("userId", userId);

            var response = RestClient.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public void ThrowError(string errorMessage)
        {
            throw new Exception(errorMessage);
        }
    }
}
