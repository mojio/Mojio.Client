using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public interface IViewers
    {
        /// <summary>
        /// list of viewers
        /// </summary>
        Guid[] Viewers { get; set; }
    }
}
