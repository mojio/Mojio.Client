using Mojio.Converters;
using Mojio.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.Configuration;
using System.Globalization;

//REL figure out how to do this on the mobile app side: using System.Configuration;
namespace Mojio
{
    /// <summary>
    /// Channel Type
    /// </summary>
    public enum ChannelType
    {
        /// <summary>The apple</summary>
        Apple,
        /// <summary>The android</summary>
        Android,
        /// <summary>The windows</summary>
        Windows,
        /// <summary>The post</summary>
        Post,
        /// <summary>The signal r</summary>
        SignalR
    }

    /// <summary>
    /// Subscription
    /// </summary>
    [JsonConverter (typeof(SubscriptionConverter))]
    public partial class Subscription : GuidEntity, IOwner
    {
        public override global::Mojio.EntityType Type {
            get { return global::Mojio.EntityType.Subscription; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        public Subscription ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscription"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public Subscription (EventType type)
        {
            Event = type;
        }

        /// <summary>Gets or sets the type of the channel.</summary>
        /// <value>The type of the channel.</value>
        public ChannelType ChannelType { get; set; }

        /// <summary>Gets or sets the channel target.</summary>
        /// <value>The channel target.</value>
        public string ChannelTarget { get; set; }

        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        public Guid AppId { get; set; }

        /// <summary>owner id</summary>
        public Guid? OwnerId { get; set; }

        /// <summary>Gets or sets the event.</summary>
        /// <value>The event.</value>
        public EventType Event { get; set; }

        /// <summary>Gets or sets the type of the entity.</summary>
        /// <value>The type of the entity.</value>
        public EntityType EntityType { get; set; }
        // TODO convert this to Guid?
        /// <summary>Gets or sets the entity identifier.</summary>
        /// <value>The entity identifier.</value>
        public Guid EntityId { get; set; }

        /// <summary>Gets or sets the interval.</summary>
        /// <value>The interval.</value>
        public int Interval { get; set; }

        /// <summary>Gets or sets the last message.</summary>
        /// <value>The last message.</value>
        public DateTime? LastMessage { get; set; }
    }

    /// <summary>
    /// Hard Subscription
    /// </summary>
    [CollectionNameAttribute (typeof(Subscription))]
    public partial class HardSubscription : Subscription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HardSubscription"/> class.
        /// </summary>
        public HardSubscription ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HardSubscription"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="maxForce">The maximum force.</param>
        public HardSubscription (EventType type, double maxForce = 1.0) : base (type)
        {
            MaxForce = maxForce;
        }

        /// <summary>Gets or sets the maximum force.</summary>
        /// <value>The maximum force.</value>
        public double MaxForce { get; set; }
    }

    /// <summary>
    /// Speed Subscription
    /// </summary>
    [CollectionNameAttribute (typeof(Subscription))]
    public partial class SpeedSubscription : Subscription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedSubscription"/> class.
        /// </summary>
        public SpeedSubscription ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpeedSubscription"/> class.
        /// </summary>
        /// <param name="maxSpeed">The maximum speed.</param>
        /// <param name="interval">The interval.</param>
        public SpeedSubscription (double maxSpeed = 65.0, int interval = 60) : base (EventType.Speed)
        {
            MaxSpeed = maxSpeed;
            Interval = interval;
        }

        /// <summary>Gets or sets the maximum speed.</summary>
        /// <value>The maximum speed.</value>
        public double MaxSpeed { get; set; }
    }

    /// <summary>
    /// Low Fuel Subscription
    /// </summary>
    [CollectionNameAttribute (typeof(Subscription))]
    public partial class LowFuelSubscription : Subscription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FuelSubscription"/> class.
        /// </summary>
        public LowFuelSubscription ()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FuelSubscription"/> class.
        /// </summary>
        /// <param name="fuelThreshold">The low fuel threshold as a percentage.</param>
        /// <param name="interval">The interval.</param>
        public LowFuelSubscription (double fuelThreshold = 0, 
                                    int interval = 60)
            : base (EventType.LowFuel)
        {
            // rel Fuel Threshold Default  TODO:: one place to define low fuel for the API.
            if (fuelThreshold == 0)
                fuelThreshold = 15; //double.Parse(ConfigurationSettings.AppSettings["LowFuelThreshold"], CultureInfo.InvariantCulture);
            LowFuelPercentageThreshold = fuelThreshold;
            Interval = interval;
        }

        /// <summary>Gets or sets the low fuel threshold percentage.</summary>
        /// <value>The low fuel threshold as a percentage 0..100.</value>
        public double LowFuelPercentageThreshold { get; set; }
    }
}