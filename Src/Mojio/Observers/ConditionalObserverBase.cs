using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public abstract partial class ConditionalObserverBase : Observer
    {
        public ConditionalObserverBase(ObserverType type)
            : base(type)
        {

        }

        public ConditionalObserverBase(ObserverType type, Type subject = null, Type parent = null)
            : base(type, subject, parent)
        {

        }
    }

}
