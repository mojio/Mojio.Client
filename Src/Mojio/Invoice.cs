using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Invoice : GuidEntity , IOwner
    {
        /// <summary>
        /// buyer id
        /// </summary>
        public Guid BuyerId { get; set; }

        /// <summary>
        /// app id
        /// </summary>
        public Guid? AppId { get; set; }

        /// <summary>
        /// invoice timestamp
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// optional due date
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// due on shipment?
        /// </summary>
        public bool? DueOnShip { get; set; }

        /// <summary>
        /// invoice items
        /// </summary>
        public InvoiceDetail[] Items { get; set; }

        /// <summary>
        /// optional promotional code
        /// </summary>
        public Guid? PromoCode { get; set; }

        /// <summary>
        /// currency
        /// </summary>
        public string Currency { get; set; }
        
        /// <summary>
        /// subtotal
        /// </summary>
        public float? SubTotal { get; set; }

        /// <summary>
        /// total tax
        /// </summary>
        public float? Tax { get; set; }

        /// <summary>
        /// total shipping
        /// </summary>
        public float? Shipping { get; set; }

        /// <summary>
        /// grand total
        /// </summary>
        public float? Total
        {
            get
            {
                return SubTotal + Tax + Shipping;
            }
        }

        /// <summary>
        /// shipping address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// amount owed
        /// </summary>
        public float? Owing { get; set; }

        /// <summary>
        /// amount owed description
        /// </summary>
        public string OwingReason { get; set; }
        
        /// <summary>
        /// has shipped?
        /// </summary>
        public bool? Shipped { get; set; }

        /// <summary>
        /// fully paid?
        /// </summary>
        public bool? Paid { get; set; }

        /// <summary>
        /// stripe id
        /// </summary>
        public string StripeId { get; set; }

        /// <summary>
        /// owner di
        /// </summary>
        [JsonIgnore]
        public Guid? OwnerId
        {
            get { return BuyerId; }
            set { this.BuyerId = value.Value; }
        }
    }

    public class InvoiceDetail
    {
        /// <summary>
        /// product id
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// price
        /// </summary>
        public float Price { get; set; }

        /// <summary>
        /// the product
        /// </summary>
        public Product Product { get; set; }
    }
}
