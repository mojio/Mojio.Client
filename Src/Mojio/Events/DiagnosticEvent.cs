using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class DiagnosticEvent : Event
    {
        public DiagnosticEvent()
        {
            EventType = Events.EventType.Diagnostic;
        }

        /// <summary>
        /// Diagnostic Trouble Code(s)
        /// </summary>
        public string[] DTC { get; set; }

        /// <summary>
        /// Malfunction Indicator Lamp (Check engine light)
        /// </summary>
        public bool MilStatus { get; set; }
    }
}
