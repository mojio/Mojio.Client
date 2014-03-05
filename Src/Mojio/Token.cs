using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Token
    /// </summary>
    public class Token : GuidEntity
    {
        /// <summary>
        /// app id
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public Guid AppId { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        public Guid? UserId { get; set; }

        /// <summary>
        /// expiry timestamp
        /// </summary>
        /// <value>
        /// The valid until.
        /// </value>
        public DateTime ValidUntil { get; set; }
    }
}
