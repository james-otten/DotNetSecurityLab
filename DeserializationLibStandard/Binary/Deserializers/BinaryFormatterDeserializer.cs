using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace DeserializationLibStandard.Binary.Deserializers
{
    public class BinaryFormatterDeserializer<T>: IVulnerableDeserializer<T>
    {
        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var formatter = new BinaryFormatter();
            var bytes = Convert.FromBase64String(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        public string Serialize(T obj)
        {
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
