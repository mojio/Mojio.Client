using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mojio
{
    /** DEPRECATED??
    /// <summary>
    /// Service Type
    /// </summary>
    public enum ServiceType : int
    {
        /// <summary>The SMS</summary>
        SMS,
        /// <summary>The UDP</summary>
        UDP,
        /// <summary>The TCP</summary>
        TCP
    }
    /// <summary>
    /// Service
    /// </summary>
    public class Service : GuidEntity
    {
        /// <summary>Gets or sets the time stamp.</summary>
        /// <value>The time stamp.</value>
        public DateTime TimeStamp { get; set; }
        
        /// <summary>Gets or sets the data.</summary>
        /// <value>The data.</value>
        public byte[] Data { get; set; }
        
        /// <summary>Gets or sets the retries.</summary>
        /// <value>The retries.</value>
        public int Retries { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [processing].
        /// </summary>
        /// <value><c>true</c> if [processing]; otherwise, <c>false</c>.</value>
        public bool Processing { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [done].
        /// </summary>
        /// <value><c>true</c> if [done]; otherwise, <c>false</c>.</value>
        public bool Done { get; set; }
        
        /// <summary>Gets or sets the mojio identifier.</summary>
        /// <value>The mojio identifier.</value>
        public string MojioId { get; set; }
        
        /// <summary>
        /// Gets or sets a value indicating whether [confirmation required].
        /// </summary>
        /// <value><c>true</c> if [confirmation required]; otherwise, <c>false</c>.</value>
        public bool ConfirmationRequired { get; set; }
        
        /// <summary>Gets or sets the status message.</summary>
        /// <value>The status message.</value>
        public string StatusMessage { get; set; }
    }
     * **/
}