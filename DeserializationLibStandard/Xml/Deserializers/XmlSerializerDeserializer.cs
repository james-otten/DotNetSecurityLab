using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace DeserializationLibStandard.Xml.Deserializers
{
    public class XmlSerializerDeserializer<T> : IVulnerableDeserializer<T>
    {
        private static readonly string ROOT_ELEMENT_NAME = "root";
        private static readonly string TYPE_ATTRIBUTE = "type";

        //Security Warning: The following code is intentionally vulnerable to a serialization vulnerability
        public T Deserialize(string data)
        {
            var root = GetSingleNodeFromXml(data, ROOT_ELEMENT_NAME);
            var ser = new XmlSerializer(Type.GetType(root.Attributes[TYPE_ATTRIBUTE].Value));
            var bytes = Encoding.ASCII.GetBytes(root.InnerXml);
            using (var stream = new MemoryStream(bytes))
            {
                return (T)ser.Deserialize(stream);
            }
        }

        public string Serialize(T obj)
        {
            var serialized = "";
            var ser = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream())
            {
                ser.Serialize(stream, obj);
                serialized = Encoding.ASCII.GetString(stream.ToArray());
            }
            
            var typeName = typeof(T).ToString();
            var doc = new XmlDocument();
            var el = doc.CreateElement(ROOT_ELEMENT_NAME);
            var attr = doc.CreateAttribute(TYPE_ATTRIBUTE);
            attr.Value = typeName;
            el.Attributes.Append(attr);
            el.InnerXml = GetSingleNodeFromXml(serialized, GetSimpleTypeName(typeName)).OuterXml;
            doc.AppendChild(el);

            return doc.OuterXml;
        }

        private XmlNode GetSingleNodeFromXml(string xml, string element)
        {
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            return doc.SelectSingleNode(element);
        }

        private string GetSimpleTypeName(string typeName)
        {
            var l = typeName.Split('.');
            return l[l.Length - 1];
        }
    }
}
