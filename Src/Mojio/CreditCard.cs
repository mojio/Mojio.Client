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
        public string Id {get;set;}

        [Display(Name = "Type")]
        public string Type { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Name on Card")]
        public string NameOnCard { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Credit Card")]
        [CreditCard(ErrorMessage="Invalid")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "CVV")]
        public int CVV { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Expiry Month")]
        public int ExpiryMonth { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Expiry Year")]
        public int ExpiryYear { get; set; }

        public Address Address { get; set; }
    }
}
