using Mojio.Client.Linq;
using Mojio.Events;
using System;
//using RestSharp;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MockMojioClient:IMojioClient
    {
        public const string Sandbox = "http://sandbox.developer.moj.io/v1";
        public const string Live = "https://developer.moj.io/v1";

        public int PageSize { get; set; }
        public int SessionTime { get; set; }
        public const int DefaultPageSize = 10;

        #region Declaration for Mock

        MockClientController.MockLoginController LoginController = new MockClientController.MockLoginController();
        public List<TripEvent> TripEventList= new List<TripEvent>();
        public List<Trip> Trips = new List<Trip>();
        
        Guid tripId1 = Guid.NewGuid();
        Guid tripId2 = Guid.NewGuid();
        Guid ownerId = Guid.NewGuid();
        string mojioId = "Mojio1";
        Address Address;
        CreditCard CreditCard;
        Device Device;
        
        App App;
        User User;
        Storage Storage;
        Product Product;
        Trip Trip;
        TripEvent TripEvent;
        TripStatusEvent TripStatusEvent;
        Subscription Subscription;
        HardEvent HardEvent;
        IgnitionEvent IgnitionEvent;
        FenceEvent FenceEvent;
        bool logged=false;
        ChangePassword changePassword;
        List<Guid> Owners=new List<Guid>();
        List<Guid> Viewers = new List<Guid>();
        byte[] UserImage,DeviceImage;

        
        List<Event> Events=new List<Event>();
        List<Device> Devices = new List<Device>();
        List<App> Apps = new List<App>();
        List<User> Users = new List<User>();
        List<Product> Products = new List<Product>();
        List<Subscription> Subscriptions = new List<Subscription>();
        List<TripStatusEvent> TripStatusEvents = new List<TripStatusEvent >();
        List<HardEvent> HardEvents = new List<HardEvent>();
        List<IgnitionEvent> IgnitionEvents = new List<IgnitionEvent>();
        List<FenceEvent> FenceEvents = new List<FenceEvent>();

        Event Event;
         Results<Event> EventsResult ;
         Results<Trip> TripsResult;
         Results<Device> DevicesResult;
         Results<App> AppsResult;
         Results<User> UsersResult;
         Results<Product> ProductsResult;

         private void LoadMockAddress()
         { 
            #region Address
             Address = new Address
             {
                 Address1 = "Address1",
                 Address2 = "Address2",
                 City = "City",
                 State = "State",
                 Country = "Country",
                 Zip = "000000"
             };
             #endregion
         }
         private void LoadMockCreditCard()
         { 
          #region CreditCard
             CreditCard = new CreditCard
             {
                 Address = Address,
                 CardNumber = "123456789",
                 CVV = 123,
                 ExpiryMonth = 10,
                 ExpiryYear = 2015,
                 Id = "12345",
                 NameOnCard = "Mojio Group",
                 Type = "VISA"
             };
             #endregion
         }
         private void LoadMockEvent()
         { 
             #region Event
             Event = new Event
             {
                 Id = Guid.NewGuid(),
                 MojioId = "MojioID",
                 EventType = EventType.IgnitionOn
             };
             Events.Add(Event);
             #endregion
            #region Result for Event
             EventsResult = new Results<Event>
             {
                 Data = Events,
                 TotalRows = Events.Count()
             };
             #endregion
         }
         private void LoadMockDevice()
         { 
         #region Device
             Device = new Device
             {
                 Id = "Entity ID",
                 IgnitionOn = true,
                 LastContactTime = DateTime.Now

             };
             Devices.Add(Device);
             #endregion
            #region Result for Device
             DevicesResult = new Results<Device>
             {
                 Data = Devices,
                 TotalRows = Devices.Count()
             };
             #endregion
         }
         private void LoadMockApp()
         { 
          #region App
             App = new App
             {
                Id=Guid.NewGuid(),
                CreationDate=DateTime.Now,
                Name="AppName",
                Description="AppDescription"
             };
             Apps.Add(App);
             #endregion
             
             #region Result for App
             AppsResult = new Results<App>
             {
                 Data = Apps,
                 TotalRows = Apps.Count()
             };
             #endregion
         }
         private void LoadMockUser()
         { 
           #region User
             User = new User
             {
                 Id=Guid.NewGuid(),
                 UserName="User Name",
                 FirstName="First Name",
                 Email="mail@moj.io",
                 CreationDate=DateTime.Now,
                 LastName="Last Name"                 
             };
             Users.Add(User);
             #endregion
             
             #region Result for User
             UsersResult = new Results<User>
             {
                 Data = Users,
                 TotalRows = Users.Count()
             };
             #endregion
         }
         private void LoadMockTrip()
         {

             #region TripEvent
             TripEvent te = new TripEvent
             {
                 MojioId = mojioId,
                 OwnerId = ownerId,
                 EventType = EventType.IgnitionOn,
                 Time = DateTime.Now, //ToDo
                 TripId = tripId1
             };
             TripEventList.Add(te);
             #endregion
             #region Trip
             Trip t = new Trip
             {
                 Id = tripId1,
                 MojioId = mojioId,
                 StartTime = DateTime.Now,
                 StartLocation = new Location
                 {
                     Lat = 100.00F,
                     Lng = 200.00F
                 },
                 EndLocation = new Location
                 {
                     Lat = 500.00F,
                     Lng = 800.00F
                 }
             };
             Trips.Add(t);
             t = new Trip
             {
                 Id = tripId2,
                 MojioId = mojioId,
                 StartTime = DateTime.Now,
                 StartLocation = new Location
                 {
                     Lat = 50.00F,
                     Lng = 200.00F
                 },
                 EndLocation = new Location
                 {
                     Lat = 700.00F,
                     Lng = 800.00F
                 }
             };
             Trips.Add(t);
             #endregion
             #region Result for Trip
             TripsResult = new Results<Trip>
             {
                 Data = Trips,
                 TotalRows = Trips.Count()
             };
             #endregion
}

        #endregion


        public Token Token {get;set;}

        static MapEntity Map = new MapEntity();



        static MockMojioClient()
        {
            Map.Add(typeof(App), "apps");
            Map.Add(typeof(User), "users");
            Map.Add(typeof(Device), "mojios");
            Map.Add(typeof(Event), "events");
            //Map.Add(typeof(GPSEvent), "events");
            //Map.Add(typeof(IgnitionEvent), "events");
            //Map.Add(typeof(ITripEvent), "events");
            //Map.Add(typeof(TripStatusEvent), "events");
            //Map.Add(typeof(HardEvent), "events");

            Map.Add(typeof(Trip), "trips");
            Map.Add(typeof(Product), "products");

            Map.Add(typeof(Invoice), "orders");

            Map.Add(typeof(Subscription), "subscriptions");
            

        }
              /// <summary>
        /// Begin a new session using the App ID and secretKey.
        /// </summary>
        /// <param name="appId">Application ID</param>
        /// <param name="secretKey">Secret Key</param>
        /// <param name="Url">API endpoint URL</param>
        public MockMojioClient(Guid appId, Guid secretKey, string Url = Live)
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
        public MockMojioClient(Guid appId, Guid secretKey, Guid? tokenId, string Url = Live)
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
        public MockMojioClient(Guid appId, Guid secretKey, string userOrEmail, string password, string Url = Live)
            : this(Url)
        {
            Begin(appId, secretKey, userOrEmail, password);
        }

        /// <summary>
        /// Initiate a new MockMojioClient.  No session token has been created yet.
        /// Client must call Begin, or supply set a valid Token.
        /// </summary>
        /// <param name="Url">API endpoint URL</param>
        public MockMojioClient(string Url = Live)
        {
            PageSize = 10;
            SessionTime = 24 * 60;
            
            //RestClient = new RestClient(Url);
            //RestClient.AddHandler("application/json", new RSJsonSerializer());
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
            //TODO for existing Token
            return Begin(appId, secretKey);
            
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
            
            var response = LoginController.Begin(appId,secretKey);
            Token = response;
            if (response.UserId != null)
            {
                
                return true;
            }
            else 
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
            
            var response = LoginController.Begin(appId,secretKey,userOrEmail,password);
            if (response!=null)
            {
                Token = response;
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
            //HttpStatusCode ignore;
            //return SetUser(userOrEmail, password, out ignore);
            logged = true;
            return true;
        }

        /// <summary>
        /// Authenticate a user and update the current session token.
        /// </summary>
        /// <param name="userOrEmail"></param>
        /// <param name="password"></param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public bool SetUser(string userOrEmail, string password, out HttpStatusCode code)
        {
            string ignore;
            return SetUser(userOrEmail, password, out code, out ignore);
        }

        /// <summary>
        /// Authenticate a user and update the current session token.
        /// </summary>
        /// <param name="userOrEmail"></param>
        /// <param name="password"></param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public bool SetUser(string userOrEmail, string password, out HttpStatusCode code, out string message)
        {
            var response = SetUserAsync(userOrEmail, password).Result;
            code = response.StatusCode;
            message = response.Content;

            if (response.StatusCode == HttpStatusCode.OK)
                return true;

            return false;
        }

		public Task<MojioResponse<Token>> SetUserAsync(string userOrEmail, string password)
        {
            if (Token == null)
                throw new Exception("Valid session must be initialized first."); // Can only "Login" if already authenticated app.
                       
            throw new NotImplementedException();           
        }

        /// <summary>
        /// Unset authenticated user.
        /// </summary>
        /// <returns></returns>
        public bool ClearUser()
        {
        //    var response = ClearUserAsync().Result;

        //    if (response.StatusCode == HttpStatusCode.OK)
        //        return true;

            return true;
        }

		public Task<MojioResponse<Token>> ClearUserAsync()
		{
            if (Token == null)
                throw new Exception("Valid session must be initialized first.");

            throw new NotImplementedException();
		}

        /// <summary>
        /// Extend token expiry date.
        /// </summary>
        /// <param name="minutes">Exipry time in minutes</param>
        /// <returns></returns>
        public bool ExtendSession(int minutes)
        {
           
            DateTime extend = DateTime.UtcNow.AddMinutes(minutes);
            if (Token.ValidUntil < extend)
            {
                Token.ValidUntil = extend;
                //BaseController.TokenDatabase.Save(token);
            }
            return true;
        }

        /// <summary>
        /// Extend token expiry date.
        /// </summary>
        /// <param name="minutes">Exipry time in minutes</param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public bool ExtendSession(int minutes, out HttpStatusCode code)
        {
            string ignore;
            return ExtendSession(minutes, out code, out ignore);
        }

        /// <summary>
        /// Extend token expiry date.
        /// </summary>
        /// <param name="minutes">Exipry time in minutes</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public bool ExtendSession(int minutes, out HttpStatusCode code, out string message )
        {
            var response = ExtendSessionAsync(minutes).Result;

            code = response.StatusCode;
            message = response.Content;

			return response.StatusCode == HttpStatusCode.OK;
        }

		public Task<MojioResponse<Token>> ExtendSessionAsync(int minutes)
        {
            if (Token == null)
                throw new Exception("No session to extend."); // Can only "Extend" if already authenticated app.

            throw new NotImplementedException();
        }

        /// <summary>
        /// Generate basic request.  Adds the session token to header if exists.
        /// </summary>
        /// <param name="resource">Resource URL</param>
        /// <param name="method">Request method</param>
        /// <returns></returns>
        //public RestRequest GetRequest(string resource, Method method)
        //{
        //    var request = new RestRequest(resource, method);
        //    request.RequestFormat = DataFormat.Json;
        //    request.JsonSerializer = new RSJsonSerializer();

        //    if (Token != null)
        //        request.AddHeader(Headers.MojioAPITokenHeader, Token.Id.ToString());
        //    return request;
        //}

        public Task<MojioResponse> RequestAsync(MojioResponse mojioResponse)
        {
            var tcs = new TaskCompletionSource<MojioResponse>();
            tcs.SetResult(mojioResponse);
            return tcs.Task;
        }

        public Task<MojioResponse<T>> RequestAsync<T>(MojioResponse<T> mojioResponse)
            where T : new()
        {
           
            var tcs = new TaskCompletionSource<MojioResponse<T>>();
            tcs.SetResult(mojioResponse);
            return tcs.Task;
        }

        /// <summary>
        /// Create a new entity through API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to create</param>
        /// <returns></returns>
        public T Create<T>(T entity)
            where T : BaseEntity, new()
        {
            HttpStatusCode ignore;
             return Create<T>(entity, out ignore);
        }

        /// <summary>
        /// Create a new entity through API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to create</param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public T Create<T>(T entity, out HttpStatusCode code)
            where T : BaseEntity, new()
        {
            string ignore;
            return Create<T>(entity, out code, out ignore);
        }

        /// <summary>
        /// Create a new entity through API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to create</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public T Create<T>(T entity, out HttpStatusCode code, out string message)
            where T : BaseEntity, new()
        {
            var response = CreateAsync(entity).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

		public Task<MojioResponse<T>> CreateAsync<T>(T entity)
            where T : BaseEntity, new()
        {

            object savedData=null; 

            if (typeof(T).Name == "User")
            {
                object temp = entity;
                User = (User)temp;
                Users.Add(User);
                savedData=User;
            }
            else if (typeof(T).Name == "App")
            {
                if (App == null)
                {
                    object temp = entity;
                    App = (App)temp;
                    Apps.Add(App);
                    savedData = App;
                }
                else
                    savedData = null;
            }
            else if (typeof(T).Name == "Device")
            {
                object temp = entity;
                Device = (Device)temp;
                Devices.Add(Device);
                savedData = Device;
            }
            else if (typeof(T).Name == "Product")
            {
                object temp = entity;
                Product = (Product)temp;
                Products.Add(Product);
                savedData = Product;
            }
            else if (typeof(T).Name == "Address")
            {
                object temp = entity;
                Address = (Address)temp;
                savedData = Address;
            }
            else if (typeof(T).Name == "CreditCard")
            {
                object temp = entity;
                CreditCard = (CreditCard)temp;
                savedData = CreditCard;
            }
            else if (typeof(T).Name == "Storage")
            {
                object temp = entity;
                Storage = (Storage)temp;
                savedData = Storage;
            }
            else if (typeof(T).Name == "TripEvent")
            {
                object temp = entity;
                TripEvent = (TripEvent)temp;
                Trip = new Trip
                {
                    MojioId=TripEvent.MojioId,
                    Id=(Guid)TripEvent.TripId
                };
                Trips.Add(Trip);

                Event = new Event { 
                    Id=TripEvent.Id,
                 MojioId=TripEvent.MojioId,
                 OwnerId=TripEvent.OwnerId,
                 EventType=TripEvent.EventType,                 
                };
                Events.Add(Event);
                savedData = TripEvent;
            }
            else if (typeof(T).Name == "Subscription")
            {
                object temp = entity;
                Subscription = (Subscription)temp;
                Subscriptions.Add(Subscription);
                savedData = Subscription;
            }
            else if (typeof(T).Name == "Trip")
            {
                object temp = entity;
                
                Trip = (Trip)temp;
                Trips.Add(Trip);
                savedData = Trip;
            }
            else if (typeof(T).Name == "TripStatusEvent")
            {
                object temp = entity;
                TripStatusEvent = (TripStatusEvent)temp;
                TripStatusEvents.Add(TripStatusEvent);
                savedData = TripStatusEvent;
                Trip = new Trip
                {
                    MojioId = TripStatusEvent.MojioId,
                    Id = (Guid)TripStatusEvent.TripId,
                    Distance = TripStatusEvent.Distance,
                    MaxSpeed = TripStatusEvent.MaxSpeed,
                    IdleTime = TripStatusEvent.IdleTime,
                    Fuel = TripStatusEvent.Fuel,

                    StartLocation = TripStatusEvent.Location


                };
                Trips.Add(Trip);
                Device = new Device
                {
                    LastLocation = TripStatusEvent.Location,
                    CurrentTrip = TripStatusEvent.TripId
                };
                Devices.Add(Device);

                Event = new Event
                {
                    Id=TripStatusEvent.Id,
                    MojioId = TripStatusEvent.MojioId,
                    OwnerId = TripStatusEvent.OwnerId,
                    EventType = TripStatusEvent.EventType,
                };
                Events.Add(Event);
            }
            else if (typeof(T).Name == "HardEvent")
            {
                object temp = entity;
                HardEvent = (HardEvent)temp;
                HardEvents.Add(HardEvent);
                savedData = HardEvent;
            }
            else if (typeof(T).Name == "IgnitionEvent")
            {
                object temp = entity;
                IgnitionEvent = (IgnitionEvent)temp;
                IgnitionEvents.Add(IgnitionEvent);
                Trip.EndLocation = IgnitionEvent.Location;
                savedData = IgnitionEvent;
            }
            else if (typeof(T).Name == "Event")
            {
                object temp = entity;
                Event = (Event)temp;
                Events.Add(Event);
                savedData = Event;
            }
            else if (typeof(T).Name == "FenceEvent")
            {
                object temp = entity;
                FenceEvent = (FenceEvent)temp;
                FenceEvents.Add(FenceEvent);
                savedData = FenceEvent;
            }


            MojioResponse<T> m = new MojioResponse<T>
            {
                Content = "Create",
                Data = (T)savedData,
                StatusCode = HttpStatusCode.OK
            };
            var tcs = new TaskCompletionSource<MojioResponse<T>>();
            tcs.SetResult(m);
            return tcs.Task;
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
            HttpStatusCode ignore;
            return Delete<T>(entity, out ignore);
        }

        /// <summary>
        /// Delete an entity through the API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to delete</param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public bool Delete<T>(T entity, out HttpStatusCode code)
            where T : BaseEntity
        {
            string ignore;
            return Delete<T>(entity, out code, out ignore);
        }

        /// <summary>
        /// Delete an entity through the API.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Entity to delete</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public bool Delete<T>(T entity, out HttpStatusCode code, out string message)
            where T : BaseEntity
        {
            return Delete<T>(entity.IdToString, out code, out message);
        }

        /// <summary>
        /// Delete an entity by Entity ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <returns></returns>
        public bool Delete<T>(object id)
        {
            HttpStatusCode ignore;
            return Delete<T>(id, out ignore);
        }

        /// <summary>
        /// Delete an entity by Entity ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public bool Delete<T>(object id, out HttpStatusCode code)
        {
            string ignore;
            return Delete<T>(id, out code, out ignore);
        }

        /// <summary>
        /// Delete an entity by Entity ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public bool Delete<T>(object id, out HttpStatusCode code, out string message)
        {
            //var response = DeleteAsync<T>(id).Result;            
            code = HttpStatusCode.OK;
            message = "Deleted";
            //if (typeof(T).Name == "User")
            //{
            //    User=null;
            //    Users = null;
            //}
            //else if (typeof(T).Name == "App")
            //{
            //     App = null;
            //     Apps = null;
            //}
            //else if (typeof(T).Name == "Device")
            //{
            //     Device = null;
            //     Devices = null;
            //}
            //else if (typeof(T).Name == "Product")
            //{
            //    Product = null;
            //    Products = null;
            //}
            //else if (typeof(T).Name == "Address")
            //{
            //    Address = null;
            //}
            //else if (typeof(T).Name == "CreditCard")
            //{
            //    CreditCard = null;
            //}
            //else if (typeof(T).Name == "Storage")
            //{
            //    Storage = null;
            //}
            //else if (typeof(T).Name == "TripEvent")
            //{
                
            //    TripEvent = null;
            //}
            //else if (typeof(T).Name == "Subscription")
            //{
            //    Subscriptions = null;
            //    Subscription = null;
            //}
            //else if (typeof(T).Name == "Trip")
            //{
            //   Trip = null;
            //   Trips=null;
            //}
            //else if (typeof(T).Name == "TripStatusEvent")
            //{
            //    TripStatusEvent = null;
            //    TripStatusEvents=null;
            //}
            //else if (typeof(T).Name == "HardEvent")
            //{
            //   HardEvent =null;
            //    HardEvents=null;
            //}
            //else if (typeof(T).Name == "IgnitionEvent")
            //{
            //    IgnitionEvent = null;
            //    IgnitionEvents=null;
            //}
            //else if (typeof(T).Name == "Event")
            //{
            //    Event = null;
            //    Events= null;
            //}

           // return response.StatusCode == System.Net.HttpStatusCode.OK;
            return true;
        }

		public Task<MojioResponse> DeleteAsync<T>(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update/save an entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Updated Entity</param>
        /// <returns></returns>
        public T Update<T>(T entity)
            where T : BaseEntity, new()
        {
            HttpStatusCode ignore;
            //string temp = typeof(T).Name;
            //temp = temp.Substring(temp.IndexOf('.')+1);
            return Update<T>(entity, out ignore);
        }

        /// <summary>
        /// Update/save an entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Updated Entity</param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public T Update<T>(T entity, out HttpStatusCode code)
            where T : BaseEntity, new()
        {
            string ignore;
            return Update<T>(entity, out code, out ignore);
        }

        /// <summary>
        /// Update/save an entity.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity">Updated Entity</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public T Update<T>(T entity, out HttpStatusCode code, out string message)
            where T : BaseEntity, new()
        {
            var response = UpdateAsync<T>(entity).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

		public Task<MojioResponse<T>> UpdateAsync<T>(T entity)
            where T : BaseEntity, new()
        {

            object savedData = null;

            if (typeof(T).Name == "User")
            {
                object temp = entity;
                User = (User)temp;
                Users.Add(User);
                savedData = User;
            }
            else if (typeof(T).Name == "App")
            {
                
                    object temp = entity;
                    App = (App)temp;
                    Apps.Add(App);
                    savedData = App;
                
            }
            else if (typeof(T).Name == "Device")
            {
                object temp = entity;
                Device = (Device)temp;
                Devices.Add(Device);
                savedData = Device;
            }
            else if (typeof(T).Name == "Product")
            {
                object temp = entity;
                Product = (Product)temp;
                Products.Add(Product);
                savedData = Product;
            }
            else if (typeof(T).Name == "Address")
            {
                object temp = entity;
                Address = (Address)temp;
                savedData = Address;
            }
            else if (typeof(T).Name == "CreditCard")
            {
                object temp = entity;
                CreditCard = (CreditCard)temp;
                savedData = CreditCard;
            }
            else if (typeof(T).Name == "Storage")
            {
                object temp = entity;
                Storage = (Storage)temp;
                savedData = Storage;
            }
            else if (typeof(T).Name == "TripEvent")
            {
                object temp = entity;
                TripEvent = (TripEvent)temp;
                Trip = new Trip
                {
                    MojioId = TripEvent.MojioId,
                    Id = (Guid)TripEvent.TripId
                };
                Trips.Add(Trip);

                Event = new Event
                {
                    Id = TripEvent.Id,
                    MojioId = TripEvent.MojioId,
                    OwnerId = TripEvent.OwnerId,
                    EventType = TripEvent.EventType,
                };
                Events.Add(Event);
                savedData = TripEvent;
            }
            else if (typeof(T).Name == "Subscription")
            {
                object temp = entity;
                Subscription = (Subscription)temp;
                Subscriptions.Add(Subscription);
                savedData = Subscription;
            }
            else if (typeof(T).Name == "Trip")
            {
                object temp = entity;

                Trip = (Trip)temp;
                Trips.Add(Trip);
                savedData = Trip;
            }
            else if (typeof(T).Name == "TripStatusEvent")
            {
                object temp = entity;
                TripStatusEvent = (TripStatusEvent)temp;
                TripStatusEvents.Add(TripStatusEvent);
                savedData = TripStatusEvent;
                Trip = new Trip
                {
                    MojioId = TripStatusEvent.MojioId,
                    Id = (Guid)TripStatusEvent.TripId,
                    Distance = TripStatusEvent.Distance,
                    MaxSpeed = TripStatusEvent.MaxSpeed,
                    IdleTime = TripStatusEvent.IdleTime,
                    Fuel = TripStatusEvent.Fuel,

                    StartLocation = TripStatusEvent.Location


                };
                Trips.Add(Trip);
                Device = new Device
                {
                    LastLocation = TripStatusEvent.Location,
                    CurrentTrip = TripStatusEvent.TripId
                };
                Devices.Add(Device);

                Event = new Event
                {
                    Id = TripStatusEvent.Id,
                    MojioId = TripStatusEvent.MojioId,
                    OwnerId = TripStatusEvent.OwnerId,
                    EventType = TripStatusEvent.EventType,
                };
                Events.Add(Event);
            }
            else if (typeof(T).Name == "HardEvent")
            {
                object temp = entity;
                HardEvent = (HardEvent)temp;
                HardEvents.Add(HardEvent);
                savedData = HardEvent;
            }
            else if (typeof(T).Name == "IgnitionEvent")
            {
                object temp = entity;
                IgnitionEvent = (IgnitionEvent)temp;
                IgnitionEvents.Add(IgnitionEvent);
                Trip.EndLocation = IgnitionEvent.Location;
                savedData = IgnitionEvent;
            }
            else if (typeof(T).Name == "Event")
            {
                object temp = entity;
                Event = (Event)temp;
                Events.Add(Event);
                savedData = Event;
            }
            else if (typeof(T).Name == "FenceEvent")
            {
                object temp = entity;
                FenceEvent = (FenceEvent)temp;
                FenceEvents.Add(FenceEvent);
                savedData = FenceEvent;
            }


            MojioResponse<T> m = new MojioResponse<T>
            {
                Content = "Create",
                Data = (T)savedData,
                StatusCode = HttpStatusCode.OK
            };


            var tcs = new TaskCompletionSource<MojioResponse<T>>();
            tcs.SetResult(m);           
            return tcs.Task;
          
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
            HttpStatusCode ignore;
            return Get<T>(id, out ignore);
        }

        /// <summary>
        /// Get an entity by ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="code">Response code</param>
        /// <returns></returns>
        public T Get<T>(object id, out HttpStatusCode code)
            where T : new()
        {
            string ignore;
            return Get<T>(id, out code, out ignore);
        }

        /// <summary>
        /// Get an entity by ID.
        /// </summary>
        /// <typeparam name="T">Entity Type</typeparam>
        /// <param name="id">Entity ID</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <returns></returns>
        public T Get<T>(object id, out HttpStatusCode code, out string message)
            where T : new()
        {
            var task = GetAsync<T>(id);
            task.Wait();

            var response = task.Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

		public Task<MojioResponse<T>> GetAsync<T>(object id)
            where T : new()
        {
           
            object data=null;
            if (typeof(T).Name == "User")
            {
                User.Id = (Guid)id;
                data = User; 
            }
            else if (typeof(T).Name == "App")
            {
                data = App;
            }
            else if (typeof(T).Name == "Device")
            {
                data = Device;
            }
            else if (typeof(T).Name == "Product")
            {
                data = Product;
            }
            else if (typeof(T).Name == "Address")
            {
                data = Address;
            }
            else if (typeof(T).Name == "CreditCard")
            {
                data = CreditCard;
            }
            else if (typeof(T).Name == "Storage")
            {
                data = Storage;
            }
            else if (typeof(T).Name == "TripEvent")
            {               
                data=TripEvent ;
            }
            else if (typeof(T).Name == "Subscription")
            {
                data = Subscription;
            }
            else if (typeof(T).Name == "Trip")
            {
               
                    data = Trip;
                
            }
            else if (typeof(T).Name == "TripStatusEvent")
            {
                data=TripStatusEvent;
            }
            else if (typeof(T).Name == "HardEvent")
            {
                data=HardEvent;
            }
            else if (typeof(T).Name == "IgnitionEvent")
            {
                data=IgnitionEvent;
            }
            else if (typeof(T).Name == "Event")
            {
                data = Event;
            }
            else if (typeof(T).Name == "FenceEvent")
            {
                data = FenceEvent;
            }

            MojioResponse<T> mojioResponse = new MojioResponse<T>
            {
                Content = "User Data",
                Data =(T)data,
                StatusCode = HttpStatusCode.Created
            };

            var tcs = new TaskCompletionSource<MojioResponse<T>>();
            tcs.SetResult(mojioResponse);
            return tcs.Task;
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
            HttpStatusCode ignore;
            return GetBy<M, T>(entity, out ignore, page);
        }

        /// <summary>
        /// Get a collection of M entities associated to a particular entity.
        /// </summary>
        /// <typeparam name="M">Entity type to fetch</typeparam>
        /// <typeparam name="T">Entity type to search by</typeparam>
        /// <param name="entity">Entity to search by</param>
        /// <param name="code">Response code</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<M> GetBy<M, T>(T entity, out HttpStatusCode code, int page = 1)
            where T : BaseEntity, new()
        {
            string ignore;
            return GetBy<M, T>(entity, out code, out ignore, page);
        }

        /// <summary>
        /// Get a collection of M entities associated to a particular entity.
        /// </summary>
        /// <typeparam name="M">Entity type to fetch</typeparam>
        /// <typeparam name="T">Entity type to search by</typeparam>
        /// <param name="entity">Entity to search by</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<M> GetBy<M, T>(T entity, out HttpStatusCode code, out string message, int page = 1)
            where T : BaseEntity, new()
        {
            return GetBy<M, T>(entity.IdToString, out code, out message, page);
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
        public Results<M> GetBy<M, T>(object id, int page = 1, string action = null)
            where T : new()
        {
            HttpStatusCode ignore;
            return GetBy<M, T>(id, out ignore, page, action);
        }

        /// <summary>
        /// Get a collection of M entities associated to a particular entity.
        /// </summary>
        /// <typeparam name="M">Entity type to fetch</typeparam>
        /// <typeparam name="T">Entity type to search by</typeparam>
        /// <param name="id">Id of entity to search by</param>
        /// <param name="code">Response code</param>
        /// <param name="action">Specific action name to call</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<M> GetBy<M, T>(object id, out HttpStatusCode code, int page = 1, string action = null)
            where T : new()
        {
            string ignore;
            return GetBy<M, T>(id, out code, out ignore, page, action);
        }

        /// <summary>
        /// Get a collection of M entities associated to a particular entity.
        /// </summary>
        /// <typeparam name="M">Entity type to fetch</typeparam>
        /// <typeparam name="T">Entity type to search by</typeparam>
        /// <param name="id">Id of entity to search by</param>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <param name="action">Specific action name to call</param>
        /// <param name="page">Pagenation page</param>
        /// <returns></returns>
        public Results<M> GetBy<M,T>(object id, out HttpStatusCode code, out string message, int page = 1, string action = null)
            where T : new()
        {
            var response = GetByAsync<M, T>(id, page, action).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

		public Task<MojioResponse<Results<M>>> GetByAsync<M, T>(object id, int page = 1, string action = null)
            where T : new()
        {
            object data=null;
            if (typeof(M).Name == "User")
            {
                Users.Add(User);
                data = Users.AsEnumerable();
            }
            else if (typeof(M).Name == "App")
            {
               
                Apps.Add(App);
                data = Apps.AsEnumerable();
            }
            else if (typeof(M).Name == "Device")
            {
               
                Devices.Add(Device);
                data = Devices.AsEnumerable();
            }
            else if (typeof(M).Name == "Product")
            {
                
                Products.Add(Product);
                data = Products.AsEnumerable();
            }
            else if (typeof(M).Name == "Subscription")
            {

                Subscriptions.Add(Subscription);
                data = Subscriptions.AsEnumerable();
            }
            else if (typeof(M).Name == "Trip")
            {
                data = Trips.AsEnumerable();
            }
            else if (typeof(M).Name == "TripStatusEvent")
            {
                data = TripStatusEvents.AsEnumerable();
            }
            else if (typeof(M).Name == "HardEvent")
            {
                data = HardEvents.AsEnumerable();
            }
            else if (typeof(M).Name == "IgnitionEvent")
            {
                data = IgnitionEvents.AsEnumerable();
            }
            else if (typeof(M).Name == "Event")
            {
                data = Events.AsEnumerable();
            }
            else if (typeof(M).Name == "FenceEvent")
            {
                data = FenceEvents.AsEnumerable();
            }

            
            Results<M> results = new Results<M>
            {
                TotalRows=1,
                Data = (IEnumerable<M>)data
            };

            MojioResponse<Results<M>> mojioResponse = new MojioResponse<Results<M>>
            {
                Content = "User Data",
                Data = (Results<M>)results,
                StatusCode = HttpStatusCode.Created
            };
            var tcs = new TaskCompletionSource<MojioResponse<Results<M>>>();
            tcs.SetResult(mojioResponse);
            return tcs.Task;
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
            HttpStatusCode ignore;
            return Get<T>(out ignore, page);
        }

        /// <summary>
        /// Get a collection of entities available to the current session.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="code">Response code</param>
        /// <param name="page">Page</param>
        /// <returns></returns>
        public Results<T> Get<T>(out HttpStatusCode code, int page = 1)
            where T : new()
        {
            string ignore;
            return Get<T>(out code, out ignore, page);
        }

        /// <summary>
        /// Get a collection of entities available to the current session.
        /// </summary>
        /// <typeparam name="T">Entity type</typeparam>
        /// <param name="code">Response code</param>
        /// <param name="message">Response message</param>
        /// <param name="page">Page</param>
        /// <returns></returns>
        public Results<T> Get<T>(out HttpStatusCode code, out string message, int page = 1)
            where T : new()
        {
            var response = GetAsync<T>(page).Result;
            code = response.StatusCode;
            message = response.Content;

            return response.Data;
        }

		public Task<MojioResponse<Results<T>>> GetAsync<T>(int page = 1)
            where T : new()
        {
            object data = null;
            if (typeof(T).Name == "User")
            {
                Users.Add(User);
                data = Users.AsEnumerable();
            }
            else if (typeof(T).Name == "App")
            {

                Apps.Add(App);
                data = Apps.AsEnumerable();
            }
            else if (typeof(T).Name == "Device")
            {

                Devices.Add(Device);
                data = Devices.AsEnumerable();
            }
            else if (typeof(T).Name == "Product")
            {

                Products.Add(Product);
                data = Products.AsEnumerable();
            }
            else if (typeof(T).Name == "Subscription")
            {

                Subscriptions.Add(Subscription);
                data = Subscriptions.AsEnumerable();
            }
            else if (typeof(T).Name == "Trip")
            {
                data = Trips.AsEnumerable();
            }
            else if (typeof(T).Name == "TripStatusEvent")
            {
                data = TripStatusEvents.AsEnumerable();
            }
            else if (typeof(T).Name == "HardEvent")
            {
                data = HardEvents.AsEnumerable();
            }
            else if (typeof(T).Name == "IgnitionEvent")
            {
                data = IgnitionEvents.AsEnumerable();
            } 
            else if (typeof(T).Name == "Event")
            {
                data = Events.AsEnumerable();
            }
            else if (typeof(T).Name == "FenceEvent")
            {
                data = FenceEvents.AsEnumerable();
            }

            Results<T> results = new Results<T>
            {
                TotalRows = 1,
                Data = (IEnumerable<T>)data
            };

            MojioResponse<Results<T>> mojioResponse = new MojioResponse<Results<T>>
            {
                Content = "User Data",
                Data = (Results<T>)results,
                StatusCode = HttpStatusCode.Created
            };
            var tcs = new TaskCompletionSource<MojioResponse<Results<T>>>();
            tcs.SetResult(mojioResponse);
            return tcs.Task;
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
            if (Owners.Contains<Guid>(userId))
                return false;
            Owners.Add(userId);
            return true;

            
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
            if (!Owners.Contains<Guid>(userId))
                return false;
            Owners.Remove(userId);
            return true;
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
            if (Viewers.Contains<Guid>(userId))
                return false;
            Viewers.Add(userId);
            return true;
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


            if (logged)
            {
                if (!Viewers.Contains<Guid>(userId))
                    return false;
                Viewers.Remove(userId);
                return true;
            }
            else
                return false;

            
        }

        public void ThrowError(string errorMessage)
        {
            throw new Exception(errorMessage);
        }

        public static T Deserialize<T>(string content)
        {
            var serializer = new RSJsonSerializer();
            return serializer.Deserialize<T>(content);
        }

        public MojioQueryable<T> Queryable<T>()
            where T : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

    }
}
