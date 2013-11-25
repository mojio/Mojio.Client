using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Mojio
{
    //public class MMY: StringEntity
    //{
    //    public string Make { get; set; }
    //    public string Model { get; set; }
    //    public double Year { get; set; }
    //}

    public class Make : StringEntity
    {
        public string MakeName { get; set; }
        [JsonIgnore]
        public Model[] Model { get; set; }
    }

    public class Model : StringEntity
    {
        public string ModelName { get; set; }
        [JsonIgnore]
        public double[] Years { get; set; }
    }

}
