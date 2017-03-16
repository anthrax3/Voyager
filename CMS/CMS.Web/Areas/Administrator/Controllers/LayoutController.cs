using CMS.Core.Services.AdminMenu;
using CMS.Web.Areas.Administrator.ViewModels;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Areas.Administrator.Controllers
{
    public class LayoutController : Controller
    {
        IAdminMenuService adminMenuService = null;
        public LayoutController(IAdminMenuService adminMenuService)
        {
            this.adminMenuService = adminMenuService;
        }

        public ActionResult Menu()
        {
            var models = adminMenuService.GetMenuItems();
            List<MenuItemViewModel> viewModelList = models
                .Select(x => new MenuItemViewModel().InjectFrom(x))
                                                    .Cast<MenuItemViewModel>()
                .ToList();

            return View("_Menu", viewModelList);
        }
    }
}