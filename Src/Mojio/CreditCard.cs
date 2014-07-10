using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// 
    /// </summary>
    public class CreditCard
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id {get;set;}

        /// <summary>
        /// credit card type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// cardholder full name
        /// </summary>
        public string NameOnCard { get; set; }

        /// <summary>
        /// card number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// CVV code
        /// </summary>
        public int CVV { get; set; }

        /// <summary>
        /// expiry month
        /// </summary>
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// expiry year
        /// </summary>
        public int ExpiryYear { get; set; }

        /// <summary>
        /// billing address
        /// </summary>
        public Address Address { get; set; }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class BetaPayment
    {
        /// <summary>Gets or sets the credit card.</summary>
        /// <value>The credit card.</value>
        public CreditCard CreditCard { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [authorize charge].
        /// </summary>
        /// <value><c>true</c> if [authorize charge]; otherwise, <c>false</c>.</value>
        public bool AuthorizeCharge { get; set; }
    }
}
