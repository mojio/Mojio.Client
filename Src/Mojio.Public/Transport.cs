using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    [Flags]
    public enum Transport
    {
        Unspecified = 0,
        SignalR = 1 << 0,
        Pubnub = 1 << 1,
        ApplePush = 1 << 2,
        AndroidPush = 1 << 3,
        HttpPost = 1 << 4
    }
}
