using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        Read = 1 << 0,
        Write = 1 << 1,
        Share = 1 << 2,
        Owner = ~None,
    }

    public class AccessRule : GuidEntity
    {
        /// <summary>
        /// Type of entity. This is only really needed for double checking?
        /// </summary>
        public Guid Group { get; set; }

        public IEnumerable<string> Permissions { get; set; }

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
