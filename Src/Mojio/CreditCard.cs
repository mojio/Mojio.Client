using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        /// <summary>
        /// Determines whether the specified value of the object is valid.
        /// </summary>
        /// <param name="value">The value of the object to validate.</param>
        /// <returns>true if the specified value is valid; otherwise, false.</returns>
        public override bool IsValid(object value)
        {
            return value != null && value is bool && (bool)value;
        }
    }
}
