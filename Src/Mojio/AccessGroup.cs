using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class AccessGroup : GuidEntity
    {
        public string Name { get; set; }

        [Parent(typeof(User))]
        public Guid OwnerId { get; set; }
    }

    public class AccessGroupUser : GuidEntity
    {
        public Guid UserId { get; set; }

        [Parent(typeof(AccessGroup))]
        public Guid GroupId { get; set; }
    }
}
