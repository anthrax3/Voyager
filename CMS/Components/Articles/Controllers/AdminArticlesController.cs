using ComArticles.Models;
using ComArticles.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ComArticles
{
    public class AdminArticlesController : Controller
    {
        IArticlesService articlesService = null;
        public AdminArticlesController(IArticlesService articlesService)
        {
            this.articlesService = articlesService;
        }

        public ActionResult ArticlesList()
        {
            return View("~/Components/ComArticles/Views/Admin/ArticlesList.cshtml");
        }
    }
}