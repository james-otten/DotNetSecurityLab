using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace XsltLibFull.Xslt
{
    public class XslCompiledTransformProcessor : IXsltProcessor
    {
        //Security Warning: The following code is intentionally vulnerable to multiple vulnerabilities
        public string ProcessXslt(string xslt, string xml)
        {
            var inStreamXslt = new MemoryStream(Encoding.Default.GetBytes(xslt));
            var inStreamXml = new MemoryStream(Encoding.Default.GetBytes(xml));
            var readerSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlUrlResolver()
            };
            var xsltReader = XmlReader.Create(inStreamXslt, readerSettings);
            var xmlReader = XmlReader.Create(inStreamXml, readerSettings);

            var settings = new XsltSettings(true, true);
            var processor = new XslCompiledTransform();
            processor.Load(xsltReader, settings, new XmlUrlResolver());

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                processor.Transform(xmlReader, xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
