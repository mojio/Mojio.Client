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

    interface IReferenceCounter
    {
        void IncrementCount ();

        void DecrementCount ();
    }

    public partial class Subscription : IReferenceCounter
    {
        private int _counter = 0;

        public int Counter { 
            get { return _counter; } 
            set {
                _counter = value;
                if (_counter < 0)
                    _counter = 0;
            }
        }

        public void IncrementCount ()
        {
            Counter += 1;
        }

        public void DecrementCount ()
        {
            Counter -= 1;
        }
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

        public int Interval { get; set; }

        public DateTime? LastMessage { get; set; }
    }

    public partial class HardSubscription : Subscription
    {
        public float MaxForce { get; set; }
    }

    public partial class SpeedSubscription : Subscription
    {
        public SpeedSubscription ()
        {
            // Set default interval
            Interval = 60;
        }

        public float MaxSpeed { get; set; }
    }
}