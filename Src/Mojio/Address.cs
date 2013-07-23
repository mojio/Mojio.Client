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
        /// <summary>
        /// address line 1
        /// </summary>
        [Display(Name = "Address 1")]
        [Required(ErrorMessage = "Required")]
        public string Address1 { get; set; }

        /// <summary>
        ///  address line 2
        /// </summary>
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        /// <summary>
        /// city
        /// </summary>
        [Display(Name = "City")]
        [Required(ErrorMessage = "Required")]
        public string City { get; set; }

        /// <summary>
        /// state or province
        /// </summary>
        [Display(Name = "State/Province")]
        [Required(ErrorMessage = "Required")]
        public string State { get; set; }

        /// <summary>
        /// zip or postal code
        /// </summary>
        [Display(Name = "Zip/Postal Code")]
        [Required(ErrorMessage = "Required")]
        public string Zip { get; set; }

        /// <summary>
        /// country
        /// </summary>
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Required")]
        public string Country { get; set; }
    }
}
