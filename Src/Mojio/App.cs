using Newtonsoft.Json;
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
    ///         
    [Observable]
    public partial class App : GuidEntity
    {
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
    }
}
