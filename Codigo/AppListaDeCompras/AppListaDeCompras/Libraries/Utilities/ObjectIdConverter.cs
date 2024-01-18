using MongoDB.Bson;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Fonte: https://gist.github.com/cleydson/d1583f87f6fb7e2a8ee67e2455a1bb56
namespace AppListaDeCompras.Libraries.Utilities
{
    public class ObjectIdConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value.GetType().IsArray)
            {
                writer.WriteStartArray();
                foreach (var item in (Array)value)
                {
                    serializer.Serialize(writer, item);
                }
                writer.WriteEndArray();
            }
            else
                serializer.Serialize(writer, value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            var objectIds = new List<ObjectId>();

            if (token.Type == JTokenType.Array)
            {
                foreach (var item in token.ToObject<string[]>())
                {
                    objectIds.Add(new ObjectId(item));
                }
                return objectIds.ToArray();
            }

            if (token.ToObject<string>().Equals("MongoDB.Bson.ObjectId[]"))
            {
                return objectIds.ToArray();
            }
            else
                return new ObjectId(token.ToObject<string>());
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(ObjectId));
        }
    }
}
