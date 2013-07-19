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
        static Dictionary<SubscriptionType, string> PushTypeMap = new Dictionary<SubscriptionType, string>()
        {
            { SubscriptionType.Mojio , "Mojios" },
            { SubscriptionType.User, "Users" },
            { SubscriptionType.Trip, "Trips" }
        };

        const string PushController = "notify";
        public string PushRegistrationId { get; set; }
        public NotifyType PushRegistrationType { get; set; }


        public void SubscribePush<T>(object id, EventType events )
        {
            var request = GetRequest(Request(Map[typeof(T)], id, "notify"), Method.POST);

            request.AddBody(events);

            var response = RestClient.Execute(request);

            return;
        }

        public void GetSubscriptions()
        {

        }
    }
}
