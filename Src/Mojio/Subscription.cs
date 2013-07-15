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
        Windows,
        Post,
        SignalR
    }

    public class Notify : GuidEntity, IOwner
    {
        public PushType Type { get; set; }
        public string Receiver { get; set; }

        public Guid AppId { get; set; }
        public Guid? OwnerId { get; set; }

        public EventType[] Events { get; set; }

        public SubscriptionType EntityType { get; set; }
        public object EntityId { get; set; }
    }

    public class NotifyApple : Notify
    {
        public NotifyApple(string id)
        {
            Type = PushType.Apple;
            Receiver = id;
        }

        public string NotificationId {
            get { return Receiver; }
            set { Receiver = value; }
        }
    }
}