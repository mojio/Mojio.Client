using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class DTC:StringEntity
    {
        /// <summary>
        /// Sets DTC description to unknown string value.
        /// </summary>
        public void SetToUnknown()
        {
            this.Description = "Unknown DTC";
        }

        public string Code
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Description { get; set; }
        public string Source { get; set; }
    }
}
