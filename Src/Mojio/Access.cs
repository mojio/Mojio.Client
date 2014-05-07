using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Access : GuidEntity
    {
        public static Guid Everyone = Guid.Empty;

        public Access()
        {
            UserId = Everyone;
        }

        public Guid UserId { get; set; }

        public Permissions Permissions { get; set; }

        public string EntityType { get; set; }

        public Guid EntityId { get; set; }
    }
}
