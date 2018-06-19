using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace XsltLibFull.Xslt
{
    public class XslTransformProcessor : IXsltProcessor
    {
        public string ProcessXslt(string xslt, string xml)
        {
            var inStreamXslt = new MemoryStream(Encoding.Default.GetBytes(xslt));
            var readerSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlUrlResolver()
            };
            var xsltReader = XmlReader.Create(inStreamXslt, readerSettings);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
#pragma warning disable CS0618 // Type or member is obsolete
            var transformer = new XslTransform();
#pragma warning restore CS0618 // Type or member is obsolete
            transformer.Load(xsltReader);
            
            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                transformer.Transform(xmlDoc, new XsltArgumentList(), xmlTextWriter);
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
