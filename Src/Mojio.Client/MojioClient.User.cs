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
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <returns></returns>
        public User RegisterUser( string username, string email, string password )
        {
            string message;
            HttpStatusCode code;

            return RegisterUser(username, email, password, out code , out message );
        }

        /// <summary>
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        public User RegisterUser(string username, string email, string password, out HttpStatusCode code )
        {
            string message;
            return RegisterUser(username, email, password, out code, out message);
        }

        /// <summary>
        /// Register a new user with Mojio.
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="email">Email address</param>
        /// <param name="password">Password</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        public User RegisterUser(string username, string email, string password, out string message)
        {
            HttpStatusCode code;
            return RegisterUser(username, email, password, out code, out message);
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
        public User RegisterUser(string username, string email, string password, out HttpStatusCode code, out string message)
        {
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action), Method.POST);
            request.AddBody(new
            {
                UserName = username,
                Email = email,
                Password = password
            });

            var response = RestClient.Execute<User>(request);
            message = response.Content;
            code = response.StatusCode;

            if (response.StatusCode != HttpStatusCode.Created)
                return null;

            return response.Data;
        }

        User _currentUser;
        public User CurrentUser
        {
            get 
            {
                if (_currentUser != null)
                    return _currentUser;
                if (Token.UserId != null)
                _currentUser=  Get<User>(Token.UserId.Value);
                return _currentUser;
            }
        }

        /// <summary>
        /// Check if there is a logged in user.
        /// </summary>
        /// <returns></returns>
        public bool IsLoggedIn()
        {
            return Token.UserId != null;
        }

        void ResetCurrentUser()
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
        public bool ChangePassword(string oldPassword, string newPassword, out HttpStatusCode code, out string message)
        {
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, Token.UserId, "ChangePassword"), Method.PUT);
            request.AddBody(new
                {
                    oldPassword = oldPassword,
                    newPassword = newPassword
                });

            var response = RestClient.Execute(request);
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
        public bool ChangePassword(string oldPassword, string newPassword)
        {
            HttpStatusCode code;
            string message;
            return ChangePassword(oldPassword, newPassword, out code, out message);
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword, out string message)
        {
            HttpStatusCode code;
            return ChangePassword(oldPassword, newPassword, out code, out message);
        }

        /// <summary>
        /// Change current user's password.
        /// </summary>
        /// <param name="oldPassword">Old password</param>
        /// <param name="newPassword">New password</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        public bool ChangePassword(string oldPassword, string newPassword, out HttpStatusCode code)
        {
            string message;
            return ChangePassword(oldPassword, newPassword, out code, out message);
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        public bool RequestPasswordReset(string userNameOrEmail, string returnUrl, out HttpStatusCode code, out string message)
        {
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userNameOrEmail, "ResetPassword"), Method.POST);
            request.AddBody(returnUrl);

            var response = RestClient.Execute(request);
            code = response.StatusCode;
            message = response.Content;

            if (response.StatusCode != HttpStatusCode.OK)
            {
                ThrowError(response.Content);
            }

            return true;
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <returns></returns>
        public bool RequestPasswordReset(string userNameOrEmail, string returnUrl)
        {
            HttpStatusCode code;
            string message;
            return RequestPasswordReset(userNameOrEmail, returnUrl, out code, out message);
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        public bool RequestPasswordReset(string userNameOrEmail, string returnUrl, out string message)
        {
            HttpStatusCode code;
            return RequestPasswordReset(userNameOrEmail, returnUrl, out code, out message);
        }

        /// <summary>
        /// Send a password reset request to user's email.
        /// </summary>
        /// <param name="oldPassword">User's name or email</param>
        /// <param name="newPassword">Return URL</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        public bool RequestPasswordReset(string userNameOrEmail, string returnUrl, out HttpStatusCode code)
        {
            string message;
            return RequestPasswordReset(userNameOrEmail, returnUrl, out code, out message);
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <param name="message">Http response content</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        public bool PasswordReset(ResetPassword reset, out HttpStatusCode code, out string message)
        {
            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, reset.UserNameOrEmail, "ResetPassword"), Method.PUT);
            request.AddBody(reset);

            var response = RestClient.Execute(request);
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
        public bool PasswordReset(ResetPassword reset)
        {
            HttpStatusCode code;
            string message;
            return PasswordReset(reset, out code, out message);
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <param name="message">Http response content</param>
        /// <returns></returns>
        public bool PasswordReset(ResetPassword reset, out string message)
        {
            HttpStatusCode code;
            return PasswordReset(reset, out code, out message);
        }

        /// <summary>
        /// Reset a users password using a reset token.
        /// </summary>
        /// <param name="reset">Reset request</param>
        /// <param name="code">Http response status code</param>
        /// <returns></returns>
        public bool PasswordReset(ResetPassword reset, out HttpStatusCode code)
        {
            string message;
            return PasswordReset(reset, out code, out message);
        }

        /// <summary>
        /// Get a collection of applictions owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Results<App> UserApps(Guid userId, int page = 1)
        {
            return GetBy<App, User>(userId, page);
        }

        /// <summary>
        /// Get a collection of mojio devices owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Results<Device> UserMojios(Guid userId, int page = 1)
        {
            return GetBy<Device, User>(userId, page);
        }
        
        /// <summary>
        /// Get a collection of trips owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Results<Trip> UserTrips(Guid userId, int page = 1)
        {
            return GetBy<Trip, User>(userId, page);
        }

        /// <summary>
        /// Get a collection of events owned by a user.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <returns></returns>
        public Results<Event> UserEvents(Guid userId, int page = 1)
        {
            return GetBy<Event, User>(userId, page);
        }

        public Address GetShipping(Guid? userId = null)
        {
            if (userId == null)
                userId = CurrentUser.Id;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "shipping"), Method.GET);

            var response = RestClient.Execute<Address>(request);
            return response.Data;
        }

        public bool SaveShipping(Address shipping, Guid? userId = null)
        {
            if (userId == null)
                userId = CurrentUser.Id;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "shipping"), Method.POST);
            request.AddBody(shipping);

            var response = RestClient.Execute(request);
            return response.StatusCode == HttpStatusCode.OK;
        }

        public CreditCard GetCreditCard(Guid? userId = null)
        {
            if (userId == null)
                userId = CurrentUser.Id;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "creditcard"), Method.GET);

            var response = RestClient.Execute<CreditCard>(request);
            return response.Data;
        }

        public bool SaveCreditCard(CreditCard creditCard, Guid? userId = null)
        {
            if (userId == null)
                userId = CurrentUser.Id;

            string action = Map[typeof(User)];
            var request = GetRequest(Request(action, userId, "creditcard"), Method.POST);
            request.AddBody(creditCard);

            var response = RestClient.Execute<bool>(request);
            return response.Data;
        }
    }
}
