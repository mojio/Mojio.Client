using Mojio.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Events
{
    public interface IEvent
    {
        /// <summary>
        /// mojio Id
        /// </summary>
        string MojioId { get; set; }

        /// <summary>
        /// owner Id
        /// </summary>
        Guid? OwnerId { get; set; }

        /// <summary>
        /// event type
        /// </summary>
        EventType EventType { get; set; }

        /// <summary>
        /// event timestamp
        /// </summary>
        DateTime Time { get; set; }

        /// <summary>
        /// location
        /// </summary>
        Location Location { get; set; }
    }

    /// <summary>
    /// event
    /// </summary>
    [JsonConverter (typeof(EventConverter))]
    public class Event : GuidEntity, IEvent, IOwner, ICloneable
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

        /// <summary>
        /// location
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// TimeIsApproximate
        /// </summary>
        public bool? TimeIsApprox { get; set; }

        public object Clone ()
        {
            return this.MemberwiseClone ();
        }

        public override string ToString()
        {
            try
            {
                string str = "MojioEvent-> ";

                if (this.Location != null && this.Location.IsValid)
                    return str + string.Format("Type: {0}, Lat {1}, Lng {2}, Time {3}",
                        this.EventType.ToString(),
                        this.Location.Lat,
                        this.Location.Lng,
                        this.Time != null ? this.Time.ToString() : "nodata"
                     );
                else
                    return str + string.Format("Type: {0}, Lat {1}, Lng {2}, Time {3}",
                        this.EventType.ToString(),
                        "nodata",
                        "nodata",
                        this.Time != null ? this.Time.ToString() : "nodata"
                    );
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}
