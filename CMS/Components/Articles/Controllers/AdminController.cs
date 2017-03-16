using ComArticles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComArticles
{
    public class AdminController : Controller
    {
        public AdminController()
        {

        }

        public ActionResult ArticlesList()
        {
            return View("~/Components/ComArticles/Views/ArticlesList.cshtml");
        }
    }
}