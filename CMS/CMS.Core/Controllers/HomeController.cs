using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Core.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            NLog.LogManager.GetCurrentClassLogger().Log(NLog.LogLevel.Error, "test");
            int a = 1;
            int b = 0;
            int c = a / b;
            return View();
        }
    }
}