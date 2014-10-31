using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public enum ObserverTiming {
        always=0,
        low=1,
        high=2,
        edge=3,
        leading=5,
        trailing=6,
    }
    public abstract partial class ConditionalObserverBase : Observer
    {
        /// <summary>
        /// Timing
        /// </summary>
        public ObserverTiming Timing { get; set; }

        public ConditionalObserverBase(ObserverType type, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(type)
        {
            Timing = timing;
        }

        public ConditionalObserverBase(Type subject = null, Type parent = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : this(ObserverType.Generic, subject, parent) 
        {
            Timing = timing;
        }


        public ConditionalObserverBase(ObserverType type, Type subject = null, 
            Type parent = null, ObserverTiming timing = ObserverTiming.edge)
            : base(type, subject, parent)
        {
            Timing = timing;
        }
    }

}
