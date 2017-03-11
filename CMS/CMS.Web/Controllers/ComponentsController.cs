using CMS.Core.Services.ComponentsManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Controllers
{
    public class ComponentsController : Controller
    {
        IComponentsManagerService componentsManager = null;

        public ComponentsController(IComponentsManagerService componentsManager)
        {
            this.componentsManager = componentsManager;
        }

        public PartialViewResult Call(String componentName, String action, 
                                      Dictionary<String, object> parameters)
        {
            var callParameters = new CallParameters()
            {
                ComponentName = componentName,
                ActionName = action,
                Parameters = parameters
            };

            var actionResult = componentsManager.CallComponent(callParameters);
            var test = actionResult.Model;
            var zxc = actionResult.View;
            return PartialView(actionResult.View, actionResult.Model);
        }
    }
}