using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Storage
    /// </summary>
    public class Storage : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.Storage; }
        }

        /// <summary>
        /// app owner id
        /// </summary>
        /// <value>
        /// The owner application identifier.
        /// </value>
        public Guid OwnerAppId { get; set; }
        //public Guid? OwnerUserId { get; set; }

        /// <summary>
        /// record creation timestamp
        /// </summary>
        /// <value>
        /// The creation date.
        /// </value>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// most recent record update timestamp
        /// </summary>
        /// <value>
        /// The last updated.
        /// </value>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// controller
        /// </summary>
        /// <value>
        /// The controller.
        /// </value>
        public string Controller { get; set; }

        /// <summary>
        /// entity id
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public string EntityId { get; set; }

        /// <summary>
        /// key
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public string Key { get; set; }

        /// <summary>
        /// value
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public string Value { get; set; }
    }
}
