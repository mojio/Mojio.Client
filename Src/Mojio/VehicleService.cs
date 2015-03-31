using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public partial class VehicleService
    {
        public int DOVehicleId { get; set; }
        public int DOEngineId { get; set; }
        public string TransNotes { get; set; }
        public string MaintenanceCategory { get; set; }
        public string MaintenanceName { get; set; }
        public string MaintenanceNotes { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
        public string OperatingParameter { get; set; }
        public string OperatingParameterNotes { get; set; }
        public string ComputerCode { get; set; }
        public string ServiceEvent { get; set; }
        public string IntervalType { get; set; }
        public decimal? Value { get; set; }
        public string Units { get; set; }
        public decimal? InitialValue { get; set; }

    }
}
