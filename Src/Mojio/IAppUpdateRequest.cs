using System;
using System.Collections.Generic;
namespace Mojio
{
    public interface IAppUpdateRequest
    {
        string Description { get; set; }
        string Name { get; set; }
        IEnumerable<string> RedirectUris { get; set; }
    }
}
