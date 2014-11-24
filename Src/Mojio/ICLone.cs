using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public interface ICLone
    {
        object Clone();
        //Object DeepClone(int recursionLevels);
    }
}
