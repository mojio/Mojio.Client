using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Reflection;
using Mojio.Serialization;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public abstract partial class BaseEntity
    {
        static Type[] Types = typeof(BaseEntity).Assembly.GetExportedTypes();

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

        /// <summary>
        /// Converts a string into a Type
        /// </summary>
        /// <param name="typeName">Case insensitive type in the Mojio assembly</param>
        /// <returns></returns>
        public static Type ToType(string typeName)
        {
            if (string.IsNullOrEmpty(typeName))
                return null;
            return Types.SingleOrDefault(t => t.Name.ToLower() == typeName.ToLower());
        }

        /*
        This lives in Mojio.Private
        public static string ToType(this Type type)
        {
            return type.Name.ToLower();
        }*/
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
    [JsonConverter(typeof(DiscriminatorConverter<GuidEntity>))]   
    public abstract class GuidEntity : Entity<Guid>
    {
        /// <summary>Ensures the identifier.</summary>
        public void EnsureId()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }

        public abstract EntityType Type { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class StringEntity : Entity<string>
    {

    }
}
