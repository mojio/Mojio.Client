using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    class DiagnosticEvent : Event
    {
        /// <summary>
        /// Diagnostic Trouble Code
        /// </summary>
        public string DTC { get; set; }
    }
}
