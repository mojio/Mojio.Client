using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Storage : GuidEntity
    {
        public Guid OwnerAppId { get; set; }
        //public Guid? OwnerUserId { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastUpdated { get; set; }

        public string Controller { get; set; }
        public string EntityId { get; set; }

        public string Key { get; set; }

        // TODO: currently we still accept any OBJECT, but ONLY string works.
        public object Value { get; set; }
    }
}
