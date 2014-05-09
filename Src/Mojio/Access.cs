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
        View = 1 << 0,
        Share = 1 << 1,
        Delete = 1 << 2,
        Modify = 1 << 3,
        Inherit = 1 << 4,

        // Common permission combinations
        Editor = Permissions.View | Permissions.Modify,
        Author = Permissions.View | Permissions.Modify | Permissions.Delete,
        Sharer = Permissions.View | Permissions.Share,
        Owner = Permissions.View | Permissions.Share | Permissions.Delete | Permissions.Modify | Permissions.Inherit,

        Wrecker = Permissions.Delete | Permissions.Inherit,
    }

    public class Access : GuidEntity
    {
        public static Guid Everyone = Guid.Empty;

        public Access()
        {
            GroupId = Everyone;
        }

        public Guid GroupId { get; set; }

        public Permissions Permissions { get; set; }

        public string EntityType { get; set; }

        public Guid EntityId { get; set; }
    }
}
