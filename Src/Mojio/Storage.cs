using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Storage : GuidEntity
    {
        public override string Type
        {
            get { return "Storage"; }
        }

        /// <summary>
        /// app owner id
        /// </summary>
        public Guid OwnerAppId { get; set; }
        //public Guid? OwnerUserId { get; set; }

        /// <summary>
        /// record creation timestamp
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// most recent record update timestamp
        /// </summary>
        public DateTime LastUpdated { get; set; }

        /// <summary>
        /// controller
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// entity id
        /// </summary>
        public string EntityId { get; set; }

        /// <summary>
        /// key
        /// </summary>
        public string Key { get; set; }

        // TODO: currently we still accept any OBJECT, but ONLY string works.
        /// <summary>
        /// value
        /// </summary>
        public object Value { get; set; }
    }
}
