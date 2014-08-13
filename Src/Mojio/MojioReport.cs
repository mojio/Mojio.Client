using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    //TODO:: this could be produced by mojio machine as a log of the TCU report.
    class MojioReport : GuidEntity, IOwner
    {
        public override EntityType Type
        {
            get { return EntityType.Mojio; }
        }

        /// <summary>
        /// Owner ID
        /// </summary>
        [Observable(typeof(User))]
        [Parent(typeof(User))]
        [Obsolete("Use the access record to determine owner")]
        public Guid? OwnerId { get; set; }
    }
}
