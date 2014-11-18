using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public abstract partial class SmoothObserverBase : Observer
    {
        public double InterpolationRate { get; set; } // in seconds

        public static double MaximumTimeForInterpolation = 5.0 * 60.0;  // in seconds, five minutes
 
        public SmoothObserverBase(ObserverType type, double interpolationRate=1.0)
            : base(type)
        {
            InterpolationRate = interpolationRate;
        }

        public SmoothObserverBase(ObserverType type, Type subject = null, 
            Type parent = null, double interpolationRate=1.0)
            : base(type, subject, parent)
        {
            InterpolationRate = interpolationRate;
        }

    }
}
