using System.IO;
using System.Text;
using System.Xml;

namespace XmlLibFull.Xml.Parsers
{
    public class XmlDocumentParser : IXmlParser
    {
        //Security Warning: The following code is intentionally vulnerable to a XXE vulnerability
        public string ParseXml(string data)
        {
            var inStream = new MemoryStream(Encoding.Default.GetBytes(data));
            var settings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlUrlResolver()
            };
            var reader = XmlReader.Create(inStream, settings);

            var doc = new XmlDocument();
            doc.Load(reader);

            return XmlToString(doc);
        }

        private string XmlToString(XmlDocument doc)
        {
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                doc.WriteTo(xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
