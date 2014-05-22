using System;
using System.Security.Claims;

namespace Mojio
{
    /// <summary>
    /// Token
    /// </summary>
    public class Token : GuidEntity
    {
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

        public Scope Scopes { get; set; }
    }

    [Flags]
    public enum Scope { 
        basic = 0,
        user = 1 << 0
    }

    public static class ScopeExtensions {
        public static string ClaimType = "urn:oauth:scope";

        public static Scope AddClaim(this Scope scope, Claim input) {
            if (input.Type == ClaimType)
            {
                return scope | (Scope)Enum.Parse(typeof(Scope), input.Value);
            }
            else {
                return scope;
            }
        }
    }
}
