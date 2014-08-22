using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// user roles
    /// </summary>
    [Flags]
    public enum Roles
    {
        /// <summary>
        /// no role
        /// </summary>
        None = 0,

        /// <summary>
        /// admin role
        /// </summary>
        Admin = 1 << 0
    }
}
