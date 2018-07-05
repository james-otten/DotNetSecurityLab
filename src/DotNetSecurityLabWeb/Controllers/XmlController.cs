using DotNetSecurityLabWeb.Models;
using System.Web.Mvc;
using XmlLibFull;
using XmlLibFull.Xml;
using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Controllers
{
    public class XmlController : Controller
    {
        // GET: Xml
        public ActionResult Index()
        {
            var model = new XmlViewModel();
            model.Data = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<foo>bar</foo>";
            return View(model);
        }

        // POST: Parse
        //Security Warning: Intentionally vulnerable to CSRF
        [ValidateInput(false)]//Security Warning: Unsafe, can lead to XSS
        public ActionResult Parse(string data, int parser)
        {
            var model = new XmlViewModel();
            model.Data = data;
            model.Parser = (XmlParserClassTypeEnum)parser;

            var factory = new XmlParserFactory();
            var xmlParser = factory.GetXmlParser((XmlEnums.XmlParserTypeEnum)parser);
            model.Output = xmlParser.ParseXml(data);

            return View("Index", model);
        }
    }
}