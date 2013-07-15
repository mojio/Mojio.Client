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
        [JsonIgnore]
        public string Serial { get { return Id; } set { Id = value; } }

        public int PIN { get; set; }

        [Display(Name = "Owner")]
        public Guid? OwnerId { get; set; }      

        public string Name { get; set; }

        public bool? IgnitionOn { get; set; }
        
        public Guid? LastGPSEvent { get; set; }
        public Guid? CurrentTrip { get; set; }

        public DateTime LastContactTime { get; set; }

        public Guid[] Viewers { get; set; }
    }
}
