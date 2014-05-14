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
    public class DTC : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.DTC; }
        }

        /// <summary>
        /// Sets DTC description to unknown string value.
        /// </summary>
        public void SetToUnknown()
        {
            this.Description = "Unknown DTC";
        }

        /// <summary>Gets or sets the code.</summary>
        /// <value>The code.</value>
        public string Code { get; set; }
        
        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        public string Description { get; set; }
        
        /// <summary>Gets or sets the source.</summary>
        /// <value>The source.</value>
        public string Source { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
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
