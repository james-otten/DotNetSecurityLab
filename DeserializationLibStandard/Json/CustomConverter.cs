using DeserializationLibStandard.DataTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DeserializationLibStandard.Json
{
    class CustomConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Person));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var person = new Person();
            person.Name = obj["Name"].ToObject<Name>();
            person.Age = (int)obj["Age"];
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            person.Address = JsonConvert.DeserializeObject<Object>(obj["Address"].ToString(),
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            person.Properties = JsonConvert.DeserializeObject<List<Property>>(obj["Properties"].ToString(),
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return person;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject jo = new JObject();
            Type type = value.GetType();
            jo.Add("type", type.Name);

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.CanRead)
                {
                    object propVal = prop.GetValue(value, null);
                    if (propVal != null)
                    {
                        jo.Add(prop.Name, JToken.FromObject(propVal, serializer));
                    }
                }
            }
            jo.WriteTo(writer);
        }
    }
}
