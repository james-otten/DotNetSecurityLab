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
            [Display(Name = "FSPickler Json")]
            FSPicklerJson = 2,
            [Display(Name = "FSPickler Xml")]
            FSPicklerXml = 3,
            [Display(Name = "Sweet.Jayson")]
            SweetJayson = 4,
            JavascriptSerializer = 5,
            DataContractJsonSerializer = 6,
            BinaryFormatter = 7,
            SoapFormatter = 8,
            NetDataContractSerializer = 9,
            DataContractSerializer = 10,
            ObjectStateFormatter = 11,
            LosFormatter = 12,
            XmlSerializer = 13
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