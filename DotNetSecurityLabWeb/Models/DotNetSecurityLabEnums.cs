using System.ComponentModel.DataAnnotations;

namespace DotNetSecurityLabWeb.Models
{
    public static class DotNetSecurityLabEnums
    {
        public enum SerializationTypeEnum
        {
            FastJSON = 0,
            [Display(Name = "Json.Net")]
            JsonDotNet = 1,
            FSPickler = 2,
            [Display(Name = "Sweet.Jayson")]
            SweetJayson = 3,
            JavascriptSerializer = 4,
            DataContractJsonSerializer = 5,
        }

        public enum XmlParserClassTypeEnum
        {
            XmlDocument = 0,
            XmlTextReader = 1
        }
    }
}