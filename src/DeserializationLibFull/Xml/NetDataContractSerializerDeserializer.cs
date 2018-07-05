using DeserializationLibStandard;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Runtime.Serialization;

namespace DeserializationLibFull.Xml
{
    class NetDataContractSerializerDeserializer<T> : IVulnerableDeserializer<T>
    {
        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var ser = new NetDataContractSerializer();
            var bytes = Encoding.ASCII.GetBytes(data);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)ser.ReadObject(stream);
            }
        }

        public string Serialize(T obj)
        {
            var ser = new NetDataContractSerializer();
            using (var stream = new MemoryStream())
            {
                ser.WriteObject(stream, obj);
                return Encoding.ASCII.GetString(stream.ToArray());
            }
        }
    }
}
