using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Models
{
    public class XsltViewModel
    {
        public string Xml { get; set; }

        public string Xslt { get; set; }

        public string Output { get; set; }

        public XsltProcessorClassTypeEnum Parser { get; set; }
    }
}