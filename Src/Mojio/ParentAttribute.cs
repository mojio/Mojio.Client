using System;
using System.Collections.Generic;
using System.Linq;

namespace Mojio
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParentAttribute : Attribute
    {
        public Type ParentType { get; set; }

        public ParentAttribute()
        {

        }
        public ParentAttribute(Type type)
        {
            ParentType = type;
        }
    }
}