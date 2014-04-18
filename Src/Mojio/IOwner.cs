using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOwner
    {
        /// <summary>
        /// Owner ID
        /// </summary>
        Guid? OwnerId { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public interface IOwners
    {
        /// <summary>Gets or sets the owners.</summary>
        /// <value>The owners.</value>
        Guid[] Owners { get; set; }
    }
}
