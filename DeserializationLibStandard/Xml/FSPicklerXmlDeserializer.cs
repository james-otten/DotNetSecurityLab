using MBrace.FsPickler;
using System.IO;
using System.Text;

namespace DeserializationLibStandard.Xml
{
    public class FSPicklerXmlDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            var ser = FsPickler.CreateXmlSerializer();
            using (var sr = new StringReader(data))
            {
                return ser.Deserialize<T>(sr);
            }
        }

        public string Serialize(T obj)
        {
            var ser = FsPickler.CreateXmlSerializer();
            var output = new StringBuilder();
            using (TextWriter sw = new StringWriter(output))
            {
                ser.Serialize<T>(sw, obj);
            }
            return output.ToString();
        }
    }
}
