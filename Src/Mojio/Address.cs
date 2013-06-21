using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Address
    {
        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Required")]
        public string Address1 { get; set; }

        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "Required")]
        public string City { get; set; }

        [Display(Name = "State/Province")]
        [Required(ErrorMessage = "Required")]
        public string State { get; set; }

        [Display(Name = "Zip/Postal Code")]
        [Required(ErrorMessage = "Required")]
        public string Zip { get; set; }

        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }
    }
}
