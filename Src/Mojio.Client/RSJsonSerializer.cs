using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Serializers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client
{
    public class RSJsonSerializer : IDeserializer, ISerializer
    {
        public string Namespace { get; set; }

        public string RootElement { get; set; }

        public MediaTypeHeaderValue ContentType { get; set; }

        public string DateFormat { get; set; }

        public Newtonsoft.Json.JsonSerializer Serializer { get; private set; }

        public static bool IsJson (string input)
        {
            input = input.Trim ();
            return (input.StartsWith ("{") && input.EndsWith ("}"))
            || (input.StartsWith ("[") && input.EndsWith ("]"));
        }

        public RSJsonSerializer ()
        {
            ContentType = new MediaTypeHeaderValue("application/json");

            Serializer = new Newtonsoft.Json.JsonSerializer {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            Serializer.Converters.Add (new Newtonsoft.Json.Converters.StringEnumConverter ());
        }

        public T Deserialize<T>(string content)
        {
            return Deserialize<T>(System.Text.Encoding.UTF8.GetBytes(content));
        }

        public T Deserialize<T> (byte[] content)
        {
            try {
                //return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(response.Content);

                using (var reader = new StreamReader(new MemoryStream (content))) {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        return Serializer.Deserialize<T> (jsonReader);
                    }
                }
            }catch(Exception e) {
                Log.Create (e);
                return default(T);
            }
        }

        public T Deserialize<T> (IRestResponse response)
        {
            return Deserialize<T> (response.RawBytes);
        }

        public byte[] Serialize (object obj)
        {
                //return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
                using (var stringWriter = new StringWriter ()) {
                    using (var jsonTextWriter = new JsonTextWriter (stringWriter)) {
                        Serializer.Serialize (jsonTextWriter, obj);

                        var result = stringWriter.ToString();
                        return System.Text.Encoding.UTF8.GetBytes(result);
                    }
                }
        }
    }
}
