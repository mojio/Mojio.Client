using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public partial class App : GuidEntity
    {
        // TODO: MIGRATION remove TypeName and Type
        public static string TypeName = "App";
        public override string Type
        {
            get
            {
                return TypeName;
            }
        }

        /// <summary>
        /// app name
        /// </summary>
        [Display(Name = "Display Name")]
        [StringLength(32, MinimumLength=5, ErrorMessage="Name has to be between 5 and 32 characters")]
        public string Name { get; set; }

        /// <summary>
        /// description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// record creation timestamp
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// total number of downloads
        /// </summary>
        public int? Downloads { get; set; }

        //TODO: MIGRATION These fields are moved to AppPrivate
        /// <summary>
        /// secret key
        /// </summary>
        public Guid SecretKey { get; set; }
    }
}
