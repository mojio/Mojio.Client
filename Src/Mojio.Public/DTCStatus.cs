using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio.Public
{
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
