using MBrace.FsPickler.Json;
using System.IO;
using System.Text;

namespace DeserializationLibStandard.Json
{
    public class FSPicklerJsonDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            var ser = FsPickler.CreateJsonSerializer();
            using (TextReader sr = new StringReader(data))
            {
                return ser.Deserialize<T>(sr);
            }
            
        }

        public string Serialize(T obj)
        {
            var ser = FsPickler.CreateJsonSerializer();
            var output = new StringBuilder();
            using (TextWriter sw = new StringWriter(output))
            {
                ser.Serialize<T>(sw, obj);
            }
            return output.ToString();
        }
    }
}
