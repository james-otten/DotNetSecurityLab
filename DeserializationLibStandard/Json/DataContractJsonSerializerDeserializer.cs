using DeserializationLibStandard;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DeserializationLibFull.Json
{
    public class DataContractJsonSerializerDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            //The following code is based on an example from Alvaro Muñoz & Oleksandr Mirosh - Friday the 13th JSON Attacks
            var ser = new DataContractJsonSerializer(typeof(T));
            var bytes = Encoding.ASCII.GetBytes(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)ser.ReadObject(stream);
            }
        }

        public string Serialize(T obj)
        {
            var settings = new DataContractJsonSerializerSettings
            {
                EmitTypeInformation = System.Runtime.Serialization.EmitTypeInformation.Always,
            };
            var ser = new DataContractJsonSerializer(typeof(T), settings);
            using (var stream = new MemoryStream())
            {
                ser.WriteObject(stream, obj);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }
    }
}
