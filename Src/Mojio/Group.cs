using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Group : GuidEntity
    {
        public string Name { get; set; }

        [Parent(typeof(User))]
        public Guid OwnerId { get; set; }

        public Guid[] UserId { get; set; }

        public override EntityType Type
        {
            get { return EntityType.AccessGroup; }
        }
    }
}
