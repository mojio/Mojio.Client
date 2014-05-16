using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Events
{
    /// <summary>
    /// DeviceDiagnostic Event
    /// </summary>
    [CollectionNameAttribute(typeof(Event))]
    public class DeviceDiagnosticEvent : Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeviceDiagnosticEvent"/> class.
        /// </summary>
        public DeviceDiagnosticEvent()
        {
            EventType = Events.EventType.DeviceDiagnostic;
        }

        public RegistrationState GsmState { get; set; }
        public RegistrationState GprsState { get; set; }
        public bool? PdpActive { get; set; }
        public double? HoursOffline { get; set; }
        public double? HoursOnline { get; set; }
        public int? PowerUpCount { get; set; }
        public int? ResetCount { get; set; }
        public double? GpsLostPercent { get; set; }
        public double? GpsLostQualityPercent { get; set; }
        public double? GsmLostPercent { get; set; }
        public double? GprsLostPercent { get; set; }
        public double? PdpLostPercent { get; set; }
        public int? LowVoltageCount { get; set; }
        public int? HighVoltageCount { get; set; }
        public int? ContextActivationCount { get; set; }
        public double? DataBytesOut { get; set; }
        public double? DataBytesIn { get; set; }
        public double? AckBytesIn { get; set; }
        public int? SmsOutCount { get; set; }
        public int? SmsInCount { get; set; }
        public int? SmsSpamCount { get; set; }
        
    }
}
