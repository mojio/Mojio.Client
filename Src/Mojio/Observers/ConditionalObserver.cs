using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public abstract partial class ConditionalObserver : Observer
    {
        public ConditionalObserver(ObserverType type)
            : base(type)
        {

        }
    }

}
