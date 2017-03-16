using CMS.Web.Areas.Administrator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Administrator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ComponentView(String targetController, 
                String targetAction, List<String> targetParameters)
        {
            var data = new ComponentSiteDataViewModel()
            {
                Controller = targetController,
                Action = targetAction,
                Parameters = targetParameters
            };

            return View(data);
        }
    }
}