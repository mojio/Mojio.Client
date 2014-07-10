using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public class Address
    {
        /// <summary>
        /// address line 1
        /// </summary>
        public string Address1 { get; set; }

        /// <summary>
        ///  address line 2
        /// </summary>
        public string Address2 { get; set; }

        /// <summary>
        /// city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// state or province
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// zip or postal code
        /// </summary>
        public string Zip { get; set; }

        /// <summary>
        /// country
        /// </summary>
        public string Country { get; set; }
    }
}
