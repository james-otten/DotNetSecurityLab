using XmlLibFull.Xml.Parsers;
using System;

namespace XmlLibFull.Xml
{
    public class XmlParserFactory
    {
        public IXmlParser GetXmlParser(XmlEnums.XmlParserTypeEnum type)
        {
            switch(type)
            {
                case XmlEnums.XmlParserTypeEnum.XmlDocument:
                    return new XmlDocumentParser();
                case XmlEnums.XmlParserTypeEnum.XmlTextReader:
                    return new XmlTextReaderParser();
                default:
                    throw new Exception("Unsupported parser");
            }
        }
    }
}
