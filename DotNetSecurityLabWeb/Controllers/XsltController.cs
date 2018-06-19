using DotNetSecurityLabWeb.Models;
using System.Web.Mvc;
using XsltLibFull;
using static DotNetSecurityLabWeb.Models.DotNetSecurityLabEnums;

namespace DotNetSecurityLabWeb.Controllers
{
    public class XsltController : Controller
    {
        // GET: Xslt
        public ActionResult Index()
        {
            var model = new XsltViewModel();
            model.Xml = @"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<foo>bar</foo>";
            model.Xslt = @"<?xml version=""1.0""?>
<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform"">
    <xsl:template match=""@*|node()"">
        <xsl:copy>
            <xsl:apply-templates select=""@*|node()""/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>";
            return View(model);
        }

        // POST: Process
        //Security Warning: Intentionally vulnerable to CSRF
        [ValidateInput(false)]//Security Warning: Unsafe, can lead to XSS
        public ActionResult Process(string xslt, string xml, int processor)
        {
            var model = new XsltViewModel
            {
                Xslt = xslt,
                Xml = xml,
                Parser = (XsltProcessorClassTypeEnum)processor
            };

            var factory = new XsltProcessorFactory();
            var xsltProcessor = factory.GetXsltProcessor((XsltEnums.XsltProcessorTypeEnum)processor);
            model.Output = xsltProcessor.ProcessXslt(xslt, xml);

            return View("Index", model);
        }
    }
}