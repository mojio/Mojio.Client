using Mojio.Events;
using RestSharp.Portable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            var request = GetRequest (Request (Map [typeof(T)], id, PushController), HttpMethod.Post);
            request.AddBody (events);

            var response = RestClient.Execute (request);

            return;
        }

        public void GetSubscriptions ()
        {

        }
    }
}
