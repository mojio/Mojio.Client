using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionNameAttribute : Attribute
    {
        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionNameAttribute"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        public CollectionNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionNameAttribute"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CollectionNameAttribute(Type type)
        {
            Name = type.Name;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}