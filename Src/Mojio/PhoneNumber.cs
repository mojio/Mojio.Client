using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mojio
{
    public enum PhoneType
    {
        Home,
        Work,
        Mobile
    }

    public class PhoneNumber
    {
        public PhoneType Type { get; set; }
        public int CountryCode { get; set; }
        public int AreaCode { get; set; }
        public int Number { get; set; }
        public int Ext { get; set; }
    }
}
