using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio;

namespace Mojio
{
    public class Access : GuidEntity
    {
        /// <summary>
        /// Type of entity. This is only really needed for double checking?
        /// </summary>
        public IList<UserAccess> Users { get; set; }

        public Permissions Everyone { get; set; }

        public override EntityType Type
        {
            get { return global::Mojio.EntityType.Access; }
        }
    }

    public class UserAccess
    {
        public Guid UserId { get; set; }

        public Permissions Permissions { get; set; }
    }
}
