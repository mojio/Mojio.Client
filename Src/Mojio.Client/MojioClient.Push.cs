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
        const string PushController = "notify";

        public string PushRegistrationId { get; set; }

        public ChannelType PushRegistrationType { get; set; }

        public void SubscribePush<T> (Guid id, EventType events)
        {
            var request = GetRequest (Request (Map [typeof(T)], id, PushController), Method.POST);

            request.AddBody (events);

            var response = RestClient.ExecuteAsync (request);

            return;
        }

        public void GetSubscriptions ()
        {

        }
    }
}
