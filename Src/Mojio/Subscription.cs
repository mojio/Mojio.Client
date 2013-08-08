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

    public enum ChannelType
    {
        Apple,
        Android,
        Windows,
        Post,
        SignalR
    }

    public partial class Subscription : GuidEntity, IOwner
    {
        public ChannelType ChannelType { get; set; }
        public string ChannelTarget { get; set; }

        public Guid AppId { get; set; }
        public Guid? OwnerId { get; set; }

        public EventType Event { get; set; }

        public SubscriptionType EntityType { get; set; }
        public string EntityId { get; set; }
    }

    public partial class HardSubscription : Subscription
    {
        public float MaxForce { get; set; }
    }

    public partial class SpeedSucbscription : Subscription
    {
        public float MaxSpeed { get; set; }
    }
}