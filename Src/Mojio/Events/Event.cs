using Mojio.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    [JsonConverter(typeof(EventConverter))]
    public class Event : GuidEntity, IOwner
    {
        // TODO: MIGRATION remove TypeName and Type
        public static string TypeName = "Event";
        public override string Type
        {
            get
            {
                return TypeName;
            }
        }
        
        public string MojioId { get; set; }
        public Guid? OwnerId { get; set; }

        public EventType EventType { get; set; }
        public DateTime Time { get; set; }

        public void EnsureId()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }
    }
}
