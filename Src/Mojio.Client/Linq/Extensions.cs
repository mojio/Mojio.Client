using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.Linq
{
    public static class Extensions
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

        public static async Task<int> CountAsync<T>(this IQueryable<T> query)
        {
            if(query is IMojioQueryable<T>)
            {
                return await ((IMojioQueryable<T>)query).CountAsync();
            }
            else
            {
                return query.Count();
            }
        }

        public static async Task<T[]> ToArrayAsync<T>(this IQueryable<T> query)
        {
            if (query is IMojioQueryable<T>)
            {
                var result = await ((IMojioQueryable<T>)query).FetchAsync();
                return result.ToArray();
            }
            else
            {
                return query.ToArray();
            }
        }
    }
}
