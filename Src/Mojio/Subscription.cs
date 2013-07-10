using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public enum SubscriptionType
    {
        Mojio = 1,
        Trip,
        User,
    }

    public enum PushType
    {
        Apple,
        Android,
        Windows
    }

    public class PushSubscription : GuidEntity
    {
        public override string Type
        {
            get { return "Push"; }
        }

        public PushType DeviceType { get; set; }

        public string DeviceId { get; set; }

        public EventType[] Events { get; set; }

        public SubscriptionType SubscriptionType { get; set; }

        public object SubscriptionId { get; set; }
    }
}
