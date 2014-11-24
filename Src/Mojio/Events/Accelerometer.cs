using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mojio;

namespace Mojio.Events
{
    public class Accelerometer
    {
        public double? X { get; set; }

        public double? Y { get; set; }

        public double? Z { get; set; }

        public double? Magnitude
        {
            get
            {
                if(X.HasValue && Y.HasValue && Z.HasValue)
                {
                    return Math.Sqrt(
                        Math.Pow(X.Value, 2) +
                        Math.Pow(Y.Value, 2) +
                        Math.Pow(Z.Value, 2)
                    );
                }

                return null;
            }
        }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
