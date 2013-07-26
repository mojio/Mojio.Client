using Mojio.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    /// <summary>
    /// event
    /// </summary>
    [JsonConverter(typeof(EventConverter))]
    public class Event : GuidEntity, IOwner
    {
        /// <summary>
        /// mojio Id
        /// </summary>
        public string MojioId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        public EventType EventType { get; set; }

        /// <summary>
        /// event timestamp
        /// </summary>
        public DateTime Time { get; set; }

        public void EnsureId()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }
    }
}
