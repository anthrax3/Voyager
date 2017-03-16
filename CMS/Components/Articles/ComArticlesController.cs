using CMS.Core.DB;
using CMS.Core.Services.Positions;
using ComArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComArticles
{
    public class ComArticlesController : Controller
    {
        public ComArticlesController()
        {

        }

        public ActionResult TestAction(List<String> parameters)
        {
            return View("~/Components/ComArticles/Views/Index.cshtml");
        }
    }
}