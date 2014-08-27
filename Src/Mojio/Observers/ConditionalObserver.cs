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

        public ConditionalObserver(ObserverType type, Type subject = null, Type parent = null)
            : base(type, subject, parent)
        {

        }
    }

}
