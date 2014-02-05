using Newtonsoft.Json;
using RestSharp.Deserializers;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public class RSJsonSerializer : IDeserializer, ISerializer
    {
        public string Namespace { get; set; }
        public string RootElement { get; set; }
        public string ContentType { get; set; }
        public string DateFormat { get; set; }

        private readonly Newtonsoft.Json.JsonSerializer Serializer;
        public RSJsonSerializer()
        {
            ContentType = "application/json";
            Serializer = new Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            Serializer.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        }

        public T Deserialize<T>(string content)
        {
            //return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);
            using (var stringReader = new StringReader(content) )
            {
                using (var jsonReader = new JsonTextReader(stringReader))
                {
                    return Serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            return Deserialize<T>(response.Content);
        }

        public string Serialize(object obj)
        {
            //return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    Serializer.Serialize(jsonTextWriter, obj);

                    var result = stringWriter.ToString();
                    return result;
                }
            }
        }
    }
}
