using Newtonsoft.Json;
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
    ///         
    [Observable]
    public partial class App : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.App; }
        }

        /// <summary>
        /// App name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Record creation timestamp
        /// </summary>
        [DefaultSort]
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Total number of downloads
        /// </summary>
        public int? Downloads { get; set; }

        /// <summary>
        /// Valid redirect uris
        /// </summary>
        public string[] RedirectUris { get; set; }

        /// <summary>
        /// Identifies the OAuth type of this application
        /// </summary>
        public AppTypes ApplicationType { get; set; }
    }

    public enum AppTypes { 
        web,
        installed
    }
}
