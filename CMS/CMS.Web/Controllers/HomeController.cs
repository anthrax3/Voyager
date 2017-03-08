using CMS.Web.DAL;
using CMS.Web.Models;
using CMS.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IDatabaseContext db)
        {

        }

        public ActionResult Index()
        {
            return View();
        }
    }
}