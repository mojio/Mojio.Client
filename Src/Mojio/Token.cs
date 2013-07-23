using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class Token : GuidEntity
    {
        public override string Type
        {
            get { return "AT"; }
        }

        /// <summary>
        /// app id
        /// </summary>
        public Guid AppId { get; set; }

        /// <summary>
        /// user id
        /// </summary>
        public Guid? UserId { get; set; }

        /// <summary>
        /// expiry timestamp
        /// </summary>
        public DateTime ValidUntil { get; set; }
    }
}
