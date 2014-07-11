using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Mojio.Serialization
{
    public class DiscriminatorConverter<T> : JsonConverter
        where T : class
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///   <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        /// <summary>Reads the JSON representation of the object.</summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType,
          object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);
            var target = Create(objectType, jsonObject, serializer);
            if (target != null)
                serializer.Populate(jsonObject.CreateReader(), target);
            return target;
        }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON.
        /// </summary>
        /// <value>
        /// <c>true</c> if this <see cref="T:Newtonsoft.Json.JsonConverter" /> can write JSON; otherwise, <c>false</c>.
        /// </value>
        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        /// <summary>Writes the JSON representation of the object.</summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The value.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //serializer.Serialize(writer, value);
            throw new NotImplementedException();
        }

        /// <summary>Creates the specified object type.</summary>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="jsonObject">The json object.</param>
        /// <param name="serializer">The serializer.</param>
        /// <returns></returns>
        protected T Create (Type objectType, JObject jsonObject, JsonSerializer serializer)
        {
            var map = TypeEnumDiscriminatorMap.GetMap(typeof(T));
            if (map == null)
                throw new ArgumentException("Type discriminator map does not exist for " + typeof(T));

            var disc = jsonObject[map.Property];
            // Discriminator may not be found as default values
            // are not transmitted
            if (disc != null)
                return map.Create(disc.ToString()) as T;
            return map.Create() as T;
        }
    }
}
