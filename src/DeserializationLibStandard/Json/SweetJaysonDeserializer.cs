using Sweet.Jayson;

namespace DeserializationLibStandard.Json
{
    public class SweetJaysonDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            return JaysonConverter.ToObject<T>(data);
        }

        public string Serialize(T obj)
        {
            var settings = JaysonSerializationSettings.DefaultClone();
            settings.TypeNames = JaysonTypeNameSerialization.All;
            return JaysonConverter.ToJsonString(obj, settings);
        }
    }
}
