using DotNetSecurityLabWeb.Models;
using System;
using System.Web.Mvc;

namespace DotNetSecurityLabWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            var model = new AboutViewModel();
            model.ReferencedAssemblies = GetReferencedAssemblies();
            return View(model);
        }

        private string GetReferencedAssemblies()
        {
            var ret = "";
            foreach(var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                ret += asm.GetName() + "\n";
            }

            return ret;
        }
    }
}