using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Product : GuidEntity,IOwner
    {
        static public Guid MojioProductId = new Guid("15840D74-C48D-4F02-B60D-9D4C0C405B88");
        static public Guid MojioSDKId = new Guid("B8621675-4499-45AE-8FA6-AF0F0A6B9A55");

        public Guid AppId { get; set; }
        public string Name { get; set; }        
        public string Description { get; set; }
        
        public bool? Shipping { get; set; }
        public bool? Taxable { get; set; }
        
        public float Price { get; set; }
        public bool Discontinued { get; set; }

        public Guid? OwnerId { get;set; }

        public DateTime CreationDate { get; set; }
    }
}
