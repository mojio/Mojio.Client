using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using Mojio;

namespace Mojio.Client.MockClientController
{
    public  static class MockSecurity
    {
        public const string AppIdParameter = "mojioAppId";

        // Method 1: AppId saved in Session
        public const string MojioAppSession = "MojioAppSession";

        // Method 2: Session token in header
        public const int AppTokenWindow = 120;
        public const int UserTokenWindow = 43829;

        public static Token Token;
        public static App App;
        public static void LoadMockMojioData()
        {
            #region Token
            Token = new Token
            {
                AppId = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                ValidUntil = DateTime.Now.AddHours(0.5)
            };

            #endregion

            
        }

        

        
        public static Token GetToken(Guid tokenId)
        {
            LoadMockMojioData();
            var token = Token;

            if (token != null)
            {
                // Check if the token is still valid
                if (token.ValidUntil < DateTime.UtcNow)
                {
                   //BaseController.TokenDatabase.Delete(token);
                    return null;
                }

                ExtendToken(token, AppTokenWindow);
            }

            return token;
        }

        public static Token ExtendToken(Token token, int minutes)
        {
            DateTime extend = DateTime.UtcNow.AddMinutes(minutes);
            if (token.ValidUntil < extend)
            {
                token.ValidUntil = extend;
                //BaseController.TokenDatabase.Save(token);
            }

            return token;
        }

        // This is it - this function does all the authorization checking
        //public static bool IsAuthorized(HttpActionContext actionContext, bool checkUser = false, Roles roles = Roles.None)
        //public static bool IsAuthorized(HttpActionContext actionContext, bool checkUser = false)
        //{
        //    //actionContext.ActionDescriptor.ActionName
        //    //actionContext.ActionDescriptor.ControllerDescriptor.ControllerName
        //    //actionContext.ActionDescriptor
        //    // ReflectedHttpActionDescriptor 
        //    //Guid? appId = null;
        //    App app = null;
        //    Token token = null;

        //    // Method 1: Session
        //    if (HttpContext.Current != null &&
        //        HttpContext.Current.Session != null)
        //    {
        //        token = HttpContext.Current.Session[MojioAppSession] as Token;
        //    }

        //    // Method 2: Session token in header
        //    IEnumerable<string> items;
        //    if (actionContext.Request.Headers.TryGetValues(Headers.MojioAPITokenHeader, out items))
        //    {
        //        Guid tokenId;
        //        if (items != null &&
        //            items.Count() == 1 &&
        //            Guid.TryParse(items.First(), out tokenId))
        //        {
        //            token = GetToken(tokenId);
        //        }
        //    }

        //    // Method 3: AppId & SecretKey sent each time in Basic Authentication header
        //    if (actionContext.Request.Headers.Authorization != null)
        //    {
        //        string authToken = actionContext.Request.Headers.Authorization.Parameter;
        //        string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

        //        string appIdString = decodedToken.Substring(0, decodedToken.IndexOf(":"));
        //        string secretKeyString = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

        //        app = GetApp(new Guid(appIdString), new Guid(secretKeyString));
        //        if (app != null && !checkUser)
        //        {
        //            token = new Token
        //            {
        //                Id = Guid.NewGuid(),
        //                AppId = app.Id
        //            };
        //        }
        //    }

        //    if (token != null)
        //    {
        //        if (checkUser && !token.UserId.HasValue)
        //            return false;

        //        //BaseController controller = actionContext.ControllerContext.Controller as BaseController;

        //        //if (!CheckRole(controller.CurrentUser ?? (token.UserId.HasValue ? UsersController.IntGet(token.UserId.Value) : null), roles))
        //        //    return false; // did not pass

        //        //if (controller != null)
        //        //    controller.SecurityContext = token;

        //        //return CheckRestricted(actionContext.ActionDescriptor as ReflectedHttpActionDescriptor, token.AppId, app, controller);
        //    }

        //    return false;
        //}

        //internal static bool CheckRole(User user, Roles? roles)
        //{
        //    if (roles == Roles.None)
        //        return true;

        //    if (user == null)
        //        return false; // automatic fail

        //    UsersController.IntLoadPrivate(user);
        //    if (user.UserPrivate.Roles == null)
        //        return false;

        //    return user.UserPrivate.Roles.Value.HasFlag(roles);
        //}

        //static bool CheckRestricted(ReflectedHttpActionDescriptor descriptor, Guid appId, App app, BaseController baseController)
        //{
        //    if (descriptor == null)
        //        return true;

        //    if (descriptor.MethodInfo.GetCustomAttributes(typeof(RestrictedAttribute), true).Count() == 1)
        //    {
        //        // We're dealing with a restricted function
        //        // Check to see if the app has access
        //        if (app == null)
        //        {
        //            app = BaseController.Database.Get<App>(appId);

        //            AppsController.IntLoadPrivate(app);
        //        }

        //        if (app.AppPrivate == null ||
        //            app.AppPrivate.Granted == null)
        //            return false;

        //        string path = string.Format("{0}/{1}", descriptor.ControllerDescriptor.ControllerName.ToLower(), descriptor.ActionName.ToLower());

        //        // Either the path or "*" has to exist
        //        bool result = (from g in app.AppPrivate.Granted
        //                       where
        //                       g == "*" ||
        //                       g == path
        //                       select g).Count() == 1;

        //        if (result)
        //            // log
        //            baseController.Action(descriptor.ControllerDescriptor.ControllerName, descriptor.ActionName);

        //        return result;
        //    }

        //    baseController.Action(descriptor.ControllerDescriptor.ControllerName, descriptor.ActionName);

        //    return true;
        //}

        static App GetApp(Guid appId, Guid secretKey)
        {
            App = new App
            {
                CreationDate = DateTime.Now,
                Name = "TestApp",
                Description = "Test Description"
            };

            if (App == null)
                return null;
            else
                return App;

            
        }

        public static bool Authorize(Guid appId, Guid secretKey)
        {
            App app = GetApp(appId, secretKey);
            if (app!= null)
            {
               return true;
            }
            return false;
        }

        public static Token AuthorizeToken(Guid appId, Guid secretKey, int minutes = AppTokenWindow)
        {
            Token token = IntAuthorizeToken(appId, secretKey, minutes);
            //if (token != null)
            //    BaseController.TokenDatabase.Save(token);
            return token;
        }

        public static Token AuthorizeToken(Guid appId, Guid secretKey, string username, string password, int minutes = UserTokenWindow)
        {
            Token token = IntAuthorizeToken(appId, secretKey, minutes);
            if (AuthorizeUser(token, username, password))
                return token;

            return null;
        }

        public static bool AuthorizeUser(Token token, string username, string password)
        {
            return true;
        }

        public static bool AuthorizeExternalUser(Token token, string externalSystemKey, string externalUserId, string email)
        {
            throw new NotImplementedException();
        }

        static Token IntAuthorizeToken(Guid appId, Guid secretKey, int minutes)
        {
            App app = GetApp(appId, secretKey);

            if (app != null)
            {
                Token appToken = new Token { AppId = appId, ValidUntil = DateTime.UtcNow.AddMinutes(minutes) };
                return appToken;
            }
            return null;
        }


    }
}