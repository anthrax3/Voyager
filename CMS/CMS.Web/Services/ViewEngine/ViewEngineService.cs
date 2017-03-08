using CMS.Web.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CMS.Web.Services.ViewEngine
{
    public class ViewEngineService : IViewEngineService
    {
        public void UpdateViewLocalisations(List<string> localisations)
        {
            var viewEngine = ViewEngines.Engines.First() as ExtendedRazorViewEngine;
            viewEngine.SetLocations(localisations);
        }
    }
}