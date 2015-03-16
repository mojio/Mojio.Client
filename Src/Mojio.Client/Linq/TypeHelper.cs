using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Mojio.Client.Linq
{
    internal static class TypeHelper
    {
        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null) return seqType;
            return ienum.GetGenericArguments()[0];
// 4.5 framework:            return ienum.GetTypeInfo().GenericTypeArguments[0];
        }

        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;
            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            if (seqType.IsGenericType)
//4.5 framework:            if (seqType.GetTypeInfo().IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
// 4.5 framework:                foreach (Type arg in seqType.GetTypeInfo().GenericTypeArguments)
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
// 4.5 framework:                        if (ienum.GetTypeInfo().IsAssignableFrom(seqType.GetTypeInfo()))
                    {
                        return ienum;
                    }
                }
            }
            var ifaces = seqType.GetInterfaces();
// 4.5 framework:            var ifaces = seqType.GetTypeInfo().ImplementedInterfaces;
            if (ifaces != null && ifaces.Count() > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null) return ienum;
                }
            }
            if (seqType.BaseType != null && seqType.BaseType != typeof(object))

// 4.5 framework:            if (seqType.GetTypeInfo().BaseType != null && seqType.GetTypeInfo().BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
// 4.5 framework:                return FindIEnumerable(seqType.GetTypeInfo().BaseType);
            }
            return null;
        }
    }
}
