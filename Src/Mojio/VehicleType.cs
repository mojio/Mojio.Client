using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class VehicleType : StringEntity
    {     
        //public string Make
        //{
        //    get { return Id; }
        //    set { Id = value; }
        //}

        public VehicleModelYear[] Models { get; set; }
    }

    public class VehicleModelYear
    {
        public string Model { get; set; }
        public int[] Year { get; set; }
    }
}
