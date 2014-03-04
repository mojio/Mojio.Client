using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public interface IOwner
    {
        /// <summary>
        /// owner id
        /// </summary>
        Guid? OwnerId { get; set; }
    }

    public interface IOwners
    {
        Guid[] Owners { get; set; }
    }
}
