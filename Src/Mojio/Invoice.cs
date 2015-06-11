using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Invoice
    /// </summary>
    public class Invoice : GuidEntity , IOwner
    {
        public enum PaymentStatuses
        {
            Processing,
            Failed,
            Success
        }
        public override EntityType Type
        {
            get { return EntityType.Invoice; }
        }

        /// <summary>
        /// buyer id
        /// </summary>
        [Parent(typeof(User))]
        public Guid? OwnerId { get; set; }


        public Guid BuyerId { set { OwnerId = value; } }

        /// <summary>
        /// app id
        /// </summary>
        public Guid? AppId { get; set; }

        [DefaultSort]
        public DateTime Date { get; set; }

        public string Details { get; set; }

        /// <summary>
        /// currency
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// grand total
        /// </summary>
        public double? Total { get; set; }

        /// <summary>
        /// shipping address
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// stripe id
        /// </summary>
        public string TransactionId { get; set; }

        public string StatusMessage { get; set; }

        public PaymentStatuses Status { get; set; } 
    }
}
