using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Observers
{
    public class ObserverToken : GuidEntity
    {
        /// <summary>
        /// Specifies the observer this token applies to.
        /// If this value is null, the observer was not persisted
        /// and your app was authorized to recieve messages on the
        /// specified channel. You don't need to ever unsubscribe
        /// </summary>
        public Guid? ObserverId { get; set; }

        /// <summary>
        /// Provided if using pubnub
        /// </summary>
        public string PubnubAuthKey { get; set; }


    }
}
