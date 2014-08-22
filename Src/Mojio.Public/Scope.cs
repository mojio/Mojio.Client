using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Flags]
    public enum Scope
    {
        Basic = 0,
        Full = 1 << 0
    }
}
