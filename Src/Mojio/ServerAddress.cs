using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    public class ServerAddress
    {
        public ServerAddress()
        {
        }

        public ServerAddress(string address, int port)
        {
            Address = address;
            Port = port;
        }

        public ServerAddress(string address)
        {
            int col = address.IndexOf(':');
            if (col == -1)
            {
                throw new ArgumentException("Invalid host:port format");
            }

            var addressStr = address.Substring(0, col);
            var portStr = address.Substring(col + 1);
            int port;

            if (!Int32.TryParse(portStr, out port))
            {
                throw new ArgumentException("Invalid port number");
            }

            Address = addressStr;
            Port = port;
        }

        public string Address { get; set; }

        public int Port { get; set; }

        public override string ToString()
        {
            return String.Format("{0}:{1}", Address, Port);
        }
    }
}
