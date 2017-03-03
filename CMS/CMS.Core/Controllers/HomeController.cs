using CMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Core.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ILoggerService l)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}