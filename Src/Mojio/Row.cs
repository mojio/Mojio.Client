using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class Row<T>
    {
        public string Id { get; set; }
        public object Key { get; set; }
        public T Value { get; set; }
    }

    public class Row : Row<object>
    {

    }
}
