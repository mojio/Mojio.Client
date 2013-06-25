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
        // TODO: MIGRATION remove TypeName and Type
        public static string TypeName = "Invoice";
        public override string Type
        {
            get
            {
                return TypeName;
            }
        }

        public Guid BuyerId { get; set; }
        public Guid? AppId { get; set; }

        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }
        public bool? DueOnShip { get; set; }

        public InvoiceDetail[] Items { get; set; }

        public Guid? PromoCode { get; set; }
        public string Currency { get; set; }
        public float? SubTotal { get; set; }
        public float? Tax { get; set; }
        public float? Shipping { get; set; }

        public float? Total
        {
            get
            {
                return SubTotal + Tax + Shipping;
            }
        }

        public Address Address { get; set; }

        // Owing
        public float? Owing { get; set; }
        public string OwingReason { get; set; }
        
        // Status        
        public bool? Shipped { get; set; }
        public bool? Paid { get; set; }
        public string StripeId { get; set; }

        [JsonIgnore]
        public Guid? OwnerId
        {
            get { return BuyerId; }
            set { this.BuyerId = value.Value; }
        }
    }

    public class InvoiceDetail
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }

        public Product Product { get; set; }
    }
}
