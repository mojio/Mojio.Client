﻿using Mojio.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio
{
    /// <summary>
    /// Specifies the observer this token applies to.
    /// If this value is null, the observer was not persisted
    /// and your app was authorized to recieve messages on the
    /// specified channel. You don't need to ever unsubscribe
    /// </summary>
    [JsonConverter(typeof(DiscriminatorConverter<ObserverToken>))]
    public class ObserverToken
    {
        public Transport Transport { get; set; }
    }

    /// <summary>
    /// A pubnub token
    /// </summary>
    public class PubnubObserverToken : ObserverToken 
    {
        /// <summary>
        /// Provided if using pubnub
        /// </summary>
        public string PubnubAuthKey { get; set; }

        public PubnubObserverToken()
        {
            Transport = global::Mojio.Transport.Pubnub;
        }

    }

    /// <summary>
    /// A APN observer token
    /// </summary>
    public class ApplePushObserverToken : ObserverToken
    {
        /// <summary>
        /// Provided if using APN
        /// </summary>
        public string DeviceToken { get; set; }

        public string AlertBody { get; set; }

        public string AlertCategory { get; set; }

        public string AlertSound { get; set; }

        public ApplePushObserverToken()
        {
            Transport = global::Mojio.Transport.ApplePush;
        }

    }

    /// <summary>
    /// A Google GCM observer token
    /// </summary>
    public class AndroidPushObserverToken : ObserverToken
    {
        /// <summary>
        /// Provided if using GCM
        /// </summary>
        public string DeviceRegistrationId { get; set; }

        public AndroidPushObserverToken()
        {
            Transport = global::Mojio.Transport.AndroidPush;
        }

    }

    public class HttpPostObserverToken : ObserverToken
    {
        public string Address { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public HttpPostObserverToken()
        {
            Transport = Transport.HttpPost;
        }
    }
}
