using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio
{
    /// <summary>
    /// Token
    /// </summary>
    public class Token : GuidEntity
    {
        public Token()
            : base()
        {
            Deprecated = false;
        }
        public override EntityType Type
        {
            get { return EntityType.Token; }
        }

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

        /// <summary>
        /// An enum of scope (permission) flags.
        /// </summary>
        public Scope Scopes { get; set; }

        /// <summary>
        /// Whether this token will attempt to access the sandboxed databases.
        /// </summary>
        public Boolean Sandboxed { get; set; }

        /// <summary>
        /// Whether this token will attempt to access the sandboxed databases.
        /// </summary>
        public Boolean Deprecated { get; set; }
    }

    [Flags]
    public enum Scope { 
        Basic = 0,
        Full = 1 << 0
    }
}
