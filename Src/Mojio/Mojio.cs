using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Mojio
{
    public class Device : StringEntity, IOwner,IViewers
    {
        /// <summary>
        /// device serial number
        /// </summary>
        [JsonIgnore]
        public string Serial { get { return Id; } set { Id = value; } }

        /// <summary>
        /// device PIN
        /// </summary>
        public int PIN { get; set; }

        /// <summary>
        /// owner id
        /// </summary>
        [Display(Name = "Owner")]
        public Guid? OwnerId { get; set; }      

        /// <summary>
        /// device name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// optional is ignition on?
        /// </summary>
        public bool? IgnitionOn { get; set; }
        
        /// <summary>
        /// most recent GPS event
        /// </summary>
        public Guid? LastGPSEvent { get; set; }

        /// <summary>
        /// current trip id
        /// </summary>
        public Guid? CurrentTrip { get; set; }

        /// <summary>
        /// most recent communication time
        /// </summary>
        public DateTime LastContactTime { get; set; }

        /// <summary>
        /// list of viewer ids
        /// </summary>
        public Guid[] Viewers { get; set; }
    }
}
