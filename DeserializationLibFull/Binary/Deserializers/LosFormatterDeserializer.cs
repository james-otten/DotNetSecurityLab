using DeserializationLibStandard;
using System.IO;
using System.Text;
using System.Web.UI;

namespace DeserializationLibFull.Binary.Deserializers
{
    class LosFormatterDeserializer<T> : IVulnerableDeserializer<T>
    {
        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var ser = new LosFormatter();
            var bytes = Encoding.ASCII.GetBytes(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)ser.Deserialize(stream);
            }
        }

        public string Serialize(T obj)
        {
            var ser = new LosFormatter();
            using (var stream = new MemoryStream())
            {
                ser.Serialize(stream, obj);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }
    }
}
