using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Mojio
{
    public partial class Device : StringEntity, IOwner,IViewers
    {
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
        /// most recent trip event
        /// </summary>
        public Guid? LastTripEvent { get; set; }

        /// <summary>
        /// Last location time
        /// </summary>
        public DateTime? LastLocationTime { get; set; }

        /// <summary>
        /// last known location
        /// </summary>
        public Location LastLocation { get; set; }

        /// <summary>
        /// current trip id
        /// </summary>
        public Guid? CurrentTrip { get; set; }

        /// <summary>
        /// most recent communication time
        /// </summary>
        public DateTime LastContactTime { get; set; }

        // TODO: Maybe Viewers should be in private?
        /// <summary>
        /// list of viewer ids
        /// </summary>
        public Guid[] Viewers { get; set; }
    }
}
