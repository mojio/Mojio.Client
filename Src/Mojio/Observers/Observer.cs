using Mojio.Converters;
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
        SignalR         =   1 << 0,
        Pubnub          =   1 << 1,
        ApplePush       =   1 << 2,
        AndroidPush     =   1 << 3,
        HttpPost        =   1 << 4   
    }

    public enum ObserveStatus
    {
        Pending,
        Denied,
        Approved
    }

    [JsonConverter(typeof(ObserverConverter))]
    public partial class Observer : GuidEntity, IOwner
    {
        public string Name { get; set; }
        
        public ObserverType Type { get; set; }

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
        public Transport Transport { get; set; }
        public ObserveStatus? Status { get; set; }

        public List<ObserverToken> Tokens { get; set; }

        public Observer()
            : this(ObserverType.Generic) { }

        public Observer(ObserverType type)
        {
            Type = type;
        }
    }
}
