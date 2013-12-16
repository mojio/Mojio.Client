using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Security;
using Newtonsoft.Json;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace Mojio.Client.MockClientController
{
    class MockLoginController
    {
        public Token SecurityContext { get; set; }
        
        /// <summary>
        /// Initialize an application session using an Application ID and Secret Key.
        /// </summary>
        /// <param name="id">Application ID</param>
        /// <param name="secretKey">Application secret key</param>
        /// <param name="minutes">Session lifetime, in minutes</param>
        /// <returns>Session token</returns>
        
        
        public Token Begin(Guid id, Guid secretKey, int minutes = 20)
        {
            // Method 2: Token in header
            var result = MockSecurity.AuthorizeToken(id, secretKey, minutes);
            if (result == null)
                ThrowError(HttpStatusCode.Unauthorized, "Invalid credentials");
            return result;
        }

        /// <summary>
        /// Initialize an application session with an attached user.
        /// </summary>
        /// <param name="id">Application ID</param>
        /// <param name="secretKey">Application secret key</param>
        /// <param name="userOrEmail">Users username or email</param>
        /// <param name="password">Users password</param>
        /// <param name="minutes">Session lifetime, in minutes</param>
        /// <returns>Session token</returns>
      
        public Token Begin(Guid id, Guid secretKey, string userOrEmail, string password, int minutes = 20)
        {
            // Method 2: Token in header
            var result = MockSecurity.AuthorizeToken(id, secretKey, userOrEmail, password, minutes);
            if (result == null)
                ThrowError(HttpStatusCode.Unauthorized, "Invalid credentials");
            FormsAuthentication.SetAuthCookie(userOrEmail, false);
            return result;
        }

        /// <summary>
        /// Set or switch attached user.
        /// </summary>
        /// <param name="id">Username or email</param>
        /// <param name="password">Password</param>
        /// <returns>Updated session token</returns>
        
        public Token SetUser(string id, string password)
        {
            var result = MockSecurity.AuthorizeUser(SecurityContext, id, password);
            if (!result)
                ThrowError(HttpStatusCode.Unauthorized, "Invalid credentials");
            FormsAuthentication.SetAuthCookie(id, false);

            return SecurityContext;
        }


        public Token SetExternalUser(string accessToken = null, string expiresIn = null, string signedRequest = null, string userID = null)        
        {
            //Facebook.FacebookClient facebookClient = new Facebook.FacebookClient(accessToken);
            //facebookClient.AppId = System.Configuration.ConfigurationManager.AppSettings["FacebookAppId"];
            //facebookClient.AppSecret = System.Configuration.ConfigurationManager.AppSettings["FacebookAppSecret"];
            //try
            //{
            //    var me = facebookClient.Get("me").ToString();
            //    FacebookProperties obj = JsonConvert.DeserializeObject<FacebookProperties>(me);
            //    if (string.IsNullOrWhiteSpace(obj.Id) || string.IsNullOrWhiteSpace(obj.Email))
            //        ThrowError(HttpStatusCode.BadRequest, "Invalid facebook login");
            //    var result = Security.AuthorizeExternalUser(SecurityContext, "facebook", obj.Id, obj.Email);
            //    if (!result)
            //        ThrowError(HttpStatusCode.NotFound, "Facebook user not found or account could not be created");
            //    FormsAuthentication.SetAuthCookie(obj.Email, false);

            //    return SecurityContext;
            //}
            //catch (Facebook.FacebookOAuthException e)
            //{
            //    ThrowError(HttpStatusCode.Unauthorized, string.Format("External system error ({0})", e.Message));
            //    return SecurityContext;
            //}
            return null;
        }

        /// <summary>
        /// Logout a user from app, but keep the application token active.
        /// </summary>
        /// <param name="id">Token ID</param>
        /// <returns>Updated session token</returns>
        
        public Token Logout(Guid id)
        {
            SecurityContext.UserId = null;
            //TokenDatabase.Save(SecurityContext);

            return SecurityContext;
        }

        /// <summary>
        /// Get the details for a specific token.
        /// </summary>
        /// <param name="Id">Token ID</param>
        /// <returns>Session token</returns>
        public Token Get(Guid id)
        {
            // TODO: should we authenticate?
            MockSecurity.LoadMockMojioData();
            var token = MockSecurity.Token;

            if (token == null || token.Id == Guid.Empty || token.ValidUntil < DateTime.UtcNow)
                ThrowError(HttpStatusCode.NotFound, "Not a valid token");

            return token;
        }

        /// <summary>
        /// Extend a session tokens valid time.
        /// </summary>
        /// <param name="id">Token ID</param>
        /// <param name="minutes">Minutes to extend</param>
        /// <returns>Session token</returns>
       
        public Token Extend(Guid id, int minutes = 20)
        {
            // TODO: should we authenticate?
            //if (id != SecurityContext.Id)
            //    ThrowError(HttpStatusCode.Forbidden, "You cannot extend this token");

            //// update last access time
            //if (SecurityContext != null && SecurityContext.UserId.HasValue)
            //{
            //    User user = UsersController.IntGet(SecurityContext.UserId.Value);
            //    user.LastActivityDate = DateTime.UtcNow;
            //    UsersController.Database.Save(user);
            //}

            //return Security.ExtendToken(SecurityContext, minutes);
            return null;
        }

        /// <summary>
        /// Terminate a session token.  This token will no longer be usable.
        /// </summary>
        /// <param name="Id">Token ID</param>
       
        public void End(Guid Id)
        {
            if (HttpContext.Current != null &&
                HttpContext.Current.Session != null)            
                HttpContext.Current.Session.Abandon();

            //TokenDatabase.Delete(SecurityContext);

            // TODO: Clear session cookie?
            //Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
        }
        protected static void ThrowError(HttpStatusCode statusCode, string message = null)
        {
            HttpResponseMessage response = new HttpResponseMessage(statusCode);
            if (message != null)
                response.Content = new StringContent(message);
            throw new HttpResponseException(response);
        }

    }

    internal class FacebookProperties
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("first_name")]
        public string NameFirst { get; set; }

        [JsonProperty("last_name")]
        public string NameLast { get; set; }

        [JsonProperty("link")]
        public string ProfileUrl { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
 }



