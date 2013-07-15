using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Mojio
{
    public partial class User : GuidEntity
    {
        public string UserName { get; set; }

        [Display(Name="First Name")]
        [MaxLength(32, ErrorMessage="Maximum lenght 32 characters")]
        public string FirstName { get; set; }
        
        [Display(Name = "Last Name")]
        [MaxLength(32, ErrorMessage = "Maximum lenght 32 characters")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
        
        public int UserCount { get; set; }
        public int? Credits { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime LastPasswordChangedDate { get; set; }
    }
}
