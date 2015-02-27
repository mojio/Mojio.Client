using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class Group : GuidEntity
    {
        public override EntityType Type { get { return EntityType.Group;  } }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<Guid> Users { get; set; }
    }
}
