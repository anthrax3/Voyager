using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Administrator.Controllers
{
    public class LayoutController : Controller
    {
        public LayoutController()
        {

        }

        public ActionResult Menu()
        {
            var test = new List<ViewModels.MenuItemViewModel>();
            return View("_Menu", test);
        }
    }
}