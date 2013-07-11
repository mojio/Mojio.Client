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
        static Dictionary<Type, SubscriptionType> PushTypeMap = new Dictionary<SubscriptionType, string>()
        {
            { SubscriptionType.Mojio , "Mojios" },
            { SubscriptionType.User },
            { SubscriptionType.Trip }
        };

        const string PushController = "notify";
        public string PushRegistrationId { get; set; }
        public PushType PushRegistrationType { get; set; }


        public void SubscribePush<T>(object id, EventType events )
        {
            var request = GetRequest(Request(Map[typeof(T)], id, "notify"), Method.POST);

            request.AddBody(entity);

            var response = RestClient.Execute<T>(request);
            return response.Data;
        }

        public void GetSubscriptions()
        {

        }
    }
}
