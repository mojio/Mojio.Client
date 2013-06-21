using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public interface IOwner
    {
        Guid? OwnerId { get; set; }
    }

    public interface IOwners
    {
        Guid[] Owners { get; set; }
    }
}
