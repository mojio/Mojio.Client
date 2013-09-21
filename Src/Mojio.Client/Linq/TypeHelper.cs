using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.Linq
{
    public static class InHelper
    {
        /// <summary>
        /// Determines whether a specified value is contained in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="source">A sequence in which to locate the values.</param>
        /// <returns>True if the value is contained in the sequence.</returns>
        public static bool In<TSource>(this TSource value, TSource[] source)
        {
            return source.Contains(value);
        }

        /// <summary>
        /// Determines whether a specified value is contained in a sequence.
        /// </summary>
        /// <typeparam name="TSource">The type of the elements of source.</typeparam>
        /// <param name="value">The value to locate in the sequence.</param>
        /// <param name="source">A sequence in which to locate the values.</param>
        /// <returns>True if the value is contained in the sequence.</returns>
        public static bool In<TSource>(this TSource value, IEnumerable<TSource> source)
        {
            return source.Contains(value);
        }
    }
    internal static class TypeHelper
    {
        internal static Type GetElementType(Type seqType)
        {
            Type ienum = FindIEnumerable(seqType);
            if (ienum == null) return seqType;
            return ienum.GetGenericArguments()[0];
        }

        private static Type FindIEnumerable(Type seqType)
        {
            if (seqType == null || seqType == typeof(string))
                return null;
            if (seqType.IsArray)
                return typeof(IEnumerable<>).MakeGenericType(seqType.GetElementType());
            if (seqType.IsGenericType)
            {
                foreach (Type arg in seqType.GetGenericArguments())
                {
                    Type ienum = typeof(IEnumerable<>).MakeGenericType(arg);
                    if (ienum.IsAssignableFrom(seqType))
                    {
                        return ienum;
                    }
                }
            }
            Type[] ifaces = seqType.GetInterfaces();
            if (ifaces != null && ifaces.Length > 0)
            {
                foreach (Type iface in ifaces)
                {
                    Type ienum = FindIEnumerable(iface);
                    if (ienum != null) return ienum;
                }
            }
            if (seqType.BaseType != null && seqType.BaseType != typeof(object))
            {
                return FindIEnumerable(seqType.BaseType);
            }
            return null;
        }
    }
}
