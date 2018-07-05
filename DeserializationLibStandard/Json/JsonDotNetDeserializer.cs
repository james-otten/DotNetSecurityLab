using Newtonsoft.Json;

namespace DeserializationLibStandard.Json
{
    public class JsonDotNetDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            //The following code is based on an example from Alvaro Muñoz & Oleksandr Mirosh - Friday the 13th JSON Attacks
            var deser = JsonConvert.DeserializeObject<T>(data,
                new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            return deser;
        }

        public string Serialize(T obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
        }
    }
}
