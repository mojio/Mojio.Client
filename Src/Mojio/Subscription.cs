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

    public enum NotifyType
    {
        Apple,
        Android,
        Windows,
        Post,
        SignalR
    }

    public partial class Subscription : GuidEntity, IOwner
    {
        public NotifyType NotifyType { get; set; }
        public string Notify { get; set; }

        public Guid AppId { get; set; }
        public Guid? OwnerId { get; set; }

        public EventType Event { get; set; }

        public SubscriptionType EntityType { get; set; }
        public object EntityId { get; set; }
    }
}