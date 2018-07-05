using DeserializationLibStandard;
using System.Web.Script.Serialization;

namespace DeserializationLibFull.Json
{
    class JavascriptSerializerDeserializer<T> : IVulnerableDeserializer<T>
    {
        public T Deserialize(string data)
        {
            //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
            //The following code is based on an example from Alvaro Muñoz & Oleksandr Mirosh - Friday the 13th JSON Attacks
            var sr = new JavaScriptSerializer(new SimpleTypeResolver());
            return sr.Deserialize<T>(data);
        }

        public string Serialize(T obj)
        {
            var ser = new JavaScriptSerializer(new SimpleTypeResolver());
            return ser.Serialize(obj);
        }
    }
}
