using System.IO;
using System.Text;
using System.Xml;

namespace XmlLibFull.Xml.Parsers
{
    public class XmlTextReaderParser : IXmlParser
    {
        //Security Warning: The following code is intentionally vulnerable to a XXE vulnerability
        public string ParseXml(string data)
        {
            var ret = "";
            var inStream = new MemoryStream(Encoding.Default.GetBytes(data));
            var reader = new XmlTextReader(inStream)
            {
                DtdProcessing = DtdProcessing.Parse,
                XmlResolver = new XmlUrlResolver(),
                EntityHandling = EntityHandling.ExpandEntities
            };
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        ret += string.Format("<{0}>", reader.Name);
                        break;
                    case XmlNodeType.EndElement:
                        ret += string.Format("</{0}>", reader.Name);
                        break;
                    case XmlNodeType.XmlDeclaration:
                        ret += string.Format("<?xml {0}?>", reader.Value);
                        break;
                    case XmlNodeType.EntityReference:
                        ret += reader.Value;
                        break;
                    case XmlNodeType.DocumentType:
                        ret += string.Format("<!DOCTYPE {0} [{1}]", reader.Name, reader.Value);
                        break;
                    default:
                        ret += reader.Value;
                        break;
                }
            }

            return ret;
        }
    }
}
