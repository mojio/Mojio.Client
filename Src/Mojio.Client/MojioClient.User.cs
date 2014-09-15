using Mojio;
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
        /// <summary>
        /// Login to mojio using a valid facebook access_token
        /// </summary>
        /// <param name="access_token">Facebook access_token</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Token FacebookLogin (string access_token)
        {
            string message;
            HttpStatusCode code;

            return FacebookLogin (access_token, out code, out message);
        }

        /// <summary>
        /// Login to mojio using a valid facebook access_token
        /// </summary>
        /// <param name="access_token">Facebook access_token</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Token FacebookLogin (string access_token, out HttpStatusCode code)
        {
            string message;

            return FacebookLogin (access_token, out code, out message);
        }

        /// <summary>
        /// Login to mojio using a valid facebook access_token
        /// </summary>
        /// <param name="access_token">Facebook access_token</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Token FacebookLogin (string access_token, out string message)
        {
            HttpStatusCode code;

            return FacebookLogin (access_token, out code, out message);
        }

        /// <summary>
        /// Login to mojio using a valid facebook access_token
        /// </summary>
        /// <param name="access_token">Facebook access_token</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Token FacebookLogin (string access_token, out HttpStatusCode code, out string message)
        {
            var task = AvoidAsyncDeadlock(() => FacebookLoginAsync(access_token));
            var response = task.Result;

            message = response.Content;
            code = response.StatusCode;

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return response.Data;
        }

        /// <summary>
        /// Login to mojio using a valid facebook access_token
        /// </summary>
        /// <returns>Request response</returns>
        /// <param name="access_token">Facebook access_token.</param>
        public Task<MojioResponse<Token>> FacebookLoginAsync (string access_token)
        {
            if (Token == null)
                throw new Exception ("Valid session must be initialized first."); // Can only "Login" if already authenticated app.
                
            var request = GetRequest (Request ("login", "facebook", "externaluser"), Method.POST);
            request.AddBody ("");
            //request.AddParameter("userOrEmail", userOrEmail);
            request.AddParameter ("accessToken", access_token);

            var task = RequestAsync<Token> (request);
            return task.ContinueWith<MojioResponse<Token>> (r => {
                var response = r.Result;
                if (response.StatusCode == HttpStatusCode.OK) {
                    Token = response.Data;
                    ResetCurrentUser ();
                }

                return response;
            });
        }

        /// <summary>
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public User RegisterUser (string username, string email, string password)
        {
            string message;
            HttpStatusCode code;

            return RegisterUser (username, email, password, out code, out message);
        }

        /// <summary>
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public User RegisterUser (string username, string email, string password, out HttpStatusCode code)
        {
            string message;
            return RegisterUser (username, email, password, out code, out message);
        }

        /// <summary>
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public User RegisterUser (string username, string email, string password, out string message)
        {
            HttpStatusCode code;
            return RegisterUser (username, email, password, out code, out message);
        }

        /// <summary>
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public User RegisterUser (string username, string email, string password, out HttpStatusCode code, out string message)
        {
            var task = AvoidAsyncDeadlock(() => RegisterUserAsync(username, email, password));

            var response = task.Result;

            message = response.Content;
            code = response.StatusCode;

            if (response.StatusCode != HttpStatusCode.Created)
                return null;

            return response.Data;
        }

        /// <summary>
        /// Async Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public Task<MojioResponse<User>> RegisterUserAsync (string username, string email, string password)
        {
            string action = Map [typeof(User)];
            var request = GetRequest (Request (action), Method.POST);
            request.AddBody (new
				{
					UserName = username,
					Email = email,
					Password = password
				});

            var task = RequestAsync<User> (request);
            return task;
        }

        User _currentUser;

        [Obsolete("Property has been deprecated because request is performed synchronously, please use GetCurrentUserAsync() instead.")]
        public User CurrentUser {
            get {
                if (_currentUser != null)
                    return _currentUser;
                if (Token.UserId != null)
#pragma warning disable 0618
                    _currentUser = Get<User> (Token.UserId.Value);
#pragma warning restore 0618
                return _currentUser;
            }
        }

        public async Task<User> GetCurrentUserAsync()
        {
            if (Token == null || !Token.UserId.HasValue)
                return null;

            if (_currentUser == null)
            {
                var response = await GetAsync<User>(Token.UserId.Value);
                _currentUser = response.Data;
            }

            return _currentUser;
        }

        /// <summary>
        /// Check if there is a logged in user.
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn ()
        {
            return Token != null && Token.UserId != null;
        }

        protected void ResetCurrentUser ()
        {
            _currentUser = null;
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool ChangePassword (string oldPassword, string newPassword, out HttpStatusCode code, out string message)
        {
            var response = AvoidAsyncDeadlock(() => ChangePasswordAsync(oldPassword, newPassword)).Result;

            code = response.StatusCode;
            message = response.Content;

            if (response.StatusCode != HttpStatusCode.OK)
                return false;
            return true;
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> ChangePasswordAsync(string oldPassword, string newPassword)
        {
            string action = Map [typeof(User)];
            var request = GetRequest (Request (action, Token.UserId, "Password"), Method.PUT);
            request.AddBody (new
                {
                    oldPassword = oldPassword,
                    newPassword = newPassword
                });

            return RequestAsync<bool> (request);
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool ChangePassword (string oldPassword, string newPassword)
        {
            HttpStatusCode code;
            string message;
#pragma warning disable 0618
            return ChangePassword(oldPassword, newPassword, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool ChangePassword (string oldPassword, string newPassword, out string message)
        {
            HttpStatusCode code;
#pragma warning disable 0618
            return ChangePassword(oldPassword, newPassword, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool ChangePassword (string oldPassword, string newPassword, out HttpStatusCode code)
        {
            string message;
#pragma warning disable 0618
            return ChangePassword(oldPassword, newPassword, out code, out message);
#pragma warning restore 0618
        }

        public Task<MojioResponse<bool>> RequestPasswordResetAsync (string userNameOrEmail, string returnUrl = null)
        {
            string action = Map [typeof(User)];
            var request = GetRequest (Request (action, userNameOrEmail, "PasswordEmail"), Method.POST);
            request.AddBody (returnUrl);

            return RequestAsync<bool> (request);
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool RequestPasswordReset (string userNameOrEmail, string returnUrl, out HttpStatusCode code, out string message)
        {
            var task = AvoidAsyncDeadlock(() => RequestPasswordResetAsync (userNameOrEmail, returnUrl));
            var response = task.Result;

            if (response != null) {
                code = response.StatusCode;
                message = response.Content;

                if (response.StatusCode != HttpStatusCode.OK) {
                    ThrowError (response.Content);
                }

                return response.Data;
            } else {
                code = HttpStatusCode.InternalServerError;
                message = "Internal server error.";
            }

            return false;
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool RequestPasswordReset (string userNameOrEmail, string returnUrl)
        {
            HttpStatusCode code;
            string message;
#pragma warning disable 0618
            return RequestPasswordReset(userNameOrEmail, returnUrl, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool RequestPasswordReset (string userNameOrEmail, string returnUrl, out string message)
        {
            HttpStatusCode code;
#pragma warning disable 0618
            return RequestPasswordReset(userNameOrEmail, returnUrl, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool RequestPasswordReset (string userNameOrEmail, string returnUrl, out HttpStatusCode code)
        {
            string message;
#pragma warning disable 0618
            return RequestPasswordReset(userNameOrEmail, returnUrl, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <returns></returns>
        public Task<MojioResponse<bool>> PasswordResetAsync(ResetPassword reset)
        {
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, reset.UserNameOrEmail, "Password"), Method.POST);
            request.AddBody(reset);

            return RequestAsync<bool>(request);
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool PasswordReset (ResetPassword reset, out HttpStatusCode code, out string message)
        {
            var response = AvoidAsyncDeadlock(() => PasswordResetAsync(reset)).Result;

            code = response.StatusCode;
            message = response.Content;

            if (response.StatusCode != HttpStatusCode.OK)
                return false;

            return true;
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool PasswordReset (ResetPassword reset)
        {
            HttpStatusCode code;
            string message;
#pragma warning disable 0618
            return PasswordReset(reset, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool PasswordReset (ResetPassword reset, out string message)
        {
            HttpStatusCode code;
#pragma warning disable 0618
            return PasswordReset(reset, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool PasswordReset (ResetPassword reset, out HttpStatusCode code)
        {
            string message;
#pragma warning disable 0618
            return PasswordReset(reset, out code, out message);
#pragma warning restore 0618
        }

        /// <summary>
        /// Get a collection of applictions owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<App> UserApps (Guid userId, int page = 1)
        {
            return GetBy<App, User> (userId, page);
        }

        /// <summary>
        /// Get a collection of applictions owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<App>>> UserAppsAsnc(Guid userId, int page = 1)
        {
            return GetByAsync<App, User>(userId, page);
        }

        /// <summary>
        /// Get a collection of mojio devices owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Mojio> UserMojios (Guid userId, int page = 1)
        {
            return GetBy<Mojio, User> (userId, page);
        }

        /// <summary>
        /// Get a collection of mojio devices owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<Mojio>>> UserMojiosAsync(Guid userId, int page = 1)
        {
            return GetByAsync<Mojio, User>(userId, page);
        }

        /// <summary>
        /// Get a collection of mojio devices owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Vehicle> UserVehicles (Guid userId, int page = 1)
        {
            return GetBy<Vehicle, User> (userId, page);
        }

        /// <summary>
        /// Get a collection of mojio devices owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<Vehicle>>> UserVehiclesAsync(Guid userId, int page = 1)
        {
            return GetByAsync<Vehicle, User>(userId, page);
        }

        /// <summary>
        /// Get a collection of trips owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Trip> UserTrips (Guid userId, int page = 1)
        {
            return GetBy<Trip, User> (userId, page);
        }

        /// <summary>
        /// Get a collection of trips owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<Trip>>> UserTripsAsync(Guid userId, int page = 1)
        {
            return GetByAsync<Trip, User>(userId, page);
        }

        /// <summary>
        /// Get a collection of events owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Results<Event> UserEvents (Guid userId, int page = 1)
        {
            return GetBy<Event, User> (userId, page);
        }

        /// <summary>
        /// Get a collection of events owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Task<MojioResponse<Results<Event>>> UserEventsAsync(Guid userId, int page = 1)
        {
            return GetByAsync<Event, User>(userId, page);
        }

        public Task<MojioResponse<Address>> GetShippingAsync(Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "shipping"), Method.GET);

            return RequestAsync<Address>(request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Address GetShipping (Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => GetShippingAsync(userId)).Result;
            return response.Data;
        }

        public Task<MojioResponse<bool>> SaveShippingAsync(Address shipping, Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "shipping"), Method.POST);
            request.AddBody(shipping);

            return RequestAsync<bool>(request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SaveShipping (Address shipping, Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => SaveShippingAsync(shipping, userId)).Result;
            return response.StatusCode == HttpStatusCode.OK;
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public CreditCard GetCreditCard (out string message, Guid? userId = null)
        {
            HttpStatusCode code;
            return GetCreditCard (out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public CreditCard GetCreditCard (out HttpStatusCode code, Guid? userId = null)
        {
            string message;
            return GetCreditCard (out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public CreditCard GetCreditCard (Guid? userId = null)
        {
            HttpStatusCode code;
            string message;
            return GetCreditCard (out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public CreditCard GetCreditCard (out HttpStatusCode code, out string message, Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => GetCreditCardAsync(userId)).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        public Task<MojioResponse<CreditCard>> GetCreditCardAsync (Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map [typeof(User)];
            var request = GetRequest (Request (action, userId, "creditcard"), Method.GET);

            return RequestAsync<CreditCard> (request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SaveCreditCard (CreditCard creditCard, out string message, Guid? userId = null)
        {
            HttpStatusCode code;
            return SaveCreditCard (creditCard, out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SaveCreditCard (CreditCard creditCard, out HttpStatusCode code, Guid? userId = null)
        {
            string message;
            return SaveCreditCard (creditCard, out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SaveCreditCard (CreditCard creditCard, Guid? userId = null)
        {
            HttpStatusCode code;
            string message;
            return SaveCreditCard (creditCard, out code, out message, userId);
        }

        public Task<MojioResponse<bool>> SaveCreditCardAsync(CreditCard creditCard, Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "creditcard"), Method.POST);
            request.AddBody(creditCard);

            return RequestAsync<bool>(request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SaveCreditCard (CreditCard creditCard, out HttpStatusCode code, out string message, Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => SaveCreditCardAsync(creditCard, userId)).Result;

            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool DeleteCreditCard (out string message, Guid? userId = null)
        {
            HttpStatusCode code;
            return DeleteCreditCard (out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool DeleteCreditCard (out HttpStatusCode code, Guid? userId = null)
        {
            string message;
            return DeleteCreditCard (out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool DeleteCreditCard (Guid? userId = null)
        {
            HttpStatusCode code;
            string message;
            return DeleteCreditCard (out code, out message, userId);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool DeleteCreditCard (out HttpStatusCode code, out string message, Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => DeleteCreditCardAsync(userId)).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        public Task<MojioResponse<bool>> DeleteCreditCardAsync (Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map [typeof(User)];
            var request = GetRequest (Request (action, userId, "creditcard"), Method.DELETE);

            return RequestAsync<bool> (request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool SetImage (byte[] data, string mimetype, out HttpStatusCode code, out string message, Guid? userId = null)
        {
            var result = AvoidAsyncDeadlock(() => SetImageAsync(data, mimetype, userId)).Result;
            code = result.StatusCode;
            message = result.Content;
            return result.Data;
        }

        public Task<MojioResponse<bool>> SetImageAsync (byte[] data, string mimetype, Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map [typeof(User)];
            var request = GetRequest (Request (action, userId, "image"), Method.POST);
            request.AddBody (data);

            return RequestAsync<bool> (request);
        }

        public Task<MojioResponse<bool>> DeleteImageAsync(Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "image"), Method.DELETE);

            return RequestAsync<bool>(request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public bool DeleteImage (out HttpStatusCode code, out string message, Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => DeleteImageAsync(userId)).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public byte[] GetImage (ImageSize size = ImageSize.Small, Guid? userId = null)
        {
            var task = AvoidAsyncDeadlock(() => GetImageAsync(size, userId));
            return task.Result;
        }

        public Task<byte[]> GetImageAsync (ImageSize size = ImageSize.Small, Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map [typeof(User)];
            var request = GetRequest (Request (action, userId, "image"), Method.GET);
            request.AddParameter ("size", size);

            var tcs = new TaskCompletionSource<byte[]> ();
            try {
                RestClient.ExecuteAsync (request).ContinueWith( t => {
                    var response = t.Result;

                    if (response.StatusCode == HttpStatusCode.OK)
                        tcs.SetResult (response.RawBytes);
                    else
                        tcs.SetResult (null);
                });
            } catch (Exception ex) {
                tcs.SetException (ex);
            }
            return tcs.Task;
        }

        public Task<MojioResponse<Roles?>> GetRoleAsync(Guid? userId = null)
        {
            if (userId == null)
                userId = Token.UserId;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "role"), Method.GET);

            return RequestAsync<Roles?>(request);
        }

        [Obsolete("All synchronous methods have been deprecated, please use the asynchronous method instead.")]
        public Roles? GetRole(Guid? userId = null)
        {
            var response = AvoidAsyncDeadlock(() => GetRoleAsync(userId)).Result;

            if (response.StatusCode == HttpStatusCode.OK)
                return response.Data;

            return null;
        }
    }
}
