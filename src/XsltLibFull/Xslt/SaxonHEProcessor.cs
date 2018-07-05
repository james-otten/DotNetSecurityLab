using Saxon.Api;
using System;
using System.IO;
using System.Text;
using System.Xml;

namespace XsltLibFull.Xslt
{
    public class SaxonHEProcessor : IXsltProcessor
    {
        //Security Warning: The following code is intentionally vulnerable to multiple vulnerabilities
        public string ProcessXslt(string xslt, string xml)
        {
            var processor = new Processor();
            var compiler = processor.NewXsltCompiler();
            compiler.BaseUri = new Uri(Directory.GetCurrentDirectory());

            var inStreamXslt = new MemoryStream(Encoding.Default.GetBytes(xslt));
            var inStreamXml = new MemoryStream(Encoding.Default.GetBytes(xml));
            var readerSettings = new XmlReaderSettings
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlUrlResolver()
            };
            var xsltReader = XmlReader.Create(inStreamXslt, readerSettings);

            var executable = compiler.Compile(xsltReader);
            var transformer = executable.Load();
            transformer.SetInputStream(inStreamXml, new Uri(Directory.GetCurrentDirectory()));

            using (var stringWriter = new StringWriter())
            using (var xmlTextWriter = XmlWriter.Create(stringWriter))
            {
                transformer.Run(new TextWriterDestination(xmlTextWriter));
                xmlTextWriter.Flush();
                return stringWriter.GetStringBuilder().ToString();
            }
        }
    }
}
