using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Mojio;
using Mojio.Events;

namespace Mojio.Client
{
    public partial class MojioClient
    {

        public string RegistrationId { get; set; }

        public void RegisterPush(SubscriptionType subscribe, string id, EventType types)
        {
        }
    }
}