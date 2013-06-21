using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class UserCounter : StringEntity
    {
        public override string Type
        {
            get
            {
                return null;
            }
        }


        // TODO: MIGRATION Moved to Counter - generic implementation for sequences
        public static string EntityId { get { return "userCountEntity"; } }
        public override string Id { get { return EntityId; } set { } }        
        public int Counter { get; set; }
    }
}
