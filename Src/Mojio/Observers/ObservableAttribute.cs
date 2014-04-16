using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class ObservableAttribute : Attribute
    {
        public Type LinkType { get; set; }

        public ObservableAttribute()
        {

        }
        public ObservableAttribute(Type linkType)
        {
            LinkType = linkType;
        }
    }
}
