using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Models
{
    public class XmlViewModel
    {
        public string Data { get; set; }

        public string Output { get; set; }

        public XmlParserClassTypeEnum Parser { get; set; }
    }
}