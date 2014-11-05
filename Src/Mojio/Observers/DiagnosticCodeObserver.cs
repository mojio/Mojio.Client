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
            : base(ObserverType.Event, typeof(Vehicle), null, ObserverTiming.edge)
        {
            DiagnosticCodes = new string[] { };
        }

        public DiagnosticCodeObserver(Guid vehicleId, string[] diagnosticCodes, ObserverTiming timing = ObserverTiming.edge)
            : base(ObserverType.Event,  typeof(Event), typeof(Vehicle), timing)
        {
            ParentId = vehicleId;
            DiagnosticCodes = diagnosticCodes;
        }
    }
}
