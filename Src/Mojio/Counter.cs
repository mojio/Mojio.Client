using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Counter : StringEntity
    {
        // TODO: MIGRATION remove Type
        public override string Type
        {
            get { return null; }
        }

        public int Seq { get; set; }
    }
}