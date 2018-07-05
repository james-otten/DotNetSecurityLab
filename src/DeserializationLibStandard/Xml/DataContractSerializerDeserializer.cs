using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace DeserializationLibStandard.Xml
{
    public class DataContractSerializerDeserializer<T> : IVulnerableDeserializer<T>
    {
        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var ser = new DataContractSerializer(typeof(T));
            var bytes = Encoding.ASCII.GetBytes(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)ser.ReadObject(stream);
            }
        }

        public string Serialize(T obj)
        {
            var ser = new DataContractSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                ser.WriteObject(stream, obj);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }
    }
}
