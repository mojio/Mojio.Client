using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio
{
    [AttributeUsage(AttributeTargets.Class)]
    public class CollectionNameAttribute : Attribute
    {
        public string Name { get; set; }

        public CollectionNameAttribute(string name)
        {
            Name = name;
        }

        public CollectionNameAttribute(Type type)
        {
            Name = type.Name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}