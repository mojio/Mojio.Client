using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class CreditCard
    {
        /// <summary>
        /// id
        /// </summary>
        public string Id {get;set;}

        /// <summary>
        /// credit card type
        /// </summary>
        [Display(Name = "Type")]
        public string Type { get; set; }

        /// <summary>
        /// cardholder full name
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Name on Card")]
        public string NameOnCard { get; set; }

        /// <summary>
        /// card number
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Credit Card")]
        [CreditCard(ErrorMessage="Invalid")]
        public string CardNumber { get; set; }

        /// <summary>
        /// CVV code
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "CVV")]
        public int CVV { get; set; }

        /// <summary>
        /// expiry month
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Expiry Month")]
        public int ExpiryMonth { get; set; }

        /// <summary>
        /// expiry year
        /// </summary>
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Expiry Year")]
        public int ExpiryYear { get; set; }

        /// <summary>
        /// billing address
        /// </summary>
        public Address Address { get; set; }
    }
    public class BetaPayment
    {
        public CreditCard CreditCard { get; set; }

        [MustBeTrue(ErrorMessage = "Please agree to the terms.")]
        [Display(Name = "I agree to have $10.00 charged to my credit card.")]
        public bool AuthorizeCharge { get; set; }
    }

    /// <summary>
    /// Validation attribute that demands that a boolean value must be true.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public class MustBeTrueAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool)value;
        }
    }
}
