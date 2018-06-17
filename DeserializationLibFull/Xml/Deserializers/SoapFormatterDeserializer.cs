using DeserializationLibStandard;
using System.IO;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;

namespace DeserializationLibFull.Xml.Deserializers
{
    public class SoapFormatterDeserializer<T> : IVulnerableDeserializer<T>
    {
        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var formatter = new SoapFormatter();
            var bytes = Encoding.ASCII.GetBytes(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)formatter.Deserialize(stream);
            }
        }

        public string Serialize(T obj)
        {
            var formatter = new SoapFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }
    }
}
