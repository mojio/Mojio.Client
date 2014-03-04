using System;
using System.Net;

namespace Mojio.Client
{
    public class MojioRequest
    {
        public MojioClient Client { get; set; }

        public int Skip { get; set; }

        public Type From { get; set; }

        public string[] Segments { get; set; }
    }
}

