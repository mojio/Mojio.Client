using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Linq;

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

        /// <summary>
        /// An enum of scope (permission) flags.
        /// </summary>
        public Scope Scopes { get; set; }
    }

    [Flags]
    public enum Scope { 
        basic = 0,
        full = 1 << 0
    }

    public static class ScopeExtensions {
        public static Dictionary<Scope, string> Descriptions = new Dictionary<Scope, string>() { 
            {Scope.basic, "Basic information about your Mojio account."},
            {Scope.full, "Full access to your Mojio account."}
        };

        public static Dictionary<Scope, string> Names = new Dictionary<Scope, string>() { 
            {Scope.basic, "Basic"},
            {Scope.full, "Full"}
        };

        public static string ClaimType = "urn:oauth:scope";

        /// <summary>
        /// Converts input claim into scopes, if applicable.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Scope AddClaim(this Scope scope, Claim input) {
            if (input.Type == ClaimType)
            {
                return scope.AddScope(input.Value);
            }
            else {
                return scope;
            }
        }

        /// <summary>
        /// Splits out flags into individual scopes (useful for display purposes).
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static IEnumerable<Scope> ToScopes(this Scope scope) {
            return from s in (Scope[])Enum.GetValues(typeof(Scope))
                   where scope.HasFlag(s)
                   select s;
        }

        /// <summary>
        /// Splits out flags into claims.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static IEnumerable<Claim> ToClaims(this Scope scope) {
            return scope.ToScopes().Select(s => new Claim(ClaimType, s.ToName()));
        }

        /// <summary>
        /// Splits out flags into names.
        /// </summary>
        /// <param name="scope"></param>
        /// <returns></returns>
        public static IEnumerable<string> ToNames(this Scope scope) {
            return scope.ToScopes().Select(s => Enum.GetName(typeof(Scope), s));
        }

        public static string ToName(this Scope scope) {
            return scope.ToNames().FirstOrDefault();
        }

        /// <summary>
        /// Converts the input into a scope flag, the or's them together.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Scope AddScope(this Scope scope, Scope input) {
            return scope | input;
        }

        /// <summary>
        /// Returns an or'd scope with the parsed input.
        /// </summary>
        /// <param name="scope"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static Scope AddScope(this Scope scope, string input) {
            try
            {
                return scope | (Scope)Enum.Parse(typeof(Scope), input);
            }
            catch(ArgumentException e)
            {
                return scope | default(Scope);
            }
        }
    }
}
