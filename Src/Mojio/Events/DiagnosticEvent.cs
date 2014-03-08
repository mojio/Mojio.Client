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
    public class DiagnosticEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticEvent"/> class.
        /// </summary>
        public DiagnosticEvent()
        {
            EventType = Events.EventType.Diagnostic;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DiagnosticEvent"/> class.
        /// </summary>
        /// <param name="DTCs">The dt cs.</param>
        /// <param name="milStatus">if set to <c>true</c> [mil status].</param>
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


