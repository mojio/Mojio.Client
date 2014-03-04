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

        public DiagnosticEvent(string[] DTCs, bool milStatus)
        {
            EventType = Events.EventType.Diagnostic;
            this.Codes = DTCs;
            this.MilStatus = milStatus;
        }

        /// <summary>
        /// Diagnostic Trouble Code
        /// </summary>
        [Newtonsoft.Json.JsonIgnore]
        public string[] Codes { get; set; }

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


