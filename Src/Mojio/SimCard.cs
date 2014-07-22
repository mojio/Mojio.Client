using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class SimCard : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.SimCard; }
        }

        public string Iccid { get; set; }
        public string Msisdn { get; set; }
        public string Apn { get; set; }
        public bool Activated { get; set; }

        public void FilterSimCharacters()
        {
            Iccid = Iccid.Replace("-", "").Replace(".", "").Replace(" ", "");
            Msisdn = Msisdn.Replace("-", "").Replace(".", "").Replace(" ", "");
        }
    }
}
