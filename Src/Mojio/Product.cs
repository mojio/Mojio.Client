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
        /// The Mojio product identifier
        /// </summary>
        static public Guid MojioProductId = new Guid("15840D74-C48D-4F02-B60D-9D4C0C405B88");

        static public Guid MojioCanadaProductId = new Guid("44be2671-0ad6-41ab-bb6c-0f9a4acf764d");
        
        /// <summary>
        /// The Mojio SDK identifier
        /// </summary>
        static public Guid MojioSDKId = new Guid("B8621675-4499-45AE-8FA6-AF0F0A6B9A55");

        /// <summary>
        /// App id
        /// </summary>
        public Guid AppId { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Shippable?
        /// </summary>
        public bool? Shipping { get; set; }

        /// <summary>
        /// Taxable?
        /// </summary>
        public bool? Taxable { get; set; }
        
        /// <summary>
        /// Price
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Discontinued?
        /// </summary>
        public bool Discontinued { get; set; }

        /// <summary>
        /// Owner id
        /// </summary>
        [Obsolete("Use the access record to determine owner")]
        public Guid? OwnerId { get;set; }

        [DefaultSort]
        /// <summary>
        /// Record creation timestamp
        /// </summary>
        public DateTime CreationDate { get; set; }
    }
}
