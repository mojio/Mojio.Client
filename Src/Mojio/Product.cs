using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : GuidEntity,IOwner
    {
        public override EntityType Type
        {
            get { return EntityType.Product; }
        }

        /// <summary>
        /// The mojio product identifier
        /// </summary>
        static public Guid MojioProductId = new Guid("15840D74-C48D-4F02-B60D-9D4C0C405B88");
        
        /// <summary>
        /// The mojio SDK identifier
        /// </summary>
        static public Guid MojioSDKId = new Guid("B8621675-4499-45AE-8FA6-AF0F0A6B9A55");

        /// <summary>
        /// app id
        /// </summary>
        public Guid AppId { get; set; }

        /// <summary>
        /// name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// shippable?
        /// </summary>
        public bool? Shipping { get; set; }

        /// <summary>
        /// taxable?
        /// </summary>
        public bool? Taxable { get; set; }
        
        /// <summary>
        /// price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// discontinued?
        /// </summary>
        public bool Discontinued { get; set; }

        /// <summary>
        /// owner id
        /// </summary>
        public Guid? OwnerId { get;set; }

        [DefaultSort]
        /// <summary>
        /// record creation timestamp
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
