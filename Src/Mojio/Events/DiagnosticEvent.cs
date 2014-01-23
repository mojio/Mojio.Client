using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mojio;

namespace Mojio.Events
{
    [CollectionNameAttribute(typeof(Event))]
    public class DiagnosticEvent : Event
    {
        public DiagnosticEvent()
        {
            EventType = Events.EventType.Diagnostic;
        }

        public DiagnosticEvent(string[] DTCs)
        {
            EventType = Events.EventType.Diagnostic;
            this.DTCCodes = DTCs;
        }

        /// <summary>
        /// Diagnostic Trouble Code
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string[] DTCCodes { get; set; }

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


