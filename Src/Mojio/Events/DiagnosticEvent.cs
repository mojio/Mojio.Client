using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio;

namespace Mojio.Events
{
    /// <summary>
    /// 
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public partial class DiagnosticEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticEvent"/> class.
        /// </summary>
        public DiagnosticEvent()
        {
            EventType = Events.EventType.Diagnostic;
        }

        /// <summary>
        /// Diagnostic Trouble Code Attribute
        /// </summary>
        public DTC[] DTCs { get; set; }

        /// <summary>
        /// Malfunction Indicator Lamp (Check engine light)
        /// </summary>
        public bool MilStatus { get; set; }

    }
}


