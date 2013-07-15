using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public class Trip : GuidEntity
    {
        public string MojioId { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public float? MaxSpeed { get; set; }
        public float? AverageSpeed { get; set; }

        public float? Fuel { get; set; }
        public float? Distance { get; set; }

        public float? IdlePercent { get; set; }        

        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }        
    }
}
