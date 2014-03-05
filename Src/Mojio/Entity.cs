using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BaseEntity
    {
        /// <summary>Gets or sets the revision.</summary>
        /// <value>The revision.</value>
        [JsonProperty(PropertyName = "_rev")]
        public string Revision { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [delete].
        /// </summary>
        /// <value><c>true</c> if [delete]; otherwise, <c>false</c>.</value>
        [JsonProperty(PropertyName = "_deleted")]
        public bool Delete { get; set; }

        /// <summary>Gets the identifier to string.</summary>
        /// <value>The identifier to string.</value>
        [JsonIgnore]
        public abstract string IdToString { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TId">The type of the identifier.</typeparam>
    public abstract class Entity<TId> : BaseEntity
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        [JsonProperty(PropertyName = "_id")]
        public virtual TId Id { get; set; }

        /// <summary>Gets the identifier to string.</summary>
        /// <value>The identifier to string.</value>
        [JsonIgnore]
        public override string IdToString
        {
            get { return Id.ToString(); }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class GuidEntity : Entity<Guid>
    {
        /// <summary>Ensures the identifier.</summary>
        public void EnsureId()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class StringEntity : Entity<string>
    {

    }
}
