using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Flags]
    public enum Permissions {
        None = 0,
        View = 1 << 0,
        Share = 1 << 1,
        Delete = 1 << 2,
        Modify = 1 << 3
    }

    public class AccessRole : GuidEntity
    {
        public static Guid DefaultRolesAppId = Guid.Empty;

        public AccessRole()
        {
            AppId = DefaultRolesAppId;
        }

        public string Name { get; set; }

        public Guid AppId { get; set; }

        public Permissions Permissions { get; set; }
    }
}
