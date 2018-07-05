
namespace DeserializationLibStandard.Json
{
    public class FastJSONDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            //The following code is based on an example from Alvaro Muñoz & Oleksandr Mirosh - Friday the 13th JSON Attacks
            return fastJSON.JSON.ToObject<T>(data);
        }

        public string Serialize(T obj)
        {
            return fastJSON.JSON.ToJSON(obj);
        }
    }
}
