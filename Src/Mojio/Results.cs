using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Results<T>
    {
        public int PageSize { get; set; }
        public int Offset { get; set; }
        public int TotalRows { get; set; }
        public IEnumerable<T> Data { get; set; }
    }

    public class Results : Results<object>
    {
    }

}
