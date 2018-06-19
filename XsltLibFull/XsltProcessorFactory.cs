using System;
using XsltLibFull.Xslt;
using static XsltLibFull.XsltEnums;

namespace XsltLibFull
{
    public class XsltProcessorFactory
    {
        public IXsltProcessor GetXsltProcessor(XsltProcessorTypeEnum processorType)
        {
            switch(processorType)
            {
                case XsltProcessorTypeEnum.XslCompiledTransform:
                    return new XslCompiledTransformProcessor();
                case XsltProcessorTypeEnum.XslTransform:
                    return new XslTransformProcessor();
                case XsltProcessorTypeEnum.SaxonHE:
                    return new SaxonHEProcessor();
                default:
                    throw new Exception("Unsupported processor");
            }
        }
    }
}
