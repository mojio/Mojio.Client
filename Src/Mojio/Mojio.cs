using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Mojio
{
    /// <summary>
    /// Device
    /// </summary>
    [Observable]
    public partial class Mojio : GuidEntity, IOwner
    {
        public override EntityType Type
        {
            get { return EntityType.Mojio; }
        }

        /// <summary>
        /// Owner ID
        /// </summary>
        [Display (Name = "Owner")]
        [Observable(typeof(User))]
        [Parent(typeof(User))]
        public Guid? OwnerId { get; set; }

        /// <summary>
        /// Device name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Device IMEI number
        /// </summary>
        public string Imei { get; set; }

        [DefaultSort]
        /// <summary>
        /// Most recent communication time
        /// </summary>
        public DateTime LastContactTime { get; set; }

        /// <summary>
        /// Current vehicle ID
        /// </summary>
        [Observable(typeof(Vehicle))]
        public Guid? VehicleId { get; set; }
    }
}
