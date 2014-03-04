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


    public class DTCStatus
    {
        /// <summary>
        /// Time of when diagnostics were updated.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// String array of active DTC's.  
        /// </summary>
        public string[] Codes { get; set; }
    }
}
