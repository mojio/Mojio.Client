using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    /// <summary>
    /// Row
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Row<T>
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// key
        /// </summary>
        public object Key { get; set; }

        /// <summary>
        /// value
        /// </summary>
        public T Value { get; set; }
    }

    /// <summary>
    /// Row
    /// </summary>
    public class Row : Row<object>
    {

    }
}
