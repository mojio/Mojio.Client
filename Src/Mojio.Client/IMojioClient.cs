using Mojio.Client.Linq;
using System;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mojio.Client
{
    public interface IMojioClient
    {
        bool AddAdmin<T>(object id, Guid userId);
        bool AddAdmin<T>(T entity, Guid userId) where T : BaseEntity;
        bool AddViewer<T>(object id, Guid userId);
        bool AddViewer<T>(T entity, Guid userId) where T : BaseEntity;
        bool Begin(Guid appId, Guid secretKey);
        bool Begin(Guid appId, Guid secretKey, Guid? tokenId);
        bool Begin(Guid appId, Guid secretKey, string userOrEmail, string password);
        bool ChangePassword(string oldPassword, string newPassword);
        bool ChangePassword(string oldPassword, string newPassword, out HttpStatusCode code);
        bool ChangePassword(string oldPassword, string newPassword, out HttpStatusCode code, out string message);
        bool ChangePassword(string oldPassword, string newPassword, out string message);
        Task<MojioResponse<bool>> RequestPasswordResetAsync (string userNameOrEmail, string returnUrl = null);
		Task<Client.MojioResponse<T>> ClaimAsync<T>(T entity, int? pin) where T : BaseEntity, new();
        bool ClearUser();
        Task<Client.MojioResponse<Token>> ClearUserAsync();
        T Create<T>(T entity) where T : BaseEntity, new();
        T Create<T>(T entity, out HttpStatusCode code) where T : BaseEntity, new();
        T Create<T>(T entity, out HttpStatusCode code, out string message) where T : BaseEntity, new();
        Task<Client.MojioResponse<T>> CreateAsync<T>(T entity) where T : BaseEntity, new();
        User CurrentUser { get; }
        bool Delete<T>(object id);
        bool Delete<T>(object id, out HttpStatusCode code);
        bool Delete<T>(object id, out HttpStatusCode code, out string message);
        bool Delete<T>(T entity) where T : BaseEntity;
        bool Delete<T>(T entity, out HttpStatusCode code) where T : BaseEntity;
        bool Delete<T>(T entity, out HttpStatusCode code, out string message) where T : BaseEntity;
        Task<Client.MojioResponse> DeleteAsync<T>(object id);
        bool DeleteImage(out HttpStatusCode code, out string message, Guid? userId = null);
        bool ExtendSession(int minutes);
        bool ExtendSession(int minutes, out HttpStatusCode code);
        bool ExtendSession(int minutes, out HttpStatusCode code, out string message);
        Task<Client.MojioResponse<Token>> ExtendSessionAsync(int minutes);
        Token FacebookLogin(string access_token);
        Token FacebookLogin(string access_token, out HttpStatusCode code);
        Token FacebookLogin(string access_token, out HttpStatusCode code, out string message);
        Token FacebookLogin(string access_token, out string message);
        Task<Client.MojioResponse<Token>> FacebookLoginAsync(string access_token);
        Results<T> Get<T>(out HttpStatusCode code, out string message, int page = 1) where T : new();
        Results<T> Get<T>(out HttpStatusCode code, int page = 1) where T : new();
        Results<T> Get<T>(int page = 1) where T : new();
        T Get<T>(object id) where T : new();
        T Get<T>(object id, out HttpStatusCode code) where T : new();
        T Get<T>(object id, out HttpStatusCode code, out string message) where T : new();
        Task<Client.MojioResponse<Results<T>>> GetAsync<T>(int page = 1) where T : new();
        Task<Client.MojioResponse<T>> GetAsync<T>(object id) where T : new();
        Results<M> GetBy<M, T>(object id, out HttpStatusCode code, out string message, int page = 1, string action = null) where T : new();
        Results<M> GetBy<M, T>(object id, out HttpStatusCode code, int page = 1, string action = null) where T : new();
        Results<M> GetBy<M, T>(object id, int page = 1, string action = null) where T : new();
        Results<M> GetBy<M, T>(T entity, out HttpStatusCode code, out string message, int page = 1) where T : BaseEntity, new();
        Results<M> GetBy<M, T>(T entity, out HttpStatusCode code, int page = 1) where T : BaseEntity, new();
        Results<M> GetBy<M, T>(T entity, int page = 1) where T : BaseEntity, new();
        Task<Client.MojioResponse<Results<M>>> GetByAsync<M, T>(object id, int page = 1, string action = null) where T : new();
        CreditCard GetCreditCard(Guid? userId = null);
        byte[] GetImage(ImageSize size = ImageSize.Small, Guid? userId = null);
        Task<byte[]> GetImageAsync(ImageSize size = ImageSize.Small, Guid? userId = null);
        Address GetShipping(Guid? userId = null);
        void GetSubscriptions();
        bool IsLoggedIn();
        int PageSize { get; set; }
        bool PasswordReset(ResetPassword reset);
        bool PasswordReset(ResetPassword reset, out HttpStatusCode code);
        bool PasswordReset(ResetPassword reset, out HttpStatusCode code, out string message);
        bool PasswordReset(ResetPassword reset, out string message);
        string PushRegistrationId { get; set; }
        ChannelType PushRegistrationType { get; set; }
        User RegisterUser(string username, string email, string password);
        User RegisterUser(string username, string email, string password, out HttpStatusCode code);
        User RegisterUser(string username, string email, string password, out HttpStatusCode code, out string message);
        User RegisterUser(string username, string email, string password, out string message);
        Task<Client.MojioResponse<User>> RegisterUserAsync(string username, string email, string password);
        bool RemoveAdmin<T>(object id, Guid userId);
        bool RemoveAdmin<T>(T entity, Guid userId) where T : BaseEntity;
        bool RemoveViewer<T>(object id, Guid userId);
        bool RemoveViewer<T>(T entity, Guid userId) where T : BaseEntity;
        string Request(string controller, object id = null, string action = null, string key = null);
        bool RequestPasswordReset(string userNameOrEmail, string returnUrl);
        bool RequestPasswordReset(string userNameOrEmail, string returnUrl, out HttpStatusCode code);
        bool RequestPasswordReset(string userNameOrEmail, string returnUrl, out HttpStatusCode code, out string message);
        bool RequestPasswordReset(string userNameOrEmail, string returnUrl, out string message);
        bool SaveCreditCard(CreditCard creditCard, out HttpStatusCode code, out string message, Guid? userId = null);
        bool SaveCreditCard(CreditCard creditCard, out HttpStatusCode code, Guid? userId = null);
        bool SaveCreditCard(CreditCard creditCard, out string message, Guid? userId = null);
        bool SaveCreditCard(CreditCard creditCard, Guid? userId = null);
        bool SaveShipping(Address shipping, Guid? userId = null);
        int SessionTime { get; set; }
        bool SetImage(byte[] data, string mimetype, out HttpStatusCode code, out string message, Guid? userId = null);
        Task<MojioResponse<bool>> SetImageAsync(byte[] data, string mimetype, Guid? userId = null);
        byte[] GetDeviceImage(string id, ImageSize size = ImageSize.Small);
        Task<byte[]> GetDeviceImageAsync(string id, ImageSize size = ImageSize.Small);
        
        bool SetDeviceImage(string id, byte[] data, string mimetype, out HttpStatusCode code, out string message);
        Task<MojioResponse<bool>> SetDeviceImageAsync(string id, byte[] data, string mimetype);

        bool SetUser(string userOrEmail, string password);
        bool SetUser(string userOrEmail, string password, out HttpStatusCode code);
        bool SetUser(string userOrEmail, string password, out HttpStatusCode code, out string message);
        Task<Client.MojioResponse<Token>> SetUserAsync(string userOrEmail, string password);
        void SubscribePush<T>(object id, Events.EventType events);
        void ThrowError(string errorMessage);
        T Update<T>(T entity) where T : BaseEntity, new();
        T Update<T>(T entity, out HttpStatusCode code) where T : BaseEntity, new();
        T Update<T>(T entity, out HttpStatusCode code, out string message) where T : BaseEntity, new();
        Task<Client.MojioResponse<T>> UpdateAsync<T>(T entity) where T : BaseEntity, new();
        Results<App> UserApps(Guid userId, int page = 1);
        Results<Events.Event> UserEvents(Guid userId, int page = 1);
        Results<Device> UserMojios(Guid userId, int page = 1);
        Results<Trip> UserTrips(Guid userId, int page = 1);
        IMojioQueryable<T> Queryable<T>() where T : BaseEntity, new();

        bool ClearSubscriptions(ChannelType channel, String target);
        bool ClearSubscriptions(ChannelType channel, String target, out HttpStatusCode code);
        bool ClearSubscriptions (ChannelType channel, String target, out HttpStatusCode code, out string message);
        Task<MojioResponse> ClearSubscriptionsAsync (ChannelType channel, String target);
    }
}
