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

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            return this.MemberwiseClone();
        }
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

        public DTC[] DiagnosticCodes { get; set; }

        /// <summary>Creates a new object that is a copy of the current instance.</summary>
        /// <returns>A new object that is a copy of this instance.</returns>
        public object Clone()
        {
            DTCStatus dtcStatus = this.MemberwiseClone() as DTCStatus;
            dtcStatus.DiagnosticCodes = new DTC[this.DiagnosticCodes.Length];
            for (int i=0;i<this.DiagnosticCodes.Length;i++) {
                dtcStatus.DiagnosticCodes[i] = this.DiagnosticCodes[i].Clone() as DTC;
            }
            dtcStatus.Codes = new string[this.Codes.Length];
            for (int i=0;i<this.Codes.Length;i++) {
                dtcStatus.Codes[i] = this.Codes[i];
            }
            return dtcStatus;
        }
    }
}
