using Android.App;
using Android.Content;
using Microsoft.AspNet.SignalR.Client;
using Microsoft.AspNet.SignalR.Client.Hubs;
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
        const string SharedPreferencesName = "MojioClientPreferences";
        const string TokenPreferenceName = "TokenID";

        protected Guid TokenId;
        protected bool GcmRegistered;
        protected Context CurrentContext;

        protected string RegistrationId;

        public MojioClient(Context context, Guid appId, Guid secretKey, string Url = Live)
            : this(Url)
        {
            CurrentContext = context;

            var preferences = context.GetSharedPreferences(SharedPreferencesName, FileCreationMode.Private);
            if (preferences.Contains(TokenPreferenceName))
            {
                var token = preferences.GetString(TokenPreferenceName, null);
                TokenId = new Guid(token);
                Begin(appId, secretKey, TokenId);
            }
            else
                Begin(appId, secretKey);

			var edits = preferences.Edit();
			edits.PutString(TokenPreferenceName, Token.Id.ToString());
			edits.Commit ();
        }

		public Subscription SubscribeGcm(string registrationId, Subscription sub)
		{
			HttpStatusCode ignore;
			return SubscribeGcm (registrationId, sub, out ignore);
		}

		public Subscription SubscribeGcm(string registrationId, Subscription sub, out HttpStatusCode code)
		{
			string ignore;
			return SubscribeGcm (registrationId, sub, out code, out ignore);
		}

		public Subscription SubscribeGcm(string registrationId, Subscription sub, out HttpStatusCode code, out string message)
        {
            sub.ChannelType = ChannelType.Android;
            sub.ChannelTarget = registrationId;

            return Subscribe(sub, out code, out message);
        }

		protected Subscription Subscribe(Subscription subscription )
		{
			HttpStatusCode ignore;
			return Subscribe(subscription, out ignore);
		}

		protected Subscription Subscribe(Subscription subscription, out HttpStatusCode code )
		{
			string ignore;
			return Subscribe(subscription, out code, out ignore);
		}

        protected Subscription Subscribe(Subscription subscription, out HttpStatusCode code, out string message )
        {
            if (subscription.ChannelType == ChannelType.SignalR)
                throw new Exception("SignalR should not be subscribed this way");

            subscription.AppId = Token.AppId;
            subscription.OwnerId = Token.UserId;

            return Create(subscription, out code, out message);
        }
    }
}
