using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
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

    public class Row : Row<object>
    {

    }
}
