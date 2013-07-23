using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Results<T>
    {
        /// <summary>
        /// maximum number of items per page
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// page number
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// total number of items
        /// </summary>
        public int TotalRows { get; set; }

        /// <summary>
        /// items
        /// </summary>
        public IEnumerable<T> Data { get; set; }
    }

    public class Results : Results<object>
    {
    }

}
