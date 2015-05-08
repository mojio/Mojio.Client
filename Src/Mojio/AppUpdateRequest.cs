using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class AppUpdateRequest : IAppUpdateRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<string> RedirectUris { get; set; }
    }
}
