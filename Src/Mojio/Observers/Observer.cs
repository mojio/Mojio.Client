using Mojio.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Flags]
    public enum Transport
    {
        Unspecified     =   0,
        SignalR         =   1 << 0,
        Pubnub          =   1 << 1,
        ApplePush       =   1 << 2,
        AndroidPush     =   1 << 3,
        HttpPost        =   1 << 4   
    }

    public enum ObserveStatus
    {
        Pending         = 0,
        Denied          = 1,
        Approved        = 2
    }


    [JsonConverter(typeof(DiscriminatorConverter<Observer>))]   
    public partial class Observer : GuidEntity, IOwner
    {
        public override EntityType Type
        {
            get { return EntityType.Observer; }
        }

        public string Name { get; set; }
        
        public ObserverType ObserverType { get; set; }

        /// <summary>
        /// The AppId is required. This specifies which app created the Observer 
        /// </summary>
        public Guid AppId { get; set; }

        /// <summary>
        /// If unspecified, events for the logged in user will go to the app unless the App has SystemObserver access
        /// If specified, restricts messages for entities belonging to this user
        /// If the user is different than the entity owner than the Status has to be Approved
        /// </summary>
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// The Parent Type to observe on
        /// </summary>
        public string Parent { get; set; }

        /// <summary>
        /// The specific Parent entity observe on
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// The Subject Entity type to observe
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// The specfic Subject entity to observe
        /// </summary>
        public Guid? SubjectId { get; set; }
        public Transport Transports { get; set; }
        public ObserveStatus? Status { get; set; }
 
        public List<ObserverToken> Tokens { get; set; }

        /// <summary>
        /// Time Window.  Used with BroadcastOnlyRecent flag to determine how far back changes based on vehicle time
        /// are broadcast forward to the outside world.  Default is 15 minutes.
        /// </summary>
        public TimeSpan? TimeWindow { get; set; }

        /// <summary>
        /// BroadcastOnlyRecent when the time window is set. Used with TimeWindow time span to determine if changes are broadcast if that change is based
        /// on something that happened in the vehicle a long time ago and is only recently being updated.
        /// </summary>
        public bool? BroadcastOnlyRecent { get; set; } 

        public Observer()
            : this(ObserverType.Generic)
        {
           // ObserverType = ObserverType.Generic;
        }

        public Observer(Type subject = null, Type parent = null)
            : this(ObserverType.Generic, subject, parent) { }

        public Observer(ObserverType type, Type subject = null, Type parent = null)
        {
            ObserverType = type;

            if (subject != null)
                Subject = subject.Name;

            if (parent != null)
                Parent = parent.Name;
            
            TimeWindow = new TimeSpan(0, 15, 0); // 15 minutes.
            BroadcastOnlyRecent = true;
        }
    }
}
