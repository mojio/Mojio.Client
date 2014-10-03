using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class SimCard : GuidEntity
    {
        private string iccid;
        private string msisdn;

        public override EntityType Type
        {
            get { return EntityType.SimCard; }
        }

        public Guid? MojioId { get; set; }

        [DefaultSort]
        public string Iccid
        {
            get
            {
                return iccid;
            }
            set
            {
                iccid = value.Replace("-", "").Replace(".", "").Replace(" ", "").Trim();
            }
        }


        public string Msisdn {
            get
            {
                return msisdn;
            }
            set
            {
                msisdn = value.Replace("-", "").Replace(".", "").Replace(" ", "").Trim();
            }
        
        }
    }
}
