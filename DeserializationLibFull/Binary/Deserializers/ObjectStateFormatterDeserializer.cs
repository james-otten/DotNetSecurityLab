using DeserializationLibStandard;
using System;
using System.IO;
using System.Web.UI;

namespace DeserializationLibFull.Binary.Deserializers
{
    class ObjectStateFormatterDeserializer<T> : IVulnerableDeserializer<T>
    {
        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var ser = new ObjectStateFormatter();
            var bytes = Convert.FromBase64String(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)ser.Deserialize(stream);
            }
        }

        public string Serialize(T obj)
        {
            var ser = new ObjectStateFormatter();
            using (var stream = new MemoryStream())
            {
                ser.Serialize(stream, obj);
                return Convert.ToBase64String(stream.ToArray());
            }
        }
    }
}
