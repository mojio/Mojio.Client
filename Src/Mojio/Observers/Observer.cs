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
    public partial class Observer : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.Observer; }
        }

        public string Name { get; set; }
        
        public ObserverType ObserverType { get; set; }

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

        public Observer()
            : this(ObserverType.Generic) { }

        public Observer(Type subject = null, Type parent = null)
            : this(ObserverType.Generic, subject, parent) { }


        public Observer(ObserverType type, Type subject = null, Type parent = null)
        {
            ObserverType = type;

            if (subject != null)
                Subject = subject.Name;

            if (parent != null)
                Parent = parent.Name;
        }
    }
}
