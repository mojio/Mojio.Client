using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// User Counter
    /// </summary>
    public class UserCounter : StringEntity
    {
        // TODO: MIGRATION Moved to Counter - generic implementation for sequences
        
        /// <summary>
        /// Gets the entity identifier.
        /// </summary>
        /// <value>
        /// The entity identifier.
        /// </value>
        public static string EntityId { get { return "userCountEntity"; } }
        
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public override string Id { get { return EntityId; } set { } }
        
        /// <summary>
        /// Gets or sets the counter.
        /// </summary>
        /// <value>
        /// The counter.
        /// </value>
        public int Counter { get; set; }
    }
}
