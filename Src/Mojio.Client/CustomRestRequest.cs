using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Mojio.Client
{
    /// <summary>
    /// this superclass is used due to limitations in RestRequest with respect to adding parameters
    /// </summary>
    public class CustomRestRequest : RestRequest
    {
        private CustomRestRequest() { /* intentionally hidden */ }

        /// <summary>
        /// calls the necessary base constructor
        /// </summary>
        /// <param name="url"></param>
        /// <param name="method"></param>
        public CustomRestRequest(string url, Method method)
            : base(url, method)
        {
            // nothing to do here
        }

        /// <summary>
        /// adds the parameter to the URL (.Resource)
        /// </summary>
        /// <param name="name">parameter name</param>
        /// <param name="value">parameter value</param>
        public new void AddParameter(string name, object value)
        {
            if (value == null)
                return;

            Resource += (Resource.Contains("?") ? "&" : "?") +
                string.Format("{0}={1}", name, value.ToString());
        }
    }
}
