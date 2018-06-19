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
            BinaryFormatter = 6,
            SoapFormatter = 7,
            NetDataContractSerializer = 8,
            DataContractSerializer = 9,
            ObjectStateFormatter = 10,
            LosFormatter = 11,
            XmlSerializer = 12
        }

        public enum XmlParserClassTypeEnum
        {
            XmlDocument = 0,
            XmlTextReader = 1
        }

        public enum XsltProcessorClassTypeEnum
        {
            XslCompiledTransform = 0,
            XslTransform = 1,
            [Display(Name = "Saxon HE")]
            SaxonHE = 2
        }
    }
}