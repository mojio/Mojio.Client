using Mojio.Converters;
using Mojio.Events;
using Newtonsoft.Json;
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

    [JsonConverter(typeof(SubscriptionConverter))]
    public partial class Subscription : GuidEntity, IOwner
    {
        public Subscription() {
        }

        public Subscription(EventType type)
        {
            Event = type;
        }

        public ChannelType ChannelType { get; set; }
        public string ChannelTarget { get; set; }

        public Guid AppId { get; set; }
        public Guid? OwnerId { get; set; }

        public EventType Event { get; set; }

        public SubscriptionType EntityType { get; set; }
        public string EntityId { get; set; }

        public int Interval { get; set; }
        public DateTime? LastMessage { get; set; }
    }

    [CollectionNameAttribute(typeof(Subscription))]
    public partial class HardSubscription : Subscription
    {
        public HardSubscription() {
        }

        public HardSubscription(EventType type, float maxForce = 1f) : base(type)
        {
            MaxForce = maxForce;
        }

        public float MaxForce { get; set; }
    }

    [CollectionNameAttribute(typeof(Subscription))]
    public partial class SpeedSubscription : Subscription
    {
        public SpeedSubscription() {
        }

        public SpeedSubscription(float maxSpeed = 65f, int interval = 60) : base(EventType.Speed)
        {
            MaxSpeed = maxSpeed;
            Interval = 60;
        }

        public float MaxSpeed { get; set; }
    }
}