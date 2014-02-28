using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mojio
{
    public enum ServiceType : int
    {
        SMS,
        UDP,
        TCP
    }
    public class Service : GuidEntity
    {
        public DateTime TimeStamp { get; set; }
        public byte[] Data { get; set; }
        public int Retries { get; set; }
        public bool Processing { get; set; }
        public bool Done { get; set; }
        public string MojioId { get; set; }
        public bool ConfirmationRequired { get; set; }
        public string StatusMessage { get; set; }
    }
}