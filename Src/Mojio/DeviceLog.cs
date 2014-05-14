using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class DeviceLog : GuidEntity
    {
        public override EntityType Type
        {
            get { return EntityType.DeviceLog; }
        }
        public string MojioId { get; set; }
        public Mojio Mojio { get; set; }

        [DefaultSort]
        public DateTime Timestamp { get; set; }
        public byte[] PacketBytes { get; set; }
        public string PacketString { get; set; }

        public DeviceLog() { }

        public DeviceLog(Mojio mojio, string packet)
        {
            this.Mojio = mojio;
            this.Timestamp = DateTime.UtcNow;
            this.PacketString = packet;
        }
    }
}
