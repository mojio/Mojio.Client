using Mojio.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    [CollectionNameAttribute("Observer")]
    public partial class DiagnosticCodeObserver : ConditionalObserverBase
    {
        public string[] DiagnosticCodes { get; set; }

        public DiagnosticCodeObserver()
            : base(ObserverType.Diagnostic, typeof(Vehicle), null, ObserverTiming.edge)
        {
            DiagnosticCodes = new string[] { };
        }

                /// <summary>
        /// <param name="altitudeLow">Lower bound for the altitude, any altitude above this threshold fires an observation event</param>
        /// <param name="altitudeHigh">Optional Upper bound, any altitude below this threshold and above LowAltitude, fires an observe event</param>
        /// </summary>
        public DiagnosticCodeObserver(Guid vehicleId, string[] diagnosticCodes = null,
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Diagnostic,
                    typeof(Vehicle),  // events == true means observe events for a vehicle
                    null,  // events == false means observe a vehicle
                    timing)
        {
            if (diagnosticCodes == null)
                diagnosticCodes = new string[] { "All" };

            SubjectId = vehicleId;
            DiagnosticCodes = diagnosticCodes;
        }

        public DiagnosticCodeObserver(Guid vehicleId, bool events = false, string[] diagnosticCodes = null, 
            ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Diagnostic,
                    events == true ? typeof(Event) : typeof(Vehicle),  // events == true means observe events for a vehicle
                    events == true ? typeof(Vehicle) : null,  // events == false means observe a vehicle
                    timing)
        {
            if (diagnosticCodes == null)
                diagnosticCodes = new string[] { "All" };

            if (events)
                ParentId = vehicleId;
            else
                SubjectId = vehicleId; 

            DiagnosticCodes = diagnosticCodes;
        }
    }
}
