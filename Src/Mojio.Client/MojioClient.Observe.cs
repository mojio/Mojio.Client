using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public partial class MojioClient
    {
        public string Observe<T>(Guid id, ObserverScope scope = ObserverScope.User )
            where T : BaseEntity
        {
           return Observe<T>(id.ToString(), scope);
        }

        public string Observe<T>(string id, ObserverScope scope = ObserverScope.User)
            where T : BaseEntity
        {
            var type = typeof(T);
            var request = GetRequest(Request("observe", type.Name, id), Method.GET);

            var response = RestClient.Execute(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return response.Content;
            return null;
        } 
    }
}
