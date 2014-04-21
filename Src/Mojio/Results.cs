using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Results
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Results<T>
    {
        /// <summary>
        /// Maximum number of items per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Page number
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Total number of items
        /// </summary>
        [DefaultValue(-1)]
        public int TotalRows { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }

    /// <summary>
    /// Results
    /// </summary>
    public class Results : Results<object>
    {
    }

}
